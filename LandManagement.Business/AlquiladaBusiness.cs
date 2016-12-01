using LandManagement.Entities;
using LandManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandManagement.Business
{
    public class AlquiladaBusiness
    {
        private AlquiladaRepository alquiladaRepository;

        public AlquiladaBusiness()
        {
            alquiladaRepository = new AlquiladaRepository();
        }

        public void Update(tbalquilada _alquilada)
        {
            alquiladaRepository.Update(_alquilada);
        }

        public void Delete(tbalquilada _alquilada)
        {
            alquiladaRepository.Delete(_alquilada);
        }

        public object GetElementByKey(tbalquilada _alquilada)
        {
            return alquiladaRepository.GetElementByKey(_alquilada);
        }
    }
}
