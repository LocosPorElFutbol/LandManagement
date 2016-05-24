using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class FamiliarRepository: IFamiliar<tbcliente>
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

        public void Create(tbcliente entity)
        {
            try
            {
                Contexto = new landmanagementbdEntities();
                Contexto.CreateObjectSet<tbcliente>().AddObject(entity);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                //throw new ExcepcionRepository();
                throw ex;
            }
        }

        public void Create(tbcliente entity, tbcliente cliente)
        {
            try
            {
                Contexto = new landmanagementbdEntities();

                Contexto.tbcliente.Attach(cliente);
                entity.tbcliente2 = cliente;

                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                //throw new ExcepcionRepository();
                throw ex;
            }
        }
        
        public void Update(tbcliente entity)
        {
            try
            {
                EntityKey key = Contexto.CreateEntityKey(
                    Contexto.CreateObjectSet<tbcliente>().EntitySet.Name, entity);
                tbcliente entityAux = null;
                entityAux = (tbcliente)Contexto.GetObjectByKey(key);

                Contexto.CreateObjectSet<tbcliente>().ApplyCurrentValues(entity);
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

        public void Delete(tbcliente entity)
        {
            try
            {
                tbcliente c = (tbcliente)this.GetElement(entity);
                Contexto.tbcliente.DeleteObject(c);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
                //throw new ExcepcionRepository();
            }
        }

        public object GetElement(tbcliente entity)
        {
            try
            {
                tbcliente salida = (from c in Contexto.tbcliente.Include("tbpropiedad")
                                                                .Include("tbdomicilio")
                                                                .Include("tbcliente1")
                                                                .Include("tbtipofamiliar")
                                    where c.cli_id == entity.cli_id
                                    select c).FirstOrDefault();

                return salida;
            }
            catch (ObjectNotFoundException)
            {
                throw new ExcepcionRepository();
            }
        }

        public object GetList()
        {
            return Contexto.tbcliente.Include("tbcliente1").ToList();
        }

        public object GetFamiliaresPorCliente(tbcliente cliente)
        {
            try
            {
                var salida = (from p in Contexto.tbcliente
                              where p.cli_id_padre == cliente.cli_id
                              select p).ToList<tbcliente>();

                return salida;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
