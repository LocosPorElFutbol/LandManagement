namespace LandManagement
{
    partial class frmAlquilada
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
			this.btnGuardar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.dtpFecha = new LandManagement.Utilidades.PangeaDateTimePicker();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.btnQuitarLocatario = new System.Windows.Forms.Button();
			this.btnAgregarLocatario = new System.Windows.Forms.Button();
			this.dgvLocatarios = new System.Windows.Forms.DataGridView();
			this.cmbCliente = new System.Windows.Forms.ComboBox();
			this.label23 = new System.Windows.Forms.Label();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.btnQuitarGarante = new System.Windows.Forms.Button();
			this.btnAgregarGarante = new System.Windows.Forms.Button();
			this.dgvGarantes = new System.Windows.Forms.DataGridView();
			this.cmbGarante = new System.Windows.Forms.ComboBox();
			this.label24 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txbTercerAnio = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txbQuintoAnio = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.txbCuartoAnio = new System.Windows.Forms.TextBox();
			this.txbPrimerAnio = new System.Windows.Forms.TextBox();
			this.txbSegundoAnio = new System.Windows.Forms.TextBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.txbBancoNumeroCuenta = new System.Windows.Forms.TextBox();
			this.txbBanco = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.rdbPagoDeposito = new System.Windows.Forms.RadioButton();
			this.rdbPagoEfectivo = new System.Windows.Forms.RadioButton();
			this.cbxEnAdministracion = new System.Windows.Forms.CheckBox();
			this.cbxConIva = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.rdbServiciosCargoLocatario = new System.Windows.Forms.RadioButton();
			this.rdbServiciosCargoLocador = new System.Windows.Forms.RadioButton();
			this.dtpFechaDesocupacion = new LandManagement.Utilidades.PangeaDateTimePicker();
			this.dtpFechaFin = new LandManagement.Utilidades.PangeaDateTimePicker();
			this.dtpFechaInicio = new LandManagement.Utilidades.PangeaDateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.pnlControles.SuspendLayout();
			this.groupBox9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvLocatarios)).BeginInit();
			this.groupBox12.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvGarantes)).BeginInit();
			this.groupBox4.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox3.SuspendLayout();
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
			this.groupBox1.Size = new System.Drawing.Size(1223, 542);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Propiedad Alquilada";
			// 
			// pnlControles
			// 
			this.pnlControles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlControles.Controls.Add(this.btnGuardar);
			this.pnlControles.Controls.Add(this.btnCancelar);
			this.pnlControles.Controls.Add(this.dtpFecha);
			this.pnlControles.Controls.Add(this.groupBox9);
			this.pnlControles.Controls.Add(this.groupBox12);
			this.pnlControles.Controls.Add(this.groupBox4);
			this.pnlControles.Controls.Add(this.label2);
			this.pnlControles.Location = new System.Drawing.Point(6, 19);
			this.pnlControles.Name = "pnlControles";
			this.pnlControles.Size = new System.Drawing.Size(1211, 516);
			this.pnlControles.TabIndex = 34;
			// 
			// btnGuardar
			// 
			this.btnGuardar.Location = new System.Drawing.Point(1046, 485);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(75, 23);
			this.btnGuardar.TabIndex = 32;
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.Location = new System.Drawing.Point(1127, 485);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(75, 23);
			this.btnCancelar.TabIndex = 31;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// dtpFecha
			// 
			this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpFecha.Location = new System.Drawing.Point(50, 3);
			this.dtpFecha.Name = "dtpFecha";
			this.dtpFecha.Size = new System.Drawing.Size(83, 20);
			this.dtpFecha.TabIndex = 13;
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.btnQuitarLocatario);
			this.groupBox9.Controls.Add(this.btnAgregarLocatario);
			this.groupBox9.Controls.Add(this.dgvLocatarios);
			this.groupBox9.Controls.Add(this.cmbCliente);
			this.groupBox9.Controls.Add(this.label23);
			this.groupBox9.Location = new System.Drawing.Point(390, 56);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(447, 202);
			this.groupBox9.TabIndex = 29;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Locatario";
			// 
			// btnQuitarLocatario
			// 
			this.btnQuitarLocatario.Location = new System.Drawing.Point(413, 47);
			this.btnQuitarLocatario.Name = "btnQuitarLocatario";
			this.btnQuitarLocatario.Size = new System.Drawing.Size(28, 23);
			this.btnQuitarLocatario.TabIndex = 34;
			this.btnQuitarLocatario.Text = "-";
			this.btnQuitarLocatario.UseVisualStyleBackColor = true;
			this.btnQuitarLocatario.Click += new System.EventHandler(this.btnQuitarLocatario_Click);
			// 
			// btnAgregarLocatario
			// 
			this.btnAgregarLocatario.Location = new System.Drawing.Point(215, 19);
			this.btnAgregarLocatario.Name = "btnAgregarLocatario";
			this.btnAgregarLocatario.Size = new System.Drawing.Size(56, 21);
			this.btnAgregarLocatario.TabIndex = 2;
			this.btnAgregarLocatario.Text = "Agregar";
			this.btnAgregarLocatario.UseVisualStyleBackColor = true;
			this.btnAgregarLocatario.Click += new System.EventHandler(this.btnAgregarLocatario_Click);
			// 
			// dgvLocatarios
			// 
			this.dgvLocatarios.AllowUserToAddRows = false;
			this.dgvLocatarios.AllowUserToResizeRows = false;
			this.dgvLocatarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvLocatarios.Location = new System.Drawing.Point(9, 46);
			this.dgvLocatarios.MultiSelect = false;
			this.dgvLocatarios.Name = "dgvLocatarios";
			this.dgvLocatarios.ReadOnly = true;
			this.dgvLocatarios.RowHeadersVisible = false;
			this.dgvLocatarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvLocatarios.Size = new System.Drawing.Size(398, 150);
			this.dgvLocatarios.TabIndex = 33;
			// 
			// cmbCliente
			// 
			this.cmbCliente.FormattingEnabled = true;
			this.cmbCliente.Location = new System.Drawing.Point(55, 19);
			this.cmbCliente.Name = "cmbCliente";
			this.cmbCliente.Size = new System.Drawing.Size(154, 21);
			this.cmbCliente.TabIndex = 1;
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(6, 23);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(44, 13);
			this.label23.TabIndex = 0;
			this.label23.Text = "Nombre";
			// 
			// groupBox12
			// 
			this.groupBox12.Controls.Add(this.btnQuitarGarante);
			this.groupBox12.Controls.Add(this.btnAgregarGarante);
			this.groupBox12.Controls.Add(this.dgvGarantes);
			this.groupBox12.Controls.Add(this.cmbGarante);
			this.groupBox12.Controls.Add(this.label24);
			this.groupBox12.Location = new System.Drawing.Point(390, 269);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(447, 210);
			this.groupBox12.TabIndex = 30;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "Garante";
			// 
			// btnQuitarGarante
			// 
			this.btnQuitarGarante.Location = new System.Drawing.Point(410, 45);
			this.btnQuitarGarante.Name = "btnQuitarGarante";
			this.btnQuitarGarante.Size = new System.Drawing.Size(28, 23);
			this.btnQuitarGarante.TabIndex = 34;
			this.btnQuitarGarante.Text = "-";
			this.btnQuitarGarante.UseVisualStyleBackColor = true;
			this.btnQuitarGarante.Click += new System.EventHandler(this.btnQuitarGarante_Click);
			// 
			// btnAgregarGarante
			// 
			this.btnAgregarGarante.Location = new System.Drawing.Point(215, 18);
			this.btnAgregarGarante.Name = "btnAgregarGarante";
			this.btnAgregarGarante.Size = new System.Drawing.Size(56, 21);
			this.btnAgregarGarante.TabIndex = 16;
			this.btnAgregarGarante.Text = "Agregar";
			this.btnAgregarGarante.UseVisualStyleBackColor = true;
			this.btnAgregarGarante.Click += new System.EventHandler(this.btnAgregarGarante_Click);
			// 
			// dgvGarantes
			// 
			this.dgvGarantes.AllowUserToAddRows = false;
			this.dgvGarantes.AllowUserToResizeRows = false;
			this.dgvGarantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvGarantes.Location = new System.Drawing.Point(6, 45);
			this.dgvGarantes.MultiSelect = false;
			this.dgvGarantes.Name = "dgvGarantes";
			this.dgvGarantes.ReadOnly = true;
			this.dgvGarantes.RowHeadersVisible = false;
			this.dgvGarantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvGarantes.Size = new System.Drawing.Size(398, 150);
			this.dgvGarantes.TabIndex = 33;
			// 
			// cmbGarante
			// 
			this.cmbGarante.FormattingEnabled = true;
			this.cmbGarante.Location = new System.Drawing.Point(55, 19);
			this.cmbGarante.Name = "cmbGarante";
			this.cmbGarante.Size = new System.Drawing.Size(154, 21);
			this.cmbGarante.TabIndex = 1;
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(6, 23);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(44, 13);
			this.label24.TabIndex = 0;
			this.label24.Text = "Nombre";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.groupBox7);
			this.groupBox4.Controls.Add(this.groupBox6);
			this.groupBox4.Controls.Add(this.groupBox3);
			this.groupBox4.Controls.Add(this.dtpFechaDesocupacion);
			this.groupBox4.Controls.Add(this.dtpFechaFin);
			this.groupBox4.Controls.Add(this.dtpFechaInicio);
			this.groupBox4.Controls.Add(this.label3);
			this.groupBox4.Controls.Add(this.label9);
			this.groupBox4.Controls.Add(this.label16);
			this.groupBox4.Location = new System.Drawing.Point(843, 56);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(359, 423);
			this.groupBox4.TabIndex = 27;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Detalle Alquiler";
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.label4);
			this.groupBox7.Controls.Add(this.txbTercerAnio);
			this.groupBox7.Controls.Add(this.label5);
			this.groupBox7.Controls.Add(this.label6);
			this.groupBox7.Controls.Add(this.txbQuintoAnio);
			this.groupBox7.Controls.Add(this.label7);
			this.groupBox7.Controls.Add(this.label8);
			this.groupBox7.Controls.Add(this.txbCuartoAnio);
			this.groupBox7.Controls.Add(this.txbPrimerAnio);
			this.groupBox7.Controls.Add(this.txbSegundoAnio);
			this.groupBox7.Location = new System.Drawing.Point(13, 78);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(335, 101);
			this.groupBox7.TabIndex = 28;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Valores";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(29, 23);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 13);
			this.label4.TabIndex = 24;
			this.label4.Text = "1° año";
			// 
			// txbTercerAnio
			// 
			this.txbTercerAnio.Location = new System.Drawing.Point(73, 72);
			this.txbTercerAnio.Name = "txbTercerAnio";
			this.txbTercerAnio.Size = new System.Drawing.Size(86, 20);
			this.txbTercerAnio.TabIndex = 31;
			this.txbTercerAnio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarDecimales);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(29, 51);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(38, 13);
			this.label5.TabIndex = 25;
			this.label5.Text = "2° año";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(29, 76);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(38, 13);
			this.label6.TabIndex = 26;
			this.label6.Text = "3° año";
			// 
			// txbQuintoAnio
			// 
			this.txbQuintoAnio.Location = new System.Drawing.Point(236, 44);
			this.txbQuintoAnio.Name = "txbQuintoAnio";
			this.txbQuintoAnio.Size = new System.Drawing.Size(85, 20);
			this.txbQuintoAnio.TabIndex = 33;
			this.txbQuintoAnio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarDecimales);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(192, 23);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(38, 13);
			this.label7.TabIndex = 27;
			this.label7.Text = "4° año";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(192, 49);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(38, 13);
			this.label8.TabIndex = 28;
			this.label8.Text = "5° año";
			// 
			// txbCuartoAnio
			// 
			this.txbCuartoAnio.Location = new System.Drawing.Point(236, 19);
			this.txbCuartoAnio.Name = "txbCuartoAnio";
			this.txbCuartoAnio.Size = new System.Drawing.Size(85, 20);
			this.txbCuartoAnio.TabIndex = 32;
			this.txbCuartoAnio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarDecimales);
			// 
			// txbPrimerAnio
			// 
			this.txbPrimerAnio.Location = new System.Drawing.Point(73, 20);
			this.txbPrimerAnio.Name = "txbPrimerAnio";
			this.txbPrimerAnio.Size = new System.Drawing.Size(85, 20);
			this.txbPrimerAnio.TabIndex = 29;
			this.txbPrimerAnio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarDecimales);
			// 
			// txbSegundoAnio
			// 
			this.txbSegundoAnio.Location = new System.Drawing.Point(73, 46);
			this.txbSegundoAnio.Name = "txbSegundoAnio";
			this.txbSegundoAnio.Size = new System.Drawing.Size(86, 20);
			this.txbSegundoAnio.TabIndex = 30;
			this.txbSegundoAnio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarDecimales);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.txbBancoNumeroCuenta);
			this.groupBox6.Controls.Add(this.txbBanco);
			this.groupBox6.Controls.Add(this.label17);
			this.groupBox6.Controls.Add(this.label18);
			this.groupBox6.Controls.Add(this.rdbPagoDeposito);
			this.groupBox6.Controls.Add(this.rdbPagoEfectivo);
			this.groupBox6.Controls.Add(this.cbxEnAdministracion);
			this.groupBox6.Controls.Add(this.cbxConIva);
			this.groupBox6.Location = new System.Drawing.Point(13, 247);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(335, 161);
			this.groupBox6.TabIndex = 33;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Forma de Pago";
			// 
			// txbBancoNumeroCuenta
			// 
			this.txbBancoNumeroCuenta.Location = new System.Drawing.Point(203, 104);
			this.txbBancoNumeroCuenta.Name = "txbBancoNumeroCuenta";
			this.txbBancoNumeroCuenta.Size = new System.Drawing.Size(119, 20);
			this.txbBancoNumeroCuenta.TabIndex = 44;
			this.txbBancoNumeroCuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidarEntero);
			// 
			// txbBanco
			// 
			this.txbBanco.Location = new System.Drawing.Point(74, 104);
			this.txbBanco.Name = "txbBanco";
			this.txbBanco.Size = new System.Drawing.Size(76, 20);
			this.txbBanco.TabIndex = 43;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(156, 107);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(41, 13);
			this.label17.TabIndex = 42;
			this.label17.Text = "Cuenta";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(30, 107);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(38, 13);
			this.label18.TabIndex = 41;
			this.label18.Text = "Banco";
			// 
			// rdbPagoDeposito
			// 
			this.rdbPagoDeposito.AutoSize = true;
			this.rdbPagoDeposito.Location = new System.Drawing.Point(17, 81);
			this.rdbPagoDeposito.Name = "rdbPagoDeposito";
			this.rdbPagoDeposito.Size = new System.Drawing.Size(96, 17);
			this.rdbPagoDeposito.TabIndex = 40;
			this.rdbPagoDeposito.TabStop = true;
			this.rdbPagoDeposito.Text = "Pago deposito.";
			this.rdbPagoDeposito.UseVisualStyleBackColor = true;
			// 
			// rdbPagoEfectivo
			// 
			this.rdbPagoEfectivo.AutoSize = true;
			this.rdbPagoEfectivo.Location = new System.Drawing.Point(17, 58);
			this.rdbPagoEfectivo.Name = "rdbPagoEfectivo";
			this.rdbPagoEfectivo.Size = new System.Drawing.Size(94, 17);
			this.rdbPagoEfectivo.TabIndex = 39;
			this.rdbPagoEfectivo.TabStop = true;
			this.rdbPagoEfectivo.Text = "Pago efectivo.";
			this.rdbPagoEfectivo.UseVisualStyleBackColor = true;
			this.rdbPagoEfectivo.CheckedChanged += new System.EventHandler(this.rdbPagoEfectivo_CheckedChanged);
			// 
			// cbxEnAdministracion
			// 
			this.cbxEnAdministracion.AutoSize = true;
			this.cbxEnAdministracion.Location = new System.Drawing.Point(17, 24);
			this.cbxEnAdministracion.Name = "cbxEnAdministracion";
			this.cbxEnAdministracion.Size = new System.Drawing.Size(112, 17);
			this.cbxEnAdministracion.TabIndex = 38;
			this.cbxEnAdministracion.Text = "En administración.";
			this.cbxEnAdministracion.UseVisualStyleBackColor = true;
			// 
			// cbxConIva
			// 
			this.cbxConIva.AutoSize = true;
			this.cbxConIva.Location = new System.Drawing.Point(145, 24);
			this.cbxConIva.Name = "cbxConIva";
			this.cbxConIva.Size = new System.Drawing.Size(119, 17);
			this.cbxConIva.TabIndex = 37;
			this.cbxConIva.Text = "Se factura con IVA.";
			this.cbxConIva.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.rdbServiciosCargoLocatario);
			this.groupBox3.Controls.Add(this.rdbServiciosCargoLocador);
			this.groupBox3.Location = new System.Drawing.Point(13, 185);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(335, 56);
			this.groupBox3.TabIndex = 32;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Servicios";
			// 
			// rdbServiciosCargoLocatario
			// 
			this.rdbServiciosCargoLocatario.AutoSize = true;
			this.rdbServiciosCargoLocatario.Location = new System.Drawing.Point(145, 24);
			this.rdbServiciosCargoLocatario.Name = "rdbServiciosCargoLocatario";
			this.rdbServiciosCargoLocatario.Size = new System.Drawing.Size(123, 17);
			this.rdbServiciosCargoLocatario.TabIndex = 29;
			this.rdbServiciosCargoLocatario.TabStop = true;
			this.rdbServiciosCargoLocatario.Text = "A Cargo del locatario";
			this.rdbServiciosCargoLocatario.UseVisualStyleBackColor = true;
			// 
			// rdbServiciosCargoLocador
			// 
			this.rdbServiciosCargoLocador.AutoSize = true;
			this.rdbServiciosCargoLocador.Location = new System.Drawing.Point(17, 24);
			this.rdbServiciosCargoLocador.Name = "rdbServiciosCargoLocador";
			this.rdbServiciosCargoLocador.Size = new System.Drawing.Size(122, 17);
			this.rdbServiciosCargoLocador.TabIndex = 28;
			this.rdbServiciosCargoLocador.TabStop = true;
			this.rdbServiciosCargoLocador.Text = "A Cargo del Locador";
			this.rdbServiciosCargoLocador.UseVisualStyleBackColor = true;
			// 
			// dtpFechaDesocupacion
			// 
			this.dtpFechaDesocupacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaDesocupacion.Location = new System.Drawing.Point(125, 47);
			this.dtpFechaDesocupacion.Name = "dtpFechaDesocupacion";
			this.dtpFechaDesocupacion.Size = new System.Drawing.Size(85, 20);
			this.dtpFechaDesocupacion.TabIndex = 31;
			// 
			// dtpFechaFin
			// 
			this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaFin.Location = new System.Drawing.Point(267, 18);
			this.dtpFechaFin.Name = "dtpFechaFin";
			this.dtpFechaFin.Size = new System.Drawing.Size(86, 20);
			this.dtpFechaFin.TabIndex = 30;
			// 
			// dtpFechaInicio
			// 
			this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaInicio.Location = new System.Drawing.Point(125, 18);
			this.dtpFechaInicio.Name = "dtpFechaInicio";
			this.dtpFechaInicio.Size = new System.Drawing.Size(85, 20);
			this.dtpFechaInicio.TabIndex = 29;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 52);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(118, 13);
			this.label3.TabIndex = 28;
			this.label3.Text = "Desocupación Efectiva";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(213, 23);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(51, 13);
			this.label9.TabIndex = 27;
			this.label9.Text = "Fecha fin";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(55, 24);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(64, 13);
			this.label16.TabIndex = 26;
			this.label16.Text = "Fecha inicio";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(37, 13);
			this.label2.TabIndex = 14;
			this.label2.Text = "Fecha";
			// 
			// frmAlquilada
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancelar;
			this.ClientSize = new System.Drawing.Size(1247, 566);
			this.Controls.Add(this.groupBox1);
			this.Name = "frmAlquilada";
			this.Text = "frmAlquilada";
			this.Load += new System.EventHandler(this.frmAlquilada_Load);
			this.groupBox1.ResumeLayout(false);
			this.pnlControles.ResumeLayout(false);
			this.pnlControles.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			this.groupBox9.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvLocatarios)).EndInit();
			this.groupBox12.ResumeLayout(false);
			this.groupBox12.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvGarantes)).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private LandManagement.Utilidades.PangeaDateTimePicker dtpFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private LandManagement.Utilidades.PangeaDateTimePicker dtpFechaDesocupacion;
        private LandManagement.Utilidades.PangeaDateTimePicker dtpFechaFin;
        private LandManagement.Utilidades.PangeaDateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbServiciosCargoLocatario;
        private System.Windows.Forms.RadioButton rdbServiciosCargoLocador;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txbBancoNumeroCuenta;
        private System.Windows.Forms.TextBox txbBanco;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.RadioButton rdbPagoDeposito;
        private System.Windows.Forms.RadioButton rdbPagoEfectivo;
        private System.Windows.Forms.CheckBox cbxEnAdministracion;
        private System.Windows.Forms.CheckBox cbxConIva;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbTercerAnio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbQuintoAnio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbCuartoAnio;
        private System.Windows.Forms.TextBox txbPrimerAnio;
        private System.Windows.Forms.TextBox txbSegundoAnio;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.ComboBox cmbGarante;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Panel pnlControles;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvLocatarios;
        private System.Windows.Forms.Button btnAgregarLocatario;
        private System.Windows.Forms.Button btnQuitarLocatario;
        private System.Windows.Forms.Button btnQuitarGarante;
        private System.Windows.Forms.DataGridView dgvGarantes;
        private System.Windows.Forms.Button btnAgregarGarante;
    }
}