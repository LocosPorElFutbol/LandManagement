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
using LandManagement.Utilidades;
using log4net;

namespace LandManagement
{
    public partial class frmImportarExcel : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ErrorProvider errorProvider1 = new ErrorProvider();
        private ValidarControles validarControles;

        public frmImportarExcel()
        {
            InitializeComponent();
        }

        private void frmImportarExcel_Load(object sender, EventArgs e)
        {
            pnlControles.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdExcel = new OpenFileDialog();
            ofdExcel.InitialDirectory = "C:\\Leo\\Temp";
            ofdExcel.Filter = "Archivos Excel (*.xlsx) | *.xlsx";

            if (ofdExcel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                if (!string.IsNullOrEmpty(ofdExcel.FileName))
                    txbPathArchivoExcel.Text = ofdExcel.FileName;
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (this.ValidateChildren())
                {
                    prbImportarExcel.Visible = true;
                    ExcelBusiness excelBusiness = new ExcelBusiness(txbPathArchivoExcel.Text);
                    List<PersonaExcel> listaPersonas = (List<PersonaExcel>)excelBusiness.RetornarRowExcel(txbNombreHoja.Text);

                    //Seteo parametros del progressbar y creo el thread
                    prbImportarExcel.Value = 0;
                    prbImportarExcel.Maximum = listaPersonas.Count;
                    prbImportarExcel.Step = 1;

                    if (ImportarFilas(listaPersonas))
                        ImportacionOK();
                    else
                        ImportacionError("Se produjo un error en la importación de datos.");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                ImportacionError("Error al cargar archivo excel, corrobore no tener el archivo abierto y \nque los datos en las columnas sean los correctos.");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool ImportarFilas(List<PersonaExcel> listaPersonas)
        {
            bool resultado = false;
            try
            {
                int porcentajeBarra = 0;

                tbcliente cliente;
                foreach (PersonaExcel persona in listaPersonas)
                {
                    cliente = CargarDatosCliente(persona);
                    prbImportarExcel.Value = porcentajeBarra++;
                }
                resultado = true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                ImportacionError("Error al crear los objetos cliente. \nControle las columnas del archivo excel");
            }

            return resultado;
        }

        #region Cargar Datos del Cliente
        public tbcliente CargarDatosCliente(PersonaExcel persona)
        {
            tbcliente cliente = null;
            
            try
            {
                cliente = new tbcliente()
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

                CargarDomicilio(persona, cliente);

                if (!string.IsNullOrEmpty(persona.apellidoConyuge) &&
                   !string.IsNullOrEmpty(persona.nombreDePila) &&
                   !string.IsNullOrEmpty(persona.dniConyuge) &&
                   !string.IsNullOrEmpty(persona.cuitCuilConyuge) &&
                   !!string.IsNullOrEmpty(persona.nacionalidadConyuge) &&
                   !!string.IsNullOrEmpty(persona.mailConyuge))
                    CargarConyuge(persona, cliente);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                ImportacionError("Error al crear objeto cliente. \nCorrobore los datos y tipos de datos en las columnas");
            }

            return cliente;
        }

        private static void CargarDomicilio(PersonaExcel persona, tbcliente cliente)
        {
            //Cargo datos del domicilio
            tbdomicilio domicilio = new tbdomicilio()
            {
                dom_domicilio_importado = persona.domicilio,
                dom_codigo_postal = persona.codigoPostal.ToString(),
                dom_localidad = persona.localidad
            };
            cliente.tbdomicilio.Add(domicilio);
        }

        private static void CargarConyuge(PersonaExcel persona, tbcliente cliente)
        {
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
        }
        #endregion

        #region Validacion de controles
        private void CampoRequerido(object sender, CancelEventArgs e)
        {
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            validarControles = new ValidarControles();
            Control control = validarControles.ObtenerControl(sender);
            string error = validarControles.ValidarControl(sender);

            //Ingresa al if cuando error tiene un valor 
            //(es el mensaje de error que se va a mostrar)
            if (!string.IsNullOrEmpty(error))
            {
                errorProvider1.SetError(control, error);

                //Me valida hasta ingresar el valor correcto
                e.Cancel = true;
                return;
            }

            //error es nulo
            errorProvider1.SetError(control, error);
        }
        #endregion

        #region Mensajes
        void ImportacionOK()
        {
            int cantidadDeRegistros = prbImportarExcel.Maximum;
            lblResultado.Visible = true;
            btnAceptar.Visible = true;
            lblResultado.Text = "Se importaron correctamente " + cantidadDeRegistros.ToString() + " registros";
            lblResultado.ForeColor = Color.Green;
        }

        void ImportacionError(string mensaje)
        {
            lblResultado.Visible = true;
            lblResultado.Text = mensaje;
            lblResultado.ForeColor = Color.Red;
        }
        #endregion
    }
}
