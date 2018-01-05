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
using LandManagement.Utilidades.UserControls;

namespace LandManagement
{
    public partial class frmAlquilada : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private tboperaciones operacion;
        private Form formPadre;
        DisplayNameHelper displayNameHelper;
        ValidarControles validarControles;
        private ErrorProvider errorProvider1 = new ErrorProvider();
        UserControlPropietarios userControlPropietarios = null;

        public frmAlquilada()
        {
            InitializeComponent();
        }

        public frmAlquilada(tboperaciones _operacion, Form _formularioPadre)
        {
            InitializeComponent();

            this.operacion = _operacion;
            this.formPadre = _formularioPadre;

            btnGuardar.Click -= new EventHandler(btnGuardar_Click);
            btnGuardar.Click += new EventHandler(btnGuardarActualiza_Click);
        }

        private void frmAlquilada_Load(object sender, EventArgs e)
        {
            try
            {
                //User control propietarios
                userControlPropietarios = new UserControlPropietarios();
                userControlPropietarios.Location = new Point(10, 269);
                userControlPropietarios.SetearNombreGroupBox("Locador");
                pnlControles.Controls.Add(userControlPropietarios);

                pnlControles.AutoScroll = true;
                cmbCliente.Sorted = true;
                cmbGarante.Sorted = true;
                this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
                this.CargarCombos();

                gbxDetallePropiedad.Enabled = false;
                rdbServiciosCargoLocatario.Checked = true;
                rdbPagoEfectivo.Checked = true;

                cmbDireccion.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbDireccion.AutoCompleteSource = AutoCompleteSource.ListItems;

                cmbCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;

                cmbGarante.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbGarante.AutoCompleteSource = AutoCompleteSource.ListItems;

                InicializarGrillaLocatarios();
                InicializarGrillaGarantes();

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
                    operacion.tbalquilada = new tbalquilada();

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

        /// <summary>
        /// Solo se carga completo cuando es un Create, si es un update, se invoca directamente a guardar
        /// objeto actualizable.
        /// </summary>
        /// <param name="_operacion">La operación existente ya almacenada en base de datos.</param>
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
            CargoLocatarioALaOperacion(_operacion);
            CargoGaranteALaOperacion(_operacion);
            CargaObjetoActualizable(_operacion);
        }

        private void CargoPropietariosALaOperacion(tboperaciones _operacion)
        {
            tbclienteoperacion clienteOperacion;
            _operacion.tbclienteoperacion.Clear();

            var listaClientes = userControlPropietarios.ObtenerPropietarios();

            foreach (var obj in listaClientes)
            {
                clienteOperacion = new tbclienteoperacion();
                clienteOperacion.cli_id = obj.cli_id;
                clienteOperacion.stc_id = (int)TipoOperador.PROPIETARI;

                _operacion.tbclienteoperacion.Add(clienteOperacion);
            }
        }

        public void CargoLocatarioALaOperacion(tboperaciones _operacion)
        {
            tbclienteoperacion clienteOperacion;

            if (dgvLocatarios.Rows.Count > 0)
            {
                foreach (DataGridViewRow obj in dgvLocatarios.Rows)
                {
                    clienteOperacion = new tbclienteoperacion();
                    clienteOperacion.cli_id = this.ObtenerIdLocatarioGrilla(obj);
                    clienteOperacion.stc_id = (int)TipoOperador.LOCATARIO;

                    _operacion.tbclienteoperacion.Add(clienteOperacion);
                }
            }
        }

        public void CargoGaranteALaOperacion(tboperaciones _operacion)
        {
            tbclienteoperacion clienteOperacion;

            if (dgvGarantes.Rows.Count > 0)
            {
                foreach (DataGridViewRow obj in dgvGarantes.Rows)
                {
                    clienteOperacion = new tbclienteoperacion();
                    clienteOperacion.cli_id = this.ObtenerIdGaranteGrilla(obj);
                    clienteOperacion.stc_id = (int)TipoOperador.GARANALQUI;

                    _operacion.tbclienteoperacion.Add(clienteOperacion);
                }
            }
        }

        private void CargaObjetoActualizable(tboperaciones _operacion)
        {
            CargoDatosOperacionAlquilada(_operacion);
        }

        private void CargoDatosOperacionAlquilada(tboperaciones _operacion)
        {
            _operacion.tbalquilada.alq_fecha_inicio = dtpFechaInicio.Value;
            _operacion.tbalquilada.alq_fecha_fin = dtpFechaFin.Value;
            _operacion.tbalquilada.alq_fecha_desocupacion = dtpFechaDesocupacion.Value;
            _operacion.tbalquilada.alq_precio_primer_anio = ValidarDecimalNulo(txbPrimerAnio.Text);
            _operacion.tbalquilada.alq_precio_segundo_anio = ValidarDecimalNulo(txbSegundoAnio.Text);
            _operacion.tbalquilada.alq_precio_tercer_anio = ValidarDecimalNulo(txbTercerAnio.Text);
            _operacion.tbalquilada.alq_precio_cuarto_anio = ValidarDecimalNulo(txbCuartoAnio.Text);
            _operacion.tbalquilada.alq_precio_quinto_anio = ValidarDecimalNulo(txbQuintoAnio.Text);

            //Servicios a cargo del locador
            _operacion.tbalquilada.alq_servicios_cargo_locador = rdbServiciosCargoLocador.Checked;

            //Pago en administracion
            _operacion.tbalquilada.alq_pago_administracion = cbxEnAdministracion.Checked;

            //Factura con IVA
            _operacion.tbalquilada.alq_factura_iva = cbxConIva.Checked;

            //Pago con deposito
            _operacion.tbalquilada.alq_pago_deposito = rdbPagoDeposito.Checked;
            _operacion.tbalquilada.alq_banco = txbBanco.Text;
            _operacion.tbalquilada.alq_numero_cuenta = txbBancoNumeroCuenta.Text;
        }

        private void GuardaObjeto(tboperaciones _operacion)
        {
            OperacionBusiness operacionBusiness = new OperacionBusiness();
            if (this.getOperacionExistente() != null)
                operacionBusiness.Update(_operacion, _operacion.tbalquilada);
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
            CargarGrillaPropietarios(_operacion);
            CargarGrillaLocatarios(_operacion);
            CargarGrillaGarantes(_operacion);

            //Cargo datos del objeto actualizable
            dtpFechaInicio.Value = _operacion.tbalquilada.alq_fecha_inicio;
            dtpFechaFin.Value = _operacion.tbalquilada.alq_fecha_fin;
            dtpFechaDesocupacion.Value = _operacion.tbalquilada.alq_fecha_desocupacion;
            txbPrimerAnio.Text = _operacion.tbalquilada.alq_precio_primer_anio.ToString();
            txbSegundoAnio.Text = _operacion.tbalquilada.alq_precio_segundo_anio.ToString();
            txbTercerAnio.Text = _operacion.tbalquilada.alq_precio_tercer_anio.ToString();
            txbCuartoAnio.Text = _operacion.tbalquilada.alq_precio_cuarto_anio.ToString();
            txbQuintoAnio.Text = _operacion.tbalquilada.alq_precio_quinto_anio.ToString();

            //Servicios a cargo del locador
            if (_operacion.tbalquilada.alq_servicios_cargo_locador)
                rdbServiciosCargoLocador.Checked = true;

            //Pago en administracion
            if (_operacion.tbalquilada.alq_pago_administracion != null &&
                _operacion.tbalquilada.alq_pago_administracion == true)
                cbxEnAdministracion.Checked = true;
            else
                cbxEnAdministracion.Checked = false;

            //Factura con IVA
            if (_operacion.tbalquilada.alq_factura_iva != null &&
                _operacion.tbalquilada.alq_factura_iva == true)
                cbxConIva.Checked = true;
            else
                cbxConIva.Checked = false;

            //Pago con deposito
            if (_operacion.tbalquilada.alq_pago_deposito != null &&
                _operacion.tbalquilada.alq_pago_deposito == true)
                rdbPagoDeposito.Checked = true;
            else
                rdbPagoDeposito.Checked = false;

            txbBanco.Text = _operacion.tbalquilada.alq_banco.ToString();
            txbBancoNumeroCuenta.Text = _operacion.tbalquilada.alq_numero_cuenta.ToString();
        }

        private void CargarGrillaPropietarios(tboperaciones _operacion)
        {
            //Cargo user control propietarios
            userControlPropietarios.Enabled = false;
            userControlPropietarios.CargarGrillaPropietariosOperacion(_operacion.ope_id);
        }

        /// <summary>
        /// Carga el combo de direcciones, tener en cuenta que tambien carga los datos de la propiedad. 
        /// Ya que, al realizar la seleccion del item, se dispara el itemChange del combo y se 
        /// cargan automaticamente los propietarios correspondientes a esa operación.
        /// </summary>
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

        /// <summary>
        /// Agrega los locatarios a la grilla (los quita del combo y los agrega a la grilla)
        /// </summary>
        /// <param name="_operacion">Objeto operacion del cual obtendra los reservantes.</param>
        private void CargarGrillaLocatarios(tboperaciones _operacion)
        {
            cmbCliente.Enabled = false;
            btnAgregarLocatario.Enabled = false;
            btnQuitarLocatario.Enabled = false;

            var idsLocatarios = GetIdsLocatarios(_operacion);

            foreach (tbcliente obj in cmbCliente.Items)
            {
                if (idsLocatarios.Contains(obj.cli_id))
                    this.AgregaLocatarioGrilla(obj);
            }
        }

        private List<int> GetIdsLocatarios(tboperaciones _operacion)
        {
            var idsLocatarios = GetClientesOperacion(_operacion)
                                    .Where(x => x.stc_id == (int)TipoOperador.LOCATARIO)
                                    .Select(x => x.cli_id).ToList<int>();
            return idsLocatarios;
        }

        /// <summary>
        /// Agrega los Garantes a la grilla (los quita del combo y los agrega a la grilla)
        /// </summary>
        /// <param name="_operacion">Objeto operacion del cual obtendra los reservantes.</param>
        private void CargarGrillaGarantes(tboperaciones _operacion)
        {
            cmbGarante.Enabled = false;
            btnAgregarGarante.Enabled = false;
            btnQuitarGarante.Enabled = false;

            var idsGarantes = GetIdsGarantes(_operacion);

            foreach (tbcliente obj in cmbGarante.Items)
            {
                if (idsGarantes.Contains(obj.cli_id))
                    this.AgregaGaranteGrilla(obj);
            }
        }

        private List<int> GetIdsGarantes(tboperaciones _operacion)
        {
            var idsGarantes = GetClientesOperacion(_operacion)
                                    .Where(x => x.stc_id == (int)TipoOperador.GARANALQUI)
                                    .Select(x => x.cli_id).ToList<int>();
            return idsGarantes;
        }

        private IEnumerable<int> GetIdsOperador(tboperaciones _operacion, int _codigoOperador)
        {
            var idsOperadores = GetClientesOperacion(_operacion)
                .Where(x => x.stc_id == _codigoOperador).Select(x => x.cli_id);
            return idsOperadores;
        }

        private IEnumerable<tbclienteoperacion> GetClientesOperacion(tboperaciones _operacion)
        {
            var clientesOperacion = this.operacion.tbclienteoperacion
                .Where(x => x.ope_id == _operacion.ope_id);

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

        #region Cargo controles de Dirección, Cliente y Garante seleccionado
        private void cmbDireccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbpropiedad propiedad = (tbpropiedad)cmbDireccion.SelectedItem;
            CargarControlesPropiedad(propiedad);
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
        }

        #endregion

        #region Grilla de Locatarios
        public void InicializarGrillaLocatarios()
        {
            dgvLocatarios.Rows.Clear();
            dgvLocatarios.Columns.Clear();
            string[] columnasGrilla = {
                                        "cli_id",
                                        "tif_id",
                                        "cli_nombre_completo",
                                        "cli_nombre",
                                        "cli_apellido",
                                        "cli_numero_documento",
                                        "cli_fecha_nacimiento"
                                      };

            int i = 0;
            DisplayNameHelper displayNameHelper = new DisplayNameHelper();
            foreach (string s in columnasGrilla)
            {
                PropertyInfo pi = typeof(tbcliente).GetProperty(s);
                string columna = displayNameHelper.GetMetaDisplayName(pi);
                dgvLocatarios.Columns.Add(s, columna);
                i++;
            }

            dgvLocatarios.Columns[0].Visible = false;
            dgvLocatarios.Columns[1].Visible = false;
            dgvLocatarios.Columns[2].Visible = false;
        }

        private void btnAgregarLocatario_Click(object sender, EventArgs e)
        {
            tbcliente cliente = (tbcliente)cmbCliente.SelectedItem;
            cmbCliente.Items.Remove(cliente);
            AgregaLocatarioGrilla(cliente);
        }

        private void btnQuitarLocatario_Click(object sender, EventArgs e)
        {
            int idCliente = 0;
            if (dgvLocatarios.Rows.Count > 0)
            {
                foreach (DataGridViewRow obj in dgvLocatarios.SelectedRows)
                {
                    idCliente = this.ObtenerIdLocatarioGrilla(obj);
                    dgvLocatarios.Rows.RemoveAt(obj.Index);
                }

                ClienteBusiness clienteBusiness = new ClienteBusiness();
                tbcliente cliente = (tbcliente)clienteBusiness.GetElement(new tbcliente() { cli_id = idCliente });
                cmbCliente.Items.Add(cliente);
            }
        }

        public void AgregaLocatarioGrilla(tbcliente _locatario)
        {
            DataGridViewRow dataGridViewRow = new DataGridViewRow();
            int indice = dgvLocatarios.Rows.Add();
            dataGridViewRow = dgvLocatarios.Rows[indice];
            dataGridViewRow.Cells["cli_id"].Value = _locatario.cli_id;
            dataGridViewRow.Cells["tif_id"].Value = _locatario.tif_id;
            dataGridViewRow.Cells["cli_nombre_completo"].Value = _locatario.cli_nombre_completo;
            dataGridViewRow.Cells["cli_nombre"].Value = _locatario.cli_nombre;
            dataGridViewRow.Cells["cli_apellido"].Value = _locatario.cli_apellido;
            dataGridViewRow.Cells["cli_numero_documento"].Value = _locatario.cli_numero_documento;
            dataGridViewRow.Cells["cli_fecha_nacimiento"].Value = _locatario.cli_fecha_nacimiento.ToString("dd/MM/yyyy");
        }

        public int ObtenerIdLocatarioGrilla(DataGridViewRow _dataGridViewRow)
        {
            return Convert.ToInt32(_dataGridViewRow.Cells["cli_id"].Value);
        }
        #endregion

        #region Grilla de Garantes
        public void InicializarGrillaGarantes()
        {
            dgvGarantes.Rows.Clear();
            dgvGarantes.Columns.Clear();
            string[] columnasGrilla = {
                                        "cli_id",
                                        "tif_id",
                                        "cli_nombre_completo",
                                        "cli_nombre",
                                        "cli_apellido",
                                        "cli_numero_documento",
                                        "cli_fecha_nacimiento"
                                      };

            int i = 0;
            DisplayNameHelper displayNameHelper = new DisplayNameHelper();
            foreach (string s in columnasGrilla)
            {
                PropertyInfo pi = typeof(tbcliente).GetProperty(s);
                string columna = displayNameHelper.GetMetaDisplayName(pi);
                dgvGarantes.Columns.Add(s, columna);
                i++;
            }

            dgvGarantes.Columns[0].Visible = false;
            dgvGarantes.Columns[1].Visible = false;
            dgvGarantes.Columns[2].Visible = false;
        }

        private void btnAgregarGarante_Click(object sender, EventArgs e)
        {
            tbcliente cliente = (tbcliente)cmbGarante.SelectedItem;
            cmbGarante.Items.Remove(cliente);
            AgregaGaranteGrilla(cliente);
        }

        private void btnQuitarGarante_Click(object sender, EventArgs e)
        {
            int idCliente = 0;
            if (dgvGarantes.Rows.Count > 0)
            {
                foreach (DataGridViewRow obj in dgvGarantes.SelectedRows)
                {
                    idCliente = this.ObtenerIdGaranteGrilla(obj);
                    dgvGarantes.Rows.RemoveAt(obj.Index);
                }

                ClienteBusiness clienteBusiness = new ClienteBusiness();
                tbcliente cliente = (tbcliente)clienteBusiness.GetElement(new tbcliente() { cli_id = idCliente });
                cmbGarante.Items.Add(cliente);
            }
        }

        public void AgregaGaranteGrilla(tbcliente _garante)
        {
            DataGridViewRow dataGridViewRow = new DataGridViewRow();
            int indice = dgvGarantes.Rows.Add();
            dataGridViewRow = dgvGarantes.Rows[indice];
            dataGridViewRow.Cells["cli_id"].Value = _garante.cli_id;
            dataGridViewRow.Cells["tif_id"].Value = _garante.tif_id;
            dataGridViewRow.Cells["cli_nombre_completo"].Value = _garante.cli_nombre_completo;
            dataGridViewRow.Cells["cli_nombre"].Value = _garante.cli_nombre;
            dataGridViewRow.Cells["cli_apellido"].Value = _garante.cli_apellido;
            dataGridViewRow.Cells["cli_numero_documento"].Value = _garante.cli_numero_documento;
            dataGridViewRow.Cells["cli_fecha_nacimiento"].Value = _garante.cli_fecha_nacimiento.ToString("dd/MM/yyyy");
        }

        public int ObtenerIdGaranteGrilla(DataGridViewRow _dataGridViewRow)
        {
            return Convert.ToInt32(_dataGridViewRow.Cells["cli_id"].Value);
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

        #region Carga de Combos TipoPropiedad, Piso, Depto, Direcciones, Clientes y Garante
        private void CargarCombos()
        {
            this.SetearDisplayValue();
            this.CargarTipoPropiedad();
            this.CargarPiso();
            this.CargarDepto();
            this.CargarDirecciones();
            this.CargarClienteYGarante();
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

            cmbCliente.ValueMember = "cli_id";
            cmbCliente.DisplayMember = "cli_nombre_completo";

            cmbGarante.ValueMember = "cli_id";
            cmbGarante.DisplayMember = "cli_nombre_completo";
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

        private void CargarClienteYGarante()
        {
            ClienteBusiness clienteBusiness = new ClienteBusiness();
            List<tbcliente> listaNombresCompletos = (List<tbcliente>)clienteBusiness.GetList();

            if (listaNombresCompletos.Count != 0)
                foreach (var obj in listaNombresCompletos)
                {
                    cmbCliente.Items.Add(obj);
                    cmbGarante.Items.Add(obj);
                }
        }

        private void CargarCombo(List<ComboBoxItem> lista, ComboBox combo)
        {
            foreach (var obj in lista)
                combo.Items.Add(obj);
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

        private void rdbPagoEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPagoEfectivo.Checked)
            {
                txbBanco.Enabled = false;
                txbBancoNumeroCuenta.Enabled = false;
            }
            else
            {
                txbBanco.Enabled = true;
                txbBancoNumeroCuenta.Enabled = true;
            }
        }
        #endregion

        private void ValidarEntero(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

    }
}
