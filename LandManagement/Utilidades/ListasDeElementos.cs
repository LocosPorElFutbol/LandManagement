using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandManagement.Utilidades
{
    public class ListasDeElementos
    {
        public List<ComboBoxItem> GetListaTipoDocumento()
        {
            List<ComboBoxItem> lista = new List<ComboBoxItem>(){
                new ComboBoxItem("DNI",1),
                new ComboBoxItem("CI",2),
                new ComboBoxItem("LC",3),
                new ComboBoxItem("LE",4),
            };

            return lista;
        }

        public List<ComboBoxItem> GetListaEstadoCivil()
        {
            List<ComboBoxItem> lista = new List<ComboBoxItem>(){
                new ComboBoxItem("Soltero",1),
                new ComboBoxItem("Casado",2),
                new ComboBoxItem("Concubino",3),
                new ComboBoxItem("Viudo",4),
            };

            return lista;
        }

        public List<ComboBoxItem> GetListaSexo()
        {
            List<ComboBoxItem> lista = new List<ComboBoxItem>(){
                new ComboBoxItem("Femenino",1),
                new ComboBoxItem("Masculino",2)
            };

            return lista;
        }

        public List<ComboBoxItem> GetListaPiso()
        {
            List<ComboBoxItem> lista = new List<ComboBoxItem>(){
                new ComboBoxItem("0",0),
                new ComboBoxItem("1",1),
                new ComboBoxItem("2",2),
                new ComboBoxItem("3",3),
                new ComboBoxItem("4",4),
                new ComboBoxItem("5",5),
                new ComboBoxItem("6",6),
                new ComboBoxItem("7",7),
                new ComboBoxItem("8",8),
                new ComboBoxItem("9",9),
                new ComboBoxItem("10",10),
                new ComboBoxItem("11",11),
                new ComboBoxItem("12",12),
                new ComboBoxItem("13",13),
                new ComboBoxItem("14",14),
                new ComboBoxItem("15",15),
                new ComboBoxItem("16",16),
                new ComboBoxItem("17",17),
                new ComboBoxItem("18",18),
                new ComboBoxItem("19",19),
                new ComboBoxItem("20",20)
            };

            return lista;
        }

        public List<ComboBoxItem> GetListaDepto()
        {
            List<ComboBoxItem> lista = new List<ComboBoxItem>(){
                new ComboBoxItem("",0),
                new ComboBoxItem("A",1),
                new ComboBoxItem("B",2),
                new ComboBoxItem("C",3),
                new ComboBoxItem("D",4),
                new ComboBoxItem("E",5),
                new ComboBoxItem("F",6),
                new ComboBoxItem("G",7),
                new ComboBoxItem("H",8),
                new ComboBoxItem("I",9),
                new ComboBoxItem("J",10),
                new ComboBoxItem("K",11),
                new ComboBoxItem("L",12),
                new ComboBoxItem("M",13),
                new ComboBoxItem("N",14),
                new ComboBoxItem("O",15),
                new ComboBoxItem("P",16),
                new ComboBoxItem("Q",17),
                new ComboBoxItem("R",18),
                new ComboBoxItem("S",19),
                new ComboBoxItem("T",19),
                new ComboBoxItem("U",19),
                new ComboBoxItem("V",19),
                new ComboBoxItem("W",19),
                new ComboBoxItem("X",19),
                new ComboBoxItem("Y",19),
                new ComboBoxItem("Z",20)
            };

            return lista;
        }
    }
}
