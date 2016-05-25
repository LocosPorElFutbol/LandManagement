using LandManagement.Entities;
using LandManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandManagement.Business
{
    public class EnAlquilerBusiness
    {
        private EnAlquilerRepository enAlquilerRepository;

        public EnAlquilerBusiness()
        {
            enAlquilerRepository = new EnAlquilerRepository();
        }

        public void Update(tbenalquiler entity)
        {
            enAlquilerRepository.Update(entity);        
        }

        public void Delete(tbenalquiler _enAlquiler)
        {
            enAlquilerRepository.Delete(_enAlquiler);
        }

        public object GetElementByKey(tbenalquiler _enAlquiler)
        {
            return enAlquilerRepository.GetElementByKey(_enAlquiler);
        }
    }
}
