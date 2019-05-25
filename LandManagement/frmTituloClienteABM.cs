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
using LandManagement.Utilidades;
using log4net;

namespace LandManagement
{
    public partial class frmTituloClienteABM : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private tbtitulocliente tituloClienteExistente;
        private Form formPadre;
        ValidarControles validarControles;
        public ErrorProvider errorProvider1 = new ErrorProvider();

        public frmTituloClienteABM(Form formularioPadre)
        {
            InitializeComponent();
            this.formPadre = formularioPadre;
        }

        public frmTituloClienteABM(tbtitulocliente tituloCliente, Form _formularioPadre)
        {
            InitializeComponent();

            this.tituloClienteExistente = tituloCliente;
            this.formPadre = _formularioPadre;

            btnGuardar.Click -= new EventHandler(btnGuardar_Click);
            btnGuardar.Click += new EventHandler(btnGuardarActualiza_Click);
        }

        private void frmTituloClienteABM_Load(object sender, EventArgs e)
        {
            pnlControles.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;

            if (this.getTituloCliente() != null)
                CargarControles(this.getTituloCliente());
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateChildren())
                {
                    tbtitulocliente tituloCliente = new tbtitulocliente();

                    CargarObjeto(tituloCliente);
                    GuardarObjeto(tituloCliente);
                    MensajeOk();
                    ((frmTituloClienteListado)formPadre).CargarGrilla();
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
                    tbtitulocliente tituloClienteLocal = new tbtitulocliente();
                    tituloClienteLocal = this.getTituloCliente();

                    CargarObjeto(tituloClienteLocal);
                    GuardarObjeto(tituloClienteLocal);
                    MensajeOk();
                    ((frmTituloClienteListado)formPadre).CargarGrilla();
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

        }

        private void CargarControles(tbtitulocliente tituloCliente)
        {
            txbDescripcion.Text = tituloCliente.tcl_descripcion;
        }

        private void CargarObjeto(tbtitulocliente tituloCliente)
        {
            tituloCliente.tcl_descripcion = txbDescripcion.Text;
        }

        private void GuardarObjeto(tbtitulocliente tituloCliente)
        {
            TituloClienteBusiness tituloClienteBusiness = new TituloClienteBusiness();
            if (getTituloCliente() != null)
                tituloClienteBusiness.Update(tituloCliente);
            else
                tituloClienteBusiness.Create(tituloCliente);
        }

        public tbtitulocliente getTituloCliente()
        {
            return this.tituloClienteExistente;
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
