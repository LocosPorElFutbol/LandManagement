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
            toolTip1.SetToolTip(btnHelp, "Guarda en clipboard la ruta donde se debe guardar la carta.");
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

        private void btnEditarCarta_Click(object sender, EventArgs e)
        {
            try
            {
                string TemplateCarta = ConfigurationManager.AppSettings["TemplateCarta"].ToString();

                ReemplazarCartasBusiness cartas = new ReemplazarCartasBusiness(TemplateCarta);
                cartas.AbrirTemplateCarta();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error editar carta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string TemplateCarta = ConfigurationManager.AppSettings["TemplateCarta"].ToString();
            System.Windows.Forms.Clipboard.SetText(TemplateCarta);
        }

        private void btnImprimirEtiquetas_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string TemplateEtiquetas300 = ConfigurationManager.AppSettings["TemplateEtiquetas300"].ToString();
                string TemplateEtiquetas300Actualizado = ConfigurationManager.AppSettings["TemplateEtiquetas300Actualizado"].ToString();

                ReemplazarEtiquetasBusiness reemplazarEtiquetasBusiness =
                    new ReemplazarEtiquetasBusiness(TemplateEtiquetas300, TemplateEtiquetas300Actualizado);

                reemplazarEtiquetasBusiness.ReemplazarImprimir300Etiquetas(this.listaEtiquetas);
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
                string TemplateCarta = ConfigurationManager.AppSettings["TemplateCarta"].ToString();
                string TemplateCarta300 = ConfigurationManager.AppSettings["TemplateCarta300"].ToString();
                string TemplateCarta300Actualizado = ConfigurationManager.AppSettings["TemplateCarta300Actualizado"].ToString();

                ReemplazarCartasBusiness reemplazarCartasBusiness = 
                    new ReemplazarCartasBusiness(TemplateCarta, TemplateCarta300, TemplateCarta300Actualizado);

                reemplazarCartasBusiness.ReemplazarImprimir300Cartas(this.listaEtiquetas);
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
                    cartaEntity.NombreCompleto = obj.cli_nombre + ", " + obj.cli_apellido;
                    cartaEntity.Direccion = cartaEntityTemp.Direccion;
                    cartaEntity.Localidad = cartaEntityTemp.Localidad;
                    cartaEntity.CodigoPostal = cartaEntityTemp.CodigoPostal;
                    cartaEntity.FechaCumpleanios = obj.cli_fecha_nacimiento;

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
