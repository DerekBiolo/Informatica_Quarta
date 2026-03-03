using System;

namespace EsercitazioneVerifica
{
    public class TimerClass
    {
        int Intervallo;
        public EventHandler OnTick;

        public TimerClass(int i)
        {
            Intervallo = i;
        }

        public void Tick()
        {
            while (true)
            {
                Thread.Sleep(Intervallo * 1000);
                OnTick?.Invoke(this, null);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            TimerClass t = new(1);
            t.OnTick += Tick;
        }

        static void Tick(object sender, EventArgs e)
        {
            Console.WriteLine("Tick!");
        }
    }
}
