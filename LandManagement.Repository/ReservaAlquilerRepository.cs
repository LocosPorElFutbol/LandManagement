using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class ReservaAlquilerRepository: BaseRepository<tbreservaalquiler>
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

        public override void Create(tbreservaalquiler entity)
        {
            throw new NotImplementedException();
        }

        //public void Update(tbreservaalquiler entity)
        //{
        //    try
        //    {
        //        EntityKey key = ContextoLocal.CreateEntityKey(ContextoLocal.CreateObjectSet<tbreservaalquiler>().EntitySet.Name, entity);
        //        tbreservaalquiler entityAux = (tbreservaalquiler)ContextoLocal.GetObjectByKey(key);

        //        ContextoLocal.CreateObjectSet<tbreservaalquiler>().ApplyCurrentValues(entity);
        //        ContextoLocal.ObjectStateManager.GetObjectStateEntry(entityAux).ChangeState(EntityState.Modified);
        //        ContextoLocal.ObjectStateManager.ChangeObjectState(entityAux, EntityState.Modified);

        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void Delete(tbreservaalquiler entity)
        //{
        //    try
        //    {
        //        tbreservaalquiler o = (tbreservaalquiler)this.GetElementByKey(entity);
        //        ContextoLocal.tbreservaalquiler.DeleteObject(o);
        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public object GetElement(tbreservaalquiler entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public object GetElement(tbreservaalquiler entity)
        //{
        //    try
        //    {
        //        EntityKey key = ContextoLocal.CreateEntityKey(
        //            ContextoLocal.CreateObjectSet<tbreservaalquiler>().EntitySet.Name, entity);

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
