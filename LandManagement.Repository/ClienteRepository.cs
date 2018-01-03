using LandManagement.Entities;
using LandManagement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Transactions;

namespace LandManagement.Repository
{
    public class ClienteRepository: ICliente<tbcliente>
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
                Contexto.Connection.Open();

                using (var transactionScope = new TransactionScope())
                {
                    Contexto.CreateObjectSet<tbcliente>().AddObject(entity);
                    Contexto.SaveChanges();

                    transactionScope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Contexto.Connection.Close();
            }
        }
        
        public void Update(tbcliente entity)
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

        public void Update(tbcliente entity, tbpropiedad propiedad)
        {
            try
            {
                using (var ctx = new landmanagementbdEntities())
                {
                    tbcliente cli = ctx.tbcliente.FirstOrDefault(c => c.cli_id == entity.cli_id);
                    tbpropiedad prop = ctx.tbpropiedad.FirstOrDefault(p => p.pro_id == propiedad.pro_id);
                    cli.tbpropiedad.Add(prop);
                    ctx.SaveChanges();
                }

                //Contexto = new landmanagementbdEntities();
                //Contexto.tbpropiedad.Attach(propiedad);
                //entity.tbpropiedad.Add(propiedad);

                //Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                //throw new ExcepcionRepository();
                throw ex;
            }
        }

        public void Delete(tbcliente entity)
        {
            try
            {
                tbcliente m = (tbcliente)this.GetElement(entity);
                Contexto.tbcliente.DeleteObject(m);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(tbcliente entity, tbpropiedad propiedad)
        {
            try
            {
                using (var ctx = new landmanagementbdEntities())
                {
                    tbcliente cli = ctx.tbcliente.FirstOrDefault(c => c.cli_id == entity.cli_id);
                    tbpropiedad prop = ctx.tbpropiedad.FirstOrDefault(p => p.pro_id == propiedad.pro_id);
                    cli.tbpropiedad.Remove(prop);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //throw new ExcepcionRepository();
                throw ex;
            }
        }

        public void Delete(tbcliente entity, tbcliente familiar)
        {
            try
            {
                using (var ctx = new landmanagementbdEntities())
                {
                    tbcliente cli = ctx.tbcliente.FirstOrDefault(c => c.cli_id == entity.cli_id);
                    tbcliente fam = ctx.tbcliente.FirstOrDefault(f => f.cli_id == familiar.cli_id);
                    cli.tbcliente1.Remove(fam);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //throw new ExcepcionRepository();
                throw ex;
            }
        }

        public object GetElementNew(tbcliente entity)
        {
            try
            {
                tbcliente clienteSalida = new tbcliente();
                clienteSalida = (from c in Contexto.tbcliente
                                 where c.cli_id == entity.cli_id
                                 select c).FirstOrDefault();

                clienteSalida.tbpropiedad = new List<tbpropiedad>();
                clienteSalida.tbdomicilio = new List<tbdomicilio>();
                clienteSalida.tbcliente1 = new List<tbcliente>();
                clienteSalida.tbcliente2 = new tbcliente();

                //Cargo propiedades
                PropiedadRepository propiedadRepository = new PropiedadRepository();
                clienteSalida.tbpropiedad = 
                    (List<tbpropiedad>)propiedadRepository.GetPropiedadesPorCliente(entity);

                //Cargo domicilios
                DomicilioRepository domicilioRepository = new DomicilioRepository();
                clienteSalida.tbdomicilio
                    = (List<tbdomicilio>)domicilioRepository.GetDomicilioPorCliente(entity);

                //Cargo tipo familiar
                TipoFamiliarRepository tipoFamiliarRepository = new TipoFamiliarRepository();
                tbtipofamiliar familiar = new tbtipofamiliar(){tif_id = clienteSalida.tif_id};
                clienteSalida.tbtipofamiliar = new tbtipofamiliar();
                clienteSalida.tbtipofamiliar = (tbtipofamiliar)tipoFamiliarRepository.GetElement(familiar);

                //Cargo lista de hijos
                List<tbcliente> hijos = this.obtenerHijos(entity).ToList<tbcliente>();

                if (hijos.Count() > 0)
                    foreach (var obj in hijos)
                        clienteSalida.tbcliente1.Add((tbcliente)this.GetElement(obj));
                   
                return clienteSalida;
            }
            catch (ObjectNotFoundException)
            {
                throw new ExcepcionRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private IEnumerable<tbcliente> obtenerHijos(tbcliente cliente)
        {
            List<tbcliente> listaHijos = new List<tbcliente>();

            var hijos = (from c in Contexto.tbcliente.Include("tbtipofamiliar")
                                 where c.cli_id_padre == cliente.cli_id
                                 select c).ToList<tbcliente>();

            foreach (var obj in hijos)
                listaHijos.Add(obj);
            
            return listaHijos;
        }

        private tbcliente obtenerPadre(tbcliente cliente)
        {
            tbcliente padre = new tbcliente();
            
            padre = (from c in Contexto.tbcliente
                         where c.cli_id == cliente.cli_id_padre
                         select c).FirstOrDefault();

            //if (padre.cli_id_padre != null)
            //    padre.tbcliente2 = obtenerPadre(padre);

            return padre;
        }

        private tbcliente ArmarArbol(tbcliente entity)
        {
            List<tbcliente> listaHijos = obtenerHijos(entity) as List<tbcliente>;

            if (listaHijos.Count() > 0)
            {
                entity.tbcliente1 = new List<tbcliente>();
                
                foreach (var obj in listaHijos)
                {
                    var l = this.obtenerHijos(obj) as List<tbcliente>;

                    if (l.Count() > 0)
                        ArmarArbol(obj);

                    entity.tbcliente1.Add(obj);
                }
            }

            return entity;
        }

        public tbcliente ArmarArbolGenealogico(tbcliente entity)
        {
            try
            {
                tbcliente raiz = new tbcliente();

                if (entity.cli_id_padre != null)
                    raiz = obtenerRaiz(entity);
                else
                    raiz = entity;

                raiz = ArmarArbol(raiz);

                return raiz;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private tbcliente obtenerRaiz(tbcliente entity)
        {
            tbcliente raiz = (from c in Contexto.tbcliente.Include("tbtipofamiliar")
                                where c.cli_id == entity.cli_id_padre
                                select c).FirstOrDefault();

            if (raiz.cli_id_padre != null)
                obtenerRaiz(raiz);
                
            return raiz;
        }


        public object GetElement(tbcliente entity)
        {
            try
            {
                tbcliente salida = (from c in Contexto.tbcliente.Include("tbpropiedad")
                                                                .Include("tbdomicilio")
                                                                .Include("tbtipofamiliar")
                                    where c.cli_id == entity.cli_id
                                    select c).FirstOrDefault();

                //Cargo lista de hijos
                List<tbcliente> hijos = this.obtenerHijos(entity).ToList<tbcliente>();

                if (hijos.Count() > 0)
                {
                    salida.tbcliente1 = new List<tbcliente>();
                    foreach (var obj in hijos)
                        salida.tbcliente1.Add((tbcliente)this.GetElement(obj));
                }

                //Cargo padre
                if (salida.cli_id_padre != null)
                    salida.tbcliente2 = obtenerPadre(salida);

                return salida;
            }
            catch (ObjectNotFoundException)
            {
                throw new ExcepcionRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetElementOLD(tbcliente entity)
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object ValidarExitenciaByDni(tbcliente entity)
        {
            var cliente = (from c in Contexto.tbcliente
                          where c.cli_numero_documento == entity.cli_numero_documento
                          select c).FirstOrDefault();
            
            return cliente;
        }

        public object GetList()
        {
            //return Contexto.CreateObjectSet<tbcliente>().ToList();
            return Contexto.tbcliente.Include("tbtipofamiliar")
                .OrderBy(x => x.cli_nombre).ToList();
        }

        public object GetList(Func<tbcliente, bool> _whereClausule)
        {
            try
            {
                return Contexto.tbcliente.Where(_whereClausule).ToList<tbcliente>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetClientePorPropiedad(tbpropiedad propiedad)
        {
            try
            {
                var salida = (from p in Contexto.tbcliente.Include("tbpropiedad")
                              where p.tbpropiedad.Any(o => o.pro_id == propiedad.pro_id)
                              select p).ToList<tbcliente>();

                return salida;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetClientesByIdCategoria(List<int> _idsCategoria)
        {
            try
            {
                CategoriaRepository categoriaRepository = new CategoriaRepository();

                //Busco en categorias los clientes correspondientes a las categorias
                //enviadas por parametro
                List<tbcategoria> idClientesByIdCategoria =
                    (List<tbcategoria>)categoriaRepository.GetIdClientesByIdCategoria(_idsCategoria);

                //Obtengo solo los ids del cliente
                List<int> ids = idClientesByIdCategoria.Select(x => x.cli_id).ToList();

                //Traigo los clientes matcheando con los ids de la consulta anterior.
                var clientesByCategoria = from c in Contexto.tbcliente
                                          where ids.Contains(c.cli_id)
                                          select c;

                return clientesByCategoria.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
