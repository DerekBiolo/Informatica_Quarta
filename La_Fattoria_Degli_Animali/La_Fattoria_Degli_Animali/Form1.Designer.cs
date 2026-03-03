namespace La_Fattoria_Degli_Animali
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
            this.lblNomeAnimale = new System.Windows.Forms.Label();
            this.pbCane = new System.Windows.Forms.PictureBox();
            this.pbGatto = new System.Windows.Forms.PictureBox();
            this.pbMucca = new System.Windows.Forms.PictureBox();
            this.pnl_Title = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbCane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGatto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMucca)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNomeAnimale
            // 
            this.lblNomeAnimale.AutoSize = true;
            this.lblNomeAnimale.Location = new System.Drawing.Point(330, 36);
            this.lblNomeAnimale.Name = "lblNomeAnimale";
            this.lblNomeAnimale.Size = new System.Drawing.Size(44, 16);
            this.lblNomeAnimale.TabIndex = 0;
            this.lblNomeAnimale.Text = "label1";
            // 
            // pbCane
            // 
            this.pbCane.Location = new System.Drawing.Point(44, 71);
            this.pbCane.Name = "pbCane";
            this.pbCane.Size = new System.Drawing.Size(100, 50);
            this.pbCane.TabIndex = 1;
            this.pbCane.TabStop = false;
            // 
            // pbGatto
            // 
            this.pbGatto.Location = new System.Drawing.Point(350, 200);
            this.pbGatto.Name = "pbGatto";
            this.pbGatto.Size = new System.Drawing.Size(100, 50);
            this.pbGatto.TabIndex = 2;
            this.pbGatto.TabStop = false;
            // 
            // pbMucca
            // 
            this.pbMucca.Location = new System.Drawing.Point(512, 51);
            this.pbMucca.Name = "pbMucca";
            this.pbMucca.Size = new System.Drawing.Size(100, 50);
            this.pbMucca.TabIndex = 3;
            this.pbMucca.TabStop = false;
            // 
            // pnl_Title
            // 
            this.pnl_Title.Location = new System.Drawing.Point(322, 20);
            this.pnl_Title.Name = "pnl_Title";
            this.pnl_Title.Size = new System.Drawing.Size(200, 100);
            this.pnl_Title.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnl_Title);
            this.Controls.Add(this.pbMucca);
            this.Controls.Add(this.pbGatto);
            this.Controls.Add(this.pbCane);
            this.Controls.Add(this.lblNomeAnimale);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbCane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGatto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMucca)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNomeAnimale;
        private System.Windows.Forms.PictureBox pbCane;
        private System.Windows.Forms.PictureBox pbGatto;
        private System.Windows.Forms.PictureBox pbMucca;
        private System.Windows.Forms.Panel pnl_Title;
    }
}

