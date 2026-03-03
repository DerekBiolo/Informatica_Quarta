using System;
using System.Collections.Generic;
using System.Text;

namespace Il_Binario_Async
{
    internal class Stazione
    {
        private readonly SemaphoreSlim _binario;
        private readonly object _lock = new object();

        public int treniFunzionanti = 0;
        public bool? direzioneTreni = null;

        public int treniAttesa = 0;

        public List<Treno> treni;
        public CancellationTokenSource cts;

        public Stazione(SemaphoreSlim s, CancellationTokenSource c)
        {
            _binario = s;
            cts = c;

            treni = new();
        }

        public void InizializzaTreni(int tot)
        {
            for(int  i = 0; i < tot;  i++)
            {
                
            }
        }

    }
}
