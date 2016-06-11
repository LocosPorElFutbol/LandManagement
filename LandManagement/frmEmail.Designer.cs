namespace LandManagement
{
    partial class frmEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmail));
            this.btnimagen = new System.Windows.Forms.Button();
            this.HTMLEditor = new System.Windows.Forms.WebBrowser();
            this.txtasunto = new System.Windows.Forms.TextBox();
            this.txtmailto = new System.Windows.Forms.TextBox();
            this.btnadjuntar = new System.Windows.Forms.Button();
            this.btnenviar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btncancelar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtclientes = new System.Windows.Forms.TextBox();
            this.btnagregar = new System.Windows.Forms.Button();
            this.adjlabel = new System.Windows.Forms.Label();
            this.BoldtoolStrip = new System.Windows.Forms.ToolStripButton();
            this.UnderlinetoolStrip = new System.Windows.Forms.ToolStripButton();
            this.ItalictoolStrip = new System.Windows.Forms.ToolStripButton();
            this.ColortoolStrip = new System.Windows.Forms.ToolStripButton();
            this.JustifyFulltoolStrip = new System.Windows.Forms.ToolStripButton();
            this.JustifyCentertoolStrip = new System.Windows.Forms.ToolStripButton();
            this.JustifyLtoolStrip = new System.Windows.Forms.ToolStripButton();
            this.JustifyRtoolStrip = new System.Windows.Forms.ToolStripButton();
            this.VinDtoolStrip = new System.Windows.Forms.ToolStripButton();
            this.VinNtoolStrip = new System.Windows.Forms.ToolStripButton();
            this.IMGtoolStrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.arialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verdanaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currierNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timesNewRomanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnimagen
            // 
            this.btnimagen.Location = new System.Drawing.Point(202, 362);
            this.btnimagen.Name = "btnimagen";
            this.btnimagen.Size = new System.Drawing.Size(75, 23);
            this.btnimagen.TabIndex = 7;
            this.btnimagen.Text = "Imagen";
            this.btnimagen.UseVisualStyleBackColor = true;
            this.btnimagen.Click += new System.EventHandler(this.btnimagen_Click);
            // 
            // HTMLEditor
            // 
            this.HTMLEditor.AllowWebBrowserDrop = false;
            this.HTMLEditor.IsWebBrowserContextMenuEnabled = false;
            this.HTMLEditor.Location = new System.Drawing.Point(20, 126);
            this.HTMLEditor.MinimumSize = new System.Drawing.Size(20, 20);
            this.HTMLEditor.Name = "HTMLEditor";
            this.HTMLEditor.ScriptErrorsSuppressed = true;
            this.HTMLEditor.Size = new System.Drawing.Size(646, 202);
            this.HTMLEditor.TabIndex = 5;
            this.HTMLEditor.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.HTMLEditor_DocumentCompleted);
            // 
            // txtasunto
            // 
            this.txtasunto.Location = new System.Drawing.Point(63, 100);
            this.txtasunto.Name = "txtasunto";
            this.txtasunto.Size = new System.Drawing.Size(603, 20);
            this.txtasunto.TabIndex = 4;
            this.txtasunto.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingControl);
            // 
            // txtmailto
            // 
            this.txtmailto.Location = new System.Drawing.Point(63, 74);
            this.txtmailto.Name = "txtmailto";
            this.txtmailto.Size = new System.Drawing.Size(603, 20);
            this.txtmailto.TabIndex = 3;
            this.txtmailto.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingControl);
            // 
            // btnadjuntar
            // 
            this.btnadjuntar.Location = new System.Drawing.Point(20, 362);
            this.btnadjuntar.Name = "btnadjuntar";
            this.btnadjuntar.Size = new System.Drawing.Size(75, 23);
            this.btnadjuntar.TabIndex = 6;
            this.btnadjuntar.Text = "Adjuntar";
            this.btnadjuntar.UseVisualStyleBackColor = true;
            this.btnadjuntar.Click += new System.EventHandler(this.btnadjuntar_Click);
            // 
            // btnenviar
            // 
            this.btnenviar.Location = new System.Drawing.Point(591, 362);
            this.btnenviar.Name = "btnenviar";
            this.btnenviar.Size = new System.Drawing.Size(75, 23);
            this.btnenviar.TabIndex = 9;
            this.btnenviar.Text = "Enviar";
            this.btnenviar.UseVisualStyleBackColor = true;
            this.btnenviar.Click += new System.EventHandler(this.btnenviar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Asunto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Para";
            // 
            // btncancelar
            // 
            this.btncancelar.Location = new System.Drawing.Point(373, 361);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(75, 23);
            this.btncancelar.TabIndex = 8;
            this.btncancelar.Text = "Cancelar";
            this.btncancelar.UseVisualStyleBackColor = true;
            this.btncancelar.Click += new System.EventHandler(this.btncacelar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Clientes";
            // 
            // txtclientes
            // 
            this.txtclientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtclientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtclientes.Location = new System.Drawing.Point(63, 44);
            this.txtclientes.Name = "txtclientes";
            this.txtclientes.Size = new System.Drawing.Size(477, 20);
            this.txtclientes.TabIndex = 1;
            // 
            // btnagregar
            // 
            this.btnagregar.Location = new System.Drawing.Point(557, 44);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(75, 23);
            this.btnagregar.TabIndex = 2;
            this.btnagregar.Text = "Agregar";
            this.btnagregar.UseVisualStyleBackColor = true;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // adjlabel
            // 
            this.adjlabel.AutoSize = true;
            this.adjlabel.Location = new System.Drawing.Point(707, 126);
            this.adjlabel.Name = "adjlabel";
            this.adjlabel.Size = new System.Drawing.Size(0, 13);
            this.adjlabel.TabIndex = 37;
            // 
            // BoldtoolStrip
            // 
            this.BoldtoolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BoldtoolStrip.Image = ((System.Drawing.Image)(resources.GetObject("BoldtoolStrip.Image")));
            this.BoldtoolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BoldtoolStrip.Name = "BoldtoolStrip";
            this.BoldtoolStrip.Size = new System.Drawing.Size(23, 22);
            this.BoldtoolStrip.Text = "Negrita";
            this.BoldtoolStrip.Click += new System.EventHandler(this.BoldtoolStrip_Click);
            // 
            // UnderlinetoolStrip
            // 
            this.UnderlinetoolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UnderlinetoolStrip.Image = ((System.Drawing.Image)(resources.GetObject("UnderlinetoolStrip.Image")));
            this.UnderlinetoolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UnderlinetoolStrip.Name = "UnderlinetoolStrip";
            this.UnderlinetoolStrip.Size = new System.Drawing.Size(23, 22);
            this.UnderlinetoolStrip.Text = "Subrayar";
            this.UnderlinetoolStrip.Click += new System.EventHandler(this.UnderlinetoolStrip_Click);
            // 
            // ItalictoolStrip
            // 
            this.ItalictoolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ItalictoolStrip.Image = ((System.Drawing.Image)(resources.GetObject("ItalictoolStrip.Image")));
            this.ItalictoolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ItalictoolStrip.Name = "ItalictoolStrip";
            this.ItalictoolStrip.Size = new System.Drawing.Size(23, 22);
            this.ItalictoolStrip.Text = "Cursiva";
            this.ItalictoolStrip.Click += new System.EventHandler(this.ItalictoolStrip_Click);
            // 
            // ColortoolStrip
            // 
            this.ColortoolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ColortoolStrip.Image = ((System.Drawing.Image)(resources.GetObject("ColortoolStrip.Image")));
            this.ColortoolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ColortoolStrip.Name = "ColortoolStrip";
            this.ColortoolStrip.Size = new System.Drawing.Size(23, 22);
            this.ColortoolStrip.Text = "Color";
            this.ColortoolStrip.Click += new System.EventHandler(this.ColortoolStrip_Click);
            // 
            // JustifyFulltoolStrip
            // 
            this.JustifyFulltoolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.JustifyFulltoolStrip.Image = ((System.Drawing.Image)(resources.GetObject("JustifyFulltoolStrip.Image")));
            this.JustifyFulltoolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.JustifyFulltoolStrip.Name = "JustifyFulltoolStrip";
            this.JustifyFulltoolStrip.Size = new System.Drawing.Size(23, 22);
            this.JustifyFulltoolStrip.Text = "Alineacion normal";
            this.JustifyFulltoolStrip.Click += new System.EventHandler(this.JustifyFulltoolStrip_Click);
            // 
            // JustifyCentertoolStrip
            // 
            this.JustifyCentertoolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.JustifyCentertoolStrip.Image = ((System.Drawing.Image)(resources.GetObject("JustifyCentertoolStrip.Image")));
            this.JustifyCentertoolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.JustifyCentertoolStrip.Name = "JustifyCentertoolStrip";
            this.JustifyCentertoolStrip.Size = new System.Drawing.Size(23, 22);
            this.JustifyCentertoolStrip.Text = "Alineacion al centro";
            this.JustifyCentertoolStrip.Click += new System.EventHandler(this.JustifyCentertoolStrip_Click);
            // 
            // JustifyLtoolStrip
            // 
            this.JustifyLtoolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.JustifyLtoolStrip.Image = ((System.Drawing.Image)(resources.GetObject("JustifyLtoolStrip.Image")));
            this.JustifyLtoolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.JustifyLtoolStrip.Name = "JustifyLtoolStrip";
            this.JustifyLtoolStrip.Size = new System.Drawing.Size(23, 22);
            this.JustifyLtoolStrip.Text = "Alineacion a la izquierda";
            this.JustifyLtoolStrip.Click += new System.EventHandler(this.JustifyLtoolStrip_Click);
            // 
            // JustifyRtoolStrip
            // 
            this.JustifyRtoolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.JustifyRtoolStrip.Image = ((System.Drawing.Image)(resources.GetObject("JustifyRtoolStrip.Image")));
            this.JustifyRtoolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.JustifyRtoolStrip.Name = "JustifyRtoolStrip";
            this.JustifyRtoolStrip.Size = new System.Drawing.Size(23, 22);
            this.JustifyRtoolStrip.Text = "Alineacion a la derecha";
            this.JustifyRtoolStrip.Click += new System.EventHandler(this.JustifyRtoolStrip_Click);
            // 
            // VinDtoolStrip
            // 
            this.VinDtoolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.VinDtoolStrip.Image = ((System.Drawing.Image)(resources.GetObject("VinDtoolStrip.Image")));
            this.VinDtoolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.VinDtoolStrip.Name = "VinDtoolStrip";
            this.VinDtoolStrip.Size = new System.Drawing.Size(23, 22);
            this.VinDtoolStrip.Text = "toolStripButton9";
            this.VinDtoolStrip.Click += new System.EventHandler(this.VinDtoolStrip_Click);
            // 
            // VinNtoolStrip
            // 
            this.VinNtoolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.VinNtoolStrip.Image = ((System.Drawing.Image)(resources.GetObject("VinNtoolStrip.Image")));
            this.VinNtoolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.VinNtoolStrip.Name = "VinNtoolStrip";
            this.VinNtoolStrip.Size = new System.Drawing.Size(23, 22);
            this.VinNtoolStrip.Text = "toolStripButton10";
            this.VinNtoolStrip.Click += new System.EventHandler(this.VinNtoolStrip_Click);
            // 
            // IMGtoolStrip
            // 
            this.IMGtoolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.IMGtoolStrip.Image = ((System.Drawing.Image)(resources.GetObject("IMGtoolStrip.Image")));
            this.IMGtoolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IMGtoolStrip.Name = "IMGtoolStrip";
            this.IMGtoolStrip.Size = new System.Drawing.Size(23, 22);
            this.IMGtoolStrip.Text = "toolStripButton11";
            this.IMGtoolStrip.Click += new System.EventHandler(this.IMGtoolStrip_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arialToolStripMenuItem,
            this.verdanaToolStripMenuItem,
            this.currierNewToolStripMenuItem,
            this.timesNewRomanToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(59, 22);
            this.toolStripSplitButton1.Text = "Fuente";
            // 
            // arialToolStripMenuItem
            // 
            this.arialToolStripMenuItem.Name = "arialToolStripMenuItem";
            this.arialToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.arialToolStripMenuItem.Text = "Arial";
            this.arialToolStripMenuItem.Click += new System.EventHandler(this.arialToolStripMenuItem_Click);
            // 
            // verdanaToolStripMenuItem
            // 
            this.verdanaToolStripMenuItem.Name = "verdanaToolStripMenuItem";
            this.verdanaToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.verdanaToolStripMenuItem.Text = "Verdana";
            this.verdanaToolStripMenuItem.Click += new System.EventHandler(this.verdanaToolStripMenuItem_Click);
            // 
            // currierNewToolStripMenuItem
            // 
            this.currierNewToolStripMenuItem.Name = "currierNewToolStripMenuItem";
            this.currierNewToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.currierNewToolStripMenuItem.Text = "Currier New";
            this.currierNewToolStripMenuItem.Click += new System.EventHandler(this.currierNewToolStripMenuItem_Click);
            // 
            // timesNewRomanToolStripMenuItem
            // 
            this.timesNewRomanToolStripMenuItem.Name = "timesNewRomanToolStripMenuItem";
            this.timesNewRomanToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.timesNewRomanToolStripMenuItem.Text = "Times New Roman";
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.toolStripSplitButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton2.Image")));
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(67, 22);
            this.toolStripSplitButton2.Text = "Tamaño";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "1";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem3.Text = "2";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem4.Text = "3";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem5.Text = "4";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem6.Text = "5";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BoldtoolStrip,
            this.UnderlinetoolStrip,
            this.ItalictoolStrip,
            this.ColortoolStrip,
            this.JustifyFulltoolStrip,
            this.JustifyCentertoolStrip,
            this.JustifyLtoolStrip,
            this.JustifyRtoolStrip,
            this.VinDtoolStrip,
            this.VinNtoolStrip,
            this.IMGtoolStrip,
            this.toolStripSplitButton1,
            this.toolStripSplitButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(980, 25);
            this.toolStrip1.TabIndex = 34;
            // 
            // frmEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 532);
            this.Controls.Add(this.adjlabel);
            this.Controls.Add(this.btnagregar);
            this.Controls.Add(this.txtclientes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btncancelar);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnimagen);
            this.Controls.Add(this.HTMLEditor);
            this.Controls.Add(this.txtasunto);
            this.Controls.Add(this.txtmailto);
            this.Controls.Add(this.btnadjuntar);
            this.Controls.Add(this.btnenviar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmEmail";
            this.Text = "frmMail";
            this.Load += new System.EventHandler(this.frmMail_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnimagen;
        private System.Windows.Forms.WebBrowser HTMLEditor;
        private System.Windows.Forms.TextBox txtasunto;
        private System.Windows.Forms.TextBox txtmailto;
        private System.Windows.Forms.Button btnadjuntar;
        private System.Windows.Forms.Button btnenviar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btncancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtclientes;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.Label adjlabel;
        private System.Windows.Forms.ToolStripButton BoldtoolStrip;
        private System.Windows.Forms.ToolStripButton UnderlinetoolStrip;
        private System.Windows.Forms.ToolStripButton ItalictoolStrip;
        private System.Windows.Forms.ToolStripButton ColortoolStrip;
        private System.Windows.Forms.ToolStripButton JustifyFulltoolStrip;
        private System.Windows.Forms.ToolStripButton JustifyCentertoolStrip;
        private System.Windows.Forms.ToolStripButton JustifyLtoolStrip;
        private System.Windows.Forms.ToolStripButton JustifyRtoolStrip;
        private System.Windows.Forms.ToolStripButton VinDtoolStrip;
        private System.Windows.Forms.ToolStripButton VinNtoolStrip;
        private System.Windows.Forms.ToolStripButton IMGtoolStrip;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem arialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verdanaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currierNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timesNewRomanToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStrip toolStrip1;
    }
}