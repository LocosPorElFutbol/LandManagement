using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LandManagement.Entities
{
    [MetadataType(typeof(tbpropiedad_metadata))]
    public partial class tbpropiedad
    {
        public string pro_tip_descripcion { get; set; }
        public string pro_direccion {
            get 
            {
                if (pro_piso == 0)
                    return pro_calle + " " + pro_numero + ", PB, " + pro_departamento;
                else
                    return pro_calle + " " + pro_numero + ", " + pro_piso.ToString() + ", " + pro_departamento;
            }
        }
    }

    public class tbpropiedad_metadata
    {
        [DisplayName("Id Propiedad")]
        public int pro_id{get;set;}

        [DisplayName("Id Tipo Propiedad")]
        public int tip_id{get;set;}

        [DisplayName("Tipo de Propiedad")]
        public int pro_tip_descripcion { get; set; }        

        [DisplayName("Calle")]
        public string pro_calle{get;set;}

        [DisplayName("Número")]
        public int pro_numero{get;set;}

        [DisplayName("Piso")]
        public int pro_piso{get;set;}

        [DisplayName("Departamento")]
        public string pro_departamento{get;set;}

        [DisplayName("Código Postal")]
        public string pro_codigo_postal{get;set;}

        [DisplayName("Localidad")]
        public string pro_localidad { get; set; }

        [DisplayName("Dirección")]
        public string pro_direccion { get; set; }

        [DisplayName("Característica")]
        public string pro_caracteristica { get; set; }
    }
}
