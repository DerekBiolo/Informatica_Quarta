using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoCarteGuerra
{
    internal class CArciere : CPersonaggio
    {
        public CArciere(string nome) : base(nome, 80)
        {
        }
        public override int Attacca()
        {
            return 25;
        }
    }
}
