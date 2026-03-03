using System.Diagnostics;
using System.Threading.Tasks;

namespace Stampante_Asincrona
{
    using static System.Console;
    internal class Program
    {
        // 1 Perché il tempo parallelo è minore di quello sequenziale?
        // Perche nella stampa parallela tutti i documenti vengono stampati allo stesso tempo, quindi il tempo deriva
        // dal documento con il maggior numero di pagine, mentre nella stampa sequenziale è la somma di tutte le stampe, perchè
        // le stampe attendono la stampa precedente prima di iniziare

        // 2 L’ordine di completamento coincide con l’ordine dei documenti?
        // Dipende, in quella sequenziale si, mentre in quella parallela vanno da quello con pagine minori a quello con pagine maggiori

        // 3 Cosa succede se un documento ha molte più pagine degli altri?
        // In quella sequenziale e un blocco per tutto, fermando temporaneamente tutto, mentre in quella parallela, sebbena lui stesso ci metta
        // tanto a completarsi, lascia la possibilità a tutti gli altri di completarsi

        // 4 Perché il metodo Main deve essere dichiarato async Task?
        // Perchè lui stesso gestisce funzioni await, quindi per far si che il programma non si blocchi, diventa lui stesso un task cosi da
        // poter aspettare i metodi asincroni

        static async Task Main(string[] args)
        {
            var files = new List<(string nome, int pagine)>
            {
                ("Il Manifesto del Partito Comunista", 3),
                ("Il Capitale",4),
                ("Stato e rivooluzione",2),
                ("Quaderni del carcere",8),
                ("Riforma sociale e rivolizione",5)
            };
            Console.ForegroundColor = ConsoleColor.Blue;
            WriteLine("---| Stampa Sequenziale |---");
            long tempoSequenziale = await StampaSequenziale(files);

            Console.ForegroundColor = ConsoleColor.Red;
            WriteLine("\n---| Stampa Parallela |---");
            long tempoParallelo = await StampaParallela(files);

            Console.ForegroundColor = ConsoleColor.Green;
            WriteLine("\n---| Tempistica Finale |---");
            WriteLine($"Stampa Sequenziale = {tempoSequenziale} ms");
            WriteLine($"Stampa Parallela = {tempoParallelo} ms");
            WriteLine($"Differenza = {tempoSequenziale - tempoParallelo} ms");

            Console.ForegroundColor = ConsoleColor.White;
        }

        static async Task<string> StampaDocumento(string nome, int pagine)
        {
            WriteLine($"Attesa della stampa di: {nome}");
            await Task.Delay(pagine * 300);
            return $"Stampa completata {nome}";
        }

        static async Task<long> StampaSequenziale(List<(string nome, int pagine)> documenti)
        {
            var timer = Stopwatch.StartNew();

            foreach(var documento in documenti)
            {
                string ris = await StampaDocumento(documento.nome, documento.pagine);
                WriteLine(ris);
            }

            timer.Stop();
            return timer.ElapsedMilliseconds;
        }

        static async Task<long> StampaParallela(List<(string nome, int pagine)> documenti)
        {
            var timer = Stopwatch.StartNew();

            var tasks = documenti.Select(d => StampaDocumento(d.nome, d.pagine)).ToList();
            // chiamo ogni elemento in documenti con Select e avvio la stampa ( d => StampaDocumento ), e poi preservo tutti questi task generati in tasks

            while (tasks.Count > 0)
            {
                Task<string> completato = await Task.WhenAny(tasks);
                // aspetto la prima qualsiasi stampa completata, la scrivo e la tolgo
                WriteLine(await completato);
                tasks.Remove(completato);
            }

            timer.Stop();
            return timer.ElapsedMilliseconds;
        }
    }
}
