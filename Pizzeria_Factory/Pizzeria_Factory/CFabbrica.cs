using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria_Factory
{
    internal class CFabbrica
    {
        private static readonly List<string> NomiPizze = new List<string>
        {
            "Margherita",
            "Frasson El Pasticcion",
            "Schiavi",
            "Suan",
            "Sergente Ricino",
            "Marinara",
            "Prosciutto e Funghi",
            "Quattro Formaggi",
            "Ortolana",
            "La Biondona Porcellona"
        };

        public static IPizza CreaPizza(string tipo)
        {
            string type = tipo.ToLowerInvariant().Replace(" ", "");

            switch (type)
            {
                case "margherita":
                    return new Margherita();
                case "frassonelpasticcion":
                    return new FrassonElPasticcion();
                case "schiavi":
                    return new Schiavi();
                case "suan":
                    return new Suan();
                case "sergentericino":
                    return new SergenteRicino();
                case "marinara":
                    return new Marinara();
                case "prosciuttofunghi":
                    return new ProsciuttoFunghi();
                case "quattroformaggi":
                    return new QuattroFormaggi();
                case "ortolana":
                    return new Ortolana();
                case "labiondonaporcellona":
                    return new LaBiondonaPorcellona();
                default:
                    throw new ArgumentException($"Tipo di pizza '{tipo}' non è nel nostro menu.");
            }
        }

        public string WritelinePizze()
        {
            string pizze = "";
            for (int i = 0; i < NomiPizze.Count; i++)
            {
                pizze += $"{NomiPizze[i]} \n";
            }
            return pizze;
        }
    }
}
