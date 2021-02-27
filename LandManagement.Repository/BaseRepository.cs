using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;

namespace LandManagement.Repository
{
    public abstract class BaseRepository<E> : IBaseRepository<E> 
        where E : class, new()
    {
        //private landmanagementbdEntities _Contexto;
        //public landmanagementbdEntities Contexto
        //{
        //    set { }
        //    get
        //    {
        //        if (_Contexto == null)
        //        {
        //            _Contexto = new landmanagementbdEntities();
        //            _Contexto.ContextOptions.LazyLoadingEnabled = false;
        //            _Contexto.ContextOptions.ProxyCreationEnabled = false;
        //        }
        //        return _Contexto;
        //    }
        //}
        private ObjectContext _Contexto;

        public ObjectContext Contexto
        {
            set { }
            get
            {
				if (_Contexto == null)
                {
					landmanagementbdEntities asd = new landmanagementbdEntities();
                    var cliente = asd.tbcliente.FirstOrDefault();
                    Console.WriteLine(cliente.cli_nombre);

					//EntityConnection entityConnection = asd.Database.Connection as EntityConnection;
					//_Contexto = new ObjectContext(entityConnection);
					//_Contexto = new ObjectContext("name=landmanagementbdEntities");
					_Contexto =
						new ObjectContext(ConfigurationManager.ConnectionStrings["landmanagementbdEntities"].ConnectionString);
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
                EntityKey entityKey = new EntityKey()
                {
                    EntityContainerName = Contexto.CreateObjectSet<E>().EntitySet.EntityContainer.Name,
                    EntitySetName = Contexto.CreateObjectSet<E>().EntitySet.Name
                };
                string entitySetName = entityKey.EntityContainerName + "." + entityKey.EntitySetName;

                EntityKey key = Contexto.CreateEntityKey(entitySetName, entity);
                E entityAux = (E)Contexto.GetObjectByKey(key);

                //EntityKey key = Contexto.CreateEntityKey(
                //    Contexto.CreateObjectSet<E>().EntitySet.Name, entity);

                //E entityAux = (E)Contexto.GetObjectByKey(key);

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
                E entityToDelete = (E)this.GetElement(entity);
                Contexto.DeleteObject(entityToDelete);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual object GetElement(E entity)
        {
            try
            {
                EntityKey entityKey = new EntityKey()
                {
                    EntityContainerName = Contexto.CreateObjectSet<E>().EntitySet.EntityContainer.Name,
                    EntitySetName = Contexto.CreateObjectSet<E>().EntitySet.Name
                };
                
                string entitySetName = entityKey.EntityContainerName + "." + entityKey.EntitySetName;
				EntityKey key = Contexto.CreateEntityKey(entitySetName, entity);

				//EntityKey key = Contexto.CreateEntityKey(
				//    Contexto.CreateObjectSet<E>().EntitySet.Name, entity);

				return (E)Contexto.GetObjectByKey(key);
            }
            catch (ObjectNotFoundException)
            {
                throw new ExcepcionRepository();
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
