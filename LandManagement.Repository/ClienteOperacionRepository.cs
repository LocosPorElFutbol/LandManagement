using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class ClienteOperacionRepository : IClienteOperacion<tbclienteoperacion>
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

        public void Create(tbclienteoperacion entity)
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

        public void Update(tbclienteoperacion entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(tbclienteoperacion entity)
        {
            try
            {
                tbclienteoperacion m = (tbclienteoperacion)this.GetElementByKey(entity);
                Contexto.tbclienteoperacion.DeleteObject(m);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetElement(tbclienteoperacion entity)
        {
            throw new NotImplementedException();
        }

        public object GetElementByKey(tbclienteoperacion entity)
        {
            try
            {
                EntityKey key = Contexto.CreateEntityKey(Contexto.CreateObjectSet<tbclienteoperacion>().EntitySet.Name, entity);
                return Contexto.GetObjectByKey(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetList()
        {
            return Contexto.tbclienteoperacion.Include("tbcliente")
                                              .Include("tboperaciones")
                                              .Include("tbsystipocliente").ToList();
        }

        public object GetListByIdOperacion(int _idOperacion)
        {
            try
            {
                return Contexto.tbclienteoperacion.Where(x => x.ope_id == _idOperacion).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
