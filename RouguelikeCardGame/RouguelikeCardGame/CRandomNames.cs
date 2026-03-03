using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouguelikeCardGame
{
    internal class CRandomNames
    {
        List<string> names = new List<string>()
        {
            "Aragorn", "Legolas", "Gimli", "Frodo", "Samwise",
            "Gandalf", "Boromir", "Elrond", "Galadriel", "Eowyn",
            "Thorin", "Bilbo", "Saruman", "Sauron", "Arwen",
            "Faramir", "Theoden", "Denethor", "Pippin", "Merry",
            "Radagast", "Gollum", "Shelob", "Treebeard", "Eomer",
            "Isildur", "Celebrimbor", "Balin", "Dwalin", "Kili",
            "Tauriel", "Luthien", "Yavanna", "Varda", "Nimrodel",
            "Melian", "Idril", "Morwen", "Haleth", "Finduilas",
            "Aredhel", "Glorfindel", "Nessa", "Uinen", "Vairë",
            "Nienna", "Eruanna", "Elwing", "Arwen", "Galadriel",
            "Eowyn", "Rosie", "Dior", "Lalaith", "Miriel"
        };

        public static List<string> GetRandomNames()
        {
            CRandomNames randomNames = new CRandomNames();
            Random rand = new Random();
            return randomNames.names.OrderBy(x => rand.Next()).Take(20).ToList();
        }
    }
}
