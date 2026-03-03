namespace BancaAsyncrona
{
    internal class Program
    {
        static int MAX_CLIENTI;
        static int MAX_ENTRATE;
        static async Task Main()
        {
            MAX_CLIENTI = 15;
            MAX_ENTRATE = 3;

            Cabina cabina = new(MAX_ENTRATE);

            List<Cliente> clienti = [];
            List<Task> tasks = [];

            for (int i = 0; i < MAX_CLIENTI; i++)
            {
                Cliente c = new();
                clienti.Add(c);
                tasks.Add(c.SimulaIngresso(cabina));
            }

            await Task.WhenAll(tasks);

            Console.WriteLine("Simulazione terminata, tutti i clienti sono stati eseguiti.");
        }
    }
}
