using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class EnVentaRepository : BaseRepository<tbenventa>
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

		public override void Create(tbenventa entity)
		{
            throw new NotImplementedException();
		}

		//public void Update(tbenventa entity)
		//      {
		//          try
		//          {
		//              EntityKey key = ContextoLocal.CreateEntityKey(ContextoLocal.CreateObjectSet<tbenventa>().EntitySet.Name, entity);
		//              tbenventa entityAux = (tbenventa)ContextoLocal.GetObjectByKey(key);

		//              ContextoLocal.CreateObjectSet<tbenventa>().ApplyCurrentValues(entity);
		//              ContextoLocal.ObjectStateManager.GetObjectStateEntry(entityAux).ChangeState(EntityState.Modified);
		//              ContextoLocal.ObjectStateManager.ChangeObjectState(entityAux, EntityState.Modified);

		//              ContextoLocal.SaveChanges();
		//          }
		//          catch (Exception ex)
		//          {
		//              throw ex;
		//          }
		//      }

		//public void Delete(tbenventa entity)
		//{
		//    try
		//    {
		//        tbenventa m = (tbenventa)this.GetElementByKey(entity);
		//        ContextoLocal.tbenventa.DeleteObject(m);
		//        ContextoLocal.SaveChanges();
		//    }
		//    catch (Exception ex)
		//    {
		//        throw ex;
		//    }
		//}

		//public object GetElement(tbenventa entity)
		//{
		//    throw new NotImplementedException();
		//}

		//public object GetElement(tbenventa entity)
		//{
		//    try
		//    {
		//        EntityKey key = ContextoLocal.CreateEntityKey(
		//            ContextoLocal.CreateObjectSet<tbenventa>().EntitySet.Name, entity);

		//        return ContextoLocal.GetObjectByKey(key);
		//    }
		//    catch (Exception ex)
		//    {
		//        throw ex;
		//    }
		//}

		public override object GetList()
		{
			throw new NotImplementedException();
		}

		public override object GetList(Func<tbenventa, bool> funcion)
		{
			throw new NotImplementedException();
		}
	}
}
