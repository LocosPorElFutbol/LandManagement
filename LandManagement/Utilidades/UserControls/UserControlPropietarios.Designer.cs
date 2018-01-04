namespace LandManagement.Utilidades.UserControls
{
    partial class UserControlPropietarios
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbxPropietarios = new System.Windows.Forms.GroupBox();
            this.btnRemovePropietario = new System.Windows.Forms.Button();
            this.btnAgregarPropietario = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbPropietario = new System.Windows.Forms.ComboBox();
            this.dgvPropietarios = new System.Windows.Forms.DataGridView();
            this.gbxPropietarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropietarios)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxPropietarios
            // 
            this.gbxPropietarios.Controls.Add(this.btnRemovePropietario);
            this.gbxPropietarios.Controls.Add(this.btnAgregarPropietario);
            this.gbxPropietarios.Controls.Add(this.label16);
            this.gbxPropietarios.Controls.Add(this.cmbPropietario);
            this.gbxPropietarios.Controls.Add(this.dgvPropietarios);
            this.gbxPropietarios.Location = new System.Drawing.Point(3, 3);
            this.gbxPropietarios.Name = "gbxPropietarios";
            this.gbxPropietarios.Size = new System.Drawing.Size(368, 196);
            this.gbxPropietarios.TabIndex = 9;
            this.gbxPropietarios.TabStop = false;
            this.gbxPropietarios.Text = "Propietarios";
            // 
            // btnRemovePropietario
            // 
            this.btnRemovePropietario.Location = new System.Drawing.Point(335, 49);
            this.btnRemovePropietario.Name = "btnRemovePropietario";
            this.btnRemovePropietario.Size = new System.Drawing.Size(27, 23);
            this.btnRemovePropietario.TabIndex = 21;
            this.btnRemovePropietario.Text = "-";
            this.btnRemovePropietario.UseVisualStyleBackColor = true;
            this.btnRemovePropietario.Click += new System.EventHandler(this.btnRemovePropietario_Click);
            // 
            // btnAgregarPropietario
            // 
            this.btnAgregarPropietario.Location = new System.Drawing.Point(289, 19);
            this.btnAgregarPropietario.Name = "btnAgregarPropietario";
            this.btnAgregarPropietario.Size = new System.Drawing.Size(56, 23);
            this.btnAgregarPropietario.TabIndex = 20;
            this.btnAgregarPropietario.Text = "Agregar";
            this.btnAgregarPropietario.UseVisualStyleBackColor = true;
            this.btnAgregarPropietario.Click += new System.EventHandler(this.btnAgregarPropietario_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 13);
            this.label16.TabIndex = 19;
            this.label16.Text = "Propietario";
            // 
            // cmbPropietario
            // 
            this.cmbPropietario.FormattingEnabled = true;
            this.cmbPropietario.Location = new System.Drawing.Point(74, 20);
            this.cmbPropietario.Name = "cmbPropietario";
            this.cmbPropietario.Size = new System.Drawing.Size(206, 21);
            this.cmbPropietario.TabIndex = 18;
            // 
            // dgvPropietarios
            // 
            this.dgvPropietarios.AllowUserToAddRows = false;
            this.dgvPropietarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPropietarios.Location = new System.Drawing.Point(6, 49);
            this.dgvPropietarios.MultiSelect = false;
            this.dgvPropietarios.Name = "dgvPropietarios";
            this.dgvPropietarios.ReadOnly = true;
            this.dgvPropietarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPropietarios.Size = new System.Drawing.Size(324, 138);
            this.dgvPropietarios.TabIndex = 17;
            // 
            // ucPropietarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxPropietarios);
            this.Name = "ucPropietarios";
            this.Size = new System.Drawing.Size(377, 203);
            this.Load += new System.EventHandler(this.ucPropietarios_Load);
            this.gbxPropietarios.ResumeLayout(false);
            this.gbxPropietarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropietarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxPropietarios;
        private System.Windows.Forms.Button btnRemovePropietario;
        private System.Windows.Forms.Button btnAgregarPropietario;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbPropietario;
        private System.Windows.Forms.DataGridView dgvPropietarios;
    }
}
