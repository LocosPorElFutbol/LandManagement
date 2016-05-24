using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandManagement.Interface;
using LandManagement.Entities;
using System.Data;

namespace LandManagement.Repository
{
    public class TipoFamiliarRepository : ITipoFamiliar<tbtipofamiliar>
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

        public void Create(tbtipofamiliar entity)
        {
            try
            {
                Contexto = new landmanagementbdEntities();
                Contexto.CreateObjectSet<tbtipofamiliar>().AddObject(entity);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(tbtipofamiliar entity)
        {
            try
            {
                EntityKey key = Contexto.CreateEntityKey(
                    Contexto.CreateObjectSet<tbtipofamiliar>().EntitySet.Name, entity);
                tbtipofamiliar entityAux = null;
                entityAux = (tbtipofamiliar)Contexto.GetObjectByKey(key);

                Contexto.CreateObjectSet<tbtipofamiliar>().ApplyCurrentValues(entity);
                Contexto.ObjectStateManager.GetObjectStateEntry(entityAux).ChangeState(EntityState.Modified);
                Contexto.ObjectStateManager.ChangeObjectState(entityAux, EntityState.Modified);

                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(tbtipofamiliar entity)
        {
            try
            {
                tbtipofamiliar m = (tbtipofamiliar)this.GetElement(entity);
                Contexto.tbtipofamiliar.DeleteObject(m);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetElement(tbtipofamiliar entity)
        {
            EntityKey key = Contexto.CreateEntityKey(
                Contexto.CreateObjectSet<tbtipofamiliar>().EntitySet.Name, entity);
            try
            {
                tbtipofamiliar salida = (tbtipofamiliar)Contexto.GetObjectByKey(key);
                return salida;
            }
            catch (ObjectNotFoundException)
            {
                throw new ExcepcionRepository();
            }
        }

        public object GetElementByLoginName(tbtipofamiliar entity)
        {
            tbtipofamiliar usuario = new tbtipofamiliar();
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
            return Contexto.CreateObjectSet<tbtipofamiliar>().ToList();
        }
    }
}


