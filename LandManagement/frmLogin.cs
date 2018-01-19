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
using System.Configuration;
using System.Net.NetworkInformation;

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
            VariablesDeSesion.MACADDRESS_ETHERNET = GetMacAddressEthernet();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (!this.LicenciaActivada())
                gbxLogin.Enabled = false;
            else 
                lkbActivarProducto.Visible = false;

            this.Icon = (Icon)Recursos.ResourceImages.ResourceManager.GetObject("Llave");
            this.Text = "Inicio de Sesión";
            pbxLogoCliente.Image = (Image)Recursos.ResourceImages.ResourceManager.GetObject("Logo");
            
            VersionBusiness versionBusiness = new VersionBusiness();
            this.Text += " - Land Management v" + versionBusiness.GetLastVersion().ver_version;

            if (Properties.Settings.Default.nombreUsuario != string.Empty)
            {
                txbUsuario.Text = Properties.Settings.Default.nombreUsuario;
                txbPassword.Text = Properties.Settings.Default.passwordUsuario;
                cbxRecordar.Checked = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                log.Info("ingreso");

                RecordarDatosDeUsuario();

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

        private void lkbActivarProducto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicencia formularioLicencia = new frmLicencia();
            formularioLicencia.Show();
        }

        private void RecordarDatosDeUsuario()
        {
            if (cbxRecordar.Checked)
            {
                Properties.Settings.Default.nombreUsuario = txbUsuario.Text;
                Properties.Settings.Default.passwordUsuario = txbPassword.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.nombreUsuario = string.Empty;
                Properties.Settings.Default.passwordUsuario = string.Empty;
                Properties.Settings.Default.Save();
            }
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

        private bool LicenciaActivada()
        {
            //return true;
            return false;
        }

        /// <summary>
        /// Obtiene la mac address de la placa de red del equipo. No importa si esta en uso o no.
        /// </summary>
        /// <returns></returns>
        private string GetMacAddressEthernet()
        {
            string macAddresses = string.Empty;
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Only consider Ethernet network interfaces, thereby ignoring any
                // loopback devices etc.
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }

                //STATUS UP, LAN CONECTADA
                //if (nic.NetworkInterfaceType != NetworkInterfaceType.Ethernet) continue;
                //if (nic.OperationalStatus == OperationalStatus.Up)
                //{
                //    macAddresses += nic.GetPhysicalAddress().ToString();
                //    break;
                //}
            }

            return macAddresses;
        }

    }
}
