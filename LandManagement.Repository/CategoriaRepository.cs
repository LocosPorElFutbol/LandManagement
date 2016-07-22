using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandManagement.Entities;

namespace LandManagement.Repository
{
    public class CategoriaRepository
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

        public object GetListByClienteId(tbcliente _cliente)
        {
            try
            {
                var listaCategorias = (from co in Contexto.tbclienteoperacion
                                 join tc in Contexto.tbsystipocliente on co.stc_id equals tc.stc_id
                                 join op in Contexto.tboperaciones on co.ope_id equals op.ope_id
                                 where co.cli_id == _cliente.cli_id
                                 select new tbcategoria() { cat_id = co.stc_id, cat_descripcion = tc.stc_descripcion, cat_fecha = op.ope_fecha })
                                    .OrderByDescending(x => x.cat_fecha);

                return listaCategorias.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetListaCategorias()
        {
            try
            {
                var listaCategorias = (from stc in Contexto.tbsystipocliente
                                       select new tbcategoria() { cat_id = stc.stc_id, cat_descripcion = stc.stc_descripcion })
                                        .OrderBy(x => x.cat_descripcion);

                return listaCategorias.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetClientesByIdCategoria(List<int> idsCategoria)
        {
            try
            {
                ClienteOperacionRepository clienteOperacionRepository = new ClienteOperacionRepository();
                List<tbclienteoperacion> clientesMayor = 
                    (List<tbclienteoperacion>)clienteOperacionRepository.GetList();

                //var filtro = from 
                //var clientesConCategoriaYFecha = from o in Contexto.tboperaciones
                //                                 join co in Contexto.tbclienteoperacion on o.ope_id equals co.ope_id
                //                                 select new tbcategoria { cli_id = co.cli_id, cat_id = co.stc_id, ope_id = co.ope_id, cat_fecha = o.ope_fecha };



                //var clientesUltimaCategoria = clientesConCategoriaYFecha.GroupBy(x => x.cli_id)
                //                              .Select(x => x.OrderByDescending(s => s.cat_fecha)
                //                              .FirstOrDefault());

                //string sa = (clientesUltimaCategoria as System.Data.Objects.ObjectQuery).ToTraceString();

                //var clientesUltimaCategoria = from cc in clientesConCategoriaYFecha
                //                              group cc by cc.cli_id into g
                //                              select g.OrderByDescending(x => x.cat_fecha).First();

                //var clientes = from cuc in clientesUltimaCategoria
                //               join c in Contexto.tbcliente on cuc.cli_id equals c.cli_id
                //               select c;


                //var clientes = (from cuc in clientesUltimaCategoria
                //               join c in Contexto.tbcliente on c.cli_id equals cuc.cli_id
                //               select new { cli_id = cuc.cli_id, stc_id = cuc.stc_id, ope_id = cuc.ope_id };

                //var clientes2 = (from cc in Contexto.tbclienteoperacion
                //                from cuc in clientesUltimaCategoria
                //                where cc.cli_id == cuc.cli_id
                //                && cc.ope_id == cuc.ope_id
                //                && cc.stc_id == cuc.stc_id
                //                select cc).ToList();
                                    

                //List<tbclienteoperacion> c = new List<tbclienteoperacion>();
                //foreach (var obj in clientes)
                //{
                //    c.Add(new tbclienteoperacion() { cli_id = obj.cli_id, ope_id = obj.ope_id, stc_id = obj.stc_id});
                //}

                //var clientesConCategoria = (from co in Contexto.tbclienteoperacion
                //                            join c in Contexto.tbcliente on co.cli_id equals c.cli_id
                //                            join o in Contexto.tboperaciones on co.ope_id equals o.ope_id
                //                            select new { cli_id = co.cli_id, stc_id = co.stc_id, ope_id = o.ope_id, ope_fecha = o.ope_fecha });

                //var clientesUltimaCategoria = from cc in clientesConCategoria
                //                              group cc by cc.cli_id into g
                //                              select g.OrderByDescending(x => x.ope_fecha).FirstOrDefault();

                //var clientes = from cuc in clientesUltimaCategoria
                //               select new tbclienteoperacion { cli_id = cuc.cli_id, stc_id = cuc.stc_id, ope_id = cuc.ope_id };




                //select new tbcategoria { cli_id = g.Key, cat_fecha = g.Max(x => x.ope_fecha) };

                //var clientesPorCategoria = from lc in clientesConCategoria
                //                           where idsCategoria.Contains(lc.stc_id)
                //                           select new { lc.cli_id, lc.stc_id, lc.ope_fecha };



                //var listaClientes = from cc in clientesPorCategoria
                //                    join c in Contexto.tbcliente on cc.cli_id equals c.cli_id
                //                    select c;

                return clientesMayor.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
