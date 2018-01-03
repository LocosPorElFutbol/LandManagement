using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandManagement.Repository;
using LandManagement.Entities;

namespace LandManagement.Business
{
    public class ClienteOperacionBusiness
    {
        private ClienteOperacionRepository clienteOperacionRepository;

        public ClienteOperacionBusiness()
        {
            clienteOperacionRepository = new ClienteOperacionRepository();
        }

        public void Create(tbclienteoperacion entity)
        {
            clienteOperacionRepository.Create(entity);
        }

        public void Delete(tbclienteoperacion entity)
        {
            clienteOperacionRepository.Delete(entity);
        }

        public object GetElementByKey(tbclienteoperacion entity)
        {
            return clienteOperacionRepository.GetElementByKey(entity);
        }

        public object GetListByIdOperacion(int _idOperacion)
        {
            return clienteOperacionRepository.GetListByIdOperacion(_idOperacion);
        }

        public object GetList(Func<tbclienteoperacion, bool> _whereClausule)
        {
            return clienteOperacionRepository.GetList(_whereClausule);
        }

        public object GetClienteOperacionPorIdsOperacion(List<int> idsOperaciones)
        {
            Func<tbclienteoperacion, bool> whereClausule = x => idsOperaciones.Contains(x.ope_id);
            return this.GetList(whereClausule);
        }
    }
}
