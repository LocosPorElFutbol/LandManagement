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

            CargoPropietariosALaOperacion();
            CargaObjetoActualizable();
        }

        private void CargaObjetoActualizable()
        {
            CargoDatosOperacionTasacion();
        }

        private void CargoDatosOperacionTasacion()
        {
            this.operacion.tbtasacion.tas_apellido = txbApellidoTasador.Text;
            this.operacion.tbtasacion.tas_nombre = txbNombreTasador.Text;
            this.operacion.tbtasacion.tas_tasacion = Convert.ToDouble(txbTasacion.Text);
            this.operacion.tbtasacion.tas_observaciones = txbObservaciones.Text;
        }

        private void CargoPropietariosALaOperacion()
        {
            tbclienteoperacion clienteOperacion;
            this.operacion.tbclienteoperacion.Clear();

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

                    this.operacion.tbclienteoperacion.Add(clienteOperacion);
                }
            }
        }

        private void GuardaObjeto()
        {
            if (this.idOperacion != 0)
                operacionBusiness.Update(this.operacion, this.operacion.tbtasacion);
            else
                operacionBusiness.Create(this.operacion);
        }

        #region Carga de Combos Piso, Depto, Direcciones

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
            cmbPiso.Text = p.pro_piso.ToString();
            cmbDepto.Text = p.pro_departamento;
            txbLocalidad.Text = p.pro_localidad;
            txbCodigoPostal.Text = p.pro_codigo_postal;
        }
        #endregion

        #region Cargo Controles con los Datos de la Operacion Almacenada
        private void CargoFormulario()
        {
            dtpFecha.Enabled = false;
            dtpFecha.Value = this.operacion.ope_fecha.Value;

            CargarComboDireccion();
            txbApellidoTasador.Text = this.operacion.tbtasacion.tas_apellido;
            txbNombreTasador.Text = this.operacion.tbtasacion.tas_nombre;
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
