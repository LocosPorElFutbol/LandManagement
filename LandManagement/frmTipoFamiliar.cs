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

namespace LandManagement
{
        public partial class frmTipoFamiliar : Form
    {
        private TipoFamiliarBusiness tfamiliarBusiness;
        private frmTipoFamiliarABM frmtfamiliarABM;
        private DataGridViewRow dataGridViewRow;
        private DisplayNameHelper displayNameHelper;

        public frmTipoFamiliar()
        {
            InitializeComponent();
            tfamiliarBusiness = new TipoFamiliarBusiness();
        }

        private void frmTipoFamiliar_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmtfamiliarABM = new frmTipoFamiliarABM(this);
            ControlarInstanciaAbierta(frmtfamiliarABM);
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
        public void CargarGrilla()
        {
            tfamiliarBusiness = new TipoFamiliarBusiness();
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
            List<tbtipofamiliar> listattfamiliar = (List<tbtipofamiliar>)tfamiliarBusiness.GetList();
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
            dataGridViewRow = dataGridViewTFamiliar.SelectedRows[0];
            int idTFamiliarSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["tif_id"].Value);

            tbtipofamiliar tfamiliar = (tbtipofamiliar)tfamiliarBusiness.GetElement(
                new tbtipofamiliar() { tif_id = idTFamiliarSeleccionado });
            return tfamiliar;


        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MensajeEliminacionOK() == System.Windows.Forms.DialogResult.Yes)
            {
                dataGridViewRow = dataGridViewTFamiliar.SelectedRows[0];
                int idTFamiliarSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["tif_id"].Value);
                tfamiliarBusiness.Delete(new tbtipofamiliar() { tif_id = idTFamiliarSeleccionado });
                this.CargarGrilla();
            }
        }
        private DialogResult MensajeEliminacionOK()
        {
            return MessageBox.Show("¿Desea eliminar el tipo de familiar?",
                        "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (MensajeEliminacionOK() == System.Windows.Forms.DialogResult.Yes)
            {
                dataGridViewRow = dataGridViewTFamiliar.SelectedRows[0];
                int idTFamiliarSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["tif_id"].Value);
                tfamiliarBusiness.Delete(new tbtipofamiliar() { tif_id = idTFamiliarSeleccionado });
                this.CargarGrilla();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}