namespace LandManagement
{
    partial class frmMenuABM
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
            this.rdbEsHijo = new System.Windows.Forms.RadioButton();
            this.rdbEsPadre = new System.Windows.Forms.RadioButton();
            this.rdbEsCabecera = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbPadres = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txbNombreFormulario = new System.Windows.Forms.TextBox();
            this.txbNombre = new System.Windows.Forms.TextBox();
            this.chbEstado = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rdbEsHijo);
            this.groupBox1.Controls.Add(this.rdbEsPadre);
            this.groupBox1.Controls.Add(this.rdbEsCabecera);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.cmbPadres);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txbNombreFormulario);
            this.groupBox1.Controls.Add(this.txbNombre);
            this.groupBox1.Controls.Add(this.chbEstado);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 318);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modificación de Menú";
            // 
            // rdbEsHijo
            // 
            this.rdbEsHijo.AutoSize = true;
            this.rdbEsHijo.Location = new System.Drawing.Point(109, 190);
            this.rdbEsHijo.Name = "rdbEsHijo";
            this.rdbEsHijo.Size = new System.Drawing.Size(61, 17);
            this.rdbEsHijo.TabIndex = 6;
            this.rdbEsHijo.Text = "Es Hijo.";
            this.rdbEsHijo.UseVisualStyleBackColor = true;
            this.rdbEsHijo.CheckedChanged += new System.EventHandler(this.rdbEsHijo_CheckedChanged);
            // 
            // rdbEsPadre
            // 
            this.rdbEsPadre.AutoSize = true;
            this.rdbEsPadre.Location = new System.Drawing.Point(109, 164);
            this.rdbEsPadre.Name = "rdbEsPadre";
            this.rdbEsPadre.Size = new System.Drawing.Size(71, 17);
            this.rdbEsPadre.TabIndex = 5;
            this.rdbEsPadre.Text = "Es Padre.";
            this.rdbEsPadre.UseVisualStyleBackColor = true;
            this.rdbEsPadre.CheckedChanged += new System.EventHandler(this.rdbEsPadre_CheckedChanged);
            // 
            // rdbEsCabecera
            // 
            this.rdbEsCabecera.AutoSize = true;
            this.rdbEsCabecera.Checked = true;
            this.rdbEsCabecera.Location = new System.Drawing.Point(109, 138);
            this.rdbEsCabecera.Name = "rdbEsCabecera";
            this.rdbEsCabecera.Size = new System.Drawing.Size(89, 17);
            this.rdbEsCabecera.TabIndex = 4;
            this.rdbEsCabecera.TabStop = true;
            this.rdbEsCabecera.Text = "Es Cabecera.";
            this.rdbEsCabecera.UseVisualStyleBackColor = true;
            this.rdbEsCabecera.CheckedChanged += new System.EventHandler(this.rdbEsCabecera_CheckedChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(209, 280);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCanelar_Click);
            // 
            // cmbPadres
            // 
            this.cmbPadres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPadres.Enabled = false;
            this.cmbPadres.FormattingEnabled = true;
            this.cmbPadres.Location = new System.Drawing.Point(109, 221);
            this.cmbPadres.Name = "cmbPadres";
            this.cmbPadres.Size = new System.Drawing.Size(175, 21);
            this.cmbPadres.TabIndex = 7;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(120, 280);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Padre: ";
            // 
            // txbNombreFormulario
            // 
            this.txbNombreFormulario.Enabled = false;
            this.txbNombreFormulario.Location = new System.Drawing.Point(109, 71);
            this.txbNombreFormulario.Name = "txbNombreFormulario";
            this.txbNombreFormulario.Size = new System.Drawing.Size(175, 20);
            this.txbNombreFormulario.TabIndex = 2;
            // 
            // txbNombre
            // 
            this.txbNombre.Location = new System.Drawing.Point(109, 36);
            this.txbNombre.Name = "txbNombre";
            this.txbNombre.Size = new System.Drawing.Size(175, 20);
            this.txbNombre.TabIndex = 1;
            this.txbNombre.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingControl);
            // 
            // chbEstado
            // 
            this.chbEstado.AutoSize = true;
            this.chbEstado.Checked = true;
            this.chbEstado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbEstado.Location = new System.Drawing.Point(109, 107);
            this.chbEstado.Name = "chbEstado";
            this.chbEstado.Size = new System.Drawing.Size(59, 17);
            this.chbEstado.TabIndex = 3;
            this.chbEstado.Text = "Estado";
            this.chbEstado.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre formulario: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre: ";
            // 
            // frmMenuABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.CancelButton = this.btnCancelar;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(341, 342);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMenuABM";
            this.Text = "frmMenuModificacion";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cmbPadres;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbNombreFormulario;
        private System.Windows.Forms.TextBox txbNombre;
        private System.Windows.Forms.CheckBox chbEstado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbEsHijo;
        private System.Windows.Forms.RadioButton rdbEsPadre;
        private System.Windows.Forms.RadioButton rdbEsCabecera;
    }
}