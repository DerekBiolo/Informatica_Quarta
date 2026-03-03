using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Torre_di_hannoi_forms
{
    public partial class FSimulazione : Form
    {
        int numeroDischi;
        int mosseEffettuate = 0;
        List<Panel> torreA = new List<Panel>();
        List<Panel> torreB = new List<Panel>();
        List<Panel> torreC = new List<Panel>();

        Stopwatch stopwatch = new Stopwatch();
        System.Windows.Forms.Timer timerUI = new System.Windows.Forms.Timer();

        public FSimulazione(int n)
        {
            InitializeComponent();
            numeroDischi = n;

            Styler();
            InizializzaTorri();
            InizializzaLabels();
        }

        private void Styler()
        {
            // Gradient verticale sfondo
            this.Paint += (s, e) =>
            {
                using var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                    this.ClientRectangle, Color.Beige, Color.White,
                    System.Drawing.Drawing2D.LinearGradientMode.Vertical);
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            };

            // Doppio buffering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            this.UpdateStyles();

            // Stile etichette
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label lbl)
                    lbl.ForeColor = Color.DarkSlateGray;
            }

            // Stile pannelli torri
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Panel pnl && (pnl.Name == "pnl_TorreA" || pnl.Name == "pnl_TorreB" || pnl.Name == "pnl_TorreC"))
                {
                    pnl.BackColor = Color.LightGray;
                    pnl.BorderStyle = BorderStyle.Fixed3D;
                }
            }
        }

        private void InizializzaLabels()
        {
            lbl_MosseMinime.Text = $"Numero minimo di mosse: {Math.Pow(2, numeroDischi) - 1}";
            double tempoPrevisto = (Math.Pow(2, numeroDischi) - 1) * 1.6;
            lbl_TempoPrevisto.Text = $"Tempo previsto (stima): {tempoPrevisto:F3} s";
            lbl_NumeroMosse.Text = "Numero di mosse effettuate: 0";
            lbl_Timer.Text = "Tempo trascorso: 0,000 s";
        }

        private void InizializzaTorri()
        {
            int[] xPos = { pnl_TorreA.Left + pnl_TorreA.Width / 2,
                           pnl_TorreB.Left + pnl_TorreB.Width / 2,
                           pnl_TorreC.Left + pnl_TorreC.Width / 2 };

            int baseY = pnl_TorreA.Bottom - 10;
            int diskHeight = pnl_TorreA.Height / numeroDischi;
            int diskWidthBase = 120;
            int diskStep = 10;

            Color baseColore = ScegliColoreBase();

            for (int i = numeroDischi; i >= 1; i--)
            {
                Color coloreDisco = CalcolaColoreDisco(baseColore, i, numeroDischi);
                int larghezza = diskWidthBase - (numeroDischi - i) * diskStep;

                Panel disco = CreaDisco(larghezza, diskHeight, coloreDisco);
                disco.Left = xPos[0] - disco.Width / 2;
                disco.Top = baseY - (numeroDischi - i + 1) * diskHeight;

                this.Controls.Add(disco);
                torreA.Add(disco);
                disco.BringToFront();
            }
        }

        private Color ScegliColoreBase()
        {
            Color[] coloriBase = {
                Color.FromArgb(255,100,100), Color.FromArgb(255,150,200), Color.FromArgb(100,200,100),
                Color.FromArgb(255,220,100), Color.FromArgb(100,150,255), Color.FromArgb(200,100,255),
                Color.FromArgb(255,150,50), Color.FromArgb(150,100,50), Color.FromArgb(200,200,200),
                Color.FromArgb(255,255,255), Color.FromArgb(0,0,0), Color.FromArgb(100,255,200),
                Color.FromArgb(150,0,255), Color.FromArgb(255,0,150), Color.FromArgb(200,255,100),
                Color.FromArgb(255,200,255), Color.FromArgb(200,150,100), Color.FromArgb(150,150,150),
                Color.FromArgb(255,215,0), Color.FromArgb(128,0,128)
            };
            Random rnd = new Random();
            return coloriBase[rnd.Next(coloriBase.Length)];
        }

        private Color CalcolaColoreDisco(Color baseColore, int indice, int numeroDischi)
        {
            float fattore = (float)(indice - 1) / (numeroDischi - 1);
            int r = (int)(baseColore.R * (0.6f + 0.4f * fattore));
            int g = (int)(baseColore.G * (0.6f + 0.4f * fattore));
            int b = (int)(baseColore.B * (0.6f + 0.4f * fattore));
            return Color.FromArgb(r, g, b);
        }

        private Panel CreaDisco(int larghezza, int altezza, Color colore)
        {
            Panel disco = new Panel { Width = larghezza, Height = altezza, BorderStyle = BorderStyle.FixedSingle };

            Bitmap bmp = new Bitmap(larghezza, altezza);
            using Graphics gfx = Graphics.FromImage(bmp);
            using var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                new Rectangle(0, 0, larghezza, altezza),
                ControlPaint.LightLight(colore),
                ControlPaint.Dark(colore),
                System.Drawing.Drawing2D.LinearGradientMode.Vertical);
            gfx.FillRectangle(brush, 0, 0, larghezza, altezza);
            using Pen pen = new Pen(ControlPaint.DarkDark(colore), 2);
            gfx.DrawRectangle(pen, 0, 0, larghezza - 1, altezza - 1);

            disco.BackgroundImage = bmp;
            disco.BackgroundImageLayout = ImageLayout.Stretch;
            return disco;
        }

        private async void FSimulazione_Load(object sender, EventArgs e)
        {
            stopwatch.Start();
            timerUI.Interval = 100;
            timerUI.Tick += (s, ev) => AggiornaUI();
            timerUI.Start();

            await Hanoi(numeroDischi, torreA, torreC, torreB);

            stopwatch.Stop();
            timerUI.Stop();

            MessageBox.Show($"Simulazione completata!\n\nMosse: {mosseEffettuate}\nTempo totale: {stopwatch.Elapsed.TotalSeconds:F3} s",
                            "Fine", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AggiornaUI()
        {
            lbl_Timer.Text = $"Tempo trascorso: {stopwatch.Elapsed.TotalSeconds:F3} s";
            lbl_NumeroMosse.Text = $"Numero di mosse effettuate: {mosseEffettuate}";
        }

        private async Task Hanoi(int n, List<Panel> source, List<Panel> target, List<Panel> auxiliary)
        {
            if (n == 1)
            {
                await MoveDisk(source, target);
            }
            else
            {
                await Hanoi(n - 1, source, auxiliary, target);
                await MoveDisk(source, target);
                await Hanoi(n - 1, auxiliary, target, source);
            }
        }

        private async Task MoveDisk(List<Panel> source, List<Panel> target)
        {
            if (source.Count == 0) return;

            Panel disco = source.Last();
            source.RemoveAt(source.Count - 1);

            CalcoloTorre(target, out Panel torreDestinazione);

            int baseY = torreDestinazione.Bottom - 10;
            int altezzaDisco = torreDestinazione.Height / numeroDischi;
            int yFinal = baseY - (target.Count + 1) * altezzaDisco;
            int xFinal = torreDestinazione.Left + (torreDestinazione.Width - disco.Width) / 2;

            await AnimazioneDisco(disco, xFinal, yFinal);

            target.Add(disco);
            mosseEffettuate++;
            AggiornaUI();

            await Task.Delay(200);
        }

        private async Task AnimazioneDisco(Panel disco, int xFinal, int yFinal)
        {
            int step = 5, delay = 5, altezzaVolo = 50;

            while (disco.Top > yFinal - altezzaVolo)
            {
                await Task.Delay(delay);
                Invoke((MethodInvoker)(() => disco.Top -= step));
            }

            while (Math.Abs(disco.Left - xFinal) > step)
            {
                int direzione = disco.Left < xFinal ? 1 : -1;
                await Task.Delay(delay);
                Invoke((MethodInvoker)(() => disco.Left += step * direzione));
            }

            while (disco.Top < yFinal)
            {
                await Task.Delay(delay);
                Invoke((MethodInvoker)(() => disco.Top += step));
            }

            Invoke((MethodInvoker)(() =>
            {
                disco.Top = yFinal;
                disco.Left = xFinal;
                disco.BringToFront();
            }));
        }

        private void CalcoloTorre(List<Panel> torre, out Panel pnl_Torre)
        {
            pnl_Torre = torre == torreA ? pnl_TorreA :
                        torre == torreB ? pnl_TorreB : pnl_TorreC;
        }
    }
}
