using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class ClienteSystemRepository : BaseRepository<tbsyscliente>
    {
        //private static ClienteSystemRepository instancia = null;
        //private landmanagementbdEntities Contexto = null;

        //public static ClienteSystemRepository GetInstancia()
        //{
        //    if(instancia == null)
        //        return new ClienteSystemRepository();
        //    return instancia;
        //}

        //public ClienteSystemRepository()
        //{
        //    Contexto = new landmanagementbdEntities();
        //}

        public override void Create(tbsyscliente entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(tbsyscliente entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(tbsyscliente entity)
        {
            throw new NotImplementedException();
        }

        //public object GetElement(tbsyscliente entity)
        //{
        //    EntityKey key = Contexto.CreateEntityKey(
        //        Contexto.CreateObjectSet<tbsyscliente>().EntitySet.Name, entity);
        //    try
        //    {
        //        tbsyscliente salida = (tbsyscliente)Contexto.GetObjectByKey(key);
        //        return salida;
        //    }
        //    catch (ObjectNotFoundException)
        //    {
        //        throw new ExcepcionRepository();
        //    }
        //}

        public override object GetList()
        {
            throw new NotImplementedException();
        }

        public override object GetList(Func<tbsyscliente, bool> funcion)
        {
            throw new NotImplementedException();
        }
    }
}
