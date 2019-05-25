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

        public object GetList(Func<tbmenu, bool> funcion)
        {
            return menuRepository.GetList(funcion);
        }

        public object ObtenerListadoMenu()
        {
            Func<tbmenu, bool> funcion = x => x.men_nombre_formulario != null;
            return this.GetList(funcion) as List<tbmenu>;
        }

    }
}
