using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LandManagement.Utilidades
{
    public class DisplayNameHelper 
    {
        //public string GetMetaDisplayName(object clase, string nombreAtributo)
        //{

        //    PropertyInfo pi = typeof(clase.GetType().Name).GetProperty("men_nombre");
        //    displayNameHelper = new DisplayNameHelper();
        //    string asd = displayNameHelper.GetMetaDisplayName(pi);
        //}

        public string GetMetaDisplayName(PropertyInfo property)
        {
            var atts = property.DeclaringType.GetCustomAttributes(
                typeof(MetadataTypeAttribute), true);
            if (atts.Length == 0)
                return null;

            var metaAttr = atts[0] as MetadataTypeAttribute;
            var metaProperty =
                metaAttr.MetadataClassType.GetProperty(property.Name);
            if (metaProperty == null)
                return null;
            return GetAttributeDisplayName(metaProperty);
        }

        private string GetAttributeDisplayName(PropertyInfo property)
        {
            var atts = property.GetCustomAttributes(
                typeof(DisplayNameAttribute), true);
            if (atts.Length == 0)
                return null;
            return (atts[0] as DisplayNameAttribute).DisplayName;
        }
    }
}
