using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LandManagement.Entities;
using LandManagement.Business;
using LandManagement.Utilidades;

namespace LandManagement
{
    public partial class frmMenuABM : Form
    {
        private MenuBusiness menuBusiness;
        private List<tbmenu> listaMenu;
        private tbmenu menu;
        private ComboBoxItem comboBoxItem;
        private int idMenu = 0;
        private Form formPadre;
        private ValidarControles validarControles;
        public ErrorProvider errorProvider1 = new ErrorProvider();

        public frmMenuABM(Form formularioPadre)
        {
            InitializeComponent();
            menuBusiness = new MenuBusiness();
            //listaMenu = (List<tbmenu>)menuBusiness.GetList();
            listaMenu = (List<tbmenu>)menuBusiness.GetList();
            var lis = listaMenu.Where(x => x.men_nombre_formulario == null);

            cmbPadres.DisplayMember = ComboBoxItem.DisplayMember;
            cmbPadres.ValueMember = ComboBoxItem.ValueMember;

            if (listaMenu.Count != 0)
                //foreach (var obj in listaMenu)
                    foreach (var obj in lis)
                        cmbPadres.Items.Add(new ComboBoxItem(obj.men_nombre, obj.men_id));

            this.formPadre = formularioPadre;
        }

        public frmMenuABM(tbmenu pMenu, Form formularioPadre)
        {
            //men_nombre.DataBindings.Add("Text", new tbmenu(), "pMenu.men_id_padre");
            //men_nombre.BindingContext .Text( = tbmenu .DataBindings.Add("Text", new tbmenu(), "pMenu.men_id_padre");

            menuBusiness = new MenuBusiness();
            InitializeComponent();
            this.idMenu = pMenu.men_id;
            txbNombre.Text = pMenu.men_nombre;
            txbNombreFormulario.Text = pMenu.men_nombre_formulario;
            chbEstado.Checked = pMenu.men_estado;

            listaMenu = (List<tbmenu>)menuBusiness.GetList();
            var lis = listaMenu.Where(x => x.men_nombre_formulario == null);

            if (lis.Count() != 0)
                foreach (var obj in lis)
                    cmbPadres.Items.Add(new ComboBoxItem(obj.men_nombre, obj.men_id));

            //if (listaMenu.Count != 0)
            //    foreach (var obj in listaMenu)
            //        cmbPadres.Items.Add(new ComboBoxItem(obj.men_nombre, obj.men_id));

            cmbPadres.DisplayMember = ComboBoxItem.DisplayMember;
            cmbPadres.ValueMember = ComboBoxItem.ValueMember;

            if(string.IsNullOrEmpty(pMenu.men_nombre_formulario))
            {
                if (pMenu.men_id_padre == null)
                    rdbEsCabecera.Checked = true;
                else
                {
                    rdbEsPadre.Checked = true;
                    SeleccionarItemCombo(pMenu);
                }
            }
            else
            {
                rdbEsHijo.Checked = true;
                if (pMenu.men_id_padre != null)
                    SeleccionarItemCombo(pMenu);
            }

            btnGuardar.Click -= new EventHandler(btnGuardar_Click);
            btnGuardar.Click += new EventHandler(btnGuardarActualiza_Click);
            this.formPadre = formularioPadre;
            this.menu = pMenu;
            ValidarRadioButtons();
        }

        private void SeleccionarItemCombo(tbmenu pMenu)
        {
            tbmenu menuPadre = (tbmenu)menuBusiness.GetElement(
                new tbmenu() { men_id = pMenu.men_id_padre.Value });

            ComboBoxItem item = new ComboBoxItem(menuPadre.men_nombre, menuPadre.men_id);
            cmbPadres.SelectedIndex = cmbPadres.FindStringExact(item.Text);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                CargaObjetoMenu();
                GuardaObjetoMenu();
                MensajeOk();
                ((frmMenuListado)formPadre).CargarGrilla();
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void btnGuardarActualiza_Click(object sender, EventArgs e)
        {
            try
            {
                CargaObjetoMenu();
                GuardaObjetoMenu();
                MensajeOk();
                ((frmMenuListado)formPadre).CargarGrilla();
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnCanelar_Click(object sender, EventArgs e)
        {
            MensajeCancelar();
        }

        private void CargaObjetoMenu()
        {
            this.menu = new tbmenu();

            if (this.idMenu != 0)
                this.menu.men_id = this.idMenu;

            this.menu.men_nombre = txbNombre.Text;
            this.menu.men_estado = chbEstado.Checked;
            comboBoxItem = (ComboBoxItem)cmbPadres.SelectedItem;

            this.menu.men_nombre_formulario = txbNombreFormulario.Text;

            if (rdbEsCabecera.Checked)
            {
                this.menu.men_id_padre = null;
                this.menu.men_nombre_formulario = null;
            }
            else
            {
                this.menu.men_id_padre = comboBoxItem.Value;
                if (rdbEsHijo.Checked)
                    this.menu.men_nombre_formulario = txbNombreFormulario.Text;
                else
                    this.menu.men_nombre_formulario = null;
            }
        }

        private void GuardaObjetoMenu()
        {

            menuBusiness = new MenuBusiness();

            if (this.idMenu != 0)
                menuBusiness.Update(this.menu);
            else
                menuBusiness.Create(this.menu);
        }

        private void rdbEsPadre_CheckedChanged(object sender, EventArgs e)
        {
            ValidarRadioButtons();
        }

        private void rdbEsCabecera_CheckedChanged(object sender, EventArgs e)
        {
            ValidarRadioButtons();
        }

        private void rdbEsHijo_CheckedChanged(object sender, EventArgs e)
        {
            ValidarRadioButtons();
        }

        private void ValidarRadioButtons()
        {
            if (rdbEsPadre.Checked)
            {
                txbNombreFormulario.Enabled = false;
                cmbPadres.Enabled = true;
            }

            if (rdbEsCabecera.Checked)
            {
                txbNombreFormulario.Enabled = false;
                cmbPadres.SelectedIndex = -1;
                cmbPadres.Enabled = false;
            }
            if (rdbEsHijo.Checked)
            {
                txbNombreFormulario.Enabled = true;
                cmbPadres.Enabled = true;
            }

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
                // Stop the validation of any controls so the form can close.
                AutoValidate = AutoValidate.Disable;
                this.Close();
            }
        }

        #region Validacion de controles
        private void ValidatingControl(object sender, CancelEventArgs e)
        {
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            validarControles = new ValidarControles();
            Control control = validarControles.ObtenerControl(sender);
            string error = validarControles.ValidarControl(sender);

            if (!string.IsNullOrEmpty(error))
            {
                errorProvider1.SetError(control, error);

                //Me valida hasta ingresar el valor correcto
                e.Cancel = true;
                return;
            }

            errorProvider1.SetError(control, error);
        }

        public bool ValidEmailAddress(string emailAddress, out string errorMessage)
        {
            // Confirm that the e-mail address string is not empty.
            if (emailAddress.Length == 0)
            {
                errorMessage = "e-mail address is required.";
                return false;
            }

            // Confirm that there is an "@" and a "." in the e-mail address, and in the correct order.
            if (emailAddress.IndexOf("@") > -1)
            {
                if (emailAddress.IndexOf(".", emailAddress.IndexOf("@")) > emailAddress.IndexOf("@"))
                {
                    errorMessage = "";
                    return true;
                }
            }

            errorMessage = "e-mail address must be valid e-mail address format.\n" +
               "For example 'someone@example.com' ";
            return false;
        }
        #endregion
    }
}
