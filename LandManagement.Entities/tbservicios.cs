using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LandManagement.Entities
{
    [MetadataType(typeof(tbusuario_metadata))]
    public partial class tbservicios
    {

    }

    public class tbservicios_metadata
    {
        [DisplayName("Id")]
        public int ser_id { get; set; }

        [DisplayName("Descripcion del servicio")]
        public string ser_descripcion { get; set; }

    }
}
