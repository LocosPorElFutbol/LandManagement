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
using LandManagement.Utilidades;
using LandManagement.Business;
using log4net;

namespace LandManagement
{
    public partial class frmCategoriaClienteListado : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private frmCategoriaClienteABM frmCategoriaClienteABM;
        private DataGridViewRow dataGridViewRow;
        private DisplayNameHelper displayNameHelper;

        public frmCategoriaClienteListado()
        {
            InitializeComponent();
        }

        private void frmCategoriaClienteListado_Load(object sender, EventArgs e)
        {
            pnlControles.AutoScroll = true;
            CargarGrilla();
        }
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmCategoriaClienteABM = new frmCategoriaClienteABM(this);
            ControlarInstanciaAbierta(frmCategoriaClienteABM);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MensajeEliminacionOK() == System.Windows.Forms.DialogResult.Yes)
                {
                    dataGridViewRow = dataGridViewCategoriaCliente.SelectedRows[0];
                    int idCategoriaClienteSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["ccl_id"].Value);
                    CategoriaClienteBusiness categoriaClienteBusiness = new CategoriaClienteBusiness();
                    categoriaClienteBusiness.Delete(new tbcategoriacliente() { ccl_id = idCategoriaClienteSeleccionado });
                    this.CargarGrilla();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al eliminar registro. Existe una referencia hacia este registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Carga Grilla Categoria Cliente
        public void CargarGrilla()
        {
            CategoriaClienteBusiness categoriaClienteBusiness = new CategoriaClienteBusiness();
            dataGridViewCategoriaCliente.Rows.Clear();

            dataGridViewCategoriaCliente.Columns.Clear();
            string[] columnasGrilla = { "ccl_id",
                                         "ccl_descripcion",
                                       };

            int i = 0;
            foreach (string s in columnasGrilla)
            {
                PropertyInfo pi = typeof(tbcategoriacliente).GetProperty(s);
                displayNameHelper = new DisplayNameHelper();
                string columna = displayNameHelper.GetMetaDisplayName(pi);
                dataGridViewCategoriaCliente.Columns.Add(s, columna);
                i++;
            }

            int indice;
            List<tbcategoriacliente> listaCategoriaCliente = (List<tbcategoriacliente>)categoriaClienteBusiness.GetList();
            foreach (var obj in listaCategoriaCliente)
            {
                indice = dataGridViewCategoriaCliente.Rows.Add();
                dataGridViewRow = dataGridViewCategoriaCliente.Rows[indice];
                dataGridViewRow.Cells["ccl_id"].Value = obj.ccl_id;
                dataGridViewRow.Cells["ccl_descripcion"].Value = obj.ccl_descripcion;

            }
        }

        private void dataGridViewCategoriaCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tbcategoriacliente categoriaCliente = ObtenerCategoriaClienteSeleccionado();

            frmCategoriaClienteABM = new frmCategoriaClienteABM(categoriaCliente, this);
            ControlarInstanciaAbierta(frmCategoriaClienteABM);
        }

        private tbcategoriacliente ObtenerCategoriaClienteSeleccionado()
        {
            CategoriaClienteBusiness categoriaClienteBusiness = new CategoriaClienteBusiness();
            dataGridViewRow = dataGridViewCategoriaCliente.SelectedRows[0];
            int idCategoriaClienteSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["ccl_id"].Value);

            tbcategoriacliente categoriaCliente = (tbcategoriacliente)categoriaClienteBusiness.GetElement(
                new tbcategoriacliente() { ccl_id = idCategoriaClienteSeleccionado });
            return categoriaCliente;
        }
        #endregion

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
 
        private DialogResult MensajeEliminacionOK()
        {
            return MessageBox.Show("¿Desea eliminar este registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }


    }
}


