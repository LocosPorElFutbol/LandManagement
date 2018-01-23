using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class VersionRepository : IBaseRepository<tbsysversion>
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
        public void Create(tbsysversion entity)
        {
            throw new NotImplementedException();
        }

        public void Update(tbsysversion entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(tbsysversion entity)
        {
            throw new NotImplementedException();
        }

        public object GetElement(tbsysversion entity)
        {
            throw new NotImplementedException();
        }

        public object GetList()
        {
            return Contexto.tbsysversion.ToList<tbsysversion>();
        }

        public object GetList(Func<tbsysversion, bool> funcion)
        {
            try
            {
                return Contexto.tbsysversion.Where(funcion).ToList<tbsysversion>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
