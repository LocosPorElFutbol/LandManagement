using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandManagement.Entities;
using LandManagement.Interface;
using System.Data;

namespace LandManagement.Repository
{
    public class MenuRepository : BaseRepository<tbmenu>
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

        //public void Create(tbmenu entity)
        //{
        //    try
        //    {
        //        ContextoLocal = new landmanagementbdEntities();
        //        ContextoLocal.CreateObjectSet<tbmenu>().AddObject(entity);
        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        //throw new ExcepcionRepository();
        //        throw ex;
        //    }
        //}

        //public void Update(tbmenu entity)
        //{
        //    try
        //    {
        //        EntityKey key = ContextoLocal.CreateEntityKey(
        //            ContextoLocal.CreateObjectSet<tbmenu>().EntitySet.Name, entity);
        //        tbmenu entityAux = null;
        //        entityAux = (tbmenu)ContextoLocal.GetObjectByKey(key);

        //        ContextoLocal.CreateObjectSet<tbmenu>().ApplyCurrentValues(entity);
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

        //public void Delete(tbmenu entity)
        //{
        //    try
        //    {
        //        tbmenu m = (tbmenu)this.GetElement(entity);
        //        ContextoLocal.tbmenu.DeleteObject(m);
        //        ContextoLocal.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //        //throw new ExcepcionRepository();
        //    }
        //}

        //public object GetElement(tbmenu entity)
        //{
        //    EntityKey key = ContextoLocal.CreateEntityKey(
        //        ContextoLocal.CreateObjectSet<tbmenu>().EntitySet.Name, entity);
        //    try
        //    {
        //        tbmenu salida = (tbmenu)ContextoLocal.GetObjectByKey(key);
        //        return salida;
        //    }
        //    catch (ObjectNotFoundException)
        //    {
        //        throw new ExcepcionRepository();
        //    }
        //}

        //public object GetList()
        //{
        //    //return Contexto.CreateObjectSet<tbmenu>().ToList();
        //    return ContextoLocal.tbmenu.Include("tbusuario").ToList();
        //}

        public override object GetList(Func<tbmenu, bool> funcion)
        {
            try
            {
                //EJEMPLO DE COMO OBTENER MEDIANTE LINQ ELEMENTOS DE RELACIONES MANY TO MANY
                //int iduser= 2;
                //List<tbmenu> salida = (from m in Contexto.tbmenu
                //                        where m.tbusuario.Any(u => u.usu_id == iduser)
                //                        select m).ToList<tbmenu>();

                //OBTENER OBJETOS DE LA RELACION MANY TO MANY MEDIANTE UNA FUNCION
                //EN ESTE EJEMPLO TENGO QUE REALIZAR EL INCLUDE DE LA TABLA DE USAURIOS, MUCHO NO ME COPA
                return ContextoLocal.tbmenu.Include("tbusuario").Where(funcion).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
