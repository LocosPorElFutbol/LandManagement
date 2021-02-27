using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandManagement.Interface;
using LandManagement.Entities;
using System.Data;

namespace LandManagement.Repository
{
    public class UsuarioRepository : BaseRepository<tbusuario>
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

        //public void Create(tbusuario entity)
        //{
        //    try
        //    {
        //        ContextoLocal = new landmanagementbdEntities();
        //        ContextoLocal.CreateObjectSet<tbusuario>().AddObject(entity);
        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void Update(tbusuario entity)
        //{
        //    try
        //    {
        //        EntityKey key =
        //            ContextoLocal.CreateEntityKey(ContextoLocal.CreateObjectSet<tbusuario>().EntitySet.Name, entity);

        //        tbusuario entityAux = (tbusuario)ContextoLocal.GetObjectByKey(key);

        //        ContextoLocal.CreateObjectSet<tbusuario>().ApplyCurrentValues(entity);
        //        ContextoLocal.ObjectStateManager.GetObjectStateEntry(entityAux).ChangeState(EntityState.Modified);
        //        ContextoLocal.ObjectStateManager.ChangeObjectState(entityAux, System.Data.EntityState.Modified);

        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public void UpdateOld(tbusuario entity)
        {
            try
            {
                Update(entity); //usaba la actualizacion de las lineas de abajo comentadas, ser llama a Update base y listo

                //Verifico si ya existe la entidad en el contexto
                //EntityKey key =
                //    ContextoLocal.CreateEntityKey(ContextoLocal.CreateObjectSet<tbusuario>().EntitySet.Name, entity);

                //tbusuario entityAux = null;
                //entityAux = (tbusuario)ContextoLocal.GetObjectByKey(key);

                //// Ya existe la entidad en el contexto, aplico los cambios
                //ContextoLocal.CreateObjectSet<tbusuario>().ApplyCurrentValues(entity);
                //ContextoLocal.ObjectStateManager.GetObjectStateEntry(entityAux).ChangeState(EntityState.Modified);
                //ContextoLocal.ObjectStateManager.ChangeObjectState(entityAux, System.Data.EntityState.Modified);

                // DBK 27/03/2012
                //Contexto.SaveChanges();

                //Actualizo relaciones con tbmenu
                var usuario = ContextoLocal.tbusuario.Include("tbmenu").Single(u => u.usu_id == entity.usu_id);
                var menues = (from m in ContextoLocal.tbmenu.ToList()
                              from mu in entity.tbmenu
                              where m.men_id == mu.men_id
                              select m).ToList();

                usuario.tbmenu.Clear();
                foreach (var m in menues)
                    usuario.tbmenu.Add(m);

                ContextoLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void Delete(tbusuario entity)
        //{
        //    try
        //    {
        //        tbusuario m = (tbusuario)this.GetElement(entity);
        //        ContextoLocal.tbusuario.DeleteObject(m);
        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public override object GetElement(tbusuario entity)
        {
            try
            {
                //TENIA UN ERROR CUANDO SE CARGABAN LAS GRILLAS DE PERMISOS
                //EL DE ABAJO FUNCIONA PERO HACE EL INCLUDE DE LOS MENU [REVISAR]
                //tbusuario salida = (from u in Contexto.tbusuario
                //                    where u.usu_id == entity.usu_id
                //                    select u).FirstOrDefault();
                
                //MEJORA MENU
                tbusuario salida = (from u in ContextoLocal.tbusuario.Include("tbmenu")
                                    where u.usu_id == entity.usu_id
                                    select u).FirstOrDefault();

                return salida;
            }
            catch (ObjectNotFoundException)
            {
                throw new ExcepcionRepository();
            }
        }

        //public object GetList()
        //{
        //    return ContextoLocal.CreateObjectSet<tbusuario>().ToList();
        //}

        //public object GetList(Func<tbusuario, bool> funcion)
        //{
        //    return ContextoLocal.tbusuario.Where(funcion).ToList();
        //}
    }
}
