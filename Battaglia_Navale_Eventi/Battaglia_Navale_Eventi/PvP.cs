using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Battaglia_Navale_Eventi
{
    public partial class PvP : Form
    {
        // Oggetti di gioco
        private Player Player1;
        private Player Player2;
        private Player giocatoreCorrente;
        private Player avversario;
        private int mosse = 0;
        private HashSet<Nave> naviGiaAffondate = new HashSet<Nave>(); //Una lista veloce che non ammette di suo duplicati, e non ha una indice
        private SoundManager soundManager;


        // Liste controlli
        private List<Control> controlliTurno = new List<Control>(); // Lista generica per pulire tutto a fine turno
        private List<Button> grigliaAvversariaButtons = new List<Button>();

        // Controlli UI Statici7
        private Label lbl_Mosse;
        private Label lbl_NaviRimanenti;
        private ListBox lst_Log;
        private Button btn_Close;

        // Costanti di Layout
        private const int CELL_SIZE = 45; // Celle più grandi
        private const int GRID_GAP = 150; // Spazio tra le due griglie

        public PvP(Player p1, Player p2)
        {
            InitializeComponent();
            Player1 = p1;
            Player2 = p2;
            giocatoreCorrente = Player1;
            avversario = Player2;
            this.Text = "Battaglia Navale - PvP";
            soundManager = new SoundManager();
        }

        private void PvP_Load(object sender, EventArgs e)
        {
            SetupFormBase();
            MostraSchermataPassaggio();
        }

        private void SetupFormBase()
        {
            //SETUP GRAFICO DEL FORM
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(32, 32, 36);
            btn_Close = new Button
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
            int logWidth = 900;
            lst_Log = new ListBox
            {
                BackColor = Color.FromArgb(20, 20, 20),
                ForeColor = Color.LimeGreen,
                Font = new Font("Consolas", 11),
                Size = new Size(logWidth, 120),
                Location = new Point((Screen.PrimaryScreen.Bounds.Width - logWidth) / 2, Screen.PrimaryScreen.Bounds.Height - 140),
                BorderStyle = BorderStyle.None
            };
            this.Controls.Add(lst_Log);
        }

        private void MostraSchermataPassaggio()
        {
            PulisciInterfacciaTurno();

            //Mostra un pannello temporaneo che serve a guiocare in 2 persone
            Panel pnl = new Panel
            {
                Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height),
                BackColor = Color.FromArgb(25, 25, 30),
                Location = new Point(0, 0)
            };

            Label lbl = new Label
            {
                Text = $"TURNO DI: {giocatoreCorrente.Nome}",
                Font = new Font("Segoe UI Light", 48, FontStyle.Regular),
                ForeColor = Color.White,
                AutoSize = true
            };
            // Centra la label nel pannello
            lbl.Location = new Point((pnl.Width - lbl.PreferredWidth) / 2, (pnl.Height / 2) - 100);

            Button btn = new Button
            {
                Text = "AVVIA IL TURNO",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Size = new Size(300, 80),
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Location = new Point((pnl.Width - btn.Width) / 2, (pnl.Height / 2) + 50);

            btn.Click += (s, e) =>
            {
                this.Controls.Remove(pnl);
                pnl.Dispose();
                CostruisciInterfacciaDiGioco();
            };

            pnl.Controls.Add(lbl);
            pnl.Controls.Add(btn);
            this.Controls.Add(pnl);
            pnl.BringToFront();
            btn_Close.BringToFront(); // La X deve stare sempre sopra
        }

        private void PulisciInterfacciaTurno()
        {
            foreach (var c in controlliTurno)
            {
                this.Controls.Remove(c);
                c.Dispose();
            }
            controlliTurno.Clear();
            grigliaAvversariaButtons.Clear();
        }

        private void CostruisciInterfacciaDiGioco()
        {
            int screenW = Screen.PrimaryScreen.Bounds.Width;
            int screenH = Screen.PrimaryScreen.Bounds.Height;

            // Calcolo larghezza totale delle due griglie + spazio
            int gridPixelSize = 10 * CELL_SIZE;
            int totalContentWidth = (gridPixelSize * 2) + GRID_GAP;

            // Coordinate di partenza per centrare tutto
            int startX = (screenW - totalContentWidth) / 2;
            int startY = 150; // Margine dall'alto

            // --- HEADER (Stats) ---
            lbl_Mosse = CreaLabelStat($"Mosse: {mosse}", new Point(startX, 60), Color.White);
            lbl_NaviRimanenti = CreaLabelStat($"Navi Nemiche: {avversario.Flotta.Count(n => !n.Affondata)}", new Point(startX + totalContentWidth - 300, 60), Color.Orange); // Allineato a destra

            // --- GRIGLIA SINISTRA (PROPRIA) ---
            AggiungiTitoloGriglia("LA TUA FLOTTA", startX, startY - 40, Color.Gray);
            CreaGriglia(startX, startY, true);

            // --- GRIGLIA DESTRA (AVVERSARIA) ---
            int startX_Enemy = startX + gridPixelSize + GRID_GAP;
            AggiungiTitoloGriglia($"ATTACCO ({avversario.Nome})", startX_Enemy, startY - 40, Color.OrangeRed);
            CreaGriglia(startX_Enemy, startY, false);
        }

        private Label CreaLabelStat(string text, Point loc, Color col)
        {
            Label l = new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = col,
                Location = loc,
                AutoSize = true
            };
            this.Controls.Add(l);
            controlliTurno.Add(l);
            return l;
        }

        private void AggiungiTitoloGriglia(string testo, int x, int y, Color colore)
        {
            Label l = new Label
            {
                Text = testo,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = colore,
                Location = new Point(x, y),
                AutoSize = true
            };
            this.Controls.Add(l);
            controlliTurno.Add(l);
        }

        private void CreaGriglia(int startX, int startY, bool isPropria)
        {
            // Pannello decorativo sotto la griglia (Bordo)
            Panel sfondo = new Panel
            {
                Location = new Point(startX - 2, startY - 2),
                Size = new Size((10 * CELL_SIZE) + 4, (10 * CELL_SIZE) + 4),
                BackColor = isPropria ? Color.DimGray : Color.Maroon // Grigio per noi, Rosso per nemico
            };
            this.Controls.Add(sfondo);
            controlliTurno.Add(sfondo); // Lo aggiungiamo per rimuoverlo al cambio turno
            sfondo.SendToBack(); // Dietro i bottoni

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    Button btn = new Button
                    {
                        Size = new Size(CELL_SIZE, CELL_SIZE),
                        Location = new Point(startX + x * CELL_SIZE, startY + y * CELL_SIZE),
                        Tag = new Point(x, y),
                        FlatStyle = FlatStyle.Flat,
                        Margin = new Padding(0)
                    };
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 48);

                    if (isPropria)
                    {
                        // Logica VISUALIZZAZIONE FLOTTA
                        btn.Enabled = false; // Non cliccabile
                        var cella = giocatoreCorrente.Griglia.Celle[x, y];
                        switch (cella.Stato)
                        {
                            case StatoCella.Nave: btn.BackColor = Color.Gray; break;
                            case StatoCella.Colpita:
                                btn.BackColor = (cella.NaveAssociata != null && cella.NaveAssociata.Affondata) ? Color.Black : Color.Orange;
                                break;
                            case StatoCella.Mancata: btn.BackColor = Color.LightBlue; break;
                            default: btn.BackColor = Color.FromArgb(50, 50, 60); break;
                        }
                    }
                    else
                    {
                        // Logica GRIGLIA ATTACCO
                        btn.BackColor = Color.FromArgb(70, 70, 80); // Nebbia
                        btn.Cursor = Cursors.Hand;

                        var cella = avversario.Griglia.Celle[x, y];

                        if (cella.Stato == StatoCella.Colpita)
                        {
                            btn.BackColor = (cella.NaveAssociata != null && cella.NaveAssociata.Affondata) ? Color.DarkRed : Color.Red;
                            btn.Enabled = false;
                        }
                        else if (cella.Stato == StatoCella.Mancata)
                        {
                            btn.BackColor = Color.SteelBlue;
                            btn.Enabled = false;
                        }
                        else
                        {
                            // Eventi click solo su celle vergini
                            btn.MouseEnter += (s, e) => { if (((Button)s).Enabled) ((Button)s).BackColor = Color.LimeGreen; };
                            btn.MouseLeave += (s, e) => { if (((Button)s).Enabled) ((Button)s).BackColor = Color.FromArgb(70, 70, 80); };
                            btn.Click += GrigliaAvversaria_Click;
                        }
                        grigliaAvversariaButtons.Add(btn);
                    }

                    this.Controls.Add(btn);
                    btn.BringToFront(); // Assicura che stia sopra lo sfondo
                    controlliTurno.Add(btn);
                }
            }
        }

        private async void GrigliaAvversaria_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Point p = (Point)btn.Tag;

            // Blocca input
            foreach (var b in grigliaAvversariaButtons) b.Enabled = false;

            mosse++;
            bool colpito = avversario.Griglia.ColpisciCella(p);

            if (colpito)
            {
                btn.BackColor = Color.Red;
                Log($"{giocatoreCorrente.Nome} >> COLPITO in {GetCoord(p)}!");
                ReproduciSuono(true);
                VerificaNaviAffondate();

                if (avversario.HaPerso())
                {
                    MessageBox.Show($"{giocatoreCorrente.Nome} ha VINTO!", "Vittoria");
                    this.Close();
                    return;
                }
            }
            else
            {
                btn.BackColor = Color.SteelBlue;
                Log($"{giocatoreCorrente.Nome} >> ACQUA in {GetCoord(p)}");
                ReproduciSuono(false);
            }

            AggiornaStats();
            await Task.Delay(1500);
            CambiaTurno();
        }

        private void CambiaTurno()
        {
            var temp = giocatoreCorrente;
            giocatoreCorrente = avversario;
            avversario = temp;
            MostraSchermataPassaggio();
        }

        private void VerificaNaviAffondate()
        {
            foreach (var nave in avversario.Flotta)
            {
                if (nave.Affondata && !naviGiaAffondate.Contains(nave))
                {
                    naviGiaAffondate.Add(nave);
                    Log($"*** {nave.Nome.ToUpper()} AFFONDATA! ***");

                    // Segna in nero le navi morte
                    foreach (var pos in nave.Posizioni)
                    {
                        var btn = grigliaAvversariaButtons.FirstOrDefault(b => (Point)b.Tag == pos);
                        if (btn != null) btn.BackColor = Color.Black;
                    }
                    try
                    {
                        soundManager.PlayAffondata();
                    } catch { }
                }
            }
        }

        private void ReproduciSuono(bool colpito)
        {
            try
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
            catch { }
        }

        private void AggiornaStats()
        {
            lbl_Mosse.Text = $"Mosse: {mosse}";
            lbl_NaviRimanenti.Text = $"Navi Nemiche: {avversario.Flotta.Count(n => !n.Affondata)}";
        }

        private void Log(string msg) => lst_Log.Items.Insert(0, msg);
        private string GetCoord(Point p) => $"{(char)('A' + p.X)}{p.Y + 1}";
    }
}