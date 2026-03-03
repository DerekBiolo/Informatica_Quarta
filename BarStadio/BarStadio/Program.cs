using System;
using System.Threading;
using System.Threading.Tasks;

namespace BarStadio
{
    using static System.Console;

    internal class Program
    {
        static int NMAX = 4;
        static int TIFOSI = 10;
        static async Task Main(string[] args)
        {

            SemaphoreSlim BarSemaphore = new(NMAX, NMAX);

            CancellationTokenSource cts = new();

            Bar bar = new(BarSemaphore, NMAX, cts);

            await bar.StartAsync(TIFOSI);

            ReadLine();
        }
    }
}
