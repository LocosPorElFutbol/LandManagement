using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LandManagement.Business;
using LandManagement.Entities;

namespace LandManagement
{
    public partial class frmServiciosABM : Form
    {
        private ServiciosBusiness serviciosBusiness;
        private tbservicios servicio;
        private int idServicio = 0;
        private Form formPadre;
        public ErrorProvider errorProvider1 = new ErrorProvider();
        public frmServiciosABM(Form formularioPadre)
        {
            InitializeComponent();
            this.formPadre = formularioPadre;
        }

        public frmServiciosABM(tbservicios pServicio, Form formularioPadre)
        {

            InitializeComponent();

            serviciosBusiness = new ServiciosBusiness();
            this.idServicio = pServicio.ser_id;
            txbDescripcionServicio.Text = pServicio.ser_descripcion;
            this.formPadre = formularioPadre;

        }
        private void txbNombreUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmServiciosABM_Load(object sender, EventArgs e)
        {
            pnlControles.AutoScroll = true;
            CargarBotones();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                CargaObjetoServicio();
                GuardaObjetoServicio();
                MensajeOk();
                ((frmServicios)formPadre).CargarGrilla();
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CargarBotones()
        {
            this.servicio = new tbservicios();
            if (this.idServicio != 0)
            {
                btnGuardar.Text = "Actualizar";
            }
        }
        private void CargaObjetoServicio()
        {
            this.servicio = new tbservicios();

            if (this.idServicio != 0)
                this.servicio.ser_id = this.idServicio;

            servicio.ser_descripcion = txbDescripcionServicio.Text;
        }

        private void GuardaObjetoServicio()
        {
            serviciosBusiness = new ServiciosBusiness();

            if (this.idServicio != 0)
                serviciosBusiness.Update(this.servicio);
            else
                serviciosBusiness.Create(this.servicio);
        }
        private void MensajeOk()
        {
            MessageBox.Show("El registro se guardo correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeCancelar()
        {
            DialogResult dialogResult = DialogResult.None;

            dialogResult = MessageBox.Show("Se aplicaron cambios. Se perderán todos los datos que no hayan sido guardados. \n¿Desea cerrar la ventana?",
                "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                AutoValidate = AutoValidate.Disable;
                this.Close();
            }
        }

        private void frmServiciosABM_Load_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
