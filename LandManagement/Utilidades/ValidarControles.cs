using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace LandManagement.Utilidades
{
    /// <summary>
    /// Clase utilizada para validar los controles que son requeridos.
    /// Recordar agregar la siguiente linea en el Load() del formulario:
    ///     this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
    /// </summary>
    public class ValidarControles
    {

        public string ValidarControl(object _sender)
        {
            bool validacion = false;
            if(_sender is TextBox)
            {
                TextBox textBox = (TextBox)_sender;
                validacion = ValidarSiEsNulo(textBox);
            }

            if (_sender is ComboBox)
            {
                ComboBox comboBox = (ComboBox)_sender;
                validacion = ValidarSiEsNulo(comboBox);
            }

            if (_sender is MaskedTextBox)
            {
                MaskedTextBox maskedTextBox = (MaskedTextBox)_sender;
                validacion = ValidarSiEstaIncompleto(maskedTextBox);
            }

            if (validacion)
                return ConfigurationManager.AppSettings["ErrorValidacion"].ToString();

            return string.Empty;
        }

        public Control ObtenerControl(object _sender)
        { 
            Control control = null;
            if(_sender is TextBox)
            {
                TextBox textBox = (TextBox)_sender;
                control = textBox;
            }

            if (_sender is ComboBox)
            {
                ComboBox comboBox = (ComboBox)_sender;
                control = comboBox;
            }

            if (_sender is MaskedTextBox)
            {
                MaskedTextBox maskedTextBox = (MaskedTextBox)_sender;
                control = maskedTextBox;
            }
            
            return control;
        }

        private bool ValidarSiEsNulo(TextBox _textBox)
        {
            return string.IsNullOrEmpty(_textBox.Text);        
        }

        private bool ValidarSiEsNulo(ComboBox _comboBox)
        {
            if (_comboBox.SelectedItem == null)
                return true;
            return false;
        }

        private bool ValidarSiEstaIncompleto(MaskedTextBox _maskedTextBox)
        {
            if (ValidarSiEsNulo(_maskedTextBox))
                return true;

            return !_maskedTextBox.MaskCompleted;
        }

        private bool ValidarSiEsNulo(MaskedTextBox _maskedTextBox)
        {
            if (_maskedTextBox.Text.Replace("-", "").Replace(" ", "").Length == 0)
                return true;
            return false;
        }

    }
}
