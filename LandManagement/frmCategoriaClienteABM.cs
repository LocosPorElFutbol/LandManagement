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
    public partial class frmCategoriaClienteABM : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private tbcategoriacliente categoriaClienteExistente;
        private Form formPadre;
        ValidarControles validarControles;
        public ErrorProvider errorProvider1 = new ErrorProvider();

        public frmCategoriaClienteABM(Form formularioPadre)
        {
            InitializeComponent();
            this.formPadre = formularioPadre;
        }

        public frmCategoriaClienteABM(tbcategoriacliente categoriacliente, Form formularioPadre)
        {

            InitializeComponent();

            this.categoriaClienteExistente = categoriacliente;
            this.formPadre = formularioPadre;

            btnGuardar.Click -= new EventHandler(btnGuardar_Click);
            btnGuardar.Click += new EventHandler(btnGuardarActualiza_Click);
        }
        
        private void frmTipoClienteABM_Load(object sender, EventArgs e)
        {
            pnlControles.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;

            if (this.getCategoriaCliente() != null)
                CargarControles(this.getCategoriaCliente());
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateChildren())
                {
                    tbcategoriacliente categoriaCliente = new tbcategoriacliente();

                    CargarObjeto(categoriaCliente);
                    GuardarObjeto(categoriaCliente);
                    MensajeOk();
                    ((frmCategoriaClienteListado)formPadre).CargarGrilla();
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
                    tbcategoriacliente categoriaCliente = new tbcategoriacliente();
                    categoriaCliente = this.getCategoriaCliente();

                    CargarObjeto(categoriaCliente);
                    GuardarObjeto(categoriaCliente);
                    MensajeOk();
                    ((frmCategoriaClienteListado)formPadre).CargarGrilla();
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

        private void CargarControles(tbcategoriacliente categoriaCliente)
        {
            txbDescripcion.Text = categoriaCliente.ccl_descripcion;
        }

        private void CargarObjeto(tbcategoriacliente categoriaCliente)
        {
            categoriaCliente.ccl_descripcion = txbDescripcion.Text;
        }

        private void GuardarObjeto(tbcategoriacliente categoriaCliente)
        {
            CategoriaClienteBusiness categoriaClienteBusiness = new CategoriaClienteBusiness();
            if (getCategoriaCliente() != null)
                categoriaClienteBusiness.Update(categoriaCliente);
            else
                categoriaClienteBusiness.Create(categoriaCliente);
        }

        public tbcategoriacliente getCategoriaCliente()
        {
            return this.categoriaClienteExistente;
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

                e.Cancel = true;
                return;
            }

            errorProvider1.SetError(control, error);
        }
        #endregion
    }
}
