using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandManagement.Interface;
using LandManagement.Entities;
using System.Data;

namespace LandManagement.Repository
{
    public class DomicilioRepository: BaseRepository<tbdomicilio>
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

        //public void Create(tbdomicilio entity)
        //{
        //    try
        //    {
        //        ContextoLocal = new landmanagementbdEntities();
        //        ContextoLocal.CreateObjectSet<tbdomicilio>().AddObject(entity);
        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        //throw new ExcepcionRepository();
        //        throw ex;
        //    }
        //}

        //public void Update(tbdomicilio entity)
        //{
        //    try
        //    {
        //        EntityKey key = ContextoLocal.CreateEntityKey(
        //            ContextoLocal.CreateObjectSet<tbdomicilio>().EntitySet.Name, entity);
        //        tbdomicilio entityAux = null;
        //        entityAux = (tbdomicilio)ContextoLocal.GetObjectByKey(key);

        //        ContextoLocal.CreateObjectSet<tbdomicilio>().ApplyCurrentValues(entity);
        //        ContextoLocal.ObjectStateManager.GetObjectStateEntry(entityAux).ChangeState(EntityState.Modified);
        //        ContextoLocal.ObjectStateManager.ChangeObjectState(entityAux, EntityState.Modified);

        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //        //throw new ExcepcionRepository();
        //    }
        //}

        //public void Delete(tbdomicilio entity)
        //{
        //    try
        //    {
        //        tbdomicilio d = (tbdomicilio)this.GetElement(entity);
        //        ContextoLocal.tbdomicilio.DeleteObject(d);
        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //        //throw new ExcepcionRepository();
        //    }
        //}

        //public object GetElement(tbdomicilio entity)
        //{
        //    EntityKey key = ContextoLocal.CreateEntityKey(
        //        ContextoLocal.CreateObjectSet<tbdomicilio>().EntitySet.Name, entity);
        //    try
        //    {
        //        tbdomicilio salida = (tbdomicilio)ContextoLocal.GetObjectByKey(key);
        //        return salida;
        //    }
        //    catch (ObjectNotFoundException)
        //    {
        //        throw new ExcepcionRepository();
        //    }
        //}

        public object GetDomicilioPorCliente(tbcliente cliente)
        {
            try
            {
                var salida = (from d in ContextoLocal.tbdomicilio
                              where d.cli_id == cliente.cli_id
                              select d).ToList<tbdomicilio>();

                return salida;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

  //      public object GetList()
  //      {
  //          //return Contexto.CreateObjectSet<tbmenu>().ToList();
  //          return ContextoLocal.tbdomicilio.ToList();
  //      }

		//public object GetList(Func<tbdomicilio, bool> predicado)
		//{
		//	return ContextoLocal.tbdomicilio.Where(predicado).ToList();
		//}
    }
}
