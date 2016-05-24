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

namespace LandManagement
{
    public partial class frmUsuarioABM : Form
    {
        private UsuarioBusiness usuarioBusiness;
        private tbusuario usuario;
        private int idUsuario = 0;
        private Form formPadre;
        
        public frmUsuarioABM(Form formularioPadre)
        {
            InitializeComponent();
            this.formPadre = formularioPadre;
        }

        public frmUsuarioABM(tbusuario pUsuario, Form formularioPadre)
        {
            InitializeComponent();

            this.formPadre = formularioPadre;
            this.usuario = pUsuario;

            usuarioBusiness = new UsuarioBusiness();
            this.idUsuario = pUsuario.usu_id;
            txbNombreUsuario.Text = pUsuario.usu_nombre;
            txbApellidoUsuario.Text = pUsuario.usu_apellido;
            txbNombreLogin.Text = pUsuario.usu_nombre_login;
            txbEmailUsuario.Text = pUsuario.usu_email;
            txbPassword.Text = pUsuario.usu_password;
            chbEstado.Checked = pUsuario.usu_estado;

            btnGuardar.Click -= new EventHandler(btnGuardar_Click);
            btnGuardar.Click += new EventHandler(btnGuardarActualiza_Click);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.usuario = new tbusuario();
                CargaObjeto();
                GuardaObjeto();
                MensajeOk();
                ((frmUsuarioListado)formPadre).CargarGrilla();
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnGuardarActualiza_Click(object sender, EventArgs e)
        {
            try
            {
                CargaObjeto();
                GuardaObjeto();
                MensajeOk();
                ((frmUsuarioListado)formPadre).CargarGrilla();
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MensajeCancelar();
        }

        private void CargaObjeto()
        {
            this.usuario.usu_nombre = txbNombreUsuario.Text;
            this.usuario.usu_apellido = txbApellidoUsuario.Text;
            this.usuario.usu_nombre_login = txbNombreLogin.Text;
            this.usuario.usu_email = txbEmailUsuario.Text;
            this.usuario.usu_estado = chbEstado.Checked;

            //Momentaneamente se setea en blanco
            //posteriormente se va a generar de manera dinamica y enviada por email
            this.usuario.usu_password = txbPassword.Text;
        }

        private void GuardaObjeto()
        {
            usuarioBusiness = new UsuarioBusiness();

            if (this.idUsuario != 0)
                usuarioBusiness.Update(this.usuario);
            else
                usuarioBusiness.Create(this.usuario);
        }

        private void MensajeOk()
        {
            MessageBox.Show("El registro se guardo correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeCancelar()
        {
            DialogResult dialogResult = DialogResult.None;

            dialogResult = MessageBox.Show("Se aplicaron cambios. Se perderán todos los datos que no hayan sido guardados. \n¿Desea cerrar la ventana?",
                "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                AutoValidate = AutoValidate.Disable;
                this.Close();
            }
        }

    }
}
