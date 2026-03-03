namespace Shapes
{
    using System;
    using System.Drawing;
    using static System.Console;

    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                WriteLine("Shapes Program");
                int scelts = ReadChoice();

                switch (scelts)
                {
                    case 1: // Rettangolo
                        double larghezza = ReadPositiveDouble("Inserisci la larghezza del rettangolo:");
                        double altezza = ReadPositiveDouble("Inserisci l'altezza del rettangolo:");
                        CDrawableRectangle rettangolo = new CDrawableRectangle(larghezza, altezza);
                        SetColorAndPosition(rettangolo);
                        WriteLine("--------------------------------");
                        rettangolo.Draw();
                        WriteLine("--------------------------------");
                        WriteLine($"Area del rettangolo: {rettangolo.GetArea()}");
                        WriteLine($"Perimetro del rettangolo: {rettangolo.GetPerimeter()}");
                        //aspetto un input prima di continuare e pulisco lo schermo
                        //creo un animazione . .. ... . .. ...
                        bool pressed = false;
                        int step = 0;
                        while (!pressed)
                        {
                            string dots = step % 3 == 0 ? "." : step % 3 == 1 ? ".." : "...";
                            Write($"\rPremi Enter per continuare{dots}   ");
                            Thread.Sleep(500);
                            step++;
                            if (KeyAvailable && ReadKey(true).Key == ConsoleKey.Enter)
                                pressed = true;
                        }
                        Clear();
                        break;

                    case 2: // Cerchio
                        double raggio = ReadPositiveDouble("Inserisci il raggio del cerchio:");
                        CDrawableCircle cerchio = new CDrawableCircle(raggio);
                        SetColorAndPosition(cerchio);
                        WriteLine("--------------------------------");
                        cerchio.Draw();
                        WriteLine("--------------------------------");
                        WriteLine($"Area del cerchio: {cerchio.GetArea()}");
                        WriteLine($"Perimetro del cerchio: {cerchio.GetPerimeter()}");

                        //aspetto un input prima di continuare e pulisco lo schermo
                        //creo un animazione . .. ... . .. ...
                        bool presse = false;
                        int ste = 0;
                        while (!presse)
                        {
                            string dots = ste % 3 == 0 ? "." : ste % 3 == 1 ? ".." : "...";
                            Write($"\rPremi Enter per continuare{dots}   ");
                            Thread.Sleep(500);
                            ste++;
                            if (KeyAvailable && ReadKey(true).Key == ConsoleKey.Enter)
                                presse = true;
                        }
                        Clear();
                        break;

                    case 0:
                        WriteLine("Uscita dal programma.");
                        exit = true;
                        break;
                }

                WriteLine();
            }
        }

        // Legge la scelta dell'utente in modo sicuro
        static int ReadChoice()
        {
            int scelta;
            do
            {
                Clear();
                WriteLine("Scelta la forma da calcolare:");
                WriteLine("1 - Rettangolo");
                WriteLine("2 - Cerchio");
                WriteLine("0 - Esci");
            } while (!int.TryParse(ReadLine(), out scelta) || scelta < 0 || scelta > 2);

            return scelta;
        }

        // Legge un double positivo
        static double ReadPositiveDouble(string message)
        {
            double value;
            do
            {
                WriteLine(message);
            } while (!double.TryParse(ReadLine(), out value) || value <= 0);
            return value;
        }

        // Imposta colore e posizione a un oggetto IDrawable
        static void SetColorAndPosition(IDrawable shape)
        {
            WriteLine("Inserisci il colore");
            WriteLine("Colori disponibili: Red, Green, Blue, Yellow, Cyan, Magenta, White, Black");
            string? colorName = ReadLine();
            Color color = Color.FromName(colorName ?? "Black");
            shape.SetColor(color);

            int x = (int)ReadPositiveDouble("Inserisci la coordinata X:");
            int y = (int)ReadPositiveDouble("Inserisci la coordinata Y:");

            shape.SetPosition(x, y);
        }
    }
}
