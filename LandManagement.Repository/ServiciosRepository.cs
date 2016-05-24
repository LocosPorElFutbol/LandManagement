using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandManagement.Interface;
using LandManagement.Entities;
using System.Data;

namespace LandManagement.Repository
{
    public class ServiciosRepository : IServicios<tbservicios>
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

        public void Create(tbservicios entity)
        {
            try
            {
                Contexto = new landmanagementbdEntities();
                Contexto.CreateObjectSet<tbservicios>().AddObject(entity);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(tbservicios entity)
        {
            try
            {
                EntityKey key = Contexto.CreateEntityKey(
                    Contexto.CreateObjectSet<tbservicios>().EntitySet.Name, entity);
                tbservicios entityAux = null;
                entityAux = (tbservicios)Contexto.GetObjectByKey(key);

                Contexto.CreateObjectSet<tbservicios>().ApplyCurrentValues(entity);
                Contexto.ObjectStateManager.GetObjectStateEntry(entityAux).ChangeState(EntityState.Modified);
                Contexto.ObjectStateManager.ChangeObjectState(entityAux, EntityState.Modified);

                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(tbservicios entity)
        {
            try
            {
                tbservicios m = (tbservicios)this.GetElement(entity);
                Contexto.tbservicios.DeleteObject(m);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetElement(tbservicios entity)
        {
            EntityKey key = Contexto.CreateEntityKey(
                Contexto.CreateObjectSet<tbservicios>().EntitySet.Name, entity);
            try
            {
                tbservicios salida = (tbservicios)Contexto.GetObjectByKey(key);
                return salida;
            }
            catch (ObjectNotFoundException)
            {
                throw new ExcepcionRepository();
            }
        }

        public object GetElementByLoginName(tbservicios entity)
        {
            tbservicios usuario = new tbservicios();
            try
            {
                //               usuario = Contexto.tbusuario.Include("tbmenu")
                //                   .Where(x => x.usu_nombre_login == entity.usu_nombre_login).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usuario;
        }

        public object GetList()
        {
            return Contexto.CreateObjectSet<tbservicios>().ToList();
        }
    }
}
