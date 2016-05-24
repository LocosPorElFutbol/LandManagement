using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LandManagement.Entities;
using System.Reflection;
using LandManagement.Business;
using LandManagement.Utilidades;

namespace LandManagement
{
    public partial class frmUsuarioListado : Form
    {
        private UsuarioBusiness usuarioBusiness;
        private frmUsuarioABM formularioUsuarioABM;
        private DataGridViewRow dataGridViewRow;
        private DisplayNameHelper displayNameHelper;
        private frmPermisos formularioPermisos;

        public frmUsuarioListado()
        {
            InitializeComponent();
            usuarioBusiness = new UsuarioBusiness();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        public void CargarGrilla()
        {
            usuarioBusiness = new UsuarioBusiness();
            dgvUsuarios.Rows.Clear();
            dgvUsuarios.Columns.Clear();
            string[] columnasGrilla = { "usu_id", 
                                        "usu_nombre", 
                                        "usu_apellido", 
                                        "usu_email", 
                                        "usu_nombre_login",
                                        "usu_password",
                                        "usu_estado"};

            int i = 0;
            foreach (string s in columnasGrilla)
            {
                PropertyInfo pi = typeof(tbusuario).GetProperty(s);
                displayNameHelper = new DisplayNameHelper();
                string columna = displayNameHelper.GetMetaDisplayName(pi);
                dgvUsuarios.Columns.Add(s, columna);
                i++;
            }

            int indice;
            List<tbusuario> listaUsuarios = (List<tbusuario>)usuarioBusiness.GetList();
            foreach (var obj in listaUsuarios)
            {
                indice = dgvUsuarios.Rows.Add();
                dataGridViewRow = dgvUsuarios.Rows[indice];
                dataGridViewRow.Cells["usu_id"].Value = obj.usu_id;
                dataGridViewRow.Cells["usu_nombre"].Value = obj.usu_nombre;
                dataGridViewRow.Cells["usu_apellido"].Value = obj.usu_apellido;
                dataGridViewRow.Cells["usu_email"].Value = obj.usu_email;
                dataGridViewRow.Cells["usu_nombre_login"].Value = obj.usu_nombre_login;
                dataGridViewRow.Cells["usu_password"].Value = obj.usu_password;
                dataGridViewRow.Cells["usu_estado"].Value = obj.usu_estado;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            formularioUsuarioABM = new frmUsuarioABM(this);
            ControlarInstanciaAbierta(formularioUsuarioABM, "Alta de Usuario");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count != 0)
            {
                if (MensajeEliminacionOK() == System.Windows.Forms.DialogResult.Yes)
                {
                    dataGridViewRow = dgvUsuarios.SelectedRows[0];
                    int idUsuarioSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["usu_id"].Value);
                    usuarioBusiness.Delete(new tbusuario() { usu_id = idUsuarioSeleccionado });
                    this.CargarGrilla();
                }
            }
            else
                this.MensajeSeleccionarElemento();
        }

        private void btnPermisos_Click(object sender, EventArgs e)
        {
            formularioPermisos = new frmPermisos(ObtenerUsuarioSeleccionado());
            ControlarInstanciaAbierta(formularioPermisos, "Alta de Permisos");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tbusuario usuario = ObtenerUsuarioSeleccionado();

            formularioUsuarioABM = new frmUsuarioABM(usuario, this);
            ControlarInstanciaAbierta(formularioUsuarioABM, "Planilla de Usuario");
        }

        private tbusuario ObtenerUsuarioSeleccionado()
        {
            dataGridViewRow = dgvUsuarios.SelectedRows[0];
            int idUsuarioSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["usu_id"].Value);

            tbusuario usuario = (tbusuario)usuarioBusiness.GetElement(
                new tbusuario() { usu_id = idUsuarioSeleccionado });
            return usuario;
        }

        private void MensajeSeleccionarElemento()
        {
            MessageBox.Show("Debe Seleccionar un elemento de la lista",
                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private DialogResult MensajeEliminacionOK()
        {
            return MessageBox.Show("¿Desea eliminar el registro?",
                        "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void ControlarInstanciaAbierta(Form formularioPopUp, string textFormulario)
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

                            formularioPopUp.MdiParent = this.MdiParent;
                            formularioPopUp.WindowState = FormWindowState.Minimized;
                            formularioPopUp.Show();
                            formularioPopUp.WindowState = FormWindowState.Maximized;
                            formularioPopUp.Show();

                            //ActivateMdiChild(null);
                            //ActivateMdiChild(formularioPopUp);
                        }

                    }

                }
            }

        }

        //private void ControlarInstanciaAbierta(Form formularioPopUp)
        //{
        //    Assembly frmAssembly = Assembly.LoadFile(Application.ExecutablePath);
        //    string frmCode = formularioPopUp.Name;

        //    foreach (Type type in frmAssembly.GetTypes())
        //    {
        //        if (type.BaseType == typeof(Form))
        //        {
        //            if (type.Name == frmCode)
        //            {
        //                if (Application.OpenForms.Cast<Form>().Any(form => form.Name == frmCode))
        //                {
        //                    Form f = Application.OpenForms[frmCode];
        //                    f.WindowState = FormWindowState.Normal;
        //                    f.Activate();
        //                }
        //                else
        //                {
        //                    formularioPopUp.MdiParent = this.MdiParent;
        //                    formularioPopUp.WindowState = FormWindowState.Normal;
        //                    formularioPopUp.Show();
        //                }

        //            }

        //        }
        //    }

        //}

    }
}
