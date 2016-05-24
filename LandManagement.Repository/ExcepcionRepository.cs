using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandManagement.Repository
{
    public class ExcepcionRepository : Exception
    {
        public static string ErrorConexion = "Se produjo un error en la conexión a datos.";
    }
}
