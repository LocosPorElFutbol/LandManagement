using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class ReservaVentaRepository: BaseRepository<tbreservaventa>
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

        public override void Create(tbreservaventa entity)
        {
            throw new NotImplementedException();
        }

        //public void Update(tbreservaventa entity)
        //{
        //    try
        //    {
        //        EntityKey key = ContextoLocal.CreateEntityKey(
        //            ContextoLocal.CreateObjectSet<tbreservaventa>().EntitySet.Name, entity);
        //        tbreservaventa entityAux = null;
        //        entityAux = (tbreservaventa)ContextoLocal.GetObjectByKey(key);

        //        ContextoLocal.CreateObjectSet<tbreservaventa>().ApplyCurrentValues(entity);
        //        ContextoLocal.ObjectStateManager.GetObjectStateEntry(entityAux).ChangeState(EntityState.Modified);
        //        ContextoLocal.ObjectStateManager.ChangeObjectState(entityAux, EntityState.Modified);

        //        ContextoLocal.SaveChanges();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void Delete(tbreservaventa entity)
        //{
        //    try
        //    {
        //        tbreservaventa o = (tbreservaventa)this.GetElementByKey(entity);
        //        ContextoLocal.tbreservaventa.DeleteObject(o);
        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public object GetElement(tbreservaventa entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public object GetElement(tbreservaventa entity)
        //{ 
        //    try
        //    {
        //        EntityKey key = ContextoLocal.CreateEntityKey(
        //            ContextoLocal.CreateObjectSet<tbreservaventa>().EntitySet.Name, entity);

        //        return ContextoLocal.GetObjectByKey(key);
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
