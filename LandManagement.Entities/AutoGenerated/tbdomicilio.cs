//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace LandManagement.Entities
{
    public partial class tbdomicilio
    {
        #region Primitive Properties
    
        public virtual int dom_id
        {
            get;
            set;
        }
    
        public virtual int cli_id
        {
            get { return _cli_id; }
            set
            {
                if (_cli_id != value)
                {
                    if (tbcliente != null && tbcliente.cli_id != value)
                    {
                        tbcliente = null;
                    }
                    _cli_id = value;
                }
            }
        }
        private int _cli_id;
    
        public virtual int tip_id
        {
            get { return _tip_id; }
            set
            {
                if (_tip_id != value)
                {
                    if (tbtipopropiedad != null && tbtipopropiedad.tip_id != value)
                    {
                        tbtipopropiedad = null;
                    }
                    _tip_id = value;
                }
            }
        }
        private int _tip_id;
    
        public virtual int prv_id
        {
            get { return _prv_id; }
            set
            {
                if (_prv_id != value)
                {
                    if (tbprovincia != null && tbprovincia.prv_id != value)
                    {
                        tbprovincia = null;
                    }
                    _prv_id = value;
                }
            }
        }
        private int _prv_id;
    
        public virtual string dom_calle
        {
            get;
            set;
        }
    
        public virtual int dom_numero
        {
            get;
            set;
        }
    
        public virtual Nullable<int> dom_piso
        {
            get;
            set;
        }
    
        public virtual string dom_departamento
        {
            get;
            set;
        }
    
        public virtual string dom_codigo_postal
        {
            get;
            set;
        }
    
        public virtual string dom_localidad
        {
            get;
            set;
        }
    
        public virtual bool dom_actual
        {
            get;
            set;
        }
    
        public virtual string dom_domicilio_importado
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
        public virtual tbcliente tbcliente
        {
            get { return _tbcliente; }
            set
            {
                if (!ReferenceEquals(_tbcliente, value))
                {
                    var previousValue = _tbcliente;
                    _tbcliente = value;
                    Fixuptbcliente(previousValue);
                }
            }
        }
        private tbcliente _tbcliente;
    
        public virtual tbprovincia tbprovincia
        {
            get { return _tbprovincia; }
            set
            {
                if (!ReferenceEquals(_tbprovincia, value))
                {
                    var previousValue = _tbprovincia;
                    _tbprovincia = value;
                    Fixuptbprovincia(previousValue);
                }
            }
        }
        private tbprovincia _tbprovincia;
    
        public virtual tbtipopropiedad tbtipopropiedad
        {
            get { return _tbtipopropiedad; }
            set
            {
                if (!ReferenceEquals(_tbtipopropiedad, value))
                {
                    var previousValue = _tbtipopropiedad;
                    _tbtipopropiedad = value;
                    Fixuptbtipopropiedad(previousValue);
                }
            }
        }
        private tbtipopropiedad _tbtipopropiedad;

        #endregion

        #region Association Fixup
    
        private void Fixuptbcliente(tbcliente previousValue)
        {
            if (previousValue != null && previousValue.tbdomicilio.Contains(this))
            {
                previousValue.tbdomicilio.Remove(this);
            }
    
            if (tbcliente != null)
            {
                if (!tbcliente.tbdomicilio.Contains(this))
                {
                    tbcliente.tbdomicilio.Add(this);
                }
                if (cli_id != tbcliente.cli_id)
                {
                    cli_id = tbcliente.cli_id;
                }
            }
        }
    
        private void Fixuptbprovincia(tbprovincia previousValue)
        {
            if (previousValue != null && previousValue.tbdomicilio.Contains(this))
            {
                previousValue.tbdomicilio.Remove(this);
            }
    
            if (tbprovincia != null)
            {
                if (!tbprovincia.tbdomicilio.Contains(this))
                {
                    tbprovincia.tbdomicilio.Add(this);
                }
                if (prv_id != tbprovincia.prv_id)
                {
                    prv_id = tbprovincia.prv_id;
                }
            }
        }
    
        private void Fixuptbtipopropiedad(tbtipopropiedad previousValue)
        {
            if (previousValue != null && previousValue.tbdomicilio.Contains(this))
            {
                previousValue.tbdomicilio.Remove(this);
            }
    
            if (tbtipopropiedad != null)
            {
                if (!tbtipopropiedad.tbdomicilio.Contains(this))
                {
                    tbtipopropiedad.tbdomicilio.Add(this);
                }
                if (tip_id != tbtipopropiedad.tip_id)
                {
                    tip_id = tbtipopropiedad.tip_id;
                }
            }
        }

        #endregion

    }
}
