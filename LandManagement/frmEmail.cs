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
        private ClienteBusiness clienteBusiness;
        private IHTMLDocument2 doc;
        private int port;
        private string RutImagen;
        private string MailFrom;
        private string MailFromPass;
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
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            hleCuerpo.DocumentText = "<html><body></body></html>";
            doc = hleCuerpo.Document.DomDocument as IHTMLDocument2;
            doc.designMode = "On";

            //
            txtclientes.AutoCompleteCustomSource = LoadAutoComplete();
            txtclientes.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtclientes.AutoCompleteSource = AutoCompleteSource.CustomSource;
            // variables

            if (string.IsNullOrEmpty(VariablesDeSesion.UsuarioLogueado.usu_email) &&
               string.IsNullOrEmpty(VariablesDeSesion.UsuarioLogueado.usu_email_password))
            {
                MessageBox.Show("Para utilizar la herramienta envio de e-mail, deberá configurar su cuenta personal en el sistema. \n Diríjase a, Sistema -> Configurar cuenta e-mail.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tstControlesFuente.Enabled = false;
                pnlControles.Enabled = false;
            }
            //else 
            //{
            //    MailFrom = VariablesDeSesion.UsuarioLogueado.usu_email;
            //    MailFromPass = VariablesDeSesion.UsuarioLogueado.usu_email_password;
            //}

            //if (VariablesDeSesion.UsuarioLogueado.usu_email != null)
            //{
            //    if (IsValidEmail(VariablesDeSesion.UsuarioLogueado.usu_email) != false)
            //    MailFrom = VariablesDeSesion.UsuarioLogueado.usu_email;
            //    else
            //    {
            //        MessageBox.Show("Para utilizar la herramienta envio de e-mail, deberá configurar su cuenta personal en el sistema. \n Dirijase a Sistema -> Configurar cuenta e-mail.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        tstControlesFuente.Enabled = false;
            //        pnlControles.Enabled = false;
            //    }
            //}

            //if (VariablesDeSesion.UsuarioLogueado.usu_email_password != null)
            //    MailFromPass = VariablesDeSesion.UsuarioLogueado.usu_email_password;
            //else
            //{
            //    MessageBox.Show("Debe ingresar una contraseña");
            //}

            port = 25;
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
                    //_Correo.From = new MailAddress(MailFrom);
                    _Correo.From = new MailAddress(VariablesDeSesion.UsuarioLogueado.usu_email);
                   
                    string[] toEmails = txtmailto.Text.ToString().Split(';'); //envia a varias direcciones
                    foreach (string toEmail in toEmails)
                        _Correo.To.Add(toEmail);
                    
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
                    //smtp.Credentials = new NetworkCredential(MailFrom, MailFromPass);
                    smtp.Credentials = new NetworkCredential(VariablesDeSesion.UsuarioLogueado.usu_email,
                        VariablesDeSesion.UsuarioLogueado.usu_email_password);
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = port;
                    smtp.EnableSsl = true;

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
                        MessageBox.Show("No se pudo enviar el correo. \n Ayuda: Corrobore la configuración correcta e-mail/password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnAdjuntar_Click(object sender, EventArgs e)
        {
            CargarArchivos();
        }

        private void btncacelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        #region Agregar Mail del Cliente al listado (from)
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string mailcliente;
            mailcliente = txtclientes.Text;
            if (!string.IsNullOrEmpty(txtclientes.Text))
            {
                if (string.IsNullOrEmpty(txtmailto.Text))
                    txtmailto.Text = txtmailto.Text + '"' + mailcliente.Replace("<", '"' + " <");
                else
                    txtmailto.Text = txtmailto.Text + ";" + '"' + mailcliente.Replace("<", '"' + " <");
                txtclientes.Clear();
            }
            else MessageBox.Show("Debe seleccionar algun cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

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

        public AutoCompleteStringCollection LoadAutoComplete()
        {
            clienteBusiness = new ClienteBusiness();
            List<tbcliente> listaclientes = (List<tbcliente>)clienteBusiness.GetList();
            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();
            foreach (var obj in listaclientes)
            {
                if (IsValidEmail(obj.cli_email) != false)
                    stringCol.Add(obj.cli_apellido + " " + obj.cli_nombre + " <" + obj.cli_email + ">");
            }
            return stringCol;
        }
    }
}
