using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LandManagement.Entities;
using LandManagement.Business;
using LandManagement.Utilidades;
using System.Reflection;
using log4net;
using System.Configuration;

namespace LandManagement
{
    public partial class frmPropiedadABM : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private TipoPropiedadBusiness tipoPropiedadBusiness;
        private ClienteBusiness clienteBusiness;
        private OperacionBusiness operacionBusiness;
        DisplayNameHelper displayNameHelper;
        private tbpropiedad propiedad;
        private ListasDeElementos listasDeElementos;
        private Form formPadre;
        private DataGridViewRow dataGridViewRow;
        private Form formularioOperacion;

        public frmPropiedadABM()
        {
            InitializeComponent();
        }

        public frmPropiedadABM(tbpropiedad prop, Form formularioPadre)
        {
            InitializeComponent();
            this.clienteBusiness = new ClienteBusiness();
            this.formPadre = formularioPadre;
            this.propiedad = prop;

            CargarGrillaPropietarios();
            CargarGrillaOperaciones();

        }

        private void frmPropiedadABM_Load(object sender, EventArgs e)
        {
            pnlControles.AutoScroll = true;
            listasDeElementos = new ListasDeElementos();
            this.CargarCombos();

            gbxDireccion.Enabled = false;
            this.CargarControlesPropiedad(this.propiedad);
        }

        private void CargarControlesPropiedad(tbpropiedad p)
        {
            cmbTipoPropiedad.Text = p.tbtipopropiedad.tip_descripcion;
            txbCalle.Text = p.pro_calle;
            txbNumero.Text = p.pro_numero.ToString();
            cmbPiso.Text = p.pro_piso.ToString();
            cmbDepartamento.Text = p.pro_departamento;
            txbLocalidad.Text = p.pro_localidad;
            txbCodigoPostal.Text = p.pro_codigo_postal;
            txbCaracteristicas.Text = p.pro_caracteristica;
        }

        #region Carga Grilla de Propietarios

        public void CargarGrillaPropietarios()
        {
            InicializarGrillaPropietarios();

            foreach (var obj in this.propiedad.tbcliente)
                AgregaFamiliarAGrilla(obj);
        }

        private void InicializarGrillaPropietarios()
        {
            dgvPropietarios.Rows.Clear();
            dgvPropietarios.Columns.Clear();
            string[] columnasGrilla = {
                                        "cli_id",
                                        "tif_id",
                                        "cli_nombre",
                                        "cli_apellido",
                                        "cli_numero_documento",
                                        "cli_fecha_nacimiento"
                                      };

            int i = 0;
            foreach (string s in columnasGrilla)
            {
                PropertyInfo pi = typeof(tbcliente).GetProperty(s);
                displayNameHelper = new DisplayNameHelper();
                string columna = displayNameHelper.GetMetaDisplayName(pi);
                dgvPropietarios.Columns.Add(s, columna);
                i++;
            }

            dgvPropietarios.Columns[0].Visible = false;
            dgvPropietarios.Columns[1].Visible = false;

        }

        public void AgregaFamiliarAGrilla(tbcliente familiar)
        {
            int indice;
            DataGridViewRow dataGridViewRow = new DataGridViewRow();
            indice = dgvPropietarios.Rows.Add();
            dataGridViewRow = dgvPropietarios.Rows[indice];
            dataGridViewRow.Cells["cli_id"].Value = familiar.cli_id;
            dataGridViewRow.Cells["tif_id"].Value = familiar.tif_id;
            dataGridViewRow.Cells["cli_nombre"].Value = familiar.cli_nombre;
            dataGridViewRow.Cells["cli_apellido"].Value = familiar.cli_apellido;
            dataGridViewRow.Cells["cli_numero_documento"].Value = familiar.cli_numero_documento;
            dataGridViewRow.Cells["cli_fecha_nacimiento"].Value = familiar.cli_fecha_nacimiento;
        }

        #endregion

        #region Carga Grilla de Operaciones

        public void CargarGrillaOperaciones()
        {
            InicializarGrillaOperaciones();
            CargarDataGridViewLista();
        }

        private void InicializarGrillaOperaciones()
        {
            dgvOperacionesPropiedad.Rows.Clear();
            dgvOperacionesPropiedad.Columns.Clear();
            string[] columnasGrilla = {
                                        "ope_id",
                                        "ope_tipo_operacion",
                                        "ope_fecha",
                                        "pro_tip_descripcion"
                                      };

            int i = 0;
            foreach (string s in columnasGrilla)
            {
                PropertyInfo pi = typeof(tboperaciones).GetProperty(s);
                displayNameHelper = new DisplayNameHelper();
                string columna = displayNameHelper.GetMetaDisplayName(pi);
                dgvOperacionesPropiedad.Columns.Add(s, columna);
                i++;
            }

            //dgvPropietarios.Columns[0].Visible = false;
            //dgvPropietarios.Columns[1].Visible = false;
        }

        private void CargarDataGridViewLista()
        {
            operacionBusiness = new OperacionBusiness();
            List<tboperaciones> listaOperaciones = (List<tboperaciones>)operacionBusiness.GetListByPropiedadId(this.propiedad.pro_id);
            CargarDataGridView(listaOperaciones);
        }

        private void CargarDataGridView(List<tboperaciones> listaOperaciones)
        {
            dgvOperacionesPropiedad.Rows.Clear();
            DataGridViewRow dataGridViewRow;
            int indice;
            foreach (var obj in listaOperaciones)
            {
                indice = dgvOperacionesPropiedad.Rows.Add();
                dataGridViewRow = dgvOperacionesPropiedad.Rows[indice];
                dataGridViewRow.Cells["ope_id"].Value = obj.ope_id;
                CargarTipoOperacion(obj);
                dataGridViewRow.Cells["ope_tipo_operacion"].Value = obj.ope_tipo_operacion;
                dataGridViewRow.Cells["ope_fecha"].Value = obj.ope_fecha;//.ToString("dd/MM/yyyy");
                dataGridViewRow.Cells["pro_tip_descripcion"].Value = obj.tbpropiedad.tbtipopropiedad.tip_descripcion;
            }
        }

        private void CargarTipoOperacion(tboperaciones oper)
        {
            if (oper.tas_id != null)
                oper.ope_tipo_operacion = ConfigurationManager.AppSettings["OPERTASACI"].ToString();
            if (oper.env_id != null)
                oper.ope_tipo_operacion = ConfigurationManager.AppSettings["OPERENVENT"].ToString();
            if (oper.rev_id != null)
                oper.ope_tipo_operacion = ConfigurationManager.AppSettings["OPERRESVEN"].ToString();
            if (oper.ven_id != null)
                oper.ope_tipo_operacion = ConfigurationManager.AppSettings["OPERVENTA"].ToString();
            if (oper.ena_id != null)
                oper.ope_tipo_operacion = ConfigurationManager.AppSettings["OPERENALQU"].ToString();
            if (oper.rea_id != null)
                oper.ope_tipo_operacion = ConfigurationManager.AppSettings["OPERRESALQ"].ToString();
            if (oper.alq_id != null)
                oper.ope_tipo_operacion = ConfigurationManager.AppSettings["OPERALQUIL"].ToString();
            if (oper.enc_id != null)
                oper.ope_tipo_operacion = ConfigurationManager.AppSettings["OPERENCUES"].ToString();
        }

        #region Abrir operación
        private void dgvOperacionesPropiedad_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tboperaciones operacion = ObtenerOperacionSeleccionada();

                operacionBusiness = new OperacionBusiness();
                operacion = (tboperaciones)operacionBusiness.GetElement(operacion);

                if (operacion != null)
                {
                    string nombreForm = ObtenerNombreFormulario(operacion);

                    Assembly frmAssembly = Assembly.LoadFile(Application.ExecutablePath);
                    Type tipoDeFormulario = frmAssembly.GetTypes().Where(x => x.Name == nombreForm).SingleOrDefault();
                    formularioOperacion = (Form)Activator.CreateInstance(tipoDeFormulario, new object[] { operacion, this });

                    AbrirFormulario(formularioOperacion, "Operación");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al seleccionar Operación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirFormulario(Form formularioPopUp, string textFormulario)
        {
            Assembly frmAssembly = Assembly.LoadFile(Application.ExecutablePath);
            string frmCode = formularioPopUp.Name;
            string frmNombre = textFormulario;

            formularioPopUp.ShowIcon = true;
            formularioPopUp.Text = frmNombre;
            formularioPopUp.Icon = (Icon)Recursos.ResourceImages.ResourceManager.GetObject("Tool");

            formularioPopUp.MdiParent = this.MdiParent;
            formularioPopUp.WindowState = FormWindowState.Minimized;
            formularioPopUp.Show();
            formularioPopUp.WindowState = FormWindowState.Maximized;
            formularioPopUp.Show();
        }

        private tboperaciones ObtenerOperacionSeleccionada()
        {
            dataGridViewRow = dgvOperacionesPropiedad.SelectedRows[0];
            tboperaciones operacionSeleccionada = new tboperaciones();
            operacionSeleccionada.ope_id = Convert.ToInt32(dataGridViewRow.Cells["ope_id"].Value);
            return operacionSeleccionada;
        }

        private string ObtenerNombreFormulario(tboperaciones _operacion)
        {
            if (_operacion.tas_id != null)
                return ConfigurationManager.AppSettings["tas_id"].ToString();

            if (_operacion.env_id != null)
                return ConfigurationManager.AppSettings["env_id"].ToString();

            if (_operacion.rev_id != null)
                return ConfigurationManager.AppSettings["rev_id"].ToString();

            if (_operacion.ven_id != null)
                return ConfigurationManager.AppSettings["ven_id"].ToString();

            if (_operacion.ena_id != null)
                return ConfigurationManager.AppSettings["ena_id"].ToString();

            if (_operacion.rea_id != null)
                return ConfigurationManager.AppSettings["rea_id"].ToString();

            if (_operacion.alq_id != null)
                return ConfigurationManager.AppSettings["alq_id"].ToString();

            if (_operacion.enc_id != null)
                return ConfigurationManager.AppSettings["enc_id"].ToString();

            return string.Empty;
        }
        #endregion
        #endregion

        #region Carga de combos
        private void CargarCombos()
        {
            this.SetearDisplayValue();
            this.CargarTipoPropiedad();
            this.CargarPiso();
            this.CargarDepto();
        }

        private void SetearDisplayValue()
        {
            cmbTipoPropiedad.ValueMember = "tip_id";
            cmbTipoPropiedad.DisplayMember = "tip_descripcion";

            cmbPiso.ValueMember = ComboBoxItem.ValueMember;
            cmbPiso.DisplayMember = ComboBoxItem.DisplayMember;

            cmbDepartamento.ValueMember = ComboBoxItem.ValueMember;
            cmbDepartamento.DisplayMember = ComboBoxItem.DisplayMember;
        }

        private void CargarTipoPropiedad()
        {
            tipoPropiedadBusiness = new TipoPropiedadBusiness();
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
            this.CargarCombo(listasDeElementos.GetListaDepto(), cmbDepartamento);
        }

        private void CargarCombo(List<ComboBoxItem> lista, ComboBox combo)
        {
            foreach (var obj in lista)
                combo.Items.Add(obj);
        }

        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
