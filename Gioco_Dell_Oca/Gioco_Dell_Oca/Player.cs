using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gioco_Dell_Oca
{
    public class Player
    {
        public string Name { get; set; }
        public int ImageIndex { get; set; }
        public int CurrentCellIndex { get; set; } = 0;

        public int TurniFermi;
        public int CasellaAttuale = 0;
        public Panel PedinaPanel { get; private set; }
        private PictureBox picIcon;
        private Label lblName;

        public Player(string name, int imageIndex, Image iconImage)
        {
            Name = name;
            ImageIndex = imageIndex;

            Random random = new Random();
            int red = random.Next(0, 255);
            int green = random.Next(0, 255);
            int blue = random.Next(0, 255);

            // Panel pedina
            PedinaPanel = new Panel();
            PedinaPanel.Size = new Size(80, 80);
            PedinaPanel.BackColor = Color.FromArgb(red, green, blue);

            // immagine
            picIcon = new PictureBox();
            picIcon.Size = new Size(70, 70);
            picIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            picIcon.Image = iconImage;
            picIcon.Location = new Point((PedinaPanel.Width - picIcon.Width) / 2, 0);

            PedinaPanel.Controls.Add(picIcon);

            // Label del nome sotto l'immagine
            lblName = new Label();
            lblName.Text = name.ToUpper();
            lblName.Font = new Font("Consolas", 10, FontStyle.Bold);
            lblName.AutoSize = false;
            lblName.TextAlign = ContentAlignment.MiddleCenter;
            lblName.Size = new Size(PedinaPanel.Width, 15);
            lblName.Location = new Point(0, PedinaPanel.Height - lblName.Height);

            PedinaPanel.Controls.Add(lblName);
        }

        public void SetPosition(Point location)
        {
            PedinaPanel.Location = location;
        }

        public void SetImage(Image newImage)
        {
            picIcon.Image = newImage;
        }

        public void SetName(string newName)
        {
            lblName.Text = newName;
        }
    }
}
