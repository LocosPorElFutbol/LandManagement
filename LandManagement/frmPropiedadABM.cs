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
    public partial class frmPropiedadABM : frmBase
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private TipoPropiedadBusiness tipoPropiedadBusiness;
        private ClienteBusiness clienteBusiness;
        private OperacionBusiness operacionBusiness;
        DisplayNameHelper displayNameHelper;
        private tbpropiedad propiedad;
        private int idPropiedad = 0;
        private ListasDeElementos listasDeElementos;
        private Form formPadre;
        private DataGridViewRow dataGridViewRow;
        private Form formularioOperacion;
        ValidarControles validarControles;
        private ErrorProvider errorProvider1 = new ErrorProvider();

        public frmPropiedadABM(Form _formularioPadre)
        {
            InitializeComponent();
            this.formPadre = _formularioPadre;
        }

        public frmPropiedadABM(tbpropiedad prop, Form formularioPadre)
        {
            InitializeComponent();
            this.clienteBusiness = new ClienteBusiness();
            this.formPadre = formularioPadre;
            this.propiedad = prop;
            this.idPropiedad = prop.pro_id;

            CargarGrillaClientes();
            CargarGrillaOperaciones();

            btnGuardar.Click -= new EventHandler(btnGuardar_Click);
            btnGuardar.Click += new EventHandler(btnGuardarActualiza_Click);
        }

        private void frmPropiedadABM_Load(object sender, EventArgs e)
        {
            try
            {
                pnlControles.AutoScroll = true;
                listasDeElementos = new ListasDeElementos();
                this.CargarCombos();

                if (idPropiedad != 0)
                    this.CargarControlesPropiedad(this.propiedad);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateChildren())
                {
                    Cursor.Current = Cursors.WaitCursor;

                    this.propiedad = new tbpropiedad();
                    CargaObjeto();
                    GuardaObjeto();
                    MensajeOk();
                    ((frmPropiedadListado)formPadre).CargarGrilla();
                    this.Close();

                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarActualiza_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateChildren())
                {
                    Cursor.Current = Cursors.WaitCursor;

                    CargaObjeto();
                    GuardaObjeto();
                    MensajeOk();
                    ((frmPropiedadListado)formPadre).CargarGrilla();
                    this.Close();

                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MensajeCancelar();
        }

        private void CargaObjeto()
        {
            this.propiedad.tip_id = ((tbtipopropiedad)cmbTipoPropiedad.SelectedItem).tip_id;

            this.propiedad.pro_calle = txbCalle.Text;
            this.propiedad.pro_numero = Convert.ToInt32(txbNumero.Text);
            this.propiedad.pro_piso = ((ComboBoxItem)cmbPiso.SelectedItem).Value;
            if (((ComboBoxItem)cmbDepartamento.SelectedItem) != null)
                this.propiedad.pro_departamento = ((ComboBoxItem)cmbDepartamento.SelectedItem).Text;
            else
                this.propiedad.pro_departamento = string.Empty;
            this.propiedad.pro_localidad = txbLocalidad.Text;
            this.propiedad.pro_codigo_postal = txbCodigoPostal.Text;
            this.propiedad.pro_caracteristica = txbCaracteristicas.Text;
        }

        private void GuardaObjeto()
        {
            PropiedadBusiness propiedadBusiness = new PropiedadBusiness();

            if (this.idPropiedad != 0)
                propiedadBusiness.Update(this.propiedad);
            else
                propiedadBusiness.Create(this.propiedad);
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
            cmbDepartamento.Text = p.pro_departamento;
            txbLocalidad.Text = p.pro_localidad;
            txbCodigoPostal.Text = p.pro_codigo_postal;
            txbCaracteristicas.Text = p.pro_caracteristica;
        }

        #region Carga Grilla de Clientes

        public void CargarGrillaClientes()
        {
            InicializarGrillaClientes();

            //Busco los clientes por id
            ClienteBusiness clienteBiz = new ClienteBusiness();
            List<tbcliente> lc = 
                clienteBiz.GetClientesPorIdPropiedad(this.propiedad.pro_id) as List<tbcliente>;

            foreach (var obj in lc)
                AgregaClienteAGrilla(obj);
            //Busco los clientes por id

            //OLD
            //foreach (var obj in this.propiedad.tbcliente)
            //    AgregaClienteAGrilla(obj);
        }

        private void InicializarGrillaClientes()
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

        public void AgregaClienteAGrilla(tbcliente familiar)
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

        public override void CargarGrillaOperaciones()
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
            Formularios formularios = new Formularios();
            formularios.InstanciarFormulario(this.MdiParent, formularioPopUp, "Operación");
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
            Formularios formularios = new Formularios();
            return formularios.ObtenerNombreFormulario(_operacion);
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

        private void ValidatingControl(object sender, CancelEventArgs e)
        {
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            validarControles = new ValidarControles();
            Control control = validarControles.ObtenerControl(sender);
            string error = validarControles.ValidarControl(sender);

            //Ingresa al if cuando error tiene un valor 
            //(es el mensaje de error que se va a mostrar)
            if (!string.IsNullOrEmpty(error))
            {
                errorProvider1.SetError(control, error);

                //Me valida hasta ingresar el valor correcto
                e.Cancel = true;
                return;
            }

            //error es nulo
            errorProvider1.SetError(control, error);
        }


        private void MensajeOk()
        {
            MessageBox.Show("El registro se guardo correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeCancelar()
        {
            DialogResult dialogResult = DialogResult.None;

            dialogResult = MessageBox.Show("Se aplicaron cambios. Se perderán todos los datos que no hayan sido guardados. \n¿Desea cerrar la ventana?",
                "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                // Stop the validation of any controls so the form can close.
                AutoValidate = AutoValidate.Disable;
                this.Close();
            }
        }
    }
}
