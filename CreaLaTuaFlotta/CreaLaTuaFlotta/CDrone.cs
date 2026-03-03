using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CreaLaTuaFlotta
{
    internal class CDrone : CVeicolo, IVolante
    {
        public int quotaMassima { get; set; }

        public CDrone(string nome, int quotaMassima) : base(nome)
        {
            this.quotaMassima = quotaMassima;
        }

        public void Vola()
        {
            WriteLine($"{Nome} sta volando fino a {quotaMassima} metri di altezza.");
        }

        public override void MostraInfo()
        {
            WriteLine($"Drone: {Nome}, Quota Massima: {quotaMassima} metri");
        }
    }
}
