namespace LandManagement
{
    partial class frmPadre
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
            this.lblEntornoDeTest = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblEntornoDeTest
            // 
            this.lblEntornoDeTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEntornoDeTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblEntornoDeTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntornoDeTest.Location = new System.Drawing.Point(12, 236);
            this.lblEntornoDeTest.Name = "lblEntornoDeTest";
            this.lblEntornoDeTest.Size = new System.Drawing.Size(260, 17);
            this.lblEntornoDeTest.TabIndex = 0;
            this.lblEntornoDeTest.Text = "ENTORNO DE TEST";
            this.lblEntornoDeTest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEntornoDeTest.Visible = false;
            // 
            // frmPadre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lblEntornoDeTest);
            this.Name = "frmPadre";
            this.Text = "frmPadre";
            this.Load += new System.EventHandler(this.frmPadre_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblEntornoDeTest;
    }
}