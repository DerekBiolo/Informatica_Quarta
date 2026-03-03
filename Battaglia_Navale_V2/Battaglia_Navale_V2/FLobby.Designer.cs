namespace Battaglia_Navale_V2
{
    partial class FLobby
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
            this.btn_PlayerPlayer = new System.Windows.Forms.Button();
            this.btn_PlayerAI = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_PlayerPlayer
            // 
            this.btn_PlayerPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PlayerPlayer.Location = new System.Drawing.Point(12, 219);
            this.btn_PlayerPlayer.Name = "btn_PlayerPlayer";
            this.btn_PlayerPlayer.Size = new System.Drawing.Size(230, 94);
            this.btn_PlayerPlayer.TabIndex = 0;
            this.btn_PlayerPlayer.Text = "PvP";
            this.btn_PlayerPlayer.UseVisualStyleBackColor = true;
            this.btn_PlayerPlayer.Click += new System.EventHandler(this.btn_PlayerPlayer_Click);
            // 
            // btn_PlayerAI
            // 
            this.btn_PlayerAI.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PlayerAI.Location = new System.Drawing.Point(277, 219);
            this.btn_PlayerAI.Name = "btn_PlayerAI";
            this.btn_PlayerAI.Size = new System.Drawing.Size(230, 94);
            this.btn_PlayerAI.TabIndex = 1;
            this.btn_PlayerAI.Text = "PvAI";
            this.btn_PlayerAI.UseVisualStyleBackColor = true;
            this.btn_PlayerAI.Click += new System.EventHandler(this.btn_PlayerAI_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Exit.Location = new System.Drawing.Point(535, 219);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(230, 94);
            this.btn_Exit.TabIndex = 2;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // FLobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_PlayerAI);
            this.Controls.Add(this.btn_PlayerPlayer);
            this.Name = "FLobby";
            this.Text = "FLobby";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_PlayerPlayer;
        private System.Windows.Forms.Button btn_PlayerAI;
        private System.Windows.Forms.Button btn_Exit;
    }
}