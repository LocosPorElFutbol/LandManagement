using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandManagement.Interface;
using LandManagement.Entities;
using System.Data;

namespace LandManagement.Repository
{
    public class TasacionRepository: ITasacion<tbtasacion>
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

        public void Create(tbtasacion entity)
        {
            try
            {
                Contexto = new landmanagementbdEntities();
                Contexto.CreateObjectSet<tbtasacion>().AddObject(entity);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                //throw new ExcepcionRepository();
                throw ex;
            }
        }

        public void Update(tbtasacion entity)
        {
            try
            {
                EntityKey key = Contexto.CreateEntityKey(
                    Contexto.CreateObjectSet<tbtasacion>().EntitySet.Name, entity);
                tbtasacion entityAux = null;
                entityAux = (tbtasacion)Contexto.GetObjectByKey(key);

                Contexto.CreateObjectSet<tbtasacion>().ApplyCurrentValues(entity);
                Contexto.ObjectStateManager.GetObjectStateEntry(entityAux).ChangeState(EntityState.Modified);
                Contexto.ObjectStateManager.ChangeObjectState(entityAux, EntityState.Modified);

                Contexto.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
                //throw new ExcepcionRepository();
            }
        }

        public void Delete(tbtasacion entity)
        {
            try
            {
                tbtasacion o = (tbtasacion)this.GetElement(entity);
                Contexto.tbtasacion.DeleteObject(o);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
                //throw new ExcepcionRepository();
            }
        }

        public object GetElement(tbtasacion entity)
        {
            EntityKey key = Contexto.CreateEntityKey(
                Contexto.CreateObjectSet<tbtasacion>().EntitySet.Name, entity);
            try
            {
                tbtasacion salida = (tbtasacion)Contexto.GetObjectByKey(key);
                return salida;
            }
            catch (ObjectNotFoundException)
            {
                throw new ExcepcionRepository();
            }
        }

        public object GetElementByKey(tbtasacion entity)
        {
            try
            {
                EntityKey key = Contexto.CreateEntityKey(
                    Contexto.CreateObjectSet<tbtasacion>().EntitySet.Name, entity);

                return Contexto.GetObjectByKey(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetList()
        {
            return Contexto.tbtasacion.ToList();
        }
    }
}
