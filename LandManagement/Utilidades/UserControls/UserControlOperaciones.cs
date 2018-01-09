using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using LandManagement.Entities;
using LandManagement.Business;
using System.Configuration;
using log4net;

namespace LandManagement.Utilidades.UserControls
{
    public partial class UserControlOperaciones : UserControl
    {
        public static readonly ILog log = log4net.LogManager.GetLogger 
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Form formularioOperacion;
        
        public UserControlOperaciones()
        {
            InitializeComponent();
            InicializarGrillaOperaciones();
        }

        #region Inicializa y carga grilla de operaciones

        private void InicializarGrillaOperaciones()
        {
            dgvOperaciones.Rows.Clear();
            dgvOperaciones.Columns.Clear();
            string[] columnasGrilla = {
                                        "ope_id",
                                        "ope_tipo_operacion",
                                        "ope_fecha"
                                      };

            int i = 0;
            DisplayNameHelper displayNameHelper = null;
            foreach (string s in columnasGrilla)
            {
                PropertyInfo pi = typeof(tboperaciones).GetProperty(s);
                displayNameHelper = new DisplayNameHelper();
                string columna = displayNameHelper.GetMetaDisplayName(pi);
                dgvOperaciones.Columns.Add(s, columna);
                i++;
            }
        }

        private void CargarDataGridView(List<tboperaciones> listaOperaciones)
        {
            dgvOperaciones.Rows.Clear();
            DataGridViewRow dataGridViewRow;
            int indice;
            foreach (var obj in listaOperaciones)
            {
                indice = dgvOperaciones.Rows.Add();
                dataGridViewRow = dgvOperaciones.Rows[indice];
                dataGridViewRow.Cells["ope_id"].Value = obj.ope_id;
                CargarTipoOperacion(obj);
                dataGridViewRow.Cells["ope_tipo_operacion"].Value = obj.ope_tipo_operacion;
                dataGridViewRow.Cells["ope_fecha"].Value = obj.ope_fecha;
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

        #endregion

        #region Abrir operación
        private void dgvOperaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tboperaciones operacion = ObtenerOperacionSeleccionada();

                OperacionBusiness operacionBusiness = new OperacionBusiness();
                operacion = (tboperaciones)operacionBusiness.GetElement(operacion);

                if (operacion != null)
                {
                    string nombreForm = ObtenerNombreFormulario(operacion);

                    Assembly frmAssembly = Assembly.LoadFile(Application.ExecutablePath);
                    Type tipoDeFormulario = frmAssembly.GetTypes().Where(x => x.Name == nombreForm).SingleOrDefault();
                    formularioOperacion = (Form)Activator.CreateInstance(tipoDeFormulario, new object[] { operacion, this.ParentForm });

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

        private tboperaciones ObtenerOperacionSeleccionada()
        {
            DataGridViewRow dataGridViewRow = dgvOperaciones.SelectedRows[0];
            tboperaciones operacionSeleccionada = new tboperaciones();
            operacionSeleccionada.ope_id = Convert.ToInt32(dataGridViewRow.Cells["ope_id"].Value);
            return operacionSeleccionada;
        }

        private string ObtenerNombreFormulario(tboperaciones _operacion)
        {
            Formularios formularios = new Formularios();
            return formularios.ObtenerNombreFormulario(_operacion);
        }

        private void AbrirFormulario(Form formularioPopUp, string textFormulario)
        {
            Formularios formularios = new Formularios();
            formularios.InstanciarFormulario(this.ParentForm.MdiParent, formularioPopUp, "Operación");
        }
        #endregion

        public void CargarGrillaOperacionesPorIdCliente(int idCliente)
        {
            OperacionBusiness operacionBusiness = new OperacionBusiness();
            var listaOperaciones =
                operacionBusiness.GetOperacionesPorIdCliente(idCliente) as List<tboperaciones>;

            this.CargarDataGridView(listaOperaciones);
        }

        public void CargarGrillaOperacionesPorIdPropiedad(int idPropiedad)
        {
            OperacionBusiness operacionBusiness = new OperacionBusiness();
            var listaOperaciones = 
                (List<tboperaciones>)operacionBusiness.GetListByPropiedadId(idPropiedad);

            this.CargarDataGridView(listaOperaciones);
        }
    }
}