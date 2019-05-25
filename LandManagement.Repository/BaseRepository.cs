using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LandManagement.Repository
{
    public abstract class BaseRepository<E> : IBaseRepository<E> 
        where E : class, new()
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

        public virtual void Create(E entity)
        {
            try
            {
                Contexto = new landmanagementbdEntities();
                Contexto.CreateObjectSet<E>().AddObject(entity);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Update(E entity)
        {
            try
            {
                EntityKey key = Contexto.CreateEntityKey(
                    Contexto.CreateObjectSet<E>().EntitySet.Name, entity);
                E entityAux = null;
                entityAux = (E)Contexto.GetObjectByKey(key);

                Contexto.CreateObjectSet<E>().ApplyCurrentValues(entity);
                Contexto.ObjectStateManager.GetObjectStateEntry(entityAux).ChangeState(EntityState.Modified);
                Contexto.ObjectStateManager.ChangeObjectState(entityAux, EntityState.Modified);

                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete(E entity)
        {
            try
            {
                E entidad = (E)this.GetElement(entity);
                Contexto.DeleteObject(entidad);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual object GetElement(E entity)
        {
            EntityKey key = Contexto.CreateEntityKey(
                Contexto.CreateObjectSet<E>().EntitySet.Name, entity);
            try
            {
                return (E)Contexto.GetObjectByKey(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual object GetList()
        {
            return Contexto.CreateObjectSet<E>().ToList();
        }

        public virtual object GetList(Func<E, bool> funcion)
        {
            try
            {
                return Contexto.CreateObjectSet<E>().Where(funcion).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
