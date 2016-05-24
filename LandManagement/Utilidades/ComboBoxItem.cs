using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandManagement.Utilidades
{
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public int? Value { get; set; }
        public static string DisplayMember = "Text";
        public static string ValueMember = "Value";

        public ComboBoxItem()
        {
        }

        public ComboBoxItem(string pText, int? pValue)
        {
            this.Text = pText;
            this.Value = pValue;
        }

    }
}
