namespace LandManagement
{
    partial class frmVenta
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
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txbPrecio = new System.Windows.Forms.TextBox();
            this.dtpFechaBoleto = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaEscritura = new System.Windows.Forms.DateTimePicker();
            this.txbEscribano = new System.Windows.Forms.TextBox();
            this.txbPresupuesto = new System.Windows.Forms.TextBox();
            this.txbEscribania = new System.Windows.Forms.TextBox();
            this.txbCobrado = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlControles = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnRemoveComprador = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvComprador = new System.Windows.Forms.DataGridView();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.pnlControles.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprador)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha Boleto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha Escritura";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Precio";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Escribano";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Presupuesto";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 153);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Participación escribania";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(77, 179);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Cobrado";
            // 
            // txbPrecio
            // 
            this.txbPrecio.Location = new System.Drawing.Point(98, 71);
            this.txbPrecio.Name = "txbPrecio";
            this.txbPrecio.Size = new System.Drawing.Size(133, 20);
            this.txbPrecio.TabIndex = 13;
            this.txbPrecio.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingControl);
            // 
            // dtpFechaBoleto
            // 
            this.dtpFechaBoleto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaBoleto.Location = new System.Drawing.Point(98, 19);
            this.dtpFechaBoleto.Name = "dtpFechaBoleto";
            this.dtpFechaBoleto.Size = new System.Drawing.Size(133, 20);
            this.dtpFechaBoleto.TabIndex = 1;
            // 
            // dtpFechaEscritura
            // 
            this.dtpFechaEscritura.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaEscritura.Location = new System.Drawing.Point(98, 45);
            this.dtpFechaEscritura.Name = "dtpFechaEscritura";
            this.dtpFechaEscritura.Size = new System.Drawing.Size(133, 20);
            this.dtpFechaEscritura.TabIndex = 2;
            // 
            // txbEscribano
            // 
            this.txbEscribano.Location = new System.Drawing.Point(98, 97);
            this.txbEscribano.Name = "txbEscribano";
            this.txbEscribano.Size = new System.Drawing.Size(133, 20);
            this.txbEscribano.TabIndex = 15;
            // 
            // txbPresupuesto
            // 
            this.txbPresupuesto.Location = new System.Drawing.Point(98, 123);
            this.txbPresupuesto.Name = "txbPresupuesto";
            this.txbPresupuesto.Size = new System.Drawing.Size(133, 20);
            this.txbPresupuesto.TabIndex = 16;
            // 
            // txbEscribania
            // 
            this.txbEscribania.Location = new System.Drawing.Point(131, 149);
            this.txbEscribania.Name = "txbEscribania";
            this.txbEscribania.Size = new System.Drawing.Size(100, 20);
            this.txbEscribania.TabIndex = 19;
            // 
            // txbCobrado
            // 
            this.txbCobrado.Location = new System.Drawing.Point(131, 175);
            this.txbCobrado.Name = "txbCobrado";
            this.txbCobrado.Size = new System.Drawing.Size(100, 20);
            this.txbCobrado.TabIndex = 20;
            this.txbCobrado.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingControl);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(633, 490);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 21;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(714, 490);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 22;
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
            this.groupBox1.Size = new System.Drawing.Size(812, 541);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Venta de una Propiedad";
            // 
            // pnlControles
            // 
            this.pnlControles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlControles.Controls.Add(this.label4);
            this.pnlControles.Controls.Add(this.btnCancelar);
            this.pnlControles.Controls.Add(this.btnGuardar);
            this.pnlControles.Controls.Add(this.groupBox6);
            this.pnlControles.Controls.Add(this.dtpFecha);
            this.pnlControles.Location = new System.Drawing.Point(6, 19);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Size = new System.Drawing.Size(800, 516);
            this.pnlControles.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Fecha";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txbPrecio);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.groupBox5);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.dtpFechaEscritura);
            this.groupBox6.Controls.Add(this.txbCobrado);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.dtpFechaBoleto);
            this.groupBox6.Controls.Add(this.txbEscribania);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.txbEscribano);
            this.groupBox6.Controls.Add(this.txbPresupuesto);
            this.groupBox6.Location = new System.Drawing.Point(388, 31);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(401, 453);
            this.groupBox6.TabIndex = 26;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Detalle de Venta";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnRemoveComprador);
            this.groupBox5.Controls.Add(this.btnAgregar);
            this.groupBox5.Controls.Add(this.cmbCliente);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.dgvComprador);
            this.groupBox5.Location = new System.Drawing.Point(16, 232);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(379, 195);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Datos Comprador";
            // 
            // btnRemoveComprador
            // 
            this.btnRemoveComprador.Location = new System.Drawing.Point(342, 53);
            this.btnRemoveComprador.Name = "btnRemoveComprador";
            this.btnRemoveComprador.Size = new System.Drawing.Size(27, 23);
            this.btnRemoveComprador.TabIndex = 27;
            this.btnRemoveComprador.Text = "-";
            this.btnRemoveComprador.UseVisualStyleBackColor = true;
            this.btnRemoveComprador.Click += new System.EventHandler(this.btnRemoveComprador_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(280, 21);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(56, 23);
            this.btnAgregar.TabIndex = 24;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // cmbCliente
            // 
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(53, 22);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(216, 21);
            this.cmbCliente.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Cliente";
            // 
            // dgvComprador
            // 
            this.dgvComprador.AllowUserToAddRows = false;
            this.dgvComprador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComprador.Location = new System.Drawing.Point(6, 49);
            this.dgvComprador.MultiSelect = false;
            this.dgvComprador.Name = "dgvComprador";
            this.dgvComprador.ReadOnly = true;
            this.dgvComprador.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComprador.Size = new System.Drawing.Size(330, 139);
            this.dgvComprador.TabIndex = 12;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(46, 5);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(121, 20);
            this.dtpFecha.TabIndex = 28;
            // 
            // frmVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(836, 565);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmVenta";
            this.Text = "frmVenta";
            this.Load += new System.EventHandler(this.frmVenta_Load);
            this.groupBox1.ResumeLayout(false);
            this.pnlControles.ResumeLayout(false);
            this.pnlControles.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprador)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txbPrecio;
        private System.Windows.Forms.DateTimePicker dtpFechaBoleto;
        private System.Windows.Forms.DateTimePicker dtpFechaEscritura;
        private System.Windows.Forms.TextBox txbEscribano;
        private System.Windows.Forms.TextBox txbPresupuesto;
        private System.Windows.Forms.TextBox txbEscribania;
        private System.Windows.Forms.TextBox txbCobrado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvComprador;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRemoveComprador;
        private System.Windows.Forms.Panel pnlControles;
    }
}