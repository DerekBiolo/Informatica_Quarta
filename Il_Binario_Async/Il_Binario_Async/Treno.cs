using System;
using System.Collections.Generic;
using System.Text;

namespace Il_Binario_Async
{
    internal class Treno
    {
        private bool Direzione; // true nord false sud
        public bool Dentro {  get; set; }

        public Treno(bool direzione)
        {
            Direzione = direzione;
        }

        public async Task ArrivaBinario(Stazione s, CancellationTokenSource cts)
        {
            Console.WriteLine($"Arrivato un treno, direzione: {(Direzione ? "Trento-Sicilia" : "Sicilia-Trento)}")}");

            await s.EntraNelBinario(this, cts.Token);
            await Task.Delay(Random.Shared.Next(1000, 10001), cts.Token);
            s.Exit(this);
        }

        public bool GetDirezione() => Direzione;
    }
}
