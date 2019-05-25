using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandManagement.Interface;

namespace LandManagement.Business
{
    public abstract class BaseBusiness<E, R>
        where R : IBaseRepository<E>, new()
        where E : class, new()
    {
        private R repository;

        public BaseBusiness()
        {
            repository = new R();
        }

        public virtual void Create(E entity)
        {
            repository.Create(entity);
        }

        public virtual void Update(E entity)
        {
            repository.Update(entity);
        }

        public virtual void Delete(E entity)
        {
            repository.Delete(entity);
        }

        public virtual object GetElement(E entity)
        {
            return repository.GetElement(entity);
        }

        public virtual object GetList()
        {
            return repository.GetList();
        }

        public virtual object GetList(Func<E, bool> funcion)
        {
            return repository.GetList(funcion);
        }
    }
}
