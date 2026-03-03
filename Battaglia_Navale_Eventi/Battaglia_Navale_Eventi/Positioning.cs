using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Battaglia_Navale_Eventi
{
    public partial class Positioning : Form
    {
        public event EventHandler PositioningAperto;

        private bool isPvP; // true se la partita è PvP, false vs Computer
        private Player player1;
        private Player player2;
        private Player playerCorrente; // giocatore che sta posizionando le navi

        public Positioning(bool isPvp)
        {
            InitializeComponent();
            isPvP = isPvp; // salviamo il tipo di partita
        }

        private void Positioning_Load(object sender, EventArgs e)
        {
            PositioningAperto?.Invoke(this, EventArgs.Empty); // evento per notificare l'apertura

            player1 = new Player("Giocatore 1");
            playerCorrente = player1; // parte sempre il player 1

            if (isPvP)
                player2 = new Player("Giocatore 2"); // secondo giocatore umano
            else
            {
                player2 = new Player("Computer"); // IA
                player2.GeneraRandom(); // il pc posiziona da solo le sue navi
            }

            Styler();                // applica stile generale
            CreaGriglia(playerCorrente); // crea la griglia per il giocatore corrente
            Styler();                // la richiami per aggiornare posizioni e colori
            AggiornaUI();            // aggiorna testi interfaccia
        }

        private void CreaGriglia(Player player)
        {
            int size = 50; // lato cella
            player.PulsantiGriglia.Clear(); // pulizia pulsanti precedenti

            // Creazione pulsanti griglia 10x10
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    Button btn = new Button
                    {
                        Size = new Size(size, size),
                        Tag = new Point(x, y), // salvo la posizione logica
                        BackColor = Color.LightBlue, // colore base
                        FlatStyle = FlatStyle.Flat
                    };

                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = Color.White;

                    // eventi interazione
                    btn.Click += Btn_Click;         // posiziona nave
                    btn.MouseEnter += Btn_MouseEnter; // mostra anteprima
                    btn.MouseLeave += Btn_MouseLeave; // reset preview

                    this.Controls.Add(btn);
                    player.PulsantiGriglia.Add(btn);
                }
            }

            // centra la griglia nel form
            int gridWidth = size * 10;
            int gridHeight = size * 10;
            int startX = (this.Width - gridWidth) / 2;
            int startY = (this.Height - gridHeight) / 2;

            // posiziona ogni pulsante a schermo
            foreach (var btn in player.PulsantiGriglia)
            {
                Point p = (Point)btn.Tag;
                btn.Location = new Point(startX + p.X * size, startY + p.Y * size);
            }
        }

        // Anteprima posizionamento nave
        private void Btn_MouseEnter(object sender, EventArgs e)
        {
            if (playerCorrente.NaveCorrente == null) return; // se non c'è nave da posizionare, esco

            var btn = sender as Button;
            if (btn == null) return;

            int lunghezza = playerCorrente.NaveCorrente.Lunghezza; // lunghezza nave
            bool verticale = playerCorrente.Verticale; // orientamento
            Point start = (Point)btn.Tag; // posizione iniziale

            // colora celle dove la nave andrebbe
            for (int i = 0; i < lunghezza; i++)
            {
                int x = verticale ? start.X : start.X + i;
                int y = verticale ? start.Y + i : start.Y;

                if (x < 0 || x >= 10 || y < 0 || y >= 10) break; // evita uscita griglia

                Button b = playerCorrente.PulsantiGriglia.First(p => (Point)p.Tag == new Point(x, y));
                b.BackColor = Color.Yellow; // preview
            }
        }

        // reset colori dopo anteprima
        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            foreach (var b in playerCorrente.PulsantiGriglia)
                b.BackColor = Color.LightBlue; // reset griglia

            // ricolora celle occupate dalle navi già messe
            foreach (var nave in playerCorrente.Flotta)
            {
                foreach (var p in nave.Posizioni)
                {
                    Button btn = playerCorrente.PulsantiGriglia.First(b => (Point)b.Tag == p);
                    btn.BackColor = Color.DarkBlue; // nave piazzata
                }
            }
        }

        // Click su cella: posiziona la nave
        private void Btn_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn == null || !(btn.Tag is Point)) return;

            Point p = (Point)btn.Tag; // prendi coordinate

            if (playerCorrente.PosizionaNaveCorrente(p)) // prova posizionamento
            {
                playerCorrente.AggiornaUI();
                Btn_MouseLeave(null, null); // aggiorna colori

                // se finito di posizionare le navi
                if (!playerCorrente.HaNaviDaPosizionare())
                {
                    if (isPvP && playerCorrente == player1)
                    {
                        // passa al player 2
                        MessageBox.Show("Giocatore 1 ha finito! Tocca al Giocatore 2.");
                        RimuoviGriglia(player1);
                        playerCorrente = player2;
                        CreaGriglia(playerCorrente);
                        Styler();
                        AggiornaUI();
                    }
                    else
                    {
                        // avvio partita
                        if (!isPvP)
                        {
                            MessageBox.Show("Tutte le navi posizionate! Inizio contro il computer.");
                            PvAI gameForm = new PvAI(playerCorrente, player2);
                            this.Hide();
                            gameForm.FormClosed += (s, args) => this.Close();
                            gameForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Tutte le navi posizionate! Inizia il PvP.");
                            PvP gameForm = new PvP(player1, player2);
                            this.Hide();
                            gameForm.FormClosed += (s, args) => this.Close();
                            gameForm.Show();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Non puoi mettere la nave qui!"); // posizione sbagliata
            }

            AggiornaUI();
        }

        private void RimuoviGriglia(Player player)
        {
            foreach (var btn in player.PulsantiGriglia)
                this.Controls.Remove(btn); // rimuove la vecchia griglia dal form
        }

        // Aggiorna i testi dell'interfaccia
        private void AggiornaUI()
        {
            if (playerCorrente.HaNaviDaPosizionare())
            {
                var nave = playerCorrente.NaveCorrente;
                lbl_NaveCorrente.Text = $"Nave corrente: {nave.Nome} ({nave.Lunghezza} celle)";
                lbl_Orientamento.Text = $"Orientamento: {(playerCorrente.Verticale ? "Verticale" : "Orizzontale")}";
                lbl_NaviRimanenti.Text = $"Navi rimanenti: {playerCorrente.Flotta.Count - playerCorrente.Flotta.IndexOf(playerCorrente.NaveCorrente)}";
            }
            else
            {
                lbl_NaveCorrente.Text = "Tutte le navi posizionate!";
                lbl_Orientamento.Text = "";
                lbl_NaviRimanenti.Text = "0";
            }
        }

        // cambia orientamento nave
        private void btn_Ruota_Click(object sender, EventArgs e)
        {
            playerCorrente.Verticale = !playerCorrente.Verticale;
            AggiornaUI();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close(); // chiude la schermata di posizionamento
        }

        // stile grafico form
        private void Styler()
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(30, 30, 30); // sfondo scuro

            // personalizzazione label
            lbl_NaveCorrente.ForeColor = Color.White;
            lbl_NaveCorrente.Font = new Font("Arial", 28, FontStyle.Bold);

            lbl_Orientamento.ForeColor = Color.White;
            lbl_Orientamento.Font = new Font("Arial", 24);

            lbl_NaviRimanenti.ForeColor = Color.White;
            lbl_NaviRimanenti.Font = new Font("Arial", 24);

            // posizionamento pulsanti
            int btnWidth = 200;
            int btnHeight = 70;
            int spacing = 50;

            btn_Ruota.Size = new Size(btnWidth, btnHeight);
            btn_Cancel.Size = new Size(btnWidth, btnHeight);

            int startX = (this.Width - (btn_Ruota.Width + btn_Cancel.Width + spacing)) / 2;
            int startY = this.Height - btnHeight - 100;

            btn_Ruota.Location = new Point(startX, startY);
            btn_Cancel.Location = new Point(startX + btnWidth + spacing, startY);

            btn_Ruota.BackColor = Color.SteelBlue;
            btn_Cancel.BackColor = Color.Firebrick;

            btn_Ruota.ForeColor = Color.White;
            btn_Cancel.ForeColor = Color.White;

            btn_Ruota.FlatStyle = FlatStyle.Flat;
            btn_Cancel.FlatStyle = FlatStyle.Flat;

            // aggiorna posizione griglia se già creata
            if (playerCorrente != null && playerCorrente.PulsantiGriglia.Count > 0)
            {
                int size = 50;
                int gridWidth = size * 10;
                int gridHeight = size * 10;
                int gridStartX = (this.Width - gridWidth) / 2;
                int gridStartY = (this.Height - gridHeight) / 2;

                foreach (var btn in playerCorrente.PulsantiGriglia)
                {
                    Point p = (Point)btn.Tag;
                    btn.Size = new Size(size, size);
                    btn.Location = new Point(gridStartX + p.X * size, gridStartY + p.Y * size);
                    btn.BackColor = Color.LightBlue; // reset colori base
                }
            }
        }
    }
}
