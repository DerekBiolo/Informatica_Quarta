namespace Torre_di_hannoi_forms
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
            this.num_NumeroDischi = new System.Windows.Forms.NumericUpDown();
            this.lbl_Titolo = new System.Windows.Forms.Label();
            this.lbl_Descrizione = new System.Windows.Forms.Label();
            this.btn_Avvia = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_NumeroDischi)).BeginInit();
            this.SuspendLayout();
            // 
            // num_NumeroDischi
            // 
            this.num_NumeroDischi.Location = new System.Drawing.Point(336, 221);
            this.num_NumeroDischi.Name = "num_NumeroDischi";
            this.num_NumeroDischi.Size = new System.Drawing.Size(120, 22);
            this.num_NumeroDischi.TabIndex = 0;
            // 
            // lbl_Titolo
            // 
            this.lbl_Titolo.AutoSize = true;
            this.lbl_Titolo.Location = new System.Drawing.Point(336, 13);
            this.lbl_Titolo.Name = "lbl_Titolo";
            this.lbl_Titolo.Size = new System.Drawing.Size(93, 16);
            this.lbl_Titolo.TabIndex = 1;
            this.lbl_Titolo.Text = "Torre di Hanoi";
            // 
            // lbl_Descrizione
            // 
            this.lbl_Descrizione.AutoSize = true;
            this.lbl_Descrizione.Location = new System.Drawing.Point(336, 33);
            this.lbl_Descrizione.Name = "lbl_Descrizione";
            this.lbl_Descrizione.Size = new System.Drawing.Size(244, 16);
            this.lbl_Descrizione.TabIndex = 2;
            this.lbl_Descrizione.Text = "Inserisci il numero di dischi totali ( 1 - 15 )";
            // 
            // btn_Avvia
            // 
            this.btn_Avvia.Location = new System.Drawing.Point(472, 221);
            this.btn_Avvia.Name = "btn_Avvia";
            this.btn_Avvia.Size = new System.Drawing.Size(187, 23);
            this.btn_Avvia.TabIndex = 3;
            this.btn_Avvia.Text = "Avvia Simulazione";
            this.btn_Avvia.UseVisualStyleBackColor = true;
            this.btn_Avvia.Click += new System.EventHandler(this.btn_Avvia_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Avvia);
            this.Controls.Add(this.lbl_Descrizione);
            this.Controls.Add(this.lbl_Titolo);
            this.Controls.Add(this.num_NumeroDischi);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.num_NumeroDischi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown num_NumeroDischi;
        private System.Windows.Forms.Label lbl_Titolo;
        private System.Windows.Forms.Label lbl_Descrizione;
        private System.Windows.Forms.Button btn_Avvia;
    }
}

