using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Pagamenti_Digitali
{
    interface I_Autenticazione
    {
        bool Autenticazione(string user, string password);
        void Disconnetti();
    }
}
