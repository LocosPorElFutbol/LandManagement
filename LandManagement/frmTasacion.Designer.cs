namespace LandManagement
{
    partial class frmTasacion
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
            this.label7 = new System.Windows.Forms.Label();
            this.txbTasacion = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlControles = new System.Windows.Forms.Panel();
            this.gbxDatosTasacion = new System.Windows.Forms.GroupBox();
            this.txbObservaciones = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txbNombreCliente = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txbApellidoCliente = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.gbxCliente = new System.Windows.Forms.GroupBox();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gbxDetalleDireccion = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbTipoPropiedad = new System.Windows.Forms.ComboBox();
            this.cmbDepto = new System.Windows.Forms.ComboBox();
            this.cmbPiso = new System.Windows.Forms.ComboBox();
            this.txbCodigoPostal = new System.Windows.Forms.TextBox();
            this.txbNumero = new System.Windows.Forms.TextBox();
            this.txbLocalidad = new System.Windows.Forms.TextBox();
            this.txbCalle = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDireccion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.pnlControles.SuspendLayout();
            this.gbxDatosTasacion.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gbxCliente.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbxDetalleDireccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(67, 3);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(93, 20);
            this.dtpFecha.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Tasacion";
            // 
            // txbTasacion
            // 
            this.txbTasacion.Location = new System.Drawing.Point(65, 26);
            this.txbTasacion.Name = "txbTasacion";
            this.txbTasacion.Size = new System.Drawing.Size(51, 20);
            this.txbTasacion.TabIndex = 12;
            this.txbTasacion.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingControl);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(220, 561);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(303, 561);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 14;
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
            this.groupBox1.Size = new System.Drawing.Size(403, 615);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tasación de una Propiedad";
            // 
            // pnlControles
            // 
            this.pnlControles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlControles.Controls.Add(this.gbxDatosTasacion);
            this.pnlControles.Controls.Add(this.dtpFecha);
            this.pnlControles.Controls.Add(this.gbxCliente);
            this.pnlControles.Controls.Add(this.btnCancelar);
            this.pnlControles.Controls.Add(this.btnGuardar);
            this.pnlControles.Controls.Add(this.label2);
            this.pnlControles.Controls.Add(this.groupBox2);
            this.pnlControles.Location = new System.Drawing.Point(6, 19);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Size = new System.Drawing.Size(391, 590);
            this.pnlControles.TabIndex = 15;
            // 
            // gbxDatosTasacion
            // 
            this.gbxDatosTasacion.Controls.Add(this.txbObservaciones);
            this.gbxDatosTasacion.Controls.Add(this.label13);
            this.gbxDatosTasacion.Controls.Add(this.label7);
            this.gbxDatosTasacion.Controls.Add(this.txbTasacion);
            this.gbxDatosTasacion.Location = new System.Drawing.Point(9, 388);
            this.gbxDatosTasacion.Name = "gbxDatosTasacion";
            this.gbxDatosTasacion.Size = new System.Drawing.Size(369, 167);
            this.gbxDatosTasacion.TabIndex = 28;
            this.gbxDatosTasacion.TabStop = false;
            this.gbxDatosTasacion.Text = "Datos de la tasación";
            // 
            // txbObservaciones
            // 
            this.txbObservaciones.Location = new System.Drawing.Point(65, 52);
            this.txbObservaciones.Multiline = true;
            this.txbObservaciones.Name = "txbObservaciones";
            this.txbObservaciones.Size = new System.Drawing.Size(276, 104);
            this.txbObservaciones.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Obs.";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txbNombreCliente);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.txbApellidoCliente);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Location = new System.Drawing.Point(7, 51);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(334, 81);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Cliente";
            // 
            // txbNombreCliente
            // 
            this.txbNombreCliente.Location = new System.Drawing.Point(63, 23);
            this.txbNombreCliente.Name = "txbNombreCliente";
            this.txbNombreCliente.Size = new System.Drawing.Size(195, 20);
            this.txbNombreCliente.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Nombre";
            // 
            // txbApellidoCliente
            // 
            this.txbApellidoCliente.Location = new System.Drawing.Point(63, 49);
            this.txbApellidoCliente.Name = "txbApellidoCliente";
            this.txbApellidoCliente.Size = new System.Drawing.Size(195, 20);
            this.txbApellidoCliente.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "Apellido";
            // 
            // gbxCliente
            // 
            this.gbxCliente.Controls.Add(this.cmbCliente);
            this.gbxCliente.Controls.Add(this.label16);
            this.gbxCliente.Controls.Add(this.groupBox5);
            this.gbxCliente.Location = new System.Drawing.Point(3, 235);
            this.gbxCliente.Name = "gbxCliente";
            this.gbxCliente.Size = new System.Drawing.Size(375, 147);
            this.gbxCliente.TabIndex = 14;
            this.gbxCliente.TabStop = false;
            this.gbxCliente.Text = "Buscar Cliente";
            // 
            // cmbCliente
            // 
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(71, 24);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(205, 21);
            this.cmbCliente.TabIndex = 1;
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.cmbCliente_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(21, 27);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Nombre";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gbxDetalleDireccion);
            this.groupBox2.Controls.Add(this.cmbDireccion);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(3, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(375, 200);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de la Propiedad";
            // 
            // gbxDetalleDireccion
            // 
            this.gbxDetalleDireccion.Controls.Add(this.label8);
            this.gbxDetalleDireccion.Controls.Add(this.cmbTipoPropiedad);
            this.gbxDetalleDireccion.Controls.Add(this.cmbDepto);
            this.gbxDetalleDireccion.Controls.Add(this.cmbPiso);
            this.gbxDetalleDireccion.Controls.Add(this.txbCodigoPostal);
            this.gbxDetalleDireccion.Controls.Add(this.txbNumero);
            this.gbxDetalleDireccion.Controls.Add(this.txbLocalidad);
            this.gbxDetalleDireccion.Controls.Add(this.txbCalle);
            this.gbxDetalleDireccion.Controls.Add(this.label12);
            this.gbxDetalleDireccion.Controls.Add(this.label11);
            this.gbxDetalleDireccion.Controls.Add(this.label10);
            this.gbxDetalleDireccion.Controls.Add(this.label9);
            this.gbxDetalleDireccion.Controls.Add(this.label4);
            this.gbxDetalleDireccion.Controls.Add(this.label3);
            this.gbxDetalleDireccion.Location = new System.Drawing.Point(6, 56);
            this.gbxDetalleDireccion.Name = "gbxDetalleDireccion";
            this.gbxDetalleDireccion.Size = new System.Drawing.Size(362, 137);
            this.gbxDetalleDireccion.TabIndex = 3;
            this.gbxDetalleDireccion.TabStop = false;
            this.gbxDetalleDireccion.Text = "Detalle";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "Tipo";
            // 
            // cmbTipoPropiedad
            // 
            this.cmbTipoPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPropiedad.FormattingEnabled = true;
            this.cmbTipoPropiedad.Location = new System.Drawing.Point(65, 24);
            this.cmbTipoPropiedad.Name = "cmbTipoPropiedad";
            this.cmbTipoPropiedad.Size = new System.Drawing.Size(154, 21);
            this.cmbTipoPropiedad.TabIndex = 46;
            // 
            // cmbDepto
            // 
            this.cmbDepto.FormattingEnabled = true;
            this.cmbDepto.Location = new System.Drawing.Point(294, 77);
            this.cmbDepto.Name = "cmbDepto";
            this.cmbDepto.Size = new System.Drawing.Size(49, 21);
            this.cmbDepto.TabIndex = 7;
            // 
            // cmbPiso
            // 
            this.cmbPiso.FormattingEnabled = true;
            this.cmbPiso.Location = new System.Drawing.Point(65, 77);
            this.cmbPiso.Name = "cmbPiso";
            this.cmbPiso.Size = new System.Drawing.Size(51, 21);
            this.cmbPiso.TabIndex = 6;
            // 
            // txbCodigoPostal
            // 
            this.txbCodigoPostal.Location = new System.Drawing.Point(294, 104);
            this.txbCodigoPostal.Name = "txbCodigoPostal";
            this.txbCodigoPostal.Size = new System.Drawing.Size(49, 20);
            this.txbCodigoPostal.TabIndex = 9;
            // 
            // txbNumero
            // 
            this.txbNumero.Location = new System.Drawing.Point(294, 51);
            this.txbNumero.Name = "txbNumero";
            this.txbNumero.Size = new System.Drawing.Size(49, 20);
            this.txbNumero.TabIndex = 5;
            // 
            // txbLocalidad
            // 
            this.txbLocalidad.Location = new System.Drawing.Point(65, 104);
            this.txbLocalidad.Name = "txbLocalidad";
            this.txbLocalidad.Size = new System.Drawing.Size(155, 20);
            this.txbLocalidad.TabIndex = 8;
            // 
            // txbCalle
            // 
            this.txbCalle.Location = new System.Drawing.Point(65, 51);
            this.txbCalle.Name = "txbCalle";
            this.txbCalle.Size = new System.Drawing.Size(155, 20);
            this.txbCalle.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(252, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Depto";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Piso";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Localidad";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(267, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "CP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Calle";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Número";
            // 
            // cmbDireccion
            // 
            this.cmbDireccion.FormattingEnabled = true;
            this.cmbDireccion.Location = new System.Drawing.Point(67, 23);
            this.cmbDireccion.Name = "cmbDireccion";
            this.cmbDireccion.Size = new System.Drawing.Size(218, 21);
            this.cmbDireccion.TabIndex = 2;
            this.cmbDireccion.SelectedIndexChanged += new System.EventHandler(this.cmbDireccion_SelectedIndexChanged);
            this.cmbDireccion.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingControl);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dirección";
            // 
            // frmTasacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(427, 639);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTasacion";
            this.Text = "frmTasacion";
            this.Load += new System.EventHandler(this.frmTasacion_Load);
            this.groupBox1.ResumeLayout(false);
            this.pnlControles.ResumeLayout(false);
            this.pnlControles.PerformLayout();
            this.gbxDatosTasacion.ResumeLayout(false);
            this.gbxDatosTasacion.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gbxCliente.ResumeLayout(false);
            this.gbxCliente.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbxDetalleDireccion.ResumeLayout(false);
            this.gbxDetalleDireccion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbTasacion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbDireccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbxDetalleDireccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbNumero;
        private System.Windows.Forms.TextBox txbLocalidad;
        private System.Windows.Forms.TextBox txbCalle;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDepto;
        private System.Windows.Forms.ComboBox cmbPiso;
        private System.Windows.Forms.TextBox txbCodigoPostal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbTipoPropiedad;
        private System.Windows.Forms.TextBox txbObservaciones;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel pnlControles;
        private System.Windows.Forms.GroupBox gbxDatosTasacion;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txbNombreCliente;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txbApellidoCliente;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox gbxCliente;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbCliente;
    }
}