using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CreaLaTuaFlotta
{
    abstract class CVeicolo
    {
        public string Nome { get; set; }
        public bool Acceso { get; set; }

        public CVeicolo(string nome)
        {
            Nome = nome;
            Acceso = false;
        }

        public void Accendi()
        {
            Acceso = true;
            WriteLine($"{Nome} è acceso.");
        }

        public void Spegni()
        {
            Acceso = false;
            WriteLine($"{Nome} è spento.");
        }

        public abstract void MostraInfo();
    }
}
