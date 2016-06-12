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
    public partial class frmTipoClienteABM : Form
    {
        //private TipoClienteBusiness tclienteBusiness;
        //private tbtipocliente tcliente;
        private int idTCliente = 0;
        private Form formPadre;
        public ErrorProvider errorProvider1 = new ErrorProvider();
        public frmTipoClienteABM(Form formularioPadre)
        {
            InitializeComponent();
            this.formPadre = formularioPadre;
        }

        public frmTipoClienteABM(tbsystipocliente tcliente, Form formularioPadre)
        {

            InitializeComponent();

            //tclienteBusiness = new TipoClienteBusiness();
            //this.idTCliente = tcliente.tic_id;
            //txbDescripcionTCliente.Text = tcliente.tic_descripcion;
            //this.formPadre = formularioPadre;

        }
        private void frmTipoClienteABM_Load(object sender, EventArgs e)
        {
            CargarBotones();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                CargaObjetoTCliente();
                GuardaObjetoTCliente();
                MensajeOk();
                ((frmTipoClienteListado)formPadre).CargarGrilla();
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CargarBotones()
        {
            //this.tcliente = new tbtipocliente();
            //if (this.idTCliente != 0)
            //{
            //    btnGuardar.Text = "Actualizar";
            //}
        }
        private void CargaObjetoTCliente()
        {
            //this.tcliente = new tbtipocliente();

            //if (this.idTCliente != 0)
            //    this.tcliente.tic_id = this.idTCliente;

            //tcliente.tic_descripcion = txbDescripcionTCliente.Text;
        }

        private void GuardaObjetoTCliente()
        {
            //tclienteBusiness = new TipoClienteBusiness();

            //if (this.idTCliente != 0)
            //    tclienteBusiness.Update(this.tcliente);
            //else
            //    tclienteBusiness.Create(this.tcliente);
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

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                CargaObjetoTCliente();
                GuardaObjetoTCliente();
                MensajeOk();
                ((frmTipoClienteListado)formPadre).CargarGrilla();
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
