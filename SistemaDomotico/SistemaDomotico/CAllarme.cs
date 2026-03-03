using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDomotico
{
    using static System.Console;
    internal class CAllarme : ISwitchable
    {
        public bool isOn { get; set; }

        public void Accendi()
        {
            WriteLine("Allarme attivato!");
            isOn = true;
        }

        public void Spegni()
        {
            WriteLine("Allarme disattivato!");
            isOn = false;
        }
    }
}
