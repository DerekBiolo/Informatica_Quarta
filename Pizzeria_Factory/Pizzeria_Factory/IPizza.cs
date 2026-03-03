using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria_Factory
{
    interface IPizza
    {
        string Prepara();
        string Cucina();
    }
}
