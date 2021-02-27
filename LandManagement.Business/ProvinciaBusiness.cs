using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandManagement.Entities;
using LandManagement.Repository;

namespace LandManagement.Business
{
    public class ProvinciaBusiness
    {
        private ProvinciaRepository provinciaRepository = null;

        public ProvinciaBusiness()
        {
            //provinciaRepository = ProvinciaRepository.GetInstancia();
            provinciaRepository = new ProvinciaRepository();
        }

        public object GetElement(tbprovincia entity)
        {
            return provinciaRepository.GetElement(entity);
        }

        public object GetList()
        {
            return provinciaRepository.GetList();
        }
    }
}
