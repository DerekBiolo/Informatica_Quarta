using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CreaLaTuaFlotta
{
    internal class CAuto : CVeicolo
    {
        public string targa { get; set; }

        public CAuto(string nome, string targa) : base(nome)
        {
            this.targa = targa;
        }

        public override void MostraInfo()
        {
            WriteLine($"Auto: {Nome}, Targa: {targa}");
        }
    }
}
