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
    public partial class frmServicios : Form
    {
        private ServiciosBusiness servicioBusiness;
        private frmServiciosABM formularioservicioABM;
        private DataGridViewRow dataGridViewRow;
        private DisplayNameHelper displayNameHelper;
        public frmServicios()
        {
            InitializeComponent();
            servicioBusiness = new ServiciosBusiness();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmServicios_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            formularioservicioABM = new frmServiciosABM(this);
            ControlarInstanciaAbierta(formularioservicioABM);
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
            servicioBusiness = new ServiciosBusiness();
            dataGridViewServicios.Rows.Clear();

            //.Rows.Clear();
            dataGridViewServicios.Columns.Clear();
            string[] columnasGrilla = { "ser_id",
                                         "ser_descripcion",
                                       };

            int i = 0;
            foreach (string s in columnasGrilla)
            {
                PropertyInfo pi = typeof(tbservicios).GetProperty(s);
                displayNameHelper = new DisplayNameHelper();
                string columna = displayNameHelper.GetMetaDisplayName(pi);
                dataGridViewServicios.Columns.Add(s, columna);
                i++;
            }

            int indice;
            List<tbservicios> listaservicios = (List<tbservicios>)servicioBusiness.GetList();
            foreach (var obj in listaservicios)
            {
                indice = dataGridViewServicios.Rows.Add();
                dataGridViewRow = dataGridViewServicios.Rows[indice];
                dataGridViewRow.Cells["ser_id"].Value = obj.ser_id;
                dataGridViewRow.Cells["ser_descripcion"].Value = obj.ser_descripcion;

            }
        }

        private void dataGridViewServicios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tbservicios servicio = ObtenerServicioSeleccionado();

            formularioservicioABM = new frmServiciosABM(servicio, this);
            ControlarInstanciaAbierta(formularioservicioABM);
        }

        private tbservicios ObtenerServicioSeleccionado()
        {
            dataGridViewRow = dataGridViewServicios.SelectedRows[0];
            int idServicioSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["ser_id"].Value);

            tbservicios servicio = (tbservicios)servicioBusiness.GetElement(
                new tbservicios() { ser_id = idServicioSeleccionado });
            return servicio;


        }
        private void dataGridViewServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MensajeEliminacionOK() == System.Windows.Forms.DialogResult.Yes)
            {
                dataGridViewRow = dataGridViewServicios.SelectedRows[0];
                int iDServicioSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["ser_id"].Value);
                servicioBusiness.Delete(new tbservicios() { ser_id = iDServicioSeleccionado });
                this.CargarGrilla();
            }
        }
        private DialogResult MensajeEliminacionOK()
        {
            return MessageBox.Show("¿Desea eliminar el servicio?",
                        "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void dataGridViewServicios_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
