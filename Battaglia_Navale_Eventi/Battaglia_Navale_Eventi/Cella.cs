using System;
using System.Drawing;

namespace Battaglia_Navale_Eventi
{
    public enum StatoCella
    {
        Vuota,
        Nave,
        Colpita,
        Mancata
    }

    public class Cella
    {
        public Point Posizione { get; }
        public StatoCella Stato { get; private set; }
        public Nave NaveAssociata { get; private set; }

        public Cella(int x, int y)
        {
            Posizione = new Point(x, y);
            Stato = StatoCella.Vuota;
        }

        public bool HaNave => Stato == StatoCella.Nave || Stato == StatoCella.Colpita;

        public void ColpitaCella()
        {
            if (Stato == StatoCella.Nave)
            {
                Stato = StatoCella.Colpita;
                if (NaveAssociata != null)
                {
                    NaveAssociata.Colpita(Posizione);
                }
            }
            else if (Stato == StatoCella.Vuota)
            {
                Stato = StatoCella.Mancata;
            }
        }

        public void PosizionaNave(Nave nave)
        {
            Stato = StatoCella.Nave;
            NaveAssociata = nave;
        }
    }
}