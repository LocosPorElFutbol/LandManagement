using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class FamiliarRepository: BaseRepository<tbcliente>
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

        //public void Create(tbcliente entity)
        //{
        //    try
        //    {
        //        ContextoLocal = new landmanagementbdEntities();
        //        ContextoLocal.CreateObjectSet<tbcliente>().AddObject(entity);
        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        //throw new ExcepcionRepository();
        //        throw ex;
        //    }
        //}

        public void Create(tbcliente entity, tbcliente cliente)
        {
            try
            {
                ContextoLocal = new landmanagementbdEntities();

                ContextoLocal.tbcliente.Attach(cliente);
                entity.tbcliente2 = cliente;

                ContextoLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                //throw new ExcepcionRepository();
                throw ex;
            }
        }
        
        //public void Update(tbcliente entity)
        //{
        //    try
        //    {
        //        EntityKey key = ContextoLocal.CreateEntityKey(
        //            ContextoLocal.CreateObjectSet<tbcliente>().EntitySet.Name, entity);
        //        tbcliente entityAux = null;
        //        entityAux = (tbcliente)ContextoLocal.GetObjectByKey(key);

        //        ContextoLocal.CreateObjectSet<tbcliente>().ApplyCurrentValues(entity);
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

        //public void Delete(tbcliente entity)
        //{
        //    try
        //    {
        //        tbcliente c = (tbcliente)this.GetElement(entity);
        //        ContextoLocal.tbcliente.DeleteObject(c);
        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //        //throw new ExcepcionRepository();
        //    }
        //}

        public override object GetElement(tbcliente entity)
        {
            try
            {
                tbcliente salida = (from c in ContextoLocal.tbcliente.Include("tbpropiedad")
                                                                .Include("tbdomicilio")
                                                                .Include("tbcliente1")
                                                                .Include("tbtipofamiliar")
                                                                .Include("tbtitulocliente")
                                    where c.cli_id == entity.cli_id
                                    select c).FirstOrDefault();

                return salida;
            }
            catch (ObjectNotFoundException)
            {
                throw new ExcepcionRepository();
            }
        }

        public override object GetList()
        {
            return ContextoLocal.tbcliente.Include("tbcliente1").ToList();
        }

        public object GetFamiliaresPorCliente(tbcliente cliente)
        {
            try
            {
                var salida = (from p in ContextoLocal.tbcliente
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
