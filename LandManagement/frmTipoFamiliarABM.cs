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
    public partial class frmTipoFamiliarABM : Form
    {
        private TipoFamiliarBusiness tfamiliarBusiness;
        private tbtipofamiliar tfamiliar;
        private int idTFamiliar = 0;
        private Form formPadre;
        public ErrorProvider errorProvider1 = new ErrorProvider();
        public frmTipoFamiliarABM(Form formularioPadre)
        {
            InitializeComponent();
            this.formPadre = formularioPadre;
        }

        public frmTipoFamiliarABM(tbtipofamiliar tFamiliar, Form formularioPadre)
        {

            InitializeComponent();

            tfamiliarBusiness = new TipoFamiliarBusiness();
            this.idTFamiliar = tFamiliar.tif_id;
            txbDescripcionTFamiliar.Text = tFamiliar.tif_descripcion;
            this.formPadre = formularioPadre;

        }

        private void frmTipoFamiliarABM_Load(object sender, EventArgs e)
        {
            CargarBotones();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                CargaObjetoTFamiliar();
                GuardaObjetoTFamiliar();
                MensajeOk();
                ((frmTipoFamiliar)formPadre).CargarGrilla();
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CargarBotones()
        {
            this.tfamiliar = new tbtipofamiliar();
            if (this.idTFamiliar != 0)
            {
                btnGuardar.Text = "Actualizar";
            }
        }
        private void CargaObjetoTFamiliar()
        {
            this.tfamiliar = new tbtipofamiliar();

            if (this.idTFamiliar != 0)
                this.tfamiliar.tif_id = this.idTFamiliar;

            tfamiliar.tif_descripcion = txbDescripcionTFamiliar.Text;
        }

        private void GuardaObjetoTFamiliar()
        {
            tfamiliarBusiness = new TipoFamiliarBusiness();

            if (this.idTFamiliar != 0)
                tfamiliarBusiness.Update(this.tfamiliar);
            else
                tfamiliarBusiness.Create(this.tfamiliar);
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
                CargaObjetoTFamiliar();
                GuardaObjetoTFamiliar();
                MensajeOk();
                ((frmTipoFamiliar)formPadre).CargarGrilla();
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MensajeCancelar();
        }
    }
}
