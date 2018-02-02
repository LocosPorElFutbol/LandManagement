using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace LandManagement.Utilidades
{
    public class BuscarEnDataGridView
    {
        private bool? valorCellBool = null;
        private int? valorCellInt = null;
        private string valorCellString = string.Empty;

        /// <summary>
        /// Filtra el DataGridView que se recibe por parametro, matcheando el valor de búsqueda en todas
        /// las filas y columnas.
        /// </summary>
        /// <param name="_dgv">DataGridView a filtrar</param>
        /// <param name="_valorBusqueda">string que contiene en valor a buscar en la grilla</param>
        /// <returns>Datagridview filtrado</returns>
        public DataGridView FiltrarDataGridView(
            DataGridView _dgv, 
            string _valorBusqueda,
            DateTime _fechaDesde,
            DateTime _fechaHasta)
        {
            return this.FiltrarDataGridView(_dgv, new List<string>(), _valorBusqueda, _fechaDesde, _fechaHasta);
        }

        /// <summary>
        /// Filtra el DataGridView enviado por parametro, se realiza la búsqueda en todas las columnas, 
        /// omitiendo las que se encuentran dentro de la lista _omitirColumnas.
        /// </summary>
        /// <param name="_dgv">DataGridView a filtrar</param>
        /// <param name="_omitirColumnas">Lista de strings que contiene las columnas a omitir en la búsqueda</param>
        /// <param name="_valorBusqueda">string que se va a buscar en las celdas.</param>
        /// <returns>DataGridView filtrado</returns>
        public DataGridView FiltrarDataGridView(
            DataGridView _dgv, 
            List<string> _omitirColumnas, 
            string _valorBusqueda,
            DateTime _fechaDesde,
            DateTime _fechaHasta)
        {
            //List<DataGridViewRow> listaRows = this.AplicarFiltroDataGridView(_dgv, _omitirColumnas, _valorBusqueda);
            List<DataGridViewRow> listaRows = 
                this.AplicarFiltroDataGridView(_dgv, _omitirColumnas, _valorBusqueda, _fechaDesde, _fechaHasta);
            this.CargarDataGridView(_dgv, listaRows);
            return _dgv;
        }

        /// <summary>
        /// Carga al DataGridView los DataGridViewRow obtenidos de la busqueda
        /// </summary>
        /// <param name="_dgv">DataGridView a filtrar</param>
        /// <param name="_listaDataGridViewRow">Lista de nuevos DataGridViewRow que matchearon con la búsqueda</param>
        /// <returns>DataGridView con los DataGridViewRows matcheados con la búsqueda</returns>
        private DataGridView CargarDataGridView(DataGridView _dgv, List<DataGridViewRow> _listaDataGridViewRow)
        {
            _dgv.Rows.Clear();
            foreach (var row in _listaDataGridViewRow)
                _dgv.Rows.Add(row);

            return _dgv;
        }

        /// <summary>
        /// Aplica filtro de búsqueda al DataGridView, recorre rows y compara los datos enviados por parametros, 
        /// las filas que matchean con el valor de busqueda, se envian en una lista de DataGridViewRow.
        /// </summary>
        /// <param name="_dgv">DataGridView con datos a filtrar</param>
        /// <param name="omitirColumnas">Lista de strings que contiene las columnas a omitir en el filrado</param>
        /// <param name="valorBusqueda">Valor a buscar en las celdas</param>
        /// <returns>Retorna List<DataGridViewRow> con las filas que contienen el matcheo con el valor de búsqueda</returns>
        private List<DataGridViewRow> AplicarFiltroDataGridView(DataGridView _dgv, 
            List<string> omitirColumnas, 
            string valorBusqueda,
            DateTime fechaDesde,
            DateTime fechaHasta)
        {
            List<string> columnas = this.ObtenerColumnasGrilla(_dgv);
            List<DataGridViewRow> listaRows = new List<DataGridViewRow>();
            
            foreach (DataGridViewRow row in _dgv.Rows)
            {
                bool esta = false;
                DateTime fechaBusqueda = (DateTime)row.Cells["ope_fecha"].Value;

                foreach (string name in columnas)
                {
                    if (!omitirColumnas.Contains(name))
                    {
                        Type tipo = row.Cells[name].Value.GetType();
                        object resultado = row.Cells[name].Value;
                        object resultadoCasteado = Convert.ChangeType(resultado, tipo);
                        
                        if (resultadoCasteado.ToString().ToUpper().Contains(valorBusqueda.ToUpper()))
                        {
                            if (fechaBusqueda.Date >= fechaDesde.Date && fechaBusqueda.Date <= fechaHasta.Date)
                            {
                                esta = true;
                                break;
                            }

                        }

                        string asd = row.Cells[name].Value.ToString();
                    }
                }
                if (esta)
                    listaRows.Add(row);
            }

            return listaRows;
        }

        [Obsolete("Este metodo quedará OBSOLETO, utilizar FiltrarDataGridView(...)")]
        public List<T> FiltrarDataGrid<T>(List<T> listaObjetos, List<string> excludeListColumn,
            string valorBusqueda)
        {
            bool cellContieneValor = false;
            List<T> listaAuxiliar = new List<T>();

            foreach (T obj in listaObjetos)
                listaAuxiliar.Add(obj);

            foreach (T obj in listaObjetos)
            {
                cellContieneValor = false;
                PropertyInfo[] propertiesInfo = obj.GetType().GetProperties();

                foreach (PropertyInfo pi in propertiesInfo)
                {
                    object valor = pi.GetValue(obj, null);
                    string nombreColumna = pi.Name;

                    if (!excludeListColumn.Contains(nombreColumna))
                    {
                        if (valor != null)
                        {
                            int resultadoInt;
                            bool resultadoBool;

                            if (int.TryParse(valor.ToString(), out resultadoInt))
                            {
                                this.valorCellInt = resultadoInt;
                            }
                            else if (bool.TryParse(valor.ToString(), out resultadoBool))
                            {
                                this.valorCellBool = resultadoBool;
                            }
                            else
                            {
                                this.valorCellString = valor.ToString();
                            }

                            if (valorCellBool != null && valorCellInt == null && string.IsNullOrEmpty(valorCellString))
                            {
                                if (valorCellBool.ToString() == valorBusqueda)
                                {
                                    cellContieneValor = true;
                                    break;
                                }
                            }

                            if (valorCellBool == null && valorCellInt != null && string.IsNullOrEmpty(valorCellString))
                            {
                                if (valorCellInt.ToString() == valorBusqueda)
                                {
                                    cellContieneValor = true;
                                    break;
                                }
                            }

                            if (valorCellBool == null && valorCellInt == null)
                            {
                                if (valorCellString.ToUpper().Contains(valorBusqueda.ToUpper()))
                                {
                                    cellContieneValor = true;
                                    break;
                                }
                            }

                            LimpiarVariables();
                        }
                    }
                }
                if (!cellContieneValor)
                    listaAuxiliar.Remove(obj);
            }

            return listaAuxiliar;
        }

        private void LimpiarVariables()
        {
            this.valorCellBool = null;
            this.valorCellInt = null;
            this.valorCellString = string.Empty;
        }

        /// <summary>
        /// Obtiene el nombre de las columnas de un DataGridView.
        /// </summary>
        /// <param name="_dgv">DataGirdView que contiene el nombre de las columnas</param>
        /// <returns>Lista de strings con el nombre de las columnas del DataGridView que se envia por parametro</returns>
        private List<string> ObtenerColumnasGrilla(DataGridView _dgv)
        {
            List<string> listaColumnas = new List<string>();
            foreach (DataGridViewColumn col in _dgv.Columns)
                listaColumnas.Add(col.Name);

            return listaColumnas;
        }
    }
}
