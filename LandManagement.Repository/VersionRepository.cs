using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class VersionRepository : IBaseRepository<tbversion>
    {
        private static VersionRepository instancia = null;
        private landmanagementbdEntities Contexto = null;
 
        public static VersionRepository GetInstancia()
        {
            if (instancia == null)
                return new VersionRepository();
            return instancia;
        }

        public VersionRepository()
        {
            Contexto = new landmanagementbdEntities();
        }
        public void Create(tbversion entity)
        {
            throw new NotImplementedException();
        }

        public void Update(tbversion entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(tbversion entity)
        {
            throw new NotImplementedException();
        }

        public object GetElement(tbversion entity)
        {
            throw new NotImplementedException();
        }

        public object GetList()
        {
            return Contexto.tbversion.ToList<tbversion>();
        }

        public object GetList(Func<tbversion, bool> funcion)
        {
            try
            {
                return Contexto.tbversion.Where(funcion).ToList<tbversion>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
