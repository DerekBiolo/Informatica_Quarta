using System;
using System.Collections.Generic;
using System.Text;

namespace ForestaIncantata
{
    internal class Cella
    {
        int numeroCella;
        public event Action<int> OnCellaVisitata;

        public Cella(int numero)
        {
            numeroCella = numero;
        }

        public void Visitata(int numero)
        {
            OnCellaVisitata?.Invoke(numero);
        }
    }
}
