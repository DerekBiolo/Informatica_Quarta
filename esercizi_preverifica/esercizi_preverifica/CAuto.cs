using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizi_preverifica
{
    internal class CAuto : CVeicolo
    {
        public CAuto(int s)
            : base(s) { }

        public override void Muovi()
        {
            Console.WriteLine("La macchina corre a");        
        }
    }
}
