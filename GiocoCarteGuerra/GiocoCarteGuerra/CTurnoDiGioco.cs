using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiocoCarteGuerra
{
    internal class CTurnoDiGioco
    {
        public CTurnoDiGioco()
        {
        }

        public void Turno()
        {
            int damages = attaccante.Attacca();
            MessageBox.Show($"{attaccante.GetNome()} attacca {difensore.GetNome()} infliggendo {damages} danni!");

            difensore.SubisciDanno(damages);

            if (!difensore.IsLiving())
            {
                MessageBox.Show($"{difensore.GetNome()} è stato sconfitto!");
            }
            else
            {
                MessageBox.Show($"{difensore.GetNome()} sopravvive con {difensore.GetPuntiVita()} punti vita.");
            }
        }

        public void iniziaPartita()
        {
            CPersonaggio[] mazzo1 = new CPersonaggio[10];
            CPersonaggio[] mazzo2 = new CPersonaggio[10];

            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                int tipoCarta1 = rand.Next(2);
                int tipoCarta2 = rand.Next(2);

                mazzo1[i] = (tipoCarta1 == 0)
                    ? new CArciere($"Arciere {i + 1}")
                    : new CMago($"Mago {i + 1}");

                mazzo2[i] = (tipoCarta2 == 0)
                    ? new CArciere($"Arciere {i + 1}")
                    : new CMago($"Mago {i + 1}");
            }

            MessageBox.Show("Inizia la partita! 10 carte per ciascun giocatore.");

            int turno = 0;
            while (turno < 10 && mazzo1[turno].IsLiving() && mazzo2[turno].IsLiving())
            {
                MessageBox.Show($"--- Turno {turno + 1} ---");

                attaccante = mazzo1[turno];
                difensore = mazzo2[turno];
                MessageBox.Show($"Duello: {attaccante.GetNome()} (Giocatore 1) VS {difensore.GetNome()} (Giocatore 2)");
                Turno();

                if (!difensore.IsLiving())
                {
                    MessageBox.Show("Giocatore 1 vince la partita!");
                    break;
                }

                attaccante = mazzo2[turno];
                difensore = mazzo1[turno];
                MessageBox.Show($"Contro-attacco: {attaccante.GetNome()} (Giocatore 2) VS {difensore.GetNome()} (Giocatore 1)");
                Turno();

                if (!difensore.IsLiving())
                {
                    MessageBox.Show("Giocatore 2 vince la partita!");
                    break;
                }

                turno++;
            }

            if (turno >= 10)
                MessageBox.Show("La partita è terminata: pareggio dopo 10 turni!");
        }
    }
}
