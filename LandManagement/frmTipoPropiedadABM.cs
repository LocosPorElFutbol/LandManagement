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
    public partial class frmTipoPropiedadABM : Form
    {
        private TipoPropiedadBusiness tpropiedadBusiness;
        private tbtipopropiedad tpropiedad;
        private int idTPropiedad = 0;
        private Form formPadre;
        public ErrorProvider errorProvider1 = new ErrorProvider();
        public frmTipoPropiedadABM(Form formularioPadre)
        {
            InitializeComponent();
            this.formPadre = formularioPadre;
        }

        public frmTipoPropiedadABM(tbtipopropiedad tpropiedad, Form formularioPadre)
        {

            InitializeComponent();

            tpropiedadBusiness = new TipoPropiedadBusiness();
            this.idTPropiedad = tpropiedad.tip_id;
            txbDescripcionTPropiedad.Text = tpropiedad.tip_descripcion;
            this.formPadre = formularioPadre;

        }
        private void txbNombreUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmTipoPropiedadABM_Load(object sender, EventArgs e)
        {
            CargarBotones();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                CargaObjetoTPropiedad();
                GuardaObjetoTPropiedad();
                MensajeOk();
                ((frmTipoPropiedad)formPadre).CargarGrilla();
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CargarBotones()
        {
            this.tpropiedad = new tbtipopropiedad();
            if (this.idTPropiedad != 0)
            {
                btnGuardar.Text = "Actualizar";
            }
        }
        private void CargaObjetoTPropiedad()
        {
            this.tpropiedad = new tbtipopropiedad();

            if (this.idTPropiedad != 0)
                this.tpropiedad.tip_id = this.idTPropiedad;

            tpropiedad.tip_descripcion = txbDescripcionTPropiedad.Text;
        }

        private void GuardaObjetoTPropiedad()
        {
            tpropiedadBusiness = new TipoPropiedadBusiness();

            if (this.idTPropiedad != 0)
                tpropiedadBusiness.Update(this.tpropiedad);
            else
                tpropiedadBusiness.Create(this.tpropiedad);
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
                CargaObjetoTPropiedad();
                GuardaObjetoTPropiedad();
                MensajeOk();
                ((frmTipoPropiedad)formPadre).CargarGrilla();
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

