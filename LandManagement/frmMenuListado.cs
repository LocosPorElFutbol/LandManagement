using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LandManagement.Entities;
using LandManagement.Business;
using System.Reflection;
using LandManagement.Utilidades;

namespace LandManagement
{
    public partial class frmMenuListado : Form
    {
        private frmMenuABM formularioMenuABM;
        private DataGridViewRow dataGridViewRow;
        private DisplayNameHelper displayNameHelper;

        public frmMenuListado()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            pnlControles.AutoScroll = true;
            CargarGrilla();
        }

        public void CargarGrilla()
        {
            //Funciona OK, tratar de modiricarlo al datasource
            //menuBusiness = new MenuBusiness();
            //dgvMenu.DataSource = menuBusiness.GetList();

            dgvMenu.Rows.Clear();
            dgvMenu.Columns.Clear();
            string[] columnasGrilla = { "men_id", 
                                        "men_id_padre", 
                                        "men_nombre", 
                                        "men_nombre_formulario", 
                                        "men_estado" };

            int i = 0;
            foreach (string s in columnasGrilla)
            {
                PropertyInfo pi = typeof(tbmenu).GetProperty(s);
                displayNameHelper = new DisplayNameHelper();
                string columna = displayNameHelper.GetMetaDisplayName(pi);
                dgvMenu.Columns.Add(s, columna);
                i++;
            }

            CargarDataGridViewLista();
        }

        private void CargarDataGridViewLista()
        {
            MenuBusiness menuBusiness = new MenuBusiness();
            List<tbmenu> listaMenu = (List<tbmenu>)menuBusiness.GetList();
            CargarDataGridView(listaMenu);
        }

        private void CargarDataGridView(List<tbmenu> listaMenu)
        {
            dgvMenu.Rows.Clear();
            int indice;
            foreach (var obj in listaMenu)
            {
                tbmenu padre = new tbmenu() { men_nombre = string.Empty };

                MenuBusiness menuBusiness = new MenuBusiness();
                if (obj.men_id_padre != null)
                    padre = (tbmenu)menuBusiness.GetElement(new tbmenu() { men_id = obj.men_id_padre.Value });

                indice = dgvMenu.Rows.Add();
                //DataGridViewRow dataGridViewRow = dgvMenu.Rows[indice];
                dataGridViewRow = dgvMenu.Rows[indice];
                dataGridViewRow.Cells["men_id"].Value = obj.men_id;
                dataGridViewRow.Cells["men_id_padre"].Value = padre.men_nombre;
                dataGridViewRow.Cells["men_nombre"].Value = obj.men_nombre;
                dataGridViewRow.Cells["men_nombre_formulario"].Value = obj.men_nombre_formulario;
                dataGridViewRow.Cells["men_estado"].Value = obj.men_estado;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            formularioMenuABM = new frmMenuABM(this);
            ControlarInstanciaAbierta(formularioMenuABM);
        }

        private void dgvMenu_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewRow = dgvMenu.SelectedRows[0];
            int idMenuSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["men_id"].Value);
            MenuBusiness menuBusiness = new MenuBusiness();
            tbmenu menu = (tbmenu)menuBusiness.GetElement(new tbmenu() { men_id = idMenuSeleccionado });
            
            formularioMenuABM = new frmMenuABM(menu, this);
            ControlarInstanciaAbierta(formularioMenuABM);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MensajeEliminacionOK() == System.Windows.Forms.DialogResult.Yes)
            {
                dataGridViewRow = dgvMenu.SelectedRows[0];
                int idMenuSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["men_id"].Value);
                MenuBusiness menuBusiness = new MenuBusiness();
                menuBusiness.Delete(new tbmenu() { men_id = idMenuSeleccionado });
                this.CargarGrilla();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Herramienta de Búsqueda

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<string> listaExcluir = new List<string>() { "men_id", "men_id_padre", "men_nombre_formulario", "men_estado" };
            BuscarEnDataGridView buscar = new BuscarEnDataGridView();

            MenuBusiness menuBusiness = new MenuBusiness();
            List<tbmenu> listaFiltrada = (List<tbmenu>)menuBusiness.GetList();
            listaFiltrada = buscar.FiltrarDataGrid(listaFiltrada, listaExcluir, txbBuscarPor.Text);
            CargarDataGridView(listaFiltrada);
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            CargarDataGridViewLista();
        }

        #endregion

        private DialogResult MensajeEliminacionOK()
        {
            return MessageBox.Show("¿Desea eliminar el registro?", 
                        "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void ControlarInstanciaAbierta(Form formularioPopUp)
        {
            Assembly frmAssembly = Assembly.LoadFile(Application.ExecutablePath);
            string frmCode = formularioPopUp.Name;

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
                            f.Activate();
                        }
                        else
                        {
                            formularioPopUp.MdiParent = this.MdiParent;
                            formularioPopUp.WindowState = FormWindowState.Normal;
                            formularioPopUp.Show();
                        }

                    }

                }
            }

        }

    }
}
