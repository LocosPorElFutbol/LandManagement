using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandManagement.Repository;
using LandManagement.Entities;

namespace LandManagement.Business
{
    public class MenuBusiness
    {
        private MenuRepository menuRepository;

        public MenuBusiness()
        {
            menuRepository = new MenuRepository();
        }

        public void Create(tbmenu menu)
        {
            menuRepository.Create(menu);
        }

        public void Update(tbmenu menu)
        {
            menuRepository.Update(menu);
        }

        public void Delete(tbmenu menu)
        {
            menuRepository.Delete(menu);
        }

        public object GetElement(tbmenu menu)
        {
            return menuRepository.GetElement(menu);
        }

        public object GetList()
        {
            return menuRepository.GetList();
        }

        public object ObtenerListadoMenu()
        {
            //return ((List<tbmenu>)this.GetList()).Where(x => x.men_nombre_formulario != null);
            var listadoMenu = ((List<tbmenu>)this.GetList()).Where(x => x.men_nombre_formulario != null);
            List<tbmenu> listaMenuSalida = new List<tbmenu>();

            foreach (tbmenu obj in listadoMenu)
            {
                listaMenuSalida.Add(obj);
                    //new tbmenu()
                    //{
                    //    men_id = obj.men_id,
                    //    men_nombre = obj.men_nombre,
                    //    men_nombre_formulario = obj.men_nombre_formulario
                    //});
            }

            return listaMenuSalida;
            //return listadoMenu;
        }

    }
}
