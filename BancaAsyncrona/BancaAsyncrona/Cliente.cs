using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace BancaAsyncrona
{
    internal class Cliente
    {
        public bool haMetallo;
        public int id;

        private static int _counter = 0;
        private static readonly int _possibilita = 3; // 30% di possibilità di avere metallo

        public Cliente()
        {
            id = Interlocked.Increment(ref _counter);
            haMetallo = Random.Shared.Next(1, 11) <= _possibilita;
        }

        public async Task SimulaIngresso(Cabina cabina)
        {
            await Task.Delay(Random.Shared.Next(500, 2001));

            Console.WriteLine($"Cliente {id} si avvicina alla cabina per ENTRARE.");
            bool entrato = await cabina.Entra(Direzione.Entrata, this);

            if (entrato)
            {
                Console.WriteLine($"Cliente {id} è ENTRATO nella banca.");
                await cabina.Esci(this); // Esce dalla cabina

                // Simula operazioni bancarie
                int tempo_operazioni = Random.Shared.Next(2000, 10001);
                Console.WriteLine($"Cliente {id} sta effettuando operazioni bancarie ({tempo_operazioni}ms)...");
                await Task.Delay(tempo_operazioni);

                // Ora deve uscire dalla banca
                Console.WriteLine($"Cliente {id} vuole uscire dalla banca.");
                await cabina.EsciDallaBanca(this);
                await cabina.Esci(this);

                Console.WriteLine($"Cliente {id} ha LASCIATO la banca.");
            }
            else
            {
                Console.WriteLine($"Cliente {id} è stato ESPULSO (qualcuno nel gruppo aveva metallo) , grupppo di dormiglioni");
                await cabina.Esci(this);
            }
        }
    }
}