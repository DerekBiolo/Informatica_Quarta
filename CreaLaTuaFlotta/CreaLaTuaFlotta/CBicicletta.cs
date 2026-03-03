using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CreaLaTuaFlotta
{
    internal class CBicicletta : CVeicolo , ICondivisibile
    {
        public string Id { get; set; }
        public bool Disponibile { get; set; }
        public CBicicletta(string nome, string id, bool disponibile) : base(nome)
        {
            Id = id;
            Disponibile = disponibile;
        }
        public override void MostraInfo()
        {
            WriteLine($"Bicicletta: {Nome}, Id: {Id}, Disponibile: {Disponibile}");
        }
    }
}
