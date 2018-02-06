using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LandManagement.Business;
using LandManagement.Entities;

namespace LandManagement.Utilidades.UserControls
{
    public partial class UserControlDatosPropiedad : UserControl
    {
        private ListasDeElementos listasDeElementos = null;

        public UserControlDatosPropiedad()
        {
            InitializeComponent();
        }

        private void UserControlDatosPropiedad_Load(object sender, EventArgs e)
        {
            //this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.gbxDetalleDireccion.Enabled = false;
            listasDeElementos = new ListasDeElementos();
            this.CargarCombos();

            cmbDireccion.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbDireccion.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        #region Carga de Combos Piso, Depto, Direcciones y clientes

        private void CargarCombos()
        {
            this.SetearDisplayValue();
            this.CargarTipoPropiedad();
            this.CargarPiso();
            this.CargarDepto();
            this.CargarDirecciones();
            this.CargarClientes();
        }

        private void SetearDisplayValue()
        {
            cmbTipoPropiedad.ValueMember = "tip_id";
            cmbTipoPropiedad.DisplayMember = "tip_descripcion";

            cmbPiso.ValueMember = ComboBoxItem.ValueMember;
            cmbPiso.DisplayMember = ComboBoxItem.DisplayMember;

            cmbDepto.ValueMember = ComboBoxItem.ValueMember;
            cmbDepto.DisplayMember = ComboBoxItem.DisplayMember;

            cmbDireccion.ValueMember = "pro_id";
            cmbDireccion.DisplayMember = "pro_direccion";

            cmbProvincia.ValueMember = "prv_id";
            cmbProvincia.DisplayMember = "prv_descripcion";
        }

        private void CargarTipoPropiedad()
        {
            TipoPropiedadBusiness tipoPropiedadBusiness = new TipoPropiedadBusiness();
            List<tbtipopropiedad> listaTipoPropiedades = (List<tbtipopropiedad>)tipoPropiedadBusiness.GetList();

            foreach (var obj in listaTipoPropiedades)
                cmbTipoPropiedad.Items.Add(obj);
        }

        private void CargarPiso()
        {
            this.CargarCombo(listasDeElementos.GetListaPiso(), cmbPiso);
        }

        private void CargarDepto()
        {
            this.CargarCombo(listasDeElementos.GetListaDepto(), cmbDepto);
        }

        private void CargarDirecciones()
        {
            PropiedadBusiness propiedadBusiness = new PropiedadBusiness();
            List<tbpropiedad> listaDirecciones = (List<tbpropiedad>)propiedadBusiness.GetListDirecciones();

            if (listaDirecciones.Count != 0)
                foreach (var obj in listaDirecciones)
                    cmbDireccion.Items.Add(obj);
        }

        private void CargarClientes()
        {
            ProvinciaBusiness provinciaBusiness = new ProvinciaBusiness();
            List<tbprovincia> provincias =
                (List<tbprovincia>)provinciaBusiness.GetList();

            foreach (var obj in provincias)
                cmbProvincia.Items.Add(obj);
        }

        private void CargarCombo(List<ComboBoxItem> lista, ComboBox combo)
        {
            foreach (var obj in lista)
                combo.Items.Add(obj);
        }

        #endregion

        #region Cargo controles de dirección seleccionada
        private void cmbDireccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarControlesPropiedad((tbpropiedad)cmbDireccion.SelectedItem);
        }

        private void CargarControlesPropiedad(tbpropiedad p)
        {
            cmbTipoPropiedad.Text = p.tbtipopropiedad.tip_descripcion;
            txbCalle.Text = p.pro_calle;
            txbNumero.Text = p.pro_numero.ToString();
            if (p.pro_piso == 0)
                cmbPiso.Text = "PB";
            else
                cmbPiso.Text = p.pro_piso.ToString();
            cmbDepto.Text = p.pro_departamento;
            txbLocalidad.Text = p.pro_localidad;
            txbCodigoPostal.Text = p.pro_codigo_postal;

            //Cargo provincia de la propiedad
            ProvinciaBusiness provinciaBusiness = new ProvinciaBusiness();
            tbprovincia provincia =
                provinciaBusiness.GetElement(new tbprovincia() { prv_id = p.prv_id }) as tbprovincia;
            cmbProvincia.Text = provincia.prv_descripcion;
        }
        #endregion

        public tbpropiedad GetPropiedadSeleccionada()
        {
            return (tbpropiedad)cmbDireccion.SelectedItem;
        }

        public void SeleccionarPropiedad(int idPropiedad)
        {
            cmbDireccion.Enabled = false;
            tbpropiedad propiedadSeleccionada = null;
            foreach (tbpropiedad obj in cmbDireccion.Items)
            {
                if (obj.pro_id == idPropiedad)
                {
                    propiedadSeleccionada = obj;
                    break;
                }
            }
            cmbDireccion.SelectedItem = propiedadSeleccionada;
        }
    }
}
