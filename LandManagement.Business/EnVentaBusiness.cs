using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandManagement.Repository;
using LandManagement.Entities;

namespace LandManagement.Business
{
    public class EnVentaBusiness
    {
        private EnVentaRepository enVentaRepository;
        
        public EnVentaBusiness()
        {
            this.enVentaRepository = new EnVentaRepository();
        }

        public void Update(tbenventa entity)
        {
            this.enVentaRepository.Update(entity);
        }

        public void Delete(tbenventa entity)
        {
            enVentaRepository.Delete(entity);
        }

        public object GetElementByKey(tbenventa entity)
        {
            return enVentaRepository.GetElementByKey(entity);
        }
    }
}
