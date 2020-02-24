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

		public object GetList(Func<tbdomicilio, bool> predicado)
		{
			return domicilioRepository.GetList(predicado);
		}

        #region Métodos Particulares
        public object GetDomicilioByIdCliente(tbcliente _cliente)
        {
            List<tbdomicilio> listaDomicilio = (List<tbdomicilio>)this.GetList();
            return listaDomicilio
                .Where(d => d.cli_id == _cliente.cli_id && d.dom_actual == true).SingleOrDefault();
        }

        #endregion
    }
}
