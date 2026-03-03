namespace Torre_di_hannoi_forms
{
    partial class FSimulazione
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
            this.pnl_TorreA = new System.Windows.Forms.Panel();
            this.pnl_TorreB = new System.Windows.Forms.Panel();
            this.pnl_TorreC = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Timer = new System.Windows.Forms.Label();
            this.lbl_NumeroMosse = new System.Windows.Forms.Label();
            this.lbl_MosseMinime = new System.Windows.Forms.Label();
            this.lbl_TempoPrevisto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnl_TorreA
            // 
            this.pnl_TorreA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.pnl_TorreA.Location = new System.Drawing.Point(142, 136);
            this.pnl_TorreA.Name = "pnl_TorreA";
            this.pnl_TorreA.Size = new System.Drawing.Size(20, 287);
            this.pnl_TorreA.TabIndex = 0;
            // 
            // pnl_TorreB
            // 
            this.pnl_TorreB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.pnl_TorreB.Location = new System.Drawing.Point(390, 136);
            this.pnl_TorreB.Name = "pnl_TorreB";
            this.pnl_TorreB.Size = new System.Drawing.Size(20, 287);
            this.pnl_TorreB.TabIndex = 1;
            // 
            // pnl_TorreC
            // 
            this.pnl_TorreC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.pnl_TorreC.Location = new System.Drawing.Point(638, 136);
            this.pnl_TorreC.Name = "pnl_TorreC";
            this.pnl_TorreC.Size = new System.Drawing.Size(20, 287);
            this.pnl_TorreC.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel1.Location = new System.Drawing.Point(-13, 409);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 59);
            this.panel1.TabIndex = 1;
            // 
            // lbl_Timer
            // 
            this.lbl_Timer.AutoSize = true;
            this.lbl_Timer.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Timer.Location = new System.Drawing.Point(13, 13);
            this.lbl_Timer.Name = "lbl_Timer";
            this.lbl_Timer.Size = new System.Drawing.Size(73, 27);
            this.lbl_Timer.TabIndex = 3;
            this.lbl_Timer.Text = "label1";
            // 
            // lbl_NumeroMosse
            // 
            this.lbl_NumeroMosse.AutoSize = true;
            this.lbl_NumeroMosse.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NumeroMosse.Location = new System.Drawing.Point(13, 40);
            this.lbl_NumeroMosse.Name = "lbl_NumeroMosse";
            this.lbl_NumeroMosse.Size = new System.Drawing.Size(73, 27);
            this.lbl_NumeroMosse.TabIndex = 4;
            this.lbl_NumeroMosse.Text = "label1";
            // 
            // lbl_MosseMinime
            // 
            this.lbl_MosseMinime.AutoSize = true;
            this.lbl_MosseMinime.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MosseMinime.Location = new System.Drawing.Point(13, 67);
            this.lbl_MosseMinime.Name = "lbl_MosseMinime";
            this.lbl_MosseMinime.Size = new System.Drawing.Size(73, 27);
            this.lbl_MosseMinime.TabIndex = 5;
            this.lbl_MosseMinime.Text = "label1";
            // 
            // lbl_TempoPrevisto
            // 
            this.lbl_TempoPrevisto.AutoSize = true;
            this.lbl_TempoPrevisto.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TempoPrevisto.Location = new System.Drawing.Point(13, 94);
            this.lbl_TempoPrevisto.Name = "lbl_TempoPrevisto";
            this.lbl_TempoPrevisto.Size = new System.Drawing.Size(73, 27);
            this.lbl_TempoPrevisto.TabIndex = 6;
            this.lbl_TempoPrevisto.Text = "label1";
            // 
            // FSimulazione
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_TempoPrevisto);
            this.Controls.Add(this.lbl_MosseMinime);
            this.Controls.Add(this.lbl_NumeroMosse);
            this.Controls.Add(this.lbl_Timer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_TorreC);
            this.Controls.Add(this.pnl_TorreB);
            this.Controls.Add(this.pnl_TorreA);
            this.Name = "FSimulazione";
            this.Text = "FSimulazione";
            this.Load += new System.EventHandler(this.FSimulazione_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_TorreA;
        private System.Windows.Forms.Panel pnl_TorreB;
        private System.Windows.Forms.Panel pnl_TorreC;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Timer;
        private System.Windows.Forms.Label lbl_NumeroMosse;
        private System.Windows.Forms.Label lbl_MosseMinime;
        private System.Windows.Forms.Label lbl_TempoPrevisto;
    }
}