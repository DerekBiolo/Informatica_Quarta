using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DoubleLinkedList
{
    public partial class Form1 : Form
    {
        DoubleLinkedList lista = new DoubleLinkedList();

        readonly string percorsoFile = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "studenti.json");

        public Form1()
        {
            InitializeComponent();
            Styler();
            CaricaAllAvvio();
        }

        private void CaricaAllAvvio()
        {
            if (!File.Exists(percorsoFile)) return;

            try
            {
                string json = File.ReadAllText(percorsoFile);
                var studenti = JsonConvert.DeserializeObject<List<Studente>>(json);
                lista.Clear();
                foreach (var s in studenti)
                    lista.Add(s);

                AggiornalistBox(lista);
            }
            catch
            {
                MessageBox.Show("Impossibile ripristinare i dati dal file.",
                                "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AggiornalistBox(IEnumerable<Studente> sorgente)
        {
            listBox1.Items.Clear();
            foreach (var s in sorgente)
                listBox1.Items.Add(s);
        }

        private void Styler()
        {
            Color sfondo      = Color.FromArgb(15, 15, 20);
            Color superficie  = Color.FromArgb(25, 25, 35);
            Color bordo       = Color.FromArgb(50, 50, 70);
            Color accento     = Color.FromArgb(99, 179, 237);
            Color testoChiaro = Color.FromArgb(220, 220, 235);
            Color testoGrigio = Color.FromArgb(120, 120, 150);

            this.BackColor        = sfondo;
            this.ForeColor        = testoChiaro;
            this.Font             = new Font("Segoe UI", 9.5f);
            this.Text             = "Gestione Studenti";
            this.Size             = new Size(580, 800);
            this.MinimumSize      = new Size(580, 800);
            this.StartPosition    = FormStartPosition.CenterScreen;

            void StileLabel(Label l, string testo, int x, int y1)
            {
                l.Text      = testo;
                l.Location  = new Point(x, y1);
                l.Size      = new Size(500, 18);
                l.ForeColor = testoGrigio;
                l.Font      = new Font("Segoe UI", 8f, FontStyle.Bold);
                l.AutoSize  = false;
            }

            void StileTextBox(TextBox t, int x, int y2)
            {
                t.Location    = new Point(x, y2);
                t.Size        = new Size(500, 34);
                t.BackColor   = superficie;
                t.ForeColor   = testoChiaro;
                t.BorderStyle = BorderStyle.FixedSingle;
                t.Font        = new Font("Segoe UI", 11f);
            }

            void StileBottone(Button b, int x, int y3, int w = 120, bool primario = false)
            {
                b.Location = new Point(x, y3);
                b.Size     = new Size(w, 38);
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderColor           = primario ? accento : bordo;
                b.FlatAppearance.BorderSize            = 1;
                b.FlatAppearance.MouseOverBackColor    = Color.FromArgb(45, 99, 179, 237);
                b.BackColor = primario ? Color.FromArgb(25, 99, 179, 237) : superficie;
                b.ForeColor = primario ? accento : testoGrigio;
                b.Font      = new Font("Segoe UI", 9f, FontStyle.Bold);
                b.Cursor    = Cursors.Hand;
                b.UseVisualStyleBackColor = false;
                Color fgNorm = primario ? accento : testoGrigio;
                b.MouseEnter += (s, e) => b.ForeColor = Color.White;
                b.MouseLeave += (s, e) => b.ForeColor = fgNorm;
            }

            int lx = 40, gap = 68, y = 40;

            StileLabel(label_nome,     "NOME",     lx, y); StileTextBox(txt_nome,     lx, y + 20); y += gap;
            StileLabel(label_cognome,  "COGNOME",  lx, y); StileTextBox(txt_cognome,  lx, y + 20); y += gap;
            StileLabel(label_codice,   "CODICE",   lx, y); StileTextBox(txt_codice,   lx, y + 20); y += gap;
            StileLabel(label_classe,   "CLASSE",   lx, y); StileTextBox(txt_classe,   lx, y + 20); y += gap + 10;

            // separatore 1
            this.Controls.Add(new Panel { Location = new Point(lx, y), Size = new Size(500, 1), BackColor = bordo });
            y += 16;

            // riga 1 – CRUD
            int bw = 118, bsp = 8, bx = lx;
            btn_Inserisci.Text = "＋  Inserisci"; StileBottone(btn_Inserisci, bx, y, bw, primario: true); bx += bw + bsp;
            btn_Aggiorna.Text  = "↻  Aggiorna";  StileBottone(btn_Aggiorna,  bx, y, bw);                  bx += bw + bsp;
            btn_Cerca.Text     = "⌕  Cerca";     StileBottone(btn_Cerca,     bx, y, bw);                  bx += bw + bsp;
            btn_Elimina.Text   = "✕  Elimina";   StileBottone(btn_Elimina,   bx, y, bw);
            y += 52;

            // riga 2 – JSON
            bx = lx;
            btn_SalvaJSON.Text   = "↓  Salva JSON";   StileBottone(btn_SalvaJSON,   bx, y, 156); bx += 156 + bsp;
            btn_CaricaJSON.Text  = "↑  Carica JSON";  StileBottone(btn_CaricaJSON,  bx, y, 156); bx += 156 + bsp;
            y += 52;

            // riga 3 – mostra crescente / decrescente (menu 5 e 6)
            bx = lx;
            btn_Mostra.Text     = "↑  Crescente";     StileBottone(btn_Mostra,     bx, y, 240, primario: true); bx += 240 + bsp;
            btn_Decrescente.Text = "↓  Decrescente";  StileBottone(btn_Decrescente, bx, y, 240);
            y += 52;

            // separatore 2
            this.Controls.Add(new Panel { Location = new Point(lx, y), Size = new Size(500, 1), BackColor = bordo });
            y += 14;

            // info size + listbox
            lbl_info.Location  = new Point(lx, y);
            lbl_info.Size      = new Size(500, 18);
            lbl_info.ForeColor = testoGrigio;
            lbl_info.Font      = new Font("Segoe UI", 8f, FontStyle.Bold);
            y += 20;

            listBox1.Location    = new Point(lx, y);
            listBox1.Size        = new Size(500, 200);
            listBox1.BackColor   = superficie;
            listBox1.ForeColor   = testoChiaro;
            listBox1.BorderStyle = BorderStyle.FixedSingle;
            listBox1.Font        = new Font("Consolas", 9.5f);
            listBox1.DrawMode    = DrawMode.OwnerDrawFixed;
            listBox1.ItemHeight  = 24;
            listBox1.DrawItem   += (s, e) =>
            {
                if (e.Index < 0) return;
                Color bg = (e.Index % 2 == 0) ? superficie : Color.FromArgb(32, 32, 48);
                e.Graphics.FillRectangle(new SolidBrush(bg), e.Bounds);
                e.Graphics.DrawString(
                    listBox1.Items[e.Index].ToString(),
                    e.Font, new SolidBrush(testoChiaro),
                    new Point(e.Bounds.X + 6, e.Bounds.Y + 4));
            };
        }
        private void AggiornInfo()
        {
            lbl_info.Text = lista.IsEmpty()
                ? "Lista vuota"
                : $"Studenti in lista: {lista.Size()}   |   Primo: {lista.First().Codice}   |   Ultimo: {lista.Last().Codice}";
        }

        private void btn_Inserisci_Click(object sender, EventArgs e)
        {
            if (CampiVuoti()) return;

            Studente s = new Studente(txt_nome.Text, txt_cognome.Text,
                                     txt_codice.Text, txt_classe.Text);
            lista.Add(s);
            SalvaAutomatico();
            AggiornalistBox(lista);
            AggiornInfo();
            MessageBox.Show("Studente inserito!", "OK",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            PulisciCampi();
        }

        private void btn_Cerca_Click(object sender, EventArgs e)
        {
            var studente = lista.Find(txt_codice.Text.Trim());
            if (studente != null)
                MessageBox.Show(studente.ToString(), "Studente trovato",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Studente non trovato!", "Non trovato",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btn_Elimina_Click(object sender, EventArgs e)
        {
            string codice = txt_codice.Text.Trim();
            if (string.IsNullOrWhiteSpace(codice))
            {
                MessageBox.Show("Inserisci il codice dello studente da eliminare.");
                return;
            }

            lista.Delete(codice);
            SalvaAutomatico();
            AggiornalistBox(lista);
            AggiornInfo();
            MessageBox.Show("Operazione completata.", "OK",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Aggiorna_Click(object sender, EventArgs e)
        {
            if (CampiVuoti()) return;

            Studente nuovo = new Studente(txt_nome.Text, txt_cognome.Text,
                                          txt_codice.Text, txt_classe.Text);
            lista.UpdateByCodice(txt_codice.Text, nuovo);
            SalvaAutomatico();
            AggiornalistBox(lista);
            AggiornInfo();
            MessageBox.Show("Studente aggiornato!", "OK",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            PulisciCampi();
        }

        private void btn_Mostra_Click(object sender, EventArgs e)
        {
            // usa direttamente lista come IEnumerable (foreach sul DLL)
            AggiornalistBox(lista.GetAscending());
            AggiornInfo();
        }
        private void btn_Decrescente_Click(object sender, EventArgs e)
        {
            AggiornalistBox(lista.GetDescending());
            AggiornInfo();
        }

        private void btn_SalvaJSON_Click(object sender, EventArgs e)
        {
            SalvaAutomatico();
            MessageBox.Show($"Dati salvati su:\n{percorsoFile}", "Salvato",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_CaricaJSON_Click(object sender, EventArgs e)
        {
            if (!File.Exists(percorsoFile))
            {
                MessageBox.Show("File non trovato!", "Errore",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string json     = File.ReadAllText(percorsoFile);
            var studenti    = JsonConvert.DeserializeObject<List<Studente>>(json);
            lista.Clear();
            foreach (var s in studenti)
                lista.Add(s);

            AggiornalistBox(lista);
            AggiornInfo();
            MessageBox.Show("Dati caricati!", "OK",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SalvaAutomatico()
        {
            var snapshot = new List<Studente>();
            foreach (var s in lista)
                snapshot.Add(s);

            string json = JsonConvert.SerializeObject(snapshot, Formatting.Indented);
            File.WriteAllText(percorsoFile, json);
        }

        private bool CampiVuoti()
        {
            if (string.IsNullOrWhiteSpace(txt_nome.Text)    ||
                string.IsNullOrWhiteSpace(txt_cognome.Text) ||
                string.IsNullOrWhiteSpace(txt_codice.Text)  ||
                string.IsNullOrWhiteSpace(txt_classe.Text))
            {
                MessageBox.Show("Compila tutti i campi!", "Attenzione",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        private void PulisciCampi()
        {
            txt_nome.Clear();
            txt_cognome.Clear();
            txt_codice.Clear();
            txt_classe.Clear();
        }
    }
}
