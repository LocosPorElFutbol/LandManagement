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
            //clienteSystemRepository = ClienteSystemRepository.GetInstancia();
            clienteSystemRepository = new ClienteSystemRepository();
        }

        public object GetElement(tbsyscliente sysCliente)
        {
            return clienteSystemRepository.GetElement(sysCliente);
        }
    }
}
