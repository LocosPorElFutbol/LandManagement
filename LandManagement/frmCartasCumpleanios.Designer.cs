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
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txbCantidadClientes = new System.Windows.Forms.TextBox();
			this.btnGuardarCarta = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txbCuerpoCarta = new System.Windows.Forms.TextBox();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnImprimirCartas = new System.Windows.Forms.Button();
			this.btnImprimirEtiquetas = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.pba_Buscando = new System.Windows.Forms.ProgressBar();
			this.dtpFechaCumpleaniosHasta = new LandManagement.Utilidades.PangeaDateTimePicker();
			this.dtpFechaCumpleaniosDesde = new LandManagement.Utilidades.PangeaDateTimePicker();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
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
			this.panel1.Size = new System.Drawing.Size(429, 400);
			this.panel1.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.btnGuardarCarta);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Controls.Add(this.btnCancelar);
			this.groupBox1.Controls.Add(this.btnImprimirCartas);
			this.groupBox1.Controls.Add(this.btnImprimirEtiquetas);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(423, 394);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Cumpleaños de clientes";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.pba_Buscando);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.dtpFechaCumpleaniosHasta);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.dtpFechaCumpleaniosDesde);
			this.groupBox3.Controls.Add(this.btnBuscar);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.txbCantidadClientes);
			this.groupBox3.Location = new System.Drawing.Point(10, 21);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(405, 97);
			this.groupBox3.TabIndex = 13;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Fecha cumpleaños";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(155, 28);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Hasta";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(17, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Desde";
			// 
			// btnBuscar
			// 
			this.btnBuscar.Location = new System.Drawing.Point(304, 22);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(93, 23);
			this.btnBuscar.TabIndex = 2;
			this.btnBuscar.Text = "Buscar";
			this.btnBuscar.UseVisualStyleBackColor = true;
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(150, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Cantidad clientes encontrados";
			// 
			// txbCantidadClientes
			// 
			this.txbCantidadClientes.Location = new System.Drawing.Point(173, 63);
			this.txbCantidadClientes.Name = "txbCantidadClientes";
			this.txbCantidadClientes.Size = new System.Drawing.Size(34, 20);
			this.txbCantidadClientes.TabIndex = 4;
			// 
			// btnGuardarCarta
			// 
			this.btnGuardarCarta.Location = new System.Drawing.Point(316, 301);
			this.btnGuardarCarta.Name = "btnGuardarCarta";
			this.btnGuardarCarta.Size = new System.Drawing.Size(93, 23);
			this.btnGuardarCarta.TabIndex = 12;
			this.btnGuardarCarta.Text = "Guardar carta";
			this.btnGuardarCarta.UseVisualStyleBackColor = true;
			this.btnGuardarCarta.Click += new System.EventHandler(this.btnGuardarCarta_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txbCuerpoCarta);
			this.groupBox2.Location = new System.Drawing.Point(10, 125);
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
			this.btnCancelar.Location = new System.Drawing.Point(284, 353);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(125, 23);
			this.btnCancelar.TabIndex = 7;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnImprimirCartas
			// 
			this.btnImprimirCartas.Location = new System.Drawing.Point(149, 353);
			this.btnImprimirCartas.Name = "btnImprimirCartas";
			this.btnImprimirCartas.Size = new System.Drawing.Size(125, 23);
			this.btnImprimirCartas.TabIndex = 6;
			this.btnImprimirCartas.Text = "Imprimir cartas";
			this.btnImprimirCartas.UseVisualStyleBackColor = true;
			this.btnImprimirCartas.Click += new System.EventHandler(this.btnImprimirCartas_Click);
			// 
			// btnImprimirEtiquetas
			// 
			this.btnImprimirEtiquetas.Location = new System.Drawing.Point(10, 353);
			this.btnImprimirEtiquetas.Name = "btnImprimirEtiquetas";
			this.btnImprimirEtiquetas.Size = new System.Drawing.Size(125, 23);
			this.btnImprimirEtiquetas.TabIndex = 5;
			this.btnImprimirEtiquetas.Text = "Imprimir etiquetas";
			this.btnImprimirEtiquetas.UseVisualStyleBackColor = true;
			this.btnImprimirEtiquetas.Click += new System.EventHandler(this.btnImprimirEtiquetas_Click);
			// 
			// pba_Buscando
			// 
			this.pba_Buscando.Location = new System.Drawing.Point(20, 50);
			this.pba_Buscando.Name = "pba_Buscando";
			this.pba_Buscando.Size = new System.Drawing.Size(377, 10);
			this.pba_Buscando.TabIndex = 5;
			this.pba_Buscando.Visible = false;
			// 
			// dtpFechaCumpleaniosHasta
			// 
			this.dtpFechaCumpleaniosHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaCumpleaniosHasta.Location = new System.Drawing.Point(196, 24);
			this.dtpFechaCumpleaniosHasta.Name = "dtpFechaCumpleaniosHasta";
			this.dtpFechaCumpleaniosHasta.Size = new System.Drawing.Size(86, 20);
			this.dtpFechaCumpleaniosHasta.TabIndex = 2;
			this.dtpFechaCumpleaniosHasta.ValueChanged += new System.EventHandler(this.dtpFechaCumpleaniosHasta_ValueChanged);
			// 
			// dtpFechaCumpleaniosDesde
			// 
			this.dtpFechaCumpleaniosDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaCumpleaniosDesde.Location = new System.Drawing.Point(61, 24);
			this.dtpFechaCumpleaniosDesde.Name = "dtpFechaCumpleaniosDesde";
			this.dtpFechaCumpleaniosDesde.Size = new System.Drawing.Size(86, 20);
			this.dtpFechaCumpleaniosDesde.TabIndex = 1;
			this.dtpFechaCumpleaniosDesde.ValueChanged += new System.EventHandler(this.dtpFechaCumpleaniosDesde_ValueChanged);
			// 
			// frmCartasCumpleanios
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(453, 424);
			this.Controls.Add(this.panel1);
			this.Name = "frmCartasCumpleanios";
			this.Text = "frmCartasCumpleanios";
			this.Load += new System.EventHandler(this.frmCartasCumpleanios_Load);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
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
        private LandManagement.Utilidades.PangeaDateTimePicker dtpFechaCumpleaniosDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImprimirCartas;
        private System.Windows.Forms.Button btnImprimirEtiquetas;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txbCuerpoCarta;
        private System.Windows.Forms.Button btnGuardarCarta;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private LandManagement.Utilidades.PangeaDateTimePicker dtpFechaCumpleaniosHasta;
		private System.Windows.Forms.ProgressBar pba_Buscando;
	}
}