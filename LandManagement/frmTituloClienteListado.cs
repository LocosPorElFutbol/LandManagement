using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using LandManagement.Business;
using LandManagement.Entities;
using LandManagement.Utilidades;
using log4net;

namespace LandManagement
{
    public partial class frmTituloClienteListado : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private frmTituloClienteABM frmTituloClienteABM;
        private DataGridViewRow dataGridViewRow;
        private DisplayNameHelper displayNameHelper;

        public frmTituloClienteListado()
        {
            InitializeComponent();
        }

        private void frmTituloClienteListado_Load(object sender, EventArgs e)
        {
            pnlControles.AutoScroll = true;
            CargarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.frmTituloClienteABM = new frmTituloClienteABM(this);
            ControlarInstanciaAbierta(this.frmTituloClienteABM);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MensajeEliminacionOK() == System.Windows.Forms.DialogResult.Yes)
                {
                    dataGridViewRow = dataGridViewTituloCliente.SelectedRows[0];
                    int idTituloClienteSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["tcl_id"].Value);
                    TituloClienteBusiness tituloClienteBusiness = new TituloClienteBusiness();
                    tituloClienteBusiness.Delete(new tbtitulocliente() { tcl_id = idTituloClienteSeleccionado });
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

        #region Carga Grilla Titulo de Clientes
        public void CargarGrilla()
        {
            TituloClienteBusiness tituloClienteBusiness = new TituloClienteBusiness();
            dataGridViewTituloCliente.Rows.Clear();

            dataGridViewTituloCliente.Columns.Clear();
            string[] columnasGrilla = { "tcl_id",
                                         "tcl_descripcion",
                                       };

            int i = 0;
            foreach (string s in columnasGrilla)
            {
                PropertyInfo pi = typeof(tbtitulocliente).GetProperty(s);
                displayNameHelper = new DisplayNameHelper();
                string columna = displayNameHelper.GetMetaDisplayName(pi);
                dataGridViewTituloCliente.Columns.Add(s, columna);
                i++;
            }

            int indice;
            List<tbtitulocliente> listaTituloCliente = (List<tbtitulocliente>)tituloClienteBusiness.GetList();
            foreach (var obj in listaTituloCliente)
            {
                indice = dataGridViewTituloCliente.Rows.Add();
                dataGridViewRow = dataGridViewTituloCliente.Rows[indice];
                dataGridViewRow.Cells["tcl_id"].Value = obj.tcl_id;
                dataGridViewRow.Cells["tcl_descripcion"].Value = obj.tcl_descripcion;

            }
        }

        private void dataGridViewTituloCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tbtitulocliente tituloCliente = ObtenerTituloClienteSeleccionado();

            frmTituloClienteABM = new frmTituloClienteABM(tituloCliente, this);
            ControlarInstanciaAbierta(frmTituloClienteABM);
        }

        private tbtitulocliente ObtenerTituloClienteSeleccionado()
        {
            TituloClienteBusiness tituloClienteBusiness = new TituloClienteBusiness();
            dataGridViewRow = dataGridViewTituloCliente.SelectedRows[0];
            int idTituloClienteSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["tcl_id"].Value);

            tbtitulocliente tituloCliente = (tbtitulocliente)tituloClienteBusiness.GetElement(
                new tbtitulocliente() { tcl_id = idTituloClienteSeleccionado });
            return tituloCliente;
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
            return MessageBox.Show("¿Desea eliminar este registro?",
                        "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
