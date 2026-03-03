using System;
using System.Collections.Generic;
using System.Text;

namespace BarStadio
{
    internal class Bar
    {
        private readonly SemaphoreSlim _posti;
        private readonly object _lock = new();

        private int tifosiDentro = 0;
        private bool? squadraDentro = null; //se e vero casa altrimenti trasferta
        private bool eBarChiuso = false;

        private int ospitiInAttesa = 0;

        private List<Tifoso> tifosi;
        private Barista barista;
        private CancellationTokenSource cts;

        public Bar(SemaphoreSlim s, int tot, CancellationTokenSource cts)
        {
            _posti = s;
            this.cts = cts;

            tifosi = new();
            barista = new(this);
        }

        private void InizializzaTifosi(int tot)
        {
            for (int i = 0; i < tot; i++)
            {
                bool casa = Random.Shared.Next(0, 2) == 0;
                tifosi.Add(new Tifoso(casa));
            }
        }

        public async Task StartAsync(int n)
        {
            List<Task> tasks = new();
            InizializzaTifosi(n);

            foreach (var t in tifosi)
                tasks.Add(t.RunAsync(this, cts));

            tasks.Add(barista.RunAsync(cts.Token));
            
            await Task.WhenAll(tasks);
        }

        public async Task EnterAsync(Tifoso t, CancellationToken token)
        {
            lock (_lock)
            {
                if (!t.GetHome())
                    ospitiInAttesa++;

                while(eBarChiuso || (squadraDentro != null && squadraDentro != t.GetHome()) || (t.GetHome() && ospitiInAttesa > 0))
                {
                    Monitor.Wait(_lock);
                }

                if(!t.GetHome())
                    ospitiInAttesa--;

                squadraDentro ??= t.GetHome();
                tifosiDentro++;

                Console.WriteLine($"Entra il tifoso {(t.GetHome() ? "CASA" : "TRASFERTA")}");
                Console.WriteLine($"[tifosi dentro: {tifosiDentro}, squadra {(t.GetHome() ? "CASA" : "TRASFERTA")}] \n");
            }

            await _posti.WaitAsync(token);
        }

        public void Exit(Tifoso t)
        { 
            _posti.Release();

            lock (_lock)
            {
                tifosiDentro--;
                Console.WriteLine($"Esce tifoso: {(t.GetHome() ? "CASA" : "TRASFERTA")}");
                Console.WriteLine($"[tifosi dentro: {tifosiDentro}, squadra {(t.GetHome() ? "CASA" : "TRASFERTA")}] \n");

                if (tifosiDentro == 0)
                    squadraDentro = null;

                Monitor.PulseAll(_lock);
            }
        }

        public async Task StartCleaning()
        {
            lock (_lock)
            {
                Console.WriteLine("Bar chiuso per pulizia");
                eBarChiuso = true;

                while (tifosiDentro > 0) //il barista rilascia il lock e aspetta che sia vuoto il bar per pulire
                    Monitor.Wait(_lock);
            }

            Console.WriteLine("Pulizia in corso...");
            await Task.Delay(5000);

            lock (_lock)
            {
                eBarChiuso = false;
                Console.WriteLine("Bar riapre");
                Monitor.PulseAll(_lock);
            }
        }

    }
}
