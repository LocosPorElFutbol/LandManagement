using LandManagement.Entities;
using LandManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandManagement.Business
{
    public class DomicilioBusiness
    {
        private DomicilioRepository domicilioRepository;

        public DomicilioBusiness()
        {
            domicilioRepository = new DomicilioRepository();
        }

        public void Create(tbdomicilio domicilio)
        {
            domicilioRepository.Create(domicilio);
        }

        public void Update(tbdomicilio domicilio)
        {
            domicilioRepository.Update(domicilio);
        }

        public void Delete(tbdomicilio domicilio)
        {
            domicilioRepository.Delete(domicilio);
        }

        public object GetElement(tbdomicilio domicilio)
        {
            return domicilioRepository.GetElement(domicilio);
        }

        public object GetList()
        {
            return domicilioRepository.GetList();
        }

    }
}
