using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class EnVentaRepository : IEnVenta<tbenventa>
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

        public void Update(tbenventa entity)
        {
            try
            {
                EntityKey key = Contexto.CreateEntityKey(Contexto.CreateObjectSet<tbenventa>().EntitySet.Name, entity);
                tbenventa entityAux = (tbenventa)Contexto.GetObjectByKey(key);

                Contexto.CreateObjectSet<tbenventa>().ApplyCurrentValues(entity);
                Contexto.ObjectStateManager.GetObjectStateEntry(entityAux).ChangeState(EntityState.Modified);
                Contexto.ObjectStateManager.ChangeObjectState(entityAux, EntityState.Modified);

                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(tbenventa entity)
        {
            try
            {
                tbenventa m = (tbenventa)this.GetElementByKey(entity);
                Contexto.tbenventa.DeleteObject(m);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetElement(tbenventa entity)
        {
            throw new NotImplementedException();
        }

        public object GetElementByKey(tbenventa entity)
        {
            try
            {
                EntityKey key = Contexto.CreateEntityKey(
                    Contexto.CreateObjectSet<tbenventa>().EntitySet.Name, entity);

                return Contexto.GetObjectByKey(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
