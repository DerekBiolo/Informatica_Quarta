namespace FileMultimedialiForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Lbl_Luminosita = new System.Windows.Forms.Label();
            this.Num_Luminosita = new System.Windows.Forms.NumericUpDown();
            this.Lbl_Durata = new System.Windows.Forms.Label();
            this.Txt_Durata = new System.Windows.Forms.TextBox();
            this.Lbl_Volume = new System.Windows.Forms.Label();
            this.Num_Volume = new System.Windows.Forms.NumericUpDown();
            this.odsoiwdjfownvnbdwhv = new System.Windows.Forms.Label();
            this.RBtn_Audio = new System.Windows.Forms.RadioButton();
            this.RBtn_Video = new System.Windows.Forms.RadioButton();
            this.RBtn_Immagine = new System.Windows.Forms.RadioButton();
            this.btn_AddFile = new System.Windows.Forms.Button();
            this.MTxt_NomeFile = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Lst_visualizzazione = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_IncreaseVOlume = new System.Windows.Forms.Button();
            this.btn_DecreaseVolume = new System.Windows.Forms.Button();
            this.btn_IncreaseBrightness = new System.Windows.Forms.Button();
            this.btn_DecreaseLuminosita = new System.Windows.Forms.Button();
            this.bar_Volume = new System.Windows.Forms.ProgressBar();
            this.bar_Luminosita = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.Lumi = new System.Windows.Forms.Label();
            this.Lbl_DurataItemSelezionato = new System.Windows.Forms.Label();
            this.lbl_NomeFileSelezionato = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Luminosita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Volume)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.Lbl_Luminosita);
            this.panel1.Controls.Add(this.Num_Luminosita);
            this.panel1.Controls.Add(this.Lbl_Durata);
            this.panel1.Controls.Add(this.Txt_Durata);
            this.panel1.Controls.Add(this.Lbl_Volume);
            this.panel1.Controls.Add(this.Num_Volume);
            this.panel1.Controls.Add(this.odsoiwdjfownvnbdwhv);
            this.panel1.Controls.Add(this.RBtn_Audio);
            this.panel1.Controls.Add(this.RBtn_Video);
            this.panel1.Controls.Add(this.RBtn_Immagine);
            this.panel1.Controls.Add(this.btn_AddFile);
            this.panel1.Controls.Add(this.MTxt_NomeFile);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 425);
            this.panel1.TabIndex = 0;
            // 
            // Lbl_Luminosita
            // 
            this.Lbl_Luminosita.AutoSize = true;
            this.Lbl_Luminosita.Location = new System.Drawing.Point(14, 314);
            this.Lbl_Luminosita.Name = "Lbl_Luminosita";
            this.Lbl_Luminosita.Size = new System.Drawing.Size(126, 16);
            this.Lbl_Luminosita.TabIndex = 16;
            this.Lbl_Luminosita.Text = "Luminosità ( 0 - 100 )";
            // 
            // Num_Luminosita
            // 
            this.Num_Luminosita.Location = new System.Drawing.Point(14, 333);
            this.Num_Luminosita.Name = "Num_Luminosita";
            this.Num_Luminosita.Size = new System.Drawing.Size(152, 22);
            this.Num_Luminosita.TabIndex = 15;
            // 
            // Lbl_Durata
            // 
            this.Lbl_Durata.AutoSize = true;
            this.Lbl_Durata.Location = new System.Drawing.Point(14, 258);
            this.Lbl_Durata.Name = "Lbl_Durata";
            this.Lbl_Durata.Size = new System.Drawing.Size(97, 16);
            this.Lbl_Durata.TabIndex = 14;
            this.Lbl_Durata.Text = "Durata (mm:ss)";
            // 
            // Txt_Durata
            // 
            this.Txt_Durata.Location = new System.Drawing.Point(14, 277);
            this.Txt_Durata.Name = "Txt_Durata";
            this.Txt_Durata.Size = new System.Drawing.Size(153, 22);
            this.Txt_Durata.TabIndex = 13;
            // 
            // Lbl_Volume
            // 
            this.Lbl_Volume.AutoSize = true;
            this.Lbl_Volume.Location = new System.Drawing.Point(14, 202);
            this.Lbl_Volume.Name = "Lbl_Volume";
            this.Lbl_Volume.Size = new System.Drawing.Size(108, 16);
            this.Lbl_Volume.TabIndex = 12;
            this.Lbl_Volume.Text = "Volume ( 0 - 100 )";
            // 
            // Num_Volume
            // 
            this.Num_Volume.Location = new System.Drawing.Point(14, 221);
            this.Num_Volume.Name = "Num_Volume";
            this.Num_Volume.Size = new System.Drawing.Size(152, 22);
            this.Num_Volume.TabIndex = 11;
            // 
            // odsoiwdjfownvnbdwhv
            // 
            this.odsoiwdjfownvnbdwhv.AutoSize = true;
            this.odsoiwdjfownvnbdwhv.Location = new System.Drawing.Point(14, 146);
            this.odsoiwdjfownvnbdwhv.Name = "odsoiwdjfownvnbdwhv";
            this.odsoiwdjfownvnbdwhv.Size = new System.Drawing.Size(41, 16);
            this.odsoiwdjfownvnbdwhv.TabIndex = 10;
            this.odsoiwdjfownvnbdwhv.Text = "Titolo";
            // 
            // RBtn_Audio
            // 
            this.RBtn_Audio.AutoSize = true;
            this.RBtn_Audio.Location = new System.Drawing.Point(15, 103);
            this.RBtn_Audio.Name = "RBtn_Audio";
            this.RBtn_Audio.Size = new System.Drawing.Size(63, 20);
            this.RBtn_Audio.TabIndex = 9;
            this.RBtn_Audio.TabStop = true;
            this.RBtn_Audio.Text = "Audio";
            this.RBtn_Audio.UseVisualStyleBackColor = true;
            this.RBtn_Audio.CheckedChanged += new System.EventHandler(this.RBtn_Audio_CheckedChanged);
            // 
            // RBtn_Video
            // 
            this.RBtn_Video.AutoSize = true;
            this.RBtn_Video.Location = new System.Drawing.Point(15, 77);
            this.RBtn_Video.Name = "RBtn_Video";
            this.RBtn_Video.Size = new System.Drawing.Size(64, 20);
            this.RBtn_Video.TabIndex = 8;
            this.RBtn_Video.TabStop = true;
            this.RBtn_Video.Text = "Video";
            this.RBtn_Video.UseVisualStyleBackColor = true;
            this.RBtn_Video.CheckedChanged += new System.EventHandler(this.RBtn_Video_CheckedChanged);
            // 
            // RBtn_Immagine
            // 
            this.RBtn_Immagine.AutoSize = true;
            this.RBtn_Immagine.Location = new System.Drawing.Point(15, 51);
            this.RBtn_Immagine.Name = "RBtn_Immagine";
            this.RBtn_Immagine.Size = new System.Drawing.Size(87, 20);
            this.RBtn_Immagine.TabIndex = 7;
            this.RBtn_Immagine.TabStop = true;
            this.RBtn_Immagine.Text = "Immagine";
            this.RBtn_Immagine.UseVisualStyleBackColor = true;
            this.RBtn_Immagine.CheckedChanged += new System.EventHandler(this.RBtn_Immagine_CheckedChanged);
            // 
            // btn_AddFile
            // 
            this.btn_AddFile.Location = new System.Drawing.Point(17, 363);
            this.btn_AddFile.Name = "btn_AddFile";
            this.btn_AddFile.Size = new System.Drawing.Size(230, 45);
            this.btn_AddFile.TabIndex = 6;
            this.btn_AddFile.Text = "Aggiungi File";
            this.btn_AddFile.UseVisualStyleBackColor = true;
            this.btn_AddFile.Click += new System.EventHandler(this.btn_AddFile_Click);
            // 
            // MTxt_NomeFile
            // 
            this.MTxt_NomeFile.Location = new System.Drawing.Point(14, 165);
            this.MTxt_NomeFile.Name = "MTxt_NomeFile";
            this.MTxt_NomeFile.Size = new System.Drawing.Size(155, 22);
            this.MTxt_NomeFile.TabIndex = 5;
            this.MTxt_NomeFile.Leave += new System.EventHandler(this.MTxt_NomeFile_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Modulo di inserimento";
            // 
            // Lst_visualizzazione
            // 
            this.Lst_visualizzazione.FormattingEnabled = true;
            this.Lst_visualizzazione.ItemHeight = 16;
            this.Lst_visualizzazione.Location = new System.Drawing.Point(283, 13);
            this.Lst_visualizzazione.Name = "Lst_visualizzazione";
            this.Lst_visualizzazione.Size = new System.Drawing.Size(627, 420);
            this.Lst_visualizzazione.TabIndex = 1;
            this.Lst_visualizzazione.SelectedIndexChanged += new System.EventHandler(this.Lst_visualizzazione_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Controls.Add(this.btn_IncreaseVOlume);
            this.panel2.Controls.Add(this.btn_DecreaseVolume);
            this.panel2.Controls.Add(this.btn_IncreaseBrightness);
            this.panel2.Controls.Add(this.btn_DecreaseLuminosita);
            this.panel2.Controls.Add(this.bar_Volume);
            this.panel2.Controls.Add(this.bar_Luminosita);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.Lumi);
            this.panel2.Controls.Add(this.Lbl_DurataItemSelezionato);
            this.panel2.Controls.Add(this.lbl_NomeFileSelezionato);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(916, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(264, 425);
            this.panel2.TabIndex = 2;
            // 
            // btn_IncreaseVOlume
            // 
            this.btn_IncreaseVOlume.Location = new System.Drawing.Point(134, 269);
            this.btn_IncreaseVOlume.Name = "btn_IncreaseVOlume";
            this.btn_IncreaseVOlume.Size = new System.Drawing.Size(112, 23);
            this.btn_IncreaseVOlume.TabIndex = 29;
            this.btn_IncreaseVOlume.Text = "+";
            this.btn_IncreaseVOlume.UseVisualStyleBackColor = true;
            this.btn_IncreaseVOlume.Click += new System.EventHandler(this.btn_IncreaseVOlume_Click);
            // 
            // btn_DecreaseVolume
            // 
            this.btn_DecreaseVolume.Location = new System.Drawing.Point(19, 269);
            this.btn_DecreaseVolume.Name = "btn_DecreaseVolume";
            this.btn_DecreaseVolume.Size = new System.Drawing.Size(112, 23);
            this.btn_DecreaseVolume.TabIndex = 28;
            this.btn_DecreaseVolume.Text = "-";
            this.btn_DecreaseVolume.UseVisualStyleBackColor = true;
            this.btn_DecreaseVolume.Click += new System.EventHandler(this.btn_DecreaseVolume_Click);
            // 
            // btn_IncreaseBrightness
            // 
            this.btn_IncreaseBrightness.Location = new System.Drawing.Point(134, 181);
            this.btn_IncreaseBrightness.Name = "btn_IncreaseBrightness";
            this.btn_IncreaseBrightness.Size = new System.Drawing.Size(112, 23);
            this.btn_IncreaseBrightness.TabIndex = 27;
            this.btn_IncreaseBrightness.Text = "+";
            this.btn_IncreaseBrightness.UseVisualStyleBackColor = true;
            this.btn_IncreaseBrightness.Click += new System.EventHandler(this.btn_IncreaseBrightness_Click);
            // 
            // btn_DecreaseLuminosita
            // 
            this.btn_DecreaseLuminosita.Location = new System.Drawing.Point(19, 181);
            this.btn_DecreaseLuminosita.Name = "btn_DecreaseLuminosita";
            this.btn_DecreaseLuminosita.Size = new System.Drawing.Size(112, 23);
            this.btn_DecreaseLuminosita.TabIndex = 26;
            this.btn_DecreaseLuminosita.Text = "-";
            this.btn_DecreaseLuminosita.UseVisualStyleBackColor = true;
            this.btn_DecreaseLuminosita.Click += new System.EventHandler(this.btn_DecreaseLuminosita_Click);
            // 
            // bar_Volume
            // 
            this.bar_Volume.Location = new System.Drawing.Point(19, 240);
            this.bar_Volume.Name = "bar_Volume";
            this.bar_Volume.Size = new System.Drawing.Size(227, 23);
            this.bar_Volume.TabIndex = 25;
            // 
            // bar_Luminosita
            // 
            this.bar_Luminosita.Location = new System.Drawing.Point(19, 151);
            this.bar_Luminosita.Name = "bar_Luminosita";
            this.bar_Luminosita.Size = new System.Drawing.Size(227, 23);
            this.bar_Luminosita.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "Volume";
            // 
            // Lumi
            // 
            this.Lumi.AutoSize = true;
            this.Lumi.Location = new System.Drawing.Point(16, 131);
            this.Lumi.Name = "Lumi";
            this.Lumi.Size = new System.Drawing.Size(71, 16);
            this.Lumi.TabIndex = 22;
            this.Lumi.Text = "Luminosità";
            // 
            // Lbl_DurataItemSelezionato
            // 
            this.Lbl_DurataItemSelezionato.AutoSize = true;
            this.Lbl_DurataItemSelezionato.Location = new System.Drawing.Point(16, 81);
            this.Lbl_DurataItemSelezionato.Name = "Lbl_DurataItemSelezionato";
            this.Lbl_DurataItemSelezionato.Size = new System.Drawing.Size(44, 16);
            this.Lbl_DurataItemSelezionato.TabIndex = 21;
            this.Lbl_DurataItemSelezionato.Text = "label3";
            // 
            // lbl_NomeFileSelezionato
            // 
            this.lbl_NomeFileSelezionato.AutoSize = true;
            this.lbl_NomeFileSelezionato.Location = new System.Drawing.Point(16, 53);
            this.lbl_NomeFileSelezionato.Name = "lbl_NomeFileSelezionato";
            this.lbl_NomeFileSelezionato.Size = new System.Drawing.Size(44, 16);
            this.lbl_NomeFileSelezionato.TabIndex = 18;
            this.lbl_NomeFileSelezionato.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Modulo di inserimento";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 476);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Lst_visualizzazione);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Luminosita)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Volume)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_AddFile;
        private System.Windows.Forms.MaskedTextBox MTxt_NomeFile;
        private System.Windows.Forms.RadioButton RBtn_Audio;
        private System.Windows.Forms.RadioButton RBtn_Video;
        private System.Windows.Forms.RadioButton RBtn_Immagine;
        private System.Windows.Forms.Label odsoiwdjfownvnbdwhv;
        private System.Windows.Forms.Label Lbl_Volume;
        private System.Windows.Forms.NumericUpDown Num_Volume;
        private System.Windows.Forms.Label Lbl_Durata;
        private System.Windows.Forms.TextBox Txt_Durata;
        private System.Windows.Forms.Label Lbl_Luminosita;
        private System.Windows.Forms.NumericUpDown Num_Luminosita;
        private System.Windows.Forms.ListBox Lst_visualizzazione;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Lbl_DurataItemSelezionato;
        private System.Windows.Forms.Label lbl_NomeFileSelezionato;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar bar_Volume;
        private System.Windows.Forms.ProgressBar bar_Luminosita;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Lumi;
        private System.Windows.Forms.Button btn_IncreaseBrightness;
        private System.Windows.Forms.Button btn_DecreaseLuminosita;
        private System.Windows.Forms.Button btn_IncreaseVOlume;
        private System.Windows.Forms.Button btn_DecreaseVolume;
    }
}

