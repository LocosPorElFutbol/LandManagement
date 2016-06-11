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
    public partial class frmTipoFamiliarABM : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private tbtipofamiliar tipofamiliarExistente;
        private Form formPadre;
        ValidarControles validarControles;
        public ErrorProvider errorProvider1 = new ErrorProvider();

        public frmTipoFamiliarABM(Form formularioPadre)
        {
            InitializeComponent();
            this.formPadre = formularioPadre;
        }

        public frmTipoFamiliarABM(tbtipofamiliar _tipoFamiliar, Form _formularioPadre)
        {
            InitializeComponent();

            this.tipofamiliarExistente = _tipoFamiliar;
            this.formPadre = _formularioPadre;

            btnGuardar.Click -= new EventHandler(btnGuardar_Click);
            btnGuardar.Click += new EventHandler(btnGuardarActualiza_Click);
        }

        private void frmTipoFamiliarABM_Load(object sender, EventArgs e)
        {
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;

            if (this.getTipoFamiliar() != null)
                CargarControles(this.getTipoFamiliar());
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateChildren())
                {
                    tbtipofamiliar tipoFamiliar = new tbtipofamiliar();

                    CargarObjeto(tipoFamiliar);
                    GuardarObjeto(tipoFamiliar);
                    MensajeOk();
                    ((frmTipoFamiliarListado)formPadre).CargarGrilla();
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
                    tbtipofamiliar tipoFamiliarLocal = new tbtipofamiliar();
                    tipoFamiliarLocal = this.getTipoFamiliar();

                    CargarObjeto(tipoFamiliarLocal);
                    GuardarObjeto(tipoFamiliarLocal);
                    MensajeOk();
                    ((frmTipoFamiliarListado)formPadre).CargarGrilla();
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

        private void CargarControles(tbtipofamiliar _tipoFamiliar)
        {
            txbDescripcion.Text = _tipoFamiliar.tif_descripcion;
        }

        private void CargarObjeto(tbtipofamiliar _tipoFamiliar)
        {
            _tipoFamiliar.tif_descripcion = txbDescripcion.Text;
        }

        private void GuardarObjeto(tbtipofamiliar _tipoFamiliar)
        {
            TipoFamiliarBusiness tipoFamiliarBusiness = new TipoFamiliarBusiness();
            if (getTipoFamiliar() != null)
                tipoFamiliarBusiness.Update(_tipoFamiliar);
            else
                tipoFamiliarBusiness.Create(_tipoFamiliar);
        }

        public tbtipofamiliar getTipoFamiliar()
        {
            return this.tipofamiliarExistente;
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
