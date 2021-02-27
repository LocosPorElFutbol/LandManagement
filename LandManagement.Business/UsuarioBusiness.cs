using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandManagement.Repository;
using LandManagement.Entities;

namespace LandManagement.Business
{
    public class UsuarioBusiness
    {
        private UsuarioRepository _UsuarioRepository;
        private MenuBusiness menuBusiness;
        public UsuarioBusiness()
        {
            this._UsuarioRepository = new UsuarioRepository();
            menuBusiness = new MenuBusiness();
        }

        public void Create(tbusuario tbUsuario)
        {
            _UsuarioRepository.Create(tbUsuario);
        }

        public void UpdateNew(tbusuario tbUsuario)
        {
            _UsuarioRepository.Update(tbUsuario);
        }

        [Obsolete("Este metodo se deprecará, evitar su utilización. El nuevo nombre es UpdateNew(tbusuario entity). FALTA ACTUALIZAR COLECCION DE MENUES DE CADA USUARIO!!!")]
        public void Update(tbusuario tbUsuario)
        {
            _UsuarioRepository.UpdateOld(tbUsuario);
        }

        public void Delete(tbusuario tbUsuario)
        {
            _UsuarioRepository.Delete(tbUsuario);
        }

        public object GetElement(tbusuario tbUsuario)
        {
            return _UsuarioRepository.GetElement(tbUsuario);
        }

        public object GetList()
        {
            return _UsuarioRepository.GetList();
        }

        public object GetList(Func<tbusuario, bool> funcion)
        {
            return _UsuarioRepository.GetList(funcion);
        }

        public tbusuario ValidacionUsuarioPassword(string userName, string password)
        {
            //Obtengo usuario si coinciden loginName y pass
            Func<tbusuario, bool> funcion = x => x.usu_nombre_login == userName && x.usu_password == password;
            tbusuario usuario = ((List<tbusuario>)this.GetList(funcion)).FirstOrDefault();
            return usuario;
        }

        //REFACTORING ARMADO DE MENU
        //FALTA REFACTORIZAR CLIENTE
        //FUNCIONO PARA LOS DOS USUARIOS; FALTA REFACTORIZAR EL ARMADO DEL MENU STRIP DEL CLIENTE
        public List<tbmenu> CargarMenuAsignadoAUsuario(tbusuario usuario)
        {
            //Filtro para obtener el menu asignado a un usuario
            Func<tbmenu, bool> funcionBusqueda = x => x.tbusuario.Any(u => u.usu_id == usuario.usu_id);
            
            List<tbmenu> listaMenu = (List<tbmenu>)menuBusiness.GetList(funcionBusqueda);
            List<tbmenu> listaMenuSalida = new List<tbmenu>();

            //este listado va a contener unicamente perfiles (hojas).
            foreach (tbmenu menu in listaMenu)
                ArmoMenuBD(menu, listaMenuSalida);
            
            return listaMenuSalida;
        }

        private bool listaSalidaContieneAPadreDe(tbmenu menu, List<tbmenu> listaMenuSalida)
        {
            foreach (tbmenu m in listaMenuSalida)
            {
                if (m.men_id == menu.men_id_padre)
                {
                    m.tbmenu1.Add(menu);
                    return true;
                }
                else
                {
                    if (m.tbmenu1.Count() > 0)
                        listaSalidaContieneAPadreDe(menu, (List<tbmenu>)m.tbmenu1);
                }
            }
            return false;
        }

        private void ArmoMenuBD(tbmenu menu, List<tbmenu> listaMenuSalida)
        {
            tbmenu padre = null;
            if (!this.listaSalidaContieneAPadreDe(menu, listaMenuSalida))
            {
                padre = this.ObtenerPadreMenu(menu.men_id_padre.Value);
                padre.tbmenu1 = new List<tbmenu>();
                padre.tbmenu1.Add(menu);
             
                if (padre.men_id_padre != null)
                    ArmoMenuBD(padre, listaMenuSalida);
                else
                    listaMenuSalida.Add(padre);
            }
        }

        private tbmenu ObtenerPadreMenu(int idPadre)
        {
            tbmenu menuPadre = new tbmenu() { men_id = idPadre };
            return (tbmenu)menuBusiness.GetElement(menuPadre);
        }
        //REFACTORING ARMADO DE MENU
        //FALTA REFACTORIZAR CLIENTE
    }
}
