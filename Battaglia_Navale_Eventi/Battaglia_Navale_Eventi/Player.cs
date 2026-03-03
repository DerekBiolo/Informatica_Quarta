using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Battaglia_Navale_Eventi
{
    public class Player
    {
        public string Nome { get; private set; }
        public Tabella Griglia { get; private set; }
        public List<Nave> Flotta { get; private set; }
        public List<Button> PulsantiGriglia { get; set; }
        private int indiceNaveCorrente = 0;

        public Nave NaveCorrente => indiceNaveCorrente < Flotta.Count ? Flotta[indiceNaveCorrente] : null;
        public bool Verticale { get; set; } = true;

        public Player(string nome)
        {
            Nome = nome;
            Griglia = new Tabella();
            PulsantiGriglia = new List<Button>();
            Flotta = new List<Nave>()
            {
                new Portaerei(),
                new Cacciatorpediniere(),
                new Cacciatorpediniere(),
                new Sottomarino(),
                new Sottomarino(),
                new Torpediniere()
            };
        }

        public void ProssimaNave()
        {
            if (indiceNaveCorrente < Flotta.Count)
                indiceNaveCorrente++;
        }

        public bool HaNaviDaPosizionare()
        {
            return indiceNaveCorrente < Flotta.Count;
        }

        public bool PosizionaNaveCorrente(Point p)
        {
            var nave = NaveCorrente;
            if (nave == null) return false;

            if (Griglia.PosizionaNave(nave, p, Verticale))
            {
                ProssimaNave();
                return true;
            }
            return false;
        }

        public void AggiornaUI()
        {
            foreach (var nave in Flotta)
            {
                foreach (var np in nave.Posizioni)
                {
                    var btn = PulsantiGriglia.FirstOrDefault(b => b.Tag is Point p && p == np);
                    if (btn != null)
                        btn.BackColor = Color.Gray;
                }
            }
        }

        public bool HaPerso()
        {
            return Flotta.All(n => n.Affondata);
        }

        public void GeneraRandom()
        {
            Random rnd = new Random();
            foreach (var nave in Flotta)
            {
                bool posizionata = false;
                int tentativi = 0;
                while (!posizionata && tentativi < 100)
                {
                    int x = rnd.Next(0, 10);
                    int y = rnd.Next(0, 10);
                    bool verticale = rnd.Next(0, 2) == 0;
                    posizionata = Griglia.PosizionaNave(nave, new Point(x, y), verticale);
                    tentativi++;
                }
            }
        }
    }
}