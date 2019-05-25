using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LandManagement.Entities
{
    [MetadataType(typeof(tbcategoriacliente_metadata))]
    public partial class tbcategoriacliente
    {
    }

    public class tbcategoriacliente_metadata
    {
        [DisplayName("Id categoria cliente")]
        public int ccl_id { get; set; }
        [DisplayName("Categoria cliente")]
        public string ccl_descripcion { get; set; }
    }
}
