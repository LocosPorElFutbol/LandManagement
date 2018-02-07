using LandManagement.Business;
using LandManagement.Entities;
using LandManagement.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using log4net;
using LandManagement.Utilidades.UserControls;

namespace LandManagement
{
    public partial class frmEnVenta : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private tboperaciones operacion;
        private OperacionBusiness operacionBusiness;
        private int idOperacion = 0;
        private ClienteBusiness clienteBusiness;
        private ListasDeElementos listasDeElementos;
        private Form formPadre;
        DisplayNameHelper displayNameHelper;
        ValidarControles validarControles;
        private ErrorProvider errorProvider1 = new ErrorProvider();
        UserControlPropietarios userControlPropietarios = null;
        UserControlDatosPropiedad userControlDatosPropiedad = null;

        public frmEnVenta()
        {
            InitializeComponent();
            this.operacionBusiness = new OperacionBusiness();
            this.clienteBusiness = new ClienteBusiness();
            //this.formPadre = formularioPadre;
        }

        public frmEnVenta(tboperaciones _operacion, Form _formularioPadre)
        {
            InitializeComponent();
            this.operacionBusiness = new OperacionBusiness();
            this.clienteBusiness = new ClienteBusiness();
            this.operacion = _operacion;
            this.formPadre = _formularioPadre;
            this.idOperacion = _operacion.ope_id;

            btnGuardar.Click -= new EventHandler(btnGuardar_Click);
            btnGuardar.Click += new EventHandler(btnGuardarActualiza_Click);

        }

        private void frmEnVenta_Load(object sender, EventArgs e)
        {
            try
            {
                //User control propietarios
                userControlPropietarios = new UserControlPropietarios();
                userControlPropietarios.Location = new Point(15, 378);
                pnlControles.Controls.Add(userControlPropietarios);

                //User control datos propiedad
                userControlDatosPropiedad = new UserControlDatosPropiedad();
                userControlDatosPropiedad.Location = new Point(15, 39);
                pnlControles.Controls.Add(userControlDatosPropiedad);

                pnlControles.AutoScroll = true;
                this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
                listasDeElementos = new ListasDeElementos();
                this.CargarCombos();

                cmbCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;

                InicializarGrillaAutorizantes();

                if (this.operacion != null)
                    CargoFormulario();
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

                    this.operacion = new tboperaciones();
                    this.operacion.tbenventa = new tbenventa();

                    CargaObjeto();
                    GuardaObjeto();
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

                    CargaObjeto();
                    GuardaObjeto();

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

        private void GuardaObjeto()
        {
            if (this.idOperacion != 0)
                operacionBusiness.Update(this.operacion, this.operacion.tbenventa);
            else
                operacionBusiness.Create(this.operacion);
        }

        private void CargaObjeto()
        {
            //Asigno fecha de la operacion
            this.operacion.ope_fecha = dtpFechaEnVenta.Value;

            //Asigno id de la propiedad a la operacion
            //this.operacion.pro_id = ((tbpropiedad)cmbDireccion.SelectedItem).pro_id;
            this.operacion.pro_id = userControlDatosPropiedad.GetPropiedadSeleccionada().pro_id;

            //Asigno id de usuario a la operacion
            this.operacion.usu_id = Utilidades.VariablesDeSesion.UsuarioLogueado.usu_id;

            CargoDatosOperacionEnVenta();
            CargoPropietariosALaOperacion();
            CargoAutorizantesALaOperacion();
        }

        private void CargoDatosOperacionEnVenta()
        {
            //Cargo datos de la operacion En Venta
            this.operacion.tbenventa.env_titulo_propiedad = cbxTituloPropiedad.Checked;
            this.operacion.tbenventa.env_planos = cbxPlanos.Checked;
            this.operacion.tbenventa.env_reglamento = cbxReglamento.Checked;
            this.operacion.tbenventa.env_matricula = cbxMatricula.Checked;
            this.operacion.tbenventa.env_abl = cbxAbl.Checked;
            this.operacion.tbenventa.env_agua = cbxAgua.Checked;
            this.operacion.tbenventa.env_luz = cbxLuz.Checked;
            this.operacion.tbenventa.env_gas = cbxGas.Checked;
            this.operacion.tbenventa.env_telefono = cbxTelefono.Checked;
            this.operacion.tbenventa.env_fecha_vencimiento = dtpFechaVencimiento.Value;
            this.operacion.tbenventa.env_precio = Convert.ToDouble(txbPrecio.Text);
            this.operacion.tbenventa.env_cartel = txbCartel.Text;
            this.operacion.tbenventa.env_observaciones = txbObservaciones.Text;
        }

        private void CargoPropietariosALaOperacion()
        {
            tbclienteoperacion clienteOperacion;
            this.operacion.tbclienteoperacion.Clear();

            var listaClientes = userControlPropietarios.ObtenerPropietarios();

            foreach (var obj in listaClientes)
            {
                clienteOperacion = new tbclienteoperacion();
                clienteOperacion.cli_id = obj.cli_id;
                clienteOperacion.stc_id = (int)TipoOperador.PROPIETARI;

                this.operacion.tbclienteoperacion.Add(clienteOperacion);
            }
        }

        private void CargoAutorizantesALaOperacion()
        {
            tbclienteoperacion clienteOperacion;
            //this.operacion.tbclienteoperacion.Clear();

            if (dgvAutorizantes.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvAutorizantes.Rows)
                {
                    clienteOperacion = new tbclienteoperacion();
                    clienteOperacion.cli_id = (int)row.Cells["cli_id"].Value;
                    clienteOperacion.stc_id = (int)TipoOperador.AUTORIZANT;

                    this.operacion.tbclienteoperacion.Add(clienteOperacion);
                }
            }
        }

        private void btnAgregarAutorizante_Click(object sender, EventArgs e)
        {
            try
            {
                AgregaAutorizanteGrilla((tbcliente)cmbCliente.SelectedItem);
                cmbCliente.Items.Remove((tbcliente)cmbCliente.SelectedItem);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al agregar autorizante.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveAutorizante_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAutorizantes.Rows.Count > 0)
                {
                    AgregoClienteGrillaACombo();
                    foreach (DataGridViewRow obj in dgvAutorizantes.SelectedRows)
                        dgvAutorizantes.Rows.RemoveAt(obj.Index);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al eliminar autorizante.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MensajeCancelar();
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

        #region Carga de Combo Clientes

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

        #region Carga Autorizantes a la Grilla

        private void InicializarGrillaAutorizantes()
        {
            dgvAutorizantes.Rows.Clear();
            dgvAutorizantes.Columns.Clear();
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
                dgvAutorizantes.Columns.Add(s, columna);
                i++;
            }

            dgvAutorizantes.Columns[0].Visible = false;
            dgvAutorizantes.Columns[1].Visible = false;
            dgvAutorizantes.Columns[2].Visible = false;

        }

        public void AgregaAutorizanteGrilla(tbcliente Autorizante)
        {
            DataGridViewRow dataGridViewRow = new DataGridViewRow();
            int indice = dgvAutorizantes.Rows.Add();
            dataGridViewRow = dgvAutorizantes.Rows[indice];
            dataGridViewRow.Cells["cli_id"].Value = Autorizante.cli_id;
            dataGridViewRow.Cells["tif_id"].Value = Autorizante.tif_id;
            dataGridViewRow.Cells["cli_nombre_completo"].Value = Autorizante.cli_nombre_completo;
            dataGridViewRow.Cells["cli_nombre"].Value = Autorizante.cli_nombre;
            dataGridViewRow.Cells["cli_apellido"].Value = Autorizante.cli_apellido;
            dataGridViewRow.Cells["cli_numero_documento"].Value = Autorizante.cli_numero_documento;
            dataGridViewRow.Cells["cli_fecha_nacimiento"].Value = Autorizante.cli_fecha_nacimiento.ToString("dd/MM/yyyy");
        }

        private tbcliente ObtenerClienteSeleccionado()
        {
            DataGridViewRow dataGridViewRow = dgvAutorizantes.SelectedRows[0];
            int idClienteSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["cli_id"].Value);

            tbcliente cliente = (tbcliente)this.clienteBusiness.GetElement(
                new tbcliente() { cli_id = idClienteSeleccionado });

            return cliente;
        }

        #endregion

        #region Cargo Controles con los Datos de la Operacion Almacenada
        private void CargoFormulario()
        {
            dtpFechaEnVenta.Enabled = false;

            dtpFechaEnVenta.Value = this.operacion.ope_fecha.Value;
            if (DateTime.Today <= this.operacion.tbenventa.env_fecha_vencimiento.Date)
                rdbVigenteSi.Checked = true;
            else
                rdbVigenteNo.Checked = true;

            CargarComboDireccion();
            cbxTituloPropiedad.Checked = this.operacion.tbenventa.env_titulo_propiedad;
            cbxPlanos.Checked = this.operacion.tbenventa.env_planos;
            cbxReglamento.Checked = this.operacion.tbenventa.env_reglamento;
            cbxMatricula.Checked = this.operacion.tbenventa.env_matricula;
            cbxAbl.Checked = this.operacion.tbenventa.env_abl;
            cbxAgua.Checked = this.operacion.tbenventa.env_agua;
            cbxLuz.Checked = this.operacion.tbenventa.env_luz;
            cbxGas.Checked = this.operacion.tbenventa.env_gas;
            cbxTelefono.Checked = this.operacion.tbenventa.env_telefono;
            
            //cargar grilla autorizantes
            CargoGrillaAutorizantes();
            CargarGrillaPropietarios(this.operacion);

            dtpFechaVencimiento.Value = this.operacion.tbenventa.env_fecha_vencimiento;
            txbPrecio.Text = this.operacion.tbenventa.env_precio.ToString();
            txbCartel.Text = this.operacion.tbenventa.env_cartel;
            txbObservaciones.Text = this.operacion.tbenventa.env_observaciones;
        }

        private void CargarGrillaPropietarios(tboperaciones _operacion)
        {
            //Cargo user control propietarios
            userControlPropietarios.Enabled = false;
            userControlPropietarios.CargarGrillaPropietariosOperacion(_operacion.ope_id);
        }

        /// <summary>
        /// Carga la grilla de autorizantes. Tener en cuenta que se trabaja en memoria. Es decir, los datos de los
        /// autorizantes (clientes), se traen del combo de clientes donde se encuentran todos los de la base.
        /// </summary>
        private void CargoGrillaAutorizantes()
        {
            var idsAutorizantes = GetIdsAutorizantes();
            List<tbcliente> listaAutorizantesARemover = new List<tbcliente>();

            foreach (tbcliente obj in cmbCliente.Items)
            {
                if (idsAutorizantes.Contains(obj.cli_id))
                {
                    AgregaAutorizanteGrilla(obj);
                    listaAutorizantesARemover.Add(obj);
                }
            }

            foreach (var obj in listaAutorizantesARemover)
                cmbCliente.Items.Remove(obj);
        }

        private IEnumerable<tbclienteoperacion> GetClientesOperacion()
        {
            var clientesOperacion = this.operacion.tbclienteoperacion
                .Where(x => x.ope_id == this.operacion.ope_id);

            return clientesOperacion;
        }

        private IEnumerable<int> GetIdsAutorizantes()
        {
            var idsAutorizantes = GetClientesOperacion()
                .Where(x => x.stc_id == (int)TipoOperador.AUTORIZANT).Select(x => x.cli_id);
            return idsAutorizantes;
        }

        /// <summary>
        /// Carga el combo de direcciones, tener en cuenta que tambien carga los propietarios. Ya que, al realizar la seleccion
        /// del item, se dispara el itemChange del combo y se cargan automaticamente.
        /// </summary>
        private void CargarComboDireccion()
        {
            userControlDatosPropiedad.SeleccionarPropiedad(this.operacion.pro_id);
        }
        #endregion

        #region Mensajes de Pantalla
        private void MensajeOk()
        {
            MessageBox.Show("El registro se guardo correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

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

        #endregion

        #region Validacion de controles
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

        private void ValidarDecimal(object sender, KeyPressEventArgs e)
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
        #endregion

    }
}
