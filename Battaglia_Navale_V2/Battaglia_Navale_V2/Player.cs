using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Battaglia_Navale_V2
{
    internal class Player
    {
        public string Nome;
        public TipoPlayer Tipo;
        public Tabella Tabella;
        public List<ANave> Flotta;
        public int MosseEffettuate = 0;
        public int FlottaRimasta => Flotta.Count(n => !n.isAffondata);

        public event GameEventHandler OnPlayerPronto;
        public event NaveEventHandler OnNaveAffondata;

        public Player(string n, TipoPlayer t)
        {
            Nome = n;
            Tipo = t;
            Tabella = new Tabella(10, 10);
            Flotta = new List<ANave>();
            InizializzaNavi();
        }

        public void InizializzaNavi()
        {
            Flotta.AddRange(new ANave[]
            {
                new Portaerei(), // 1 da 4
                new Corazzata(), // 2 da 3
                new Corazzata(),
                new Incrociatore(), // 2 da 2
                new Corazzata(),
                new Sottomarino() // 1 da 1
            });

            foreach (var nave in Flotta)
            {
                // per ogni nave, con s , aggiungo un gestore per l'evento OnAffondare (s sarebbe la nave stessa)
                nave.OnAffondare += (s) => OnNaveAffondata?.Invoke(s);
            }
        }

        public bool PosizionaNave(ANave nave, int x, int y, bool isOrizzontale)
        {
            return Tabella.PosizionareNave(nave, x, y, isOrizzontale);
        }

        //uso la ricorsione per piazzare automaticamente le navi
        public bool AutoPosizionaNave()
        {
            return AutoPlacer(Flotta, 0);
        }

        private bool AutoPlacer(List<ANave> navi, int inice)
        {
            if (inice >= navi.Count) return true;

            var nave = navi[inice];
            Random r = new Random();
            int tentativi = 0;

            while(tentativi < 200)
            {
                int x = r.Next(0, 10);
                int y = r.Next(0, 10);
                bool isOrizzontale = r.Next(0, 2) == 0;

                if(Tabella.CanPosizionareNave(nave, x, y, isOrizzontale))
                {
                    Tabella.PosizionareNave(nave, x, y, isOrizzontale);
                    if (AutoPlacer(navi, inice + 1))
                        { return true; }

                    Tabella.RimuoviNave(nave);
                }
                tentativi++;
            }
            return false;
        }

        public void EseguiMossa(int x, int y, Player avversario)
        {
            MosseEffettuate++;
            avversario.Tabella.Attacca(x, y);
        }
    }
}
