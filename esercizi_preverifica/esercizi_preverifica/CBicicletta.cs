using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizi_preverifica
{
    internal class CBicicletta : CVeicolo
    {
        public CBicicletta(int s)
            : base(s) { }

        public override void Muovi()
        {
            Console.WriteLine("La bici corre");
        }
    }
}
