namespace CreaLaTuaFlotta
{
    using static System.Console;
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            List<CVeicolo> flotta = new List<CVeicolo>
            {
                new CBicicletta("Bicicleticos", "B001", true),
                new CMonopattino("Monoze di Nicola", "M001", false),
                new CElicottero("Elicotterone", 5000),
                new CDrone("Dronasso", 3000)
            };

            foreach (var v in flotta)
            {
                v.Accendi();
                v.MostraInfo();

                //check se è volate
                if (v is IVolante vol)
                {
                    vol.Vola();
                }

                //check se condivisibile
                if (v is ICondivisibile con)
                {
                    WriteLine($"ID: {con.Id}, Disponibile: {con.Disponibile}");
                }

            }
            WriteLine("Premi un tasto per uscire...");
        }
    }
}
