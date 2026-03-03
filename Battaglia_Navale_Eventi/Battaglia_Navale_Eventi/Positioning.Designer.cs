namespace Battaglia_Navale_Eventi
{
    partial class Positioning
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
            this.lbl_NaveCorrente = new System.Windows.Forms.Label();
            this.lbl_Orientamento = new System.Windows.Forms.Label();
            this.lbl_NaviRimanenti = new System.Windows.Forms.Label();
            this.btn_Ruota = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_NaveCorrente
            // 
            this.lbl_NaveCorrente.AutoSize = true;
            this.lbl_NaveCorrente.Location = new System.Drawing.Point(563, 96);
            this.lbl_NaveCorrente.Name = "lbl_NaveCorrente";
            this.lbl_NaveCorrente.Size = new System.Drawing.Size(44, 16);
            this.lbl_NaveCorrente.TabIndex = 0;
            this.lbl_NaveCorrente.Text = "label1";
            // 
            // lbl_Orientamento
            // 
            this.lbl_Orientamento.AutoSize = true;
            this.lbl_Orientamento.Location = new System.Drawing.Point(564, 150);
            this.lbl_Orientamento.Name = "lbl_Orientamento";
            this.lbl_Orientamento.Size = new System.Drawing.Size(44, 16);
            this.lbl_Orientamento.TabIndex = 1;
            this.lbl_Orientamento.Text = "label1";
            // 
            // lbl_NaviRimanenti
            // 
            this.lbl_NaviRimanenti.AutoSize = true;
            this.lbl_NaviRimanenti.Location = new System.Drawing.Point(563, 211);
            this.lbl_NaviRimanenti.Name = "lbl_NaviRimanenti";
            this.lbl_NaviRimanenti.Size = new System.Drawing.Size(44, 16);
            this.lbl_NaviRimanenti.TabIndex = 2;
            this.lbl_NaviRimanenti.Text = "label1";
            // 
            // btn_Ruota
            // 
            this.btn_Ruota.Location = new System.Drawing.Point(713, 150);
            this.btn_Ruota.Name = "btn_Ruota";
            this.btn_Ruota.Size = new System.Drawing.Size(75, 23);
            this.btn_Ruota.TabIndex = 3;
            this.btn_Ruota.Text = "Ruota";
            this.btn_Ruota.UseVisualStyleBackColor = true;
            this.btn_Ruota.Click += new System.EventHandler(this.btn_Ruota_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(12, 12);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "Back";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // Positioning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ruota);
            this.Controls.Add(this.lbl_NaviRimanenti);
            this.Controls.Add(this.lbl_Orientamento);
            this.Controls.Add(this.lbl_NaveCorrente);
            this.Name = "Positioning";
            this.Text = "PvAIPositioning";
            this.Load += new System.EventHandler(this.Positioning_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_NaveCorrente;
        private System.Windows.Forms.Label lbl_Orientamento;
        private System.Windows.Forms.Label lbl_NaviRimanenti;
        private System.Windows.Forms.Button btn_Ruota;
        private System.Windows.Forms.Button btn_Cancel;
    }
}