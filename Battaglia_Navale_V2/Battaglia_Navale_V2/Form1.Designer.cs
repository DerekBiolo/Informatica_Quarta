namespace Battaglia_Navale_V2
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlPlayer1 = new System.Windows.Forms.Panel();
            this.pnlPlayer2 = new System.Windows.Forms.Panel();
            this.lblMosse = new System.Windows.Forms.Label();
            this.lblNaviRimanenti = new System.Windows.Forms.Label();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // pnlPlayer1
            // 
            this.pnlPlayer1.Location = new System.Drawing.Point(64, 67);
            this.pnlPlayer1.Name = "pnlPlayer1";
            this.pnlPlayer1.Size = new System.Drawing.Size(200, 100);
            this.pnlPlayer1.TabIndex = 0;
            // 
            // pnlPlayer2
            // 
            this.pnlPlayer2.Location = new System.Drawing.Point(449, 67);
            this.pnlPlayer2.Name = "pnlPlayer2";
            this.pnlPlayer2.Size = new System.Drawing.Size(200, 100);
            this.pnlPlayer2.TabIndex = 1;
            // 
            // lblMosse
            // 
            this.lblMosse.AutoSize = true;
            this.lblMosse.Location = new System.Drawing.Point(61, 232);
            this.lblMosse.Name = "lblMosse";
            this.lblMosse.Size = new System.Drawing.Size(44, 16);
            this.lblMosse.TabIndex = 2;
            this.lblMosse.Text = "label1";
            // 
            // lblNaviRimanenti
            // 
            this.lblNaviRimanenti.AutoSize = true;
            this.lblNaviRimanenti.Location = new System.Drawing.Point(61, 267);
            this.lblNaviRimanenti.Name = "lblNaviRimanenti";
            this.lblNaviRimanenti.Size = new System.Drawing.Size(44, 16);
            this.lblNaviRimanenti.TabIndex = 3;
            this.lblNaviRimanenti.Text = "label2";
            // 
            // lstLog
            // 
            this.lstLog.FormattingEnabled = true;
            this.lstLog.ItemHeight = 16;
            this.lstLog.Location = new System.Drawing.Point(449, 209);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(312, 212);
            this.lstLog.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 577);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.lblNaviRimanenti);
            this.Controls.Add(this.lblMosse);
            this.Controls.Add(this.pnlPlayer2);
            this.Controls.Add(this.pnlPlayer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPlayer1;
        private System.Windows.Forms.Panel pnlPlayer2;
        private System.Windows.Forms.Label lblMosse;
        private System.Windows.Forms.Label lblNaviRimanenti;
        private System.Windows.Forms.ListBox lstLog;
    }
}

