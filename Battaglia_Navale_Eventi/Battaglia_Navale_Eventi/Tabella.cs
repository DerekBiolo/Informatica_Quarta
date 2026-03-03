using System;
using System.Drawing;

namespace Battaglia_Navale_Eventi
{
    public class Tabella
    {
        public const int Dimensione = 10;
        public Cella[,] Celle { get; private set; }

        public Tabella()
        {
            Celle = new Cella[Dimensione, Dimensione];
            for (int x = 0; x < Dimensione; x++)
            {
                for (int y = 0; y < Dimensione; y++)
                {
                    Celle[x, y] = new Cella(x, y);
                }
            }
        }

        public bool PosizionaNave(Nave nave, Point start, bool verticale)
        {
            // Verifica validità posizione
            for (int i = 0; i < nave.Lunghezza; i++)
            {
                int x = start.X + (verticale ? 0 : i);
                int y = start.Y + (verticale ? i : 0);

                if (x < 0 || x >= Dimensione || y < 0 || y >= Dimensione)
                    return false;
                if (Celle[x, y].HaNave)
                    return false;
            }

            // Posiziona nave
            for (int i = 0; i < nave.Lunghezza; i++)
            {
                int x = start.X + (verticale ? 0 : i);
                int y = start.Y + (verticale ? i : 0);
                Celle[x, y].PosizionaNave(nave);
                nave.Posizioni.Add(new Point(x, y));
            }
            return true;
        }

        public bool ColpisciCella(Point p)
        {
            var cella = Celle[p.X, p.Y];
            bool colpito = cella.HaNave && cella.Stato != StatoCella.Colpita;
            cella.ColpitaCella();
            return colpito;
        }
    }
}