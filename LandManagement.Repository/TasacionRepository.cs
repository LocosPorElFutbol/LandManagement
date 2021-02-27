using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandManagement.Interface;
using LandManagement.Entities;
using System.Data;

namespace LandManagement.Repository
{
    public class TasacionRepository: BaseRepository<tbtasacion>
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

        //public void Create(tbtasacion entity)
        //{
        //    try
        //    {
        //        ContextoLocal = new landmanagementbdEntities();
        //        ContextoLocal.CreateObjectSet<tbtasacion>().AddObject(entity);
        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        //throw new ExcepcionRepository();
        //        throw ex;
        //    }
        //}

        //public void Update(tbtasacion entity)
        //{
        //    try
        //    {
        //        EntityKey key = ContextoLocal.CreateEntityKey(
        //            ContextoLocal.CreateObjectSet<tbtasacion>().EntitySet.Name, entity);
        //        tbtasacion entityAux = null;
        //        entityAux = (tbtasacion)ContextoLocal.GetObjectByKey(key);

        //        ContextoLocal.CreateObjectSet<tbtasacion>().ApplyCurrentValues(entity);
        //        ContextoLocal.ObjectStateManager.GetObjectStateEntry(entityAux).ChangeState(EntityState.Modified);
        //        ContextoLocal.ObjectStateManager.ChangeObjectState(entityAux, EntityState.Modified);

        //        ContextoLocal.SaveChanges();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //        //throw new ExcepcionRepository();
        //    }
        //}

        //public void Delete(tbtasacion entity)
        //{
        //    try
        //    {
        //        tbtasacion o = (tbtasacion)this.GetElement(entity);
        //        ContextoLocal.tbtasacion.DeleteObject(o);
        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //        //throw new ExcepcionRepository();
        //    }
        //}

        //public object GetElement(tbtasacion entity)
        //{
        //    EntityKey key = ContextoLocal.CreateEntityKey(
        //        ContextoLocal.CreateObjectSet<tbtasacion>().EntitySet.Name, entity);
        //    try
        //    {
        //        tbtasacion salida = (tbtasacion)ContextoLocal.GetObjectByKey(key);
        //        return salida;
        //    }
        //    catch (ObjectNotFoundException)
        //    {
        //        throw new ExcepcionRepository();
        //    }
        //}

        //public object GetElement(tbtasacion entity)
        //{
        //    try
        //    {
        //        EntityKey key = ContextoLocal.CreateEntityKey(
        //            ContextoLocal.CreateObjectSet<tbtasacion>().EntitySet.Name, entity);

        //        return ContextoLocal.GetObjectByKey(key);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public object GetList()
        //{
        //    return ContextoLocal.tbtasacion.ToList();
        //}
    }
}
