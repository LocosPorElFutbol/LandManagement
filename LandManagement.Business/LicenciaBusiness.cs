using LandManagement.Entities;
using LandManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandManagement.Business
{
    public class LicenciaBusiness
    {
        private LicenciaRepository licenciaRepository = null;

        public LicenciaBusiness()
        {
            //licenciaRepository = LicenciaRepository.GetInstancia();
            licenciaRepository = new LicenciaRepository();
        }

        public void ActivarProducto(tbsyslicencia licencia)
        {
            licenciaRepository.Create(licencia);
        }

        public tbsyslicencia GetLicenciaByMacEthernet(tbsyslicencia licencia)
        {
            tbsyslicencia licenciaSalida = new tbsyslicencia();

            Func<tbsyslicencia, bool> funcion = x => x.sli_mac_ethernet == licencia.sli_mac_ethernet;
            var listaLicencias = licenciaRepository.GetList(funcion) as List<tbsyslicencia>;

            if (listaLicencias.Count > 0)
                return listaLicencias.FirstOrDefault();
            return null;
        }

        public void TomarLicencia(tbsyslicencia licencia)
        {
            licencia.sli_en_uso = true;
            licenciaRepository.Update(licencia);
        }

        public void LiberarLicencia(tbsyslicencia licencia)
        {
            licencia.sli_en_uso = false;
            licenciaRepository.Update(licencia);
        }

        public int LicenciasDisponibles()
        {
            Func<tbsyslicencia, bool> funcion = x => x.sli_en_uso == true;
            var listaLicenciasActivas = licenciaRepository.GetList(funcion) as List<tbsyslicencia>;

            ClienteSystemBusiness clienteSystemBusiness = new ClienteSystemBusiness();
            var sysCliente = clienteSystemBusiness.GetElement(new tbsyscliente() { scl_id = 1 }) as tbsyscliente;

            int cantidadLicenciasDisponibles = sysCliente.scl_cantidad_licencias - listaLicenciasActivas.Count;

            return cantidadLicenciasDisponibles;
        }
    }
}
