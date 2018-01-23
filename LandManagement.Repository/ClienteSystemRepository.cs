using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class ClienteSystemRepository : IBaseRepository<tbsyscliente>
    {
        private static ClienteSystemRepository instancia = null;
        private landmanagementbdEntities Contexto = null;

        public static ClienteSystemRepository GetInstancia()
        {
            if(instancia == null)
                return new ClienteSystemRepository();
            return instancia;
        }

        public ClienteSystemRepository()
        {
            Contexto = new landmanagementbdEntities();
        }

        public void Create(tbsyscliente entity)
        {
            throw new NotImplementedException();
        }

        public void Update(tbsyscliente entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(tbsyscliente entity)
        {
            throw new NotImplementedException();
        }

        public object GetElement(tbsyscliente entity)
        {
            EntityKey key = Contexto.CreateEntityKey(
                Contexto.CreateObjectSet<tbsyscliente>().EntitySet.Name, entity);
            try
            {
                tbsyscliente salida = (tbsyscliente)Contexto.GetObjectByKey(key);
                return salida;
            }
            catch (ObjectNotFoundException)
            {
                throw new ExcepcionRepository();
            }
        }

        public object GetList()
        {
            throw new NotImplementedException();
        }

        public object GetList(Func<tbsyscliente, bool> funcion)
        {
            throw new NotImplementedException();
        }
    }
}
