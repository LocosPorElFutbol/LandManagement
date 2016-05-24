using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class OperacionRepository: IOperacion<tboperaciones>
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

        public void Create(tboperaciones entity)
        {
            try
            {
                Contexto = new landmanagementbdEntities();
                Contexto.CreateObjectSet<tboperaciones>().AddObject(entity);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                //throw new ExcepcionRepository();
                throw ex;
            }
        }

        public void Update(tboperaciones entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(tboperaciones entity)
        {
            try
            {
                tboperaciones o = (tboperaciones)this.GetElementByKey(entity);
                Contexto.tboperaciones.DeleteObject(o);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetElementByKey(tboperaciones entity)
        {
            try
            {
                EntityKey key = Contexto.CreateEntityKey(
                    Contexto.CreateObjectSet<tboperaciones>().EntitySet.Name, entity);

                return Contexto.GetObjectByKey(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetElement(tboperaciones entity)
        {
            try
            {
                tboperaciones salida = (tboperaciones)Contexto.tboperaciones.Include("tbalquilada")
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

        public object GetList()
        {
            return Contexto.tboperaciones.Include("tbalquilada")
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
            return Contexto.tboperaciones.Include("tbalquilada")
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
    }
}
