using LandManagement.Entities;
using LandManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandManagement.Business
{
    public class ClienteSystemBusiness
    {
        private ClienteSystemRepository clienteSystemRepository = null;

        public ClienteSystemBusiness()
        {
            clienteSystemRepository = ClienteSystemRepository.GetInstancia();
        }

        public object GetElement(tbsyscliente sysCliente)
        {
            return clienteSystemRepository.GetElement(sysCliente);
        }
    }
}
