using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaLaTuaFlotta
{
    internal class CElicottero : CVeicolo, IVolante
    {
        public int quotaMassima { get; set; }
        public CElicottero(string nome, int quotaMassima) : base(nome)
        {
            this.quotaMassima = quotaMassima;
        }
        public void Vola()
        {
            Console.WriteLine($"{Nome} sta volando fino a {quotaMassima} metri di altezza.");
        }
        public override void MostraInfo()
        {
            Console.WriteLine($"Elicottero: {Nome}, Quota Massima: {quotaMassima} metri");
        }
    }
}
