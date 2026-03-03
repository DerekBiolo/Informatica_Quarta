namespace Pizzeria_Factory
{
    using static System.Console;
    internal class Program
    {
        static void Main(string[] args)
        {
            CFabbrica fabbrica = new CFabbrica();
            IPizza pizza;

            WriteLine("Benveuto da Pizzeria Gangster");
            WriteLine("Pizze disponibili:");

            WriteLine(fabbrica.WritelinePizze());

            WriteLine("Scrivi il nome di una pizza per ordinarla");
            string pizzaOrdinata = ReadLine();

            pizza = CFabbrica.CreaPizza(pizzaOrdinata);

            WriteLine($"Ordine accettato: {((CPizzas)pizza).GetNome()}");
            WriteLine(pizza.Prepara());
            WriteLine(pizza.Cucina());

            ReadLine();
        }
    }
}