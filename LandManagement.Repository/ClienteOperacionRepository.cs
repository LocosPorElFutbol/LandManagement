using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class ClienteOperacionRepository : BaseRepository<tbclienteoperacion>
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

        public override void Create(tbclienteoperacion entity)
        {
            try
            {
                using (var ctx = new landmanagementbdEntities())
                {
                    tbcliente cli = ctx.tbcliente.FirstOrDefault(c => c.cli_id == entity.cli_id);
                    tbsystipocliente stc = ctx.tbsystipocliente.FirstOrDefault(x => x.stc_id == entity.stc_id);
                    tboperaciones ope = ctx.tboperaciones.FirstOrDefault(x => x.ope_id == entity.ope_id);

                    tbclienteoperacion clienteOperacion = new tbclienteoperacion()
                    {cli_id = cli.cli_id,
                    ope_id = ope.ope_id,
                    stc_id = stc.stc_id};

                    ope.tbclienteoperacion.Add(clienteOperacion);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override void Update(tbclienteoperacion entity)
        {
            throw new NotImplementedException();
        }

		//public void Delete(tbclienteoperacion entity)
		//{
		//    try
		//    {
		//        tbclienteoperacion m = (tbclienteoperacion)this.GetElement(entity);
		//        ContextoLocal.tbclienteoperacion.DeleteObject(m);
		//        ContextoLocal.SaveChanges();
		//    }
		//    catch (Exception ex)
		//    {
		//        throw ex;
		//    }
		//}

		//public object GetElement(tbclienteoperacion entity)
		//{
		//    throw new NotImplementedException();
		//}

		//public object GetElement(tbclienteoperacion entity)
		//{
		//	try
		//	{
		//		EntityKey key = ContextoLocal.CreateEntityKey(ContextoLocal.CreateObjectSet<tbclienteoperacion>().EntitySet.Name, entity);
		//		return ContextoLocal.GetObjectByKey(key);
		//	}
		//	catch (Exception ex)
		//	{
		//		throw ex;
		//	}
		//}

		//public object GetList()
		//{
		//    return ContextoLocal.tbclienteoperacion.Include("tbcliente")
		//                                      .Include("tboperaciones")
		//                                      .Include("tbsystipocliente").ToList();
		//}

		public object GetListByIdOperacion(int _idOperacion)
        {
            try
            {
                return ContextoLocal.tbclienteoperacion.Where(x => x.ope_id == _idOperacion).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public object GetList(Func<tbclienteoperacion, bool> _whereClausule)
        //{
        //    try
        //    {
        //        return ContextoLocal.tbclienteoperacion.Where(_whereClausule).ToList<tbclienteoperacion>();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
