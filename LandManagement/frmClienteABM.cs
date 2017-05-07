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
using System.Text.RegularExpressions;

namespace LandManagement
{
    public partial class frmClienteABM : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ClienteBusiness clienteBusiness;
        private PropiedadBusiness propiedadBusiness;
        private FamiliarBusiness familiarBusiness;
        private TipoFamiliarBusiness tipoFamiliarBusiness;
        private tbcliente cliente;
        private int idCliente = 0;
        private DisplayNameHelper displayNameHelper; 
        private Form formPadre;
        private frmClienteFamiliar formularioClienteFamiliar;
        private frmClientePropiedad formularioClientePropiedad;
        private ListasDeElementos listasDeElementos;
        private DataGridViewRow dataGridViewRow;
        ValidarControles validarControles;
        private ErrorProvider errorProvider1 = new ErrorProvider();

        public frmClienteABM(Form formularioPadre)
        {
            InitializeComponent();
            this.formPadre = formularioPadre;
            familiarBusiness = new FamiliarBusiness();
            propiedadBusiness = new PropiedadBusiness();
            InicializarGrillaFamiliares();
            InicializarGrillaPropiedades();
        }

        public frmClienteABM(tbcliente pCliente, Form formularioPadre)
        {
            InitializeComponent();

            this.formPadre = formularioPadre;
            this.cliente = pCliente;

            familiarBusiness = new FamiliarBusiness();
            propiedadBusiness = new PropiedadBusiness();
            clienteBusiness = new ClienteBusiness();
            this.idCliente = pCliente.cli_id;

            txbNombre.Text = pCliente.cli_nombre;
            txbApellido.Text = pCliente.cli_apellido;
            mtbTelefonoCelular.Text = pCliente.cli_telefono_celular;
            mtbTelefonoParticular.Text = pCliente.cli_telefono_particular;
            mtbTelefonoLaboral.Text = pCliente.cli_telefono_laboral;
            txbEmail.Text = pCliente.cli_email;
            cmbSexo.Text = pCliente.cli_sexo;
            dtpFechaNacimiento.Value = pCliente.cli_fecha_nacimiento;
            txbNacionalidad.Text = pCliente.cli_nacionalidad;
            cmbEstadoCivil.Text = pCliente.cli_estado_civil;
            cmbTipoDocumento.Text = pCliente.cli_tipo_documento;
            txbNumeroDocumento.Text = pCliente.cli_numero_documento;
            txbCuilCuit.Text = pCliente.cli_cuit_cuil;
            txbComoLlego.Text = pCliente.cli_como_llego;

            //Cargo datos de Propiedades importadas
            if (pCliente.cli_actualizado != null)
                dtpActualizado.Value = (DateTime)pCliente.cli_actualizado;

            //titulo se carga en el load, posterior a la carga de combos
            txbNombreDePila.Text = pCliente.cli_nombre_pila;
            if (pCliente.cli_imprime_carta == null)
                cbxImprimeCarta.Checked = false;
            else
                cbxImprimeCarta.Checked = (bool)pCliente.cli_imprime_carta;
            txbEstadoActual.Text = pCliente.cli_estado_actual;

            InicializarGrillaFamiliares();
            InicializarGrillaPropiedades();
            InicializarGrillaCategorias();

            buscapadre(pCliente);
            //Carga grilla propiedades
            foreach (var prop in pCliente.tbpropiedad)
            {
                TipoPropiedadBusiness tipoPropiedadBussiness = new TipoPropiedadBusiness();
                tbtipopropiedad tipoPropiedad = (tbtipopropiedad)tipoPropiedadBussiness.GetElement(new tbtipopropiedad() { tip_id = prop.tip_id });
                prop.pro_tip_descripcion = tipoPropiedad.tip_descripcion;
                AgregaPropiedadAGrilla(prop);
            }

            //Carga Grilla familiares
            foreach (var cli1 in pCliente.tbcliente1)
            {
                tipoFamiliarBusiness = new TipoFamiliarBusiness();
                tbtipofamiliar tipoFamiliar = (tbtipofamiliar)tipoFamiliarBusiness.GetElement(new tbtipofamiliar() { tif_id = cli1.tif_id });
                cli1.cli_parentezco = tipoFamiliar.tif_descripcion;
                AgregaFamiliarAGrilla(cli1);
            }

            //Carga Grilla categorias
            CategoriaBusiness categoriaBusiness = new CategoriaBusiness();
            List<tbcategoria> listaCategorias = (List<tbcategoria>)categoriaBusiness.GetListByClienteId(pCliente);
            foreach (tbcategoria obj in listaCategorias)
                this.AgregaCategoriaAGrilla(obj);

            btnGuardar.Click -= new EventHandler(btnGuardar_Click);
            btnGuardar.Click += new EventHandler(btnGuardarActualiza_Click);

        }

        private void frmClienteABM_Load(object sender, EventArgs e)
        {
            txbDomicilioImportado.Enabled = false;
            pnlControles.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            listasDeElementos = new ListasDeElementos();
            SetearDisplayValueCombos();
            CargarCombos();

            if (this.cliente != null)
            {
                cmbTipoFamiliar.Text = this.cliente.tbtipofamiliar.tif_descripcion;
                cmbTipoDocumento.Text = this.cliente.cli_tipo_documento;
                cmbEstadoCivil.Text = this.cliente.cli_estado_civil;
                cmbSexo.Text = this.cliente.cli_sexo;
                //El titulo se carga aca porque tiene que tener cargado el combo
                cmbTitulo.Text = string.IsNullOrEmpty(this.cliente.cli_titulo) ? "Sr." : this.cliente.cli_titulo;

                CargaDatosDelDomicilio();
            }
        }

        private void CargaDatosDelDomicilio()
        {
            //Cargo datos del domicilio
            tbdomicilio domicilioActual = this.cliente.tbdomicilio.Where(x => x.dom_actual == true).FirstOrDefault();

            if (domicilioActual != null)
            {
                TipoPropiedadBusiness tipoPropiedadBusiness = new TipoPropiedadBusiness();
                tbtipopropiedad tipoPropiedad = (tbtipopropiedad)tipoPropiedadBusiness.GetElement(new tbtipopropiedad() { tip_id = domicilioActual.tip_id });

                txbCalle.Text = domicilioActual.dom_calle;
                txbNumero.Text = domicilioActual.dom_numero.ToString();
                cmbPiso.Text = domicilioActual.dom_piso.ToString();
                cmbDepto.Text = domicilioActual.dom_departamento;
                txbLocalidad.Text = domicilioActual.dom_localidad;
                txbCodigoPostal.Text = domicilioActual.dom_codigo_postal;

                //Cargo domicilio importado
                txbDomicilioImportado.Text = domicilioActual.dom_domicilio_importado;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateChildren())
                {
                    Cursor.Current = Cursors.WaitCursor;

                    this.cliente = new tbcliente();
                    CargaObjeto();
                    GuardaObjeto();
                    MensajeOk();
                    ((frmClienteListado)formPadre).CargarGrilla();
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
                    ((frmClienteListado)formPadre).CargarGrilla();
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
            this.cliente.cli_fecha = dtpFechaAlta.Value;

            this.cliente.tif_id = ((tbtipofamiliar)cmbTipoFamiliar.SelectedItem).tif_id;
            this.cliente.cli_nombre = string.IsNullOrEmpty(txbNombre.Text) ? null : txbNombre.Text;
            this.cliente.cli_apellido = string.IsNullOrEmpty(txbApellido.Text) ? null : txbApellido.Text;
            this.cliente.cli_telefono_celular = MaskedTextboxNulo(mtbTelefonoCelular) ? null : mtbTelefonoCelular.Text;
            this.cliente.cli_telefono_particular = MaskedTextboxNulo(mtbTelefonoParticular) ? null : mtbTelefonoParticular.Text;
            this.cliente.cli_telefono_laboral = MaskedTextboxNulo(mtbTelefonoLaboral) ? null : mtbTelefonoLaboral.Text;
            this.cliente.cli_email = string.IsNullOrEmpty(txbEmail.Text) ? null : txbEmail.Text;
            this.cliente.cli_sexo = string.IsNullOrEmpty(cmbSexo.Text) ? null : cmbSexo.Text;
            this.cliente.cli_fecha_nacimiento = dtpFechaNacimiento.Value;
            this.cliente.cli_nacionalidad = string.IsNullOrEmpty(txbNacionalidad.Text) ? null : txbNacionalidad.Text;
            this.cliente.cli_estado_civil = string.IsNullOrEmpty(cmbEstadoCivil.Text) ? null : cmbEstadoCivil.Text;
            this.cliente.cli_tipo_documento = string.IsNullOrEmpty(cmbTipoDocumento.Text) ? null : cmbTipoDocumento.Text;
            this.cliente.cli_numero_documento = string.IsNullOrEmpty(txbNumeroDocumento.Text) ? null : txbNumeroDocumento.Text;
            this.cliente.cli_cuit_cuil = string.IsNullOrEmpty(txbCuilCuit.Text) ? null : txbCuilCuit.Text;
            this.cliente.cli_como_llego = string.IsNullOrEmpty(txbComoLlego.Text) ? null : txbComoLlego.Text;

            //Cargo campos importados
            this.cliente.cli_actualizado = dtpActualizado.Value;
            this.cliente.cli_titulo = cmbTitulo.Text;
            this.cliente.cli_nombre_pila = txbNombreDePila.Text;
            this.cliente.cli_imprime_carta = cbxImprimeCarta.Checked;
            this.cliente.cli_estado_actual = txbEstadoActual.Text;

            CargaDomicilioAlCliente();
            CargaFamiliaresAlCliente();
            CargaPropiedadesAlCliente();
        }

        private void GuardaObjeto()
        {
            clienteBusiness = new ClienteBusiness();

            if (this.idCliente != 0)
                clienteBusiness.Update(this.cliente);
            else
                clienteBusiness.Create(this.cliente);
        }

        #region Carga domicilio al Cliente

        private void CargaDomicilioAlCliente()
        {
            try
            {
                tbdomicilio domicilio = new tbdomicilio();
                domicilio.tip_id = 1; //Se limino el combo tipo de propiedad;
                domicilio.dom_calle = string.IsNullOrEmpty(txbCalle.Text) ? null : txbCalle.Text;
                domicilio.dom_numero = string.IsNullOrEmpty(txbNumero.Text) ? 0 : Convert.ToInt32(txbNumero.Text);
                domicilio.dom_piso = ((ComboBoxItem)cmbPiso.SelectedItem).Value;
                domicilio.dom_departamento = ((ComboBoxItem)cmbDepto.SelectedItem).Text;
                domicilio.dom_codigo_postal = string.IsNullOrEmpty(txbCodigoPostal.Text) ? null : txbCodigoPostal.Text;
                domicilio.dom_localidad = string.IsNullOrEmpty(txbLocalidad.Text) ? null : txbLocalidad.Text;
                domicilio.dom_actual = true;

                //Guardo siempre el domicilio importado, sino se pierde
                domicilio.dom_domicilio_importado = txbDomicilioImportado.Text;
                
                this.cliente.tbdomicilio.Add(domicilio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
        
        #endregion

        #region Carga Familiares a la Grilla de Familiares

        private void InicializarGrillaFamiliares()
        {
            dgvFamiliares.Rows.Clear();
            dgvFamiliares.Columns.Clear();
            string[] columnasGrilla = {
                                        "cli_id",
                                        "tif_id",
                                        "cli_parentezco",
                                        "cli_nombre",
                                        "cli_apellido",
                                        "cli_fecha_nacimiento"
                                      };

            int i = 0;
            foreach (string s in columnasGrilla)
            {
                PropertyInfo pi = typeof(tbcliente).GetProperty(s);
                displayNameHelper = new DisplayNameHelper();
                string columna = displayNameHelper.GetMetaDisplayName(pi);
                dgvFamiliares.Columns.Add(s, columna);
                i++;
            }

            dgvFamiliares.Columns[0].Visible = false;
            dgvFamiliares.Columns[1].Visible = false;
        }

        public void AgregaFamiliarAGrilla(tbcliente familiar)
        {
            int indice;
            DataGridViewRow dataGridViewRow = new DataGridViewRow();
            indice = dgvFamiliares.Rows.Add();
            dataGridViewRow = dgvFamiliares.Rows[indice];
            dataGridViewRow.Cells["cli_id"].Value = familiar.cli_id;
            dataGridViewRow.Cells["tif_id"].Value = familiar.tif_id;
            dataGridViewRow.Cells["cli_parentezco"].Value = familiar.cli_parentezco;
            dataGridViewRow.Cells["cli_nombre"].Value = familiar.cli_nombre;
            dataGridViewRow.Cells["cli_apellido"].Value = familiar.cli_apellido;
            dataGridViewRow.Cells["cli_fecha_nacimiento"].Value = familiar.cli_fecha_nacimiento;
        }

        private void btnAddFamiliar_Click(object sender, EventArgs e)
        {
            formularioClienteFamiliar = new frmClienteFamiliar(this);
            ControlarInstanciaAbierta(formularioClienteFamiliar, "Alta de un Familiar");
        }

        private void btnRemoveFamiliar_Click(object sender, EventArgs e)
        {
            if (dgvFamiliares.Rows.Count > 0)
                foreach (DataGridViewRow obj in dgvFamiliares.SelectedRows)
                    dgvFamiliares.Rows.RemoveAt(obj.Index);
        }

        private void CargaFamiliaresAlCliente()
        {
            tbcliente clienteFamiliar;
            this.cliente.tbcliente1.Clear();

            if (dgvFamiliares.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvFamiliares.Rows)
                {
                    clienteFamiliar = new tbcliente();
                    clienteFamiliar.cli_fecha = dtpFechaAlta.Value;
                    clienteFamiliar.cli_id = (int)row.Cells["cli_id"].Value;
                    clienteFamiliar.tif_id = (int)row.Cells["tif_id"].Value;
                    clienteFamiliar.cli_nombre = (string)row.Cells["cli_nombre"].Value;
                    clienteFamiliar.cli_apellido = (string)row.Cells["cli_apellido"].Value;
                    clienteFamiliar.cli_fecha_nacimiento = (DateTime)row.Cells["cli_fecha_nacimiento"].Value;
                    clienteFamiliar.cli_tipo_documento = "DNI";
                    clienteFamiliar.cli_numero_documento = "0";

                    this.cliente.tbcliente1.Add(clienteFamiliar);
                }
            }
        }

        #endregion

        #region Carga Propiedades a la Grilla de Propiedades
        private void InicializarGrillaPropiedades()
        {
            dgvPropiedades.Rows.Clear();
            dgvPropiedades.Columns.Clear();
            string[] columnasGrilla = {
                                        "pro_id",
                                        "tip_id",
                                        "pro_tip_descripcion",
                                        "pro_calle",
                                        "pro_numero",
                                        "pro_piso",
                                        "pro_departamento",
                                        "pro_localidad",
                                        "pro_codigo_postal",
                                        "pro_caracteristica"
                                      };

            int i = 0;
            foreach (string s in columnasGrilla)
            {
                PropertyInfo pi = typeof(tbpropiedad).GetProperty(s);
                displayNameHelper = new DisplayNameHelper();
                string columna = displayNameHelper.GetMetaDisplayName(pi);
                dgvPropiedades.Columns.Add(s, columna);
                i++;
            }

            dgvPropiedades.Columns[0].Visible = false;
            dgvPropiedades.Columns[1].Visible = false;
        }

        public void AgregaPropiedadAGrilla(tbpropiedad prop)
        {
            int indice;
            DataGridViewRow dataGridViewRow = new DataGridViewRow();
            indice = dgvPropiedades.Rows.Add();
            dataGridViewRow = dgvPropiedades.Rows[indice];
            dataGridViewRow.Cells["pro_id"].Value = prop.pro_id;
            dataGridViewRow.Cells["tip_id"].Value = prop.tip_id;
            dataGridViewRow.Cells["pro_tip_descripcion"].Value = prop.pro_tip_descripcion;
            dataGridViewRow.Cells["pro_calle"].Value = prop.pro_calle;
            dataGridViewRow.Cells["pro_numero"].Value = prop.pro_numero;
            dataGridViewRow.Cells["pro_piso"].Value = prop.pro_piso;
            dataGridViewRow.Cells["pro_departamento"].Value = prop.pro_departamento;
            dataGridViewRow.Cells["pro_localidad"].Value = prop.pro_localidad;
            dataGridViewRow.Cells["pro_codigo_postal"].Value = prop.pro_codigo_postal;
            dataGridViewRow.Cells["pro_caracteristica"].Value = prop.pro_caracteristica;
        }

        private void btnAddPropiedad_Click(object sender, EventArgs e)
        {
            formularioClientePropiedad = new frmClientePropiedad(this, ObtenerIdsDePropiedadesDeLaGrilla());
            ControlarInstanciaAbierta(formularioClientePropiedad, "Alta de una Propiedad");
        }

        private int[] ObtenerIdsDePropiedadesDeLaGrilla()
        {
            int cantPropiedades = dgvPropiedades.Rows.Count;
            int[] arregloIdsPropiedades = new int[cantPropiedades];
            int i = 0;

            foreach (DataGridViewRow dgvr in dgvPropiedades.Rows)
            {
                arregloIdsPropiedades[i] = Convert.ToInt32(dgvr.Cells["pro_id"].Value);
                i++;
            }
            return arregloIdsPropiedades;
        }

        private void btnRemovePropiedad_Click(object sender, EventArgs e)
        {
            if (dgvPropiedades.Rows.Count > 0)
                foreach (DataGridViewRow obj in dgvPropiedades.SelectedRows)
                    dgvPropiedades.Rows.RemoveAt(obj.Index);
        }

        private void CargaPropiedadesAlCliente()
        {
            tbpropiedad clientePropiedad;
            this.cliente.tbpropiedad.Clear();

            if (dgvPropiedades.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvPropiedades.Rows)
                {
                    clientePropiedad = new tbpropiedad();
                    clientePropiedad.pro_id = (int)row.Cells["pro_id"].Value;
                    clientePropiedad.tip_id = (int)row.Cells["tip_id"].Value;
                    clientePropiedad.pro_calle = (string)row.Cells["pro_calle"].Value;
                    clientePropiedad.pro_numero = (int)row.Cells["pro_numero"].Value;
                    clientePropiedad.pro_piso = (int)row.Cells["pro_piso"].Value;
                    clientePropiedad.pro_departamento = (string)row.Cells["pro_departamento"].Value;
                    clientePropiedad.pro_localidad = (string)row.Cells["pro_localidad"].Value;
                    clientePropiedad.pro_codigo_postal = (string)row.Cells["pro_codigo_postal"].Value;
                    clientePropiedad.pro_caracteristica = (string)row.Cells["pro_caracteristica"].Value;

                    this.cliente.tbpropiedad.Add(clientePropiedad);
                }
            }
        }
        #endregion

        #region Carga Propiedades a la Grilla de Categorias
        private void InicializarGrillaCategorias()
        {
            dgvCategorias.Rows.Clear();
            dgvCategorias.Columns.Clear();
            string[] columnasGrilla = {
                                        "cat_id",
                                        "cat_descripcion",
                                        "cat_fecha"
                                      };

            int i = 0;
            foreach (string s in columnasGrilla)
            {
                PropertyInfo pi = typeof(tbcategoria).GetProperty(s);
                displayNameHelper = new DisplayNameHelper();
                string columna = displayNameHelper.GetMetaDisplayName(pi);
                dgvCategorias.Columns.Add(s, columna);
                i++;
            }

            dgvCategorias.Columns[0].Visible = false;
        }

        public void AgregaCategoriaAGrilla(tbcategoria _categoria)
        {
            int indice;
            DataGridViewRow dataGridViewRow = new DataGridViewRow();
            indice = dgvCategorias.Rows.Add();
            dataGridViewRow = dgvCategorias.Rows[indice];
            dataGridViewRow.Cells["cat_id"].Value = _categoria.cat_id;
            dataGridViewRow.Cells["cat_descripcion"].Value = _categoria.cat_descripcion;
            dataGridViewRow.Cells["cat_fecha"].Value = _categoria.cat_fecha;
        }
        #endregion

        #region CARGA DE COMBOS

        private void SetearDisplayValueCombos()
        {
            cmbTipoFamiliar.DisplayMember = "tif_descripcion";
            cmbTipoFamiliar.ValueMember = "tif_id";

            cmbTipoDocumento.DisplayMember = ComboBoxItem.DisplayMember;
            cmbTipoDocumento.ValueMember = ComboBoxItem.ValueMember;

            cmbEstadoCivil.DisplayMember = ComboBoxItem.DisplayMember;
            cmbEstadoCivil.ValueMember = ComboBoxItem.ValueMember;

            cmbSexo.DisplayMember = ComboBoxItem.DisplayMember;
            cmbSexo.ValueMember = ComboBoxItem.ValueMember;

            cmbPiso.DisplayMember = ComboBoxItem.DisplayMember;
            cmbPiso.ValueMember = ComboBoxItem.ValueMember;

            cmbDepto.DisplayMember = ComboBoxItem.DisplayMember;
            cmbDepto.ValueMember = ComboBoxItem.ValueMember;

            cmbTitulo.DisplayMember = ComboBoxItem.DisplayMember;
            cmbTitulo.ValueMember = ComboBoxItem.ValueMember;
        }

        private void CargarCombos()
        {
            this.CargarTipoFamiliar();
            this.CargarTipoDocumento();
            this.CargarEstadoCivil();
            this.CargarSexo();
            this.CargarPiso();
            this.CargarDepto();
            this.CargarTitulo();
            SetearIndiceCombo();
        }

        private void SetearIndiceCombo()
        {
            cmbTipoFamiliar.SelectedIndex = 0;
            cmbTipoDocumento.SelectedIndex = 0;
            cmbEstadoCivil.SelectedIndex = 0;
            cmbSexo.SelectedIndex = 0;
            cmbPiso.SelectedIndex = 0;
            cmbDepto.SelectedIndex = 0;
            cmbTitulo.SelectedIndex = 0;
        }

        private void CargarTipoFamiliar()
        {
            tipoFamiliarBusiness = new TipoFamiliarBusiness();
            List<tbtipofamiliar> listaFamiliares = (List<tbtipofamiliar>)tipoFamiliarBusiness.GetList();

            foreach (var obj in listaFamiliares)
                cmbTipoFamiliar.Items.Add(obj);
        }

        private void CargarTipoDocumento()
        {
            this.CargarCombo(listasDeElementos.GetListaTipoDocumento(), cmbTipoDocumento);
        }

        private void CargarEstadoCivil()
        {
            this.CargarCombo(listasDeElementos.GetListaEstadoCivil(), cmbEstadoCivil);
        }

        private void CargarSexo()
        {
            this.CargarCombo(listasDeElementos.GetListaSexo(), cmbSexo);
        }

        private void CargarPiso()
        {
            this.CargarCombo(listasDeElementos.GetListaPiso(), cmbPiso);
        }

        private void CargarDepto()
        {
            this.CargarCombo(listasDeElementos.GetListaDepto(), cmbDepto);
        }

        private void CargarTitulo()
        {
            this.CargarCombo(listasDeElementos.GetListaTitulo(), cmbTitulo);
        }

        private void CargarCombo(List<ComboBoxItem> lista, ComboBox combo)
        {
            foreach (var obj in lista)
                combo.Items.Add(obj);
        }

        #endregion

        #region Abrir PopUp Familiar Seleccionado

        private void dgvFamiliares_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbcliente familiar = ObtenerFamiliarSeleccionado();

                if (familiar != null)
                {
                    formularioClienteFamiliar = new frmClienteFamiliar(familiar, e.RowIndex, this);
                    ControlarInstanciaAbierta(formularioClienteFamiliar, "PLanilla de un Familiar");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al seleccionar familiar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private tbcliente ObtenerFamiliarSeleccionado()
        {
            dataGridViewRow = dgvFamiliares.SelectedRows[0];
            int idFamiliarSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["cli_id"].Value);

#if DEBUG
#warning "el if idFamiliarSeleccionado == 0) se agrego para que no pinche cuando se trabaja con un nuevo familiar en memoria. Mejora a realizar."
#endif

            if (idFamiliarSeleccionado == 0)
                return null;

            tbcliente familiar = (tbcliente)familiarBusiness.GetElement(
                new tbcliente() { cli_id = idFamiliarSeleccionado });
            return familiar;
        }

        public void ActualizarFamiliarSeleccionado(tbcliente familiarActualizado, int indiceFilaActualizada)
        {
            DataGridViewRow dgvRowActualizada = dgvFamiliares.Rows[indiceFilaActualizada];
            dataGridViewRow.Cells["cli_id"].Value = familiarActualizado.cli_id;
            dataGridViewRow.Cells["tif_id"].Value = familiarActualizado.tif_id;
            dataGridViewRow.Cells["cli_parentezco"].Value = familiarActualizado.cli_parentezco;
            dataGridViewRow.Cells["cli_nombre"].Value = familiarActualizado.cli_nombre;
            dataGridViewRow.Cells["cli_apellido"].Value = familiarActualizado.cli_apellido;
            dataGridViewRow.Cells["cli_fecha_nacimiento"].Value = familiarActualizado.cli_fecha_nacimiento;
        }

        #endregion

        #region Abrir PopUp Propiedad Seleccionada

        private void dgvPropiedades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbpropiedad propiedad = ObtenerPropiedadSeleccionada();

                if (propiedad != null)
                {
                    formularioClientePropiedad = new frmClientePropiedad(propiedad, e.RowIndex, this);
                    ControlarInstanciaAbierta(formularioClientePropiedad, "PLanilla de un Familiar");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al seleccionar propiedad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private tbpropiedad ObtenerPropiedadSeleccionada()
        {
            dataGridViewRow = dgvPropiedades.SelectedRows[0];
            tbpropiedad propiedadSeleccionada = new tbpropiedad();

            propiedadSeleccionada.pro_id = Convert.ToInt32(dataGridViewRow.Cells["pro_id"].Value);

#if DEBUG
#warning Mejorar se valida con pro_id == 0 porque no se admite modificación en memoria.
#endif

            if (propiedadSeleccionada.pro_id == 0)
                return null;

            propiedadSeleccionada.tip_id = Convert.ToInt32(dataGridViewRow.Cells["tip_id"].Value);
            propiedadSeleccionada.pro_tip_descripcion = dataGridViewRow.Cells["pro_tip_descripcion"].Value.ToString();
            propiedadSeleccionada.pro_calle = dataGridViewRow.Cells["pro_calle"].Value.ToString();
            propiedadSeleccionada.pro_numero = Convert.ToInt32(dataGridViewRow.Cells["pro_numero"].Value);
            propiedadSeleccionada.pro_piso = Convert.ToInt32(dataGridViewRow.Cells["pro_piso"].Value);
            propiedadSeleccionada.pro_departamento = dataGridViewRow.Cells["pro_departamento"].Value.ToString();
            propiedadSeleccionada.pro_localidad = dataGridViewRow.Cells["pro_localidad"].Value.ToString();
            propiedadSeleccionada.pro_codigo_postal = dataGridViewRow.Cells["pro_codigo_postal"].Value.ToString();
            propiedadSeleccionada.pro_caracteristica = dataGridViewRow.Cells["pro_caracteristica"].Value.ToString();

            return propiedadSeleccionada;
        }

        public void ActualizarPropiedadSeleccionada(tbpropiedad propiedadActualizada, int indiceFilaActualizada)
        {
            DataGridViewRow dgvRowActualizada = dgvPropiedades.Rows[indiceFilaActualizada];

            dataGridViewRow.Cells["pro_id"].Value = propiedadActualizada.pro_id;
            dataGridViewRow.Cells["tip_id"].Value = propiedadActualizada.tip_id;
            dataGridViewRow.Cells["pro_tip_descripcion"].Value = propiedadActualizada.pro_tip_descripcion;
            dataGridViewRow.Cells["pro_calle"].Value = propiedadActualizada.pro_calle;
            dataGridViewRow.Cells["pro_numero"].Value = propiedadActualizada.pro_numero;
            dataGridViewRow.Cells["pro_piso"].Value = propiedadActualizada.pro_piso;
            dataGridViewRow.Cells["pro_departamento"].Value = propiedadActualizada.pro_departamento;
            dataGridViewRow.Cells["pro_localidad"].Value = propiedadActualizada.pro_localidad;
            dataGridViewRow.Cells["pro_codigo_postal"].Value = propiedadActualizada.pro_codigo_postal;
            dataGridViewRow.Cells["pro_caracteristica"].Value = propiedadActualizada.pro_caracteristica;
        }

        #endregion

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

        private void ControlarInstanciaAbierta(Form formularioPopUp, string textFormulario)
        {
            Assembly frmAssembly = Assembly.LoadFile(Application.ExecutablePath);
            string frmCode = formularioPopUp.Name;
            string frmNombre = textFormulario;

            foreach (Type type in frmAssembly.GetTypes())
            {
                if (type.BaseType == typeof(Form))
                {
                    if (type.Name == frmCode)
                    {
                        if (Application.OpenForms.Cast<Form>().Any(form => form.Name == frmCode))
                        {
                            Form f = Application.OpenForms[frmCode];
                            f.WindowState = FormWindowState.Normal;
                            formularioPopUp.Text = frmNombre;
                            f.Activate();
                        }
                        else
                        {
                            formularioPopUp.ShowIcon = true;
                            formularioPopUp.Text = frmNombre;
                            formularioPopUp.Icon = (Icon)Recursos.ResourceImages.ResourceManager.GetObject("Tool");

                            formularioPopUp.MdiParent = this.MdiParent;
                            formularioPopUp.WindowState = FormWindowState.Minimized;
                            formularioPopUp.Show();
                            formularioPopUp.WindowState = FormWindowState.Maximized;
                            formularioPopUp.Show();

                            //ActivateMdiChild(null);
                            //ActivateMdiChild(formularioPopUp);
                        }

                    }

                }
            }

        }

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

        private void ValidatingControlDni(object sender, CancelEventArgs e)
        {
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            TextBox textBoxDni = sender as TextBox;

            if (string.IsNullOrEmpty(textBoxDni.Text))
                ValidatingControl(sender, e);

            if (!string.IsNullOrEmpty(errorProvider1.GetError(textBoxDni)))
            {
                e.Cancel = true;
                return;
            }

            errorProvider1.SetError(textBoxDni, "");
        }

        private void buscapadre(tbcliente cliente)
        {
            tbcliente padre = new tbcliente();
            List<tbcliente> listaClientes = (List<tbcliente>)clienteBusiness.GetList();
            tipoFamiliarBusiness = new TipoFamiliarBusiness();
            if (cliente.cli_id_padre != null)
            {
                padre = (from item in listaClientes
                         where item.cli_id.ToString().Equals(cliente.cli_id_padre.ToString())
                         select item).First();
                tbtipofamiliar tipoFamiliar = (tbtipofamiliar)tipoFamiliarBusiness.GetElement(new tbtipofamiliar() { tif_id = padre.tif_id });
                TreeNode nodo1 = new TreeNode(padre.cli_nombre + " " + padre.cli_apellido + "(" + tipoFamiliar.tif_descripcion + ")");
                treeView1.Nodes.Add(nodo1);
                cargafam(padre, nodo1);
            }
            else
            {
                tbtipofamiliar tipoFamiliar = (tbtipofamiliar)tipoFamiliarBusiness.GetElement(new tbtipofamiliar() { tif_id = cliente.tif_id });
                TreeNode nodo1 = new TreeNode(cliente.cli_nombre + " " + cliente.cli_apellido + "(" + tipoFamiliar.tif_descripcion + ")");
                treeView1.Nodes.Add(nodo1);

                cargafam(cliente, nodo1);
            }

        }
        private void cargafam(tbcliente cliente, TreeNode nodePadre)
        {
            tipoFamiliarBusiness = new TipoFamiliarBusiness();
            ClienteBusiness clienteBusiness = new ClienteBusiness();
            List<tbcliente> listaClientes = (List<tbcliente>)clienteBusiness.GetList();
            foreach (var obj in listaClientes)
            {
                tbtipofamiliar tipoFamiliar = (tbtipofamiliar)tipoFamiliarBusiness.GetElement(new tbtipofamiliar() { tif_id = obj.tif_id });
                TreeNode nuevoNodo = new TreeNode();
                if (cliente.cli_id == obj.cli_id_padre)
                {
                    //agrego el hijo
                    nuevoNodo.Text = (obj.cli_nombre + " " + obj.cli_apellido + "(" + tipoFamiliar.tif_descripcion + ")");
                    nodePadre.Nodes.Add(nuevoNodo);
                    cargafam(obj, nuevoNodo);
                }

            }

        }

        private void ValidatingControlMaskedTextBox(object sender, CancelEventArgs e)
        {
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            MaskedTextBox maskedTextBox = sender as MaskedTextBox;

            if (!this.MaskedTextboxNulo(maskedTextBox))
                if (!maskedTextBox.MaskCompleted)
                {
                    errorProvider1.SetError(maskedTextBox, "Error en validación.");

                    e.Cancel = true;
                    return;
                }

            errorProvider1.SetError(maskedTextBox, "");
        }

        #region Validacion de controles
        private void ValidarEnteros(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        bool ValidarEmail(string email)
        {
            try
            {
                string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                    + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                    + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

                Regex regEx = new Regex(pattern);
                Match match = regEx.Match(email);

                if (!match.Success)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }

        private void txbEmail_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbEmail.Text))
            {
                if (!ValidarEmail(txbEmail.Text))
                {
                    btnGuardar.Enabled = false;
                    txbEmail.ForeColor = Color.Red;
                    txbEmail.Focus();
                }
                else
                {
                    txbEmail.ForeColor = Color.Black;
                    btnGuardar.Enabled = true;
                }
            }
            else
                btnGuardar.Enabled = true;

        }

        private void txbNumeroDocumento_TextChanged(object sender, EventArgs e)
        {
            if (this.cliente == null)
            {
                TextBox textBox = sender as TextBox;
                tbcliente cliente = new tbcliente() { cli_numero_documento = textBox.Text };

                ClienteBusiness clienteBus = new ClienteBusiness();
                tbcliente clienteRepetido = (tbcliente)clienteBus.ValidarExistenciaByDNI(cliente);

                if (clienteRepetido != null)
                    errorProvider1.SetError(textBox, "Numero Existente.");
                else
                    errorProvider1.SetError(textBox, "");
            }
        }

        private bool MaskedTextboxNulo(MaskedTextBox _maskedTextBox)
        {
            if (_maskedTextBox.Text.Replace("-", "").Replace(" ", "").Length == 0)
                return true;
            return false;
        }
        #endregion

    }
}
