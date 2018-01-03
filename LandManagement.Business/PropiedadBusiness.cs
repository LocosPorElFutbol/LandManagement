using LandManagement.Entities;
using LandManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandManagement.Business
{
    public class PropiedadBusiness
    {
        private PropiedadRepository propiedadRepository;

        public PropiedadBusiness()
        {
            propiedadRepository = new PropiedadRepository();
        }

        public void Create(tbpropiedad propiedad)
        {
            propiedadRepository.Create(propiedad);
        }

        public void Create(tbpropiedad propiedad, tbcliente cliente)
        {
            propiedadRepository.Create(propiedad, cliente);
        }

        public void Update(tbpropiedad propiedad)
        {
            propiedadRepository.Update(propiedad);
        }

        public void Delete(tbpropiedad propiedad)
        {
            propiedadRepository.Delete(propiedad);
        }

        public object GetElement(tbpropiedad propiedad)
        {
            return propiedadRepository.GetElement(propiedad);
        }

        public object GetList()
        {
            return propiedadRepository.GetList();
        }

        public object GetList(Func<tbpropiedad, bool> _whereClausule)
        {
            return propiedadRepository.GetList(_whereClausule);
        }

        public object GetList(int[] ids)
        {
            return propiedadRepository.GetList(ids);
        }

        public object GetPropiedadesPorCliente(tbcliente cliente)
        {
            return propiedadRepository.GetPropiedadesPorCliente(cliente);
        }

        public object GetListDirecciones()
        {
            List<tbpropiedad> listaDirecciones = (List<tbpropiedad>)this.GetList();

            //foreach (tbpropiedad obj in listaDirecciones)
            //    this.GetDireccion(obj);

            return listaDirecciones;
        }

        public object GetListDirecciones(int[] ids)
        {
            List<tbpropiedad> listaDirecciones = (List<tbpropiedad>)this.GetList(ids);
            //foreach (tbpropiedad obj in listaDirecciones)
            //    this.GetDireccion(obj);

            return listaDirecciones;
        }

        public object GetPropiedadesPorIdCliente(int idCliente)
        {
            //Obtengo los ids de la operacion de clienteoperacion mediante el id del cliente
            ClienteOperacionBusiness clienteOperacionBusiness = new ClienteOperacionBusiness();
            List<tbclienteoperacion> listaClienteOperacion =
                clienteOperacionBusiness.GetClienteOperacionesPorIdCliente(idCliente)
                    as List<tbclienteoperacion>;

            //Armo una lista de ids de operaciones con el listado anterior
            List<int> listaIdsOperaciones = listaClienteOperacion.Select(x => x.ope_id).ToList();

            //Obtengo las operaciones con el id de operacion
            OperacionBusiness operacionesBusiness = new OperacionBusiness();
            List<tboperaciones> listaOperaciones =
                operacionesBusiness.GetIdsPropiedadesPorIdsOperacion(listaIdsOperaciones)
                    as List<tboperaciones>;

            //Obtengo los ids de las propíedades con los ids de las operaciones
            List<int> listaIdsPropiedades = 
                listaOperaciones.Select(x => x.pro_id).Distinct().ToList();
            
            //Obtengo las propieaddes con los ids de las propiedades
            Func<tbpropiedad, bool> whereClausule = x => listaIdsPropiedades.Contains(x.pro_id);
            return this.GetList(whereClausule);
        }
    }
}
