using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoCarteGuerra
{
    internal class CGuerriero : CPersonaggio
    {
        public CGuerriero(string nome) : base(nome, 100)
        {
        }
        public override int Attacca()
        {
            return 20;
        }
    }
}
