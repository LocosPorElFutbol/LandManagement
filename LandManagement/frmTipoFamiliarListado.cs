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
    public partial class frmTipoFamiliarListado : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private frmTipoFamiliarABM frmtfamiliarABM;
        private DataGridViewRow dataGridViewRow;
        private DisplayNameHelper displayNameHelper;

        public frmTipoFamiliarListado()
        {
            InitializeComponent();
        }

        private void frmTipoFamiliar_Load(object sender, EventArgs e)
        {
            pnlControles.AutoScroll = true;
            CargarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmtfamiliarABM = new frmTipoFamiliarABM(this);
            ControlarInstanciaAbierta(frmtfamiliarABM);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MensajeEliminacionOK() == System.Windows.Forms.DialogResult.Yes)
                {
                    dataGridViewRow = dataGridViewTFamiliar.SelectedRows[0];
                    int idTFamiliarSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["tif_id"].Value);
                    TipoFamiliarBusiness tipoFamiliarBusiness = new TipoFamiliarBusiness();
                    tipoFamiliarBusiness.Delete(new tbtipofamiliar() { tif_id = idTFamiliarSeleccionado });
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

        #region Carga Grilla Tipo de Familiares
        public void CargarGrilla()
        {
            TipoFamiliarBusiness tipoFamiliarBusiness = new TipoFamiliarBusiness();
            dataGridViewTFamiliar.Rows.Clear();

            dataGridViewTFamiliar.Columns.Clear();
            string[] columnasGrilla = { "tif_id",
                                         "tif_descripcion",
                                       };

            int i = 0;
            foreach (string s in columnasGrilla)
            {
                PropertyInfo pi = typeof(tbtipofamiliar).GetProperty(s);
                displayNameHelper = new DisplayNameHelper();
                string columna = displayNameHelper.GetMetaDisplayName(pi);
                dataGridViewTFamiliar.Columns.Add(s, columna);
                i++;
            }

            int indice;
            List<tbtipofamiliar> listattfamiliar = (List<tbtipofamiliar>)tipoFamiliarBusiness.GetList();
            foreach (var obj in listattfamiliar)
            {
                indice = dataGridViewTFamiliar.Rows.Add();
                dataGridViewRow = dataGridViewTFamiliar.Rows[indice];
                dataGridViewRow.Cells["tif_id"].Value = obj.tif_id;
                dataGridViewRow.Cells["tif_descripcion"].Value = obj.tif_descripcion;

            }
        }

        private void dataGridViewTFamiliar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tbtipofamiliar tfamiliar = ObtenerTFamiliarSeleccionado();

            frmtfamiliarABM = new frmTipoFamiliarABM(tfamiliar, this);
            ControlarInstanciaAbierta(frmtfamiliarABM);
        }

        private tbtipofamiliar ObtenerTFamiliarSeleccionado()
        {
            TipoFamiliarBusiness tipoFamiliarBusiness = new TipoFamiliarBusiness();
            dataGridViewRow = dataGridViewTFamiliar.SelectedRows[0];
            int idTFamiliarSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["tif_id"].Value);

            tbtipofamiliar tfamiliar = (tbtipofamiliar)tipoFamiliarBusiness.GetElement(
                new tbtipofamiliar() { tif_id = idTFamiliarSeleccionado });
            return tfamiliar;
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
            return MessageBox.Show("¿Desea eliminar el tipo de familiar?",
                        "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}