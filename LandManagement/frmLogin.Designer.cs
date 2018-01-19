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
            this.gbxLogin = new System.Windows.Forms.GroupBox();
            this.txbUsuario = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cbxRecordar = new System.Windows.Forms.CheckBox();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbxLogoCliente = new System.Windows.Forms.PictureBox();
            this.lkbActivarProducto = new System.Windows.Forms.LinkLabel();
            this.gbxLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogoCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxLogin
            // 
            this.gbxLogin.Controls.Add(this.txbUsuario);
            this.gbxLogin.Controls.Add(this.btnAceptar);
            this.gbxLogin.Controls.Add(this.cbxRecordar);
            this.gbxLogin.Controls.Add(this.txbPassword);
            this.gbxLogin.Controls.Add(this.lblError);
            this.gbxLogin.Controls.Add(this.label1);
            this.gbxLogin.Controls.Add(this.label2);
            this.gbxLogin.Controls.Add(this.pbxLogoCliente);
            this.gbxLogin.Location = new System.Drawing.Point(12, 12);
            this.gbxLogin.Name = "gbxLogin";
            this.gbxLogin.Size = new System.Drawing.Size(327, 135);
            this.gbxLogin.TabIndex = 12;
            this.gbxLogin.TabStop = false;
            this.gbxLogin.Text = "Login";
            // 
            // txbUsuario
            // 
            this.txbUsuario.Location = new System.Drawing.Point(79, 18);
            this.txbUsuario.Name = "txbUsuario";
            this.txbUsuario.Size = new System.Drawing.Size(143, 20);
            this.txbUsuario.TabIndex = 2;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(147, 70);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cbxRecordar
            // 
            this.cbxRecordar.AutoSize = true;
            this.cbxRecordar.Location = new System.Drawing.Point(79, 97);
            this.cbxRecordar.Name = "cbxRecordar";
            this.cbxRecordar.Size = new System.Drawing.Size(99, 17);
            this.cbxRecordar.TabIndex = 8;
            this.cbxRecordar.Text = "Recordar datos";
            this.cbxRecordar.UseVisualStyleBackColor = true;
            // 
            // txbPassword
            // 
            this.txbPassword.Location = new System.Drawing.Point(79, 44);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '•';
            this.txbPassword.Size = new System.Drawing.Size(143, 20);
            this.txbPassword.TabIndex = 3;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(76, 116);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(148, 13);
            this.lblError.TabIndex = 5;
            this.lblError.Text = "Usuario/Password Incorrecto.";
            this.lblError.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // pbxLogoCliente
            // 
            this.pbxLogoCliente.Location = new System.Drawing.Point(244, 18);
            this.pbxLogoCliente.Name = "pbxLogoCliente";
            this.pbxLogoCliente.Size = new System.Drawing.Size(78, 56);
            this.pbxLogoCliente.TabIndex = 6;
            this.pbxLogoCliente.TabStop = false;
            // 
            // lkbActivarProducto
            // 
            this.lkbActivarProducto.AutoSize = true;
            this.lkbActivarProducto.Location = new System.Drawing.Point(250, 148);
            this.lkbActivarProducto.Name = "lkbActivarProducto";
            this.lkbActivarProducto.Size = new System.Drawing.Size(86, 13);
            this.lkbActivarProducto.TabIndex = 13;
            this.lkbActivarProducto.TabStop = true;
            this.lkbActivarProducto.Text = "Activar Producto";
            this.lkbActivarProducto.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkbActivarProducto_LinkClicked);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(352, 163);
            this.Controls.Add(this.lkbActivarProducto);
            this.Controls.Add(this.gbxLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.gbxLogin.ResumeLayout(false);
            this.gbxLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogoCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxLogin;
        private System.Windows.Forms.TextBox txbUsuario;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.CheckBox cbxRecordar;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbxLogoCliente;
        private System.Windows.Forms.LinkLabel lkbActivarProducto;

    }
}