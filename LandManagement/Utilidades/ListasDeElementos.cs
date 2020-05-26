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
                new ComboBoxItem("Divorciado",5),
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
                new ComboBoxItem("PB",0),
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
                new ComboBoxItem("-",0),
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
                new ComboBoxItem("20",20),
                new ComboBoxItem("21",21),
                new ComboBoxItem("22",22),
                new ComboBoxItem("23",23),
                new ComboBoxItem("24",24),
                new ComboBoxItem("25",25),
                new ComboBoxItem("26",26),
                new ComboBoxItem("A",27),
                new ComboBoxItem("B",28),
                new ComboBoxItem("C",29),
                new ComboBoxItem("D",30),
                new ComboBoxItem("E",31),
                new ComboBoxItem("F",32),
                new ComboBoxItem("G",33),
                new ComboBoxItem("H",34),
                new ComboBoxItem("I",35),
                new ComboBoxItem("J",36),
                new ComboBoxItem("K",37),
                new ComboBoxItem("L",38),
                new ComboBoxItem("M",39),
                new ComboBoxItem("N",40),
                new ComboBoxItem("O",41),
                new ComboBoxItem("P",42),
                new ComboBoxItem("Q",43),
                new ComboBoxItem("R",44),
                new ComboBoxItem("S",45),
                new ComboBoxItem("T",46),
                new ComboBoxItem("U",47),
                new ComboBoxItem("V",48),
                new ComboBoxItem("W",49),
                new ComboBoxItem("X",50),
                new ComboBoxItem("Y",51),
                new ComboBoxItem("Z",52)
            };

            return lista;
        }

        public List<ComboBoxItem> GetListaTitulo()
        {
            List<ComboBoxItem> lista = new List<ComboBoxItem>(){
                new ComboBoxItem("Sr.",0),
                new ComboBoxItem("Sra.",1),
                new ComboBoxItem("Srta.",1)
               };

            return lista;
        }
    }
}
