using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LandManagement.Entities
{
    [MetadataType(typeof(tbcliente_metadata))]
    public partial class tbcliente
    {
        public string cli_parentezco { get; set; }
        public string cli_nombre_completo
        {
            get
            {
                return this.cli_nombre + ", " + this.cli_apellido;
            }
        }
         
    }

    public class tbcliente_metadata
    {
        [DisplayName("Id Cliente")]
        public int cli_id { get; set; }

        [DisplayName("Id Importado")]
        public int cli_id_import { get; set; }

        [DisplayName("Id Cliente Padre")]
        public int cli_id_padre { get; set; }

        [DisplayName("Id Tipo Familiar")]
        public int tif_id { get; set; }

        [DisplayName("Id titulo cliente")]
        public int tcl_id { get; set; }

        [DisplayName("Id categoria cliente")]
        public int ccl_id { get; set; }

        [DisplayName("Parentezco")]
        public string cli_parentezco { get; set; }

        [DisplayName("Fecha Alta")]
        public DateTime cli_fecha { get; set; }

        [DisplayName("Nombre")]
        public int cli_nombre{get;set;}

        [DisplayName("Título")]
        public string cli_titulo { get; set; }

        [DisplayName("Apellido")]
        public string cli_apellido{get;set;}

        [DisplayName("Telefono Celular")]
        public string cli_telefono_celular{get;set;}

        [DisplayName("Telefono Particular")]
        public string cli_telefono_particular{get;set;}

        [DisplayName("Telefono Laboral")]
        public string cli_telefono_laboral{get;set;}

        [DisplayName("Email")]
        public string cli_email{get;set;}

        [DisplayName("Sexo")]
        public string cli_sexo{get;set;}

        [DisplayName("Fecha de Nacimiento")]
        public DateTime cli_fecha_nacimiento{get;set;}

        [DisplayName("Nacionalidad")]
        public string cli_nacionalidad{get;set;}

        [DisplayName("Estado Civil")]
        public string cli_estado_civil{get;set;}

        [DisplayName("Tipo Documento")]
        public string cli_tipo_documento{get;set;}

        [DisplayName("Número de Documento")]
        public string cli_numero_documento{get;set;}

        [DisplayName("CUIT/CUIL")]
        public string cli_cuit_cuil{get;set;}

        [DisplayName("Como llego a nosotros")]
        public string cli_como_llego{get;set;}
    }
}
