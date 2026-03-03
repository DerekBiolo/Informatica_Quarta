using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gioco_Dell_Oca
{
    public partial class Form1 : Form
    {
        public GameManager gameManager;
        public static Form1 Instance;

        public Player Player1;
        public Player Player2;

        Image i1;
        Image i2;

        public bool IsPlayer1Turn = true;
        public Form1()
        {
            Instance = this;
            InitializeComponent();
            gameManager = new GameManager();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (PlayerCreation f = new PlayerCreation())
            {
                DialogResult result = f.ShowDialog();

                if (result == DialogResult.Cancel)
                {
                    this.Close();
                    return;
                }

                //controllo se ce sebastiano
                if(f.P1Name.ToLower() == "sebastiano")
                {
                    i1 = Image.FromFile("sebastiano.png");
                } else
                {
                    i1 = f.ImmaginiArray[f.p1Index];
                }

                if (f.P2Name.ToLower() == "sebastiano")
                {
                    i2 = Image.FromFile("sebastiano.png");
                }
                else
                {
                    i2 = f.ImmaginiArray[f.p2Index];
                }

                Player1 = new Player(f.P1Name, f.p1Index, i1);
                Player2 = new Player(f.P2Name, f.p2Index, i2);
                this.Controls.Add(Player1.PedinaPanel);
                this.Controls.Add(Player2.PedinaPanel);
                Player1.SetPosition(new Point(50, 50));
                Player2.SetPosition(new Point(50, 150));
            }

            gameManager.InizializzaGioco();
        }

    }
}
