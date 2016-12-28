using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessExcel;
using EntititesExcel;

namespace LandManagement
{
    public partial class frmImportarExcel : Form
    {
        public frmImportarExcel()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdExcel = new OpenFileDialog();
            ofdExcel.InitialDirectory = "C:\\Leo\\Temp\\";
            ofdExcel.Filter = "Archivos Excel (*.xlsx) | *.xlsx";

            if (ofdExcel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                if (!string.IsNullOrEmpty(ofdExcel.FileName))
                    txbPathArchivoExcel.Text = ofdExcel.FileName;        
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            ExcelBusiness excelBusiness = new ExcelBusiness(txbPathArchivoExcel.Text);
            List<PersonaExcel> listaPersonas = (List<PersonaExcel>)excelBusiness.RetornarRowExcel("BASE TOTAL DE CLIENTES CUMPLE");

            foreach (PersonaExcel persona in listaPersonas)
            {
                string nombre = persona.nombreCompleto;
            }
        }
    }
}
