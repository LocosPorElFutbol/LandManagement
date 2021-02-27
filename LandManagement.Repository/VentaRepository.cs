using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class VentaRepository : BaseRepository<tbventa>
    {
        private landmanagementbdEntities _ContextoLocal;
        public landmanagementbdEntities ContextoLocal
        {
            set { }
            get
            {
                if (_ContextoLocal == null)
                {
                    _ContextoLocal = new landmanagementbdEntities();
                    _ContextoLocal.Configuration.LazyLoadingEnabled = false;
                    _ContextoLocal.Configuration.ProxyCreationEnabled = false;
                }
                return _ContextoLocal;
            }
        }

        public override void Create(tbventa entity)
        {
            throw new NotImplementedException();
        }

        //public void Update(tbventa entity)
        //{
        //    try
        //    {
        //        EntityKey key = ContextoLocal.CreateEntityKey(ContextoLocal.CreateObjectSet<tbventa>().EntitySet.Name, entity);
        //        tbventa entityAux = (tbventa)ContextoLocal.GetObjectByKey(key);

        //        ContextoLocal.CreateObjectSet<tbventa>().ApplyCurrentValues(entity);
        //        ContextoLocal.ObjectStateManager.GetObjectStateEntry(entityAux).ChangeState(EntityState.Modified);
        //        ContextoLocal.ObjectStateManager.ChangeObjectState(entityAux, EntityState.Modified);

        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void Delete(tbventa entity)
        //{
        //    try
        //    {
        //        tbventa o = (tbventa)this.GetElementByKey(entity);
        //        ContextoLocal.tbventa.DeleteObject(o);
        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public object GetElement(tbventa entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public object GetElement(tbventa entity)
        //{
        //    try
        //    {
        //        EntityKey key = ContextoLocal.CreateEntityKey(
        //            ContextoLocal.CreateObjectSet<tbventa>().EntitySet.Name, entity);

        //        tbventa salida = (tbventa)ContextoLocal.GetObjectByKey(key);
        //        return salida;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public override object GetList()
        {
            throw new NotImplementedException();
        }
    }
}
