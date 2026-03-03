namespace AttaccoAlRe
{
    using static System.Console;
    public delegate void AttaccoEventHandler(object sender, EventArgs e);
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("=== DIFENDI IL RE ===");

            string fileInput = "input.txt";

            if (!File.Exists(fileInput))
            {
                CreaDatiEsempio(fileInput);
                WriteLine("File di input creato con dati defaulters");
            }

            SistemaDifesa sistemas = new();
            bool risult = sistemas.CaricaDaFile(fileInput);

            if (!risult) {
                WriteLine("Arrivato al comando end hai perso la partita.");
            }
            WriteLine("Premi un tasto per uscire...");
            ReadKey();
        }

        static void CreaDatiEsempio(string percorso)
        {
            string[] datiEx = new string[]
            {
                "Ammiraglio",
                "Bucaresti Barontopa Clito Besoli Lancelot Genitalz Trucco",
                "Predone ChristianSomma Lesley Brad America Mistopesce Porca Lumiere",
                "Attacca Re",
                "Cattura Lumiere",
                "Cattura Predone",
                "Cattura Bucaresti",
                "Attacca Re",
                "Cattura ChristianSomma",
                "Cattura Clito",
                "Cattura Lesley",
                "Attacca Re",
                "Cattura Barontopa",
                "Cattura Brad",
                "Cattura Besoli",
                "Attacca Re",
                "Cattura America",
                "Cattura Lancelot",
                "Attacca Re",
                "Cattura Mistopesce",
                "Cattura Genitalz",
                "Attacca Re",
                "Cattura Porca",
                "Cattura Trucco",
                "Attacca Re",
                "Cattura Ammiraglio",
                "Attacca Re",
                "End"
            };
            File.WriteAllLines(percorso, datiEx);
        }
    }
}
