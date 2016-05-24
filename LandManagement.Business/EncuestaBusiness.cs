using LandManagement.Entities;
using LandManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandManagement.Business
{
    public class EncuestaBusiness
    {
        private EncuestaRepository encuestaRepository;

        public EncuestaBusiness()
        {
            encuestaRepository = new EncuestaRepository();
        }

        public void Delete(tbencuesta _encuesta)
        {
            encuestaRepository.Delete(_encuesta);
        }

        public object GetElementByKey(tbencuesta _encuesta)
        {
            return encuestaRepository.GetElementByKey(_encuesta);
        }
    }
}
