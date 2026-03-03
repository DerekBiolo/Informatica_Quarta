namespace FigurePiane
{
    using System;
    using static System.Console;

    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Benvenuto nel generatore di figure");

            string scelta;
            do
            {
                WriteLine("\nScegli la figura da generare:");
                WriteLine("1. Rettangolo");
                WriteLine("2. Cerchio");
                WriteLine("0. Esci");
                scelta = ReadLine();

                GestisciScelta(scelta);

            } while (scelta != "0");

            WriteLine("\nGrazie per aver usato il generatore!");
        }

        private static void GestisciScelta(string s)
        {
            switch (s)
            {
                case "1":
                    Write("Inserisci la larghezza del rettangolo: ");
                    double larghezza = double.Parse(ReadLine());
                    Write("Inserisci l'altezza del rettangolo: ");
                    double altezza = double.Parse(ReadLine());

                    CRettangolo r = new CRettangolo(larghezza, altezza);
                    WriteLine($"Perimetro: {r.CalcolaPerimetro()}");
                    WriteLine($"Area: {r.CalcolaArea()}");
                    break;

                case "2":
                    Write("Inserisci il raggio del cerchio: ");
                    double raggio = double.Parse(ReadLine());

                    CCerchio c = new CCerchio(raggio);
                    WriteLine($"Perimetro: {c.CalcolaPerimetro():F2}");
                    WriteLine($"Area: {c.CalcolaArea():F2}");
                    break;

                case "0":
                    break;

                default:
                    WriteLine("Scelta non valida!");
                    break;
            }
        }
    }
}
