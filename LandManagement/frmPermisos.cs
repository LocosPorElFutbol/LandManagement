using LandManagement.Business;
using LandManagement.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LandManagement
{
    public partial class frmPermisos : Form
    {
        private tbusuario usuarioSeleccionado;
        public frmPermisos()
        {
            InitializeComponent();
        }

        public frmPermisos(tbusuario usuario)
        {
            InitializeComponent();

            this.usuarioSeleccionado = usuario;
            txbNombre.Text = usuario.usu_nombre;
            txbApellido.Text = usuario.usu_apellido;
            SetearObjetosListas();
        }

        private void frmPermisos_Load(object sender, EventArgs e)
        {
            var listaTodosLosPermisos = this.FiltrarTodosLosPermisos(this.usuarioSeleccionado);
            CargoLista(lbxTodosLosPermisos, listaTodosLosPermisos);

            var listaPermisosUsuario = (List<tbmenu>)this.usuarioSeleccionado.tbmenu.ToList();
            CargoLista(lbxPermisosAsignados, listaPermisosUsuario);
        }

        private void CargoLista(ListBox listbox, List<tbmenu> listaElementos)
        {
            foreach (var obj in listaElementos)
                listbox.Items.Add(obj);
        }

        private List<tbmenu> FiltrarTodosLosPermisos(tbusuario usuario)
        {
            MenuBusiness menuBusiness = new MenuBusiness();
            List<tbmenu> listaCompleta = (List<tbmenu>)menuBusiness.ObtenerListadoMenu();
            List<tbmenu> listaUsuario = (List<tbmenu>)this.usuarioSeleccionado.tbmenu.ToList();

            foreach (tbmenu m in listaUsuario)
            {
                var obj = listaCompleta.Where(x => x.men_id == m.men_id).SingleOrDefault();
                listaCompleta.Remove(obj);            
            }

            return listaCompleta;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            lbxPermisosAsignados.Items.Add(lbxTodosLosPermisos.SelectedItem);
            lbxTodosLosPermisos.Items.Remove(lbxTodosLosPermisos.SelectedItem);
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            lbxTodosLosPermisos.Items.Add(lbxPermisosAsignados.SelectedItem);
            lbxPermisosAsignados.Items.Remove(lbxPermisosAsignados.SelectedItem);
        }

        private void SetearObjetosListas()
        {
            lbxTodosLosPermisos.DisplayMember = "men_nombre";
            lbxTodosLosPermisos.ValueMember = "men_id";
            lbxPermisosAsignados.DisplayMember = "men_nombre";
            lbxPermisosAsignados.ValueMember = "men_id";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.usuarioSeleccionado.tbmenu.Clear();
            
            foreach (tbmenu obj in lbxPermisosAsignados.Items)
                this.usuarioSeleccionado.tbmenu.Add(obj);
            
            UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
            usuarioBusiness.Update(this.usuarioSeleccionado);

            MensajeOk();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MensajeCancelar();
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
