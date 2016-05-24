using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LandManagement.Entities
{
    [MetadataType(typeof(tbtipopropiedad_metadata))]
    public partial class tbtipopropiedad
    {

    }

    public class tbtipopropiedad_metadata
    {
        [DisplayName("Id")]
        public int tip_id { get; set; }

        [DisplayName("Descripcion del servicio")]
        public string tip_descripcion { get; set; }

        /*        [DisplayName("Apellido del Usuario")]
                public string usu_apellido { get; set; 

                [DisplayName("E-Mail")]
                public string usu_email { get; set; }

                [DisplayName("Nombre Login")]
                public string usu_nombre_login { get; set; }

                [DisplayName("Password")]
                public string usu_password { get; set; }
          */
    }
}

