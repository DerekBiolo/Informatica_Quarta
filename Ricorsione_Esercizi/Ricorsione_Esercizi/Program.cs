namespace Ricorsione_Esercizi
{
    using static System.Console;
    internal class Program
    {
        private static void Main()
        {
            Random r = new Random();
            int[] array = new int[10];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next(1, 6);
            }

            WriteLine("Array iniziale:");
            StampaArray(array);

            WriteLine("\nInserisci un numero:");
            int numero = int.Parse(ReadLine()!);
            WriteLine("Inserisci from:");
            int from = int.Parse(ReadLine()!);
            WriteLine("Inserisci to:");
            int to = int.Parse(ReadLine()!);

            int trovati = Trova(numero, from, to, array);
            WriteLine($"Il numero {numero} è stato trovato {trovati} volte");

            WriteLine("\nArray PRIMA dell'inversione:");
            StampaArray(array);

            Inverti(array, from, to);

            WriteLine("\nArray DOPO l'inversione:");
            StampaArray(array);

            WriteLine("\nQuanto è grande il piano delle piastrelle (1 * n)?");
            int n = int.Parse(ReadLine()!);
            int combinazioni = FibonacciNumeroPiastrelle(n);
            WriteLine($"Numero di combinazioni delle piastrelle = {combinazioni}");

            WriteLine("\nInserisci un numero n di persone per calcolare le amicizie possibili:");
            int numeroAmicizie = int.Parse(ReadLine()!);
            int amicizie = Friends(numeroAmicizie);
            WriteLine($"Numero di amicizie possibili per {numeroAmicizie} persone = {amicizie}");

            WriteLine("Inserisci la cifra da sommare ( es 134 => 8 )");
            //int cifra = int.Parse(ReadLine()!);
            //int sommaCifre = cifreSommate(cifra);
            //WriteLine("Cifra sommata = " + sommaCifre);

            WriteLine("Inserisci la lunghezza N della tabella N*M");
            int N = int.Parse(ReadLine()!);
            WriteLine("Inserisci la largezza della tabella " + N + "xM");
            int M = int.Parse(ReadLine()!);

            int percorsi = trovaPercorsi(N, M);
            WriteLine("I percorsi sono = " + percorsi);
        }

        static int trovaPercorsi(int n, int m)
        {
            if (n == 0 || m == 0) return 0;

            if (n == 1 && m == 1) return 1;

            return trovaPercorsi(n - 1, m) + trovaPercorsi(n, m - 1);
        }

        private static int cifreSommate(int n)
        {
            if (n < 10) return n;
            int numero = n % 10;
            n = numero + cifreSommate(numero);
            return n;
        }

        private static int Friends(int n)
        {
            if (n < 2) return 0;
            return (n - 1) + Friends(n - 1);
        }

        private static readonly int[] Memorizzazione = Enumerable.Repeat(-1, 100).ToArray();

        private static int FibonacciNumeroPiastrelle(int n)
        {
            if (n <= 2) return n;

            if (Memorizzazione[n] != -1)
                return Memorizzazione[n];

            int risultato = FibonacciNumeroPiastrelle(n - 1) + FibonacciNumeroPiastrelle(n - 2);
            Memorizzazione[n] = risultato;
            return risultato;
        }

        private static int Trova(int numero, int from, int to, int[] array)
        {
            if (from > to)
                return 0;

            int conta = array[from] == numero ? 1 : 0;
            return conta + Trova(numero, from + 1, to, array);
        }

        private static void Inverti(int[] array, int from, int to)
        {
            if (from >= to)
                return;

            (array[from], array[to]) = (array[to], array[from]);
            Inverti(array, from + 1, to - 1);
        }

        private static void StampaArray(int[] array)
        {
            Write("[");
            for (int i = 0; i < array.Length; i++)
            {
                Write(array[i]);
                if (i < array.Length - 1)
                    Write(", ");
            }
            WriteLine("]");
        }
    }
}