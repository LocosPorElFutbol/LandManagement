using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandManagement.Interface;
using LandManagement.Entities;
using System.Data;

namespace LandManagement.Repository
{
    public class TipoPropiedadRepository : ITipoPropiedad<tbtipopropiedad>
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

        public void Create(tbtipopropiedad entity)
        {
            try
            {
                Contexto = new landmanagementbdEntities();
                Contexto.CreateObjectSet<tbtipopropiedad>().AddObject(entity);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(tbtipopropiedad entity)
        {
            try
            {
                EntityKey key = Contexto.CreateEntityKey(
                    Contexto.CreateObjectSet<tbtipopropiedad>().EntitySet.Name, entity);
                tbtipopropiedad entityAux = null;
                entityAux = (tbtipopropiedad)Contexto.GetObjectByKey(key);

                Contexto.CreateObjectSet<tbtipopropiedad>().ApplyCurrentValues(entity);
                Contexto.ObjectStateManager.GetObjectStateEntry(entityAux).ChangeState(EntityState.Modified);
                Contexto.ObjectStateManager.ChangeObjectState(entityAux, EntityState.Modified);

                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(tbtipopropiedad entity)
        {
            try
            {
                tbtipopropiedad m = (tbtipopropiedad)this.GetElement(entity);
                Contexto.tbtipopropiedad.DeleteObject(m);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetElement(tbtipopropiedad entity)
        {
            EntityKey key = Contexto.CreateEntityKey(
                Contexto.CreateObjectSet<tbtipopropiedad>().EntitySet.Name, entity);
            try
            {
                tbtipopropiedad salida = (tbtipopropiedad)Contexto.GetObjectByKey(key);
                return salida;
            }
            catch (ObjectNotFoundException)
            {
                throw new ExcepcionRepository();
            }
        }

        public object GetElementByLoginName(tbtipopropiedad entity)
        {
            tbtipopropiedad usuario = new tbtipopropiedad();
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
            return Contexto.CreateObjectSet<tbtipopropiedad>().ToList();
        }
    }
}
