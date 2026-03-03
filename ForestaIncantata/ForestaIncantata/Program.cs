namespace ForestaIncantata
{
    using System.Runtime.CompilerServices;
    using System.Security.Cryptography.X509Certificates;
    using static System.Console;
    internal class Program
    {
        public static bool vittoria = false;
        public static bool turno = true;
        static void Main(string[] args)
        {
            Tabellone tabellone = new Tabellone();
            WriteLine("Benvenuti nella Foresta Incantata!");
             
            while (!vittoria)
            {
                tabellone.Giocaturno(turno);
                turno = !turno;
                Console.ReadKey();
            }
        }
    }
}
