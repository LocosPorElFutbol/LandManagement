using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class ReservaAlquilerRepository: ICrud<tbreservaalquiler>
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

        public void Create(tbreservaalquiler entity)
        {
            throw new NotImplementedException();
        }

        public void Update(tbreservaalquiler entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(tbreservaalquiler entity)
        {
            try
            {
                tbreservaalquiler o = (tbreservaalquiler)this.GetElementByKey(entity);
                Contexto.tbreservaalquiler.DeleteObject(o);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetElement(tbreservaalquiler entity)
        {
            throw new NotImplementedException();
        }

        public object GetElementByKey(tbreservaalquiler entity)
        {
            try
            {
                EntityKey key = Contexto.CreateEntityKey(
                    Contexto.CreateObjectSet<tbreservaalquiler>().EntitySet.Name, entity);

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
