using System;
using System.Collections.Generic;
using System.Text;

namespace BancaAsyncrona
{
    internal class MetalDetector
    {
        public static bool Controllo(List<Cliente> clienteList)
        {
            bool result = false;
            foreach (Cliente cliente in clienteList)
            {
                if (cliente.haMetallo == true)
                    result = true;
            }

            return result;
        }
    }
}
