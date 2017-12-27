using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandManagement.Interface
{
    public interface IBaseRepository<E> where E : class, new()
    {
        void Create(E entity);
        void Update(E entity);
        void Delete(E entity);
        object GetElement(E entity);
        object GetList();
        object GetList(Func<E, bool> funcion);
    }
}
