namespace Battaglia_Navale_Eventi
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
            this.btn_PvP = new System.Windows.Forms.Button();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.btn_PvAI = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_PvP
            // 
            this.btn_PvP.Location = new System.Drawing.Point(12, 169);
            this.btn_PvP.Name = "btn_PvP";
            this.btn_PvP.Size = new System.Drawing.Size(187, 111);
            this.btn_PvP.TabIndex = 0;
            this.btn_PvP.Text = "PvP";
            this.btn_PvP.UseVisualStyleBackColor = true;
            this.btn_PvP.Click += new System.EventHandler(this.btn_PvP_Click);
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Location = new System.Drawing.Point(337, 51);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(107, 16);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "Battaglia Navale";
            // 
            // btn_PvAI
            // 
            this.btn_PvAI.Location = new System.Drawing.Point(307, 170);
            this.btn_PvAI.Name = "btn_PvAI";
            this.btn_PvAI.Size = new System.Drawing.Size(187, 111);
            this.btn_PvAI.TabIndex = 2;
            this.btn_PvAI.Text = "PvAI";
            this.btn_PvAI.UseVisualStyleBackColor = true;
            this.btn_PvAI.Click += new System.EventHandler(this.btn_PvAI_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(572, 170);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(187, 111);
            this.btn_Exit.TabIndex = 3;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_PvAI);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.btn_PvP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_PvP;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Button btn_PvAI;
        private System.Windows.Forms.Button btn_Exit;
    }
}

