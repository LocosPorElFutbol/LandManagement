using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LandManagement.Utilidades
{
    public class BuscarEnDataGridView
    {

        private bool? valorCellBool = null;
        private int? valorCellInt = null;
        private string valorCellString = string.Empty;

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

    }
}
