using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battaglia_Navale_V2
{
    public class Tabella
    {
        private Cella[,] Celle;
        public int Larghezza;
        public int Altezza;

        public event CellaEventHandler OnCambioCella;

        public Tabella(int l, int a)
        {
            Larghezza = l;
            Altezza = a;
            Celle = new Cella[l, a];

            for(int x = 0; x < l; x++)
            {
                for(int y = 0; y < a; y++)
                {
                    Celle[x, y] = new Cella(x, y);
                    Celle[x, y].OnCambioStato += (cell) => OnCambioCella.Invoke(cell);
                }
            }
        }

        public Cella GetCella(int x, int y) => Celle[x, y];

        public bool CanPosizionareNave(ANave nave, int sX, int sY, bool oriz)
        {
            for(int i = 0; i < nave.Lunghezza; i++)
            {
                int x = oriz ? sX + i : sX;
                int y = oriz ? sY : sY + i;

                if (x >= Larghezza || y >= Altezza || Celle[x,y].Status != StatusCella.Vuota)
                {
                    return false;
                }
            }
            return true;
        }

        public bool PosizionareNave(ANave nave, int sX, int sY, bool oriz)
        {
            if (!CanPosizionareNave(nave, sX, sY, oriz))
                return false;

            for ( int i = 0; i < nave.Lunghezza; i++)
            {
                int x = oriz ? sX + i : sX;
                int y = oriz ? sY : sY + i;
                Celle[x, y].PosizionaNave(nave);
            }
            return true;
        }

        public void RimuoviNave(ANave nave)
        {
            for(int x = 0; x < Larghezza; x++)
            {
                for(int y = 0; y < Altezza; y++)
                {
                    if (Celle[x,y].Nave == nave)
                    {
                        Celle[x, y] = new Cella(x, y);
                    }
                }
            }
        }

        public bool Attacca(int x, int y)
        {
            return Celle[x, y].Attacca();
        }
    }
}