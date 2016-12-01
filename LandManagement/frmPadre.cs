using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using LandManagement.Business;
using LandManagement.Entities;
using System.Configuration;

namespace LandManagement
{
    public partial class frmPadre : Form
    {
        MenuStrip menuStrip;
        ToolStripMenuItem toolStripMenuItem;
        private MenuBusiness menuBusiness;
        private List<tbmenu> listaMenu;
    
        public frmPadre()
        {
            InitializeComponent();
        }

        public frmPadre(List<tbmenu> listaMenuDelUsuario)
        {
            InitializeComponent();
            this.listaMenu = listaMenuDelUsuario;
        }

        private void frmPadre_Load(object sender, EventArgs e)
        {
            this.Text = "Land Management v" + ConfigurationManager.AppSettings["version"].ToString();
            this.Icon = (Icon)Recursos.ResourceImages.ResourceManager.GetObject("LogoLandManagement");

            //Controla entorno de prueba
            string connectionString = ConfigurationManager.ConnectionStrings["landmanagementbdEntities"].ToString();
            if (connectionString.Contains("test"))
                lblEntornoDeTest.Visible = true;

            this.WindowState = FormWindowState.Maximized;
            menuStrip = new MenuStrip();
            this.Controls.Add(menuStrip);
            this.IsMdiContainer = true;

            //Carga todos los menus directamente desde la tabla menu
            //se tiene que modificar para que el menu se cargue desde el usuario
            //menuBusiness = new MenuBusiness();
            //var coleccion = (List<tbmenu>)menuBusiness.GetList();

            //Se carga el menu del usuario logueado
            var coleccion = this.listaMenu;

            foreach (var obj in coleccion)
            {
                if (obj.men_id_padre == null)
                {
                    toolStripMenuItem = new ToolStripMenuItem(obj.men_nombre);
                    if (TieneHijos(obj))
                        CargarHijos(toolStripMenuItem, obj);

                    //((ToolStripDropDownMenu)menuItem.DropDown).ShowImageMargin = false;
                    //Oculto el margen de los iconos en el menu
                    ((ToolStripDropDownMenu)toolStripMenuItem.DropDown).ShowImageMargin = false;
                    ((ToolStripDropDownMenu)toolStripMenuItem.DropDown).ShowCheckMargin = false;

                    menuStrip.Items.Add(toolStripMenuItem);
                }
            }

            this.MainMenuStrip = menuStrip;
        }

        public bool TieneHijos(tbmenu objeto)
        {
            bool salida = false;

            if (objeto.tbmenu1 != null && objeto.tbmenu1.Count > 0)
                salida = true;

            return salida;
        }

        public void CargarHijos(ToolStripMenuItem menuPadre, tbmenu padre)
        {
            foreach (var obj in padre.tbmenu1)
            {
                ToolStripMenuItem toolStripMenuItemHijo = new ToolStripMenuItem(obj.men_nombre);
                if (TieneHijos(obj))
                    CargarHijos(toolStripMenuItemHijo, obj);
                else
                    toolStripMenuItemHijo =
                        new ToolStripMenuItem(obj.men_nombre, null, new EventHandler(ChildClick));

                menuPadre.DropDownItems.Add(toolStripMenuItemHijo);
            }
        }

        public void SubMenu(ToolStripMenuItem pToolStripMenuItem, int pSubMenu)
        {
            menuBusiness = new MenuBusiness();
            var lista = ((List<tbmenu>)menuBusiness.GetList()).Where(x => x.men_id == pSubMenu);

            foreach (var obj in lista)
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem(obj.men_nombre_formulario, null, new EventHandler(ChildClick));
                pToolStripMenuItem.DropDownItems.Add(tsmi);
            }
        }

        private void ChildClick(object sender, EventArgs e)
        {
            menuBusiness = new MenuBusiness();
            var sbm = ((List<tbmenu>)menuBusiness.GetList()).Where(x => x.men_nombre == sender.ToString()).FirstOrDefault();
            string frmCode = ((tbmenu)sbm).men_nombre_formulario;
            string frmNombre = ((tbmenu)sbm).men_nombre;

            Assembly frmAssembly = Assembly.LoadFile(Application.ExecutablePath);

            foreach (Type type in frmAssembly.GetTypes())
            {
                if (type.BaseType == typeof(Form))
                {
                    if (type.Name == frmCode)
                    {
                        Form formShow;
                        if (Application.OpenForms.Cast<Form>().Any(form => form.Name == frmCode))
                        {
                            Form f = Application.OpenForms[frmCode];
                            f.WindowState = FormWindowState.Normal;
                            f.Activate();
                            //f.Show();
                        }
                        else
                        {
                            formShow = (Form)frmAssembly.CreateInstance(type.ToString());
                            formShow.ShowIcon = true;
                            formShow.Text = frmNombre;

                            formShow.Icon = (Icon)Recursos.ResourceImages.ResourceManager.GetObject("Tool");

                            formShow.MdiParent = this;
                            formShow.WindowState = FormWindowState.Maximized;
                            formShow.Show();

                            //Se utiliza para que no genere conflicto la carga del icono tool
                            ActivateMdiChild(null);
                            ActivateMdiChild(formShow);
                        }

                    }

                }
            }

        }

    }
}
