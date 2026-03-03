using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaLaTuaFlotta
{
    interface ICondivisibile
    {
        public string Id { get; set; }
        public bool Disponibile { get; set; }
    }
}
