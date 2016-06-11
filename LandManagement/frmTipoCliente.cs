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
    public partial class frmTipoCliente : Form
    {
        private frmTipoClienteABM frmtclienteABM;

        public frmTipoCliente()
        {
            InitializeComponent();
        }

        private void frmTipoCliente_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmtclienteABM = new frmTipoClienteABM(this);
            ControlarInstanciaAbierta(frmtclienteABM);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
  //          //tclienteBusiness = new TipoClienteBusiness();
  //          dataGridViewTCliente.Rows.Clear();
  //          dataGridViewTCliente.Columns.Clear();
  //          string[] columnasGrilla = { "tic_id",
  //                                       "tic_descripcion",
  //                                     };

  //          int i = 0;
  //          foreach (string s in columnasGrilla)
  //          {
  //            //  PropertyInfo pi = typeof(tbtipocliente).GetProperty(s);
  //              displayNameHelper = new DisplayNameHelper();
  ////              string columna = displayNameHelper.GetMetaDisplayName(pi);
  //              dataGridViewTCliente.Columns.Add(s, columna);
  //              i++;
//            }

            //int indice;
//            List<tbtipocliente> listatcliente = (List<tbtipocliente>)tclienteBusiness.GetList();
            //foreach (var obj in listatcliente)
            //{
            //    indice = dataGridViewTCliente.Rows.Add();
            //    dataGridViewRow = dataGridViewTCliente.Rows[indice];
            //    dataGridViewRow.Cells["tic_id"].Value = obj.tic_id;
            //    dataGridViewRow.Cells["tic_descripcion"].Value = obj.tic_descripcion;

            //}
        }

        private void dataGridViewTCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //tbtipocliente tcliente = ObtenerTClienteSeleccionado();
       

            //frmtclienteABM = new frmTipoClienteABM(tcliente, this);
            //ControlarInstanciaAbierta(frmtclienteABM);
        }

        //private tbtipocliente ObtenerTClienteSeleccionado()
        //{
        //    dataGridViewRow = dataGridViewTCliente.SelectedRows[0];
        //    int idTClienteSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["tic_id"].Value);

        //    tbtipocliente tcliente = (tbtipocliente)tclienteBusiness.GetElement(
        //        new tbtipocliente() { tic_id = idTClienteSeleccionado });
        //    return tcliente;


        //}


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //if (MensajeEliminacionOK() == System.Windows.Forms.DialogResult.Yes)
            //{
            //    dataGridViewRow = dataGridViewTCliente.SelectedRows[0];
            //    int idTClienteSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["tic_id"].Value);
            //    tclienteBusiness.Delete(new tbtipocliente() { tic_id = idTClienteSeleccionado });
            //    this.CargarGrilla();
            //}
        }
        private DialogResult MensajeEliminacionOK()
        {
            return MessageBox.Show("¿Desea eliminar el tipo de cliente?",
                        "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            //if (MensajeEliminacionOK() == System.Windows.Forms.DialogResult.Yes)
            //{
            //    dataGridViewRow = dataGridViewTCliente.SelectedRows[0];
            //    int idTClienteSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["tic_id"].Value);
            //    tclienteBusiness.Delete(new tbtipocliente() { tic_id = idTClienteSeleccionado });
            //    this.CargarGrilla();
            //}
        }

    }
}


