using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LandManagement.Entities;
using LandManagement.Utilidades;
using LandManagement.Business;
using log4net;

namespace LandManagement
{
    public partial class frmClientePropiedad : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private TipoPropiedadBusiness tipoPropiedadBusiness;
        private tbpropiedad propiedad;
        private int idPropiedad = 0;
        private int[] idsPropiedades;
        private int indiceFila = -1;
        private bool esNuevo = false;
        private ListasDeElementos listasDeElementos;
        private Form formPadre;
        ValidarControles validarControles;
        private ErrorProvider errorProvider1 = new ErrorProvider();

        public frmClientePropiedad(Form formularioPadre, int[] _idsPropiedades)
        {
            InitializeComponent();
            this.formPadre = formularioPadre;
            this.esNuevo = true;
            this.idsPropiedades = _idsPropiedades;
        }

        public frmClientePropiedad(tbpropiedad prop, int idxFila, Form formularioPadre)
        {
            InitializeComponent();
            this.formPadre = formularioPadre;
            this.propiedad = prop;
            this.idPropiedad = prop.pro_id;
            this.indiceFila = idxFila;

            btnGuardar.Click -= new EventHandler(btnGuardar_Click);
            btnGuardar.Click += new EventHandler(btnGuardarActualiza_Click);
        }

        private void frmClientePropiedad_Load(object sender, EventArgs e)
        {
            pnlControles.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            listasDeElementos = new ListasDeElementos();
            this.CargarCombos();
            
            if (this.esNuevo)
            {
                this.InicializarControlesHabilitados(this.esNuevo);

                cmbDireccion.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbDireccion.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            else
            {
                //Selecciono propiedad del combo y habilito groupbox
                rdbExistente.Enabled = false;
                rdbPropiedadNueva.Enabled = false;
                gbxDatosPropiedad.Enabled = true;
                cmbDireccion.Enabled = false;
                this.CargarControlesPropiedad(this.propiedad);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateChildren())
                {
                    if (this.idPropiedad == 0)
                        this.propiedad = new tbpropiedad();
                    CargaObjeto();
                    GuardaObjeto();
                    this.Close();
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
                    CargaObjeto();
                    //((frmClienteABM)this.formPadre).ActualizarPropiedadSeleccionada(this.propiedad, this.indiceFila);
                    this.Close();
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

        private void rdbPropiedadNueva_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPropiedadNueva.Checked == true)
                InicializarControlesHabilitados(true);

            if (rdbExistente.Checked == true)
                InicializarControlesHabilitados(false);
        }

        private void cmbDireccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarControlesPropiedad((tbpropiedad)cmbDireccion.SelectedItem);
        }

        private void CargarControlesPropiedad(tbpropiedad p)
        {
            //cmbTipoFamiliar.Text = this.familiar.tbtipofamiliar.tif_descripcion;
            //cmbTipoPropiedad.Text = this.propiedad.pro_tip_descripcion;

            if (p.tbtipopropiedad != null)
                cmbTipoPropiedad.Text = p.tbtipopropiedad.tip_descripcion;
            else
                cmbTipoPropiedad.Text = p.pro_tip_descripcion;
            txbCalle.Text = p.pro_calle;
            txbNumero.Text = p.pro_numero.ToString();
            cmbPiso.Text = p.pro_piso.ToString();
            cmbDepto.Text = p.pro_departamento;
            txbLocalidad.Text = p.pro_localidad;
            txbCodigoPostal.Text = p.pro_codigo_postal;
            txbCaracteristicas.Text = p.pro_caracteristica;
        }

        #region Carga de Combos TipoPropiedad, Piso, Depto y Direcciones

        private void CargarCombos()
        {
            this.SetearDisplayValue();
            this.CargarTipoPropiedad();
            this.CargarPiso();
            this.CargarDepto();
            this.CargarDirecciones();
            this.SetearIndiceCombo();
        }

        private void SetearIndiceCombo()
        {
            cmbTipoPropiedad.SelectedIndex = 0;
            cmbPiso.SelectedIndex = 0;
            cmbDepto.SelectedIndex = 0;

            if (this.esNuevo)
                if (cmbDireccion.Items.Count > 0)
                    cmbDireccion.SelectedIndex = 0;
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
            List<tbpropiedad> listaDirecciones = null;

            if (this.idsPropiedades != null && this.idsPropiedades.Length != 0)
                listaDirecciones = (List<tbpropiedad>)propiedadBusiness.GetListDirecciones(this.idsPropiedades);
            else
                listaDirecciones = (List<tbpropiedad>)propiedadBusiness.GetListDirecciones();

            if (listaDirecciones.Count != 0)
                foreach (var obj in listaDirecciones)
                    cmbDireccion.Items.Add(obj);
            else
                this.DeshabilitarControlesDireccion();
        }

        private void CargarCombo(List<ComboBoxItem> lista, ComboBox combo)
        {
            foreach (var obj in lista)
                combo.Items.Add(obj);
        }

        #endregion

        private void CargaObjeto()
        {
            this.propiedad.tip_id = ((tbtipopropiedad)cmbTipoPropiedad.SelectedItem).tip_id;
            
            //Cargo id de propiedad si se selecciono del combo
            if (cmbDireccion.Enabled)
                this.propiedad.pro_id = ((tbpropiedad)cmbDireccion.SelectedItem).pro_id;

            this.propiedad.pro_tip_descripcion = ((tbtipopropiedad)cmbTipoPropiedad.SelectedItem).tip_descripcion;
            this.propiedad.pro_calle = txbCalle.Text;
            this.propiedad.pro_numero = Convert.ToInt32(txbNumero.Text);
            this.propiedad.pro_piso = ((ComboBoxItem)cmbPiso.SelectedItem).Value;
            this.propiedad.pro_departamento = ((ComboBoxItem)cmbDepto.SelectedItem).Text;
            this.propiedad.pro_localidad = txbLocalidad.Text;
            this.propiedad.pro_codigo_postal = txbCodigoPostal.Text;
            this.propiedad.pro_caracteristica = txbCaracteristicas.Text;
        }

        private void GuardaObjeto()
        {
            //((frmClienteABM)this.formPadre).AgregaPropiedadAGrilla(this.propiedad);
        }

        private void InicializarControlesHabilitados(bool esNueva)
        {
            gbxDatosPropiedad.Enabled = esNueva;
            lblDireccion.Enabled = !esNueva;
            cmbDireccion.Enabled = !esNueva;

            if (esNueva)
            {
                this.SetearIndiceCombo();
                txbCalle.Text = string.Empty;
                txbNumero.Text = string.Empty;
                txbLocalidad.Text = string.Empty;
                txbCodigoPostal.Text = string.Empty;
                txbCaracteristicas.Text = string.Empty;
            }
            else
                CargarControlesPropiedad((tbpropiedad)cmbDireccion.SelectedItem);
        }

        private void DeshabilitarControlesDireccion()
        {
            rdbExistente.Enabled = false;
            cmbDireccion.Enabled = false;
        }

        private void MensajeCancelar()
        {
            DialogResult dialogResult = DialogResult.None;

            dialogResult = MessageBox.Show("Se aplicaron cambios. Se perderán todos los datos que no hayan sido guardados. \n¿Desea cerrar la ventana?",
                "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                AutoValidate = AutoValidate.Disable;
                this.Close();
            }
        }

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

        private void ValidarEntero(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        #endregion
    }
}
