using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battaglia_Navale_V2
{
    public abstract class ANave
    {
        protected string Nome;
        public int Lunghezza { get; protected set;  }
        private int ColpiSubiti;
        public bool isAffondata => ColpiSubiti >= Lunghezza;

        public event NaveEventHandler OnAffondare;

        public void Colpita()
        {
            ColpiSubiti++;
            if (isAffondata)
            {
                OnAffondare?.Invoke(this);
            }
        }
    }

    // Classe derivate delle varie navi
    public class Portaerei : ANave
    {
        public Portaerei()
        {
            Nome = "Portaerei";
            Lunghezza = 4;
        }
    }

    public class Corazzata : ANave
    {
        public Corazzata()
        {
            Nome =  "Corazzata";
            Lunghezza = 3;
        }
    }

    public class Incrociatore : ANave
    {
        public Incrociatore()
        {
            Nome = "Incrociatore";
            Lunghezza = 2;
        }
    }

    public class Sottomarino : ANave
    {
        public Sottomarino()
        {
            Nome = "Sottomarino";
            Lunghezza = 1;
        }
    }
}
