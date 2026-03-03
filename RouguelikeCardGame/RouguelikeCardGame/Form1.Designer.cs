namespace RouguelikeCardGame
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
            this.Btn_StartGame = new System.Windows.Forms.Button();
            this.Lst_GameLogVisualizer = new System.Windows.Forms.ListBox();
            this.Btn_Continue = new System.Windows.Forms.Button();
            this.Lbl_PlayerCoins = new System.Windows.Forms.Label();
            this.Lbl_Turn = new System.Windows.Forms.Label();
            this.Lst_Deck2Visual = new System.Windows.Forms.ListBox();
            this.Lst_Deck1Visual = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Btn_StartGame
            // 
            this.Btn_StartGame.Location = new System.Drawing.Point(481, 451);
            this.Btn_StartGame.Name = "Btn_StartGame";
            this.Btn_StartGame.Size = new System.Drawing.Size(222, 86);
            this.Btn_StartGame.TabIndex = 0;
            this.Btn_StartGame.Text = "Start game";
            this.Btn_StartGame.UseVisualStyleBackColor = true;
            this.Btn_StartGame.Click += new System.EventHandler(this.Btn_StartGame_Click);
            // 
            // Lst_GameLogVisualizer
            // 
            this.Lst_GameLogVisualizer.FormattingEnabled = true;
            this.Lst_GameLogVisualizer.ItemHeight = 16;
            this.Lst_GameLogVisualizer.Location = new System.Drawing.Point(32, 28);
            this.Lst_GameLogVisualizer.Name = "Lst_GameLogVisualizer";
            this.Lst_GameLogVisualizer.Size = new System.Drawing.Size(415, 628);
            this.Lst_GameLogVisualizer.TabIndex = 1;
            // 
            // Btn_Continue
            // 
            this.Btn_Continue.Location = new System.Drawing.Point(709, 451);
            this.Btn_Continue.Name = "Btn_Continue";
            this.Btn_Continue.Size = new System.Drawing.Size(222, 86);
            this.Btn_Continue.TabIndex = 4;
            this.Btn_Continue.Text = "Continue";
            this.Btn_Continue.UseVisualStyleBackColor = true;
            this.Btn_Continue.Click += new System.EventHandler(this.Btn_Continue_Click);
            // 
            // Lbl_PlayerCoins
            // 
            this.Lbl_PlayerCoins.AutoSize = true;
            this.Lbl_PlayerCoins.Location = new System.Drawing.Point(965, 451);
            this.Lbl_PlayerCoins.Name = "Lbl_PlayerCoins";
            this.Lbl_PlayerCoins.Size = new System.Drawing.Size(0, 16);
            this.Lbl_PlayerCoins.TabIndex = 5;
            // 
            // Lbl_Turn
            // 
            this.Lbl_Turn.AutoSize = true;
            this.Lbl_Turn.Location = new System.Drawing.Point(32, 6);
            this.Lbl_Turn.Name = "Lbl_Turn";
            this.Lbl_Turn.Size = new System.Drawing.Size(0, 16);
            this.Lbl_Turn.TabIndex = 6;
            // 
            // Lst_Deck2Visual
            // 
            this.Lst_Deck2Visual.FormattingEnabled = true;
            this.Lst_Deck2Visual.ItemHeight = 16;
            this.Lst_Deck2Visual.Location = new System.Drawing.Point(902, 28);
            this.Lst_Deck2Visual.Name = "Lst_Deck2Visual";
            this.Lst_Deck2Visual.Size = new System.Drawing.Size(415, 388);
            this.Lst_Deck2Visual.TabIndex = 3;
            // 
            // Lst_Deck1Visual
            // 
            this.Lst_Deck1Visual.FormattingEnabled = true;
            this.Lst_Deck1Visual.ItemHeight = 16;
            this.Lst_Deck1Visual.Location = new System.Drawing.Point(481, 28);
            this.Lst_Deck1Visual.Name = "Lst_Deck1Visual";
            this.Lst_Deck1Visual.Size = new System.Drawing.Size(415, 388);
            this.Lst_Deck1Visual.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1491, 682);
            this.Controls.Add(this.Lbl_Turn);
            this.Controls.Add(this.Lbl_PlayerCoins);
            this.Controls.Add(this.Btn_Continue);
            this.Controls.Add(this.Lst_Deck2Visual);
            this.Controls.Add(this.Lst_Deck1Visual);
            this.Controls.Add(this.Lst_GameLogVisualizer);
            this.Controls.Add(this.Btn_StartGame);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_StartGame;
        private System.Windows.Forms.ListBox Lst_GameLogVisualizer;
        private System.Windows.Forms.Button Btn_Continue;
        private System.Windows.Forms.Label Lbl_PlayerCoins;
        private System.Windows.Forms.Label Lbl_Turn;
        private System.Windows.Forms.ListBox Lst_Deck2Visual;
        private System.Windows.Forms.ListBox Lst_Deck1Visual;
    }
}

