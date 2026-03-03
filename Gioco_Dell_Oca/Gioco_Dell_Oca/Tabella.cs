using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.ComponentModel.Design;
using System.Runtime.Remoting.Channels;

namespace Gioco_Dell_Oca
{
    public class Tabella
    {
        public List<Casella> Caselle = new List<Casella>();
        int _Size = 70;
        public Label lblPunteggio;

        public void AddCaselle(Dictionary<int, TipologiaCasella> caselleSpeciali)
        {
            for (int i = 1; i < 64; i++)
            {
                Casella casella;
                if (!(caselleSpeciali.ContainsKey(i)))
                {
                    casella = new Casella(i, "Normale.png", TipologiaCasella.Normale);
                }
                else
                {
                    TipologiaCasella type = caselleSpeciali[i];
                    string path = $"{type}.png";
                    casella = new Casella(i, path, type);
                }

                //registro l'evento alla casella
                if (casella.Tipologia != TipologiaCasella.Normale)
                {
                    casella.OnPlayerLanded += OnCasellaPlayerLanded;
                }

                Caselle.Add(casella);
            }
        }

        private void OnCasellaPlayerLanded(object sender, CasellaEventArgs e)
        {
            switch (e.Tipologia)
            {
                case TipologiaCasella.Normale:
                    break;

                case TipologiaCasella.Oca:
                    MessageBox.Show($"🪿 Casella OCA!\n{e.Giocatore.Name} avanza nuovamente di {GameManager.Instance.Dice1Value + GameManager.Instance.Dice2Value} caselle!",
                        "Evento Casella", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //prendo la posizione attuale del giocatore dalla cella che ha appena raggiunto
                    int posizioneAttuale = GameManager.Instance.CurrentPlayer.CasellaAttuale;
                    int nuovePosizione = posizioneAttuale + GameManager.Instance.Dice1Value + GameManager.Instance.Dice2Value;

                    //muovo il player alla nuova posizione
                    GameManager.Instance.MuoviGiocatoreACasella(e.Giocatore, nuovePosizione);
                    break;

                case TipologiaCasella.Ponte:
                    MessageBox.Show($"🌉 Ponte!\n{e.Giocatore.Name} raddoppio!",
                        "Evento Casella", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GameManager.Instance.MuoviGiocatoreACasella(e.Giocatore, 12);
                    break;

                case TipologiaCasella.Casa:
                    MessageBox.Show($"🏠 Casa!\n{e.Giocatore.Name} salta 1 turno!",
                        "Evento Casella", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Giocatore.TurniFermi = 1;
                    break;

                case TipologiaCasella.Prigione:
                    MessageBox.Show($"⛓️ Prigione!\n{e.Giocatore.Name} salta 3 turni!",
                        "Evento Casella", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Giocatore.TurniFermi = 3;
                    break;

                case TipologiaCasella.Labirinto:
                    MessageBox.Show($"🌀 Labirinto!\n{e.Giocatore.Name} torna alla casella 39!",
                        "Evento Casella", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    GameManager.Instance.MuoviGiocatoreACasella(e.Giocatore, 39);
                    break;

                case TipologiaCasella.Scheletro:
                    MessageBox.Show($"💀 Scheletro!\n{e.Giocatore.Name} torna all'inizio!",
                        "Evento Casella", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GameManager.Instance.MuoviGiocatoreACasella(e.Giocatore, 1);
                    break;

                case TipologiaCasella.Arrivo:
                    MessageBox.Show($"🏆 VITTORIA!\n{e.Giocatore.Name} ha vinto la partita!",
                        "FINE PARTITA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    GameManager.Instance.FinePartita(e.Giocatore);
                    break;
            }
        }

        public void InizializzaForm()
        {
            Form1 f = Form1.Instance;
            f.WindowState = FormWindowState.Maximized;
            f.FormBorderStyle = FormBorderStyle.None;

            int formWidth = f.ClientSize.Width;
            int formHeight = f.ClientSize.Height;

            int boardAreaWidth = (int)(formWidth * 0.75);
            int boardAreaHeight = formHeight;

            int controlsAreaX = boardAreaWidth + 20;
            int controlsAreaWidth = formWidth - boardAreaWidth - 40;

            int colonne = 9;
            int righe = (int)Math.Ceiling(63.0 / colonne);

            int spacing = 5;
            int margineTop = 40;
            int margineSx = 30;

            int maxCasellaWidth = (boardAreaWidth - margineSx * 2 - spacing * (colonne - 1)) / colonne;
            int maxCasellaHeight = (boardAreaHeight - margineTop * 2 - spacing * (righe - 1)) / righe;

            _Size = Math.Min(maxCasellaWidth, maxCasellaHeight);
            _Size = Math.Min(_Size, 90);

            int boardTotalWidth = colonne * _Size + (colonne - 1) * spacing;
            int boardTotalHeight = righe * _Size + (righe - 1) * spacing;
            int offsetX = (boardAreaWidth - boardTotalWidth) / 2;
            int offsetY = (boardAreaHeight - boardTotalHeight) / 2;

            foreach (var casella in Caselle)
            {
                int index = casella.Numero - 1;
                int riga = index / colonne;
                int colonna = index % colonne;

                if (riga % 2 == 1)
                {
                    colonna = colonne - 1 - colonna;
                }

                int x = offsetX + colonna * (_Size + spacing);
                int y = offsetY + riga * (_Size + spacing);

                // Panel
                Panel panel = new Panel();
                panel.Location = new Point(x, y);
                panel.Size = new Size(_Size, _Size);
                panel.BorderStyle = BorderStyle.FixedSingle;

                // Immagine
                PictureBox pictureBox = new PictureBox();
                pictureBox.Dock = DockStyle.Fill;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                if (File.Exists(casella.FiguraPath))
                    pictureBox.Image = Image.FromFile(casella.FiguraPath);
                else
                {
                    // ⭐ MODIFICATO: Colori diversi per tipo casella
                    switch (casella.Tipologia)
                    {
                        case TipologiaCasella.Normale:
                            pictureBox.BackColor = Color.LightBlue;
                            break;
                        case TipologiaCasella.Oca:
                            pictureBox.BackColor = Color.LightGreen;
                            break;
                        case TipologiaCasella.Ponte:
                            pictureBox.BackColor = Color.LightYellow;
                            break;
                        case TipologiaCasella.Casa:
                            pictureBox.BackColor = Color.LightPink;
                            break;
                        case TipologiaCasella.Prigione:
                            pictureBox.BackColor = Color.Gray;
                            break;
                        case TipologiaCasella.Labirinto:
                            pictureBox.BackColor = Color.Purple;
                            break;
                        case TipologiaCasella.Scheletro:
                            pictureBox.BackColor = Color.DarkRed;
                            break;
                        case TipologiaCasella.Arrivo:
                            pictureBox.BackColor = Color.Gold;
                            break;
                    }
                }

                // Numero sopra all'immagine
                string numeroTesto = casella.Numero.ToString();
                pictureBox.Paint += (sender, e) =>
                {
                    using (Font font = new Font("Arial", Math.Max(10, _Size / 8), FontStyle.Bold))
                    using (SolidBrush brush = new SolidBrush(Color.Black))
                    {
                        StringFormat sf = new StringFormat();
                        sf.Alignment = StringAlignment.Near;
                        sf.LineAlignment = StringAlignment.Far;

                        RectangleF rect = new RectangleF(2, 2,
                            pictureBox.Width - 4, pictureBox.Height - 4);

                        e.Graphics.DrawString(numeroTesto, font, brush, rect, sf);
                    }
                };

                panel.Controls.Add(pictureBox);
                f.Controls.Add(panel);
                casella.Panel = panel;
            }

            // Costruisci i controlli nell'area di destra
            Button btnClose = BtnCloseBuilder();
            Button btnRollDice = BtnRollDiceBuilder(controlsAreaX, controlsAreaWidth);

            Point centroBtn = new Point(
                btnRollDice.Left + btnRollDice.Width / 2,
                btnRollDice.Top + btnRollDice.Height / 2
            );

            Panel Dice1 = PnlDiceBuilder(centroBtn, true);
            Panel Dice2 = PnlDiceBuilder(centroBtn, false);

            // Label per i punteggi
            Label lblPunteggio = new Label();
            lblPunteggio.Text = "Punteggio Giocatori";
            lblPunteggio.Font = new Font("Arial", 14, FontStyle.Bold);
            lblPunteggio.Location = new Point(controlsAreaX, btnRollDice.Bottom + 150);
            lblPunteggio.AutoSize = true;

            f.Controls.Add(btnClose);
            f.Controls.Add(btnRollDice);
            f.Controls.Add(Dice1);
            f.Controls.Add(Dice2);
            f.Controls.Add(lblPunteggio);
            this.lblPunteggio = lblPunteggio;
        }



        private Button BtnCloseBuilder()
        {
            Button btnClose = new Button();
            btnClose.Text = "✕";
            btnClose.Size = new Size(45, 45);
            btnClose.Location = new Point(Form1.Instance.ClientSize.Width - btnClose.Width - 15, 15);
            btnClose.BackColor = Color.FromArgb(220, 53, 69);
            btnClose.ForeColor = Color.White;
            btnClose.Font = new Font("Arial", 16, FontStyle.Bold);
            btnClose.Click += (sender, e) => { Application.Exit(); };
            btnClose.TextAlign = ContentAlignment.MiddleCenter;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Cursor = Cursors.Hand;
            return btnClose;
        }

        private Button BtnRollDiceBuilder(int controlsAreaX, int controlsAreaWidth)
        {
            Button b = new Button();
            b.Text = "LANCIA\nDADI";
            b.Size = new Size(Math.Min(160, controlsAreaWidth - 40), 80);
            b.Location = new Point(controlsAreaX + (controlsAreaWidth - b.Width) / 2, 100);
            b.Click += (sender, e) => { GameManager.Instance.RollDices(); };
            b.Font = new Font("Consolas", 14, FontStyle.Bold);
            b.BackColor = Color.FromArgb(65, 105, 225);
            b.ForeColor = Color.White;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.Cursor = Cursors.Hand;

            // Effetto hover
            b.MouseEnter += (s, e) => b.BackColor = Color.FromArgb(50, 90, 210);
            b.MouseLeave += (s, e) => b.BackColor = Color.FromArgb(65, 105, 225);

            return b;
        }

        private Panel PnlDiceBuilder(Point pt, bool ifRight)
        {
            Panel p = new Panel();
            int diceSize = 70;
            p.Size = new Size(diceSize, diceSize);

            // Posiziona i dadi sotto il bottone
            int offsetX = ifRight ? -diceSize - 10 : 10;
            p.Location = new Point(pt.X + offsetX, pt.Y + 60);

            p.BackgroundImage = Image.FromFile("Dice1.png");
            p.BackgroundImageLayout = ImageLayout.Stretch;
            p.Tag = ifRight ? "Dice1" : "Dice2";
            p.BackColor = Color.Transparent;
            p.BorderStyle = BorderStyle.FixedSingle;

            return p;
        }
    }
}