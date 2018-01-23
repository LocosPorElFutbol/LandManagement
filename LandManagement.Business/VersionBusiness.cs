using LandManagement.Entities;
using LandManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandManagement.Business
{
    public class VersionBusiness
    {
        private VersionRepository versionRepository;
        public VersionBusiness()
        {
            versionRepository = VersionRepository.GetInstancia();
        }

        public tbsysversion GetLastVersion()
        {
            try
            {
                List<tbsysversion> listaVersiones = versionRepository.GetList() as List<tbsysversion>;
                var salida = listaVersiones.OrderByDescending(x => x.ver_id).First<tbsysversion>();
                return salida;   
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
