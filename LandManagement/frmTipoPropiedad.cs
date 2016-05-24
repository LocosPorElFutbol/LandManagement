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
    public partial class frmTipoPropiedad : Form
    {
        private TipoPropiedadBusiness tpropiedadBusiness;
        private frmTipoPropiedadABM frmtpropiedadABM;
        private DataGridViewRow dataGridViewRow;
        private DisplayNameHelper displayNameHelper;
        public frmTipoPropiedad()
        {
            InitializeComponent();
            tpropiedadBusiness = new TipoPropiedadBusiness();
        }

        private void frmTipoPropiedad_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }
 

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmtpropiedadABM = new frmTipoPropiedadABM(this);
            ControlarInstanciaAbierta(frmtpropiedadABM);
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
            tpropiedadBusiness = new TipoPropiedadBusiness();
            dataGridViewTpropiedad.Rows.Clear();

            //.Rows.Clear();
            dataGridViewTpropiedad.Columns.Clear();
            string[] columnasGrilla = { "tip_id",
                                         "tip_descripcion",
                                       };

            int i = 0;
            foreach (string s in columnasGrilla)
            {
                PropertyInfo pi = typeof(tbtipopropiedad).GetProperty(s);
                displayNameHelper = new DisplayNameHelper();
                string columna = displayNameHelper.GetMetaDisplayName(pi);
                dataGridViewTpropiedad.Columns.Add(s, columna);
                i++;
            }

            int indice;
            List<tbtipopropiedad> listatpropiedad = (List<tbtipopropiedad>)tpropiedadBusiness.GetList();
            foreach (var obj in listatpropiedad)
            {
                indice = dataGridViewTpropiedad.Rows.Add();
                dataGridViewRow = dataGridViewTpropiedad.Rows[indice];
                dataGridViewRow.Cells["tip_id"].Value = obj.tip_id;
                dataGridViewRow.Cells["tip_descripcion"].Value = obj.tip_descripcion;

            }
        }

        private void dataGridViewTpropiedad_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tbtipopropiedad tpropiedad = ObtenerTPropiedadSeleccionado();


            frmtpropiedadABM = new frmTipoPropiedadABM(tpropiedad, this);
            ControlarInstanciaAbierta(frmtpropiedadABM);
        }

        private tbtipopropiedad ObtenerTPropiedadSeleccionado()
        {
            dataGridViewRow = dataGridViewTpropiedad.SelectedRows[0];
            int idTPropiedadSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["tip_id"].Value);

            tbtipopropiedad tpropiedad = (tbtipopropiedad)tpropiedadBusiness.GetElement(
                new tbtipopropiedad() { tip_id = idTPropiedadSeleccionado });
            return tpropiedad;


        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MensajeEliminacionOK() == System.Windows.Forms.DialogResult.Yes)
            {
                dataGridViewRow = dataGridViewTpropiedad.SelectedRows[0];
                int idTPropiedadSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["tip_id"].Value);
                tpropiedadBusiness.Delete(new tbtipopropiedad() { tip_id = idTPropiedadSeleccionado });
                this.CargarGrilla();
            }
        }
        private DialogResult MensajeEliminacionOK()
        {
            return MessageBox.Show("¿Desea eliminar el tipo de propiedad?",
                        "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            frmtpropiedadABM = new frmTipoPropiedadABM(this);
            ControlarInstanciaAbierta(frmtpropiedadABM);
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (MensajeEliminacionOK() == System.Windows.Forms.DialogResult.Yes)
            {
                dataGridViewRow = dataGridViewTpropiedad.SelectedRows[0];
                int idTPropiedadSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["tip_id"].Value);
                tpropiedadBusiness.Delete(new tbtipopropiedad() { tip_id = idTPropiedadSeleccionado });
                this.CargarGrilla();
            }
        }

    }
}

