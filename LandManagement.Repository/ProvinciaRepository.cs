using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using LandManagement.Entities;
using LandManagement.Interface;

namespace LandManagement.Repository
{
    public class ProvinciaRepository : IBaseRepository<tbprovincia>
    {
        private static ProvinciaRepository instancia = null;
        private landmanagementbdEntities Contexto = null;

        public static ProvinciaRepository GetInstancia()
        {
            if (instancia == null)
                return new ProvinciaRepository();
            return instancia;
        }

        public ProvinciaRepository()
        {
            Contexto = new landmanagementbdEntities();
        }

        public void Create(tbprovincia entity)
        {
            throw new NotImplementedException();
        }

        public void Update(tbprovincia entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(tbprovincia entity)
        {
            throw new NotImplementedException();
        }

        public object GetElement(tbprovincia entity)
        {
            EntityKey key = Contexto.CreateEntityKey(
                Contexto.CreateObjectSet<tbprovincia>().EntitySet.Name, entity);
            try
            {
                return (tbprovincia)Contexto.GetObjectByKey(key);
            }
            catch (ObjectNotFoundException)
            {
                throw new ExcepcionRepository();
            }
        }

        public object GetList()
        {
            try
            {
                return Contexto.tbprovincia.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetList(Func<tbprovincia, bool> funcion)
        {
            try
            {
                return Contexto.tbprovincia.Where(funcion).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
