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

namespace LandManagement
{
    public partial class frmEnVenta : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private TipoPropiedadBusiness tipoPropiedadBusiness;
        private tboperaciones operacion;
        private OperacionBusiness operacionBusiness;
        private int idOperacion = 0;
        private ClienteBusiness clienteBusiness;
        private ListasDeElementos listasDeElementos;
        private Form formPadre;
        DisplayNameHelper displayNameHelper;
        ValidarControles validarControles;
        private ErrorProvider errorProvider1 = new ErrorProvider();

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
                this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
                listasDeElementos = new ListasDeElementos();
                this.CargarCombos();
                gbxDetallePropiedad.Enabled = false;

                cmbDireccion.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbDireccion.AutoCompleteSource = AutoCompleteSource.ListItems;

                cmbCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;

                InicializarGrillaPropietarios();
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
                    //((frmClienteListado)formPadre).CargarGrilla();
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
            this.operacion.pro_id = ((tbpropiedad)cmbDireccion.SelectedItem).pro_id;

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

            if (dgvPropietarios.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvPropietarios.Rows)
                {
                    clienteOperacion = new tbclienteoperacion();
                    clienteOperacion.cli_id = (int)row.Cells["cli_id"].Value;
                    clienteOperacion.stc_id = (int)TipoOperador.PROPIETARI;

                    this.operacion.tbclienteoperacion.Add(clienteOperacion);
                }
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

        private void btnAgregar_Click(object sender, EventArgs e)
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

        #region Cargo controles de dirección seleccionada
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
            //txbCaracteristicas.Text = p.pro_caracteristica;

            CargoPropietariosALaGrilla(p);
        }

        private void CargoPropietariosALaGrilla(tbpropiedad p)
        {
            dgvPropietarios.Rows.Clear();
            dgvPropietarios.Refresh();

            // Controlar si this.operacion se esta cargando en otro lugar que no sea
            // el constructor de una operacion seleccionada en el listado.
            if (this.operacion != null)
            {
                var idsPropietarios = this.GetIdsPropietarios();
                foreach (tbcliente obj in cmbCliente.Items)
                    if (idsPropietarios.Contains(obj.cli_id))
                        AgregaPropietarioGrilla(obj);
            }
            else
                AgregarPropietariosGrilla(p);
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
            //this.SetearIndiceCombo();
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
            tipoPropiedadBusiness = new TipoPropiedadBusiness();
            List<tbtipopropiedad> listaTipoPropiedades = (List<tbtipopropiedad>)tipoPropiedadBusiness.GetList();

            foreach (var obj in listaTipoPropiedades)
                cmbTipoPropiedad.Items.Add(obj);
        }

        private void CargarPiso()
        {
            this.CargarCombo(listasDeElementos.GetListaPiso(), cmbPiso);
        }

        private void CargarDepto()
        {
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

        #region Carga Propietarios a la Grilla de Propietarios

        private void InicializarGrillaPropietarios()
        {
            dgvPropietarios.Rows.Clear();
            dgvPropietarios.Columns.Clear();
            string[] columnasGrilla = {
                                        "cli_id",
                                        "tif_id",
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
                dgvPropietarios.Columns.Add(s, columna);
                i++;
            }

            dgvPropietarios.Columns[0].Visible = false;
            dgvPropietarios.Columns[1].Visible = false;

        }

        private void AgregarPropietariosGrilla(tbpropiedad prop)
        {
            foreach (tbcliente obj in prop.tbcliente)
                AgregaPropietarioGrilla(obj);
        }

        public void AgregaPropietarioGrilla(tbcliente familiar)
        {
            int indice;
            DataGridViewRow dataGridViewRow = new DataGridViewRow();
            indice = dgvPropietarios.Rows.Add();
            dataGridViewRow = dgvPropietarios.Rows[indice];
            dataGridViewRow.Cells["cli_id"].Value = familiar.cli_id;
            dataGridViewRow.Cells["tif_id"].Value = familiar.tif_id;
            dataGridViewRow.Cells["cli_nombre"].Value = familiar.cli_nombre;
            dataGridViewRow.Cells["cli_apellido"].Value = familiar.cli_apellido;
            dataGridViewRow.Cells["cli_numero_documento"].Value = familiar.cli_numero_documento;
            dataGridViewRow.Cells["cli_fecha_nacimiento"].Value = familiar.cli_fecha_nacimiento;
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

            cliente.cli_nombre_completo = cliente.cli_nombre + ", " + cliente.cli_apellido;

            return cliente;
        }

        #endregion

        #region Cargo Controles con los Datos de la Operacion Almacenada
        private void CargoFormulario()
        {
            dtpFechaEnVenta.Enabled = false;

            dtpFechaEnVenta.Value = this.operacion.ope_fecha.Value;
            if (this.operacion.tbenventa.env_fecha_vencimiento < DateTime.Today)
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

            dtpFechaVencimiento.Value = this.operacion.tbenventa.env_fecha_vencimiento;
            txbPrecio.Text = this.operacion.tbenventa.env_precio.ToString();
            txbCartel.Text = this.operacion.tbenventa.env_cartel;
            txbObservaciones.Text = this.operacion.tbenventa.env_observaciones;
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

        private IEnumerable<int> GetIdsPropietarios()
        {
            var idsPropietarios = GetClientesOperacion()
                .Where(x => x.stc_id == (int)TipoOperador.PROPIETARI).Select(x => x.cli_id);
            return idsPropietarios;
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
            cmbDireccion.Enabled = false;
            tbpropiedad propiedadSeleccionada = null;
            foreach (tbpropiedad obj in cmbDireccion.Items)
            {
                if (obj.pro_id == this.operacion.pro_id)
                {
                    propiedadSeleccionada = obj;
                    break;
                }
            }
            cmbDireccion.SelectedItem = propiedadSeleccionada;
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

        private void ControlarInstanciaAbierta(Form formularioPopUp, string textFormulario)
        {
            Assembly frmAssembly = Assembly.LoadFile(Application.ExecutablePath);
            string frmCode = formularioPopUp.Name;
            string frmNombre = textFormulario;

            foreach (Type type in frmAssembly.GetTypes())
            {
                if (type.BaseType == typeof(Form))
                {
                    if (type.Name == frmCode)
                    {
                        if (Application.OpenForms.Cast<Form>().Any(form => form.Name == frmCode))
                        {
                            Form f = Application.OpenForms[frmCode];
                            f.WindowState = FormWindowState.Normal;
                            formularioPopUp.Text = frmNombre;
                            f.Activate();
                        }
                        else
                        {
                            formularioPopUp.ShowIcon = true;
                            formularioPopUp.Text = frmNombre;
                            formularioPopUp.Icon = (Icon)Recursos.ResourceImages.ResourceManager.GetObject("Tool");

                            formularioPopUp.MdiParent = this.MdiParent;
                            formularioPopUp.WindowState = FormWindowState.Minimized;
                            formularioPopUp.Show();
                            formularioPopUp.WindowState = FormWindowState.Maximized;
                            formularioPopUp.Show();

                            //ActivateMdiChild(null);
                            //ActivateMdiChild(formularioPopUp);
                        }

                    }

                }
            }

        }
        #endregion

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

    }
}
