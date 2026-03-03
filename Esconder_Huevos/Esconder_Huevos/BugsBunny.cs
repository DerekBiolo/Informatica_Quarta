using System;
using System.Collections.Generic;
using System.Text;
using LinkedCoda;
namespace Esconder_Huevos
{
    public class BugsBunny
    {
        private readonly LinkedCoda<Huevo> _ScivoloHuevos;
        private readonly SemaphoreSlim _mutex = new SemaphoreSlim(1, 1);
        private readonly CancellationTokenSource _cancellationTokenSource;

        public readonly int MAX_HUEVOS = 15;

        public BugsBunny(LinkedCoda<Huevo> scivoloHuevos, CancellationTokenSource cancellationTokenSource)
        {
            _ScivoloHuevos = scivoloHuevos;
            _cancellationTokenSource = cancellationTokenSource;
        }

        public async Task ProduciUovo()
        {
            for (int i = 0; i < MAX_HUEVOS; i++ ) {
                Huevo uovo = new Huevo();
                uovo.Colora();
                _ScivoloHuevos.Enqueue(uovo);
                Console.WriteLine($"Uovo prodotto: {uovo.Colore1} {uovo.Colore2}");
                await Task.Delay(1000);
                Console.WriteLine($"Coda attuale: {_ScivoloHuevos.Count()} huevos");
            }
        }

        public async Task Ricolora(Huevo uovo)
        {
            uovo.Colora();
            await Task.Delay(1000);
            //lo rimetto in coda
            await _mutex.WaitAsync();
            try
            {
                _ScivoloHuevos.Enqueue(uovo);
                Console.WriteLine($"Uovo ricolorato: {uovo.Colore1} {uovo.Colore2}");
            }
            finally
            {
                _mutex.Release();
            }
        }

        public Huevo PrendiUovoDaNascondere() => _ScivoloHuevos.Dequeue();
    }
}
