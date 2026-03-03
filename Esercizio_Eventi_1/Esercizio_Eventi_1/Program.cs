using System.Runtime.CompilerServices;

namespace Esercizio_Eventi_1
{
    // definisco il delegato degli handler degli eventi
    public delegate void AlarmEventHandler(object sender, AlarmEventArgs args);

    // definisco la classe che ha le informazioni dell'evento
    public class AlarmEventArgs : EventArgs
    {
        public int SogliaRilevata { get; set; }
        public string TipoAllarme { get; set; }
        public AlarmEventArgs(int sogliaRilevata, string tipoAllarme)
        {
            SogliaRilevata = sogliaRilevata;
            TipoAllarme = tipoAllarme;
        }
    }

    public class Sensore
    {
        public int SogliaMinimaTemp;
        public int SogliaMassimaTemp;
        public int SogliaMassimaGas;
        public int totTemperaturaRilevata = 0;
        public int totGasRilevato = 0;

        Random r = new Random();

        public event AlarmEventHandler? AllarmeScattato;

        protected virtual void OnAllarmeScattato(AlarmEventArgs e)
        {
            AllarmeScattato?.Invoke(this, e);
        }

        public void Controlla()
        {
            // simulazione
            int temperatura = r.Next(-20, 50);
            int gas = r.Next(0, 500);

            if (temperatura < SogliaMinimaTemp || temperatura > SogliaMassimaTemp)
            {
                AlarmEventArgs args = new AlarmEventArgs(temperatura, "Temperatura");
                OnAllarmeScattato(args);
                totTemperaturaRilevata++;
            }

            if (gas > SogliaMassimaGas)
            {
                AlarmEventArgs args = new AlarmEventArgs(gas, "Gas");
                OnAllarmeScattato(args);
                totGasRilevato++;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Sensore s = new()
            {
                SogliaMassimaGas = 300,
                SogliaMassimaTemp = 30,
                SogliaMinimaTemp = 0
            };

            s.AllarmeScattato += GestoreAllarme;

            for(int i = 0; i < 10; i++)
            {
                s.Controlla();
            }
            Console.WriteLine("\n\n");
            Console.WriteLine("Rilevamenti totali:");
            Console.WriteLine("Temperatura: " + s.totTemperaturaRilevata);
            Console.WriteLine("Gas: " + s.totGasRilevato);

            static void GestoreAllarme(object sender, AlarmEventArgs args)
            {
                Console.WriteLine($"--| Allarme di tipo {args.TipoAllarme} rilevato: {args.SogliaRilevata} |--");
            }
        }
    }
}
