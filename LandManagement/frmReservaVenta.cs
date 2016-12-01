using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using LandManagement.Business;
using LandManagement.Entities;
using LandManagement.Utilidades;
using System.Reflection;

namespace LandManagement
{
    public partial class frmReservaVenta : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private tboperaciones operacion;
        private Form formPadre;
        ValidarControles validarControles;
        private ErrorProvider errorProvider1 = new ErrorProvider();

        public frmReservaVenta()
        {
            InitializeComponent();
        }

        public frmReservaVenta(tboperaciones _operacion, Form _formularioPadre)
        {
            InitializeComponent();
            
            this.operacion = _operacion;
            this.formPadre = _formularioPadre;
 
            btnGuardar.Click -= new EventHandler(btnGuardar_Click);
            btnGuardar.Click += new EventHandler(btnGuardarActualiza_Click);
        }

        private void frmReservaVenta_Load(object sender, EventArgs e)
        {
            try
            {
                pnlControles.AutoScroll = true;
                cmbCliente.Sorted = true;
                this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
                this.CargarCombos();
                gbxDetallePropiedad.Enabled = false;

                cmbDireccion.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbDireccion.AutoCompleteSource = AutoCompleteSource.ListItems;

                cmbCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;

                InicializarGrillaReservantes();

                if (this.operacion != null)
                {
                    tboperaciones operacionLocal = new tboperaciones();
                    operacionLocal = this.operacion;
                    CargoFormulario(operacionLocal);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al cargar formulario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateChildren())
                {
                    Cursor.Current = Cursors.WaitCursor;

                    tboperaciones operacion = new tboperaciones();
                    operacion.tbreservaventa = new tbreservaventa();

                    CargaObjeto(operacion);
                    GuardaObjeto(operacion);
                    MensajeOk();
                    this.Close();

                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarActualiza_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateChildren())
                {
                    Cursor.Current = Cursors.WaitCursor;

                    tboperaciones operacionLocal = new tboperaciones();
                    operacionLocal = this.operacion;
                    CargaObjetoActualizable(operacionLocal);
                    GuardaObjeto(operacionLocal);

                    MensajeOk();
                    ((frmOperacionListado)formPadre).CargarGrilla();
                    this.Close();

                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.MensajeCancelar();
        }

        private void CargaObjeto(tboperaciones _operacion)
        {
            //Asigno fecha de la operacion
            _operacion.ope_fecha = dtpFecha.Value;

            //Asigno id de la propiedad a la operacion
            _operacion.pro_id = ((tbpropiedad)cmbDireccion.SelectedItem).pro_id;
            //this.operacion.pro_id = ((tbpropiedad)cmbDireccion.SelectedItem).pro_id;

            //Asigno id de usuario a la operacion
            _operacion.usu_id = Utilidades.VariablesDeSesion.UsuarioLogueado.usu_id;
            //this.operacion.usu_id = Utilidades.VariablesDeSesion.UsuarioLogueado.usu_id;

            CargoPropietariosALaOperacion(_operacion);
            CargoReservanteALaOperacion(_operacion);
            CargaObjetoActualizable(_operacion);
        }

        private void CargaObjetoActualizable(tboperaciones _operacion)
        {
            CargoDatosOperacionReservaVenta(_operacion);
        }

        private void CargoDatosOperacionReservaVenta(tboperaciones _operacion)
        {
            _operacion.tbreservaventa.rev_oferta = Convert.ToDouble(txbOferta.Text);
            _operacion.tbreservaventa.rev_observaciones = txbObservaciones.Text;
        }

        public void CargoReservanteALaOperacion(tboperaciones _operacion)
        {
            tbclienteoperacion clienteOperacion;

            if (dgvReservantes.Rows.Count > 0)
            {
                foreach (DataGridViewRow obj in dgvReservantes.Rows)
                {
                    clienteOperacion = new tbclienteoperacion();
                    clienteOperacion.cli_id = this.ObtenerIdReservanteGrilla(obj);
                    clienteOperacion.stc_id = (int)TipoOperador.RESERALQUI;

                    _operacion.tbclienteoperacion.Add(clienteOperacion);
                }

            }
        }

        private void CargoPropietariosALaOperacion(tboperaciones _operacion)
        {
            tbclienteoperacion clienteOperacion;
            //this.operacion.tbclienteoperacion.Clear();
            _operacion.tbclienteoperacion.Clear();

            ClienteBusiness clienteBusiness = new ClienteBusiness();
            List<tbcliente> listaClientes = (List<tbcliente>)clienteBusiness.GetClientePorPropiedad(
                new tbpropiedad() { pro_id = ((tbpropiedad)cmbDireccion.SelectedItem).pro_id });

            if (listaClientes.Count > 0)
            {
                foreach (var obj in listaClientes)
                {
                    clienteOperacion = new tbclienteoperacion();
                    clienteOperacion.cli_id = obj.cli_id;
                    clienteOperacion.stc_id = (int)TipoOperador.PROPIETARI;

                    //this.operacion.tbclienteoperacion.Add(clienteOperacion);
                    _operacion.tbclienteoperacion.Add(clienteOperacion);
                }
            }
        }

        private void GuardaObjeto(tboperaciones _operacion)
        {
            OperacionBusiness operacionBusiness = new OperacionBusiness();
            if (_operacion.ope_id != 0)
                operacionBusiness.Update(_operacion, _operacion.tbreservaventa);
            else
                operacionBusiness.Create(_operacion);
        }

        #region Cargo controles de Dirección y Cliente seleccionado
        private void cmbDireccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarControlesPropiedad((tbpropiedad)cmbDireccion.SelectedItem);
        }

        private void CargarControlesPropiedad(tbpropiedad p)
        {
            cmbTipoPropiedad.Text = p.tbtipopropiedad.tip_descripcion;
            txbCalle.Text = p.pro_calle;
            txbNumero.Text = p.pro_numero.ToString();
            cmbPiso.Text = p.pro_piso.ToString();
            cmbDepto.Text = p.pro_departamento;
            txbLocalidad.Text = p.pro_localidad;
            txbCodigoPostal.Text = p.pro_codigo_postal;
        }
        #endregion

        #region Grilla de Reservantes
        public void InicializarGrillaReservantes()
        {
            dgvReservantes.Rows.Clear();
            dgvReservantes.Columns.Clear();
            string[] columnasGrilla = {
                                        "cli_id",
                                        "tif_id",
                                        "cli_nombre_completo",
                                        "cli_nombre",
                                        "cli_apellido",
                                        "cli_numero_documento",
                                        "cli_fecha_nacimiento"
                                      };

            int i = 0;
            DisplayNameHelper displayNameHelper = new DisplayNameHelper();
            foreach (string s in columnasGrilla)
            {
                PropertyInfo pi = typeof(tbcliente).GetProperty(s);
                string columna = displayNameHelper.GetMetaDisplayName(pi);
                dgvReservantes.Columns.Add(s, columna);
                i++;
            }

            dgvReservantes.Columns[0].Visible = false;
            dgvReservantes.Columns[1].Visible = false;
            dgvReservantes.Columns[2].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            tbcliente cliente = (tbcliente)cmbCliente.SelectedItem;
            cmbCliente.Items.Remove(cliente);
            AgregaAutorizanteGrilla(cliente);
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            int idCliente = 0;
            if (dgvReservantes.Rows.Count > 0)
            {
                foreach (DataGridViewRow obj in dgvReservantes.SelectedRows)
                {
                    idCliente = this.ObtenerIdReservanteGrilla(obj);
                    dgvReservantes.Rows.RemoveAt(obj.Index);
                }

                ClienteBusiness clienteBusiness = new ClienteBusiness();
                tbcliente cliente = (tbcliente)clienteBusiness.GetElement(new tbcliente() { cli_id = idCliente });
                cliente = (tbcliente)clienteBusiness.CargarNombreCompleto(cliente);
                cmbCliente.Items.Add(cliente);
            }
        }

        public void AgregaAutorizanteGrilla(tbcliente _reservante)
        {
            DataGridViewRow dataGridViewRow = new DataGridViewRow();
            int indice = dgvReservantes.Rows.Add();
            dataGridViewRow = dgvReservantes.Rows[indice];
            dataGridViewRow.Cells["cli_id"].Value = _reservante.cli_id;
            dataGridViewRow.Cells["tif_id"].Value = _reservante.tif_id;
            dataGridViewRow.Cells["cli_nombre_completo"].Value = _reservante.cli_nombre_completo;
            dataGridViewRow.Cells["cli_nombre"].Value = _reservante.cli_nombre;
            dataGridViewRow.Cells["cli_apellido"].Value = _reservante.cli_apellido;
            dataGridViewRow.Cells["cli_numero_documento"].Value = _reservante.cli_numero_documento;
            dataGridViewRow.Cells["cli_fecha_nacimiento"].Value = _reservante.cli_fecha_nacimiento.ToString("dd/MM/yyyy");
        }

        public int ObtenerIdReservanteGrilla(DataGridViewRow _dataGridViewRow)
        {
            return Convert.ToInt32(_dataGridViewRow.Cells["cli_id"].Value);
        }
        #endregion

        #region Carga de Combos TipoPropiedad, Piso, Depto, Direcciones y Clientes
        private void CargarCombos()
        {
            this.SetearDisplayValue();
            this.CargarTipoPropiedad();
            this.CargarPiso();
            this.CargarDepto();
            this.CargarDirecciones();
            this.CargarCliente();
        }

        private void SetearDisplayValue()
        {
            cmbTipoPropiedad.ValueMember = "tip_id";
            cmbTipoPropiedad.DisplayMember = "tip_descripcion";

            cmbPiso.ValueMember = ComboBoxItem.ValueMember;
            cmbPiso.DisplayMember = ComboBoxItem.DisplayMember;

            cmbDepto.ValueMember = ComboBoxItem.ValueMember;
            cmbDepto.DisplayMember = ComboBoxItem.DisplayMember;

            cmbDireccion.ValueMember = "pro_id";
            cmbDireccion.DisplayMember = "pro_direccion";

            cmbCliente.ValueMember = "cli_id";
            cmbCliente.DisplayMember = "cli_nombre_completo";
        }

        private void CargarTipoPropiedad()
        {
            TipoPropiedadBusiness tipoPropiedadBusiness = new TipoPropiedadBusiness();
            List<tbtipopropiedad> listaTipoPropiedades = (List<tbtipopropiedad>)tipoPropiedadBusiness.GetList();

            foreach (var obj in listaTipoPropiedades)
                cmbTipoPropiedad.Items.Add(obj);
        }

        private void CargarPiso()
        {
            ListasDeElementos listasDeElementos = new ListasDeElementos();
            this.CargarCombo(listasDeElementos.GetListaPiso(), cmbPiso);
        }

        private void CargarDepto()
        {
            ListasDeElementos listasDeElementos = new ListasDeElementos();
            this.CargarCombo(listasDeElementos.GetListaDepto(), cmbDepto);
        }

        private void CargarDirecciones()
        {
            PropiedadBusiness propiedadBusiness = new PropiedadBusiness();
            List<tbpropiedad> listaDirecciones = (List<tbpropiedad>)propiedadBusiness.GetListDirecciones();

            if (listaDirecciones.Count != 0)
                foreach (var obj in listaDirecciones)
                    cmbDireccion.Items.Add(obj);
        }

        private void CargarCliente()
        {
            ClienteBusiness clienteBusiness = new ClienteBusiness();
            List<tbcliente> listaNombresCompletos = (List<tbcliente>)clienteBusiness.GetListNombresCompletos();

            if (listaNombresCompletos.Count != 0)
                foreach (var obj in listaNombresCompletos)
                    cmbCliente.Items.Add(obj);
        }

        private void CargarCombo(List<ComboBoxItem> lista, ComboBox combo)
        {
            foreach (var obj in lista)
                combo.Items.Add(obj);
        }
        #endregion

        #region Cargo Controles con los Datos de la Operacion Almacenada
        private void CargoFormulario(tboperaciones _operacion)
        {
            dtpFecha.Enabled = false;
            dtpFecha.Value = _operacion.ope_fecha.Value;

            CargarComboDireccion(_operacion);
            CargarGrillaReservante(_operacion);
            txbOferta.Text = _operacion.tbreservaventa.rev_oferta.ToString();
            txbObservaciones.Text = this.operacion.tbreservaventa.rev_observaciones;
        }

        /// <summary>
        /// Carga el combo de direcciones, tener en cuenta que tambien carga los datos de la propiedad. 
        /// Ya que, al realizar la seleccion del item, se dispara el itemChange del combo y se 
        /// cargan automaticamente.
        /// </summary>
        private void CargarComboDireccion(tboperaciones _operacion)
        {
            cmbDireccion.Enabled = false;
            tbpropiedad propiedadSeleccionada = null;
            foreach (tbpropiedad obj in cmbDireccion.Items)
            {
                if (obj.pro_id == _operacion.pro_id)
                {
                    propiedadSeleccionada = obj;
                    break;
                }
            }
            cmbDireccion.SelectedItem = propiedadSeleccionada;
        }

        /// <summary>
        /// Agrega los reservantes a la grilla (los quita del combo y los agrega a la grilla
        /// </summary>
        /// <param name="_operacion">Objeto operacion del cual obtendra los reservantes.</param>
        private void CargarGrillaReservante(tboperaciones _operacion)
        {
            cmbCliente.Enabled = false;
            btnAgregar.Enabled = false;
            btnQuitar.Enabled = false;

            var idsReservantes = GetIdsReservante(_operacion);

            foreach (tbcliente obj in cmbCliente.Items)
            {
                if (idsReservantes.Contains(obj.cli_id))
                    this.AgregaAutorizanteGrilla(obj);
            }
        }

        private IEnumerable<tbclienteoperacion> GetClientesOperacion(tboperaciones _operacion)
        {
            var clientesOperacion = this.operacion.tbclienteoperacion
                .Where(x => x.ope_id == _operacion.ope_id);

            return clientesOperacion;
        }

        private List<int> GetIdsReservante(tboperaciones _operacion)
        {
            var idsReservantes = GetClientesOperacion(_operacion)
                                    .Where(x => x.stc_id == (int)TipoOperador.RESERALQUI)
                                    .Select(x => x.cli_id).ToList<int>();
            return idsReservantes;
        }

        #endregion

        #region Mensajes de Pantalla
        private void MensajeCancelar()
        {
            DialogResult dialogResult = DialogResult.None;

            dialogResult = MessageBox.Show("Se aplicaron cambios. Se perderán todos los datos que no hayan sido guardados. \n¿Desea cerrar la ventana?",
                "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                // Stop the validation of any controls so the form can close.
                AutoValidate = AutoValidate.Disable;
                this.Close();
            }
        }

        private void MensajeOk()
        {
            MessageBox.Show("El registro se guardo correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Validación de controles
        private void ValidatingControl(object sender, CancelEventArgs e)
        {
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            validarControles = new ValidarControles();
            Control control = validarControles.ObtenerControl(sender);
            string error = validarControles.ValidarControl(sender);

            if (!string.IsNullOrEmpty(error))
            {
                errorProvider1.SetError(control, error);

                //Me valida hasta ingresar el valor correcto
                e.Cancel = true;
                return;
            }

            errorProvider1.SetError(control, error);
        }
        #endregion

    }
}
