namespace LandManagement
{
    partial class frmReservaVenta
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
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlControles = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbOferta = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txbObservaciones = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvReservantes = new System.Windows.Forms.DataGridView();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.pnlControles.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservantes)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(66, 3);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(170, 20);
            this.dtpFecha.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(575, 507);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(656, 507);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 15;
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
            this.groupBox1.Size = new System.Drawing.Size(798, 561);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reserva de Venta";
            // 
            // pnlControles
            // 
            this.pnlControles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlControles.Controls.Add(this.dtpFecha);
            this.pnlControles.Controls.Add(this.btnGuardar);
            this.pnlControles.Controls.Add(this.groupBox3);
            this.pnlControles.Controls.Add(this.btnCancelar);
            this.pnlControles.Controls.Add(this.label2);
            this.pnlControles.Location = new System.Drawing.Point(6, 19);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Size = new System.Drawing.Size(786, 536);
            this.pnlControles.TabIndex = 28;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Location = new System.Drawing.Point(393, 30);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(385, 471);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Reservante";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.txbOferta);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.txbObservaciones);
            this.groupBox7.Location = new System.Drawing.Point(8, 258);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(363, 206);
            this.groupBox7.TabIndex = 15;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Datos de la reserva";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Oferta";
            // 
            // txbOferta
            // 
            this.txbOferta.Location = new System.Drawing.Point(48, 21);
            this.txbOferta.Name = "txbOferta";
            this.txbOferta.Size = new System.Drawing.Size(87, 20);
            this.txbOferta.TabIndex = 12;
            this.txbOferta.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingControl);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Obs.";
            // 
            // txbObservaciones
            // 
            this.txbObservaciones.Location = new System.Drawing.Point(47, 47);
            this.txbObservaciones.Multiline = true;
            this.txbObservaciones.Name = "txbObservaciones";
            this.txbObservaciones.Size = new System.Drawing.Size(283, 152);
            this.txbObservaciones.TabIndex = 13;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnQuitar);
            this.groupBox5.Controls.Add(this.btnAgregar);
            this.groupBox5.Controls.Add(this.dgvReservantes);
            this.groupBox5.Controls.Add(this.cmbCliente);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Location = new System.Drawing.Point(8, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(370, 233);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Buscar Cliente";
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(336, 51);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(27, 23);
            this.btnQuitar.TabIndex = 17;
            this.btnQuitar.Text = "-";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(269, 25);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(62, 21);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvReservantes
            // 
            this.dgvReservantes.AllowUserToAddRows = false;
            this.dgvReservantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservantes.Location = new System.Drawing.Point(14, 51);
            this.dgvReservantes.MultiSelect = false;
            this.dgvReservantes.Name = "dgvReservantes";
            this.dgvReservantes.ReadOnly = true;
            this.dgvReservantes.RowHeadersVisible = false;
            this.dgvReservantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservantes.Size = new System.Drawing.Size(316, 176);
            this.dgvReservantes.TabIndex = 16;
            // 
            // cmbCliente
            // 
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(60, 24);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(203, 21);
            this.cmbCliente.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Apellido";
            // 
            // frmReservaVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(822, 585);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmReservaVenta";
            this.Text = "formReservaVenta";
            this.Load += new System.EventHandler(this.frmReservaVenta_Load);
            this.groupBox1.ResumeLayout(false);
            this.pnlControles.ResumeLayout(false);
            this.pnlControles.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservantes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbOferta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbObservaciones;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel pnlControles;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.DataGridView dgvReservantes;
        private System.Windows.Forms.Button btnAgregar;
    }
}