using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandManagement.Interface;
using LandManagement.Entities;
using System.Data;

namespace LandManagement.Repository
{
    public class DomicilioRepository: IDomicilio<tbdomicilio>
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

        public void Create(tbdomicilio entity)
        {
            try
            {
                Contexto = new landmanagementbdEntities();
                Contexto.CreateObjectSet<tbdomicilio>().AddObject(entity);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                //throw new ExcepcionRepository();
                throw ex;
            }
        }

        public void Update(tbdomicilio entity)
        {
            try
            {
                EntityKey key = Contexto.CreateEntityKey(
                    Contexto.CreateObjectSet<tbdomicilio>().EntitySet.Name, entity);
                tbdomicilio entityAux = null;
                entityAux = (tbdomicilio)Contexto.GetObjectByKey(key);

                Contexto.CreateObjectSet<tbdomicilio>().ApplyCurrentValues(entity);
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

        public void Delete(tbdomicilio entity)
        {
            try
            {
                tbdomicilio d = (tbdomicilio)this.GetElement(entity);
                Contexto.tbdomicilio.DeleteObject(d);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
                //throw new ExcepcionRepository();
            }
        }

        public object GetElement(tbdomicilio entity)
        {
            EntityKey key = Contexto.CreateEntityKey(
                Contexto.CreateObjectSet<tbdomicilio>().EntitySet.Name, entity);
            try
            {
                tbdomicilio salida = (tbdomicilio)Contexto.GetObjectByKey(key);
                return salida;
            }
            catch (ObjectNotFoundException)
            {
                throw new ExcepcionRepository();
            }
        }

        public object GetDomicilioPorCliente(tbcliente cliente)
        {
            try
            {
                var salida = (from d in Contexto.tbdomicilio
                              where d.cli_id == cliente.cli_id
                              select d).ToList<tbdomicilio>();

                return salida;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetList()
        {
            //return Contexto.CreateObjectSet<tbmenu>().ToList();
            return Contexto.tbdomicilio.ToList();
        }

		public object GetList(Func<tbdomicilio, bool> predicado)
		{
			return Contexto.tbdomicilio.Where(predicado).ToList();
		}
    }
}
