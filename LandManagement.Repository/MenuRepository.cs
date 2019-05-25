using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandManagement.Entities;
using LandManagement.Interface;
using System.Data;

namespace LandManagement.Repository
{
    public class MenuRepository : IMenu<tbmenu>
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

        public void Create(tbmenu entity)
        {
            try
            {
                Contexto = new landmanagementbdEntities();
                Contexto.CreateObjectSet<tbmenu>().AddObject(entity);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                //throw new ExcepcionRepository();
                throw ex;
            }
        }

        public void Update(tbmenu entity)
        {
            try
            {
                EntityKey key = Contexto.CreateEntityKey(
                    Contexto.CreateObjectSet<tbmenu>().EntitySet.Name, entity);
                tbmenu entityAux = null;
                entityAux = (tbmenu)Contexto.GetObjectByKey(key);

                Contexto.CreateObjectSet<tbmenu>().ApplyCurrentValues(entity);
                Contexto.ObjectStateManager.GetObjectStateEntry(entityAux).ChangeState(EntityState.Modified);
                Contexto.ObjectStateManager.ChangeObjectState(entityAux, EntityState.Modified);

                Contexto.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
                //throw new ExcepcionRepository();
            }
        }

        public void Delete(tbmenu entity)
        {
            try
            {
                tbmenu m = (tbmenu)this.GetElement(entity);
                Contexto.tbmenu.DeleteObject(m);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
                //throw new ExcepcionRepository();
            }
        }

        public object GetElement(tbmenu entity)
        {
            EntityKey key = Contexto.CreateEntityKey(
                Contexto.CreateObjectSet<tbmenu>().EntitySet.Name, entity);
            try
            {
                tbmenu salida = (tbmenu)Contexto.GetObjectByKey(key);
                return salida;
            }
            catch (ObjectNotFoundException)
            {
                throw new ExcepcionRepository();
            }
        }

        public object GetList()
        {
            //return Contexto.CreateObjectSet<tbmenu>().ToList();
            return Contexto.tbmenu.Include("tbusuario").ToList();
        }

        public object GetList(Func<tbmenu, bool> funcion)
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
                return Contexto.tbmenu.Include("tbusuario").Where(funcion).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
