using LandManagement.Entities;
using LandManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandManagement.Business
{
    public class VentaBusiness
    {
        private VentaRepository ventaRepository;

        public VentaBusiness()
        {
            ventaRepository = new VentaRepository();
        }

        public void Delete(tbventa _venta)
        {
            ventaRepository.Delete(_venta);
        }

        public object GetElementByKey(tbventa _venta)
        {
            return ventaRepository.GetElementByKey(_venta);
        }
    }
}
