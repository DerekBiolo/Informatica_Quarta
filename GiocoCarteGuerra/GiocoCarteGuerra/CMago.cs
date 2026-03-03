using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoCarteGuerra
{
    internal class CMago : CPersonaggio
    {
        public CMago(string nome) : base(nome, 70)
        {
        }
        public override int Attacca()
        {
            return 30;
        }
    }
}
