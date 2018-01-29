using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LandManagement.Utilidades;
using log4net;
using LandManagement.Entities;
using LandManagement.Business;

namespace LandManagement
{
    public partial class frmLicencia : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        Form formularioLogin = null;


        public frmLicencia(Form _formularioLogin)
        {
            this.formularioLogin = _formularioLogin;
            InitializeComponent();
        }

        private void frmLicencia_Load(object sender, EventArgs e)
        {
            this.Icon = (Icon)Recursos.ResourceImages.ResourceManager.GetObject("Llave");
            this.Text = "Activación del Producto";
            this.txbEquipo.Text = VariablesDeSesion.MACADDRESS_ETHERNET;
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.EncriptacionCorrecta())
                {
                    tbsyslicencia licencia = new tbsyslicencia();
                    licencia.scl_id = 1;
                    licencia.sli_mac_ethernet = txbEquipo.Text;
                    licencia.sli_hash_access = txbCodigoActivacion.Text;
                    licencia.sli_en_uso = false;
                    licencia.sli_estado = true;

                    LicenciaBusiness licenciaBusiness = new LicenciaBusiness();
                    licenciaBusiness.ActivarProducto(licencia);

                    MensajeActivacion();
                }
                else
                    MessageBox.Show("Código de activación incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al activar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MensajeActivacion()
        {
            var respuesta = MessageBox.Show("El producto se activo correctamente.", "Activación", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (respuesta == System.Windows.Forms.DialogResult.OK)
            {
                formularioLogin.Close();
                this.Close();
                System.Diagnostics.Process.Start(Application.ExecutablePath);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool EncriptacionCorrecta()
        {
            EncriptarDatos.Library.EncriptarDatos encriptarDatos = new EncriptarDatos.Library.EncriptarDatos();
            string macEncriptada = encriptarDatos.EncriptarTexto(VariablesDeSesion.MACADDRESS_ETHERNET);

            if (macEncriptada.Equals(txbCodigoActivacion.Text))
                return true;
            return false;
        }

    }
}
