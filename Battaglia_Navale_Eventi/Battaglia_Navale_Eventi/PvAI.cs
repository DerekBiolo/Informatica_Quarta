using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Battaglia_Navale_Eventi
{
    public partial class PvAI : Form
    {
        // Oggetti di gioco
        private Player player;
        private Player ai;
        private int mosse = 0;
        private HashSet<Nave> naviGiaAffondate = new HashSet<Nave>();
        private SoundManager soundManager;

        // Variabili IA
        private Point? ultimoColpo = null;
        private List<Point> obiettiviIA = new List<Point>();
        private Direzione? direzioneAttacco = null;
        private Point? primoColpo = null;
        private enum Direzione { Su, Giu, Sinistra, Destra }

        // Liste per gestire i pulsanti generati via codice
        private List<Button> playerGridButtons = new List<Button>();
        private List<Button> aiGridButtons = new List<Button>();

        // NOTA: Ho rimosso le dichiarazioni di lbl_Mosse, lst_Log, ecc. qui sopra
        // per evitare il conflitto "Ambiguità". Il codice userà quelli del Designer
        // o li creerà dinamicamente se non esistono.

        // Costanti Layout
        private const int CELL_SIZE = 45;
        private const int GRID_GAP = 150;

        public PvAI(Player umano, Player computer)
        {
            InitializeComponent();
            player = umano;
            ai = computer;
            this.Text = "Battaglia Navale - Vs Computer";
            soundManager = new SoundManager();
        }

        private void PvAI_Load(object sender, EventArgs e)
        {
            // Pulisce eventuali vecchi controlli per evitare duplicati visivi
            this.Controls.Clear();

            SetupFormBase();
            CostruisciInterfaccia();
        }

        private void SetupFormBase()
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(32, 32, 36);

            // Tasto Chiudi (X)
            Button btn_Close = new Button
            {
                Text = "X",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Size = new Size(40, 40),
                Location = new Point(Screen.PrimaryScreen.Bounds.Width - 50, 10),
                BackColor = Color.IndianRed,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btn_Close.FlatAppearance.BorderSize = 0;
            btn_Close.Click += (s, e) => this.Close();
            this.Controls.Add(btn_Close);

            // Creazione o Stile del Log Box
            int logWidth = 900;

            // Creiamo un NUOVO logbox per assicurarci che sia stilizzato correttamente
            // e ignoriamo quello vecchio del designer per evitare conflitti grafici
            lst_Log = new ListBox
            {
                BackColor = Color.FromArgb(20, 20, 20),
                ForeColor = Color.Cyan,
                Font = new Font("Consolas", 11),
                Size = new Size(logWidth, 120),
                Location = new Point((Screen.PrimaryScreen.Bounds.Width - logWidth) / 2, Screen.PrimaryScreen.Bounds.Height - 140),
                BorderStyle = BorderStyle.None
            };
            this.Controls.Add(lst_Log);
        }

        private void CostruisciInterfaccia()
        {
            int screenW = Screen.PrimaryScreen.Bounds.Width;

            // Calcoli di posizionamento
            int gridPixelSize = 10 * CELL_SIZE;
            int totalContentWidth = (gridPixelSize * 2) + GRID_GAP;
            int startX = (screenW - totalContentWidth) / 2;
            int startY = 150;

            // --- HEADER ---
            // Creiamo nuove label pulite assegnandole alle variabili
            lbl_Mosse = CreaLabel("Mosse: 0", new Point(startX, 60), Color.White);
            lbl_NaviRimanenti = CreaLabel($"Navi CPU: {ai.Flotta.Count}", new Point(startX + totalContentWidth - 250, 60), Color.Orange);

            // --- GRIGLIA GIOCATORE (SX) ---
            AggiungiTitolo("LA TUA BASE", startX, startY - 40, Color.LightGray);
            CreaGrigliaVisuale(player, new Point(startX, startY));

            // --- GRIGLIA IA (DX) ---
            int startX_AI = startX + gridPixelSize + GRID_GAP;
            AggiungiTitolo("RADAR NEMICO (CPU)", startX_AI, startY - 40, Color.OrangeRed);
            CreaGrigliaInterattiva(ai, new Point(startX_AI, startY));
        }

        private void CreaGrigliaVisuale(Player p, Point start)
        {
            CreaSfondoGriglia(start, Color.DimGray);

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    Button btn = new Button
                    {
                        Size = new Size(CELL_SIZE, CELL_SIZE),
                        Location = new Point(start.X + x * CELL_SIZE, start.Y + y * CELL_SIZE),
                        Tag = new Point(x, y),
                        FlatStyle = FlatStyle.Flat,
                        Enabled = false
                    };
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(50, 50, 60);

                    var cella = p.Griglia.Celle[x, y];
                    btn.BackColor = (cella.Stato == StatoCella.Nave) ? Color.Gray : Color.FromArgb(40, 40, 50);

                    this.Controls.Add(btn);
                    btn.BringToFront();
                    playerGridButtons.Add(btn);
                }
            }
        }

        private void CreaGrigliaInterattiva(Player p, Point start)
        {
            CreaSfondoGriglia(start, Color.Maroon);

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    Button btn = new Button
                    {
                        Size = new Size(CELL_SIZE, CELL_SIZE),
                        Location = new Point(start.X + x * CELL_SIZE, start.Y + y * CELL_SIZE),
                        Tag = new Point(x, y),
                        FlatStyle = FlatStyle.Flat,
                        BackColor = Color.FromArgb(60, 60, 70),
                        Cursor = Cursors.Hand
                    };
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = Color.SteelBlue;

                    btn.Click += Player_Click;
                    btn.MouseEnter += (s, e) => { if (((Button)s).Enabled) ((Button)s).BackColor = Color.LimeGreen; };
                    btn.MouseLeave += (s, e) => { if (((Button)s).Enabled) ((Button)s).BackColor = Color.FromArgb(60, 60, 70); };

                    this.Controls.Add(btn);
                    btn.BringToFront();
                    aiGridButtons.Add(btn);
                }
            }
        }

        private async void Player_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            Point p = (Point)btn.Tag;

            DisabilitaInput(true);

            mosse++;
            bool colpito = ai.Griglia.ColpisciCella(p);

            if (colpito)
            {
                btn.BackColor = Color.Red;
                Log($"TU >> COLPITO in {GetCoord(p)}!");
                ReproduciSuono(true);
                VerificaNaviAffondate(ai, false);
            }
            else
            {
                btn.BackColor = Color.SteelBlue;
                Log($"TU >> ACQUA in {GetCoord(p)}");
                ReproduciSuono(false);
            }

            btn.Enabled = false;
            AggiornaContatori();

            if (ai.HaPerso())
            {
                MessageBox.Show("COMPLIMENTI! Hai sconfitto il computer!", "VITTORIA");
                this.Close();
                return;
            }

            await Task.Delay(1000);
            TurnoIA();

            if (!player.HaPerso()) DisabilitaInput(false);
        }

        private void TurnoIA()
        {
            Random rnd = new Random();
            Point p;

            if (obiettiviIA.Count > 0)
            {
                p = obiettiviIA[0];
                obiettiviIA.RemoveAt(0);
            }
            else
            {
                do
                {
                    p = new Point(rnd.Next(0, 10), rnd.Next(0, 10));
                } while (player.Griglia.Celle[p.X, p.Y].Stato == StatoCella.Colpita ||
                         player.Griglia.Celle[p.X, p.Y].Stato == StatoCella.Mancata);
            }

            var btnTarget = playerGridButtons.FirstOrDefault(b => (Point)b.Tag == p);

            if (player.Griglia.ColpisciCella(p))
            {
                if (btnTarget != null) btnTarget.BackColor = Color.Red;
                Log($"CPU >> HA COLPITO la tua nave in {GetCoord(p)}!");
                ReproduciSuono(true);

                GestioneColpoRiuscito(p);
                VerificaNaviAffondate(player, true);
            }
            else
            {
                if (btnTarget != null) btnTarget.BackColor = Color.SteelBlue;
                Log($"CPU >> Ha mancato in {GetCoord(p)}");
                ReproduciSuono(false);

                if (direzioneAttacco.HasValue && primoColpo.HasValue)
                {
                    CambiaDirezione();
                }
            }

            AggiornaContatori();

            if (player.HaPerso())
            {
                MessageBox.Show("GAME OVER. L'IA ha distrutto la tua flotta.", "SCONFITTA");
                this.Close();
            }
        }

        private void GestioneColpoRiuscito(Point colpo)
        {
            if (ultimoColpo == null)
            {
                ultimoColpo = colpo;
                primoColpo = colpo;
                direzioneAttacco = null;
                AggiungiCelleAdiacenti(colpo);
            }
            else
            {
                if (!direzioneAttacco.HasValue)
                {
                    direzioneAttacco = DeterminaDirezione(primoColpo.Value, colpo);
                    obiettiviIA.Clear();
                    AggiungiCellaInDirezione(colpo, direzioneAttacco.Value);
                    AggiungiCellaInDirezione(primoColpo.Value, DirezioneOpposta(direzioneAttacco.Value));
                }
                else
                {
                    AggiungiCellaInDirezione(colpo, direzioneAttacco.Value);
                }
                ultimoColpo = colpo;
            }
        }

        private void CambiaDirezione()
        {
            if (direzioneAttacco.HasValue && primoColpo.HasValue)
            {
                obiettiviIA.Clear();
                direzioneAttacco = DirezioneOpposta(direzioneAttacco.Value);
                AggiungiCellaInDirezione(primoColpo.Value, direzioneAttacco.Value);
            }
        }

        private void AggiungiCelleAdiacenti(Point p)
        {
            Point[] adiacenti = { new Point(p.X, p.Y - 1), new Point(p.X, p.Y + 1), new Point(p.X - 1, p.Y), new Point(p.X + 1, p.Y) };
            foreach (var punto in adiacenti)
            {
                if (PuntoValido(punto) && !obiettiviIA.Contains(punto)) obiettiviIA.Add(punto);
            }
        }

        private void AggiungiCellaInDirezione(Point p, Direzione dir)
        {
            Point nuovoPunto = p;
            switch (dir)
            {
                case Direzione.Su: nuovoPunto = new Point(p.X, p.Y - 1); break;
                case Direzione.Giu: nuovoPunto = new Point(p.X, p.Y + 1); break;
                case Direzione.Sinistra: nuovoPunto = new Point(p.X - 1, p.Y); break;
                case Direzione.Destra: nuovoPunto = new Point(p.X + 1, p.Y); break;
            }
            if (PuntoValido(nuovoPunto) && !obiettiviIA.Contains(nuovoPunto)) obiettiviIA.Insert(0, nuovoPunto);
        }

        private bool PuntoValido(Point p)
        {
            return p.X >= 0 && p.X < 10 && p.Y >= 0 && p.Y < 10 &&
                   player.Griglia.Celle[p.X, p.Y].Stato != StatoCella.Colpita &&
                   player.Griglia.Celle[p.X, p.Y].Stato != StatoCella.Mancata;
        }

        private Direzione DeterminaDirezione(Point primo, Point secondo)
        {
            if (secondo.Y < primo.Y) return Direzione.Su;
            if (secondo.Y > primo.Y) return Direzione.Giu;
            if (secondo.X < primo.X) return Direzione.Sinistra;
            return Direzione.Destra;
        }

        private Direzione DirezioneOpposta(Direzione dir)
        {
            switch (dir) { case Direzione.Su: return Direzione.Giu; case Direzione.Giu: return Direzione.Su; case Direzione.Sinistra: return Direzione.Destra; default: return Direzione.Sinistra; }
        }

        private void VerificaNaviAffondate(Player targetPlayer, bool isTargetPlayerHuman)
        {
            foreach (var nave in targetPlayer.Flotta)
            {
                if (nave.Affondata && !naviGiaAffondate.Contains(nave))
                {
                    naviGiaAffondate.Add(nave);
                    string nome = isTargetPlayerHuman ? "LA TUA NAVE" : "NAVE NEMICA";
                    Log($"*** {nome} ({nave.Nome}) AFFONDATA! ***");

                    var listaBottoni = isTargetPlayerHuman ? playerGridButtons : aiGridButtons;
                    foreach (var pos in nave.Posizioni)
                    {
                        var btn = listaBottoni.FirstOrDefault(b => (Point)b.Tag == pos);
                        if (btn != null) btn.BackColor = Color.Black;
                    }

                    if (isTargetPlayerHuman)
                    {
                        ultimoColpo = null; primoColpo = null; direzioneAttacco = null; obiettiviIA.Clear();
                    }

                    try { SystemSounds.Asterisk.Play(); } catch { }
                }
            }
        }

        private void DisabilitaInput(bool disable)
        {
            foreach (var btn in aiGridButtons)
            {
                if (btn.BackColor == Color.FromArgb(60, 60, 70) || btn.BackColor == Color.LimeGreen)
                    btn.Enabled = !disable;
            }
        }

        private Label CreaLabel(string text, Point loc, Color col)
        {
            Label l = new Label { Text = text, Font = new Font("Segoe UI", 20, FontStyle.Bold), ForeColor = col, Location = loc, AutoSize = true };
            this.Controls.Add(l);
            return l;
        }

        private void AggiungiTitolo(string text, int x, int y, Color c)
        {
            Label l = new Label { Text = text, Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = c, Location = new Point(x, y), AutoSize = true };
            this.Controls.Add(l);
        }

        private void CreaSfondoGriglia(Point start, Color c)
        {
            Panel p = new Panel { Location = new Point(start.X - 2, start.Y - 2), Size = new Size((10 * CELL_SIZE) + 4, (10 * CELL_SIZE) + 4), BackColor = c };
            this.Controls.Add(p);
            p.SendToBack();
        }

        private void Log(string msg) { if (lst_Log != null) lst_Log.Items.Insert(0, msg); }
        private string GetCoord(Point p) => $"{(char)('A' + p.X)}{p.Y + 1}";
        private void AggiornaContatori()
        {
            if (lbl_Mosse != null) lbl_Mosse.Text = $"Mosse: {mosse}";
            if (lbl_NaviRimanenti != null) lbl_NaviRimanenti.Text = $"Navi CPU: {ai.Flotta.Count(n => !n.Affondata)}";
        }
        private void ReproduciSuono(bool colpito) 
        { try 
            { 
                if (colpito)
                {
                    soundManager.PlayColpita();
                }
                else
                {
                    soundManager.PlayMancata();
                }
            } 
            catch {}
        }
    }
}