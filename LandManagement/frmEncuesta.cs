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
using LandManagement.Utilidades.UserControls;

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
        UserControlDatosPropiedad userControlDatosPropiedad = null;

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
                //Instancio user control con los datos de la propiedad
                userControlDatosPropiedad = new UserControlDatosPropiedad();
                userControlDatosPropiedad.Location = new Point(10, 50);
                pnlControles.Controls.Add(userControlDatosPropiedad);

                pnlControles.AutoScroll = true;
                this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
                this.CargarCombos();
                
                gbxCliente.Enabled = false;
                txbNombreEncuestado.Enabled = false;
                txbApellidoEncuestado.Enabled = false;

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
                    //((frmOperacionListado)formPadre).CargarGrillaOperaciones();
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
            _operacion.pro_id = userControlDatosPropiedad.GetPropiedadSeleccionada().pro_id;

            //Asigno id de usuario a la operacion
            _operacion.usu_id = Utilidades.VariablesDeSesion.UsuarioLogueado.usu_id;

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

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbcliente clienteSeleccionado = (tbcliente)cmbCliente.SelectedItem;
            txbNombreEncuestado.Text = clienteSeleccionado.cli_nombre;
            txbApellidoEncuestado.Text = clienteSeleccionado.cli_apellido;
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
            userControlDatosPropiedad.SeleccionarPropiedad(_operacion.pro_id);
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

        #region Carga de Combo clientes
        private void CargarCombos()
        {
            this.SetearDisplayValue();
            this.CargarComoClientes();
        }

        private void SetearDisplayValue()
        {
            cmbCliente.ValueMember = "cli_id";
            cmbCliente.DisplayMember = "cli_nombre_completo";
        }

        private void CargarComoClientes()
        {
            ClienteBusiness clienteBusiness = new ClienteBusiness();
            List<tbcliente> clientes = (List<tbcliente>)clienteBusiness.GetList();

            if (clientes.Count != 0)
                foreach (var obj in clientes)
                    cmbCliente.Items.Add(obj);
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
