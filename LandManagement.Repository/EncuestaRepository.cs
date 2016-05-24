using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class EncuestaRepository: ICrud<tbencuesta>
    {
        private landmanagementbdEntities _Contexto;
        public landmanagementbdEntities Contexto
        {
            set { }
            get
            {
                if (_Contexto == null)
                {
                    _Contexto = new landmanagementbdEntities();
                    _Contexto.ContextOptions.LazyLoadingEnabled = false;
                    _Contexto.ContextOptions.ProxyCreationEnabled = false;
                }
                return _Contexto;
            }
        }

        public void Create(tbencuesta entity)
        {
            throw new NotImplementedException();
        }

        public void Update(tbencuesta entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(tbencuesta entity)
        {
            try
            {
                tbencuesta o = (tbencuesta)this.GetElementByKey(entity);
                Contexto.tbencuesta.DeleteObject(o);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetElement(tbencuesta entity)
        {
            throw new NotImplementedException();
        }

        public object GetElementByKey(tbencuesta entity)
        {
            try
            {
                EntityKey key = Contexto.CreateEntityKey(
                    Contexto.CreateObjectSet<tbencuesta>().EntitySet.Name, entity);

                return Contexto.GetObjectByKey(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetList()
        {
            throw new NotImplementedException();
        }
    }
}
