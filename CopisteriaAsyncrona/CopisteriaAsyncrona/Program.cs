namespace CopisteriaAsyncrona
{
    internal class Program
    {
        static async Task Main(string[] args)
        { 
            Copisteria copisteria = new(3); //3 stampanti
            var studenti = new List<Task>();
            for (int i = 0; i < 5; i++)
            {
                studenti.Add(Studente(copisteria, i, 5)); //5 documenti per studente
            }

            var Assistenti = new List<Task>();
            for (int i = 0; i < 3; i++)
            {
                Assistenti.Add(Assistente(copisteria, i));
            }

            await Task.WhenAll(Assistenti);
        }

        static async Task Studente( Copisteria c, int id, int numDocumenti)
        {
            for (int i = 0; i < numDocumenti; i++)
            {
                var doc = new Documento($"Doc{id}_{i}", Random.Shared.Next(1, 4), i);
                Console.WriteLine($"Studente {id} ha creato {doc.Nome}");
                await c.InserisciDocumento(doc);
                Console.WriteLine($"Studente {id} ha inserito {doc.Nome}");
                await Task.Delay(Random.Shared.Next(500, 1000));
            }
        }

        static async Task Assistente(Copisteria c, int id)
        {
            while (true)
            {
                var doc = await c.PrendiDocumento();
                Console.WriteLine($"Assistente {id} sta stampando {doc.Nome}");
                await Task.Delay(Random.Shared.Next(1000, 2000));
                Console.WriteLine($"Assistente {id} ha finito di stampare {doc.Nome}");
                c.StampaFinita();
            }
        }
    }
}
