using LandManagement.Entities;
using LandManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandManagement.Business
{
    public class ReservaVentaBusiness
    {
        private ReservaVentaRepository reservaVentaRepository;
        public ReservaVentaBusiness()
        {
            reservaVentaRepository = new ReservaVentaRepository();
        }

        public void Update(tbreservaventa _reservaVenta)
        {
            reservaVentaRepository.Update(_reservaVenta);            
        }

        public void Delete(tbreservaventa _reservaVenta)
        {
            reservaVentaRepository.Delete(_reservaVenta);
        }

        public object GetElementByKey(tbreservaventa _reservaVenta)
        {
            return reservaVentaRepository.GetElement(_reservaVenta);
        }
    }
}
