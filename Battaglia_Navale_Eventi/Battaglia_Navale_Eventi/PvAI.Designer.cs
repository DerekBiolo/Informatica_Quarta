namespace Battaglia_Navale_Eventi
{
    partial class PvAI
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
            this.lst_Log = new System.Windows.Forms.ListBox();
            this.lbl_Mosse = new System.Windows.Forms.Label();
            this.lbl_NaviRimanenti = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lst_Log
            // 
            this.lst_Log.FormattingEnabled = true;
            this.lst_Log.ItemHeight = 16;
            this.lst_Log.Location = new System.Drawing.Point(389, 492);
            this.lst_Log.Name = "lst_Log";
            this.lst_Log.Size = new System.Drawing.Size(443, 180);
            this.lst_Log.TabIndex = 0;
            // 
            // lbl_Mosse
            // 
            this.lbl_Mosse.AutoSize = true;
            this.lbl_Mosse.Location = new System.Drawing.Point(189, 492);
            this.lbl_Mosse.Name = "lbl_Mosse";
            this.lbl_Mosse.Size = new System.Drawing.Size(44, 16);
            this.lbl_Mosse.TabIndex = 1;
            this.lbl_Mosse.Text = "label1";
            // 
            // lbl_NaviRimanenti
            // 
            this.lbl_NaviRimanenti.AutoSize = true;
            this.lbl_NaviRimanenti.Location = new System.Drawing.Point(12, 492);
            this.lbl_NaviRimanenti.Name = "lbl_NaviRimanenti";
            this.lbl_NaviRimanenti.Size = new System.Drawing.Size(44, 16);
            this.lbl_NaviRimanenti.TabIndex = 2;
            this.lbl_NaviRimanenti.Text = "label1";
            // 
            // PvAI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 676);
            this.Controls.Add(this.lbl_NaviRimanenti);
            this.Controls.Add(this.lbl_Mosse);
            this.Controls.Add(this.lst_Log);
            this.Name = "PvAI";
            this.Text = "PvAI";
            this.Load += new System.EventHandler(this.PvAI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lst_Log;
        private System.Windows.Forms.Label lbl_Mosse;
        private System.Windows.Forms.Label lbl_NaviRimanenti;
    }
}