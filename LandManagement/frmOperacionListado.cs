using LandManagement.Business;
using LandManagement.Entities;
using LandManagement.Utilidades;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace LandManagement
{
    public partial class frmOperacionListado : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private OperacionBusiness operacionBusiness;
        private DataGridViewRow dataGridViewRow;
        private DisplayNameHelper displayNameHelper;
        private Form formularioOperacion;

        public frmOperacionListado()
        {
            InitializeComponent();
            this.operacionBusiness = new OperacionBusiness();
        }

        private void frmOperacionListado_Load(object sender, EventArgs e)
        {
            pnlControles.AutoScroll = true;
            CargarGrillaOperaciones();
        }


        public void CargarGrillaOperaciones()
        {
            InicializarGrilla();
            CargarDataGridViewLista();
        }

        private void InicializarGrilla()
        {
            dgvOperaciones.Rows.Clear();
            dgvOperaciones.Columns.Clear();
            string[] columnasGrilla = { "ope_id",
                                        "ope_tipo_operacion",
                                        "ope_fecha",
                                        "pro_tip_descripcion",
                                        "pro_calle",
                                        "pro_numero",
                                        "pro_piso",
                                        "pro_departamento",
                                        "pro_codigo_postal",
                                        "pro_localidad" };

            int i = 0;
            foreach (string s in columnasGrilla)
            {
                PropertyInfo pi = typeof(tboperaciones).GetProperty(s);
                displayNameHelper = new DisplayNameHelper();
                string columna = displayNameHelper.GetMetaDisplayName(pi);
                dgvOperaciones.Columns.Add(s, columna);
                i++;
            }
        }

        private void CargarDataGridViewLista()
        {
            List<tboperaciones> listaOperaciones = (List<tboperaciones>)operacionBusiness.GetList();
            CargarDataGridView(listaOperaciones);
        }

        private void CargarDataGridView(List<tboperaciones> listaOperaciones)
        {
            dgvOperaciones.Rows.Clear();
            CargarTipoOperacion(listaOperaciones);
            int indice;
            foreach (var obj in listaOperaciones)
            {
                indice = dgvOperaciones.Rows.Add();
                dataGridViewRow = dgvOperaciones.Rows[indice];
                dataGridViewRow.Cells["ope_id"].Value = obj.ope_id;
                dataGridViewRow.Cells["ope_tipo_operacion"].Value = obj.ope_tipo_operacion;
                dataGridViewRow.Cells["ope_fecha"].Value = obj.ope_fecha;//.ToString("dd/MM/yyyy");
                dataGridViewRow.Cells["pro_tip_descripcion"].Value = obj.tbpropiedad.tbtipopropiedad.tip_descripcion;
                dataGridViewRow.Cells["pro_calle"].Value = obj.tbpropiedad.pro_calle;
                dataGridViewRow.Cells["pro_numero"].Value = obj.tbpropiedad.pro_numero;
                dataGridViewRow.Cells["pro_piso"].Value = obj.tbpropiedad.pro_piso;
                dataGridViewRow.Cells["pro_departamento"].Value = obj.tbpropiedad.pro_departamento;
                dataGridViewRow.Cells["pro_codigo_postal"].Value = obj.tbpropiedad.pro_codigo_postal;
                dataGridViewRow.Cells["pro_localidad"].Value = obj.tbpropiedad.pro_localidad;
            }
        }

        private void CargarTipoOperacion(List<tboperaciones> _listaOperaciones)
        {
            foreach (var oper in _listaOperaciones)
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
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOperaciones.SelectedRows.Count != 0)
                {
                    if (MensajeEliminacionOK() == System.Windows.Forms.DialogResult.Yes)
                    {
                        dataGridViewRow = dgvOperaciones.SelectedRows[0];
                        int idOperacionSeleccionada = Convert.ToInt32(dataGridViewRow.Cells["ope_id"].Value);
                        operacionBusiness.Delete(
                            operacionBusiness.GetElement( 
                                new tboperaciones() { ope_id = idOperacionSeleccionada }) as tboperaciones);
                        this.CargarGrillaOperaciones();
                    }
                }
                else
                    this.MensajeSeleccionarElemento();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al eliminar registro. Existe una referencia hacia este registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Abrir PopUp de Operaciones
        private void dgvOperaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
                    ControlarInstanciaAbierta(formularioOperacion, "Operación");
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

        private tboperaciones ObtenerOperacionSeleccionada()
        {
            dataGridViewRow = dgvOperaciones.SelectedRows[0];
            tboperaciones operacionSeleccionada = new tboperaciones();
            operacionSeleccionada.ope_id = Convert.ToInt32(dataGridViewRow.Cells["ope_id"].Value);
            return operacionSeleccionada;
        }
        #endregion

        #region Herramienta de Búsqueda
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                BuscarEnDataGridView buscar = new BuscarEnDataGridView();
                dgvOperaciones = buscar.FiltrarDataGridView(dgvOperaciones, txbBuscarPor.Text);
                
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al buscar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarDataGridViewLista();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al recargar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Mensajes de Pantalla
        private DialogResult MensajeEliminacionOK()
        {
            return MessageBox.Show("¿Desea eliminar el registro?",
                        "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void MensajeSeleccionarElemento()
        {
            MessageBox.Show("Debe Seleccionar un elemento de la lista",
                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

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

    }
}
