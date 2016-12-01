using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LandManagement.Business;
using LandManagement.Entities;
using log4net;
using LandManagement.Utilidades;

namespace LandManagement
{
    public partial class frmTipoPropiedadABM : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private tbtipopropiedad tipoPropiedad;
        private Form formPadre;
        ValidarControles validarControles;
        public ErrorProvider errorProvider1 = new ErrorProvider();

        public frmTipoPropiedadABM(Form formularioPadre)
        {
            InitializeComponent();
            this.formPadre = formularioPadre;
        }

        public frmTipoPropiedadABM(tbtipopropiedad _tipoPropiedad, Form formularioPadre)
        {
            InitializeComponent();

            this.tipoPropiedad = _tipoPropiedad;
            this.formPadre = formularioPadre;

            //btnGuardar.Click -= new EventHandler(btnGuardar_Click);
            btnGuardar.Click += new EventHandler(btnGuardarActualiza_Click);
        }

        private void frmTipoPropiedadABM_Load(object sender, EventArgs e)
        {
            pnlControles.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;

            if (this.getTipoPropiedad() != null)
                CargarControles(this.getTipoPropiedad());
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateChildren())
                {
                    tbtipopropiedad tipoPropiedadLocal = new tbtipopropiedad();

                    CargarObjeto(tipoPropiedadLocal);
                    GuardarObjeto(tipoPropiedadLocal);
                    MensajeOk();
                    ((frmTipoPropiedadListado)formPadre).CargarGrilla();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al crear.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarActualiza_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateChildren())
                {
                    Cursor.Current = Cursors.WaitCursor;
                    tbtipopropiedad tipoPropiedadLocal = new tbtipopropiedad();
                    tipoPropiedadLocal = this.getTipoPropiedad();

                    CargarObjeto(tipoPropiedadLocal);
                    GuardarObjeto(tipoPropiedadLocal);
                    MensajeOk();
                    ((frmTipoPropiedadListado)formPadre).CargarGrilla();
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

        private void CargarObjeto(tbtipopropiedad _tipoPropiedad)
        {
            _tipoPropiedad.tip_descripcion = txbDescripcion.Text;
        }

        private void GuardarObjeto(tbtipopropiedad _tipoPropiedad)
        {
            TipoPropiedadBusiness tipoPropiedadBusiness = new TipoPropiedadBusiness();
            if (getTipoPropiedad() != null)
                tipoPropiedadBusiness.Update(_tipoPropiedad);
            else
                tipoPropiedadBusiness.Create(_tipoPropiedad);
        }
        
        private void CargarControles(tbtipopropiedad _tipoPropiedad)
        {
            txbDescripcion.Text = _tipoPropiedad.tip_descripcion;
        }

        public tbtipopropiedad getTipoPropiedad()
        {
            return this.tipoPropiedad;
        }

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

