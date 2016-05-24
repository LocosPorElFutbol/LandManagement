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

        public void Update(tbusuario tbUsuario)
        {
            _UsuarioRepository.Update(tbUsuario);
        }

        public void Delete(tbusuario tbUsuario)
        {
            _UsuarioRepository.Delete(tbUsuario);
        }

        public object GetElement(tbusuario tbUsuario)
        {
            return _UsuarioRepository.GetElement(tbUsuario);
        }

        public object GetElementByLoginName(tbusuario pUsuario)
        {
            return _UsuarioRepository.GetElementByLoginName(pUsuario);
        }

        public object GetList()
        {
            return _UsuarioRepository.GetList();
        }

        public tbusuario ValidacionUsuarioPassword(tbusuario usuario, string password)
        {
            tbusuario usuarioObtenido = new tbusuario();
            usuarioObtenido = (tbusuario)this.GetElementByLoginName(usuario);

            if (usuarioObtenido != null)
                if (usuarioObtenido.usu_password == password)
                    return usuarioObtenido;

            return null;
        }

        public List<tbmenu> CargarMenuAsignadoAUsuario(tbusuario usuario)
        {
            List<tbmenu> listaMenu = new List<tbmenu>();
            
            if (usuario.tbmenu.Count > 0)
            {
                foreach (var m in usuario.tbmenu)
                {
                    tbmenu menuCompleto = CargoPadre(m);

                    if (listaMenu.Count > 0)
                    {
                        listaMenu = EsHermano(menuCompleto, listaMenu);
                            //if (this.EsHermano(menuCompleto, listaMenu))
                            //    listaMenu.Add(menuCompleto);
                    }
                    else
                        listaMenu.Add(menuCompleto);
                }
            } 

            return listaMenu;
        }

        private tbmenu CargoPadre(tbmenu menu)
        {
            tbmenu menuPadre = null;

            if (menu.men_id_padre != null)
            {
                tbmenu menuPadreDatos = 
                    (tbmenu)menuBusiness.GetElement(new tbmenu() { men_id = (int)menu.men_id_padre});

                menuPadre = new tbmenu()
                {
                    men_id = menuPadreDatos.men_id,
                    men_id_padre = menuPadreDatos.men_id_padre,
                    men_nombre = menuPadreDatos.men_nombre,
                    men_nombre_formulario = menuPadreDatos.men_nombre_formulario,
                    men_estado = menuPadreDatos.men_estado
                };

                menuPadre.tbmenu1.Add(menu);
                CargoPadre(menuPadre);
            }
            else
                return menuPadre;

            return menuPadre;
        }

        private List<tbmenu> EsHermano(tbmenu menuCompleto, List<tbmenu> listaMenu)
        {
            List<tbmenu> listaMenuSalida = new List<tbmenu>();
            listaMenuSalida = listaMenu;
            tbmenu menuConHermanos = null;
            tbmenu menuARemover = null;
            bool tieneHermano = false;

            foreach (var obj in listaMenu)
            {
                if(menuCompleto.men_id == obj.men_id)
                {
                    menuARemover = new tbmenu();
                    menuConHermanos = new tbmenu();
                    menuConHermanos = this.AgregarHermano(obj, menuCompleto);
                    menuARemover = obj;
                    tieneHermano = true;
                    break;
                }           
            }

            if (menuARemover != null && menuConHermanos != null)
            {
                listaMenuSalida.Remove(menuARemover);
                listaMenuSalida.Add(menuConHermanos);
            }

            if (!tieneHermano)
                listaMenuSalida.Add(menuCompleto);

            return listaMenuSalida;
        }

        private tbmenu AgregarHermano(tbmenu menuListaMenu, tbmenu menuCompleto)
        {
            tbmenu menuSalida = new tbmenu();
            menuSalida = menuListaMenu;
            tbmenu menuHermano = new tbmenu();

            foreach (var obj in menuListaMenu.tbmenu1)
            {
                foreach (var objMenuCompleto in menuCompleto.tbmenu1)
                {
                    menuHermano = objMenuCompleto;
                    if (obj.men_id == objMenuCompleto.men_id)
                    {
                        AgregarHermano(obj, objMenuCompleto);
                    }
                    else
                    {
                        if (objMenuCompleto.tbmenu1.Count == 0)
                            menuSalida.tbmenu1.Add(menuHermano);
                        break;
                    }
                }
                break;
            }

            return menuSalida;
        }

    }
}
