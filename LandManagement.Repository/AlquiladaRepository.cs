using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class AlquiladaRepository : ICrud<tbalquilada>
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

        public void Create(tbalquilada entity)
        {
            throw new NotImplementedException();
        }

        public void Update(tbalquilada entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(tbalquilada entity)
        {
            try
            {
                tbalquilada o = (tbalquilada)this.GetElementByKey(entity);
                Contexto.tbalquilada.DeleteObject(o);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetElement(tbalquilada entity)
        {
            throw new NotImplementedException();
        }

        public object GetElementByKey(tbalquilada entity)
        {
            try
            {
                EntityKey key = Contexto.CreateEntityKey(
                    Contexto.CreateObjectSet<tbalquilada>().EntitySet.Name, entity);

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
