using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandManagement.Entities;
using LandManagement.Repository;

namespace LandManagement.Business
{
    public class CartaBusiness
    {
        private CartaRepository cartaRepository = null;
        public CartaBusiness()
        {
            cartaRepository = CartaRepository.GetInstancia();
        }

        public void Update(tbcarta entity)
        {
            cartaRepository.Update(entity);
        }

        public object GetElement(tbcarta entity)
        {
            return cartaRepository.GetElement(entity);
        }
    }
}
