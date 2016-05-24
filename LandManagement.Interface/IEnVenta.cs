using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandManagement.Interface
{
    public interface IEnVenta<E> where E: class, new()
    {
        void Update(E entity);
        void Delete(E entity);
        object GetElement(E entity);
        object GetElementByKey(E entity);
    }
}
