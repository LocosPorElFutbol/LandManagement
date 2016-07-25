using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandManagement.Repository;
using LandManagement.Entities;

namespace LandManagement.Business
{
    public class CategoriaBusiness
    {
        private CategoriaRepository categoriaRepository;

        public CategoriaBusiness()
        {
            categoriaRepository = new CategoriaRepository();
        }

        public object GetListByClienteId(tbcliente _cliente)
        {
            return categoriaRepository.GetListByClienteId(_cliente);
        }

        public object GetListaCategorias()
        {
            return categoriaRepository.GetListaCategorias();
        }
    }
}
