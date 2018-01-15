using LandManagement.Business;
using LandManagement.Entities;
using LandManagement.Utilidades;
using LoadWordTemplate.Business;
using LoadWordTemplate.Entities;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace LandManagement
{
    public partial class frmCartasCumpleanios : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ErrorProvider errorProvider1 = new ErrorProvider();
        private ClienteBusiness clienteBusiness;
        private List<CartaEntity> listaEtiquetas = null;

        public frmCartasCumpleanios()
        {
            InitializeComponent();
        }

        private void frmCartasCumpleanios_Load(object sender, EventArgs e)
        {
            txbCantidadClientes.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                List<tbcliente> listaClientes = new List<tbcliente>();
                listaClientes = ObtenerClientesCumplenAniosEl(dtpFechaCumpleanios.Value);

                //Creo el listado de etiquetas
                CargarListaEtiquetas(listaClientes);

                //Cargo textbox con la cantidad de clientes que cumplen años
                txbCantidadClientes.Text = this.listaEtiquetas.Count.ToString();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al cargar fechas de cumpleaños.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimirEtiquetas_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (ValidarCumpleanieros())
                {
                    CumpleaniosEtiquetaBusiness cumpleaniosEtiquetaBusiness = new CumpleaniosEtiquetaBusiness("C:\\Etiquetas.pdf");
                    cumpleaniosEtiquetaBusiness.CrearEtiquetas(this.listaEtiquetas);
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al imprimir etiquetas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimirCartas_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (ValidarCumpleanieros())
                {
                    CumpleaniosCartaBusiness cumpleaniosCartasBusiness = new CumpleaniosCartaBusiness("C:\\Cartas.pdf");
                    cumpleaniosCartasBusiness.CrearCartasCumpleanios(this.listaEtiquetas);
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al imprimir Cartas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnGuardarCarta_Click(object sender, EventArgs e)
        {
            //string cuerpoCarta = "\tEs bueno observar la actitud de los pájaros ante la adversidad, pasan días y días haciendo su nido y recogiendo materiales, muchos de estos traídos desde largas distancias, y cuando ya está terminado y listo para poner los huevos, las inclemencias del tiempo, la mano del hombre o la obra de algún animal, destruye y tira por el suelo lo que con tanto esfuerzo se logró.  ¿Qué hace el pájaro?  ¿Se lamenta, se paraliza, abandona la tarea?  … De ninguna manera!!!  VUELVE A EMPEZAR, una y otra vez hasta que en el nido aparecen los primeros huevos.  A veces, muchas veces, antes de que nazcan los pichones, algún animal o una tormenta vuelve a destruir el nido, pero esta vez con su precioso contenido. Aún así el pájaro jamás retrocede, sigue construyendo, y nunca deja de cantar.\r\n\r\n\tHoy empieza un nuevo año en tu vida ¿Sentiste alguna vez que tu vida, tu trabajo, tu familia, tus amigos no son lo que soñaste?  ¿Te dieron ganas de decir ¡Basta!, no vale la pena el esfuerzo, esto es demasiado para mí?  ¿Muchas veces te cansaste de volver a empezar, del desgaste de la lucha diaria, de la confianza traicionada, de las metas no alcanzadas cuando estabas a punto de lograrlo?\r\n\r\n\tPor más que la vida te golpee, no te entregues nunca.  No te preocupes si en la batalla sufrís alguna herida, es de esperar que algo así suceda.  Junta los pedazos de tu esperanza, ármala de nuevo y volvé a empezar.  No importa lo que pase, no aflojes, dale para adelante.  La vida es un desafío constante, pero vale la pena aceptarlo y sobre todo NUNCA DEJES DE CANTAR.";
            //cartaEntity.CuerpoCarta = new[] { cuerpoCarta };

            string macAddresses = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Only consider Ethernet network interfaces, thereby ignoring any
                // loopback devices etc.
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet) 
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }

                //STATUS UP, LAN CONECTADA
                //if (nic.NetworkInterfaceType != NetworkInterfaceType.Ethernet) continue;
                //if (nic.OperationalStatus == OperationalStatus.Up)
                //{
                //    macAddresses += nic.GetPhysicalAddress().ToString();
                //    break;
                //}
            }

            MessageBox.Show(macAddresses);
        }

        /// <summary>
        /// Obtiene los clientes que cumplen años en la fecha indicada y retorna la lista de clientes.
        /// </summary>
        /// <param name="fechaCumpleanios">Fecha de cumpleaños a buscar.</param>
        /// <returns></returns>
        private List<tbcliente> ObtenerClientesCumplenAniosEl(DateTime fechaCumpleanios)
        {
            clienteBusiness = new ClienteBusiness();
            List<tbcliente> listaCumpleanieros = 
                (List<tbcliente>)clienteBusiness.GetListCumpleanieros(fechaCumpleanios);

            return listaCumpleanieros;
        }

        private bool ValidarCumpleanieros()
        {
            if (this.listaEtiquetas == null)
            {
                MessageBox.Show("Cantidad de clientes nulo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (this.listaEtiquetas.Count != 0)
                return true;

            MessageBox.Show("Ningún cliente cumple años en esa fecha.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
        }

        #region Carga las etiquetas con los datos de los cumpleañeros
        /// <summary>
        /// Carga la lista de CartaEntity con los clientes que cumplen años
        /// en la fecha enviada desde el formulario
        /// </summary>
        /// <param name="_listaClientes">Lista de clientes con los datos para cargar Lista de CartaEntity</param>
        private void CargarListaEtiquetas(List<tbcliente> _listaClientes)
        {
            listaEtiquetas = new List<CartaEntity>();

            //Ordeno clientes por dia de cumpleaños para preservar el orden de impresion
            //Esto se realiza por pedido del cliente.
            _listaClientes.OrderBy(e => e.cli_fecha_nacimiento.Day);

            CartaEntity cartaEntity;
            CartaEntity cartaEntityTemp;

            foreach (var obj in _listaClientes)
            {
                cartaEntity = new CartaEntity();
                cartaEntityTemp = new CartaEntity();

                //Cargo los datos del domicilio en etiqueta auxiliar
                cartaEntityTemp = ParseoDomicilioDelCliente(obj);

                if (cartaEntityTemp != null)
                {
                    cartaEntity.Titulo = obj.cli_titulo;
                    cartaEntity.NombrePila = obj.cli_nombre_pila;
                    cartaEntity.Nombre = obj.cli_nombre;
                    cartaEntity.Apellido = obj.cli_apellido;
                    cartaEntity.Direccion = cartaEntityTemp.Direccion;
                    cartaEntity.Localidad = cartaEntityTemp.Localidad;
                    cartaEntity.CodigoPostal = cartaEntityTemp.CodigoPostal;
                    cartaEntity.FechaCumpleanios = obj.cli_fecha_nacimiento;
                    cartaEntity.CuerpoCarta = txbCuerpoCarta.Lines;

                    listaEtiquetas.Add(cartaEntity);
                }
            }
        }

        /// <summary>
        /// Concateno los datos del domicilio en caso de los clientes nuevos, y sino cargo en direccion
        /// el domicilio importado. Además cargo la localidad y codigo postal.
        /// </summary>
        /// <param name="_cliente">Contiene el id del cliente por el cual se buscara el domicilio actual</param>
        /// <returns>string con la direccion concatenada por calle, numero, piso y depto</returns>
        private CartaEntity ParseoDomicilioDelCliente(tbcliente _cliente)
        {
            string direccion = string.Empty;
            CartaEntity e = null;
            
            //Cargo direccion
            DomicilioBusiness domicilioBusiness = new DomicilioBusiness();
            tbdomicilio domicilio = (tbdomicilio)domicilioBusiness.GetDomicilioByIdCliente(_cliente);

            if (domicilio != null)
            {
                e = new CartaEntity();
                if (string.IsNullOrEmpty(domicilio.dom_domicilio_importado))
                {
                    string calleYNumero = domicilio.dom_calle + " " + domicilio.dom_numero;

                    string piso = string.Empty;
                    if (domicilio.dom_piso != 0)
                        piso = domicilio.dom_piso.ToString();

                    string depto = string.Empty;
                    if (domicilio.dom_departamento != "-")
                        depto = domicilio.dom_departamento;

                    direccion = calleYNumero + " " + piso + depto;
                }
                else
                    direccion = domicilio.dom_domicilio_importado;

                e.Direccion = direccion;
                e.Localidad = domicilio.dom_localidad;
                e.CodigoPostal = domicilio.dom_codigo_postal;
            }

            return e;
        }
        #endregion
    }
}
