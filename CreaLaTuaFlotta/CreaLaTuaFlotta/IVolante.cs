using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaLaTuaFlotta
{
    interface IVolante
    {
        public int quotaMassima { get; set; }
        public void Vola();
    }
}
