﻿using System;
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
    public partial class frmTipoPropiedadListado : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private frmTipoPropiedadABM frmtpropiedadABM;
        private DataGridViewRow dataGridViewRow;
        private DisplayNameHelper displayNameHelper;

        public frmTipoPropiedadListado()
        {
            InitializeComponent();
        }

        private void frmTipoPropiedad_Load(object sender, EventArgs e)
        {
            pnlControles.AutoScroll = true;
            CargarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmtpropiedadABM = new frmTipoPropiedadABM(this);
            ControlarInstanciaAbierta(frmtpropiedadABM);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MensajeEliminacionOK() == System.Windows.Forms.DialogResult.Yes)
                {
                    dataGridViewRow = dataGridViewTpropiedad.SelectedRows[0];
                    int idTPropiedadSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["tip_id"].Value);
                    TipoPropiedadBusiness tipoPropiedadBusiness = new TipoPropiedadBusiness();
                    tipoPropiedadBusiness.Delete(new tbtipopropiedad() { tip_id = idTPropiedadSeleccionado });
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

        #region Cargar Grilla Tipos de Proiedades
        public void CargarGrilla()
        {
            TipoPropiedadBusiness tipoPropiedadBusiness = new TipoPropiedadBusiness();
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
            List<tbtipopropiedad> listatpropiedad = (List<tbtipopropiedad>)tipoPropiedadBusiness.GetList();
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

            TipoPropiedadBusiness tipoPropiedadBusiness = new TipoPropiedadBusiness();
            tbtipopropiedad tpropiedad = (tbtipopropiedad)tipoPropiedadBusiness.GetElement(
                new tbtipopropiedad() { tip_id = idTPropiedadSeleccionado });
            return tpropiedad;


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
            return MessageBox.Show("¿Desea eliminar el tipo de propiedad?",
                        "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

    }
}

