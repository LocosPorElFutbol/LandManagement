using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandManagement.Interface;
using LandManagement.Entities;
using System.Data;

namespace LandManagement.Repository
{
    public class TipoPropiedadRepository : BaseRepository<tbtipopropiedad>
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

        //public void Create(tbtipopropiedad entity)
        //{
        //    try
        //    {
        //        ContextoLocal = new landmanagementbdEntities();
        //        ContextoLocal.CreateObjectSet<tbtipopropiedad>().AddObject(entity);
        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void Update(tbtipopropiedad entity)
        //{
        //    try
        //    {
        //        EntityKey key = ContextoLocal.CreateEntityKey(
        //            ContextoLocal.CreateObjectSet<tbtipopropiedad>().EntitySet.Name, entity);
        //        tbtipopropiedad entityAux = null;
        //        entityAux = (tbtipopropiedad)ContextoLocal.GetObjectByKey(key);

        //        ContextoLocal.CreateObjectSet<tbtipopropiedad>().ApplyCurrentValues(entity);
        //        ContextoLocal.ObjectStateManager.GetObjectStateEntry(entityAux).ChangeState(EntityState.Modified);
        //        ContextoLocal.ObjectStateManager.ChangeObjectState(entityAux, EntityState.Modified);

        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void Delete(tbtipopropiedad entity)
        //{
        //    try
        //    {
        //        tbtipopropiedad m = (tbtipopropiedad)this.GetElement(entity);
        //        ContextoLocal.tbtipopropiedad.DeleteObject(m);
        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public object GetElement(tbtipopropiedad entity)
        //{
        //    EntityKey key = ContextoLocal.CreateEntityKey(
        //        ContextoLocal.CreateObjectSet<tbtipopropiedad>().EntitySet.Name, entity);
        //    try
        //    {
        //        tbtipopropiedad salida = (tbtipopropiedad)ContextoLocal.GetObjectByKey(key);
        //        return salida;
        //    }
        //    catch (ObjectNotFoundException)
        //    {
        //        throw new ExcepcionRepository();
        //    }
        //}

        //public object GetElementByLoginName(tbtipopropiedad entity)
        //{
        //    tbtipopropiedad usuario = new tbtipopropiedad();
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
        //    return ContextoLocal.CreateObjectSet<tbtipopropiedad>().ToList();
        //}
    }
}
