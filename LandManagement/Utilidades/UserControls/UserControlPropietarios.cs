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
using System.Reflection;
using log4net;

namespace LandManagement.Utilidades.UserControls
{
    public partial class UserControlPropietarios : UserControl
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
 
        public UserControlPropietarios()
        {
            InitializeComponent();
        }

        private void ucPropietarios_Load(object sender, EventArgs e)
        {
			cmbPropietario.AutoCompleteMode = AutoCompleteMode.Suggest;
			cmbPropietario.AutoCompleteSource = AutoCompleteSource.ListItems;

			this.CargarCombos();

            InicializarGrillaPropietarios();
        }

        private void btnAgregarPropietario_Click(object sender, EventArgs e)
        {
			try
			{
				if (cmbPropietario.SelectedItem != null)
				{
					AgregaPropietarioGrilla((tbcliente)cmbPropietario.SelectedItem);
					cmbPropietario.Items.Remove((tbcliente)cmbPropietario.SelectedItem);
				}
				else
				{
					MessageBox.Show("Seleccione un propietario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex.Message);
				if (ex.InnerException != null)
					log.Error(ex.InnerException.Message);
				MessageBox.Show("Error al agregar propietario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void btnRemovePropietario_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPropietarios.Rows.Count > 0)
                {
                    AgregoPropietarioGrillaACombo();
                    foreach (DataGridViewRow obj in dgvPropietarios.SelectedRows)
                        dgvPropietarios.Rows.RemoveAt(obj.Index);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error al eliminar propietario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregoPropietarioGrillaACombo()
        {
            List<tbcliente> listaTemporal = new List<tbcliente>();
            foreach (tbcliente obj in cmbPropietario.Items)
                listaTemporal.Add(obj);

            tbcliente cliente = ObtenerPropietarioSeleccionado();

            listaTemporal.Add(cliente);

            cmbPropietario.Items.Clear();
            cmbPropietario.Refresh();

            foreach (tbcliente cli in listaTemporal.OrderBy(x => x.cli_nombre))
                cmbPropietario.Items.Add(cli);
        }

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
            DisplayNameHelper displayNameHelper;
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

        private tbcliente ObtenerPropietarioSeleccionado()
        {
            ClienteBusiness clienteBusiness = new ClienteBusiness();
            DataGridViewRow dataGridViewRow = dgvPropietarios.SelectedRows[0];
            int idClienteSeleccionado = Convert.ToInt32(dataGridViewRow.Cells["cli_id"].Value);

            tbcliente cliente = (tbcliente)clienteBusiness.GetElement(
                new tbcliente() { cli_id = idClienteSeleccionado });

            return cliente;
        }

        #endregion

        private void CargarCombos()
        {
            this.SetearDisplayValue();
            this.CargarPropietario();
        }

        private void SetearDisplayValue()
        {
            cmbPropietario.ValueMember = "cli_id";
            cmbPropietario.DisplayMember = "cli_nombre_completo";
        }

		private void CargarPropietario()
		{
			ClienteBusiness clienteBusiness = new ClienteBusiness();
			List<tbcliente> listaClientes = (List<tbcliente>)clienteBusiness.GetList(true);

			cmbPropietario.DataSource = listaClientes;
			cmbPropietario.Invalidate();
			cmbPropietario.SelectedIndex = -1;
		}

		public List<tbcliente> ObtenerPropietarios()
        {
            List<tbcliente> listaClientes = null;
            List<int> idsClientes = null;
            ClienteBusiness clienteBusiness = null;

            if (dgvPropietarios.Rows.Count > 0)
            {
                listaClientes = new List<tbcliente>();
                idsClientes = new List<int>();
                clienteBusiness = new ClienteBusiness();

                foreach (DataGridViewRow row in dgvPropietarios.Rows)
                    idsClientes.Add((int)row.Cells["cli_id"].Value);

                Func<tbcliente, bool> whereClausule = x => idsClientes.Contains(x.cli_id);
                listaClientes = clienteBusiness.GetList(whereClausule) as List<tbcliente>;
            }

            return listaClientes;
        }

        #region Cargar grilla cuando se envia la operación como dato

        public void CargarGrillaPropietariosOperacion(int idOperacion)
        {
            var idsPropietarios = this.GetIdsPropietarios(idOperacion);

			Func<tbcliente, bool> func = x => idsPropietarios.Contains(x.cli_id);
			ClienteBusiness clienteBusiness = new ClienteBusiness();
			var lista = (List<tbcliente>)clienteBusiness.GetList(func);

			foreach (tbcliente obj in lista)
				AgregaPropietarioGrilla(obj);
        }

        private IEnumerable<int> GetIdsPropietarios(int idOperacion)
        {
            var idsPropietarios = GetClientesOperacion(idOperacion)
                .Where(x => x.stc_id == (int)TipoOperador.PROPIETARI).Select(x => x.cli_id);
            return idsPropietarios;
        }

        private IEnumerable<tbclienteoperacion> GetClientesOperacion(int idOperacion)
        {
            ClienteOperacionBusiness clienteOperacionBusiness = new ClienteOperacionBusiness();
            Func<tbclienteoperacion, bool> whereClausule = x => x.ope_id == idOperacion;

            var clientesOperacion = 
                clienteOperacionBusiness.GetList(whereClausule) as List<tbclienteoperacion>;

            return clientesOperacion;
        }
        
        #endregion

        public void SetearNombreGroupBox(string nombreGroupBox)
        {
            this.gbxPropietarios.Text = nombreGroupBox;
        }
    }
}
