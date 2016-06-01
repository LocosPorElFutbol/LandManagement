﻿namespace LandManagement
{
    partial class frmReservaAlquiler
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txbNombreReservante = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbOferta = new System.Windows.Forms.TextBox();
            this.txbApellidoReservante = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txbGarantia = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gbxDetallePropiedad = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTipoPropiedad = new System.Windows.Forms.ComboBox();
            this.txbCalle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbDepto = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbPiso = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txbCodigoPostal = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txbLocalidad = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txbNumero = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmbDireccion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbxDetallePropiedad.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(82, 24);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(92, 20);
            this.dtpFecha.TabIndex = 6;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(618, 343);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(537, 343);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(699, 375);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reserva de Alquiler";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Location = new System.Drawing.Point(390, 55);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(303, 282);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Reservante";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txbNombreReservante);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.txbOferta);
            this.groupBox7.Controls.Add(this.txbApellidoReservante);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.txbGarantia);
            this.groupBox7.Location = new System.Drawing.Point(8, 96);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(288, 171);
            this.groupBox7.TabIndex = 15;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Cliente";
            // 
            // txbNombreReservante
            // 
            this.txbNombreReservante.Location = new System.Drawing.Point(63, 23);
            this.txbNombreReservante.Name = "txbNombreReservante";
            this.txbNombreReservante.Size = new System.Drawing.Size(203, 20);
            this.txbNombreReservante.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Oferta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nombre";
            // 
            // txbOferta
            // 
            this.txbOferta.Location = new System.Drawing.Point(63, 74);
            this.txbOferta.Name = "txbOferta";
            this.txbOferta.Size = new System.Drawing.Size(87, 20);
            this.txbOferta.TabIndex = 12;
            this.txbOferta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarDecimales);
            // 
            // txbApellidoReservante
            // 
            this.txbApellidoReservante.Location = new System.Drawing.Point(63, 49);
            this.txbApellidoReservante.Name = "txbApellidoReservante";
            this.txbApellidoReservante.Size = new System.Drawing.Size(203, 20);
            this.txbApellidoReservante.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Garantía";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Apellido";
            // 
            // txbGarantia
            // 
            this.txbGarantia.Location = new System.Drawing.Point(62, 100);
            this.txbGarantia.Multiline = true;
            this.txbGarantia.Name = "txbGarantia";
            this.txbGarantia.Size = new System.Drawing.Size(203, 55);
            this.txbGarantia.TabIndex = 13;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbCliente);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(8, 24);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(286, 61);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Buscar Cliente";
            // 
            // cmbCliente
            // 
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(60, 24);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(205, 21);
            this.cmbCliente.TabIndex = 1;
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.cmbCliente_SelectedIndexChanged);
            this.cmbCliente.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingControl);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nombre";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gbxDetallePropiedad);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Location = new System.Drawing.Point(6, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(378, 282);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de la Propiedad";
            // 
            // gbxDetallePropiedad
            // 
            this.gbxDetallePropiedad.Controls.Add(this.label6);
            this.gbxDetallePropiedad.Controls.Add(this.cmbTipoPropiedad);
            this.gbxDetallePropiedad.Controls.Add(this.txbCalle);
            this.gbxDetallePropiedad.Controls.Add(this.label9);
            this.gbxDetallePropiedad.Controls.Add(this.label11);
            this.gbxDetallePropiedad.Controls.Add(this.cmbDepto);
            this.gbxDetallePropiedad.Controls.Add(this.label12);
            this.gbxDetallePropiedad.Controls.Add(this.cmbPiso);
            this.gbxDetallePropiedad.Controls.Add(this.label13);
            this.gbxDetallePropiedad.Controls.Add(this.txbCodigoPostal);
            this.gbxDetallePropiedad.Controls.Add(this.label14);
            this.gbxDetallePropiedad.Controls.Add(this.txbLocalidad);
            this.gbxDetallePropiedad.Controls.Add(this.label15);
            this.gbxDetallePropiedad.Controls.Add(this.txbNumero);
            this.gbxDetallePropiedad.Location = new System.Drawing.Point(11, 96);
            this.gbxDetallePropiedad.Name = "gbxDetallePropiedad";
            this.gbxDetallePropiedad.Size = new System.Drawing.Size(351, 137);
            this.gbxDetallePropiedad.TabIndex = 20;
            this.gbxDetallePropiedad.TabStop = false;
            this.gbxDetallePropiedad.Text = "Detalle";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "Tipo";
            // 
            // cmbTipoPropiedad
            // 
            this.cmbTipoPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPropiedad.FormattingEnabled = true;
            this.cmbTipoPropiedad.Location = new System.Drawing.Point(65, 24);
            this.cmbTipoPropiedad.Name = "cmbTipoPropiedad";
            this.cmbTipoPropiedad.Size = new System.Drawing.Size(154, 21);
            this.cmbTipoPropiedad.TabIndex = 44;
            // 
            // txbCalle
            // 
            this.txbCalle.Location = new System.Drawing.Point(65, 51);
            this.txbCalle.Name = "txbCalle";
            this.txbCalle.Size = new System.Drawing.Size(154, 20);
            this.txbCalle.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Calle";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Piso";
            // 
            // cmbDepto
            // 
            this.cmbDepto.FormattingEnabled = true;
            this.cmbDepto.Location = new System.Drawing.Point(275, 77);
            this.cmbDepto.Name = "cmbDepto";
            this.cmbDepto.Size = new System.Drawing.Size(59, 21);
            this.cmbDepto.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Localidad";
            // 
            // cmbPiso
            // 
            this.cmbPiso.FormattingEnabled = true;
            this.cmbPiso.Location = new System.Drawing.Point(65, 77);
            this.cmbPiso.Name = "cmbPiso";
            this.cmbPiso.Size = new System.Drawing.Size(51, 21);
            this.cmbPiso.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(225, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Número";
            // 
            // txbCodigoPostal
            // 
            this.txbCodigoPostal.Location = new System.Drawing.Point(275, 104);
            this.txbCodigoPostal.Name = "txbCodigoPostal";
            this.txbCodigoPostal.Size = new System.Drawing.Size(59, 20);
            this.txbCodigoPostal.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(233, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Depto";
            // 
            // txbLocalidad
            // 
            this.txbLocalidad.Location = new System.Drawing.Point(65, 104);
            this.txbLocalidad.Name = "txbLocalidad";
            this.txbLocalidad.Size = new System.Drawing.Size(145, 20);
            this.txbLocalidad.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(248, 108);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 13);
            this.label15.TabIndex = 5;
            this.label15.Text = "CP";
            // 
            // txbNumero
            // 
            this.txbNumero.Location = new System.Drawing.Point(275, 51);
            this.txbNumero.Name = "txbNumero";
            this.txbNumero.Size = new System.Drawing.Size(59, 20);
            this.txbNumero.TabIndex = 3;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cmbDireccion);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Location = new System.Drawing.Point(11, 24);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(351, 61);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Buscar Propiedad";
            // 
            // cmbDireccion
            // 
            this.cmbDireccion.FormattingEnabled = true;
            this.cmbDireccion.Location = new System.Drawing.Point(64, 24);
            this.cmbDireccion.Name = "cmbDireccion";
            this.cmbDireccion.Size = new System.Drawing.Size(155, 21);
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
            // frmReservaAlquiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(723, 399);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmReservaAlquiler";
            this.Text = "frmReservaAlquiler";
            this.Load += new System.EventHandler(this.frmReservaAlquiler_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.gbxDetallePropiedad.ResumeLayout(false);
            this.gbxDetallePropiedad.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbNombreReservante;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbGarantia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbApellidoReservante;
        private System.Windows.Forms.TextBox txbOferta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cmbDireccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbxDetallePropiedad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTipoPropiedad;
        private System.Windows.Forms.TextBox txbCalle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbDepto;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbPiso;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txbCodigoPostal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txbLocalidad;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txbNumero;
    }
}