namespace LandManagement
{
    partial class frmEnAlquiler
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
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txbPrecioPrimerAnio = new System.Windows.Forms.TextBox();
            this.txbPrecioSegundoAnio = new System.Windows.Forms.TextBox();
            this.txbPrecioCuartoAnio = new System.Windows.Forms.TextBox();
            this.txbPrecioQuintoAnio = new System.Windows.Forms.TextBox();
            this.txbPrecioTercerAnio = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlControles = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txbTelefono = new System.Windows.Forms.TextBox();
            this.txbAgua = new System.Windows.Forms.TextBox();
            this.txbGas = new System.Windows.Forms.TextBox();
            this.txbABL = new System.Windows.Forms.TextBox();
            this.txbLuz = new System.Windows.Forms.TextBox();
            this.txbExpensas = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.pnlControles.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Precio 1° año";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Precio 2° año";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Precio 3° año";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(200, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Precio 4° año";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(200, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Precio 5° año";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(68, 3);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(121, 20);
            this.dtpFecha.TabIndex = 1;
            // 
            // txbPrecioPrimerAnio
            // 
            this.txbPrecioPrimerAnio.Location = new System.Drawing.Point(93, 19);
            this.txbPrecioPrimerAnio.Name = "txbPrecioPrimerAnio";
            this.txbPrecioPrimerAnio.Size = new System.Drawing.Size(100, 20);
            this.txbPrecioPrimerAnio.TabIndex = 19;
            this.txbPrecioPrimerAnio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarDecimales);
            this.txbPrecioPrimerAnio.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingControl);
            // 
            // txbPrecioSegundoAnio
            // 
            this.txbPrecioSegundoAnio.Location = new System.Drawing.Point(93, 45);
            this.txbPrecioSegundoAnio.Name = "txbPrecioSegundoAnio";
            this.txbPrecioSegundoAnio.Size = new System.Drawing.Size(100, 20);
            this.txbPrecioSegundoAnio.TabIndex = 20;
            this.txbPrecioSegundoAnio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarDecimales);
            // 
            // txbPrecioCuartoAnio
            // 
            this.txbPrecioCuartoAnio.Location = new System.Drawing.Point(277, 17);
            this.txbPrecioCuartoAnio.Name = "txbPrecioCuartoAnio";
            this.txbPrecioCuartoAnio.Size = new System.Drawing.Size(100, 20);
            this.txbPrecioCuartoAnio.TabIndex = 22;
            this.txbPrecioCuartoAnio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarDecimales);
            // 
            // txbPrecioQuintoAnio
            // 
            this.txbPrecioQuintoAnio.Location = new System.Drawing.Point(277, 43);
            this.txbPrecioQuintoAnio.Name = "txbPrecioQuintoAnio";
            this.txbPrecioQuintoAnio.Size = new System.Drawing.Size(100, 20);
            this.txbPrecioQuintoAnio.TabIndex = 23;
            this.txbPrecioQuintoAnio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarDecimales);
            // 
            // txbPrecioTercerAnio
            // 
            this.txbPrecioTercerAnio.Location = new System.Drawing.Point(93, 71);
            this.txbPrecioTercerAnio.Name = "txbPrecioTercerAnio";
            this.txbPrecioTercerAnio.Size = new System.Drawing.Size(100, 20);
            this.txbPrecioTercerAnio.TabIndex = 21;
            this.txbPrecioTercerAnio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarDecimales);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(619, 371);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 24;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(700, 371);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.pnlControles);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(804, 431);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Puesta en Alquiler de una Propiedad";
            // 
            // pnlControles
            // 
            this.pnlControles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlControles.Controls.Add(this.groupBox6);
            this.pnlControles.Controls.Add(this.dtpFecha);
            this.pnlControles.Controls.Add(this.btnCancelar);
            this.pnlControles.Controls.Add(this.btnGuardar);
            this.pnlControles.Controls.Add(this.groupBox4);
            this.pnlControles.Controls.Add(this.label2);
            this.pnlControles.Location = new System.Drawing.Point(6, 19);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Size = new System.Drawing.Size(792, 406);
            this.pnlControles.TabIndex = 27;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txbTelefono);
            this.groupBox6.Controls.Add(this.txbAgua);
            this.groupBox6.Controls.Add(this.txbGas);
            this.groupBox6.Controls.Add(this.txbABL);
            this.groupBox6.Controls.Add(this.txbLuz);
            this.groupBox6.Controls.Add(this.txbExpensas);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Location = new System.Drawing.Point(3, 262);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(389, 103);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Datos Adicionales";
            // 
            // txbTelefono
            // 
            this.txbTelefono.Location = new System.Drawing.Point(286, 52);
            this.txbTelefono.Name = "txbTelefono";
            this.txbTelefono.Size = new System.Drawing.Size(51, 20);
            this.txbTelefono.TabIndex = 11;
            this.txbTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarDecimales);
            // 
            // txbAgua
            // 
            this.txbAgua.Location = new System.Drawing.Point(286, 26);
            this.txbAgua.Name = "txbAgua";
            this.txbAgua.Size = new System.Drawing.Size(51, 20);
            this.txbAgua.TabIndex = 10;
            this.txbAgua.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarDecimales);
            // 
            // txbGas
            // 
            this.txbGas.Location = new System.Drawing.Point(168, 53);
            this.txbGas.Name = "txbGas";
            this.txbGas.Size = new System.Drawing.Size(51, 20);
            this.txbGas.TabIndex = 9;
            this.txbGas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarDecimales);
            // 
            // txbABL
            // 
            this.txbABL.Location = new System.Drawing.Point(168, 27);
            this.txbABL.Name = "txbABL";
            this.txbABL.Size = new System.Drawing.Size(51, 20);
            this.txbABL.TabIndex = 8;
            this.txbABL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarDecimales);
            // 
            // txbLuz
            // 
            this.txbLuz.Location = new System.Drawing.Point(66, 53);
            this.txbLuz.Name = "txbLuz";
            this.txbLuz.Size = new System.Drawing.Size(51, 20);
            this.txbLuz.TabIndex = 7;
            this.txbLuz.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarDecimales);
            // 
            // txbExpensas
            // 
            this.txbExpensas.Location = new System.Drawing.Point(66, 27);
            this.txbExpensas.Name = "txbExpensas";
            this.txbExpensas.Size = new System.Drawing.Size(51, 20);
            this.txbExpensas.TabIndex = 6;
            this.txbExpensas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarDecimales);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(231, 58);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(49, 13);
            this.label20.TabIndex = 5;
            this.label20.Text = "Telefono";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(248, 30);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 13);
            this.label19.TabIndex = 4;
            this.label19.Text = "Agua";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(135, 58);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(26, 13);
            this.label18.TabIndex = 3;
            this.label18.Text = "Gas";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(135, 30);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(27, 13);
            this.label17.TabIndex = 2;
            this.label17.Text = "ABL";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(36, 59);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Luz";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Expensas";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txbPrecioTercerAnio);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txbPrecioQuintoAnio);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txbPrecioCuartoAnio);
            this.groupBox4.Controls.Add(this.txbPrecioPrimerAnio);
            this.groupBox4.Controls.Add(this.txbPrecioSegundoAnio);
            this.groupBox4.Location = new System.Drawing.Point(398, 262);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(387, 103);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Valores Alquiler";
            // 
            // frmEnAlquiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(828, 455);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmEnAlquiler";
            this.Text = "frmEnAlquiler";
            this.Load += new System.EventHandler(this.frmEnAlquiler_Load);
            this.groupBox1.ResumeLayout(false);
            this.pnlControles.ResumeLayout(false);
            this.pnlControles.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txbPrecioPrimerAnio;
        private System.Windows.Forms.TextBox txbPrecioSegundoAnio;
        private System.Windows.Forms.TextBox txbPrecioCuartoAnio;
        private System.Windows.Forms.TextBox txbPrecioQuintoAnio;
        private System.Windows.Forms.TextBox txbPrecioTercerAnio;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txbTelefono;
        private System.Windows.Forms.TextBox txbAgua;
        private System.Windows.Forms.TextBox txbGas;
        private System.Windows.Forms.TextBox txbABL;
        private System.Windows.Forms.TextBox txbLuz;
        private System.Windows.Forms.TextBox txbExpensas;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlControles;
    }
}