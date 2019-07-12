using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using mshtml;
using LandManagement.Business;
using LandManagement.Entities;
using LandManagement.Utilidades;
using log4net;

namespace LandManagement
{
    public partial class frmEmail : Form
    {
        public static readonly ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IHTMLDocument2 doc;
        private int port;
        private string RutImagen;
        MailMessage _Correo = new MailMessage();
        ValidarControles validarControles;
        private ErrorProvider errorProvider1 = new ErrorProvider();

        public frmEmail()
        {
            InitializeComponent();
        }

        private void frmMail_Load(object sender, EventArgs e)
        {
            pnlControles.AutoScroll = true;
            cmbCategorias.Sorted = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            hleCuerpo.DocumentText = "<html><body></body></html>";
            doc = hleCuerpo.Document.DomDocument as IHTMLDocument2;
            doc.designMode = "On";
            //port = 25;
            port = 587;

			if (string.IsNullOrEmpty(VariablesDeSesion.UsuarioLogueado.usu_email) ||
               string.IsNullOrEmpty(VariablesDeSesion.UsuarioLogueado.usu_email_password))
            {
                MessageBox.Show("Para utilizar la herramienta envio de e-mail, deberá configurar su cuenta personal en el sistema. \n Diríjase a, Sistema -> Configurar cuenta e-mail.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tstControlesFuente.Enabled = false;
                pnlControles.Enabled = false;
            }

            CargarComboCategorias();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateChildren())
                {
                    string SAVECONTENTS = hleCuerpo.DocumentText;
                    SAVECONTENTS = SAVECONTENTS.Replace("<BODY>", "<BODY> <div style=" + '"' + "background-image: url(cid:companylogo);" + '"' + ">");
                    SAVECONTENTS = SAVECONTENTS.Replace("</BODY>", "</div></BODY>");

                    //direccion e-mail origen
                    _Correo.From = new MailAddress(VariablesDeSesion.UsuarioLogueado.usu_email);

                    CargarEmailsDestinatarios();
                    
                    _Correo.Subject = txtasunto.Text;
                    _Correo.Body = SAVECONTENTS;
                    _Correo.IsBodyHtml = true;
                    _Correo.Priority = MailPriority.Normal;
                    var htmlView = AlternateView.CreateAlternateViewFromString(_Correo.Body, null, "text/html");

                    if (!string.IsNullOrEmpty(RutImagen))//Valida que exista la direccion de la imagen
                    {
                        LinkedResource logo = new LinkedResource(RutImagen);
                        logo.ContentId = "companylogo";
                        htmlView.LinkedResources.Add(logo);
                    }
                    _Correo.AlternateViews.Add(htmlView);
                    _Correo.IsBodyHtml = true;
                    
                    SmtpClient smtp = new SmtpClient();

					smtp.UseDefaultCredentials = false;
                    //Cargo credenciales de e-mail origen
                    smtp.Credentials = new NetworkCredential(VariablesDeSesion.UsuarioLogueado.usu_email,
                        VariablesDeSesion.UsuarioLogueado.usu_email_password);
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = port;
                    smtp.EnableSsl = true;
					smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        smtp.Send(_Correo);
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Correo Enviado");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex.Message);
                        if (ex.InnerException != null)
                            log.Error(ex.InnerException.Message);
                        MessageBox.Show("No se pudo enviar el correo. \n Ayuda: Corrobore la configuración correcta e-mail/password. \n Recuerde habilitar el envio de mail desde su cuenta de gmail https://myaccount.google.com/", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error en el armado del mail.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarEmailsDestinatarios()
        {
            try
            {
                //Carga de emails destino
                foreach (var email in obtenerListaDeEmails())
                    _Correo.To.Add(email);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                if (ex.InnerException != null)
                    log.Error(ex.InnerException.Message);
                MessageBox.Show("Error en dirección de e-mail/s de destinatario/s. \n por favor, controle almacenamiento de direcciones de email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdjuntar_Click(object sender, EventArgs e)
        {
            CargarArchivos();
        }

        private void btncacelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Panel de controles Envio de E-mails (Toolstrip)
        private void BoldtoolStrip_Click(object sender, EventArgs e)
        {
            hleCuerpo.Document.ExecCommand("Bold", false, null);
        }

        private void UnderlinetoolStrip_Click(object sender, EventArgs e)
        {
            hleCuerpo.Document.ExecCommand("Underline", false, null);
        }

        private void ItalictoolStrip_Click(object sender, EventArgs e)
        {
            hleCuerpo.Document.ExecCommand("Italic", false, null);
        }

        private void ColortoolStrip_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() != DialogResult.Cancel)
            {
                doc.execCommand("ForeColor", false, ColorTranslator.ToHtml(colorDialog.Color).ToString());
            }
        }

        private void JustifyFulltoolStrip_Click(object sender, EventArgs e)
        {
            hleCuerpo.Document.ExecCommand("JustifyFull", false, null);
        }

        private void JustifyCentertoolStrip_Click(object sender, EventArgs e)
        {
            hleCuerpo.Document.ExecCommand("JustifyCenter", false, null);
        }

        private void JustifyLtoolStrip_Click(object sender, EventArgs e)
        {
            hleCuerpo.Document.ExecCommand("JustifyLeft", false, null);
        }

        private void JustifyRtoolStrip_Click(object sender, EventArgs e)
        {
            hleCuerpo.Document.ExecCommand("JustifyRight", false, null);
        }

        private void VinDtoolStrip_Click(object sender, EventArgs e)
        {
            hleCuerpo.Document.ExecCommand("InsertUnorderedList", false, null);
        }

        private void VinNtoolStrip_Click(object sender, EventArgs e)
        {
            hleCuerpo.Document.ExecCommand("InsertOrderedList", false, null);
        }

        private void IMGtoolStrip_Click(object sender, EventArgs e)
        {
            OpenFileDialog _file = new OpenFileDialog();
            _file.Title = "Seleccione una imagen";
            _file.InitialDirectory = @"c:\";
            _file.Filter = "All Files(*.*)|*.*";
            _file.FilterIndex = 1;
            _file.RestoreDirectory = true;
            _file.ShowDialog();
            if (string.IsNullOrEmpty(_file.FileName)) //Valida que exista una direccion de mail
            {
                MessageBox.Show("No selecciono ningun archivo.");
                return;
            }
            RutImagen = _file.FileName;
        }
        private void arialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hleCuerpo.Document.ExecCommand("FontName", false, "Arial");
        }

        private void verdanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hleCuerpo.Document.ExecCommand("FontName", false, "Verdana");
        }

        private void currierNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hleCuerpo.Document.ExecCommand("FontName", false, "Currier New");
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            hleCuerpo.Document.ExecCommand("FontSize", false, 1);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            hleCuerpo.Document.ExecCommand("FontSize", false, 2);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            hleCuerpo.Document.ExecCommand("FontSize", false, 3);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            hleCuerpo.Document.ExecCommand("FontSize", false, 4);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            hleCuerpo.Document.ExecCommand("FontSize", false, 5);
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Categorias de cliente
        public void SetearDisplayValue()
        {
            cmbCategorias.ValueMember = "cat_id";
            cmbCategorias.DisplayMember = "cat_descripcion";

            lbxPara.ValueMember = "cat_id";
            lbxPara.DisplayMember = "cat_descripcion";
        }

        public void CargarComboCategorias()
        {
            this.SetearDisplayValue();
            CategoriaBusiness categoriaBusiness = new CategoriaBusiness();
            List<tbcategoria> listaCategorias = (List<tbcategoria>)categoriaBusiness.GetListaCategorias();

            foreach (tbcategoria cat in listaCategorias)
                cmbCategorias.Items.Add(cat);
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            tbcategoria categoria = (tbcategoria)cmbCategorias.SelectedItem;

            if (categoria != null)
            {
                lbxPara.Items.Add(categoria);
                cmbCategorias.Items.Remove(categoria);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            tbcategoria categoria = (tbcategoria)lbxPara.SelectedItem;
            if (categoria != null)
            {
                lbxPara.Items.Remove(lbxPara.SelectedItem);
                cmbCategorias.Items.Add(categoria);
            }
        }

        private List<int> getListIdsCategoriasSelecionadas()
        {
            List<int> listaCategorias = new List<int>();
            foreach (tbcategoria cat in lbxPara.Items)
                listaCategorias.Add(cat.cat_id);

            return listaCategorias;        
        }

        private List<string> obtenerListaDeEmails()
        {
            ClienteBusiness clienteBusiness = new ClienteBusiness();
            List<string> listaEmails = new List<string>();

            List<tbcliente> clientes =
                (List<tbcliente>)clienteBusiness.GetClientesByIdCategoria(
                    getListIdsCategoriasSelecionadas());

            foreach (var obj in clientes)
                if (!string.IsNullOrEmpty(obj.cli_email))
                    listaEmails.Add(obj.cli_email);

            return listaEmails;
        }
        #endregion

        private void CargarArchivos()
        {
            OpenFileDialog _file = new OpenFileDialog();
            _file.Title = "Seleccione un archivo";
            _file.InitialDirectory = @"c:\";
            _file.Filter = "All Files(*.*)|*.*";
            _file.FilterIndex = 1;

            _file.RestoreDirectory = true;
            _file.ShowDialog();
            if (string.IsNullOrEmpty(_file.FileName)) //Valida que exista una direccion de mail
            {
                MessageBox.Show("No selecciono ningun archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Correo.Attachments.Add(new System.Net.Mail.Attachment(_file.FileName));
            adjlabel.Text = adjlabel.Text + _file.SafeFileName.ToString() + System.Environment.NewLine;
        }

        private void ValidatingControl(object sender, CancelEventArgs e)
        {
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            validarControles = new ValidarControles();
            Control control = validarControles.ObtenerControl(sender);
            string error = validarControles.ValidarControl(sender);

            if (!string.IsNullOrEmpty(error))
            {
                errorProvider1.SetError(control, error);

                //Me valida hasta ingresar el valor correcto
                e.Cancel = true;
                return;
            }

            errorProvider1.SetError(control, error);
        }

    }
}
