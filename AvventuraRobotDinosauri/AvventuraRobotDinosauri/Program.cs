namespace AvventuraRobotDinosauri
{
    using LinkedCoda;
    using LinkedPila;

    internal class Program
    {
        static string[] nomiHardPerIRobot = new string[]
        {
            "Gucci Mane",
            "Jeezy",
            "Boosie",
            "Webbie",
            "Kodak",
            "NBA Youngboy",
            "Mozzy",
            "Pooh Shiesty",
            "Moneybagg",
            "42 Dugg",
            "EST Gee",
            "Rylo Rodriguez",
            "Sada Baby",
            "Finesse2Tymes",
            "Quando Rondo",
            "Lil Durk",
            "Lil Baby",
            "Chief Keef",
        };

        static string[] nomiHardPerIDinoDino = new string[]
        {
            "Massimo Pericolo",
            "Taxi B",
            "Vale Pain",
            "Neima Ezza",
            "Sacky",
            "Nader",
            "Nashley",
            "Izi",
            "Warez",
            "Slings",
            "Keta Music",
            "Ghost",
            "Nex Cassel",
            "Rondodasosa",
            "Shiva",
            "Tonno",
        };

        static async Task Main(string[] args)
        {
            //magazzino condiviso
            Magazzino magazzinoCondiviso = new Magazzino();
            LinkedPila<Componente> pilaComponentiComune = new LinkedPila<Componente>();

            var ListaRobot = new LinkedPila<Robot>();
            var ListaDinoDino = new LinkedPila<Dinosauro>();

            //creo un totale random di robot e dinoDino
            Random random = new Random();
            int numeroRobot = random.Next(1, 10);
            int numeroDinoDino = random.Next(1, 10);

            //creo i robot e i dinoDino e li aggiungo alle rispettive liste
            for (int i = 0; i < numeroRobot; i++)
            {
                string nomeRobot = nomiHardPerIRobot[random.Next(nomiHardPerIRobot.Length)];
                Robot robot = new Robot(nomeRobot, magazzinoCondiviso);
                ListaRobot.Push(robot);
            }
            for (int i = 0; i < numeroDinoDino; i++)
            {
                string nomeDinoDino = nomiHardPerIDinoDino[random.Next(nomiHardPerIDinoDino.Length)];
                int altezzaTarget = random.Next(3, 7); // altezza target tra 3 e 6 pezzi
                Dinosauro dinoDino = new Dinosauro(nomeDinoDino, magazzinoCondiviso, altezzaTarget, pilaComponentiComune);
                ListaDinoDino.Push(dinoDino);
            }

            //mostro quanti robot e dinoDino sono stati creati
            Console.WriteLine($"Sono stati creati {numeroRobot} robot e {numeroDinoDino} dinoDino!");


            var taskRobot = new List<Task>();
            foreach (var robot in ListaRobot)
            {
                taskRobot.Add(robot.Raccogli(Random.Shared.Next(1, 5))); // ogni robot raccoglie tra 1 e 4 pezzi
            }
            
            var taskDinoDino = new List<Task>();
            foreach (var dinoDino in ListaDinoDino)
            {
                taskDinoDino.Add(dinoDino.Costruisci());
            }

            await Task.WhenAll(taskRobot);
            magazzinoCondiviso.produzioneTerminata = true; // segnalo che la produzione è terminata

            await Task.WhenAll(taskDinoDino);
            Console.WriteLine("Tutti i robot hanno raccolto i pezzi e tutti i dinoDino hanno costruito i loro dinosauri!");
        }
    }
}
