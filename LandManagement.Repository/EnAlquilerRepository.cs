using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class EnAlquilerRepository: ICrud<tbenalquiler>
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

        public void Create(tbenalquiler entity)
        {
            throw new NotImplementedException();
        }

        public void Update(tbenalquiler entity)
        {
            try
            {
                EntityKey key = Contexto.CreateEntityKey(Contexto.CreateObjectSet<tbenalquiler>().EntitySet.Name, entity);
                tbenalquiler entityAux = (tbenalquiler)Contexto.GetObjectByKey(key);

                Contexto.CreateObjectSet<tbenalquiler>().ApplyCurrentValues(entity);
                Contexto.ObjectStateManager.GetObjectStateEntry(entityAux).ChangeState(EntityState.Modified);
                Contexto.ObjectStateManager.ChangeObjectState(entityAux, EntityState.Modified);

                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(tbenalquiler entity)
        {
            try
            {
                tbenalquiler o = (tbenalquiler)this.GetElementByKey(entity);
                Contexto.tbenalquiler.DeleteObject(o);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetElement(tbenalquiler entity)
        {
            throw new NotImplementedException();
        }

        public object GetElementByKey(tbenalquiler entity)
        {
            try
            {
                EntityKey key = Contexto.CreateEntityKey(
                    Contexto.CreateObjectSet<tbenalquiler>().EntitySet.Name, entity);

                return Contexto.GetObjectByKey(key);;
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
