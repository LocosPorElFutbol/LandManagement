using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LandManagement.Entities
{
    [Obsolete("tbcategoria va a eliminarse, se tiene que mejorar el código. El nombre no es apropiado para la clase")]
    [MetadataType(typeof(tbcategoria_metadata))]
    public class tbcategoria
    {
        public int cat_id { get; set; }
        public int cli_id { get; set; }
        public int ope_id { get; set; }
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
