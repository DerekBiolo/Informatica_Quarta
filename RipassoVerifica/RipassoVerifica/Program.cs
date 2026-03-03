using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static int _counter = 0;
    static SemaphoreSlim _barrier = new SemaphoreSlim(0, 3);
    static List<Task> _tasks = new List<Task>();
    static SemaphoreSlim _mutex = new SemaphoreSlim(1, 1);

    static async Task Main()
    {
        for (int i = 0; i < 3; i++)
        {
            _tasks.Add(Incrementer(Random.Shared.Next(1, 1000)));
        }

        await Task.Delay(1000);
        _barrier.Release(3);

        await Task.WhenAll(_tasks);
        Console.WriteLine($"Counter: {_counter}");
    }

    static async Task Incrementer(int value)
    {
        await _barrier.WaitAsync();
        await _mutex.WaitAsync();
        try
        {
            await Task.Delay(value);
            _counter += value;
            Console.WriteLine($"Added {value}, counter is now {_counter}");
        }
        finally
        {
            _mutex.Release();
        }
    }
}
