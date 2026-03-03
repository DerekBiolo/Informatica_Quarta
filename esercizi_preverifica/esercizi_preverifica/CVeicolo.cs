using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizi_preverifica
{
    internal abstract class CVeicolo
    {
        private int speed;

        public CVeicolo(int s)
        {
            if (s > 0)
            speed = s;
        }

        public abstract void Muovi();
        public void ModificaVel(int vel)
        {
            if (vel > 0)
                speed = vel;
        }
    }
}
