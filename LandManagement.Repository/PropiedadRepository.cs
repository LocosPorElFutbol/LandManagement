using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class PropiedadRepository: IPropiedad<tbpropiedad>
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

        public void Create(tbpropiedad entity)
        {
            try
            {
                Contexto = new landmanagementbdEntities();
                Contexto.CreateObjectSet<tbpropiedad>().AddObject(entity);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                //throw new ExcepcionRepository();
                throw ex;
            }
        }

        public void Create(tbpropiedad entity, tbcliente cliente)
        {
            try
            {
                using (var ctx = new landmanagementbdEntities())
                {
                    tbcliente cli = ctx.tbcliente.FirstOrDefault(c => c.cli_id == cliente.cli_id);
                    entity.tbcliente.Add(cli);

                    ctx.CreateObjectSet<tbpropiedad>().AddObject(entity);
                    ctx.SaveChanges();
                }
                ////Contexto = new landmanagementbdEntities();

                //Contexto.tbcliente.Attach(cliente);
                //entity.tbcliente.Add(cliente);
                
                //Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                //throw new ExcepcionRepository();
                throw ex;
            }
        }

        public void Update(tbpropiedad entity)
        {
            try
            {
                EntityKey key = Contexto.CreateEntityKey(
                    Contexto.CreateObjectSet<tbpropiedad>().EntitySet.Name, entity);
                tbpropiedad entityAux = null;
                entityAux = (tbpropiedad)Contexto.GetObjectByKey(key);

                Contexto.CreateObjectSet<tbpropiedad>().ApplyCurrentValues(entity);
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

        public void Delete(tbpropiedad entity)
        {
            try
            {
                tbpropiedad p = (tbpropiedad)this.GetElement(entity);
                Contexto.tbpropiedad.DeleteObject(p);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
                //throw new ExcepcionRepository();
            }
        }

        public object GetElement(tbpropiedad entity)
        {
            tbpropiedad salida = Contexto.tbpropiedad.Include("tbcliente")
                                                     .Include("tboperaciones")
                                                     .Include("tbservicios")
                                                     .Include("tbtipopropiedad")
                .Where(p => p.pro_id == entity.pro_id).SingleOrDefault<tbpropiedad>();

            return salida;

            //EntityKey key = Contexto.CreateEntityKey(
            //   Contexto.CreateObjectSet<tbpropiedad>().EntitySet.Name, entity);
            //try
            //{
            //    tbpropiedad salida = (tbpropiedad)Contexto.GetObjectByKey(key);
            //    return salida;
            //}
            //catch (ObjectNotFoundException)
            //{
            //    throw new ExcepcionRepository();
            //}
        }

        public object GetList()
        {
            return Contexto.tbpropiedad.Include("tbcliente")
                                        .Include("tbtipopropiedad").ToList();
        }

        public object GetList(int[] ids)
        {
            return Contexto.tbpropiedad.Include("tbcliente")
                                        .Include("tbtipopropiedad")
                                        .Where(x => !ids.Contains(x.pro_id)).ToList();
        }

        public object GetPropiedadesPorCliente(tbcliente cliente)
        {
            try
            {
                var salida = (from p in Contexto.tbpropiedad.Include("tbcliente")
                              where p.tbcliente.Any(c => c.cli_id == cliente.cli_id)
                              select p).ToList<tbpropiedad>();

                return salida;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
