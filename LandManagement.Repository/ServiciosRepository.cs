using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandManagement.Interface;
using LandManagement.Entities;
using System.Data;

namespace LandManagement.Repository
{
    public class ServiciosRepository : BaseRepository<tbservicios>
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

        //public void Create(tbservicios entity)
        //{
        //    try
        //    {
        //        ContextoLocal = new landmanagementbdEntities();
        //        ContextoLocal.CreateObjectSet<tbservicios>().AddObject(entity);
        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void Update(tbservicios entity)
        //{
        //    try
        //    {
        //        EntityKey key = ContextoLocal.CreateEntityKey(
        //            ContextoLocal.CreateObjectSet<tbservicios>().EntitySet.Name, entity);
        //        tbservicios entityAux = null;
        //        entityAux = (tbservicios)ContextoLocal.GetObjectByKey(key);

        //        ContextoLocal.CreateObjectSet<tbservicios>().ApplyCurrentValues(entity);
        //        ContextoLocal.ObjectStateManager.GetObjectStateEntry(entityAux).ChangeState(EntityState.Modified);
        //        ContextoLocal.ObjectStateManager.ChangeObjectState(entityAux, EntityState.Modified);

        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void Delete(tbservicios entity)
        //{
        //    try
        //    {
        //        tbservicios m = (tbservicios)this.GetElement(entity);
        //        ContextoLocal.tbservicios.DeleteObject(m);
        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public object GetElement(tbservicios entity)
        //{
        //    EntityKey key = ContextoLocal.CreateEntityKey(
        //        ContextoLocal.CreateObjectSet<tbservicios>().EntitySet.Name, entity);
        //    try
        //    {
        //        tbservicios salida = (tbservicios)ContextoLocal.GetObjectByKey(key);
        //        return salida;
        //    }
        //    catch (ObjectNotFoundException)
        //    {
        //        throw new ExcepcionRepository();
        //    }
        //}

        //public object GetElementByLoginName(tbservicios entity)
        //{
        //    tbservicios usuario = new tbservicios();
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
        //    return ContextoLocal.CreateObjectSet<tbservicios>().ToList();
        //}
    }
}
