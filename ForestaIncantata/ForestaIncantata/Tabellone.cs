using System;
using System.Collections.Generic;
using System.Text;

namespace ForestaIncantata
{
    public delegate EventArgs CellaVisitataHandler(int numero);
    internal class Tabellone
    {
        public List<Cella> celle;
        Player p1;
        Player p2;
        Player pAttuale;

        public Tabellone()
        {
            celle = new List<Cella>();
            for (int i = 0; i < 100; i++)
            {
                celle.Add(new Cella(i));
                celle[i].OnCellaVisitata += Cella_OnCellaVisitata;
            }
            p1 = new Player(this);
            p2 = new Player(this);
        }

        private void Cella_OnCellaVisitata(int numero)
        {
            if (numero == 7 || numero == 14 || numero == 21 || numero == 28 || numero == 35 || numero == 42 || numero == 49)
            {
                Console.WriteLine("Hai trovato una Sorgente Magica! Avanzi di 3 caselle.");
                SorgenteMagica();
            }
            else if (numero == 12)
            {
                Console.WriteLine("Sei rimasto intrappolato in una Ragnatela Gigante! Salti un turno.");
                RagnatelaGigante();
            }
            else if (numero == 26)
            {
                Console.WriteLine("Sei finito in una Palude Viscosa! Torni indietro di 7 caselle.");
                PaludeViscosa();
            }
            else if (numero == 15 || numero == 34)
            {
                Console.WriteLine("Un Amico della Foresta ti aiuta! Avanzi di 5 caselle.");
                AmicoForesta();
            }
            else if (numero == 18)
            {
                Console.WriteLine("Sei arrivato all'Albero del Destino! Tira di nuovo i dadi.");
                AlberoDestino();
            }
            else if (numero == 50)
            {
                Vittoria();
            }
        }

        private void SorgenteMagica()
        {
            pAttuale.Muovi(3);
            Console.WriteLine("Posizione attuale: " + pAttuale.GetPosizione().ToString());
        }

        private void RagnatelaGigante()
        {
            pAttuale.StopTurni(1);
        }

        private void PaludeViscosa()
        {
            pAttuale.Muovi(-7);
        }

        private void AmicoForesta()
        {
            pAttuale.Muovi(5);
        }

        private void AlberoDestino()
        {
            pAttuale.TiraDadi(Program.turno);
        }

        private void Vittoria()
        {
            Console.WriteLine("Hai vinto!");
            Program.vittoria = true;
        }

        public void Giocaturno(bool turno)
        {
            pAttuale = turno ? p1 : p2;
            pAttuale.TiraDadi(Program.turno);
        }
    }
}
