namespace LandManagement
{
    partial class frmCartasCumpleanios
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txbCuerpoCarta = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnImprimirCartas = new System.Windows.Forms.Button();
            this.btnImprimirEtiquetas = new System.Windows.Forms.Button();
            this.txbCantidadClientes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dtpFechaCumpleanios = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnGuardarCarta = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 321);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnGuardarCarta);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnImprimirCartas);
            this.groupBox1.Controls.Add(this.btnImprimirEtiquetas);
            this.groupBox1.Controls.Add(this.txbCantidadClientes);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.dtpFechaCumpleanios);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 315);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cumpleaños de clientes";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txbCuerpoCarta);
            this.groupBox2.Location = new System.Drawing.Point(10, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(405, 170);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Carta";
            // 
            // txbCuerpoCarta
            // 
            this.txbCuerpoCarta.AcceptsTab = true;
            this.txbCuerpoCarta.Location = new System.Drawing.Point(7, 19);
            this.txbCuerpoCarta.Multiline = true;
            this.txbCuerpoCarta.Name = "txbCuerpoCarta";
            this.txbCuerpoCarta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbCuerpoCarta.Size = new System.Drawing.Size(392, 145);
            this.txbCuerpoCarta.TabIndex = 10;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(284, 284);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(125, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnImprimirCartas
            // 
            this.btnImprimirCartas.Location = new System.Drawing.Point(149, 284);
            this.btnImprimirCartas.Name = "btnImprimirCartas";
            this.btnImprimirCartas.Size = new System.Drawing.Size(125, 23);
            this.btnImprimirCartas.TabIndex = 6;
            this.btnImprimirCartas.Text = "Imprimir cartas";
            this.btnImprimirCartas.UseVisualStyleBackColor = true;
            this.btnImprimirCartas.Click += new System.EventHandler(this.btnImprimirCartas_Click);
            // 
            // btnImprimirEtiquetas
            // 
            this.btnImprimirEtiquetas.Location = new System.Drawing.Point(10, 284);
            this.btnImprimirEtiquetas.Name = "btnImprimirEtiquetas";
            this.btnImprimirEtiquetas.Size = new System.Drawing.Size(125, 23);
            this.btnImprimirEtiquetas.TabIndex = 5;
            this.btnImprimirEtiquetas.Text = "Imprimir etiquetas";
            this.btnImprimirEtiquetas.UseVisualStyleBackColor = true;
            this.btnImprimirEtiquetas.Click += new System.EventHandler(this.btnImprimirEtiquetas_Click);
            // 
            // txbCantidadClientes
            // 
            this.txbCantidadClientes.Location = new System.Drawing.Point(316, 22);
            this.txbCantidadClientes.Name = "txbCantidadClientes";
            this.txbCantidadClientes.Size = new System.Drawing.Size(34, 20);
            this.txbCantidadClientes.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cantidad clientes";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(359, 20);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(50, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dtpFechaCumpleanios
            // 
            this.dtpFechaCumpleanios.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCumpleanios.Location = new System.Drawing.Point(126, 23);
            this.dtpFechaCumpleanios.Name = "dtpFechaCumpleanios";
            this.dtpFechaCumpleanios.Size = new System.Drawing.Size(86, 20);
            this.dtpFechaCumpleanios.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha de cumpleaños";
            // 
            // btnGuardarCarta
            // 
            this.btnGuardarCarta.Location = new System.Drawing.Point(316, 232);
            this.btnGuardarCarta.Name = "btnGuardarCarta";
            this.btnGuardarCarta.Size = new System.Drawing.Size(93, 23);
            this.btnGuardarCarta.TabIndex = 12;
            this.btnGuardarCarta.Text = "Guardar carta";
            this.btnGuardarCarta.UseVisualStyleBackColor = true;
            this.btnGuardarCarta.Click += new System.EventHandler(this.btnGuardarCarta_Click);
            // 
            // frmCartasCumpleanios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 345);
            this.Controls.Add(this.panel1);
            this.Name = "frmCartasCumpleanios";
            this.Text = "frmCartasCumpleanios";
            this.Load += new System.EventHandler(this.frmCartasCumpleanios_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txbCantidadClientes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker dtpFechaCumpleanios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImprimirCartas;
        private System.Windows.Forms.Button btnImprimirEtiquetas;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txbCuerpoCarta;
        private System.Windows.Forms.Button btnGuardarCarta;
    }
}