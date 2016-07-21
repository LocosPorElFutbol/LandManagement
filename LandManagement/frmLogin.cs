using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using LandManagement.Business;
using LandManagement.Entities;
using LandManagement.Utilidades;
using log4net;

namespace LandManagement
{
    public partial class frmLogin: Form
    {
        private Timer timerParpadeo;
        private int cantParpadeos = 0;
        private UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
        public List<tbmenu> listaMenuDelUsuario;
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public frmLogin()
        {
            InitializeComponent();

            timerParpadeo = new Timer();
            timerParpadeo.Interval = 300;
            timerParpadeo.Enabled = false;
            timerParpadeo.Tick += new EventHandler(timerParpadeo_Tick);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            pnlControles.AutoScroll = true;
            this.Icon = (Icon)Recursos.ResourceImages.ResourceManager.GetObject("Llave");
            this.Text = "Inicio de Sesión";
            pbxLogoCliente.Image = (Image)Recursos.ResourceImages.ResourceManager.GetObject("Logo");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                log.Info("ingreso");
                Cursor.Current = Cursors.WaitCursor;
                cantParpadeos = 0;
                if (ValidacionCredenciales())
                {
                    timerParpadeo.Tick -= timerParpadeo_Tick;
                    DialogResult = DialogResult.OK;
                    Dispose();
                }
                else
                {
                    timerParpadeo.Start();
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                log.Error(ex.InnerException.Message);
                MessageBox.Show(ex.InnerException.Message);
            }
            log.Info("salio");
        }

        void timerParpadeo_Tick(object sender, EventArgs e)
        {
            if (cantParpadeos <= 6)
                if (lblError.Visible)
                    lblError.Visible = false;
                else
                    lblError.Visible = true;
            else
            {
                timerParpadeo.Stop();
                lblError.Visible = true;
            }
            cantParpadeos++;
        }

        private bool ValidacionCredenciales()
        {
            tbusuario usuario = new tbusuario() { usu_nombre_login = txbUsuario.Text };
            usuario = usuarioBusiness.ValidacionUsuarioPassword(usuario, txbPassword.Text);

            if (usuario != null)
            {
                VariablesDeSesion.UsuarioLogueado = usuario;
                cargarListaMenuDelUsuario(usuario);
                return true;
            }
            
            return false;
        }

        private void cargarListaMenuDelUsuario(tbusuario usuario)
        {
            this.listaMenuDelUsuario = new List<tbmenu>();
            // Intento de levantarlo desde el repositorio
            //this.listaMenuDelUsuario = usuario.tbmenu.ToList();
            this.listaMenuDelUsuario = usuarioBusiness.CargarMenuAsignadoAUsuario(usuario);

            //Ordeno alfabeticamente el menu
            this.listaMenuDelUsuario = this.listaMenuDelUsuario.OrderBy(x => x.men_nombre).ToList();
            foreach (var obj in this.listaMenuDelUsuario)
                obj.tbmenu1 = obj.tbmenu1.OrderBy(x => x.men_nombre).ToList();
        }

        private void txbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (e.KeyChar == Convert.ToChar(Keys.Enter))
                btnAceptar.PerformClick();
        }

    }
}
