using LandManagement.Entities;
using LandManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandManagement.Business
{
    public class ReservaAlquilerBusiness
    {
        private ReservaAlquilerRepository reservaAlquilerRepository;

        public ReservaAlquilerBusiness()
        {
            reservaAlquilerRepository = new ReservaAlquilerRepository();
        }

        public void Update(tbreservaalquiler _reservaAlquiler)
        {
            reservaAlquilerRepository.Update(_reservaAlquiler);
        }

        public void Delete(tbreservaalquiler _reservaAlquiler)
        {
            reservaAlquilerRepository.Delete(_reservaAlquiler);
        }

        public object GetElementByKey(tbreservaalquiler _reservaAlquiler)
        {
            return reservaAlquilerRepository.GetElementByKey(_reservaAlquiler);
        }
    }
}
