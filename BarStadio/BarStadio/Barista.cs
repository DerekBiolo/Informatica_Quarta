using System;
using System.Collections.Generic;
using System.Text;

namespace BarStadio
{
    internal class Barista
    {
        private Bar bar;

        public Barista(Bar b)
        {
            bar = b;
        }

        public async Task RunAsync(CancellationToken token)
        {
            while(!token.IsCancellationRequested)
            {
                await bar.StartCleaning();
            }
        }
    }
}
