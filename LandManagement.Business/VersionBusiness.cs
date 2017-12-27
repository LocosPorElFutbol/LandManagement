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

        public tbversion GetLastVersion()
        {
            try
            {
                List<tbversion> listaVersiones = versionRepository.GetList() as List<tbversion>;
                var salida = listaVersiones.OrderByDescending(x => x.ver_id).First<tbversion>();
                return salida;   
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
