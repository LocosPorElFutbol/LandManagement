using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class ReservaVentaRepository: ICrud<tbreservaventa>
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

        public void Create(tbreservaventa entity)
        {
            throw new NotImplementedException();
        }

        public void Update(tbreservaventa entity)
        {
            try
            {
                EntityKey key = Contexto.CreateEntityKey(
                    Contexto.CreateObjectSet<tbreservaventa>().EntitySet.Name, entity);
                tbreservaventa entityAux = null;
                entityAux = (tbreservaventa)Contexto.GetObjectByKey(key);

                Contexto.CreateObjectSet<tbreservaventa>().ApplyCurrentValues(entity);
                Contexto.ObjectStateManager.GetObjectStateEntry(entityAux).ChangeState(EntityState.Modified);
                Contexto.ObjectStateManager.ChangeObjectState(entityAux, EntityState.Modified);

                Contexto.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(tbreservaventa entity)
        {
            try
            {
                tbreservaventa o = (tbreservaventa)this.GetElementByKey(entity);
                Contexto.tbreservaventa.DeleteObject(o);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetElement(tbreservaventa entity)
        {
            throw new NotImplementedException();
        }

        public object GetElementByKey(tbreservaventa entity)
        { 
            try
            {
                EntityKey key = Contexto.CreateEntityKey(
                    Contexto.CreateObjectSet<tbreservaventa>().EntitySet.Name, entity);

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
