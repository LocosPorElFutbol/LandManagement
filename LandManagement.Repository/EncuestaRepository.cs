using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class EncuestaRepository: BaseRepository<tbencuesta>
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

        public override void Create(tbencuesta entity)
        {
            throw new NotImplementedException();
        }

        //public void Update(tbencuesta entity)
        //{
        //    try
        //    {
        //        EntityKey key = ContextoLocal.CreateEntityKey(
        //            ContextoLocal.CreateObjectSet<tbencuesta>().EntitySet.Name, entity);

        //        tbencuesta entityAux = (tbencuesta)ContextoLocal.GetObjectByKey(key);

        //        ContextoLocal.CreateObjectSet<tbencuesta>().ApplyCurrentValues(entity);
        //        ContextoLocal.ObjectStateManager.GetObjectStateEntry(entityAux).ChangeState(EntityState.Modified);
        //        ContextoLocal.ObjectStateManager.ChangeObjectState(entityAux, EntityState.Modified);

        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void Delete(tbencuesta entity)
        //{
        //    try
        //    {
        //        tbencuesta o = (tbencuesta)this.GetElementByKey(entity);
        //        ContextoLocal.tbencuesta.DeleteObject(o);
        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public object GetElement(tbencuesta entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public object GetElement(tbencuesta entity)
        //{
        //    try
        //    {
        //        EntityKey key = ContextoLocal.CreateEntityKey(
        //            ContextoLocal.CreateObjectSet<tbencuesta>().EntitySet.Name, entity);

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
