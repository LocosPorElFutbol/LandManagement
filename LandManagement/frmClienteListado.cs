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
    public partial class frmClienteListado : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private frmClienteABM formularioClienteABM;
        private DataGridViewRow dataGridViewRow;
        private DisplayNameHelper displayNameHelper;

        public frmClienteListado()
        {
            InitializeComponent();
        }

        private void frmClienteListado_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            pnlControles.AutoScroll = true;
            CargarGrilla();

            this.Cursor = Cursors.Default;
        }

        public void CargarGrilla()
        {
            ClienteBusiness clienteBusiness = new ClienteBusiness();
            dgvClientes.Rows.Clear();
            dgvClientes.Columns.Clear();
            string[] columnasGrilla = { "cli_id",
                                        "cli_id_import",
                                        "cli_id_padre",
										"tif_id",
										"ccl_id",
                                        "cli_fecha",
										"ccl_descripcion",
                                        "cli_parentezco",
										"cli_nombre",
                                        "cli_apellido",
                                        "cli_telefono_celular",
                                        "cli_telefono_particular",
                                        "cli_telefono_laboral",
                                        "cli_email",
                                        "cli_sexo",
                                        "cli_fecha_nacimiento",
                                        "cli_nacionalidad",
                                        "cli_estado_civil",
                                        "cli_tipo_documento",
                                        "cli_numero_documento",
                                        "cli_cuit_cuil",
                                        "cli_como_llego",
                                        "cli_imprime_carta"};

            int i = 0;
            foreach (string s in columnasGrilla)
            {
                PropertyInfo pi = typeof(tbcliente).GetProperty(s);
                displayNameHelper = new DisplayNameHelper();
                string columna = displayNameHelper.GetMetaDisplayName(pi);
                dgvClientes.Columns.Add(s, columna);
                i++;
            }

            //dgvClientes.Columns[0].Visible = false;
            dgvClientes.Columns[2].Visible = false;
            dgvClientes.Columns[3].Visible = false;
            dgvClientes.Columns[4].Visible = false;

            CargarDataGridViewLista();
        }

        private void CargarDataGridViewLista()
        {
            ClienteBusiness clienteBusiness = new ClienteBusiness();
            List<tbcliente> listaClientes = (List<tbcliente>)clienteBusiness.GetList();
            CargarDataGridView(listaClientes);

        }

        private void CargarDataGridView(List<tbcliente> listaClientes)
        {
            dgvClientes.Rows.Clear(); 
            int indice;
            foreach (var obj in listaClientes)
            {
                indice = dgvClientes.Rows.Add();
                dataGridViewRow = dgvClientes.Rows[indice];
                dataGridViewRow.Cells["cli_id"].Value = obj.cli_id;
                dataGridViewRow.Cells["cli_id_import"].Value = obj.cli_id_import;
                dataGridViewRow.Cells["cli_id_padre"].Value = obj.cli_id_padre;
                dataGridViewRow.Cells["tif_id"].Value = obj.tif_id;
                dataGridViewRow.Cells["cli_fecha"].Value = obj.cli_fecha.ToShortDateString();
                dataGridViewRow.Cells["ccl_descripcion"].Value = obj.tbcategoriacliente.ccl_descripcion;
				dataGridViewRow.Cells["cli_parentezco"].Value = obj.tbtipofamiliar.tif_descripcion;
                dataGridViewRow.Cells["cli_nombre"].Value = obj.cli_nombre;
                dataGridViewRow.Cells["cli_apellido"].Value = obj.cli_apellido;
                dataGridViewRow.Cells["cli_telefono_celular"].Value = obj.cli_telefono_celular;
                dataGridViewRow.Cells["cli_telefono_particular"].Value = obj.cli_telefono_particular;
                dataGridViewRow.Cells["cli_telefono_laboral"].Value = obj.cli_telefono_laboral;
                dataGridViewRow.Cells["cli_email"].Value = obj.cli_email;
                dataGridViewRow.Cells["cli_sexo"].Value = obj.cli_sexo;
                dataGridViewRow.Cells["cli_fecha_nacimiento"].Value = obj.cli_fecha_nacimiento.ToString("dd/MM/yyyy");
                dataGridViewRow.Cells["cli_nacionalidad"].Value = obj.cli_nacionalidad;
                dataGridViewRow.Cells["cli_estado_civil"].Value = obj.cli_estado_civil;
                dataGridViewRow.Cells["cli_tipo_documento"].Value = obj.cli_tipo_documento;
                dataGridViewRow.Cells["cli_numero_documento"].Value = obj.cli_numero_documento;
                dataGridViewRow.Cells["cli_cuit_cuil"].Value = obj.cli_cuit_cuil;
                dataGridViewRow.Cells["cli_como_llego"].Value = obj.cli_como_llego;
                dataGridViewRow.Cells["cli_imprime_carta"].Value = obj.cli_imprime_carta;

                if (obj.cli_imprime_carta == null || obj.cli_imprime_carta == false)
                    dataGridViewRow.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#f66b6b");

                lblClientesVisualizados.Text = listaClientes.Count.ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            formularioClienteABM = new frmClienteABM(this);
            AbrirFormulario(formularioClienteABM, "Alta de un Cliente");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.SelectedRows.Count != 0)
                {
                    if (MensajeEliminacionOK() == System.Windows.Forms.DialogResult.Yes)
                    {
                        dataGridViewRow = dgvClientes.SelectedRows[0];
                        int idClienteSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["cli_id"].Value);
                        ClienteBusiness clienteBusiness = new ClienteBusiness();
                        clienteBusiness.Delete(new tbcliente() { cli_id = idClienteSeleccionado });
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

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                tbcliente cliente = new tbcliente();
                cliente = ObtenerClienteSeleccionado();

                formularioClienteABM = new frmClienteABM(cliente, this);
                AbrirFormulario(formularioClienteABM, "Planilla de Cliente");
                
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al seleccionar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private tbcliente ObtenerClienteSeleccionado()
        {
            dataGridViewRow = dgvClientes.SelectedRows[0];
            int idClienteSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["cli_id"].Value);

            ClienteBusiness clienteBusiness = new ClienteBusiness();
            tbcliente cliente = (tbcliente)clienteBusiness.GetElement(
                new tbcliente() { cli_id = idClienteSeleccionado });
            return cliente;
        }

        #region Herramienta de Búsqueda

        private void btnBuscar_Click(object sender, EventArgs e)
        {
			Cursor.Current = Cursors.WaitCursor;
            try
            {
                List<string> listaExcluir = new List<string>() 
                { 
                    "cli_id_padre",
                    "tif_id"
                };

                BuscarEnDataGridView buscar = new BuscarEnDataGridView();

                ClienteBusiness clienteBusiness = new ClienteBusiness();
                List<tbcliente> listaFiltrada = (List<tbcliente>)clienteBusiness.GetList();
                listaFiltrada = buscar.FiltrarDataGrid(listaFiltrada, listaExcluir, txbBuscarPor.Text);
                CargarDataGridView(listaFiltrada);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al Buscar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
			Cursor.Current = Cursors.Default;
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
			Cursor.Current = Cursors.WaitCursor;
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
			finally
			{
				Cursor.Current = Cursors.Default;
			}
        }

		private void btnBuscarCumpleanieros_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				List<string> listaExcluir = new List<string>()
				{
					"cli_id_padre",
					"tif_id"
				};

				BuscarEnDataGridView buscar = new BuscarEnDataGridView();

				ClienteBusiness clienteBusiness = new ClienteBusiness();
                //filtro los que no tienen asignada correctamente la fecha de cumpleaños
                Func<tbcliente, bool> func = x => !DateTime.Equals(x.cli_fecha_nacimiento, new DateTime(1900, 01, 01));
				//invoco al metodo sobrecargado con la funcion definida
                List<tbcliente> listaFiltrada = 
                    (List<tbcliente>)clienteBusiness.GetListCumpleanieros(dtpCumpleaniosDesde.Value, dtpCumpleaniosHasta.Value, func);
				CargarDataGridView(listaFiltrada);
			}
			catch (Exception ex)
			{
				log.Error(ex.Message);
				if (ex.InnerException != null)
					log.Error(ex.InnerException.Message);
				MessageBox.Show("Error al Buscar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			Cursor.Current = Cursors.Default;
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

        private void btnExportarClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();  
            saveFileDialog1.Title = "Guardar planilla de excel";
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "xls";
            saveFileDialog1.Filter = "Excel (*.xlsx)|*.xlsx";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            string filepath;
            string sheetName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filepath = System.IO.Path.GetDirectoryName(saveFileDialog1.FileName);
                sheetName = saveFileDialog1.FileName;
                try
                {
                    List<string> listaExcluir = new List<string>()
                {
                    "cli_id_padre",
                    "tif_id"
                };

                    BuscarEnDataGridView buscar = new BuscarEnDataGridView();

                    ClienteBusiness clienteBusiness = new ClienteBusiness();
                    ExportarBusiness exportarBusiness = new ExportarBusiness();
                    List<tbcliente> listaFiltrada = (List<tbcliente>)clienteBusiness.GetList();
                    listaFiltrada = buscar.FiltrarDataGrid(listaFiltrada, listaExcluir, txbBuscarPor.Text);
                    CargarDataGridView(listaFiltrada);
                    string[] columnasGrilla = { "cli_id",
                                        "cli_id_import",
                                        "cli_fecha",
                                        "ccl_descripcion",
                                        "cli_parentezco",
                                        "cli_nombre",
                                        "cli_apellido",
                                        "cli_telefono_celular",
                                        "cli_telefono_particular",
                                        "cli_telefono_laboral",
                                        "cli_email",
                                        "cli_sexo",
                                        "cli_fecha_nacimiento",
                                        "cli_nacionalidad",
                                        "cli_estado_civil",
                                        "cli_tipo_documento",
                                        "cli_numero_documento",
                                        "cli_cuit_cuil",
                                        "cli_como_llego"};
                    List<string> columnas = new List<string>();
                    foreach (string s in columnasGrilla)
                    {
                        PropertyInfo pi = typeof(tbcliente).GetProperty(s);
                        displayNameHelper = new DisplayNameHelper();
                        columnas.Add(displayNameHelper.GetMetaDisplayName(pi));

                    }
                    exportarBusiness.CreateExcelFile(filepath, sheetName, listaFiltrada, columnas);
                   
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                    if (ex.InnerException != null)
                        log.Error(ex.InnerException.Message);
                    MessageBox.Show("Error al Buscar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            

            Cursor.Current = Cursors.Default;
        }
    }
}
