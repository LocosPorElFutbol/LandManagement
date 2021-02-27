using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class EnAlquilerRepository: BaseRepository<tbenalquiler>
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

        public override void Create(tbenalquiler entity)
        {
            throw new NotImplementedException();
        }

        //public void Update(tbenalquiler entity)
        //{
        //    try
        //    {
        //        EntityKey key = ContextoLocal.CreateEntityKey(ContextoLocal.CreateObjectSet<tbenalquiler>().EntitySet.Name, entity);
        //        tbenalquiler entityAux = (tbenalquiler)ContextoLocal.GetObjectByKey(key);

        //        ContextoLocal.CreateObjectSet<tbenalquiler>().ApplyCurrentValues(entity);
        //        ContextoLocal.ObjectStateManager.GetObjectStateEntry(entityAux).ChangeState(EntityState.Modified);
        //        ContextoLocal.ObjectStateManager.ChangeObjectState(entityAux, EntityState.Modified);

        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void Delete(tbenalquiler entity)
        //{
        //    try
        //    {
        //        tbenalquiler o = (tbenalquiler)this.GetElementByKey(entity);
        //        ContextoLocal.tbenalquiler.DeleteObject(o);
        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public object GetElement(tbenalquiler entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public object GetElement(tbenalquiler entity)
        //{
        //    try
        //    {
        //        EntityKey key = ContextoLocal.CreateEntityKey(
        //            ContextoLocal.CreateObjectSet<tbenalquiler>().EntitySet.Name, entity);

        //        return ContextoLocal.GetObjectByKey(key);;
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
