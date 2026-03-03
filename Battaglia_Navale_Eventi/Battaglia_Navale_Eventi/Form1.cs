using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Battaglia_Navale_Eventi
{
    public partial class Form1 : Form
    {
        bool isPvP;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_PvP_Click(object sender, EventArgs e)
        {
            isPvP = true;
            //inizializzo il form per posizionare in PvP
            Positioning positioning = new Positioning(isPvP);

            positioning.PositioningAperto += (s, args) => this.Hide();
            positioning.FormClosed += (s, args) => this.Show();

            positioning.Show();

        }

        private void btn_PvAI_Click(object sender, EventArgs e)
        {
            isPvP = false;
            Positioning positioning = new Positioning(isPvP);

            positioning.PositioningAperto += (s, args) => this.Hide();
            positioning.FormClosed += (s, args) => this.Show(); 

            positioning.Show();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Styler()
        {
            // Full screen
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(30, 30, 30); // sfondo semplice e elegante

            // Titolo
            lbl_Title.ForeColor = Color.White;
            lbl_Title.Font = new Font("Arial", 48, FontStyle.Bold); // più grande
            lbl_Title.AutoSize = true;
            lbl_Title.Location = new Point((this.Width - lbl_Title.Width) / 2, 50);

            // Pulsanti grandi
            int btnWidth = 250;
            int btnHeight = 80;
            int spacing = 50;

            btn_PvP.Size = new Size(btnWidth, btnHeight);
            btn_PvAI.Size = new Size(btnWidth, btnHeight);
            btn_Exit.Size = new Size(btnWidth, btnHeight);

            // Posizionamento orizzontale
            int totalWidth = btn_PvP.Width + btn_PvAI.Width + btn_Exit.Width + spacing * 2;
            int startX = (this.Width - totalWidth) / 2;
            int centerY = this.Height / 2;

            btn_PvP.Location = new Point(startX, centerY - btnHeight / 2);
            btn_PvAI.Location = new Point(startX + btnWidth + spacing, centerY - btnHeight / 2);
            btn_Exit.Location = new Point(startX + (btnWidth + spacing) * 2, centerY - btnHeight / 2);

            // Colori pulsanti
            Color btnColor = Color.FromArgb(70, 130, 180);
            btn_PvP.BackColor = btnColor;
            btn_PvAI.BackColor = btnColor;
            btn_Exit.BackColor = Color.FromArgb(180, 70, 70);

            btn_PvP.ForeColor = Color.White;
            btn_PvAI.ForeColor = Color.White;
            btn_Exit.ForeColor = Color.White;

            btn_PvP.FlatStyle = FlatStyle.Flat;
            btn_PvAI.FlatStyle = FlatStyle.Flat;
            btn_Exit.FlatStyle = FlatStyle.Flat;
            btn_PvP.FlatAppearance.BorderSize = 0;
            btn_PvAI.FlatAppearance.BorderSize = 0;
            btn_Exit.FlatAppearance.BorderSize = 0;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            Styler();
        }
    }
}
