using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using LandManagement.Entities;
using LandManagement.Business;
using LandManagement.Utilidades;
using LandManagement.Utilidades.UserControls;

namespace LandManagement
{
    public partial class frmTasacion : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private tboperaciones operacion;
        private OperacionBusiness operacionBusiness;
        private int idOperacion = 0;
        private ListasDeElementos listasDeElementos;
        private Form formPadre;
        ValidarControles validarControles;
        private ErrorProvider errorProvider1 = new ErrorProvider();
        private UserControlDatosPropiedad userControlDatosPropiedad = null;

        public frmTasacion()
        {
            InitializeComponent();
            this.operacionBusiness = new OperacionBusiness();
            this.groupBox5.Enabled = false;
        }

        public frmTasacion(tboperaciones _operacion, Form _formularioPadre)
        {
            InitializeComponent();
            this.operacionBusiness = new OperacionBusiness();
            this.operacion = _operacion;
            this.formPadre = _formularioPadre;
            this.idOperacion = _operacion.ope_id;

            btnGuardar.Click -= new EventHandler(btnGuardar_Click);
            btnGuardar.Click += new EventHandler(btnGuardarActualiza_Click);
        }

        private void frmTasacion_Load(object sender, EventArgs e)
        {
            //Cargo user control datos propiedad
            userControlDatosPropiedad = new UserControlDatosPropiedad();
            userControlDatosPropiedad.Location = new Point(3, 36);
            pnlControles.Controls.Add(userControlDatosPropiedad);

            pnlControles.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            listasDeElementos = new ListasDeElementos();
            this.CargarCombos();

            cmbCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (this.operacion != null)
                CargoFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateChildren())
                {
                    Cursor.Current = Cursors.WaitCursor;

                    this.operacion = new tboperaciones();
                    this.operacion.tbtasacion = new tbtasacion();

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

                    CargaObjetoActualizable();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MensajeCancelar();
        }

        private void CargaObjeto()
        {
            //Asigno fecha de la operacion
            this.operacion.ope_fecha = dtpFecha.Value;

            //Asigno id de la propiedad a la operacion
            this.operacion.pro_id = userControlDatosPropiedad.GetPropiedadSeleccionada().pro_id;

            //Asigno id de usuario a la operacion
            this.operacion.usu_id = Utilidades.VariablesDeSesion.UsuarioLogueado.usu_id;

            CargoClienteALaOperacion();
            CargaObjetoActualizable();
        }

        private void CargaObjetoActualizable()
        {
            CargoDatosOperacionTasacion();
        }

        private void CargoDatosOperacionTasacion()
        {
            this.operacion.tbtasacion.tas_tasacion = Convert.ToDouble(txbTasacion.Text);
            this.operacion.tbtasacion.tas_observaciones = txbObservaciones.Text;
        }

        private void CargoClienteALaOperacion()
        {
            tbclienteoperacion clienteOperacion;
            this.operacion.tbclienteoperacion.Clear();

            tbcliente cliente = cmbCliente.SelectedItem as tbcliente;

            clienteOperacion = new tbclienteoperacion();
            clienteOperacion.cli_id = cliente.cli_id;
            clienteOperacion.stc_id = (int)TipoOperador.TASADO;

            this.operacion.tbclienteoperacion.Add(clienteOperacion);
        }

        private void GuardaObjeto()
        {
            if (this.idOperacion != 0)
                operacionBusiness.Update(this.operacion, this.operacion.tbtasacion);
            else
                operacionBusiness.Create(this.operacion);
        }

        #region Carga de Combo clientes

        private void CargarCombos()
        {
            this.SetearDisplayValue();
            this.CargarClientes();
        }

        private void SetearDisplayValue()
        {
            cmbCliente.ValueMember = "cli_id";
            cmbCliente.DisplayMember = "cli_nombre_completo";
        }

        private void CargarClientes()
        {
            ClienteBusiness clienteBusiness = new ClienteBusiness();
            List<tbcliente> clientes =
                (List<tbcliente>)clienteBusiness.GetList();

            if (clientes.Count != 0)
                foreach (var obj in clientes)
                    cmbCliente.Items.Add(obj);
        }

        #endregion

        #region Cargo controles de cliente seleccionado
        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarControlesCliente(
                (tbcliente)cmbCliente.SelectedItem, txbNombreCliente, txbApellidoCliente);
        }

        private void CargarControlesCliente(tbcliente c, TextBox _txbNom, TextBox _txbApe)
        {
            _txbNom.Text = c.cli_nombre;
            _txbApe.Text = c.cli_apellido;
        }
        #endregion

        #region Cargo Controles con los Datos de la Operacion Almacenada
        private void CargoFormulario()
        {
            dtpFecha.Enabled = false;
            dtpFecha.Value = this.operacion.ope_fecha.Value;

            CargarComboDireccion();
            CargarComboCliente();
            txbTasacion.Text = this.operacion.tbtasacion.tas_tasacion.ToString();
            txbObservaciones.Text = this.operacion.tbtasacion.tas_observaciones;
        }

        /// <summary>
        /// Se envia solo el id de la propiedad para que se carguen los controles correspondientes
        /// en el user control
        /// </summary>
        private void CargarComboDireccion()
        {
            userControlDatosPropiedad.SeleccionarPropiedad(this.operacion.pro_id);
        }

        /// <summary>
        /// Selecciono el cliente correspondiente del combo de clientes.
        /// </summary>
        private void CargarComboCliente()
        {
            gbxCliente.Enabled = false;
            tbclienteoperacion clienteOperacion = this.operacion.tbclienteoperacion.FirstOrDefault();

            //Con el id del cliente obtengo el objeto para posteriormente setearlo
            foreach (tbcliente obj in cmbCliente.Items)
            {
                if (obj.cli_id == clienteOperacion.cli_id)
                {
                    cmbCliente.SelectedItem = obj;
                    break;
                }
            }
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

        private void ValidarEnteros(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        #endregion

    }
}
