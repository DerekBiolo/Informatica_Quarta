using System;
using System.Collections.Generic;
using System.Text;

namespace BarStadio
{
    internal class Tifoso
    {
        private bool Home;
        public bool eDentro { get; set; }
        public Tifoso(bool Home)
        {
            this.Home = Home;
        }

        public bool GetHome() => Home;

        public async Task RunAsync(Bar bar, CancellationTokenSource cts)
        {
            Console.WriteLine($"Arrivato un tifoso {(Home ? "Casa" : "Trasferta")}\n");

            await bar.EnterAsync(this, cts.Token);
            await Task.Delay(Random.Shared.Next(1000, 10001), cts.Token);
            bar.Exit(this);
        }
    }
}
