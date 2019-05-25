using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LandManagement.Entities
{
    [MetadataType(typeof(tbtitulocliente_metadata))]
    public partial class tbtitulocliente
    {
    }

    public class tbtitulocliente_metadata
    {
        [DisplayName("Id titulo cliente")]
        public int tcl_id { get; set; }

        [DisplayName("Titulo cliente")]
        public string tcl_descripcion { get; set; }
    }
}
