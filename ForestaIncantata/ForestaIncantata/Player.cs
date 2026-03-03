using System;
using System.Collections.Generic;
using System.Text;

namespace ForestaIncantata
{
    internal class Player
    {
        
        private int posizione;
        private int stopTurni;
        Cella CellaAttuale;
        Tabellone TabelloneAttuale;

        public Player(Tabellone t)
        {
            posizione = 1;
            stopTurni = 0;
            TabelloneAttuale = t;
        }

        public void Muovi(int spostamento)
        {
            posizione += spostamento;
            if (posizione > 49)
                posizione = 50;

            if (posizione < 0)
                posizione = 0;

            CellaAttuale = TabelloneAttuale.celle[posizione];
            CellaAttuale.Visitata(posizione);

        }
        public void StopTurni(int turni)
        {
            stopTurni += turni;
        }

        public int GetPosizione()
        {
            return posizione;
        }

        public void TiraDadi(bool player)
        {
            if (stopTurni > 0)
            {
                if (player)
                {
                    Console.WriteLine("Giocatore 1 salta un turno!");
                } else
                {
                    Console.WriteLine("Giocatore 2 salta un turno!");
                }
                stopTurni--;
                return;
            }
            Random r = new Random();
            int dado1 = r.Next(1, 7);
            int dado2 = r.Next(1, 7);
            int totale = dado1 + dado2;
            Muovi(totale);
            if (player)
            {
                Console.WriteLine($"Giocatore 1 ha tirato i dadi: {dado1} e {dado2}, totale {totale}. Ora si trova sulla casella {posizione}.");
            } else
            {
                Console.WriteLine($"Giocatore 2 ha tirato i dadi: {dado1} e {dado2}, totale {totale}. Ora si trova sulla casella {posizione}.");
            }
        }
    }
}
