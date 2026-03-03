using System;
using System.Drawing;
using System.Windows.Forms;
using NAudio.Wave;

namespace La_Fattoria_Degli_Animali
{
    public partial class Form1 : Form
    {
        Fattoria fattoria = new Fattoria();

        Cane cane = new Cane();
        Gatto gatto = new Gatto();
        Mucca mucca = new Mucca();

        public Form1()
        {
            InitializeComponent();
            InizializzaStile();
            InizializzaFattoria();
        }

        private void InizializzaStile()
        {
            // Form
            this.BackColor = Color.FromArgb(245, 222, 179); // beige caldo tipo paglia
            this.Text = "Fattoria degli Animali";
            this.Size = new Size(500, 300);
            this.Font = new Font("Georgia", 10, FontStyle.Regular);

            // Panel Title
            pnl_Title.BackColor = Color.SaddleBrown; // marrone legno
            pnl_Title.Dock = DockStyle.Top;
            pnl_Title.Height = 60;

            Label lblTitle = new Label();
            lblTitle.Text = "🐄 Fattoria degli Animali 🐕";
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Georgia", 18, FontStyle.Bold);
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            pnl_Title.Controls.Add(lblTitle);

            // Label nome animale
            lblNomeAnimale.BackColor = Color.FromArgb(255, 248, 220); // beige chiaro
            lblNomeAnimale.BorderStyle = BorderStyle.FixedSingle;
            lblNomeAnimale.Font = new Font("Georgia", 12, FontStyle.Bold);
            lblNomeAnimale.TextAlign = ContentAlignment.MiddleCenter;
            lblNomeAnimale.Size = new Size(460, 30);
            lblNomeAnimale.Location = new Point(20, 200);
            lblNomeAnimale.Text = ""; // vuota all'inizio
        }

        private void InizializzaFattoria()
        {
            // Aggiungo animali alla fattoria
            fattoria.AggiungiAnimale(cane);
            fattoria.AggiungiAnimale(gatto);
            fattoria.AggiungiAnimale(mucca);

            // Iscrivo l'evento
            fattoria.VersoRiprodotto += RiproduciVersoHandler;

            // Imposto immagini PictureBox e posizione
            int startX = 20;
            int startY = 80;
            int spacing = 120;

            pbCane.ImageLocation = cane.ImmaginePath;
            pbCane.Size = new Size(100, 100);
            pbCane.Location = new Point(startX, startY);

            pbGatto.ImageLocation = gatto.ImmaginePath;
            pbGatto.Size = new Size(100, 100);
            pbGatto.Location = new Point(startX + spacing, startY);

            pbMucca.ImageLocation = mucca.ImmaginePath;
            pbMucca.Size = new Size(100, 100);
            pbMucca.Location = new Point(startX + spacing * 2, startY);

            // Stile PictureBox
            foreach (var pb in new PictureBox[] { pbCane, pbGatto, pbMucca })
            {
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.BorderStyle = BorderStyle.Fixed3D;
                pb.Cursor = Cursors.Hand;
                this.Controls.Add(pb); // se non sono già aggiunti dal Designer
            }

            // Click eventi
            pbCane.Click += (s, e) => { fattoria.RichiediVerso(cane); };
            pbGatto.Click += (s, e) => { fattoria.RichiediVerso(gatto); };
            pbMucca.Click += (s, e) => { fattoria.RichiediVerso(mucca); };
        }

        private void RiproduciVersoHandler(string versoPath, string nome)
        {
            try
            {
                lblNomeAnimale.Text = $"Animale: {nome}";

                using (var audioFile = new AudioFileReader(versoPath))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();

                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                        Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore riproduzione audio: {ex.Message}");
            }
        }
    }
}
