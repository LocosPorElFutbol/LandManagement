using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using LandManagement.Entities;
using System.Configuration;

namespace LandManagement.Utilidades
{
    public class Formularios
    {
     /// <summary>
     /// Instancia un formulario, abre un nuevo formulario dentro de la ventana principal que tiene
     /// como padre.
     /// </summary>
     /// <param name="formularioPadre">Formulario padre, contenedor del formulario que se va a instanciar.</param>
     /// <param name="formularioPopUp">Formulario a instanciar, popup que se abrira dentro del formulario padre.</param>
     /// <param name="textFormulario">Encabezado del formulario a abrirse.</param>
        public void InstanciarFormulario(Form formularioPadre, Form formularioPopUp, string textFormulario)
        {
            Assembly frmAssembly = Assembly.LoadFile(Application.ExecutablePath);
            string frmCode = formularioPopUp.Name;
            string frmNombre = textFormulario;

            formularioPopUp.ShowIcon = true;
            formularioPopUp.Text = frmNombre;
            formularioPopUp.Icon = (Icon)Recursos.ResourceImages.ResourceManager.GetObject("Tool");

            formularioPopUp.MdiParent = formularioPadre;
            formularioPopUp.WindowState = FormWindowState.Minimized;
            formularioPopUp.Show();
            formularioPopUp.WindowState = FormWindowState.Maximized;
            formularioPopUp.Show();
        }

        /// <summary>
        /// SE DEJA DE UTILIZAR PORQUE EL CLIENTE QUERIA PODER ABRIR MAS DE UN FORMULARIO
        /// DEL MISMO TIPO.
        /// </summary>
        /// <param name="formularioPopUp"></param>
        /// <param name="textFormulario"></param>
        private void ControlarInstanciaAbiertaOLD(Form formularioPopUp, string textFormulario)
        {
            Assembly frmAssembly = Assembly.LoadFile(Application.ExecutablePath);
            string frmCode = formularioPopUp.Name;
            string frmNombre = textFormulario;

            foreach (Type type in frmAssembly.GetTypes())
            {
                if (type.BaseType == typeof(Form))
                {
                    if (type.Name == frmCode)
                    {
                        if (Application.OpenForms.Cast<Form>().Any(form => form.Name == frmCode))
                        {
                            Form f = Application.OpenForms[frmCode];
                            f.WindowState = FormWindowState.Normal;
                            formularioPopUp.Text = frmNombre;
                            f.Activate();
                        }
                        else
                        {
                            formularioPopUp.ShowIcon = true;
                            formularioPopUp.Text = frmNombre;
                            formularioPopUp.Icon = (Icon)Recursos.ResourceImages.ResourceManager.GetObject("Tool");

                            //formularioPopUp.MdiParent = this.MdiParent;
                            formularioPopUp.WindowState = FormWindowState.Minimized;
                            formularioPopUp.Show();
                            formularioPopUp.WindowState = FormWindowState.Maximized;
                            formularioPopUp.Show();
                        }

                    }

                }
            }

        }

        public string ObtenerNombreFormulario(tboperaciones _operacion)
        {
            if (_operacion.tas_id != null)
                return ConfigurationManager.AppSettings["tas_id"].ToString();

            if (_operacion.env_id != null)
                return ConfigurationManager.AppSettings["env_id"].ToString();

            if (_operacion.rev_id != null)
                return ConfigurationManager.AppSettings["rev_id"].ToString();

            if (_operacion.ven_id != null)
                return ConfigurationManager.AppSettings["ven_id"].ToString();

            if (_operacion.ena_id != null)
                return ConfigurationManager.AppSettings["ena_id"].ToString();

            if (_operacion.rea_id != null)
                return ConfigurationManager.AppSettings["rea_id"].ToString();

            if (_operacion.alq_id != null)
                return ConfigurationManager.AppSettings["alq_id"].ToString();

            if (_operacion.enc_id != null)
                return ConfigurationManager.AppSettings["enc_id"].ToString();

            return string.Empty;
        }

    }
}
