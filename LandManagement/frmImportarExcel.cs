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
using LandManagement.Entities;

namespace LandManagement
{
    public partial class frmImportarExcel : Form
    {
        private BackgroundWorker backgroundWorker = new BackgroundWorker();
        public frmImportarExcel()
        {
            InitializeComponent();
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.WorkerReportsProgress = true;
        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Termino OK");
        }

        void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prbImportarExcel.Value = e.ProgressPercentage;
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<PersonaExcel> listaPersonas = (List<PersonaExcel>)e.Argument;
            var backgroundWorker = sender as BackgroundWorker;

            //Laburala
            tbcliente cliente;
            foreach (PersonaExcel persona in listaPersonas)
            {
                cliente = CargarDatosCliente(persona);
                string nombre = persona.nombreCompleto;
            }

            //for (int j = 0; j < 100; j++)
            //{
            //    System.Threading.Thread.Sleep(50);
            //    backgroundWorker.ReportProgress(j);
            //}
        }

        public tbcliente CargarDatosCliente(PersonaExcel persona)
        {
            tbcliente cliente = new tbcliente()
            {
                //Cargo datos del titular
                cli_id = persona.id,
                cli_fecha = DateTime.Parse(persona.fechaDeIngreso.ToString()),
                cli_actualizado = DateTime.Parse(persona.actualizado.ToString()),
                cli_titulo = persona.titulo,
                cli_apellido = persona.apellido,
                cli_nombre_pila = persona.nombreDePila,
                cli_nombre = persona.nombreCompleto,
                cli_imprime_carta = persona.imprimeCarta,
                cli_estado_actual = persona.estadoActual,
                cli_telefono_celular = persona.celular,
                cli_telefono_particular = persona.telParticular,
                cli_email = persona.email,
                cli_fecha_nacimiento = DateTime.Parse(persona.nacimiento.ToString()),
                cli_nacionalidad = persona.nacionalidad,
                cli_numero_documento = persona.dniTitular,
                cli_cuit_cuil = persona.cuitCuilTitular,
                cli_estado_civil = persona.estadoCivil,
                cli_como_llego = persona.observaciones
            };

            //Cargo datos del domicilio
            tbdomicilio domicilio = new tbdomicilio()
            {
                dom_domicilio_importado = persona.domicilio,
                dom_codigo_postal = persona.codigoPostal.ToString(),
                dom_localidad = persona.localidad
            };
            cliente.tbdomicilio.Add(domicilio);

            //Cargo datos del conyuge
            tbcliente conyuje = new tbcliente() 
            {
                cli_apellido = persona.apellidoConyuge,
                cli_nombre_pila = persona.nombrePilaConyuge,
                cli_nombre = persona.nombreCompletoConyuge,
                cli_numero_documento = persona.dniConyuge,
                cli_cuit_cuil = persona.cuitCuilConyuge,
                cli_fecha_nacimiento = DateTime.Parse(persona.nacimientoConyuge.ToString()),
                cli_nacionalidad = persona.nacionalidadConyuge,
                cli_telefono_celular = persona.celularConyuge,
                cli_email = persona.mailConyuge
            };
            cliente.tbcliente1.Add(conyuje);

            return cliente;
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

            prbImportarExcel.Maximum = listaPersonas.Count;
            prbImportarExcel.Step = 1;
            prbImportarExcel.Value = 0;
            backgroundWorker.RunWorkerAsync(listaPersonas);
        }
    }
}
