namespace LandManagement
{
    partial class frmPropiedadABM
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
            this.pnlControles = new System.Windows.Forms.Panel();
            this.gbxDireccion = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbCalle = new System.Windows.Forms.TextBox();
            this.cmbTipoPropiedad = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txbCaracteristicas = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txbCodigoPostal = new System.Windows.Forms.TextBox();
            this.txbNumero = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txbLocalidad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPiso = new System.Windows.Forms.ComboBox();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvOperacionesPropiedad = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvPropietarios = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.pnlControles.SuspendLayout();
            this.gbxDireccion.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperacionesPropiedad)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropietarios)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.pnlControles);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1086, 507);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información de la Propiedad";
            // 
            // pnlControles
            // 
            this.pnlControles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlControles.Controls.Add(this.gbxDireccion);
            this.pnlControles.Controls.Add(this.groupBox5);
            this.pnlControles.Controls.Add(this.groupBox2);
            this.pnlControles.Controls.Add(this.btnGuardar);
            this.pnlControles.Controls.Add(this.btnCancelar);
            this.pnlControles.Location = new System.Drawing.Point(6, 19);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Size = new System.Drawing.Size(1074, 482);
            this.pnlControles.TabIndex = 41;
            // 
            // gbxDireccion
            // 
            this.gbxDireccion.Controls.Add(this.label2);
            this.gbxDireccion.Controls.Add(this.txbCalle);
            this.gbxDireccion.Controls.Add(this.cmbTipoPropiedad);
            this.gbxDireccion.Controls.Add(this.label3);
            this.gbxDireccion.Controls.Add(this.groupBox4);
            this.gbxDireccion.Controls.Add(this.label7);
            this.gbxDireccion.Controls.Add(this.label5);
            this.gbxDireccion.Controls.Add(this.txbCodigoPostal);
            this.gbxDireccion.Controls.Add(this.txbNumero);
            this.gbxDireccion.Controls.Add(this.label9);
            this.gbxDireccion.Controls.Add(this.txbLocalidad);
            this.gbxDireccion.Controls.Add(this.label6);
            this.gbxDireccion.Controls.Add(this.label4);
            this.gbxDireccion.Controls.Add(this.cmbPiso);
            this.gbxDireccion.Controls.Add(this.cmbDepartamento);
            this.gbxDireccion.Location = new System.Drawing.Point(3, 3);
            this.gbxDireccion.Name = "gbxDireccion";
            this.gbxDireccion.Size = new System.Drawing.Size(402, 250);
            this.gbxDireccion.TabIndex = 28;
            this.gbxDireccion.TabStop = false;
            this.gbxDireccion.Text = "Dirección";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Calle";
            // 
            // txbCalle
            // 
            this.txbCalle.Location = new System.Drawing.Point(65, 47);
            this.txbCalle.Name = "txbCalle";
            this.txbCalle.Size = new System.Drawing.Size(192, 20);
            this.txbCalle.TabIndex = 2;
            this.txbCalle.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingControl);
            // 
            // cmbTipoPropiedad
            // 
            this.cmbTipoPropiedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPropiedad.FormattingEnabled = true;
            this.cmbTipoPropiedad.Location = new System.Drawing.Point(65, 19);
            this.cmbTipoPropiedad.Name = "cmbTipoPropiedad";
            this.cmbTipoPropiedad.Size = new System.Drawing.Size(192, 21);
            this.cmbTipoPropiedad.TabIndex = 8;
            this.cmbTipoPropiedad.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingControl);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Numero";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txbCaracteristicas);
            this.groupBox4.Location = new System.Drawing.Point(9, 125);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(387, 115);
            this.groupBox4.TabIndex = 38;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Caracteristicas de la propiedad";
            // 
            // txbCaracteristicas
            // 
            this.txbCaracteristicas.Location = new System.Drawing.Point(6, 19);
            this.txbCaracteristicas.Multiline = true;
            this.txbCaracteristicas.Name = "txbCaracteristicas";
            this.txbCaracteristicas.Size = new System.Drawing.Size(368, 85);
            this.txbCaracteristicas.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Tipo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(284, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Depto";
            // 
            // txbCodigoPostal
            // 
            this.txbCodigoPostal.Location = new System.Drawing.Point(326, 100);
            this.txbCodigoPostal.Name = "txbCodigoPostal";
            this.txbCodigoPostal.Size = new System.Drawing.Size(57, 20);
            this.txbCodigoPostal.TabIndex = 7;
            this.txbCodigoPostal.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingControl);
            // 
            // txbNumero
            // 
            this.txbNumero.Location = new System.Drawing.Point(326, 47);
            this.txbNumero.Name = "txbNumero";
            this.txbNumero.Size = new System.Drawing.Size(57, 20);
            this.txbNumero.TabIndex = 3;
            this.txbNumero.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingControl);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(299, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "CP";
            // 
            // txbLocalidad
            // 
            this.txbLocalidad.Location = new System.Drawing.Point(65, 100);
            this.txbLocalidad.Name = "txbLocalidad";
            this.txbLocalidad.Size = new System.Drawing.Size(192, 20);
            this.txbLocalidad.TabIndex = 6;
            this.txbLocalidad.Text = "CABA";
            this.txbLocalidad.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingControl);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Localidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Piso";
            // 
            // cmbPiso
            // 
            this.cmbPiso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPiso.FormattingEnabled = true;
            this.cmbPiso.Location = new System.Drawing.Point(65, 73);
            this.cmbPiso.Name = "cmbPiso";
            this.cmbPiso.Size = new System.Drawing.Size(44, 21);
            this.cmbPiso.TabIndex = 4;
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Location = new System.Drawing.Point(327, 73);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(56, 21);
            this.cmbDepartamento.TabIndex = 5;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgvOperacionesPropiedad);
            this.groupBox5.Location = new System.Drawing.Point(411, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(660, 447);
            this.groupBox5.TabIndex = 39;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Operaciones de la Propiedad";
            // 
            // dgvOperacionesPropiedad
            // 
            this.dgvOperacionesPropiedad.AllowUserToAddRows = false;
            this.dgvOperacionesPropiedad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperacionesPropiedad.Location = new System.Drawing.Point(6, 23);
            this.dgvOperacionesPropiedad.MultiSelect = false;
            this.dgvOperacionesPropiedad.Name = "dgvOperacionesPropiedad";
            this.dgvOperacionesPropiedad.ReadOnly = true;
            this.dgvOperacionesPropiedad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOperacionesPropiedad.Size = new System.Drawing.Size(648, 418);
            this.dgvOperacionesPropiedad.TabIndex = 10;
            this.dgvOperacionesPropiedad.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOperacionesPropiedad_CellDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvPropietarios);
            this.groupBox2.Location = new System.Drawing.Point(3, 259);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(402, 191);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Propietarios";
            // 
            // dgvPropietarios
            // 
            this.dgvPropietarios.AllowUserToAddRows = false;
            this.dgvPropietarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPropietarios.Location = new System.Drawing.Point(6, 19);
            this.dgvPropietarios.MultiSelect = false;
            this.dgvPropietarios.Name = "dgvPropietarios";
            this.dgvPropietarios.ReadOnly = true;
            this.dgvPropietarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPropietarios.Size = new System.Drawing.Size(377, 166);
            this.dgvPropietarios.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(909, 456);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(990, 456);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmPropiedadABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(1110, 531);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPropiedadABM";
            this.Text = "frmPropiedadABM";
            this.Load += new System.EventHandler(this.frmPropiedadABM_Load);
            this.groupBox1.ResumeLayout(false);
            this.pnlControles.ResumeLayout(false);
            this.gbxDireccion.ResumeLayout(false);
            this.gbxDireccion.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperacionesPropiedad)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropietarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvOperacionesPropiedad;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txbCaracteristicas;
        private System.Windows.Forms.GroupBox gbxDireccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbCalle;
        private System.Windows.Forms.ComboBox cmbTipoPropiedad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbCodigoPostal;
        private System.Windows.Forms.TextBox txbNumero;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txbLocalidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPiso;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvPropietarios;
        private System.Windows.Forms.Panel pnlControles;
    }
}