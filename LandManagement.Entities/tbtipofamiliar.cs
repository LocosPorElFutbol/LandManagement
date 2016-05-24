using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LandManagement.Entities
{
    [MetadataType(typeof(tbtipofamiliar_metadata))]
    public partial class tbtipofamiliar
    {

    }

    public class tbtipofamiliar_metadata
    {
        [DisplayName("Id")]
        public int tif_id { get; set; }

        [DisplayName("Tipo de familiar")]
        public string tif_descripcion { get; set; }

    }
}
