using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LandManagement.Entities
{
    [MetadataType(typeof(tbusuario_metadata))]
    public partial class tbusuario
    {

    }

    public class tbusuario_metadata
    {
        [DisplayName("Id")]
        public int usu_id { get; set; }

        [DisplayName("Nombre del Usuario")]
        public string usu_nombre { get; set; }

        [DisplayName("Apellido del Usuario")]
        public string usu_apellido { get; set; }

        [DisplayName("E-Mail")]
        public string usu_email { get; set; }

        [DisplayName("Nombre Login")]
        public string usu_nombre_login { get; set; }

        [DisplayName("Password")]
        public string usu_password { get; set; }
    }
}
