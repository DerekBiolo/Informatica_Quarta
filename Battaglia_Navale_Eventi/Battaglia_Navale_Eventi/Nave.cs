using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Battaglia_Navale_Eventi
{
    public abstract class Nave
    {
        public string Nome;
        public int Lunghezza;
        public List<Point> Posizioni = new List<Point>();
        private List<Point> PosizioniColpite = new List<Point>();

        public bool Affondata => PosizioniColpite.Count == Posizioni.Count && Posizioni.Count > 0;

        public bool Colpita(Point p)
        {
            if (Posizioni.Contains(p) && !PosizioniColpite.Contains(p))
            {
                PosizioniColpite.Add(p);
                return true;
            }
            return false;
        }
    }

    public class Portaerei : Nave
    {
        public Portaerei()
        {
            Nome = "Portaerei";
            Lunghezza = 4;
        }
    }

    public class Cacciatorpediniere : Nave
    {
        public Cacciatorpediniere()
        {
            Nome = "Cacciatorpediniere";
            Lunghezza = 3;
        }
    }

    public class Sottomarino : Nave
    {
        public Sottomarino()
        {
            Nome = "Sottomarino";
            Lunghezza = 2;
        }
    }

    public class Torpediniere : Nave
    {
        public Torpediniere()
        {
            Nome = "Torpediniere";
            Lunghezza = 1;
        }
    }
}