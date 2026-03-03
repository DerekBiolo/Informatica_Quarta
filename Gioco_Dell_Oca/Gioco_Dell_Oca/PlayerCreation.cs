using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Gioco_Dell_Oca
{
    public partial class PlayerCreation : Form
    {
        public string[] NomiImmagini =
        {
            "Papera",
            "Patata",
            "Cane",
            "Bottiglia",
            "Artefatto",
            "Pedina"
        };

        public Image[] ImmaginiArray =
        {
            Image.FromFile("papera.png"),
            Image.FromFile("patata.png"),
            Image.FromFile("cane.png"),
            Image.FromFile("bottiglia.png"),
            Image.FromFile("artefatto.png"),
            Image.FromFile("pedina.png")
        };


        private bool isP1Ready = false;
        private bool isP2Ready = false;

        public int p1Index = 0;
        public int p2Index = 0;
        public string P1Name = String.Empty;
        public string P2Name = String.Empty;

        // Timer separati
        private Timer animTimerP1 = new Timer();
        private Timer animTimerP2 = new Timer();

        // Player 1 anim
        private Image animCurrentImageP1;
        private Image animNextImageP1;
        private int animStepP1;
        private int animMaxStepsP1;
        private int animStartXP1, animEndXP1;
        private float animStartScaleP1, animEndScaleP1;
        private bool animatingP1 = false;
        private int originalWidthP1, originalHeightP1;
        private int animNextStartXP1, animNextEndXP1;
        private float animNextStartScaleP1, animNextEndScaleP1;

        // Player 2 anim
        private Image animCurrentImageP2;
        private Image animNextImageP2;
        private int animStepP2;
        private int animMaxStepsP2;
        private int animStartXP2, animEndXP2;
        private float animStartScaleP2, animEndScaleP2;
        private bool animatingP2 = false;
        private int originalWidthP2, originalHeightP2;
        private int animNextStartXP2, animNextEndXP2;
        private float animNextStartScaleP2, animNextEndScaleP2;

        public PlayerCreation()
        {
            InitializeComponent();
        }

        private void PlayerCreation_Load(object sender, EventArgs e)
        {
            InizializeForm();
            AddDefaultImages();
            AnimationSettings();
        }

        private void AnimationSettings()
        {
            animTimerP1.Interval = 16; // ~60 FPS
            animTimerP1.Tick += AnimTimerP1_Tick;

            animTimerP2.Interval = 16;
            animTimerP2.Tick += AnimTimerP2_Tick;

        }


        private void InizializeForm()
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            // Calcolo dimensioni base per layout responsivo
            int centerX = this.Width / 2;
            int centerY = this.Height / 2;
            int quarterWidth = this.Width / 4;
            int threeQuarterWidth = (this.Width / 4) * 3;

            // Titolo centrato
            lbl_Title.Text = "Creazione Giocatori";
            lbl_Title.Font = new Font("Consolas", 28, FontStyle.Bold);
            lbl_Title.AutoSize = true;
            lbl_Title.Location = new Point(centerX - lbl_Title.Width / 2, 40);

            // Player 1 Label
            lbl_Player1.Text = "Player 1";
            lbl_Player1.Font = new Font("Consolas", 18, FontStyle.Bold);
            lbl_Player1.AutoSize = true;
            lbl_Player1.Location = new Point(quarterWidth - lbl_Player1.Width / 2, centerY - 280);

            // Player 2 Label
            lbl_Player2.Text = "Player 2";
            lbl_Player2.Font = new Font("Consolas", 18, FontStyle.Bold);
            lbl_Player2.AutoSize = true;
            lbl_Player2.Location = new Point(threeQuarterWidth - lbl_Player2.Width / 2, centerY - 280);

            // Immagini Player - dimensioni più grandi
            int imgSize = 200;
            img_Player1Icon.Size = new Size(imgSize, imgSize);
            img_Player1Icon.SizeMode = PictureBoxSizeMode.StretchImage;
            img_Player1Icon.Location = new Point(quarterWidth - imgSize / 2, centerY - 180);
            img_Player1Icon.BackColor = Color.LightGray;
            img_Player1Icon.BorderStyle = BorderStyle.FixedSingle;

            img_Player2Icon.Size = new Size(imgSize, imgSize);
            img_Player2Icon.SizeMode = PictureBoxSizeMode.StretchImage;
            img_Player2Icon.Location = new Point(threeQuarterWidth - imgSize / 2, centerY - 180);
            img_Player2Icon.BackColor = Color.LightGray;
            img_Player2Icon.BorderStyle = BorderStyle.FixedSingle;

            // Bottoni navigazione Player 1
            int btnNavSize = 60;
            int btnNavMargin = 30;

            btn_Player1Left.Size = new Size(btnNavSize, btnNavSize);
            btn_Player1Left.Location = new Point(img_Player1Icon.Location.X - btnNavSize - btnNavMargin,
                                                  img_Player1Icon.Location.Y + imgSize / 2 - btnNavSize / 2);
            btn_Player1Left.Text = "◄";
            btn_Player1Left.Font = new Font("Consolas", 20, FontStyle.Bold);
            btn_Player1Left.FlatStyle = FlatStyle.Flat;
            btn_Player1Left.BackColor = Color.Transparent;
            btn_Player1Left.Click += Btn_Player1Left_Click;

            btn_Player1Right.Size = new Size(btnNavSize, btnNavSize);
            btn_Player1Right.Location = new Point(img_Player1Icon.Location.X + imgSize + btnNavMargin,
                                                   img_Player1Icon.Location.Y + imgSize / 2 - btnNavSize / 2);
            btn_Player1Right.Text = "►";
            btn_Player1Right.Font = new Font("Consolas", 20, FontStyle.Bold);
            btn_Player1Right.FlatStyle = FlatStyle.Flat;
            btn_Player1Right.BackColor = Color.Transparent;
            btn_Player1Right.Click += Btn_Player1Right_Click;

            // Bottoni navigazione Player 2
            btn_Player2Left.Size = new Size(btnNavSize, btnNavSize);
            btn_Player2Left.Location = new Point(img_Player2Icon.Location.X - btnNavSize - btnNavMargin,
                                                  img_Player2Icon.Location.Y + imgSize / 2 - btnNavSize / 2);
            btn_Player2Left.Text = "◄";
            btn_Player2Left.Font = new Font("Consolas", 20, FontStyle.Bold);
            btn_Player2Left.FlatStyle = FlatStyle.Flat;
            btn_Player2Left.BackColor = Color.Transparent;
            btn_Player2Left.Click += Btn_Player2Left_Click;

            btn_Player2Right.Size = new Size(btnNavSize, btnNavSize);
            btn_Player2Right.Location = new Point(img_Player2Icon.Location.X + imgSize + btnNavMargin,
                                                   img_Player2Icon.Location.Y + imgSize / 2 - btnNavSize / 2);
            btn_Player2Right.Text = "►";
            btn_Player2Right.Font = new Font("Consolas", 20, FontStyle.Bold);
            btn_Player2Right.FlatStyle = FlatStyle.Flat;
            btn_Player2Right.BackColor = Color.Transparent;
            btn_Player2Right.Click += Btn_Player2Right_Click;

            // Label numero immagine selezionata
            lbl_Player1ImgNumber.Text = $"{p1Index + 1}: {NomiImmagini[p1Index]}";  // Testo iniziale più lungo
            lbl_Player1ImgNumber.Font = new Font("Consolas", 14, FontStyle.Bold);
            lbl_Player1ImgNumber.AutoSize = false;  // CAMBIATO DA true A false
            lbl_Player1ImgNumber.Size = new Size(220, 30);  // Dimensione fissa
            lbl_Player1ImgNumber.TextAlign = ContentAlignment.MiddleCenter;  // AGGIUNTO - centra il testo
            lbl_Player1ImgNumber.Location = new Point(quarterWidth - 110,  // 220/2 = 110
                                                       img_Player1Icon.Location.Y + imgSize + 15);

            lbl_Player2ImgSelected.Text = $"{p2Index + 1}: {NomiImmagini[p2Index]}";  // Testo iniziale più lungo
            lbl_Player2ImgSelected.Font = new Font("Consolas", 14, FontStyle.Bold);
            lbl_Player2ImgSelected.AutoSize = false;  // CAMBIATO DA true A false
            lbl_Player2ImgSelected.Size = new Size(220, 30);  // Dimensione fissa
            lbl_Player2ImgSelected.TextAlign = ContentAlignment.MiddleCenter;  // AGGIUNTO - centra il testo
            lbl_Player2ImgSelected.Location = new Point(threeQuarterWidth - 110,  // 220/2 = 110
                                                         img_Player2Icon.Location.Y + imgSize + 15);

            // Textbox nomi giocatori
            txt_player1Name.Size = new Size(220, 30);
            txt_player1Name.Font = new Font("Consolas", 12);
            txt_player1Name.Location = new Point(quarterWidth - txt_player1Name.Width / 2,
                                                  lbl_Player1ImgNumber.Location.Y + 40);
            txt_player1Name.Text = "";
            txt_player1Name.TextAlign = HorizontalAlignment.Center;

            txt_player2Name.Size = new Size(220, 30);
            txt_player2Name.Font = new Font("Consolas", 12);
            txt_player2Name.Location = new Point(threeQuarterWidth - txt_player2Name.Width / 2,
                                                  lbl_Player2ImgSelected.Location.Y + 40);
            txt_player2Name.Text = "";
            txt_player2Name.TextAlign = HorizontalAlignment.Center;

            // Bottoni "Pronto"
            btn_Player1Ready.Size = new Size(180, 55);
            btn_Player1Ready.Text = "Pronto!";
            btn_Player1Ready.Font = new Font("Consolas", 16, FontStyle.Bold);
            btn_Player1Ready.FlatStyle = FlatStyle.Flat;
            btn_Player1Ready.Location = new Point(quarterWidth - btn_Player1Ready.Width / 2,
                                                   txt_player1Name.Location.Y + txt_player1Name.Height + 25);
            btn_Player1Ready.Click += Btn_Player1Ready_Click;

            btn_Player2Ready.Size = new Size(180, 55);
            btn_Player2Ready.Text = "Pronto!";
            btn_Player2Ready.Font = new Font("Consolas", 16, FontStyle.Bold);
            btn_Player2Ready.FlatStyle = FlatStyle.Flat;
            btn_Player2Ready.Location = new Point(threeQuarterWidth - btn_Player2Ready.Width / 2,
                                                   txt_player2Name.Location.Y + txt_player2Name.Height + 25);
            btn_Player2Ready.Click += Btn_Player2Ready_Click;

            // Bottone "Inizia Gioco" - più grande e in basso
            btn_StartGame.Size = new Size(300, 80);
            btn_StartGame.Text = "Inizia Gioco!";
            btn_StartGame.Font = new Font("Consolas", 22, FontStyle.Bold);
            btn_StartGame.FlatStyle = FlatStyle.Flat;
            btn_StartGame.Location = new Point(centerX - btn_StartGame.Width / 2,
                                                this.Height - btn_StartGame.Height - 60);
            btn_StartGame.Click += Btn_StartGame_Click;
            btn_StartGame.Enabled = false;

            btn_Close.Size = new Size(40, 40);
            btn_Close.Location = new Point(this.Width - btn_Close.Width - 20, 20);
            btn_Close.FlatStyle = FlatStyle.Flat;
            btn_Close.FlatAppearance.BorderSize = 0;
            btn_Close.BackColor = Color.LightCoral;
            btn_Close.ForeColor = Color.White;
            btn_Close.Font = new Font("Consolas", 14, FontStyle.Bold);
            btn_Close.Text = "X";
            btn_Close.Click += btn_Close_Click;
            btn_Close.Cursor = Cursors.Hand;

            btn_Close.MouseEnter += (s, e) => btn_Close.BackColor = Color.Red;
            btn_Close.MouseLeave += (s, e) => btn_Close.BackColor = Color.LightCoral;

        }

        private void AddDefaultImages()
        {
            img_Player1Icon.Image = ImmaginiArray[0];
            img_Player2Icon.Image = ImmaginiArray[0];

            img_Player1Icon.SizeMode = PictureBoxSizeMode.StretchImage;
            img_Player2Icon.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Btn_StartGame_Click(object sender, EventArgs e)
        {
            P1Name = txt_player1Name.Text;
            P2Name = txt_player2Name.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Btn_Player1Ready_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_player1Name.Text))
            {
                MessageBox.Show("Inserisci un nome per il Player 1 prima di essere pronto!", "Attenzione");
                return;
            }

            //easter egg
            if (txt_player1Name.Text.Trim().ToLower() == "sebastiano")
            {
                //metto l'immagine della pedina speciale
                img_Player1Icon.Image = Image.FromFile("sebastiano.png");
                lbl_Player1.Text = "Sebastiano Priante";
            }

            isP1Ready = !isP1Ready;

            if (isP1Ready)
            {
                btn_Player1Ready.BackColor = Color.LightCoral;
                btn_Player1Ready.Font = new Font(btn_Player1Ready.Font.FontFamily, 12, FontStyle.Bold);
                btn_Player1Ready.Text = "Rimuovi pronto";
            }
            else
            {
                btn_Player1Ready.BackColor = SystemColors.Control;
                btn_Player1Ready.Font = new Font(btn_Player1Ready.Font.FontFamily, 16, FontStyle.Bold);
                btn_Player1Ready.Text = "Pronto!";
            }

            btn_StartGame.Enabled = isP1Ready && isP2Ready;
            btn_StartGame.BackColor = btn_StartGame.Enabled ? Color.Cornsilk : SystemColors.Control;
        }

        private void Btn_Player2Ready_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_player2Name.Text))
            {
                MessageBox.Show("Inserisci un nome per il Player 2 prima di essere pronto!", "Attenzione");
                return;
            }

            isP2Ready = !isP2Ready;

            if (isP2Ready)
            {
                btn_Player2Ready.BackColor = Color.LightCoral;
                btn_Player2Ready.Font = new Font(btn_Player2Ready.Font.FontFamily, 12, FontStyle.Bold);
                btn_Player2Ready.Text = "Rimuovi pronto";
            }
            else
            {
                btn_Player2Ready.BackColor = SystemColors.Control;
                btn_Player2Ready.Font = new Font(btn_Player2Ready.Font.FontFamily, 16, FontStyle.Bold);
                btn_Player2Ready.Text = "Pronto!";
            }

            btn_StartGame.Enabled = isP1Ready && isP2Ready;
            btn_StartGame.BackColor = btn_StartGame.Enabled ? Color.Cornsilk : SystemColors.Control;
        }

        private void AnimTimerP1_Tick(object sender, EventArgs e)
        {
            animStepP1++;
            float t = (float)animStepP1 / animMaxStepsP1;

            int currX = (int)(animStartXP1 + t * (animEndXP1 - animStartXP1));
            float currScale = animStartScaleP1 + t * (animEndScaleP1 - animStartScaleP1);

            int nextX = (int)(animNextStartXP1 + t * (animNextEndXP1 - animNextStartXP1));
            float nextScale = animNextStartScaleP1 + t * (animNextEndScaleP1 - animNextStartScaleP1);

            Bitmap bmp = new Bitmap(originalWidthP1, originalHeightP1);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.LightGray);
                int cw = (int)(originalWidthP1 * currScale);
                int ch = (int)(originalHeightP1 * currScale);
                g.DrawImage(animCurrentImageP1, currX - animStartXP1 + (originalWidthP1 - cw) / 2, (originalHeightP1 - ch) / 2, cw, ch);

                int nw = (int)(originalWidthP1 * nextScale);
                int nh = (int)(originalHeightP1 * nextScale);
                g.DrawImage(animNextImageP1, nextX - animStartXP1 + (originalWidthP1 - nw) / 2, (originalHeightP1 - nh) / 2, nw, nh);
            }

            img_Player1Icon.Image = bmp;

            if (animStepP1 >= animMaxStepsP1)
            {
                animTimerP1.Stop();
                img_Player1Icon.Image = animNextImageP1;
                img_Player1Icon.Left = animStartXP1;
                img_Player1Icon.Width = originalWidthP1;
                img_Player1Icon.Height = originalHeightP1;
                animatingP1 = false;
                lbl_Player1ImgNumber.Text = $"{p1Index + 1}: {NomiImmagini[p1Index]}";
            }
        }

        private void AnimTimerP2_Tick(object sender, EventArgs e)
        {
            animStepP2++;
            float t = (float)animStepP2 / animMaxStepsP2;

            int currX = (int)(animStartXP2 + t * (animEndXP2 - animStartXP2));
            float currScale = animStartScaleP2 + t * (animEndScaleP2 - animStartScaleP2);

            int nextX = (int)(animNextStartXP2 + t * (animNextEndXP2 - animNextStartXP2));
            float nextScale = animNextStartScaleP2 + t * (animNextEndScaleP2 - animNextStartScaleP2);

            Bitmap bmp = new Bitmap(originalWidthP2, originalHeightP2);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.LightGray);
                int cw = (int)(originalWidthP2 * currScale);
                int ch = (int)(originalHeightP2 * currScale);
                g.DrawImage(animCurrentImageP2, currX - animStartXP2 + (originalWidthP2 - cw) / 2, (originalHeightP2 - ch) / 2, cw, ch);

                int nw = (int)(originalWidthP2 * nextScale);
                int nh = (int)(originalHeightP2 * nextScale);
                g.DrawImage(animNextImageP2, nextX - animStartXP2 + (originalWidthP2 - nw) / 2, (originalHeightP2 - nh) / 2, nw, nh);
            }

            img_Player2Icon.Image = bmp;

            if (animStepP2 >= animMaxStepsP2)
            {
                animTimerP2.Stop();
                img_Player2Icon.Image = animNextImageP2;
                img_Player2Icon.Left = animStartXP2;
                img_Player2Icon.Width = originalWidthP2;
                img_Player2Icon.Height = originalHeightP2;
                animatingP2 = false;
                lbl_Player2ImgSelected.Text = $"{p2Index + 1}: {NomiImmagini[p2Index]}";
            }
        }
        private void Btn_Player1Right_Click(object sender, EventArgs e)
        {
            if (animatingP1) return;

            int nextIndex = p1Index + 1;
            if (nextIndex >= ImmaginiArray.Length) nextIndex = 0;

            animCurrentImageP1 = img_Player1Icon.Image;
            animNextImageP1 = ImmaginiArray[nextIndex];

            animStepP1 = 0;
            animMaxStepsP1 = 20;
            originalWidthP1 = img_Player1Icon.Width;
            originalHeightP1 = img_Player1Icon.Height;

            animStartXP1 = img_Player1Icon.Left;
            animEndXP1 = animStartXP1 - 100;
            animStartScaleP1 = 1f;
            animEndScaleP1 = 0.5f;

            animNextStartXP1 = img_Player1Icon.Left + img_Player1Icon.Width;
            animNextEndXP1 = img_Player1Icon.Left;
            animNextStartScaleP1 = 0.5f;
            animNextEndScaleP1 = 1f;

            animatingP1 = true;
            animTimerP1.Start();

            p1Index = nextIndex;
        }

        private void Btn_Player1Left_Click(object sender, EventArgs e)
        {
            if (animatingP1) return;

            int nextIndex = p1Index - 1;
            if (nextIndex < 0) nextIndex = ImmaginiArray.Length - 1;

            animCurrentImageP1 = img_Player1Icon.Image;
            animNextImageP1 = ImmaginiArray[nextIndex];

            animStepP1 = 0;
            animMaxStepsP1 = 20;
            originalWidthP1 = img_Player1Icon.Width;
            originalHeightP1 = img_Player1Icon.Height;

            animStartXP1 = img_Player1Icon.Left;
            animEndXP1 = animStartXP1 + 100;
            animStartScaleP1 = 1f;
            animEndScaleP1 = 0.5f;

            animNextStartXP1 = img_Player1Icon.Left - img_Player1Icon.Width;
            animNextEndXP1 = img_Player1Icon.Left;
            animNextStartScaleP1 = 0.5f;
            animNextEndScaleP1 = 1f;

            animatingP1 = true;
            animTimerP1.Start();

            p1Index = nextIndex;
        }

        private void Btn_Player2Right_Click(object sender, EventArgs e)
        {
            if (animatingP2) return;

            int nextIndex = p2Index + 1;
            if (nextIndex >= ImmaginiArray.Length) nextIndex = 0;

            animCurrentImageP2 = img_Player2Icon.Image;
            animNextImageP2 = ImmaginiArray[nextIndex];

            animStepP2 = 0;
            animMaxStepsP2 = 20;
            originalWidthP2 = img_Player2Icon.Width;
            originalHeightP2 = img_Player2Icon.Height;

            animStartXP2 = img_Player2Icon.Left;
            animEndXP2 = animStartXP2 - 100;
            animStartScaleP2 = 1f;
            animEndScaleP2 = 0.5f;

            animNextStartXP2 = img_Player2Icon.Left + img_Player2Icon.Width;
            animNextEndXP2 = img_Player2Icon.Left;
            animNextStartScaleP2 = 0.5f;
            animNextEndScaleP2 = 1f;

            animatingP2 = true;
            animTimerP2.Start();

            p2Index = nextIndex;
        }
        private void Btn_Player2Left_Click(object sender, EventArgs e)
        {
            if (animatingP2) return;

            int nextIndex = p2Index - 1;
            if (nextIndex < 0) nextIndex = ImmaginiArray.Length - 1;

            animCurrentImageP2 = img_Player2Icon.Image;
            animNextImageP2 = ImmaginiArray[nextIndex];

            animStepP2 = 0;
            animMaxStepsP2 = 20;
            originalWidthP2 = img_Player2Icon.Width;
            originalHeightP2 = img_Player2Icon.Height;

            animStartXP2 = img_Player2Icon.Left;
            animEndXP2 = animStartXP2 + 100;
            animStartScaleP2 = 1f;
            animEndScaleP2 = 0.5f;

            animNextStartXP2 = img_Player2Icon.Left - img_Player2Icon.Width;
            animNextEndXP2 = img_Player2Icon.Left;
            animNextStartScaleP2 = 0.5f;
            animNextEndScaleP2 = 1f;

            animatingP2 = true;
            animTimerP2.Start();

            p2Index = nextIndex;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
