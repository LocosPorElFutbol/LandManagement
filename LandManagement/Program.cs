using LandManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using log4net.Config;
using log4net;
using log4net.Appender;
using System.IO;
using System.Configuration;
using System.Diagnostics;

namespace LandManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DialogResult result;
            List<tbmenu> listaMenu;


            /* Validación de ejecución */
            string nombreProceso = Process.GetCurrentProcess().ProcessName;
            if (Process.GetProcesses().Count(x => x.ProcessName == nombreProceso) > 1)
            {
                MessageBox.Show("La aplicación ya se encuentra en ejecución");
                return;
            }
            //Configuración de archivo de log
            //Cargar la key de la carpeta
            string carpetaLog = ConfigurationManager.AppSettings["CarpetaLog"].ToString();
            //Obtener el path de ubicacion del exe
            string path = AppDomain.CurrentDomain.BaseDirectory;

            GlobalContext.Properties["DirectorioDeLogs"] = path + carpetaLog;

            XmlConfigurator.Configure();

            using (var form = new frmLogin())
            {
                result = form.ShowDialog();
                listaMenu = form.listaMenuDelUsuario;
            }

            if (result == DialogResult.OK)
                Application.Run(new frmPadre(listaMenu));
        }

    }
}
