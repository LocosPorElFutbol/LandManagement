using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LandManagement.Entities
{
    [MetadataType(typeof(tbcategoria_metadata))]
    public class tbcategoria
    {
        public int cat_id { get; set; }
        public string cat_descripcion { get; set; }
        public DateTime? cat_fecha { get; set; }
    }

    public class tbcategoria_metadata
    {
        [DisplayName("Id")]
        public int cat_id { get; set; }

        [DisplayName("Descripcion")]
        public string cat_descripcion { get; set; }

        [DisplayName("Fecha")]
        public DateTime? cat_fecha { get; set; }
    }
}
