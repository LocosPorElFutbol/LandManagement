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
using LandManagement.Utilidades.UserControls;

namespace LandManagement
{
    public partial class frmVenta : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private tboperaciones operacion;
        private Form formPadre;
        DisplayNameHelper displayNameHelper;
        ValidarControles validarControles;
        private ErrorProvider errorProvider1 = new ErrorProvider();
        UserControlPropietarios userControlPropietarios = null;
        UserControlDatosPropiedad userControlDatosPropiedad = null;

        public frmVenta()
        {
            InitializeComponent();
        }

        public frmVenta(tboperaciones _operacion, Form _formularioPadre)
        {
            InitializeComponent();

            this.operacion = _operacion;
            this.formPadre = _formularioPadre;

            btnGuardar.Click -= new EventHandler(btnGuardar_Click);
            btnGuardar.Click += new EventHandler(btnGuardarActualiza_Click);
        }

        private void frmVenta_Load(object sender, EventArgs e)
        {
            try
            {
                //User control propietarios
                userControlPropietarios = new UserControlPropietarios();
                userControlPropietarios.Location = new Point(3, 260);
                userControlPropietarios.TabIndex = 2;
                pnlControles.Controls.Add(userControlPropietarios);

                //User datos propiedad
                userControlDatosPropiedad = new UserControlDatosPropiedad();
                userControlDatosPropiedad.Location = new Point(3, 30);
                pnlControles.Controls.Add(userControlDatosPropiedad);

                pnlControles.AutoScroll = true;
                this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
                this.CargarCombos();
                InicializarGrillaCompradores();

                cmbCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;

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
                    operacion.tbventa = new tbventa();

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
            _operacion.pro_id =  userControlDatosPropiedad.GetPropiedadSeleccionada().pro_id;

            //Asigno id de usuario a la operacion
            _operacion.usu_id = Utilidades.VariablesDeSesion.UsuarioLogueado.usu_id;
            //this.operacion.usu_id = Utilidades.VariablesDeSesion.UsuarioLogueado.usu_id;

            CargoPropietariosALaOperacion(_operacion);
            CargaObjetoActualizable(_operacion);
        }

        private void CargoPropietariosALaOperacion(tboperaciones _operacion)
        {
            tbclienteoperacion clienteOperacion;
            _operacion.tbclienteoperacion.Clear();
            var listaPropietarios = userControlPropietarios.ObtenerPropietarios();

            foreach (var obj in listaPropietarios)
            {
                clienteOperacion = new tbclienteoperacion();
                clienteOperacion.cli_id = obj.cli_id;
                clienteOperacion.stc_id = (int)TipoOperador.PROPIETARI;

                _operacion.tbclienteoperacion.Add(clienteOperacion);
            }
        }

        private void CargaObjetoActualizable(tboperaciones _operacion)
        {
            CargoCompradoresALaOperacion(_operacion);
            CargoDatosOperacionVenta(_operacion);
        }

        private void CargoCompradoresALaOperacion(tboperaciones _operacion)
        {
            if (_operacion.ope_id != 0)
            {
                List<tbclienteoperacion> listaClienteOperacion =
                    (List<tbclienteoperacion>)_operacion.tbclienteoperacion.Where(x => x.stc_id == (int)TipoOperador.COMPRVENTA).ToList();

                listaClienteOperacion.ForEach(obj => _operacion.tbclienteoperacion.Remove(obj));
            }

            tbclienteoperacion clienteOperacion;

            if (dgvComprador.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvComprador.Rows)
                {
                    clienteOperacion = new tbclienteoperacion();
                    clienteOperacion.cli_id = (int)row.Cells["cli_id"].Value;
                    clienteOperacion.stc_id = (int)TipoOperador.COMPRVENTA;

                    _operacion.tbclienteoperacion.Add(clienteOperacion);
                }
            }
        }

        private void CargoDatosOperacionVenta(tboperaciones _operacion)
        {
            _operacion.tbventa.ven_fecha_boleto = dtpFechaBoleto.Value;
            _operacion.tbventa.ven_fecha_escritura = dtpFechaEscritura.Value;
            _operacion.tbventa.ven_precio = Convert.ToDouble(txbPrecio.Text);
            _operacion.tbventa.ven_escribano = txbEscribano.Text;
            _operacion.tbventa.ven_presupuesto = Convert.ToDouble(txbPresupuesto.Text);
            _operacion.tbventa.ven_escribania = txbEscribania.Text;
            _operacion.tbventa.ven_cobrado = Convert.ToDouble(txbCobrado.Text);
        }

        private void GuardaObjeto(tboperaciones _operacion)
        {
            OperacionBusiness operacionBusiness = new OperacionBusiness();
            if (_operacion.ope_id != 0)
                operacionBusiness.Update(_operacion, _operacion.tbventa, (int)TipoOperador.COMPRVENTA);
            else
                operacionBusiness.Create(_operacion);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                AgregaCompradorGrilla((tbcliente)cmbCliente.SelectedItem);
                cmbCliente.Items.Remove((tbcliente)cmbCliente.SelectedItem);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al agregar comprador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveComprador_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvComprador.Rows.Count > 0)
                {
                    AgregoClienteGrillaACombo();
                    foreach (DataGridViewRow obj in dgvComprador.SelectedRows)
                        dgvComprador.Rows.RemoveAt(obj.Index);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al eliminar comprador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.MensajeCancelar();
        }

        #region Carga/Elimina Compradores a la Grilla

        private void InicializarGrillaCompradores()
        {
            dgvComprador.Rows.Clear();
            dgvComprador.Columns.Clear();
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
            foreach (string s in columnasGrilla)
            {
                PropertyInfo pi = typeof(tbcliente).GetProperty(s);
                displayNameHelper = new DisplayNameHelper();
                string columna = displayNameHelper.GetMetaDisplayName(pi);
                dgvComprador.Columns.Add(s, columna);
                i++;
            }

            dgvComprador.Columns[0].Visible = false;
            dgvComprador.Columns[1].Visible = false;
            dgvComprador.Columns[2].Visible = false;

        }

        public void AgregaCompradorGrilla(tbcliente _comprador)
        {
            DataGridViewRow dataGridViewRow = new DataGridViewRow();
            int indice = dgvComprador.Rows.Add();
            dataGridViewRow = dgvComprador.Rows[indice];
            dataGridViewRow.Cells["cli_id"].Value = _comprador.cli_id;
            dataGridViewRow.Cells["tif_id"].Value = _comprador.tif_id;
            dataGridViewRow.Cells["cli_nombre_completo"].Value = _comprador.cli_nombre_completo;
            dataGridViewRow.Cells["cli_nombre"].Value = _comprador.cli_nombre;
            dataGridViewRow.Cells["cli_apellido"].Value = _comprador.cli_apellido;
            dataGridViewRow.Cells["cli_numero_documento"].Value = _comprador.cli_numero_documento;
            dataGridViewRow.Cells["cli_fecha_nacimiento"].Value = _comprador.cli_fecha_nacimiento.ToString("dd/MM/yyyy");
        }

        private void AgregoClienteGrillaACombo()
        {
            List<tbcliente> listaTemporal = new List<tbcliente>();
            foreach (tbcliente obj in cmbCliente.Items)
                listaTemporal.Add(obj);

            tbcliente cliente = ObtenerClienteSeleccionado();

            listaTemporal.Add(cliente);

            cmbCliente.Items.Clear();
            cmbCliente.Refresh();

            foreach (tbcliente cli in listaTemporal.OrderBy(x => x.cli_nombre))
                cmbCliente.Items.Add(cli);
        }

        private tbcliente ObtenerClienteSeleccionado()
        {
            DataGridViewRow dataGridViewRow = dgvComprador.SelectedRows[0];
            int idClienteSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["cli_id"].Value);

            ClienteBusiness clienteBusiness = new ClienteBusiness();
            tbcliente cliente = (tbcliente)clienteBusiness.GetElement(
                new tbcliente() { cli_id = idClienteSeleccionado });

            return cliente;
        }

        #endregion

        #region Carga de Combo Compradores
        private void CargarCombos()
        {
            this.SetearDisplayValue();
            this.CargarCliente();
        }

        private void SetearDisplayValue()
        {
            cmbCliente.ValueMember = "cli_id";
            cmbCliente.DisplayMember = "cli_nombre_completo";
        }

        private void CargarCliente()
        {
            ClienteBusiness clienteBusiness = new ClienteBusiness();
            List<tbcliente> listaNombresCompletos = (List<tbcliente>)clienteBusiness.GetList();

            if (listaNombresCompletos.Count != 0)
                foreach (var obj in listaNombresCompletos)
                    cmbCliente.Items.Add(obj);
        }

        #endregion

        #region Cargo Controles con los Datos de la Operacion Almacenada
        private void CargoFormulario(tboperaciones _operacion)
        {
            userControlPropietarios.Enabled = false;
            dtpFecha.Enabled = false;
            dtpFecha.Value = _operacion.ope_fecha.Value;

            CargarComboDireccion(_operacion);
            CargoGrillaComprador(_operacion);
            CargoGrillaPropietarios(_operacion);

            dtpFechaBoleto.Value = _operacion.tbventa.ven_fecha_boleto;
            dtpFechaEscritura.Value = _operacion.tbventa.ven_fecha_escritura;
            txbPrecio.Text = _operacion.tbventa.ven_precio.ToString();
            txbEscribano.Text = _operacion.tbventa.ven_escribano;
            txbPresupuesto.Text = _operacion.tbventa.ven_presupuesto.ToString();
            txbEscribania.Text = _operacion.tbventa.ven_escribania;
            txbCobrado.Text = _operacion.tbventa.ven_cobrado.ToString();
        }

        /// <summary>
        /// Carga la grilla de autorizantes. Tener en cuenta que se trabaja en memoria. Es decir, los datos de los
        /// autorizantes (clientes), se traen del combo de clientes donde se encuentran todos los de la base.
        /// </summary>
        private void CargoGrillaComprador(tboperaciones _operacion)
        {
            var idsCompradores = GetIdsCompradores(_operacion);
            List<tbcliente> listaCompradoresARemover = new List<tbcliente>();

            foreach (tbcliente obj in cmbCliente.Items)
            {
                if (idsCompradores.Contains(obj.cli_id))
                {
                    AgregaCompradorGrilla(obj);
                    listaCompradoresARemover.Add(obj);
                }
            }

            foreach (var obj in listaCompradoresARemover)
                cmbCliente.Items.Remove(obj);
        }

        private void CargoGrillaPropietarios(tboperaciones _operacion)
        {
            userControlPropietarios.CargarGrillaPropietariosOperacion(_operacion.ope_id);
        }

        private IEnumerable<int> GetIdsCompradores(tboperaciones _operacion)
        {
            var idsCompradores = GetClientesOperacion(_operacion)
                .Where(x => x.stc_id == (int)TipoOperador.COMPRVENTA).Select(x => x.cli_id);
            return idsCompradores;
        }

        private IEnumerable<tbclienteoperacion> GetClientesOperacion(tboperaciones _operacion)
        {
            var clientesOperacion = this.operacion.tbclienteoperacion
                .Where(x => x.ope_id == this.operacion.ope_id);

            return clientesOperacion;
        }

        private void CargarComboDireccion(tboperaciones _operacion)
        {
            userControlDatosPropiedad.SeleccionarPropiedad(_operacion.pro_id);
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
