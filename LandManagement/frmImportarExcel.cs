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
using LandManagement.Business;
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
            ofdExcel.InitialDirectory = "C:\\";
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
                    lblResultado.Text = string.Empty;
                    btnImportar.Enabled = false;
                    btnCargar.Enabled = false;
                    prbImportarExcel.Visible = true;

                    ExcelBusiness excelBusiness = new ExcelBusiness(txbPathArchivoExcel.Text);
                    List<PersonaExcel> listaPersonas = (List<PersonaExcel>)excelBusiness.RetornarRowExcel(txbNombreHoja.Text);

                    List<tbcliente> listaClientes = ImportarFilas(listaPersonas);
                    configuroProgressBar(listaClientes.Count);
                    persistirListaClientes(listaClientes);
                    ImportacionOK();
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

        /// <summary>
        /// Convierte los elementos de List<PersonaExcel> a List<tbCliente>
        /// </summary>
        /// <param name="listaPersonas">lista de personas cargadas del documento Excel.</param>
        /// <returns>Lista de tbcliente para persistir</returns>
        private List<tbcliente> ImportarFilas(List<PersonaExcel> listaPersonas)
        {
            List<tbcliente> listaClientes = new List<tbcliente>();
            try
            {
                tbcliente cliente;
                foreach (PersonaExcel persona in listaPersonas)
                {
                    cliente = CargarDatosCliente(persona);
                    listaClientes.Add(cliente);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                ImportacionError("Error al crear los objetos cliente. \nControle las columnas del archivo excel");
            }
            return listaClientes;
        }

        void persistirListaClientes(List<tbcliente> listaClientes)
        {
            try
            {
                ClienteBusiness clienteBusiness = new ClienteBusiness();

                foreach (var obj in listaClientes)
                {
                    clienteBusiness.Create(obj);
                    prbImportarExcel.Value++;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                ImportacionError("Error al persistir lista de clientes.");
            }
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
                    cli_id_import = persona.id, //Asigno el id existente al campo id_import
                    cli_fecha = DateTime.Parse(persona.fechaDeIngreso.ToString()),
                    cli_actualizado = DateTime.Parse(persona.actualizado.ToString()),
                    cli_titulo = persona.titulo,
                    cli_apellido = CargarDatoNulo(persona.apellido),
                    cli_nombre_pila = persona.nombreDePila,
                    cli_nombre = CargarDatoNulo(persona.nombreCompleto),
                    cli_imprime_carta = persona.imprimeCarta,
                    cli_estado_actual = persona.estadoActual,
                    cli_telefono_celular = persona.celular,
                    cli_telefono_particular = persona.telParticular,
                    cli_email = persona.email,
                    cli_fecha_nacimiento = DateTime.Parse(persona.nacimiento.ToString()),
                    cli_nacionalidad = persona.nacionalidad,
                    cli_numero_documento = CargarDatoNulo(persona.dniTitular),
                    cli_cuit_cuil = persona.cuitCuilTitular,
                    cli_estado_civil = persona.estadoCivil,
                    cli_como_llego = persona.observaciones
                };

                //Agrego campo obligatorio cli_tipo_documento
                cliente.cli_tipo_documento = "DNI";
                cliente.tif_id = 5;

                CargarDomicilio(persona, cliente);

                if (!string.IsNullOrEmpty(persona.apellidoConyuge) ||
                   !string.IsNullOrEmpty(persona.nombrePilaConyuge) ||
                   !string.IsNullOrEmpty(persona.dniConyuge) ||
                   !string.IsNullOrEmpty(persona.cuitCuilConyuge) ||
                   !string.IsNullOrEmpty(persona.nacionalidadConyuge) ||
                   !string.IsNullOrEmpty(persona.mailConyuge))
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
                tip_id = 4, //dato obligatorio importado
                dom_calle = "Domicilio importado excel", //dato obligatorio
                dom_numero = 0, //dato obligatorio
                dom_piso = 0, // se carga el dato para sincronizar con alta de nuevo cliente
                dom_domicilio_importado = persona.domicilio,
                dom_codigo_postal = persona.codigoPostal.ToString(),
                dom_localidad = CargarDatoNulo(persona.localidad),
                dom_actual = true, //Para que tome el domicilio importado
                dom_departamento = "-"
            };
            cliente.tbdomicilio.Add(domicilio);
        }

        private static void CargarConyuge(PersonaExcel persona, tbcliente cliente)
        {
            //Cargo datos del conyuge
            tbcliente conyuje = new tbcliente()
            {
                tif_id = 6, //Cargo tipo de familiar Conyuje
                cli_fecha = DateTime.Parse(persona.fechaDeIngreso.ToString()), //Asigno misma fecha de alta que el cliente
                cli_apellido = CargarDatoNulo(persona.apellidoConyuge),
                cli_nombre_pila = persona.nombrePilaConyuge,
                cli_nombre = CargarDatoNulo(persona.nombreCompletoConyuge),
                cli_tipo_documento = "DNI", // Obligatorio tipo de documento
                cli_numero_documento = CargarDatoNulo(persona.dniConyuge),
                cli_cuit_cuil = persona.cuitCuilConyuge,
                cli_fecha_nacimiento = DateTime.Parse(persona.nacimientoConyuge.ToString()),
                cli_nacionalidad = persona.nacionalidadConyuge,
                cli_telefono_celular = persona.celularConyuge,
                cli_actualizado = persona.actualizado, //Asigno fecha actualizado para no generar error.
                cli_email = persona.mailConyuge
            };
            cliente.tbcliente1.Add(conyuje);
        }

        private static string CargarDatoNulo(string campoString)
        {
            return string.IsNullOrEmpty(campoString) ? "Dato sin cargar" : campoString;
        }
        #endregion

        void configuroProgressBar(int value)
        {
            prbImportarExcel.Value = 0;
            prbImportarExcel.Maximum = value;
            prbImportarExcel.Step = 1;
        }

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
