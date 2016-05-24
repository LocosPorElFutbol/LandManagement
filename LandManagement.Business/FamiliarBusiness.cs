using LandManagement.Entities;
using LandManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandManagement.Business
{
    public class FamiliarBusiness
    {
        private FamiliarRepository familiarRepository;

        public FamiliarBusiness()
        {
            this.familiarRepository = new FamiliarRepository();
        }

        public void Create(tbcliente familiar)
        {
            familiarRepository.Create(familiar);
        }

        public void Create(tbcliente familiar, tbcliente cliente)
        {
            familiarRepository.Create(familiar, cliente);
        }

        public void Update(tbcliente familiar)
        {
            familiarRepository.Update(familiar);
        }

        public void Delete(tbcliente familiar)
        {
            familiarRepository.Delete(familiar);
        }

        public object GetElement(tbcliente familiar)
        {
            return familiarRepository.GetElement(familiar);
        }

        public object GetList()
        {
            return familiarRepository.GetList();
        }

        public object GetFamiliaresPorCliente(tbcliente cliente)
        {
            return familiarRepository.GetFamiliaresPorCliente(cliente);
        }

    }
}
