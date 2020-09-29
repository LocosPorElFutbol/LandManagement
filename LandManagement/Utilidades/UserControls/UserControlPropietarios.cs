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
		BindingSource _bindingSource = new BindingSource();
		BindingList<tbcliente> _bindingList = null;

		Timer _timer = new Timer();

		public UserControlPropietarios()
        {
            InitializeComponent();
			InicializarGrillaPropietarios();

			cmbPropietario.AutoCompleteSource = AutoCompleteSource.ListItems;

			this.CargarCombos();
		}

		public UserControlPropietarios(tboperaciones operacion)
		{
			InitializeComponent();
			InicializarGrillaPropietarios();
			CargarGrillaPropietariosOperacion(operacion.ope_id);
		}

		private void ucPropietarios_Load(object sender, EventArgs e)
        {
			_timer.Interval = 1500;
			_timer.Tick += _timer_Tick;
		}

		private void btnAgregarPropietario_Click(object sender, EventArgs e)
        {
			try
			{
				Cursor = Cursors.WaitCursor;

				if (cmbPropietario.SelectedItem != null)
				{
					tbcliente propietario = (tbcliente)cmbPropietario.SelectedItem;

					if (!ExistePropietarioEnDGV(propietario))
					{
						AgregaPropietarioGrilla(propietario);

						_bindingList.Remove(propietario);
						_bindingList.ResetBindings();
					}
					else
					{
						MessageBox.Show("El cliente ya existe en la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				else
				{
					MessageBox.Show("Seleccione un propietario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				Cursor = Cursors.Default;
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
				Cursor = Cursors.WaitCursor;

				if (dgvPropietarios.Rows.Count > 0)
				{
					AgregoPropietarioGrillaACombo();
					foreach (DataGridViewRow obj in dgvPropietarios.SelectedRows)
						dgvPropietarios.Rows.RemoveAt(obj.Index);
				}

				Cursor = Cursors.Default;
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
            tbcliente propietario = ObtenerPropietarioSeleccionado();

			var item = _bindingList.ToList().Find(x => x.cli_id == propietario.cli_id);

			if (item == null)
			{
				_bindingList.Add(propietario);
				_bindingList.ResetBindings();
			}
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

		public bool ExistePropietarioEnDGV(tbcliente cliente)
		{
			foreach(DataGridViewRow row in dgvPropietarios.Rows)
			{
				if (cliente.cli_id == (int)row.Cells["cli_id"].Value)
					return true;
			}
			return false;
		}

        #endregion

        private void CargarCombos()
        {
            this.SetearDisplayValue();
            //this.CargarPropietario();
        }

        private void SetearDisplayValue()
        {
            cmbPropietario.ValueMember = "cli_id";
            cmbPropietario.DisplayMember = "cli_nombre_completo";
        }

		[Obsolete("Se va a eliminar mejora propiedad alquilada")]
		private void CargarPropietario()
		{
			ClienteBusiness clienteBusiness = new ClienteBusiness();
			List<tbcliente> listaClientes = (List<tbcliente>)clienteBusiness.GetList(true);
			_bindingList = new BindingList<tbcliente>(listaClientes);

			_bindingSource.DataSource = _bindingList;

			cmbPropietario.DataSource = _bindingSource;
			cmbPropietario.Invalidate();
			cmbPropietario.SelectedIndex = -1;
		}

		/// <summary>
		/// Este metodo se debe llamar únicamente cuando se instancia el formulario, ya que obtiene la lista
		/// de clientes a partir del binding list, y si este se modifico por algun motivo, no se retornaran todos
		/// los registros.
		/// </summary>
		/// <returns>Lista de clientes bindeada con el combo propietarios.</returns>
		[Obsolete("Se va a eliminar mejora propiedad alquilada")]
		public List<tbcliente> GetListPropietario()
		{
			return _bindingList.ToList();
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


		#region Update Dropdown Items
		private void cmbPropietario_KeyUp(object sender, KeyEventArgs e)
		{
			RestartTimer();
		}

		private void RestartTimer()
		{
			_timer.Stop();
			_timer.Start();
		}

		private void _timer_Tick(object sender, EventArgs e)
		{
			_timer.Stop();
			UpdateData();
		}

		private void UpdateData()
		{
			Cursor.Current = Cursors.WaitCursor;

			if (cmbPropietario.Text.Length > 1)
			{
				var searchData = this.GetPropietarioFilterList(cmbPropietario.Text);
				HandleTextChanged(searchData);
			}

			Cursor.Current = Cursors.Default;
		}

		private BindingSource GetPropietarioFilterList(string nombreApellido)
		{
			Func<tbcliente, bool> func =
				x => x.cli_nombre.Contains(nombreApellido) || x.cli_apellido.Contains(nombreApellido)
					|| x.cli_nombre.Contains(nombreApellido.ToUpper())
						|| x.cli_apellido.Contains(nombreApellido.ToUpper());

			ClienteBusiness clienteBusiness = new ClienteBusiness();
			List<tbcliente> listaClientes = (List<tbcliente>)clienteBusiness.GetList(func);

			_bindingList = new BindingList<tbcliente>(listaClientes.OrderBy(x => x.cli_nombre_completo).ToList());

			BindingSource bindingSource = new BindingSource();
			bindingSource.DataSource = _bindingList;

			return bindingSource;
		}

		private void HandleTextChanged(BindingSource bindingSource)
		{
			cmbPropietario.DataSource = bindingSource.DataSource;
			cmbPropietario.Update();
			cmbPropietario.DroppedDown = true;
		}
		#endregion
	}
}
