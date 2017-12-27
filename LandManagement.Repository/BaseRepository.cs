using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public abstract class BaseRepository
    {
        private landmanagementbdEntities _Contexto;

        public landmanagementbdEntities Contexto
        {
            set { }
            get
            {
                if (_Contexto == null)
                {
                    _Contexto = new landmanagementbdEntities();
                    _Contexto.ContextOptions.LazyLoadingEnabled = false;
                    _Contexto.ContextOptions.ProxyCreationEnabled = false;
                }
                return _Contexto;
            }
        }



    }
}
