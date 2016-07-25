using LandManagement.Business;
using LandManagement.Entities;
using LandManagement.Utilidades;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace LandManagement
{
    public partial class frmReservaAlquiler : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private tboperaciones operacion;
        private Form formPadre;
        ValidarControles validarControles;
        private ErrorProvider errorProvider1 = new ErrorProvider();

        public frmReservaAlquiler()
        {
            InitializeComponent();
        }

        public frmReservaAlquiler(tboperaciones _operacion, Form _formularioPadre)
        {
            InitializeComponent();

            this.operacion = _operacion;
            this.formPadre = _formularioPadre;

            btnGuardar.Click -= new EventHandler(btnGuardar_Click);
            btnGuardar.Click += new EventHandler(btnGuardarActualiza_Click);
        }

        private void frmReservaAlquiler_Load(object sender, EventArgs e)
        {
            try
            {
                pnlControles.AutoScroll = true;
                cmbCliente.Sorted = true;
                this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
                this.CargarCombos();
                gbxDetallePropiedad.Enabled = false;
                txbNombreReservante.Enabled = false;
                txbApellidoReservante.Enabled = false;

                cmbDireccion.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbDireccion.AutoCompleteSource = AutoCompleteSource.ListItems;

                cmbCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;

                InicializarGrillaReservantes();

                if (this.getOperacionExistente() != null)
                {
                    tboperaciones operacionLocal = new tboperaciones();
                    operacionLocal = this.getOperacionExistente();
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
                    operacion.tbreservaalquiler = new tbreservaalquiler();

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
                    operacionLocal = this.getOperacionExistente();
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

        private void CargoPropietariosALaOperacion(tboperaciones _operacion)
        {
            tbclienteoperacion clienteOperacion;
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

                    _operacion.tbclienteoperacion.Add(clienteOperacion);
                }
            }
        }

        public void CargoReservanteALaOperacion(tboperaciones _operacion)
        {
            tbclienteoperacion clienteOperacion;

            //Carga de reservante viejo
            //if (!string.IsNullOrEmpty(txbNombreReservante.Text))
            //{
            //    clienteOperacion = new tbclienteoperacion();
            //    clienteOperacion.cli_id = ((tbcliente)cmbCliente.SelectedItem).cli_id;
            //    clienteOperacion.stc_id = (int)TipoOperador.RESERALQUI;

            //    _operacion.tbclienteoperacion.Add(clienteOperacion);
            //}

            //Carga de reservante nueva
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

        private void CargaObjetoActualizable(tboperaciones _operacion)
        {
            CargoDatosOperacionReservaAlquiler(_operacion);
        }

        private void CargoDatosOperacionReservaAlquiler(tboperaciones _operacion)
        {
            _operacion.tbreservaalquiler.rea_oferta = ValidarDecimalNulo(txbOferta.Text);
            _operacion.tbreservaalquiler.rea_garantia = txbGarantia.Text;
        }

        private void GuardaObjeto(tboperaciones _operacion)
        {
            OperacionBusiness operacionBusiness = new OperacionBusiness();
            if (this.getOperacionExistente() != null)
                operacionBusiness.Update(_operacion, _operacion.tbreservaalquiler);
            else
                operacionBusiness.Create(_operacion);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.MensajeCancelar();
        }

        #region Cargo Controles con los Datos de la Operacion Almacenada
        private void CargoFormulario(tboperaciones _operacion)
        {
            dtpFecha.Enabled = false;
            dtpFecha.Value = _operacion.ope_fecha.Value;

            CargarComboDireccion(_operacion);
            CargarComboReservante(_operacion);

            txbOferta.Text = _operacion.tbreservaalquiler.rea_oferta.ToString();
            txbGarantia.Text = _operacion.tbreservaalquiler.rea_garantia;
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
        /// Carga el combo del cliente reservante, tener en cuenta que tambien carga los datos del cliente.
        /// </summary>
        private void CargarComboReservante(tboperaciones _operacion)
        {
            cmbCliente.Enabled = false;
            var idAutorizantes = GetIdReservante(_operacion);
            tbcliente clienteSeleccionado = new tbcliente();

            foreach (tbcliente obj in cmbCliente.Items)
            {
                if (obj.cli_id == idAutorizantes)
                {
                    clienteSeleccionado = obj;
                    break;
                }
            }

            cmbCliente.SelectedItem = clienteSeleccionado;
        }

        private int GetIdReservante(tboperaciones _operacion)
        {
            var idReservante = GetClientesOperacion(_operacion)
                .Where(x => x.stc_id == (int)TipoOperador.RESERALQUI)
                .Select(x => x.cli_id).FirstOrDefault();
            return idReservante;
        }

        private IEnumerable<tbclienteoperacion> GetClientesOperacion(tboperaciones _operacion)
        {
            var clientesOperacion = this.operacion.tbclienteoperacion
                .Where(x => x.ope_id == _operacion.ope_id);

            return clientesOperacion;
        }

        /// <summary>
        /// Obtiene la operación existente. Solo contiene datos cuando se selecciona la operación desde
        /// el listado de operaciones. Cuando se crea una nueva operación devuelve null
        /// </summary>
        /// <returns>Operación existente y almacenada en BD.</returns>
        private tboperaciones getOperacionExistente()
        {
            if (this.operacion != null)
                return this.operacion;
            return null;
        }
       
        #endregion

        #region Cargo controles de Dirección y Cliente seleccionado
        private void cmbDireccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarControlesPropiedad((tbpropiedad)cmbDireccion.SelectedItem);
        }

        private void CargarControlesPropiedad(tbpropiedad _propiedad)
        {
            cmbTipoPropiedad.Text = _propiedad.tbtipopropiedad.tip_descripcion;
            txbCalle.Text = _propiedad.pro_calle;
            txbNumero.Text = _propiedad.pro_numero.ToString();
            cmbPiso.Text = _propiedad.pro_piso.ToString();
            cmbDepto.Text = _propiedad.pro_departamento;
            txbLocalidad.Text = _propiedad.pro_localidad;
            txbCodigoPostal.Text = _propiedad.pro_codigo_postal;
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarControlesCliente((tbcliente)cmbCliente.SelectedItem);
        }

        private void CargarControlesCliente(tbcliente c)
        {
            txbNombreReservante.Text = c.cli_nombre;
            txbApellidoReservante.Text = c.cli_apellido;
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

        //private tbcliente ObtenerReservanteSeleccionado()
        //{
        //    int idClienteSeleccionado = this.ObtenerIdReservanteGrilla(dgvReservantes.SelectedRows[0]);

        //    ClienteBusiness clienteBusiness = new ClienteBusiness();
        //    tbcliente cliente = (tbcliente)clienteBusiness.GetElement(
        //        new tbcliente() { cli_id = idClienteSeleccionado });

        //    cliente.cli_nombre_completo = cliente.cli_nombre + ", " + cliente.cli_apellido;

        //    return cliente;
        //}
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

        private void ValidarDecimales(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                   (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private double ValidarDecimalNulo(string _valorTextbox)
        {
            return string.IsNullOrEmpty(_valorTextbox) ? 0 : Convert.ToDouble(_valorTextbox);
        }
        #endregion

    }
}
