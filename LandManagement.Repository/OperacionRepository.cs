using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class OperacionRepository: BaseRepository<tboperaciones>
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

        //public void Create(tboperaciones entity)
        //{
        //    try
        //    {
        //        ContextoLocal = new landmanagementbdEntities();
        //        ContextoLocal.CreateObjectSet<tboperaciones>().AddObject(entity);
        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        //throw new ExcepcionRepository();
        //        throw ex;
        //    }
        //}

        public override void Update(tboperaciones entity)
        {
            throw new NotImplementedException();
        }

        //public void Delete(tboperaciones entity)
        //{
        //    try
        //    {
        //        tboperaciones o = (tboperaciones)this.GetElementByKey(entity);
        //        ContextoLocal.tboperaciones.DeleteObject(o);
        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public object GetElementByKey(tboperaciones entity)
        //{
        //    try
        //    {
        //        EntityKey key = ContextoLocal.CreateEntityKey(
        //            ContextoLocal.CreateObjectSet<tboperaciones>().EntitySet.Name, entity);

        //        return ContextoLocal.GetObjectByKey(key);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public override object GetElement(tboperaciones entity)
        {
            try
            {
                tboperaciones salida = (tboperaciones)ContextoLocal.tboperaciones.Include("tbalquilada")
                                         .Include("tbclienteoperacion")
                                         .Include("tbenalquiler")
                                         .Include("tbencuesta")
                                         .Include("tbenventa")
                                         .Include("tbpropiedad")
                                         .Include("tbpropiedad.tbtipopropiedad")
                                         .Include("tbreservaalquiler")
                                         .Include("tbreservaventa")
                                         .Include("tbtasacion")
                                         .Include("tbusuario")
                                         .Include("tbventa")
                                         .Where(x => x.ope_id == entity.ope_id).FirstOrDefault();
                return salida;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override object GetList()
        {
            return ContextoLocal.tboperaciones.Include("tbalquilada")
                                         .Include("tbclienteoperacion")
                                         .Include("tbenalquiler")
                                         .Include("tbencuesta")
                                         .Include("tbenventa")
                                         .Include("tbpropiedad")
                                         .Include("tbpropiedad.tbtipopropiedad")
                                         .Include("tbreservaalquiler")
                                         .Include("tbreservaventa")
                                         .Include("tbtasacion")
                                         .Include("tbusuario")
                                         .Include("tbventa").ToList();
        }

        public object GetListByPropiedadId(int _idPropiedad)
        {
            return ContextoLocal.tboperaciones.Include("tbalquilada")
                                         .Include("tbclienteoperacion")
                                         .Include("tbenalquiler")
                                         .Include("tbencuesta")
                                         .Include("tbenventa")
                                         .Include("tbpropiedad")
                                         .Include("tbpropiedad.tbtipopropiedad")
                                         .Include("tbreservaalquiler")
                                         .Include("tbreservaventa")
                                         .Include("tbtasacion")
                                         .Include("tbusuario")
                                         .Include("tbventa")
                                         .Where(x => x.tbpropiedad.pro_id == _idPropiedad)
                                         .ToList();
        }

        //public object GetList(Func<tboperaciones, bool> funcion)
        //{
        //    try
        //    {
        //        return ContextoLocal.tboperaciones.Where(funcion).ToList<tboperaciones>();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        
        //}
    }
}
