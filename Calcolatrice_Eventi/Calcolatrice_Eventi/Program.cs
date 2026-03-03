using System.Net.Http.Headers;

namespace Calcolatrice_Eventi
{
    delegate double Calcolatrice(double v1, double v2);
    internal class Program
    {

        static public double Somma(double v1, double v2)
        {
            return v1 + v2;
        }

        static public double Sottrazione(double v1, double v2)
        {
            return v1 - v2;
        }

        static public double Moltiplicazione(double v1, double v2)
        {
            return v1 * v2;
        }

        static public double Divisione(double v1, double v2)
        {
            if (v2 == 0)
                throw new DivideByZeroException("Divisione per zero non consentita.");

            return v1 / v2;
        }

        static void Main(string[] args)
        {


            double valore1, valore2;
            string operazione;

            Console.WriteLine("Inserisci il primo valore: ");
            valore1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Inserisci il secondo valore: ");
            valore2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Inserisci l'operazione ==> | + , - , * , / |");
            operazione = Console.ReadLine();

            Calcolatrice calcola = null;

            switch (operazione)
            {
                case "+":
                    calcola = Somma;
                    break;
                case "-":
                    calcola = Sottrazione;
                    break;
                case "*":
                    calcola = Moltiplicazione;
                    break;
                case "/":
                    calcola = Divisione;
                    break;
                default:
                    Console.WriteLine("Operazione non valida.");
                    return;
            }

            double risultato = calcola(valore1, valore2);
            Console.WriteLine($"Il risultato di {valore1} {operazione} {valore2} è: {risultato:F2}");
        }
    }
}
