using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class PropiedadRepository: BaseRepository<tbpropiedad>
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

        //public void Create(tbpropiedad entity)
        //{
        //    try
        //    {
        //        ContextoLocal = new landmanagementbdEntities();
        //        ContextoLocal.CreateObjectSet<tbpropiedad>().AddObject(entity);
        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        //throw new ExcepcionRepository();
        //        throw ex;
        //    }
        //}

        public void Create(tbpropiedad entity, tbcliente cliente)
        {
            try
            {
                using (var ctx = new landmanagementbdEntities())
                {
                    tbcliente cli = ctx.tbcliente.FirstOrDefault(c => c.cli_id == cliente.cli_id);
                    entity.tbcliente.Add(cli);

                    //ctx.CreateObjectSet<tbpropiedad>().AddObject(entity);
                    ctx.tbpropiedad.Add(entity);

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

        //public void Update(tbpropiedad entity)
        //{
        //    try
        //    {
        //        EntityKey key = ContextoLocal.CreateEntityKey(
        //            ContextoLocal.CreateObjectSet<tbpropiedad>().EntitySet.Name, entity);
        //        tbpropiedad entityAux = null;
        //        entityAux = (tbpropiedad)ContextoLocal.GetObjectByKey(key);

        //        ContextoLocal.CreateObjectSet<tbpropiedad>().ApplyCurrentValues(entity);
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

        //public void Delete(tbpropiedad entity)
        //{
        //    try
        //    {
        //        tbpropiedad p = (tbpropiedad)this.GetElement(entity);
        //        ContextoLocal.tbpropiedad.DeleteObject(p);
        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //        //throw new ExcepcionRepository();
        //    }
        //}

        public override object GetElement(tbpropiedad entity)
        {
            tbpropiedad salida = ContextoLocal.tbpropiedad.Include("tbcliente")
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

        public override object GetList()
        {
            return ContextoLocal.tbpropiedad.Include("tbcliente")
                                        .Include("tbtipopropiedad").ToList();
        }

        //public object GetList(Func<tbpropiedad, bool> _whereClausule)
        //{
        //    try
        //    {
        //        return ContextoLocal.tbpropiedad.Where(_whereClausule).ToList<tbpropiedad>();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public object GetList(int[] ids)
        {
            return ContextoLocal.tbpropiedad.Include("tbcliente")
                                        .Include("tbtipopropiedad")
                                        .Where(x => !ids.Contains(x.pro_id)).ToList();
        }

        public object GetPropiedadesPorCliente(tbcliente cliente)
        {
            try
            {
                var salida = (from p in ContextoLocal.tbpropiedad.Include("tbcliente")
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
