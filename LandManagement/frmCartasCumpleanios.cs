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
        private List<EtiquetaEntity> listaEtiquetas = null;

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
                string pathWordTemplate = ConfigurationManager.AppSettings["pathWordTemplate"].ToString();
                string pathNuevoWordEtiquetas = ConfigurationManager.AppSettings["pathNuevoWordEtiquetas"].ToString();

                ReemplazarEtiquetasBusiness reemplazarEtiquetasBusiness =
                    new ReemplazarEtiquetasBusiness(pathWordTemplate, pathNuevoWordEtiquetas);

                reemplazarEtiquetasBusiness.Reemplazar(this.listaEtiquetas);

                //Todavia no se testo la funcion imprimir
                //reemplazarEtiquetasBusiness.ImprimirEtiquetas();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al imprimir etiquetas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<tbcliente> ObtenerClientesCumplenAniosEl(DateTime fechaCumpleanios)
        {
            clienteBusiness = new ClienteBusiness();
            List<tbcliente> listaCumpleanieros = 
                (List<tbcliente>)clienteBusiness.GetListCumpleanieros(fechaCumpleanios);

            return listaCumpleanieros;
        }

        #region Carga las etiquetas con los datos de los cumpleañeros
        private void CargarListaEtiquetas(List<tbcliente> _listaClientes)
        {
            listaEtiquetas = new List<EtiquetaEntity>();

            //Ordeno clientes por dia de cumpleaños para preservar el orden de impresion
            //Esto se realiza por pedido del cliente.
            _listaClientes.OrderBy(e => e.cli_fecha_nacimiento.Day);

            EtiquetaEntity etiqueta;
            EtiquetaEntity etiquetaTemp;

            foreach (var obj in _listaClientes)
            {
                etiqueta = new EtiquetaEntity();
                //Cargo los datos del domicilio en etiqueta auxiliar
                etiquetaTemp = ParseoDomicilioDelCliente(obj);

                if (etiquetaTemp != null)
                {
                    etiqueta.NombreApellido = obj.cli_nombre + ", " + obj.cli_apellido;
                    etiqueta.Direccion = etiquetaTemp.Direccion;
                    etiqueta.Localidad = etiquetaTemp.Localidad;
                    etiqueta.CodigoPostal = etiquetaTemp.CodigoPostal;

                    listaEtiquetas.Add(etiqueta);
                }
            }
        }

        /// <summary>
        /// Concateno los datos del domicilio en caso de los clientes nuevos, y sino cargo en direccion
        /// el domicilio importado. Además cargo la localidad y codigo postal.
        /// </summary>
        /// <param name="_cliente">Contiene el id del cliente por el cual se buscara el domicilio actual</param>
        /// <returns>string con la direccion concatenada por calle, numero, piso y depto</returns>
        private EtiquetaEntity ParseoDomicilioDelCliente(tbcliente _cliente)
        {
            string direccion = string.Empty;
            EtiquetaEntity e = null;
            
            //Cargo direccion
            DomicilioBusiness domicilioBusiness = new DomicilioBusiness();
            tbdomicilio domicilio = (tbdomicilio)domicilioBusiness.GetDomicilioByIdCliente(_cliente);

            if (domicilio != null)
            {
                e = new EtiquetaEntity();
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
