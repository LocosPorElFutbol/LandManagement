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

namespace LandManagement
{
    public partial class frmLicencia : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public frmLicencia()
        {
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

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al activar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
