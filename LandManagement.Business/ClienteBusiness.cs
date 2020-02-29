using LandManagement.Entities;
using LandManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandManagement.Business
{
	public class ClienteBusiness
	{
		private ClienteRepository clienteRepository;
		private DomicilioBusiness domicilioBusiness;
		private PropiedadBusiness propiedadBusiness;
		private FamiliarBusiness familiarBusiness;

		public ClienteBusiness()
		{
			clienteRepository = new ClienteRepository();
		}

		public void Create(tbcliente cliente)
		{
			clienteRepository.Create(cliente);
		}

		public void Update(tbcliente cliente)
		{
			//Actualizo propiedades del cliente
			ActualizarPropiedadesCliente(cliente);

			//Actualizo familiares del cliente
			ActualizarFamiliaresCliente(cliente);

			//Actualizo el domicilio del cliente.
			ActualizarDomicilioCliente(cliente);

			clienteRepository.Update(cliente);
		}

		public void Update(tbcliente cliente, tbpropiedad propiedad)
		{
			clienteRepository.Update(cliente, propiedad);
		}

		public void Delete(tbcliente cliente)
		{
			clienteRepository.Delete(cliente);
		}

		public void Delete(tbcliente cliente, tbpropiedad propiedad)
		{
			clienteRepository.Delete(cliente, propiedad);
		}

		public void Delete(tbcliente cliente, tbcliente familiar)
		{
			clienteRepository.Delete(cliente, familiar);
		}

		public object GetElement(tbcliente cliente)
		{
			return clienteRepository.GetElement(cliente);
		}

		public object ValidarExistenciaByDNI(tbcliente cliente)
		{
			return clienteRepository.ValidarExitenciaByDni(cliente);
		}

		public object GetList()
		{
			return clienteRepository.GetList();
		}

		public object GetList(Func<tbcliente, bool> _whereClausule)
		{
			return clienteRepository.GetList(_whereClausule);
		}

		public object GetListCumpleanieros(DateTime fechaDesde, DateTime fechaHasta)
		{
			DateTime fechanula = new DateTime(1900, 01, 01);
			List<tbcliente> clientesSalida = new List<tbcliente>();

			fechaDesde = new DateTime(DateTime.Now.Year, fechaDesde.Month, fechaDesde.Day);
			fechaHasta = new DateTime(DateTime.Now.Year, fechaHasta.Month, fechaHasta.Day);

			List<DateTime> listaFechas = this.GetListaFechasCumpleanios(fechaDesde, fechaHasta);
			List<tbcliente> clientes = ((List<tbcliente>)this.GetList())
				.Where(m => m.cli_imprime_carta == true && !DateTime.Equals(m.cli_fecha_nacimiento, fechanula)).ToList();

			clientesSalida = (from cliente in clientes
							  from fecha in listaFechas
							  where cliente.cli_fecha_nacimiento.Day == fecha.Day
							  && cliente.cli_fecha_nacimiento.Month == fecha.Month
							  select cliente).OrderBy(x => x.cli_fecha_nacimiento.Day).ThenBy(x => x.cli_fecha_nacimiento.Month).ToList();

			return clientesSalida;
		}

		/// <summary>
		/// Incorporo todas las fechas que se encuentran en la fecha desde y hasta la fecha hasta, para obtener los cumpleañerps
		/// </summary>
		/// <param name="fechaDesde">Fecha desde la cual se buscará los cumpleañeros.</param>
		/// <param name="fechaHasta">Fecha hasta donde se buscarán los cumpleañeros.</param>
		/// <returns>Listado de fechas en las cuales se buscara los cumpleañeros.</returns>
		private List<DateTime> GetListaFechasCumpleanios(DateTime fechaDesde, DateTime fechaHasta)
		{
			DateTime fechaDesdeLocal = new DateTime(DateTime.Now.Year, fechaDesde.Month, fechaDesde.Day);
			DateTime fechaHastaLocal = new DateTime(DateTime.Now.Year, fechaHasta.Month, fechaHasta.Day);

			List<DateTime> listaFechas = new List<DateTime>();

			for (DateTime fecha = fechaDesde; fecha <= fechaHasta; fecha = fecha.AddDays(1))
			{
				listaFechas.Add(fecha);
			}
			return listaFechas;
		}

		public object GetClientesByIdCategoria(List<int> _idsCategoria)
		{
			return clienteRepository.GetClientesByIdCategoria(_idsCategoria);
		}

		public object GetClientePorPropiedad(tbpropiedad propiedad)
		{
			return clienteRepository.GetClientePorPropiedad(propiedad);
		}

		[Obsolete("El domicilio ahora va a ser unico, no se tiene mas una lista de domicilios.")]
		private void ActualizarDomicilioClienteOLD(tbcliente cliente)
		{
			domicilioBusiness = new DomicilioBusiness();

			//Obtengo los domicilios del cliente
			List<tbdomicilio> listaDomicilioBD = ((List<tbdomicilio>)domicilioBusiness.GetList())
				.Where(x => x.cli_id == cliente.cli_id).ToList();

			//selecciono los ids de los domicilios
			List<int> listaIdsDomicilioBD = listaDomicilioBD.Select(d => d.dom_id).ToList();

			//Agrego los domicilios a una nueva lista
			List<tbdomicilio> listaDomicilioCliente = new List<tbdomicilio>();

			foreach (tbdomicilio obj in cliente.tbdomicilio)
				listaDomicilioCliente.Add(obj);

			//Si no coincide la cantidad de domicilios de bd a los datos actualizados
			if (cliente.tbdomicilio.Count != listaDomicilioBD.Count)
			{
				//Obtengo el domicilio a insertar
				List<tbdomicilio> domicilioNuevo = listaDomicilioCliente
					.Where(d => !listaIdsDomicilioBD.Contains(d.dom_id)).ToList<tbdomicilio>();

				List<int> domicilioIdsNuevo = domicilioNuevo.Select(d => d.dom_id).ToList();

				//Obtengo la lista de domicilios a modificar
				List<tbdomicilio> domicilioModificados = listaDomicilioBD
					.Where(d => !domicilioIdsNuevo.Contains(d.dom_id)).ToList<tbdomicilio>();

				//Actualizo domicilios
				foreach (var obj in domicilioModificados)
				{
					obj.dom_actual = false;
					domicilioBusiness.Update(obj);
				}

				//Inserto nuevo domicilio
				tbdomicilio datosDomicilio = domicilioNuevo.FirstOrDefault<tbdomicilio>();
				tbdomicilio domicilio = new tbdomicilio()
				{
					cli_id = datosDomicilio.cli_id,
					dom_actual = true,
					dom_calle = datosDomicilio.dom_calle,
					dom_codigo_postal = datosDomicilio.dom_codigo_postal,
					dom_departamento = datosDomicilio.dom_departamento,
					dom_id = datosDomicilio.dom_id,
					dom_localidad = datosDomicilio.dom_localidad,
					dom_numero = datosDomicilio.dom_numero,
					dom_piso = datosDomicilio.dom_piso,
					tip_id = datosDomicilio.tip_id,
					dom_domicilio_importado = datosDomicilio.dom_domicilio_importado, //dom importado
					prv_id = datosDomicilio.prv_id
				};

				domicilioBusiness.Create(domicilio);
			}
		}

		private void ActualizarDomicilioCliente(tbcliente cliente)
		{
			tbdomicilio domicilioActualizado = cliente.tbdomicilio.Where(x => x.dom_actual == true).FirstOrDefault();
			domicilioActualizado.cli_id = cliente.cli_id;

			domicilioBusiness = new DomicilioBusiness();
			domicilioBusiness.Update(domicilioActualizado);
		}

		private void ActualizarPropiedadesCliente(tbcliente cliente)
		{
			propiedadBusiness = new PropiedadBusiness();

			List<tbpropiedad> propiedadesDelCliente = ((List<tbpropiedad>)propiedadBusiness
				.GetPropiedadesPorCliente(cliente)).ToList<tbpropiedad>();

			//Selecciono los ids de las propiedades
			List<int> listaIdsPropiedadesBD = propiedadesDelCliente.Select(d => d.pro_id).ToList<int>();

			//Actualizo propiedades existentes
			foreach (var prop in cliente.tbpropiedad)
				if (prop.pro_id != 0)
					propiedadBusiness.Update(prop);

			//Obtengo las propiedades a insertar
			List<tbpropiedad> propiedadesNuevas = cliente.tbpropiedad
				.Where(p => !listaIdsPropiedadesBD.Contains(p.pro_id)).ToList<tbpropiedad>();

			//Selecciono id de las propiedades que vienen del cliente
			List<int> listaIdsPropiedadesCliente = cliente.tbpropiedad.Select(p => p.pro_id).ToList<int>();

			//Obtengo las propiedades eliminadas
			List<tbpropiedad> propiedadesEliminadas = propiedadesDelCliente
				.Where(p => !listaIdsPropiedadesCliente.Contains(p.pro_id) &&
					p.pro_id != 0).ToList<tbpropiedad>();

			//Elimino las propiedades
			foreach (var p in propiedadesEliminadas)
				this.Delete(cliente, p);

			//Elimino las propiedades asociadas, para Insertar nuevas propiedades
			cliente.tbpropiedad.Clear();

			foreach (var p in propiedadesNuevas)
			{
				//Inserta nueva propiedad a cliente existente.
				propiedadBusiness = new PropiedadBusiness();
				tbpropiedad propiedad = new tbpropiedad()
				{
					tip_id = p.tip_id,
					pro_calle = p.pro_calle,
					pro_numero = p.pro_numero,
					pro_piso = p.pro_piso,
					pro_departamento = p.pro_departamento,
					pro_codigo_postal = p.pro_codigo_postal,
					pro_localidad = p.pro_localidad,
					pro_caracteristica = p.pro_caracteristica
				};

				//actualiza el cliente seteandole una propiedad existente
				if (p.pro_id != 0)
					this.Update(cliente, p);
				else
					propiedadBusiness.Create(propiedad, cliente);
			}
		}

		private void ActualizarFamiliaresCliente(tbcliente cliente)
		{
			familiarBusiness = new FamiliarBusiness();

			List<tbcliente> familiaresDelCliente = ((List<tbcliente>)familiarBusiness
				.GetFamiliaresPorCliente(cliente)).ToList<tbcliente>();

			//Selecciono los ids de los familiares
			List<int> listaIdsFamiliaresBD = familiaresDelCliente.Select(d => d.cli_id).ToList<int>();

			//Actualizo familiar existentes
			foreach (var obj in cliente.tbcliente1)
				if (obj.cli_id != 0)
					familiarBusiness.Update(obj);

			//Obtengo el familiar a insertar
			List<tbcliente> familiaresNuevos = cliente.tbcliente1
				.Where(p => !listaIdsFamiliaresBD.Contains(p.cli_id)).ToList<tbcliente>();

			//Selecciono id de los familiares que vienen del cliente
			List<int> listaIdsFamiliaresCliente = cliente.tbcliente1.Select(c => c.cli_id).ToList<int>();

			//Obtengo los familiares eliminados
			List<tbcliente> familiaresEliminados = familiaresDelCliente
				.Where(p => !listaIdsFamiliaresCliente.Contains(p.cli_id) &&
					p.cli_id != 0).ToList<tbcliente>();

			//Elimino las propiedades
			foreach (var f in familiaresEliminados)
				this.Delete(cliente, f);

			//Elimino familiares asociados para insertar a los nuevos
			cliente.tbcliente1.Clear();
			foreach (var obj in familiaresNuevos)
			{
				familiarBusiness = new FamiliarBusiness();
				familiarBusiness.Create(obj, cliente);
			}
		}

		public object ArmarArbolGenealogico(tbcliente entity)
		{
			return clienteRepository.ArmarArbolGenealogico(entity);
		}

		public object GetClientesPorIdsClientes(List<int> idsClientes)
		{
			Func<tbcliente, bool> whereClausule = x => idsClientes.Contains(x.cli_id);
			return clienteRepository.GetList(whereClausule);
		}

		/// <summary>
		/// Obtiene todos los clientes que estan relacionados con una propiedad y una operación. 
		/// La búsqueda se realiza mediante el Id de la propieadad.
		/// </summary>
		/// <param name="_idPropiedad">Id de la propiedad que se relaciona con los clientes</param>
		/// <returns>Lista de clientes</returns>
		public object GetClientesPorIdPropiedad(int _idPropiedad)
		{
			//Obtengo las operaciones por id de propiedad
			OperacionBusiness operacionBusiness = new OperacionBusiness();
			List<tboperaciones> listaOperaciones =
				operacionBusiness.GetOperacionesByIdPropiedad(_idPropiedad) as List<tboperaciones>;

			List<int> idsOperaciones = new List<int>();
			listaOperaciones.ForEach(x => idsOperaciones.Add(x.ope_id));

			//Obtengo los ids de cliente-operacion por id de operacion
			ClienteOperacionBusiness clienteOperacionBusiness = new ClienteOperacionBusiness();
			List<tbclienteoperacion> listaClienteOperacion =
				clienteOperacionBusiness.GetClienteOperacionPorIdsOperacion(idsOperaciones)
					as List<tbclienteoperacion>;

			List<int> idsClientes =
				listaClienteOperacion.Select(x => x.cli_id).Distinct().ToList() as List<int>;

			//Obtengo los clientes mediante el id de cliente
			List<tbcliente> listaClientes =
				this.GetClientesPorIdsClientes(idsClientes) as List<tbcliente>;

			return listaClientes;
		}
	}
}
