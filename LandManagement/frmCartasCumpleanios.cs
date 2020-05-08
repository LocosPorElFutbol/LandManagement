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
            CargarCuerpoCarta();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
			Cursor.Current = Cursors.WaitCursor;
            try
            {
                List<tbcliente> listaClientes = new List<tbcliente>();
                listaClientes = ObtenerClientesCumplenAniosEl(dtpFechaCumpleaniosDesde.Value, dtpFechaCumpleaniosHasta.Value);

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
			Cursor.Current = Cursors.Default;
        }

        private void btnImprimirEtiquetas_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (ValidarCumpleanieros())
                {
                    List<CartaEntity> listaAuxiliarEtiquetas = new List<CartaEntity>();
                    this.listaEtiquetas.ForEach(x => listaAuxiliarEtiquetas.Add(x));

                    CumpleaniosEtiquetaBusiness cumpleaniosEtiquetaBusiness = new CumpleaniosEtiquetaBusiness(ConfigurationManager.AppSettings["ArchivoEtiquetas"]);
                    cumpleaniosEtiquetaBusiness.CrearEtiquetas(listaAuxiliarEtiquetas, 10);
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
                    //CumpleaniosCartaBusiness cumpleaniosCartasBusiness = new CumpleaniosCartaBusiness("C:\\Cartas.pdf");
                    CumpleaniosCartaBusiness cumpleaniosCartasBusiness = new CumpleaniosCartaBusiness(ConfigurationManager.AppSettings["ArchivoCartas"]);
                    cumpleaniosCartasBusiness.CrearCartasCumpleanios(this.listaEtiquetas, 13);
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
            try
            {
                CartaBusiness cartaBusiness = new CartaBusiness();
                tbcarta carta = new tbcarta()
                {
                    car_id = 1,
                    car_cuerpo = txbCuerpoCarta.Text,
                    car_pie = "pie carta"
                };
                cartaBusiness.Update(carta);
                MessageBox.Show("Carta guardada correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al actualizar carta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            {
                txbCantidadClientes.Text = string.Empty;
                this.listaEtiquetas = null;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.MensajeCancelar();
        }
        
        /// <summary>
        /// Obtiene los clientes que cumplen años en la fecha indicada y retorna la lista de clientes.
        /// </summary>
        /// <param name="fechaCumpleanios">Fecha de cumpleaños a buscar.</param>
        /// <returns></returns>
        private List<tbcliente> ObtenerClientesCumplenAniosEl(DateTime fechaCumpleaniosDesde, DateTime fechaCumpleaniosHasta)
        {
            clienteBusiness = new ClienteBusiness();
            List<tbcliente> listaCumpleanieros = 
                (List<tbcliente>)clienteBusiness.GetListCumpleanieros(fechaCumpleaniosDesde, fechaCumpleaniosHasta);

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

            CartaEntity cartaEntityTemp;

            foreach (var obj in _listaClientes)
            {
                cartaEntityTemp = new CartaEntity();

                //Cargo los datos del domicilio en etiqueta auxiliar
                cartaEntityTemp = ParseoDomicilioDelCliente(obj);

                if (cartaEntityTemp != null)
                {
                    listaEtiquetas.Add(new CartaEntity(
                        obj.tbtitulocliente.tcl_descripcion,
                        obj.cli_nombre_pila,
                        obj.cli_nombre,
                        obj.cli_apellido,
                        cartaEntityTemp.Direccion,
                        cartaEntityTemp.Localidad,
                        cartaEntityTemp.Provincia,
                        cartaEntityTemp.CodigoPostal,
                        obj.cli_fecha_nacimiento,
                        txbCuerpoCarta.Lines
                 ));
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
            //tbdomicilio domicilio = (tbdomicilio)domicilioBusiness.GetDomicilioByIdCliente(_cliente);

			//Predicado que me obtiene maximo id de domicilio correspondiente al cliente (antes se traian todos)
			Func<tbdomicilio, bool> predicado = x => x.cli_id == _cliente.cli_id;
			List<tbdomicilio> listaDomicilios = (List<tbdomicilio>)domicilioBusiness.GetList(predicado);
			tbdomicilio domicilio = listaDomicilios.OrderByDescending(x => x.dom_id).FirstOrDefault();

			if (domicilio != null)
			{
				e = new CartaEntity();
				if (domicilio.dom_calle == "Domicilio importado excel" && domicilio.dom_numero == 0)
				{
					direccion = domicilio.dom_domicilio_importado;
				}
				else
				{
					string calleYNumero = domicilio.dom_calle + " " + domicilio.dom_numero;

					//string piso = string.Empty;
					//if (domicilio.dom_piso != 0)
					//    piso = domicilio.dom_piso.ToString();

					string depto = string.Empty;
					if (domicilio.dom_departamento != "-")
						depto = " " + domicilio.dom_departamento;

					if (domicilio.dom_piso == 0)
						direccion = calleYNumero + " PB " + depto;
					else
						direccion = calleYNumero + " " + domicilio.dom_piso.ToString() + depto;
				}

				e.Direccion = direccion;
				e.Localidad = domicilio.dom_localidad;
				e.CodigoPostal = domicilio.dom_codigo_postal;

				//Cargo provincia
				ProvinciaBusiness provinciaBusiness = new ProvinciaBusiness();
				tbprovincia provincia =
					(tbprovincia)provinciaBusiness.GetElement(new tbprovincia() { prv_id = domicilio.prv_id });
				e.Provincia = provincia.prv_descripcion;
			}

            return e;
        }
        #endregion

        private void CargarCuerpoCarta()
        {
            CartaBusiness cartaBusiness = new CartaBusiness();
            tbcarta carta = cartaBusiness.GetElement(new tbcarta() { car_id = 1 }) as tbcarta;
            txbCuerpoCarta.Text = carta.car_cuerpo;
        }

        private void MensajeCancelar()
        {
            DialogResult dialogResult = DialogResult.None;

            dialogResult = MessageBox.Show("¿Desea cerrar la ventana?", "Aviso", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                AutoValidate = AutoValidate.Disable;
                this.Close();
            }
        }

    }
}
