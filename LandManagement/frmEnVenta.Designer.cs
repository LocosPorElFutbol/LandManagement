namespace LandManagement
{
    partial class frmEnVenta
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
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFechaEnVenta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txbPrecio = new System.Windows.Forms.TextBox();
            this.txbCartel = new System.Windows.Forms.TextBox();
            this.txbObservaciones = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlControles = new System.Windows.Forms.Panel();
            this.gbxDetalleEnVenta = new System.Windows.Forms.GroupBox();
            this.rdbVigenteNo = new System.Windows.Forms.RadioButton();
            this.rdbVigenteSi = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbxTelefono = new System.Windows.Forms.CheckBox();
            this.cbxGas = new System.Windows.Forms.CheckBox();
            this.cbxLuz = new System.Windows.Forms.CheckBox();
            this.cbxAgua = new System.Windows.Forms.CheckBox();
            this.cbxAbl = new System.Windows.Forms.CheckBox();
            this.cbxMatricula = new System.Windows.Forms.CheckBox();
            this.cbxReglamento = new System.Windows.Forms.CheckBox();
            this.cbxPlanos = new System.Windows.Forms.CheckBox();
            this.cbxTituloPropiedad = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnRemoveAutorizante = new System.Windows.Forms.Button();
            this.btnAgregarAutorizante = new System.Windows.Forms.Button();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvAutorizantes = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.pnlControles.SuspendLayout();
            this.gbxDetalleEnVenta.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutorizantes)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Vencimiento";
            // 
            // dtpFechaEnVenta
            // 
            this.dtpFechaEnVenta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaEnVenta.Location = new System.Drawing.Point(67, 13);
            this.dtpFechaEnVenta.Name = "dtpFechaEnVenta";
            this.dtpFechaEnVenta.Size = new System.Drawing.Size(85, 20);
            this.dtpFechaEnVenta.TabIndex = 1;
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(79, 23);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(87, 20);
            this.dtpFechaVencimiento.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Vigente";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Precio";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Cartel";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Obs.";
            // 
            // txbPrecio
            // 
            this.txbPrecio.Location = new System.Drawing.Point(79, 76);
            this.txbPrecio.Name = "txbPrecio";
            this.txbPrecio.Size = new System.Drawing.Size(87, 20);
            this.txbPrecio.TabIndex = 21;
            this.txbPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarDecimal);
            this.txbPrecio.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingControl);
            // 
            // txbCartel
            // 
            this.txbCartel.Location = new System.Drawing.Point(79, 102);
            this.txbCartel.Name = "txbCartel";
            this.txbCartel.Size = new System.Drawing.Size(87, 20);
            this.txbCartel.TabIndex = 22;
            // 
            // txbObservaciones
            // 
            this.txbObservaciones.Location = new System.Drawing.Point(79, 128);
            this.txbObservaciones.Multiline = true;
            this.txbObservaciones.Name = "txbObservaciones";
            this.txbObservaciones.Size = new System.Drawing.Size(274, 142);
            this.txbObservaciones.TabIndex = 23;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(573, 591);
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
            this.btnCancelar.Location = new System.Drawing.Point(654, 591);
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
            this.groupBox1.Size = new System.Drawing.Size(1096, 639);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Puesta en Venta de una Propiedad";
            // 
            // pnlControles
            // 
            this.pnlControles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlControles.Controls.Add(this.groupBox6);
            this.pnlControles.Controls.Add(this.label2);
            this.pnlControles.Controls.Add(this.btnCancelar);
            this.pnlControles.Controls.Add(this.btnGuardar);
            this.pnlControles.Controls.Add(this.dtpFechaEnVenta);
            this.pnlControles.Controls.Add(this.gbxDetalleEnVenta);
            this.pnlControles.Controls.Add(this.groupBox4);
            this.pnlControles.Location = new System.Drawing.Point(6, 19);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Size = new System.Drawing.Size(1084, 620);
            this.pnlControles.TabIndex = 26;
            // 
            // gbxDetalleEnVenta
            // 
            this.gbxDetalleEnVenta.Controls.Add(this.rdbVigenteNo);
            this.gbxDetalleEnVenta.Controls.Add(this.rdbVigenteSi);
            this.gbxDetalleEnVenta.Controls.Add(this.label7);
            this.gbxDetalleEnVenta.Controls.Add(this.txbObservaciones);
            this.gbxDetalleEnVenta.Controls.Add(this.label8);
            this.gbxDetalleEnVenta.Controls.Add(this.label10);
            this.gbxDetalleEnVenta.Controls.Add(this.txbCartel);
            this.gbxDetalleEnVenta.Controls.Add(this.txbPrecio);
            this.gbxDetalleEnVenta.Controls.Add(this.label9);
            this.gbxDetalleEnVenta.Controls.Add(this.dtpFechaVencimiento);
            this.gbxDetalleEnVenta.Controls.Add(this.label6);
            this.gbxDetalleEnVenta.Location = new System.Drawing.Point(399, 292);
            this.gbxDetalleEnVenta.Name = "gbxDetalleEnVenta";
            this.gbxDetalleEnVenta.Size = new System.Drawing.Size(359, 293);
            this.gbxDetalleEnVenta.TabIndex = 15;
            this.gbxDetalleEnVenta.TabStop = false;
            this.gbxDetalleEnVenta.Text = "Detalle";
            // 
            // rdbVigenteNo
            // 
            this.rdbVigenteNo.AutoSize = true;
            this.rdbVigenteNo.Location = new System.Drawing.Point(119, 50);
            this.rdbVigenteNo.Name = "rdbVigenteNo";
            this.rdbVigenteNo.Size = new System.Drawing.Size(39, 17);
            this.rdbVigenteNo.TabIndex = 25;
            this.rdbVigenteNo.TabStop = true;
            this.rdbVigenteNo.Text = "No";
            this.rdbVigenteNo.UseVisualStyleBackColor = true;
            // 
            // rdbVigenteSi
            // 
            this.rdbVigenteSi.AutoSize = true;
            this.rdbVigenteSi.Location = new System.Drawing.Point(79, 51);
            this.rdbVigenteSi.Name = "rdbVigenteSi";
            this.rdbVigenteSi.Size = new System.Drawing.Size(34, 17);
            this.rdbVigenteSi.TabIndex = 24;
            this.rdbVigenteSi.TabStop = true;
            this.rdbVigenteSi.Text = "Si";
            this.rdbVigenteSi.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbxTelefono);
            this.groupBox6.Controls.Add(this.cbxGas);
            this.groupBox6.Controls.Add(this.cbxLuz);
            this.groupBox6.Controls.Add(this.cbxAgua);
            this.groupBox6.Controls.Add(this.cbxAbl);
            this.groupBox6.Controls.Add(this.cbxMatricula);
            this.groupBox6.Controls.Add(this.cbxReglamento);
            this.groupBox6.Controls.Add(this.cbxPlanos);
            this.groupBox6.Controls.Add(this.cbxTituloPropiedad);
            this.groupBox6.Location = new System.Drawing.Point(15, 269);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(378, 110);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Datos Adicionales";
            // 
            // cbxTelefono
            // 
            this.cbxTelefono.AutoSize = true;
            this.cbxTelefono.Location = new System.Drawing.Point(251, 77);
            this.cbxTelefono.Name = "cbxTelefono";
            this.cbxTelefono.Size = new System.Drawing.Size(68, 17);
            this.cbxTelefono.TabIndex = 16;
            this.cbxTelefono.Text = "Telefono";
            this.cbxTelefono.UseVisualStyleBackColor = true;
            // 
            // cbxGas
            // 
            this.cbxGas.AutoSize = true;
            this.cbxGas.Location = new System.Drawing.Point(152, 77);
            this.cbxGas.Name = "cbxGas";
            this.cbxGas.Size = new System.Drawing.Size(45, 17);
            this.cbxGas.TabIndex = 15;
            this.cbxGas.Text = "Gas";
            this.cbxGas.UseVisualStyleBackColor = true;
            // 
            // cbxLuz
            // 
            this.cbxLuz.AutoSize = true;
            this.cbxLuz.Location = new System.Drawing.Point(15, 77);
            this.cbxLuz.Name = "cbxLuz";
            this.cbxLuz.Size = new System.Drawing.Size(43, 17);
            this.cbxLuz.TabIndex = 14;
            this.cbxLuz.Text = "Luz";
            this.cbxLuz.UseVisualStyleBackColor = true;
            // 
            // cbxAgua
            // 
            this.cbxAgua.AutoSize = true;
            this.cbxAgua.Location = new System.Drawing.Point(251, 54);
            this.cbxAgua.Name = "cbxAgua";
            this.cbxAgua.Size = new System.Drawing.Size(51, 17);
            this.cbxAgua.TabIndex = 13;
            this.cbxAgua.Text = "Agua";
            this.cbxAgua.UseVisualStyleBackColor = true;
            // 
            // cbxAbl
            // 
            this.cbxAbl.AutoSize = true;
            this.cbxAbl.Location = new System.Drawing.Point(152, 54);
            this.cbxAbl.Name = "cbxAbl";
            this.cbxAbl.Size = new System.Drawing.Size(46, 17);
            this.cbxAbl.TabIndex = 12;
            this.cbxAbl.Text = "ABL";
            this.cbxAbl.UseVisualStyleBackColor = true;
            // 
            // cbxMatricula
            // 
            this.cbxMatricula.AutoSize = true;
            this.cbxMatricula.Location = new System.Drawing.Point(15, 54);
            this.cbxMatricula.Name = "cbxMatricula";
            this.cbxMatricula.Size = new System.Drawing.Size(69, 17);
            this.cbxMatricula.TabIndex = 11;
            this.cbxMatricula.Text = "Matricula";
            this.cbxMatricula.UseVisualStyleBackColor = true;
            // 
            // cbxReglamento
            // 
            this.cbxReglamento.AutoSize = true;
            this.cbxReglamento.Location = new System.Drawing.Point(251, 31);
            this.cbxReglamento.Name = "cbxReglamento";
            this.cbxReglamento.Size = new System.Drawing.Size(83, 17);
            this.cbxReglamento.TabIndex = 10;
            this.cbxReglamento.Text = "Reglamento";
            this.cbxReglamento.UseVisualStyleBackColor = true;
            // 
            // cbxPlanos
            // 
            this.cbxPlanos.AutoSize = true;
            this.cbxPlanos.Location = new System.Drawing.Point(152, 31);
            this.cbxPlanos.Name = "cbxPlanos";
            this.cbxPlanos.Size = new System.Drawing.Size(58, 17);
            this.cbxPlanos.TabIndex = 9;
            this.cbxPlanos.Text = "Planos";
            this.cbxPlanos.UseVisualStyleBackColor = true;
            // 
            // cbxTituloPropiedad
            // 
            this.cbxTituloPropiedad.AutoSize = true;
            this.cbxTituloPropiedad.Location = new System.Drawing.Point(15, 31);
            this.cbxTituloPropiedad.Name = "cbxTituloPropiedad";
            this.cbxTituloPropiedad.Size = new System.Drawing.Size(118, 17);
            this.cbxTituloPropiedad.TabIndex = 8;
            this.cbxTituloPropiedad.Text = "Titulo de Propiedad";
            this.cbxTituloPropiedad.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnRemoveAutorizante);
            this.groupBox4.Controls.Add(this.btnAgregarAutorizante);
            this.groupBox4.Controls.Add(this.cmbCliente);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.dgvAutorizantes);
            this.groupBox4.Location = new System.Drawing.Point(399, 41);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(359, 245);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Autorizantes";
            // 
            // btnRemoveAutorizante
            // 
            this.btnRemoveAutorizante.Location = new System.Drawing.Point(325, 58);
            this.btnRemoveAutorizante.Name = "btnRemoveAutorizante";
            this.btnRemoveAutorizante.Size = new System.Drawing.Size(27, 23);
            this.btnRemoveAutorizante.TabIndex = 26;
            this.btnRemoveAutorizante.Text = "-";
            this.btnRemoveAutorizante.UseVisualStyleBackColor = true;
            this.btnRemoveAutorizante.Click += new System.EventHandler(this.btnRemoveAutorizante_Click);
            // 
            // btnAgregarAutorizante
            // 
            this.btnAgregarAutorizante.Location = new System.Drawing.Point(249, 19);
            this.btnAgregarAutorizante.Name = "btnAgregarAutorizante";
            this.btnAgregarAutorizante.Size = new System.Drawing.Size(56, 23);
            this.btnAgregarAutorizante.TabIndex = 21;
            this.btnAgregarAutorizante.Text = "Agregar";
            this.btnAgregarAutorizante.UseVisualStyleBackColor = true;
            this.btnAgregarAutorizante.Click += new System.EventHandler(this.btnAgregarAutorizante_Click);
            // 
            // cmbCliente
            // 
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(79, 21);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(154, 21);
            this.cmbCliente.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Cliente";
            // 
            // dgvAutorizantes
            // 
            this.dgvAutorizantes.AllowUserToAddRows = false;
            this.dgvAutorizantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAutorizantes.Location = new System.Drawing.Point(6, 58);
            this.dgvAutorizantes.MultiSelect = false;
            this.dgvAutorizantes.Name = "dgvAutorizantes";
            this.dgvAutorizantes.ReadOnly = true;
            this.dgvAutorizantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAutorizantes.Size = new System.Drawing.Size(313, 181);
            this.dgvAutorizantes.TabIndex = 18;
            // 
            // frmEnVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(1120, 663);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmEnVenta";
            this.Text = "frmEnVenta";
            this.Load += new System.EventHandler(this.frmEnVenta_Load);
            this.groupBox1.ResumeLayout(false);
            this.pnlControles.ResumeLayout(false);
            this.pnlControles.PerformLayout();
            this.gbxDetalleEnVenta.ResumeLayout(false);
            this.gbxDetalleEnVenta.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutorizantes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFechaEnVenta;
        private System.Windows.Forms.DateTimePicker dtpFechaVencimiento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbPrecio;
        private System.Windows.Forms.TextBox txbCartel;
        private System.Windows.Forms.TextBox txbObservaciones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbxDetalleEnVenta;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvAutorizantes;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox cbxTelefono;
        private System.Windows.Forms.CheckBox cbxGas;
        private System.Windows.Forms.CheckBox cbxLuz;
        private System.Windows.Forms.CheckBox cbxAgua;
        private System.Windows.Forms.CheckBox cbxAbl;
        private System.Windows.Forms.CheckBox cbxMatricula;
        private System.Windows.Forms.CheckBox cbxReglamento;
        private System.Windows.Forms.CheckBox cbxPlanos;
        private System.Windows.Forms.CheckBox cbxTituloPropiedad;
        private System.Windows.Forms.Button btnAgregarAutorizante;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRemoveAutorizante;
        private System.Windows.Forms.RadioButton rdbVigenteNo;
        private System.Windows.Forms.RadioButton rdbVigenteSi;
        private System.Windows.Forms.Panel pnlControles;
    }
}