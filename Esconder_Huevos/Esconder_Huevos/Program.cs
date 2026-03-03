namespace Esconder_Huevos
{
    using LinkedCoda;
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedCoda<Huevo> ScivoloHuevos = new LinkedCoda<Huevo>();
            LinkedCoda<Huevo> NascondiglioHuevos = new LinkedCoda<Huevo>();
            CancellationTokenSource cts = new CancellationTokenSource();
            BugsBunny bugsBunny = new BugsBunny(ScivoloHuevos, cts);
            Anselmo anselmo = new Anselmo(bugsBunny, NascondiglioHuevos, cts);

            List<Task> tasks = new List<Task>
            {
                Task.Run(() => bugsBunny.ProduciUovo()),
                Task.Run(() => anselmo.ControllaENascondi())
            };
            Task.WaitAll(tasks.ToArray());

        }
    }
}
