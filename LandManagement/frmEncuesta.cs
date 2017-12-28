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
using System.Text;
using System.Windows.Forms;

namespace LandManagement
{
    public partial class frmEncuesta : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private tboperaciones operacion;
        private Form formPadre;
        ValidarControles validarControles;
        private ErrorProvider errorProvider1 = new ErrorProvider();

        public frmEncuesta()
        {
            InitializeComponent();
        }

        public frmEncuesta(tboperaciones _operacion, Form _formularioPadre)
        {
            InitializeComponent();

            this.operacion = _operacion;
            this.formPadre = _formularioPadre;

            btnGuardar.Click -= new EventHandler(btnGuardar_Click);
            btnGuardar.Click += new EventHandler(btnGuardarActualiza_Click);
        }

        private void frmEncuesta_Load(object sender, EventArgs e)
        {
            try
            {
                pnlControles.AutoScroll = true;
                this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
                this.CargarCombos();
                
                gbxDetallePropiedad.Enabled = false;
                gbxCliente.Enabled = false;
                txbNombreEncuestado.Enabled = false;
                txbApellidoEncuestado.Enabled = false;

                cmbDireccion.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbDireccion.AutoCompleteSource = AutoCompleteSource.ListItems;

                cmbCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;

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
                    operacion.tbencuesta = new tbencuesta();

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

        /// <summary>
        /// Solo se carga completo cuando es un Create, si es un update, se invoca directamente a guardar
        /// objeto actualizable.
        /// </summary>
        /// <param name="_operacion">La operación existente ya almacenada en base de datos.</param>
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

            CargoEncuestadoALaOperacion(_operacion);
            CargaObjetoActualizable(_operacion);
        }

        private void CargoEncuestadoALaOperacion(tboperaciones _operacion)
        {
            _operacion.tbclienteoperacion.Clear();

            tbclienteoperacion clienteOperacion = new tbclienteoperacion();
            clienteOperacion.cli_id = ((tbcliente)cmbCliente.SelectedItem).cli_id;
            clienteOperacion.stc_id = (int)TipoOperador.ENCUESTADO;

            _operacion.tbclienteoperacion.Add(clienteOperacion);
        }

        private void CargaObjetoActualizable(tboperaciones _operacion)
        {
            CargoDatosOperacionEncuesta(_operacion);
        }

        private void CargoDatosOperacionEncuesta(tboperaciones _operacion)
        {
            _operacion.tbencuesta.enc_observaciones = txbObservaciones.Text;
        }

        private void GuardaObjeto(tboperaciones _operacion)
        {
            OperacionBusiness operacionBusiness = new OperacionBusiness();
            if (this.getOperacionExistente() != null)
                operacionBusiness.Update(_operacion, _operacion.tbencuesta);
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
            CargarComboEncuestado(_operacion);

            //Cargo datos del objeto actualizable
            txbObservaciones.Text = _operacion.tbencuesta.enc_observaciones;
        }

        /// <summary>
        /// Carga el combo de direcciones, tener en cuenta que tambien carga los datos de la propiedad. 
        /// Ya que, al realizar la seleccion del item, se dispara el itemChange del combo y se 
        /// cargan automaticamente los propietarios correspondientes a esa operación.
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
        /// Carga el combo del Encuestado, tener en cuenta que tambien carga los datos del Encuestado por el
        /// evento index change del combo de encuestado.
        /// </summary>
        private void CargarComboEncuestado(tboperaciones _operacion)
        {
            cmbCliente.Enabled = false;
            var idEncuestado = GetIdsOperador(_operacion, (int)TipoOperador.ENCUESTADO).FirstOrDefault();
            tbcliente clienteSeleccionado = new tbcliente();

            foreach (tbcliente obj in cmbCliente.Items)
            {
                if (obj.cli_id == idEncuestado)
                {
                    clienteSeleccionado = obj;
                    break;
                }
            }

            cmbCliente.SelectedItem = clienteSeleccionado;
        }

        private IEnumerable<int> GetIdsOperador(tboperaciones _operacion, int _codigoOperador)
        {
            var idsOperadores = GetClientesOperacion(_operacion)
                .Where(x => x.stc_id == _codigoOperador).Select(x => x.cli_id);
            return idsOperadores;
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

        #region Cargo controles de Dirección y Propietarios de esa direccion
        private void cmbDireccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbpropiedad propiedad = (tbpropiedad)cmbDireccion.SelectedItem;
            CargarControlesPropiedad(propiedad);

            cmbCliente.Text = string.Empty;
            txbNombreEncuestado.Text = string.Empty;
            txbApellidoEncuestado.Text = string.Empty;

            cmbCliente.Items.Clear();
            this.CargarComoClientes();
        }

        private void CargarControlesPropiedad(tbpropiedad _propiedad)
        {
            cmbTipoPropiedad.Text = _propiedad.tbtipopropiedad.tip_descripcion;
            txbCalle.Text = _propiedad.pro_calle;
            txbNumero.Text = _propiedad.pro_numero.ToString();
            if (_propiedad.pro_piso == 0)
                cmbPiso.Text = "PB";
            else
                cmbPiso.Text = _propiedad.pro_piso.ToString();
            cmbDepto.Text = _propiedad.pro_departamento;
            txbLocalidad.Text = _propiedad.pro_localidad;
            txbCodigoPostal.Text = _propiedad.pro_codigo_postal;
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarControlesCliente(
                (tbcliente)cmbCliente.SelectedItem, txbNombreEncuestado, txbApellidoEncuestado);
        }

        private void CargarControlesCliente(tbcliente c, TextBox _txbNom, TextBox _txbApe)
        {
            _txbNom.Text = c.cli_nombre;
            _txbApe.Text = c.cli_apellido;
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

        #region Carga de Combos TipoPropiedad, Piso, Depto, Direcciones, Clientes
        private void CargarCombos()
        {
            this.SetearDisplayValue();
            this.CargarTipoPropiedad();
            this.CargarPiso();
            this.CargarDepto();
            this.CargarDirecciones();
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

        private void CargarComoClientes()
        {
            ClienteBusiness clienteBusiness = new ClienteBusiness();
            List<tbcliente> clientes =
                (List<tbcliente>)clienteBusiness.GetList();

            if (clientes.Count != 0)
                foreach (var obj in clientes)
                    cmbCliente.Items.Add(clienteBusiness.CargarNombreCompleto(obj));
        }

        private void CargarCombo(List<ComboBoxItem> lista, ComboBox combo)
        {
            foreach (var obj in lista)
                combo.Items.Add(obj);
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
