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

        public object GetList()
        {
            return clienteRepository.GetList();
        }

        public object GetListNombresCompletos()
        {
            List<tbcliente> listaNombresCompletos = (List<tbcliente>)this.GetList();
            foreach (tbcliente obj in listaNombresCompletos)
                this.CargarNombreCompleto(obj);

            return listaNombresCompletos;
        }

        public object GetClientesByIdCategoria(List<int> _idsCategoria)
        {
            return clienteRepository.GetClientesByIdCategoria(_idsCategoria);
        }

        public object CargarNombreCompleto(tbcliente cliente)
        {
            cliente.cli_nombre_completo = cliente.cli_nombre + ", " + cliente.cli_apellido;
            return cliente;
        }

        public object GetClientePorPropiedad(tbpropiedad propiedad)
        {
            return clienteRepository.GetClientePorPropiedad(propiedad);
        }

        private void ActualizarDomicilioCliente(tbcliente cliente)
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
                    tip_id = datosDomicilio.tip_id
                };
                
                domicilioBusiness.Create(domicilio);
            }
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

            //Actualizo propiedades existentes
            foreach (var obj in cliente.tbcliente1)
                if (obj.cli_id != 0)
                    familiarBusiness.Update(obj);

            //Obtengo el familiar a insertar
            List<tbcliente> familiaresNuevos = cliente.tbcliente1
                .Where(p => !listaIdsFamiliaresBD.Contains(p.cli_id)).ToList<tbcliente>();

            //Selecciono id de los familiares que vienen del cliente
            List<int> listaIdsFamiliaresCliente = cliente.tbcliente1.Select(c => c.cli_id).ToList<int>();

            //Obtengo las propiedades eliminadas
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
                //Inserta nueva propiedad a cliente existente.
                familiarBusiness = new FamiliarBusiness();
                tbcliente familiar = new tbcliente()
                {
                    cli_fecha = obj.cli_fecha,
                    tif_id = obj.tif_id,
                    cli_nombre = obj.cli_nombre,
                    cli_apellido = obj.cli_apellido,
                    cli_fecha_nacimiento = obj.cli_fecha_nacimiento,
                    cli_tipo_documento = obj.cli_tipo_documento,
                    cli_numero_documento = "0"
                };

                familiarBusiness.Create(familiar, cliente);
            }
        }

    }
}
