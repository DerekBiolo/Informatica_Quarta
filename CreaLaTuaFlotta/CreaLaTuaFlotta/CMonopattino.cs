using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CreaLaTuaFlotta
{
    internal class CMonopattino : CVeicolo, ICondivisibile
    {
        public string Id { get; set; }
        public bool Disponibile { get; set; }
        public CMonopattino(string nome, string id, bool disponibile) : base(nome)
        {
            Id = id;
            Disponibile = disponibile;
        }
        public override void MostraInfo()
        {
            WriteLine($"Monopattino: {Nome}, Id: {Id}, Disponibile: {Disponibile}");
        }
    }
}
