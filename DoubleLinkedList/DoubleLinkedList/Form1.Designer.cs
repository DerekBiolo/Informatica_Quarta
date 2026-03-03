namespace DoubleLinkedList
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        private void InitializeComponent()
        {
            this.txt_nome        = new System.Windows.Forms.TextBox();
            this.label_nome      = new System.Windows.Forms.Label();
            this.label_cognome   = new System.Windows.Forms.Label();
            this.txt_cognome     = new System.Windows.Forms.TextBox();
            this.label_classe    = new System.Windows.Forms.Label();
            this.txt_classe      = new System.Windows.Forms.TextBox();
            this.label_codice    = new System.Windows.Forms.Label();
            this.txt_codice      = new System.Windows.Forms.TextBox();
            this.listBox1        = new System.Windows.Forms.ListBox();
            this.btn_Inserisci   = new System.Windows.Forms.Button();
            this.btn_Mostra      = new System.Windows.Forms.Button();
            this.btn_Decrescente = new System.Windows.Forms.Button();
            this.btn_SalvaJSON   = new System.Windows.Forms.Button();
            this.btn_CaricaJSON  = new System.Windows.Forms.Button();
            this.btn_Cerca       = new System.Windows.Forms.Button();
            this.btn_Elimina     = new System.Windows.Forms.Button();
            this.btn_Aggiorna    = new System.Windows.Forms.Button();
            this.lbl_info        = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // Valori di default — la posizione/dimensione reale è impostata
            // da Styler() in Form1.cs, quindi questi valori sono solo placeholder.
            this.txt_nome.Location      = new System.Drawing.Point(40, 60);
            this.txt_nome.Name          = "txt_nome";
            this.txt_nome.Size          = new System.Drawing.Size(100, 22);
            this.txt_nome.TabIndex      = 0;

            this.label_nome.AutoSize    = true;
            this.label_nome.Location    = new System.Drawing.Point(40, 40);
            this.label_nome.Name        = "label_nome";
            this.label_nome.Size        = new System.Drawing.Size(47, 16);
            this.label_nome.TabIndex    = 1;
            this.label_nome.Text        = "NOME";

            this.label_cognome.AutoSize = true;
            this.label_cognome.Location = new System.Drawing.Point(40, 108);
            this.label_cognome.Name     = "label_cognome";
            this.label_cognome.Size     = new System.Drawing.Size(76, 16);
            this.label_cognome.TabIndex = 7;
            this.label_cognome.Text     = "COGNOME";

            this.txt_cognome.Location   = new System.Drawing.Point(40, 128);
            this.txt_cognome.Name       = "txt_cognome";
            this.txt_cognome.Size       = new System.Drawing.Size(100, 22);
            this.txt_cognome.TabIndex   = 6;

            this.label_classe.AutoSize  = true;
            this.label_classe.Location  = new System.Drawing.Point(40, 244);
            this.label_classe.Name      = "label_classe";
            this.label_classe.Size      = new System.Drawing.Size(59, 16);
            this.label_classe.TabIndex  = 11;
            this.label_classe.Text      = "CLASSE";

            this.txt_classe.Location    = new System.Drawing.Point(40, 264);
            this.txt_classe.Name        = "txt_classe";
            this.txt_classe.Size        = new System.Drawing.Size(100, 22);
            this.txt_classe.TabIndex    = 10;

            this.label_codice.AutoSize  = true;
            this.label_codice.Location  = new System.Drawing.Point(40, 176);
            this.label_codice.Name      = "label_codice";
            this.label_codice.Size      = new System.Drawing.Size(57, 16);
            this.label_codice.TabIndex  = 9;
            this.label_codice.Text      = "CODICE";

            this.txt_codice.Location    = new System.Drawing.Point(40, 196);
            this.txt_codice.Name        = "txt_codice";
            this.txt_codice.Size        = new System.Drawing.Size(100, 22);
            this.txt_codice.TabIndex    = 8;

            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight    = 16;
            this.listBox1.Location      = new System.Drawing.Point(40, 560);
            this.listBox1.Name          = "listBox1";
            this.listBox1.Size          = new System.Drawing.Size(500, 200);
            this.listBox1.TabIndex      = 12;

            this.btn_Inserisci.Location = new System.Drawing.Point(40, 350);
            this.btn_Inserisci.Name     = "btn_Inserisci";
            this.btn_Inserisci.Size     = new System.Drawing.Size(100, 38);
            this.btn_Inserisci.TabIndex = 13;
            this.btn_Inserisci.Text     = "＋  Inserisci";
            this.btn_Inserisci.UseVisualStyleBackColor = true;
            this.btn_Inserisci.Click   += new System.EventHandler(this.btn_Inserisci_Click);

            this.btn_Mostra.Location    = new System.Drawing.Point(40, 450);
            this.btn_Mostra.Name        = "btn_Mostra";
            this.btn_Mostra.Size        = new System.Drawing.Size(240, 38);
            this.btn_Mostra.TabIndex    = 14;
            this.btn_Mostra.Text        = "↑  Crescente";
            this.btn_Mostra.UseVisualStyleBackColor = true;
            this.btn_Mostra.Click      += new System.EventHandler(this.btn_Mostra_Click);

            this.btn_Decrescente.Location = new System.Drawing.Point(290, 450);
            this.btn_Decrescente.Name   = "btn_Decrescente";
            this.btn_Decrescente.Size   = new System.Drawing.Size(240, 38);
            this.btn_Decrescente.TabIndex = 20;
            this.btn_Decrescente.Text   = "↓  Decrescente";
            this.btn_Decrescente.UseVisualStyleBackColor = true;
            this.btn_Decrescente.Click += new System.EventHandler(this.btn_Decrescente_Click);

            this.btn_SalvaJSON.Location = new System.Drawing.Point(40, 400);
            this.btn_SalvaJSON.Name     = "btn_SalvaJSON";
            this.btn_SalvaJSON.Size     = new System.Drawing.Size(156, 38);
            this.btn_SalvaJSON.TabIndex = 15;
            this.btn_SalvaJSON.Text     = "↓  Salva JSON";
            this.btn_SalvaJSON.UseVisualStyleBackColor = true;
            this.btn_SalvaJSON.Click   += new System.EventHandler(this.btn_SalvaJSON_Click);

            this.btn_CaricaJSON.Location = new System.Drawing.Point(204, 400);
            this.btn_CaricaJSON.Name    = "btn_CaricaJSON";
            this.btn_CaricaJSON.Size    = new System.Drawing.Size(156, 38);
            this.btn_CaricaJSON.TabIndex = 16;
            this.btn_CaricaJSON.Text    = "↑  Carica JSON";
            this.btn_CaricaJSON.UseVisualStyleBackColor = true;
            this.btn_CaricaJSON.Click  += new System.EventHandler(this.btn_CaricaJSON_Click);

            this.btn_Cerca.Location     = new System.Drawing.Point(40, 350);
            this.btn_Cerca.Name         = "btn_Cerca";
            this.btn_Cerca.Size         = new System.Drawing.Size(118, 38);
            this.btn_Cerca.TabIndex     = 17;
            this.btn_Cerca.Text         = "⌕  Cerca";
            this.btn_Cerca.UseVisualStyleBackColor = true;
            this.btn_Cerca.Click       += new System.EventHandler(this.btn_Cerca_Click);

            this.btn_Elimina.Location   = new System.Drawing.Point(40, 350);
            this.btn_Elimina.Name       = "btn_Elimina";
            this.btn_Elimina.Size       = new System.Drawing.Size(118, 38);
            this.btn_Elimina.TabIndex   = 18;
            this.btn_Elimina.Text       = "✕  Elimina";
            this.btn_Elimina.UseVisualStyleBackColor = true;
            this.btn_Elimina.Click     += new System.EventHandler(this.btn_Elimina_Click);

            this.btn_Aggiorna.Location  = new System.Drawing.Point(40, 350);
            this.btn_Aggiorna.Name      = "btn_Aggiorna";
            this.btn_Aggiorna.Size      = new System.Drawing.Size(118, 38);
            this.btn_Aggiorna.TabIndex  = 19;
            this.btn_Aggiorna.Text      = "↻  Aggiorna";
            this.btn_Aggiorna.UseVisualStyleBackColor = true;
            this.btn_Aggiorna.Click    += new System.EventHandler(this.btn_Aggiorna_Click);

            this.lbl_info.AutoSize      = false;
            this.lbl_info.Location      = new System.Drawing.Point(40, 540);
            this.lbl_info.Name          = "lbl_info";
            this.lbl_info.Size          = new System.Drawing.Size(500, 18);
            this.lbl_info.TabIndex      = 21;
            this.lbl_info.Text          = "";

            // ── FORM ─────────────────────────────────────────────────
            this.AutoScaleDimensions    = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode          = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize             = new System.Drawing.Size(580, 800);
            this.Controls.Add(this.lbl_info);
            this.Controls.Add(this.btn_Decrescente);
            this.Controls.Add(this.btn_Aggiorna);
            this.Controls.Add(this.btn_Elimina);
            this.Controls.Add(this.btn_Cerca);
            this.Controls.Add(this.btn_CaricaJSON);
            this.Controls.Add(this.btn_SalvaJSON);
            this.Controls.Add(this.btn_Mostra);
            this.Controls.Add(this.btn_Inserisci);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label_classe);
            this.Controls.Add(this.txt_classe);
            this.Controls.Add(this.label_codice);
            this.Controls.Add(this.txt_codice);
            this.Controls.Add(this.label_cognome);
            this.Controls.Add(this.txt_cognome);
            this.Controls.Add(this.label_nome);
            this.Controls.Add(this.txt_nome);
            this.Name                   = "Form1";
            this.Text                   = "Gestione Studenti";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox  txt_nome;
        private System.Windows.Forms.Label    label_nome;
        private System.Windows.Forms.Label    label_cognome;
        private System.Windows.Forms.TextBox  txt_cognome;
        private System.Windows.Forms.Label    label_classe;
        private System.Windows.Forms.TextBox  txt_classe;
        private System.Windows.Forms.Label    label_codice;
        private System.Windows.Forms.TextBox  txt_codice;
        private System.Windows.Forms.ListBox  listBox1;
        private System.Windows.Forms.Button   btn_Inserisci;
        private System.Windows.Forms.Button   btn_Mostra;
        private System.Windows.Forms.Button   btn_Decrescente;
        private System.Windows.Forms.Button   btn_SalvaJSON;
        private System.Windows.Forms.Button   btn_CaricaJSON;
        private System.Windows.Forms.Button   btn_Cerca;
        private System.Windows.Forms.Button   btn_Elimina;
        private System.Windows.Forms.Button   btn_Aggiorna;
        private System.Windows.Forms.Label    lbl_info;
    }
}
