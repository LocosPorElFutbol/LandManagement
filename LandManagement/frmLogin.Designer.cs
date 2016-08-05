namespace LandManagement
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbUsuario = new System.Windows.Forms.TextBox();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.pbxLogoCliente = new System.Windows.Forms.PictureBox();
            this.pnlControles = new System.Windows.Forms.Panel();
            this.cbxRecordar = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogoCliente)).BeginInit();
            this.pnlControles.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // txbUsuario
            // 
            this.txbUsuario.Location = new System.Drawing.Point(72, 3);
            this.txbUsuario.Name = "txbUsuario";
            this.txbUsuario.Size = new System.Drawing.Size(143, 20);
            this.txbUsuario.TabIndex = 2;
            // 
            // txbPassword
            // 
            this.txbPassword.Location = new System.Drawing.Point(72, 29);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '•';
            this.txbPassword.Size = new System.Drawing.Size(143, 20);
            this.txbPassword.TabIndex = 3;
            this.txbPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbPassword_KeyPress);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(140, 55);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(69, 101);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(148, 13);
            this.lblError.TabIndex = 5;
            this.lblError.Text = "Usuario/Password Incorrecto.";
            this.lblError.Visible = false;
            // 
            // pbxLogoCliente
            // 
            this.pbxLogoCliente.Location = new System.Drawing.Point(237, 3);
            this.pbxLogoCliente.Name = "pbxLogoCliente";
            this.pbxLogoCliente.Size = new System.Drawing.Size(78, 56);
            this.pbxLogoCliente.TabIndex = 6;
            this.pbxLogoCliente.TabStop = false;
            // 
            // pnlControles
            // 
            this.pnlControles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlControles.Controls.Add(this.cbxRecordar);
            this.pnlControles.Controls.Add(this.txbUsuario);
            this.pnlControles.Controls.Add(this.label1);
            this.pnlControles.Controls.Add(this.pbxLogoCliente);
            this.pnlControles.Controls.Add(this.label2);
            this.pnlControles.Controls.Add(this.lblError);
            this.pnlControles.Controls.Add(this.txbPassword);
            this.pnlControles.Controls.Add(this.btnAceptar);
            this.pnlControles.Location = new System.Drawing.Point(12, 12);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Size = new System.Drawing.Size(318, 119);
            this.pnlControles.TabIndex = 8;
            // 
            // cbxRecordar
            // 
            this.cbxRecordar.AutoSize = true;
            this.cbxRecordar.Location = new System.Drawing.Point(72, 82);
            this.cbxRecordar.Name = "cbxRecordar";
            this.cbxRecordar.Size = new System.Drawing.Size(99, 17);
            this.cbxRecordar.TabIndex = 8;
            this.cbxRecordar.Text = "Recordar datos";
            this.cbxRecordar.UseVisualStyleBackColor = true;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(342, 137);
            this.Controls.Add(this.pnlControles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogoCliente)).EndInit();
            this.pnlControles.ResumeLayout(false);
            this.pnlControles.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbUsuario;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.PictureBox pbxLogoCliente;
        private System.Windows.Forms.Panel pnlControles;
        private System.Windows.Forms.CheckBox cbxRecordar;
    }
}