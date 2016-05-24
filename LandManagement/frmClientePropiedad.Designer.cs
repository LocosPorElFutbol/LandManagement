namespace LandManagement
{
    partial class frmClientePropiedad
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbxDatosPropiedad = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbCalle = new System.Windows.Forms.TextBox();
            this.cmbTipoPropiedad = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txbCodigoPostal = new System.Windows.Forms.TextBox();
            this.txbNumero = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txbLocalidad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPiso = new System.Windows.Forms.ComboBox();
            this.cmbDepto = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txbCaracteristicas = new System.Windows.Forms.TextBox();
            this.gbxEstadoPropiedad = new System.Windows.Forms.GroupBox();
            this.cmbDireccion = new System.Windows.Forms.ComboBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.rdbExistente = new System.Windows.Forms.RadioButton();
            this.rdbPropiedadNueva = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gbxDatosPropiedad.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbxEstadoPropiedad.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.gbxDatosPropiedad);
            this.groupBox1.Controls.Add(this.gbxEstadoPropiedad);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 514);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Asignación de una Propiedad";
            // 
            // gbxDatosPropiedad
            // 
            this.gbxDatosPropiedad.Controls.Add(this.groupBox3);
            this.gbxDatosPropiedad.Controls.Add(this.groupBox4);
            this.gbxDatosPropiedad.Location = new System.Drawing.Point(6, 140);
            this.gbxDatosPropiedad.Name = "gbxDatosPropiedad";
            this.gbxDatosPropiedad.Size = new System.Drawing.Size(407, 329);
            this.gbxDatosPropiedad.TabIndex = 44;
            this.gbxDatosPropiedad.TabStop = false;
            this.gbxDatosPropiedad.Text = "Datos Propiedad";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txbCalle);
            this.groupBox3.Controls.Add(this.cmbTipoPropiedad);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txbCodigoPostal);
            this.groupBox3.Controls.Add(this.txbNumero);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txbLocalidad);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cmbPiso);
            this.groupBox3.Controls.Add(this.cmbDepto);
            this.groupBox3.Location = new System.Drawing.Point(6, 24);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(390, 142);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dirección";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Tipo Propiedad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Calle";
            // 
            // txbCalle
            // 
            this.txbCalle.Location = new System.Drawing.Point(65, 57);
            this.txbCalle.Name = "txbCalle";
            this.txbCalle.Size = new System.Drawing.Size(192, 20);
            this.txbCalle.TabIndex = 5;
            this.txbCalle.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingControl);
            // 
            // cmbTipoPropiedad
            // 
            this.cmbTipoPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPropiedad.FormattingEnabled = true;
            this.cmbTipoPropiedad.Location = new System.Drawing.Point(91, 24);
            this.cmbTipoPropiedad.Name = "cmbTipoPropiedad";
            this.cmbTipoPropiedad.Size = new System.Drawing.Size(166, 21);
            this.cmbTipoPropiedad.TabIndex = 4;
            this.cmbTipoPropiedad.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingControl);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Numero";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(276, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Depto";
            // 
            // txbCodigoPostal
            // 
            this.txbCodigoPostal.Location = new System.Drawing.Point(318, 110);
            this.txbCodigoPostal.Name = "txbCodigoPostal";
            this.txbCodigoPostal.Size = new System.Drawing.Size(57, 20);
            this.txbCodigoPostal.TabIndex = 10;
            this.txbCodigoPostal.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingControl);
            // 
            // txbNumero
            // 
            this.txbNumero.Location = new System.Drawing.Point(318, 57);
            this.txbNumero.Name = "txbNumero";
            this.txbNumero.Size = new System.Drawing.Size(57, 20);
            this.txbNumero.TabIndex = 6;
            this.txbNumero.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingControl);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(291, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "CP";
            // 
            // txbLocalidad
            // 
            this.txbLocalidad.Location = new System.Drawing.Point(65, 110);
            this.txbLocalidad.Name = "txbLocalidad";
            this.txbLocalidad.Size = new System.Drawing.Size(192, 20);
            this.txbLocalidad.TabIndex = 9;
            this.txbLocalidad.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingControl);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Localidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Piso";
            // 
            // cmbPiso
            // 
            this.cmbPiso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPiso.FormattingEnabled = true;
            this.cmbPiso.Location = new System.Drawing.Point(65, 83);
            this.cmbPiso.Name = "cmbPiso";
            this.cmbPiso.Size = new System.Drawing.Size(44, 21);
            this.cmbPiso.TabIndex = 7;
            // 
            // cmbDepto
            // 
            this.cmbDepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepto.FormattingEnabled = true;
            this.cmbDepto.Location = new System.Drawing.Point(319, 83);
            this.cmbDepto.Name = "cmbDepto";
            this.cmbDepto.Size = new System.Drawing.Size(56, 21);
            this.cmbDepto.TabIndex = 8;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txbCaracteristicas);
            this.groupBox4.Location = new System.Drawing.Point(6, 177);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(390, 130);
            this.groupBox4.TabIndex = 42;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Caracteristicas de la propiedad";
            // 
            // txbCaracteristicas
            // 
            this.txbCaracteristicas.Location = new System.Drawing.Point(6, 19);
            this.txbCaracteristicas.Multiline = true;
            this.txbCaracteristicas.Name = "txbCaracteristicas";
            this.txbCaracteristicas.Size = new System.Drawing.Size(369, 105);
            this.txbCaracteristicas.TabIndex = 11;
            // 
            // gbxEstadoPropiedad
            // 
            this.gbxEstadoPropiedad.Controls.Add(this.cmbDireccion);
            this.gbxEstadoPropiedad.Controls.Add(this.lblDireccion);
            this.gbxEstadoPropiedad.Controls.Add(this.rdbExistente);
            this.gbxEstadoPropiedad.Controls.Add(this.rdbPropiedadNueva);
            this.gbxEstadoPropiedad.Location = new System.Drawing.Point(6, 24);
            this.gbxEstadoPropiedad.Name = "gbxEstadoPropiedad";
            this.gbxEstadoPropiedad.Size = new System.Drawing.Size(407, 110);
            this.gbxEstadoPropiedad.TabIndex = 43;
            this.gbxEstadoPropiedad.TabStop = false;
            this.gbxEstadoPropiedad.Text = "Estado de la Propiedad";
            // 
            // cmbDireccion
            // 
            this.cmbDireccion.FormattingEnabled = true;
            this.cmbDireccion.Location = new System.Drawing.Point(113, 72);
            this.cmbDireccion.Name = "cmbDireccion";
            this.cmbDireccion.Size = new System.Drawing.Size(144, 21);
            this.cmbDireccion.TabIndex = 3;
            this.cmbDireccion.SelectedIndexChanged += new System.EventHandler(this.cmbDireccion_SelectedIndexChanged);
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(55, 76);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 13);
            this.lblDireccion.TabIndex = 2;
            this.lblDireccion.Text = "Dirección";
            // 
            // rdbExistente
            // 
            this.rdbExistente.AutoSize = true;
            this.rdbExistente.Location = new System.Drawing.Point(32, 47);
            this.rdbExistente.Name = "rdbExistente";
            this.rdbExistente.Size = new System.Drawing.Size(119, 17);
            this.rdbExistente.TabIndex = 2;
            this.rdbExistente.TabStop = true;
            this.rdbExistente.Text = "Propiedad Existente";
            this.rdbExistente.UseVisualStyleBackColor = true;
            // 
            // rdbPropiedadNueva
            // 
            this.rdbPropiedadNueva.AutoSize = true;
            this.rdbPropiedadNueva.Checked = true;
            this.rdbPropiedadNueva.Location = new System.Drawing.Point(32, 24);
            this.rdbPropiedadNueva.Name = "rdbPropiedadNueva";
            this.rdbPropiedadNueva.Size = new System.Drawing.Size(108, 17);
            this.rdbPropiedadNueva.TabIndex = 1;
            this.rdbPropiedadNueva.TabStop = true;
            this.rdbPropiedadNueva.Text = "Propiedad Nueva";
            this.rdbPropiedadNueva.UseVisualStyleBackColor = true;
            this.rdbPropiedadNueva.CheckedChanged += new System.EventHandler(this.rdbPropiedadNueva_CheckedChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(338, 475);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(257, 475);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmClientePropiedad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(449, 538);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmClientePropiedad";
            this.Text = "frmClientePropiedad";
            this.Load += new System.EventHandler(this.frmClientePropiedad_Load);
            this.groupBox1.ResumeLayout(false);
            this.gbxDatosPropiedad.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gbxEstadoPropiedad.ResumeLayout(false);
            this.gbxEstadoPropiedad.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txbCaracteristicas;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbCalle;
        private System.Windows.Forms.ComboBox cmbTipoPropiedad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbCodigoPostal;
        private System.Windows.Forms.TextBox txbNumero;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txbLocalidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPiso;
        private System.Windows.Forms.ComboBox cmbDepto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbxEstadoPropiedad;
        private System.Windows.Forms.ComboBox cmbDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.RadioButton rdbExistente;
        private System.Windows.Forms.RadioButton rdbPropiedadNueva;
        private System.Windows.Forms.GroupBox gbxDatosPropiedad;
    }
}