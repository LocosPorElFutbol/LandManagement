using LandManagement.Entities;
using LandManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandManagement.Business
{
    public class PropiedadBusiness
    {
        private PropiedadRepository propiedadRepository;

        public PropiedadBusiness()
        {
            propiedadRepository = new PropiedadRepository();
        }

        public void Create(tbpropiedad propiedad)
        {
            propiedadRepository.Create(propiedad);
        }

        public void Create(tbpropiedad propiedad, tbcliente cliente)
        {
            propiedadRepository.Create(propiedad, cliente);
        }

        public void Update(tbpropiedad propiedad)
        {
            propiedadRepository.Update(propiedad);
        }

        public void Delete(tbpropiedad propiedad)
        {
            propiedadRepository.Delete(propiedad);
        }

        public object GetElement(tbpropiedad propiedad)
        {
            return propiedadRepository.GetElement(propiedad);
        }

        public object GetList()
        {
            return propiedadRepository.GetList();
        }

        public object GetList(int[] ids)
        {
            return propiedadRepository.GetList(ids);
        }

        public object GetPropiedadesPorCliente(tbcliente cliente)
        {
            return propiedadRepository.GetPropiedadesPorCliente(cliente);
        }

        public object GetListDirecciones()
        {
            List<tbpropiedad> listaDirecciones = (List<tbpropiedad>)this.GetList();

            //foreach (tbpropiedad obj in listaDirecciones)
            //    this.GetDireccion(obj);

            return listaDirecciones;
        }

        public object GetListDirecciones(int[] ids)
        {
            List<tbpropiedad> listaDirecciones = (List<tbpropiedad>)this.GetList(ids);
            //foreach (tbpropiedad obj in listaDirecciones)
            //    this.GetDireccion(obj);

            return listaDirecciones;
        }

        //public object GetDireccion(tbpropiedad propiedad)
        //{
        //    propiedad.pro_direccion = propiedad.pro_calle + " " + propiedad.pro_numero +
        //                                        ", " + propiedad.pro_piso.ToString() + ", " + propiedad.pro_departamento;

        //     return propiedad;
        //}

    }
}
