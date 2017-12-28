using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LandManagement.Business;
using LandManagement.Utilidades;
using System.Reflection;
using LandManagement.Entities;
using log4net;

namespace LandManagement
{
    public partial class frmPropiedadListado : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private frmPropiedadABM formularioPropiedadABM;
        private DataGridViewRow dataGridViewRow;
        private DisplayNameHelper displayNameHelper;

        public frmPropiedadListado()
        {
            InitializeComponent();
        }

        private void frmPropiedadListado_Load(object sender, EventArgs e)
        {
            pnlControles.AutoScroll = true;
            CargarGrilla();
        }

        public void CargarGrilla()
        {
            //this.clienteBusiness = new ClienteBusiness();
            dgvPropiedad.Rows.Clear();
            dgvPropiedad.Columns.Clear();
            string[] columnasGrilla = { "pro_id",
                                          "tip_id",
                                          "pro_tip_descripcion",
                                          "pro_calle",
                                          "pro_numero",
                                          "pro_piso",
                                          "pro_departamento",
                                          "pro_codigo_postal",
                                          "pro_localidad",
                                          "pro_caracteristica"};

            int i = 0;
            foreach (string s in columnasGrilla)
            {
                PropertyInfo pi = typeof(tbpropiedad).GetProperty(s);
                displayNameHelper = new DisplayNameHelper();
                string columna = displayNameHelper.GetMetaDisplayName(pi);
                dgvPropiedad.Columns.Add(s, columna);
                i++;
            }

            dgvPropiedad.Columns[0].Visible = false;
            dgvPropiedad.Columns[1].Visible = false;

            CargarDataGridViewLista();
        }

        private void CargarDataGridViewLista()
        {
            PropiedadBusiness propiedadBusiness = new PropiedadBusiness();
            List<tbpropiedad> listaPropiedad = (List<tbpropiedad>)propiedadBusiness.GetList();
            CargarDataGridView(listaPropiedad);
        }

        private void CargarDataGridView(List<tbpropiedad> listaObjetos)
        {
            dgvPropiedad.Rows.Clear();
            int indice;
            foreach (var obj in listaObjetos)
            {
                indice = dgvPropiedad.Rows.Add();
                dataGridViewRow = dgvPropiedad.Rows[indice];
                dataGridViewRow.Cells["pro_id"].Value = obj.pro_id;
                dataGridViewRow.Cells["tip_id"].Value = obj.tip_id;
                dataGridViewRow.Cells["pro_tip_descripcion"].Value = obj.tbtipopropiedad.tip_descripcion;
                dataGridViewRow.Cells["pro_calle"].Value = obj.pro_calle;
                dataGridViewRow.Cells["pro_numero"].Value = obj.pro_numero;
                dataGridViewRow.Cells["pro_piso"].Value = obj.pro_piso;
                dataGridViewRow.Cells["pro_departamento"].Value = obj.pro_departamento;
                dataGridViewRow.Cells["pro_codigo_postal"].Value = obj.pro_codigo_postal;
                dataGridViewRow.Cells["pro_localidad"].Value = obj.pro_localidad;
                dataGridViewRow.Cells["pro_caracteristica"].Value = obj.pro_caracteristica;
            }
        }

        #region Crear una nueva propiedad
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            formularioPropiedadABM = new frmPropiedadABM(this);
            AbrirFormulario(formularioPropiedadABM, "Alta de una Propiedad");
        }
        #endregion
 
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPropiedad.SelectedRows.Count != 0)
                {
                    if (MensajeEliminacionOK() == System.Windows.Forms.DialogResult.Yes)
                    {
                        dataGridViewRow = dgvPropiedad.SelectedRows[0];
                        int idSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["pro_id"].Value);
                        PropiedadBusiness propiedadBusiness = new PropiedadBusiness();
                        propiedadBusiness.Delete(new tbpropiedad() { pro_id = idSeleccionado });
                        this.CargarGrilla();
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

        private void dgvPropiedad_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbpropiedad propiedad = ObtenerClienteSeleccionado();

                formularioPropiedadABM = new frmPropiedadABM(propiedad, this);
                AbrirFormulario(formularioPropiedadABM, "Planilla de Propiedad");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al seleccionar propiedad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private tbpropiedad ObtenerClienteSeleccionado()
        {
            dataGridViewRow = dgvPropiedad.SelectedRows[0];
            int idSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["pro_id"].Value);

            PropiedadBusiness propiedadBusiness = new PropiedadBusiness();
            tbpropiedad obj = (tbpropiedad)propiedadBusiness.GetElement(
                new tbpropiedad() { pro_id = idSeleccionado });
            return obj;
        }

        #region Herramienta de Búsqueda

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> listaExcluir = new List<string>() { "pro_id", "tip_id" };

                BuscarEnDataGridView buscar = new BuscarEnDataGridView();

                PropiedadBusiness propiedadBusiness = new PropiedadBusiness();
                List<tbpropiedad> listaFiltrada = (List<tbpropiedad>)propiedadBusiness.GetList();
                listaFiltrada = buscar.FiltrarDataGrid(listaFiltrada, listaExcluir, txbBuscarPor.Text);
                CargarDataGridView(listaFiltrada);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al buscar propiedad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Error al recargar propiedades.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

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

        private void AbrirFormulario(Form formularioPopUp, string textFormulario)
        {
            Formularios formularios = new Formularios();
            formularios.InstanciarFormulario(this.MdiParent, formularioPopUp, textFormulario);
        }

    }
}
