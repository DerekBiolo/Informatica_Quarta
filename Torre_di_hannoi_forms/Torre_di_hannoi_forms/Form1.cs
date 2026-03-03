using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Torre_di_hannoi_forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Styler();
        }

        private void Styler()
        {
            // Form principale
            this.Text = "Torre di Hanoi";
            this.BackColor = Color.FromArgb(45, 52, 54);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(500, 350);

            // Label Titolo
            lbl_Titolo.Text = "Torre di Hanoi";
            lbl_Titolo.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lbl_Titolo.ForeColor = Color.FromArgb(255, 234, 167);
            lbl_Titolo.TextAlign = ContentAlignment.MiddleCenter;
            lbl_Titolo.BackColor = Color.Transparent;
            lbl_Titolo.Location = new Point(50, 40);
            lbl_Titolo.Size = new Size(400, 50);
            lbl_Titolo.AutoSize = false;

            // Label Descrizione
            lbl_Descrizione.Text = "Seleziona il numero di dischi per la simulazione:";
            lbl_Descrizione.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            lbl_Descrizione.ForeColor = Color.FromArgb(223, 230, 233);
            lbl_Descrizione.TextAlign = ContentAlignment.MiddleCenter;
            lbl_Descrizione.BackColor = Color.Transparent;
            lbl_Descrizione.Location = new Point(50, 130);
            lbl_Descrizione.Size = new Size(400, 30);
            lbl_Descrizione.AutoSize = false;

            // NumericUpDown
            num_NumeroDischi.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            num_NumeroDischi.BackColor = Color.FromArgb(223, 230, 233);
            num_NumeroDischi.ForeColor = Color.FromArgb(45, 52, 54);
            num_NumeroDischi.Minimum = 3;
            num_NumeroDischi.Maximum = 10;
            num_NumeroDischi.Value = 3;
            num_NumeroDischi.TextAlign = HorizontalAlignment.Center;
            num_NumeroDischi.Location = new Point(200, 180);
            num_NumeroDischi.Size = new Size(100, 35);

            // Bottone Avvia
            btn_Avvia.Text = "Avvia Simulazione";
            btn_Avvia.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btn_Avvia.BackColor = Color.FromArgb(0, 184, 148);
            btn_Avvia.ForeColor = Color.White;
            btn_Avvia.FlatStyle = FlatStyle.Flat;
            btn_Avvia.FlatAppearance.BorderSize = 0;
            btn_Avvia.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 206, 166);
            btn_Avvia.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 163, 131);
            btn_Avvia.Cursor = Cursors.Hand;
            btn_Avvia.Location = new Point(150, 250);
            btn_Avvia.Size = new Size(200, 50);
        }

        private void btn_Avvia_Click(object sender, EventArgs e)
        {
            int n = (int)num_NumeroDischi.Value;
            FSimulazione f = new FSimulazione(n);
            this.Hide();
            f.ShowDialog();
            Application.Exit();
        }
    }
}
