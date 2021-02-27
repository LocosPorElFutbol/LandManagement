using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandManagement.Interface;
using LandManagement.Entities;
using System.Data;

namespace LandManagement.Repository
{
    public class TipoFamiliarRepository : BaseRepository<tbtipofamiliar>
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

        //public void Create(tbtipofamiliar entity)
        //{
        //    try
        //    {
        //        ContextoLocal = new landmanagementbdEntities();
        //        ContextoLocal.CreateObjectSet<tbtipofamiliar>().AddObject(entity);
        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void Update(tbtipofamiliar entity)
        //{
        //    try
        //    {
        //        EntityKey key = ContextoLocal.CreateEntityKey(
        //            ContextoLocal.CreateObjectSet<tbtipofamiliar>().EntitySet.Name, entity);
        //        tbtipofamiliar entityAux = null;
        //        entityAux = (tbtipofamiliar)ContextoLocal.GetObjectByKey(key);

        //        ContextoLocal.CreateObjectSet<tbtipofamiliar>().ApplyCurrentValues(entity);
        //        ContextoLocal.ObjectStateManager.GetObjectStateEntry(entityAux).ChangeState(EntityState.Modified);
        //        ContextoLocal.ObjectStateManager.ChangeObjectState(entityAux, EntityState.Modified);

        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void Delete(tbtipofamiliar entity)
        //{
        //    try
        //    {
        //        tbtipofamiliar m = (tbtipofamiliar)this.GetElement(entity);
        //        ContextoLocal.tbtipofamiliar.DeleteObject(m);
        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public object GetElement(tbtipofamiliar entity)
        //{
        //    EntityKey key = ContextoLocal.CreateEntityKey(
        //        ContextoLocal.CreateObjectSet<tbtipofamiliar>().EntitySet.Name, entity);
        //    try
        //    {
        //        tbtipofamiliar salida = (tbtipofamiliar)ContextoLocal.GetObjectByKey(key);
        //        return salida;
        //    }
        //    catch (ObjectNotFoundException)
        //    {
        //        throw new ExcepcionRepository();
        //    }
        //}

        //public object GetElementByLoginName(tbtipofamiliar entity)
        //{
        //    tbtipofamiliar usuario = new tbtipofamiliar();
        //    try
        //    {
        //        //               usuario = Contexto.tbusuario.Include("tbmenu")
        //        //                   .Where(x => x.usu_nombre_login == entity.usu_nombre_login).FirstOrDefault();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return usuario;
        //}

        //public object GetList()
        //{
        //    return ContextoLocal.CreateObjectSet<tbtipofamiliar>().ToList();
        //}
    }
}


