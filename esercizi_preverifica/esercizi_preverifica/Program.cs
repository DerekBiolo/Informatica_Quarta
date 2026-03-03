namespace esercizi_preverifica
{
    using System.Numerics;
    using static System.Console;
    internal class Program
    {
        static void Main(string[] args)
        {
            Esercizio1();
            Esercizio2();
        }

        static void Esercizio1()
        {
            CCane cane = new();
            cane.Verso();
        }

        static void Esercizio2()
        {
            List<CVeicolo> veicoli = new();
            CAuto auto = new(100);
            CBicicletta bicicletta = new(20);
            veicoli.Add(auto);
            veicoli.Add(bicicletta);

            foreach (var v in veicoli)
            {
                v.Muovi();
            }
        }
    }
}
