namespace EsercizioCodaPila
{
    using LinkedCoda;
    using LinkedPila;
    using static System.Console;

    internal class Program
    {
        static HashSet<char> operatori = new HashSet<char> { '+', '-', '*', ':' };
        static HashSet<char> parentesiAperte = new HashSet<char> { '(', '[', '{' };
        static HashSet<char> parentesiChiuse = new HashSet<char> { ')', ']', '}' };

        static void Main(string[] args)
        {
            LinkedCoda<string> Coda = new LinkedCoda<string>();
            LinkedPila<char> Pila = new LinkedPila<char>();

            string espressione;
            string numeroCorrente = "";

            do
            {
                WriteLine("Inserisci un espressione");
                espressione = ReadLine();
            } while (string.IsNullOrEmpty(espressione));

            foreach (char carattere in espressione)
            {
                // 1. Carattere vuoto
                if (carattere == ' ')
                {
                    if (numeroCorrente != "") // Controllo se stavo costruendo un numero
                    {
                        Coda.Enqueue(numeroCorrente);
                        numeroCorrente = "";
                    }
                    continue; // Altrimenti vado avanti
                }


                // 2. Numero
                if (char.IsDigit(carattere))
                {
                    numeroCorrente += carattere; //aggiungo al numero che sto costrunedo
                }
                else // 3. Altro
                {
                    if (numeroCorrente != "") // Se trovo altro metto in coda il numero che ho costruito
                    {
                        Coda.Enqueue(numeroCorrente);
                        numeroCorrente = "";
                    }

                    // 3. Operando
                    if (operatori.Contains(carattere))
                    { 
                        while (!Pila.IsEmpty() && Priorita(Pila.Peek()) >= Priorita(carattere)) // Svuoto la pila con priorità nella coda
                        {
                            Coda.Enqueue(Pila.Pop().ToString());
                        }
                        Pila.Push(carattere); // Metto nella pila in carattere
                    }
                    else if (parentesiAperte.Contains(carattere)) // 4. Parentesi aperta (marker)
                    {
                        Pila.Push(carattere); // Metto e basta
                    }
                    else if (parentesiChiuse.Contains(carattere)) // 5. Chiusa
                    {
                        while (!Pila.IsEmpty() && !parentesiAperte.Contains(Pila.Peek())) //finche o non e vuota o non trovo la parentesi apperta sua
                        {
                            Coda.Enqueue(Pila.Pop().ToString());
                        }
                        Pila.Pop();
                    }
                }
            }

            if (numeroCorrente != "") // Svuoto un numero che puo essere rimassto
                Coda.Enqueue(numeroCorrente);

            while (!Pila.IsEmpty())
            {
                Coda.Enqueue(Pila.Pop().ToString()); // scuoto la pila
            }

            string espressioneFinale = "";

            while (!Coda.IsEmpty())
            {
                espressioneFinale += $"{Coda.Dequeue()} ";
            }

            WriteLine(espressioneFinale);
            Calcola(espressioneFinale);
        }

        static int Priorita(char operando) // controllo priorita
        {
            if (operando == '*' || operando == ':') return 2;
            if (operando == '+' || operando == '-') return 1;
            return 0;
        }

        static void Calcola(string espressione)
        {
            LinkedPila<double> numeri = new LinkedPila<double>();

            string[] tokens = espressione.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string token in tokens)
            {
                if (double.TryParse(token, out double d))
                {
                    numeri.Push(d);
                }

                else if (token.Length == 1 && operatori.Contains(token[0]))
                { 
                    double b = numeri.Pop();
                    double a = numeri.Pop();

                    double risultato = token[0] switch
                    {
                        '+' => Addizione(a, b),
                        '-' => Sottrazione(a, b),
                        '*' => Moltiplicazione(a, b),
                        ':' => Divisione(a, b),
                        _ => throw new ArgumentException("L'operatore non esiste")
                    };

                    numeri.Push(risultato);
                }
            }

            WriteLine($"Risultato: {numeri.Pop()}");
        }

        static double Addizione(double a, double b)
        {
            double risultato = a + b;
            WriteLine($"Operazione attuale: {a} {b} +");
            return risultato;
        }

        static double Sottrazione(double a, double b)
        {
            double risultato = a - b;
            WriteLine($"Operazione attuale: {a} {b} -");
            return risultato;
        }

        static double Moltiplicazione(double a, double b)
        {
            double risultato = a * b;
            WriteLine($"Operazione attuale: {a} {b} *");
            return risultato;
        }

        static double Divisione(double a, double b)
        {
            if(b == 0)
            {
                throw new DivideByZeroException();
            } else
            {
                double risultato = a / b;
                WriteLine($"Operazione attuale: {a} {b} :");
                return risultato;
            }
        }
    }
}