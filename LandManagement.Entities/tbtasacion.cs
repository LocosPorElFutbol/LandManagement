using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LandManagement.Entities
{
    [MetadataType(typeof(tbtasacion_metadata))]
    public partial class tbtasacion
    {

    }

    public class tbtasacion_metadata
    {
        [DisplayName("Id Tasación")]
        public int tas_id { get; set; }

        [DisplayName("Valor Tasación")]
        public double tas_tasacion { get; set; }

        [DisplayName("Observaciones")]
        public string tas_observaciones { get; set; }
    }
}
