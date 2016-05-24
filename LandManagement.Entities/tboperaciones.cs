using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LandManagement.Entities
{
    [MetadataType(typeof(tboperaciones_metadata))]
    public partial class tboperaciones
    {
        public string ope_tipo_operacion { get; set; }

        public int pro_tip_descripcion { get; set; }

        public string pro_calle { get; set; }

        public int pro_numero { get; set; }

        public int pro_piso { get; set; }

        public string pro_departamento { get; set; }

        public string pro_codigo_postal { get; set; }

        public string pro_localidad { get; set; }
    }

    public class tboperaciones_metadata
    {
        [DisplayName("ID Operación")]
        public int ope_id { get; set; }

        [DisplayName("Tipo Operacion")]
        public string ope_tipo_operacion { get; set; }

        [DisplayName("Fecha Operación")]
        public DateTime ope_fecha { get; set; }

        [DisplayName("Tipo de Propiedad")]
        public int pro_tip_descripcion { get; set; }

        [DisplayName("Calle")]
        public string pro_calle { get; set; }

        [DisplayName("Número")]
        public int pro_numero { get; set; }

        [DisplayName("Piso")]
        public int pro_piso { get; set; }

        [DisplayName("Departamento")]
        public string pro_departamento { get; set; }

        [DisplayName("Código Postal")]
        public string pro_codigo_postal { get; set; }

        [DisplayName("Localidad")]
        public string pro_localidad { get; set; }
    
    }
}
