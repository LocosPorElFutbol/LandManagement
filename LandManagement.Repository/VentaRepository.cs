using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class VentaRepository : ICrud<tbventa>
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

        public void Create(tbventa entity)
        {
            throw new NotImplementedException();
        }

        public void Update(tbventa entity)
        {
            try
            {
                EntityKey key = Contexto.CreateEntityKey(Contexto.CreateObjectSet<tbventa>().EntitySet.Name, entity);
                tbventa entityAux = (tbventa)Contexto.GetObjectByKey(key);

                Contexto.CreateObjectSet<tbventa>().ApplyCurrentValues(entity);
                Contexto.ObjectStateManager.GetObjectStateEntry(entityAux).ChangeState(EntityState.Modified);
                Contexto.ObjectStateManager.ChangeObjectState(entityAux, EntityState.Modified);

                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(tbventa entity)
        {
            try
            {
                tbventa o = (tbventa)this.GetElementByKey(entity);
                Contexto.tbventa.DeleteObject(o);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetElement(tbventa entity)
        {
            throw new NotImplementedException();
        }

        public object GetElementByKey(tbventa entity)
        {
            try
            {
                EntityKey key = Contexto.CreateEntityKey(
                    Contexto.CreateObjectSet<tbventa>().EntitySet.Name, entity);

                tbventa salida = (tbventa)Contexto.GetObjectByKey(key);
                return salida;
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
