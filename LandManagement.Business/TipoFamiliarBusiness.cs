using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandManagement.Repository;
using LandManagement.Entities;

namespace LandManagement.Business
{
    public class TipoFamiliarBusiness
    {
        private TipoFamiliarRepository _TipoFamiliarRepository;
        private MenuBusiness menuBusiness;
        public TipoFamiliarBusiness()
        {
            this._TipoFamiliarRepository = new TipoFamiliarRepository();
            menuBusiness = new MenuBusiness();
        }

        public void Create(tbtipofamiliar tbtipofamiliar)
        {
            _TipoFamiliarRepository.Create(tbtipofamiliar);
        }

        public void Update(tbtipofamiliar tbtipofamiliar)
        {
            _TipoFamiliarRepository.Update(tbtipofamiliar);
        }

        public void Delete(tbtipofamiliar tbtipofamiliar)
        {
            _TipoFamiliarRepository.Delete(tbtipofamiliar);
        }

        public object GetElement(tbtipofamiliar tbtipofamiliar)
        {
            return _TipoFamiliarRepository.GetElement(tbtipofamiliar);
        }

        /*   public object GetElementByLoginName(tbusuario pUsuario)
           {
               return _ServiciosRepository.GetElementByLoginName(pUsuario);
           }
           */
        public object GetList()
        {
            return _TipoFamiliarRepository.GetList();
        }
        /*
            public tbusuario ValidacionUsuarioPassword(tbusuario usuario, string password)
            {
                tbusuario usuarioObtenido = new tbusuario();
                usuarioObtenido = (tbusuario)this.GetElementByLoginName(usuario);

                if (usuarioObtenido != null)
                    if (usuarioObtenido.usu_password == password)
                        return usuarioObtenido;

                return null;
            }
            */
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
                        EsHermano(menuCompleto, listaMenu);
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
                    (tbmenu)menuBusiness.GetElement(new tbmenu() { men_id = (int)menu.men_id_padre });

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

        private bool EsHermano(tbmenu menuCompleto, List<tbmenu> listaMenu)
        {
            tbmenu menuConHermanos = null;
            tbmenu menuARemover = null;
            foreach (var obj in listaMenu)
            {
                if (menuCompleto.men_id == obj.men_id)
                {
                    menuARemover = new tbmenu();
                    menuConHermanos = new tbmenu();
                    menuConHermanos = this.AgregarHermano(obj, menuCompleto);
                    menuARemover = obj;
                    break;
                }
            }

            listaMenu.Remove(menuARemover);
            listaMenu.Add(menuConHermanos);

            return true;
        }

        private tbmenu AgregarHermano(tbmenu menuListaMenu, tbmenu menuCompleto)
        {
            tbmenu menuSalida = new tbmenu();

            foreach (var obj in menuListaMenu.tbmenu1)
            {
                menuSalida = obj;
                foreach (var objMenuCompleto in menuCompleto.tbmenu1)
                {
                    if (obj.men_id == objMenuCompleto.men_id)
                    {
                        AgregarHermano(obj, objMenuCompleto);
                    }
                    else
                    {
                        if (objMenuCompleto.tbmenu1.Count == 0)
                            menuSalida.tbmenu1.Add(objMenuCompleto);
                    }
                }
            }

            return menuSalida;
        }

    }

}
