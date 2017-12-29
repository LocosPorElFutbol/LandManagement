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
            pnlControles.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.gbxDetalleDireccion.Enabled = false;
            listasDeElementos = new ListasDeElementos();
            this.CargarCombos();

            cmbCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbDireccion.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbDireccion.AutoCompleteSource = AutoCompleteSource.ListItems;

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
                    //((frmBase)formPadre).CargarGrillaOperaciones();
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
            this.operacion.pro_id = ((tbpropiedad)cmbDireccion.SelectedItem).pro_id;

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
            //LINEAS A ELIMINAR
            this.operacion.tbtasacion.tas_nombre = "BLANCO";
            this.operacion.tbtasacion.tas_apellido = "BLANCO";
            //LINEAS A ELIMINAR
            
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

        #region Carga de Combos Piso, Depto, Direcciones y clientes

        private void CargarCombos()
        {
            this.SetearDisplayValue();
            this.CargarTipoPropiedad();
            this.CargarPiso();
            this.CargarDepto();
            this.CargarDirecciones();
            this.CargarClientes();
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

        private void CargarClientes()
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
            if (p.pro_piso == 0)
                cmbPiso.Text = "PB";
            else
                cmbPiso.Text = p.pro_piso.ToString();
            cmbDepto.Text = p.pro_departamento;
            txbLocalidad.Text = p.pro_localidad;
            txbCodigoPostal.Text = p.pro_codigo_postal;
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


        /// <summary>
        /// Cargo el combo del cliente mediante el id (que al mismo tiempo obtengo de tbclienteoperacion).
        /// Es importante aclarar que solamente se tomara un cliente, ya que la operación de tasación 
        /// involucra unicamente a un solo cliente.
        /// </summary>
        private void CargarComboCliente()
        {
            gbxCliente.Enabled = false;
            tbclienteoperacion clienteOperacion = null;
            tbcliente clienteSeleccionado = null;

            //Busco id del cliente en la operación
            foreach (tbcliente obj in cmbCliente.Items)
            {
                clienteOperacion =
                    this.operacion.tbclienteoperacion.Where(x => x.cli_id == obj.cli_id).FirstOrDefault();

                if (clienteOperacion != null)
                {
                    ClienteBusiness clienteBusiness = new ClienteBusiness();
                    tbcliente cliente = clienteBusiness.GetElement(new tbcliente() { cli_id = clienteOperacion.cli_id }) as tbcliente;
                    cmbDireccion.SelectedItem = cliente;
                    break;
                }
            }

            //Con el id del cliente obtengo el objeto para posteriormente setearlo
            foreach (tbcliente obj in cmbCliente.Items)
                if (obj.cli_id == clienteOperacion.cli_id)
                    clienteSeleccionado = obj;

            cmbCliente.SelectedItem = clienteSeleccionado;
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
