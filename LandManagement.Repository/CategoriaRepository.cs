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

        private object GetUltimaCategoriaDeClientes()
        {
            //Traigo la fecha de operacion a todos los registros de tbclienteoperacion
            var clientesConCategoriaYFecha = from o in Contexto.tboperaciones
                                             join co in Contexto.tbclienteoperacion on o.ope_id equals co.ope_id
                                             select new tbcategoria { cli_id = co.cli_id, cat_id = co.stc_id, ope_id = co.ope_id, cat_fecha = o.ope_fecha };

            //Filtro por ultima fecha de operacion al cliente
            var maximos = from ccyf in clientesConCategoriaYFecha
                          group ccyf by ccyf.cli_id into g
                          select new { cli_id = g.Key, fecha = g.Max(x => x.cat_fecha) };

            //Obtengo el registro de tbclienteoperacion con la ultima fecha de operacion
            //realizada por el cliente (ultima categoría del cliente)
            var clientesUltimaCategoria = from co in clientesConCategoriaYFecha
                                          from cc in maximos
                                          where co.cli_id == cc.cli_id
                                          && co.cat_fecha == cc.fecha
                                          select co;

            //devuelvo lista de tbcategorias
            return clientesUltimaCategoria.ToList();
        }

        /// <summary>
        /// Retorna los ids del cliente en base a los ids de categoría enviados por parametro.
        /// Nota: Este metodo se invoca desde clienteBusiness, que es el encargado de retornar
        /// la lista de clientes.
        /// </summary>
        /// <param name="_idsCategoria">Lista de enteros correspondientes a las categorias.</param>
        /// <returns></returns>
        public object GetIdClientesByIdCategoria(List<int> _idsCategoria)
        {
            try
            {
                List<tbcategoria> clientesUltimaCategoria = 
                    (List<tbcategoria>)this.GetUltimaCategoriaDeClientes();

                var idClientesByCategoria = from cuc in clientesUltimaCategoria
                                          where _idsCategoria.Contains(cuc.cat_id)
                                          select cuc;

                return idClientesByCategoria.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
