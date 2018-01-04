using LandManagement.Business;
using LandManagement.Entities;
using LandManagement.Utilidades;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace LandManagement
{
    public partial class frmEnAlquiler : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private tboperaciones operacion;
        private Form formPadre;
        DisplayNameHelper displayNameHelper;
        ValidarControles validarControles;
        private ErrorProvider errorProvider1 = new ErrorProvider();

        public frmEnAlquiler()
        {
            InitializeComponent();
        }

        public frmEnAlquiler(tboperaciones _operacion, Form _formularioPadre)
        {
            InitializeComponent();

            this.operacion = _operacion;
            this.formPadre = _formularioPadre;

            btnGuardar.Click -= new EventHandler(btnGuardar_Click);
            btnGuardar.Click += new EventHandler(btnGuardarActualiza_Click);
        }

        private void frmEnAlquiler_Load(object sender, EventArgs e)
        {
            try
            {
                pnlControles.AutoScroll = true;
                this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
                this.CargarCombos();
                this.InicializarGrillaPropietarios();
                gbxDetallePropiedad.Enabled = false;

                cmbDireccion.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbDireccion.AutoCompleteSource = AutoCompleteSource.ListItems;

                if (this.getOperacionExistente() != null)
                {
                    tboperaciones operacionLocal = new tboperaciones();
                    operacionLocal = this.getOperacionExistente();
                    CargoFormulario(operacionLocal);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al cargar formulario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateChildren())
                {
                    Cursor.Current = Cursors.WaitCursor;

                    tboperaciones operacion = new tboperaciones();
                    operacion.tbenalquiler = new tbenalquiler();

                    CargaObjeto(operacion);
                    GuardaObjeto(operacion);
                    MensajeOk();
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

                    tboperaciones operacionLocal = new tboperaciones();
                    operacionLocal = this.getOperacionExistente();
                    CargaObjetoActualizable(operacionLocal);
                    GuardaObjeto(operacionLocal);

                    MensajeOk();
                    ((frmOperacionListado)formPadre).CargarGrillaOperaciones();
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

        private void CargaObjeto(tboperaciones _operacion)
        {
            //Asigno fecha de la operacion
            _operacion.ope_fecha = dtpFecha.Value;

            //Asigno id de la propiedad a la operacion
            _operacion.pro_id = ((tbpropiedad)cmbDireccion.SelectedItem).pro_id;
            //this.operacion.pro_id = ((tbpropiedad)cmbDireccion.SelectedItem).pro_id;

            //Asigno id de usuario a la operacion
            _operacion.usu_id = Utilidades.VariablesDeSesion.UsuarioLogueado.usu_id;
            //this.operacion.usu_id = Utilidades.VariablesDeSesion.UsuarioLogueado.usu_id;

            CargoPropietariosALaOperacion(_operacion);
            CargaObjetoActualizable(_operacion);
        }

        private void CargoPropietariosALaOperacion(tboperaciones _operacion)
        {
            tbclienteoperacion clienteOperacion;
            _operacion.tbclienteoperacion.Clear();

            if (dgvPropietarios.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvPropietarios.Rows)
                {
                    clienteOperacion = new tbclienteoperacion();
                    clienteOperacion.cli_id = (int)row.Cells["cli_id"].Value;
                    clienteOperacion.stc_id = (int)TipoOperador.PROPIETARI;

                    _operacion.tbclienteoperacion.Add(clienteOperacion);
                }
            }
        }

        private void CargaObjetoActualizable(tboperaciones _operacion)
        {
            CargoDatosOperacionEnAlquiler(_operacion);
        }

        private void CargoDatosOperacionEnAlquiler(tboperaciones _operacion)
        {
            _operacion.tbenalquiler.ena_precio_primer_anio = ValidarDecimalNulo(txbPrecioPrimerAnio.Text);
            _operacion.tbenalquiler.ena_precio_segundo_anio = ValidarDecimalNulo(txbPrecioSegundoAnio.Text);
            _operacion.tbenalquiler.ena_precio_tercer_anio = ValidarDecimalNulo(txbPrecioTercerAnio.Text);
            _operacion.tbenalquiler.ena_precio_cuarto_anio = ValidarDecimalNulo(txbPrecioCuartoAnio.Text);
            _operacion.tbenalquiler.ena_precio_quinto_anio = ValidarDecimalNulo(txbPrecioQuintoAnio.Text);
            _operacion.tbenalquiler.ena_expensas = ValidarDecimalNulo(txbExpensas.Text);
            _operacion.tbenalquiler.ena_abl = ValidarDecimalNulo(txbABL.Text);
            _operacion.tbenalquiler.ena_aguas = ValidarDecimalNulo(txbAgua.Text);
            _operacion.tbenalquiler.ena_luz = ValidarDecimalNulo(txbLuz.Text);
            _operacion.tbenalquiler.ena_gas = ValidarDecimalNulo(txbGas.Text);
            _operacion.tbenalquiler.ena_telefono = ValidarDecimalNulo(txbTelefono.Text);
        }

        private void GuardaObjeto(tboperaciones _operacion)
        {
            OperacionBusiness operacionBusiness = new OperacionBusiness();
            if (this.getOperacionExistente() != null)
                operacionBusiness.Update(_operacion, _operacion.tbenalquiler);
            else
                operacionBusiness.Create(_operacion);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.MensajeCancelar();
        }

        #region Cargo Controles con los Datos de la Operacion Almacenada
        private void CargoFormulario(tboperaciones _operacion)
        {
            dtpFecha.Enabled = false;
            dtpFecha.Value = _operacion.ope_fecha.Value;

            CargarComboDireccion(_operacion);
            //cargar grilla comprador
            //CargoGrillaComprador(_operacion);

            txbPrecioPrimerAnio.Text = _operacion.tbenalquiler.ena_precio_primer_anio.ToString();
            txbPrecioSegundoAnio.Text = _operacion.tbenalquiler.ena_precio_segundo_anio.ToString();
            txbPrecioTercerAnio.Text = _operacion.tbenalquiler.ena_precio_tercer_anio.ToString();
            txbPrecioCuartoAnio.Text = _operacion.tbenalquiler.ena_precio_cuarto_anio.ToString();
            txbPrecioQuintoAnio.Text = _operacion.tbenalquiler.ena_precio_quinto_anio.ToString();
            txbExpensas.Text = _operacion.tbenalquiler.ena_expensas.ToString();
            txbABL.Text = _operacion.tbenalquiler.ena_abl.ToString();
            txbAgua.Text = _operacion.tbenalquiler.ena_aguas.ToString();
            txbLuz.Text = _operacion.tbenalquiler.ena_luz.ToString();
            txbGas.Text = _operacion.tbenalquiler.ena_gas.ToString();
            txbTelefono.Text = _operacion.tbenalquiler.ena_telefono.ToString();
        }

        private void CargarComboDireccion(tboperaciones _operacion)
        {
            cmbDireccion.Enabled = false;
            tbpropiedad propiedadSeleccionada = null;
            foreach (tbpropiedad obj in cmbDireccion.Items)
            {
                if (obj.pro_id == _operacion.pro_id)
                {
                    propiedadSeleccionada = obj;
                    break;
                }
            }
            cmbDireccion.SelectedItem = propiedadSeleccionada;
        }
        #endregion

        #region Cargo controles de Dirección y Cliente seleccionado
        private void cmbDireccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarControlesPropiedad((tbpropiedad)cmbDireccion.SelectedItem);
        }

        private void CargarControlesPropiedad(tbpropiedad _propiedad)
        {
            cmbTipoPropiedad.Text = _propiedad.tbtipopropiedad.tip_descripcion;
            txbCalle.Text = _propiedad.pro_calle;
            txbNumero.Text = _propiedad.pro_numero.ToString();
            cmbPiso.Text = _propiedad.pro_piso.ToString();
            cmbDepto.Text = _propiedad.pro_departamento;
            txbLocalidad.Text = _propiedad.pro_localidad;
            txbCodigoPostal.Text = _propiedad.pro_codigo_postal;

            CargoPropietariosALaGrilla(_propiedad);
        }

        private void CargoPropietariosALaGrilla(tbpropiedad p)
        {
            dgvPropietarios.Rows.Clear();
            dgvPropietarios.Refresh();

            //Carga los propietarios al momento de generar la operación
            if (this.getOperacionExistente() != null)
            {
                var idsPropietarios = this.GetIdsPropietarios(this.getOperacionExistente());
                foreach (tbcliente obj in this.ObtenerClientes())
                    if (idsPropietarios.Contains(obj.cli_id))
                        AgregaPropietarioGrilla(obj);
            }
            else
                AgregarPropietariosGrilla(p);
        }

        private List<tbcliente> ObtenerClientes()
        {
            ClienteBusiness clienteBusiness = new ClienteBusiness();
            return (List<tbcliente>)clienteBusiness.GetList();
        }

        /// <summary>
        /// Obtiene los ids de los propietarios de la tabla tbclienteoperacion
        /// </summary>
        /// <param name="_operacion">Operacion almacenada en bd</param>
        /// <returns>ids de los propietarios</returns>
        private IEnumerable<int> GetIdsPropietarios(tboperaciones _operacion)
        {
            var idsPropietarios = GetClientesOperacion(_operacion)
                .Where(x => x.stc_id == (int)TipoOperador.PROPIETARI).Select(x => x.cli_id);
            return idsPropietarios;
        }

        /// <summary>
        /// Obtiene todos los registros de la tabla tbclienteoperacion por id de operación existente
        /// </summary>
        /// <param name="_operacion">Operacion almacenada en bd</param>
        /// <returns>Registros correspondientes a la operación enviada por parametro</returns>
        private IEnumerable<tbclienteoperacion> GetClientesOperacion(tboperaciones _operacion)
        {
            var clientesOperacion = _operacion.tbclienteoperacion
                .Where(x => x.ope_id == this.operacion.ope_id);

            return clientesOperacion;
        }

        /// <summary>
        /// Obtiene la operación existente. Solo contiene datos cuando se selecciona la operación desde
        /// el listado de operaciones. Cuando se crea una nueva operación devuelve null
        /// </summary>
        /// <returns>Operación existente y almacenada en BD.</returns>
        private tboperaciones getOperacionExistente()
        {
            if (this.operacion != null)
                return this.operacion;
            return null;
        }
        #endregion

        #region Carga Propietarios a la Grilla de Propietarios

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

        private void AgregarPropietariosGrilla(tbpropiedad prop)
        {
            foreach (tbcliente obj in prop.tbcliente)
                AgregaPropietarioGrilla(obj);
        }

        public void AgregaPropietarioGrilla(tbcliente familiar)
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

        #region Carga de Combos TipoPropiedad, Piso, Depto, Direcciones
        private void CargarCombos()
        {
            this.SetearDisplayValue();
            this.CargarTipoPropiedad();
            this.CargarPiso();
            this.CargarDepto();
            this.CargarDirecciones();
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
            ListasDeElementos listasDeElementos = new ListasDeElementos();
            this.CargarCombo(listasDeElementos.GetListaPiso(), cmbPiso);
        }

        private void CargarDepto()
        {
            ListasDeElementos listasDeElementos = new ListasDeElementos();
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

        private void CargarCombo(List<ComboBoxItem> lista, ComboBox combo)
        {
            foreach (var obj in lista)
                combo.Items.Add(obj);
        }
        #endregion

        #region Mensajes de Pantalla
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

        private void MensajeOk()
        {
            MessageBox.Show("El registro se guardo correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Validación de controles
        private void ValidatingControl(object sender, CancelEventArgs e)
        {
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            validarControles = new ValidarControles();
            Control control = validarControles.ObtenerControl(sender);
            string error = validarControles.ValidarControl(sender);

            if (!string.IsNullOrEmpty(error))
            {
                errorProvider1.SetError(control, error);

                //Me valida hasta ingresar el valor correcto
                e.Cancel = true;
                return;
            }

            errorProvider1.SetError(control, error);
        }

        private void ValidarDecimales(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                   (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private double ValidarDecimalNulo(string _valorTextbox)
        {
            return string.IsNullOrEmpty(_valorTextbox) ? 0 : Convert.ToDouble(_valorTextbox);
        }
        #endregion

    }
}
