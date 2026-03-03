using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDomotico
{
    internal interface ISwitchable
    {
        public bool isOn { get; set; }
        void Accendi();
        void Spegni();
    }
}
