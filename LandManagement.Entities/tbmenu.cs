using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LandManagement.Entities
{
    [MetadataType(typeof(tb_menu_metadata))]
    public partial class tbmenu
    {
    }

    public class tb_menu_metadata
    {
        [DisplayName("Id")]
        public int men_id { get; set; }

        [DisplayName("Nombre Padre")]
        public int men_id_padre { get; set; }

        [DisplayName("Nombre Menú")]
        public string men_nombre { get; set; }

        [DisplayName("Nombre del Formulario")]
        public string men_nombre_formulario { get; set; }

        [DisplayName("Estado")]
        public bool men_estado { get; set; }
    }
}
