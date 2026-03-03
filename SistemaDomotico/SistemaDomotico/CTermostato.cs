using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDomotico
{
    using static System.Console;
    internal class CTermostato : CItem
    {
        public double temperatura;
        public override bool isOn { get; set; }

        public CTermostato(string nome, string stanza, double temperatura)
            : base(nome, stanza)
        {
            this.temperatura = temperatura;
        }   

        public override void Accendi()
        {
            WriteLine($"Il termostato {nome} nella stanza {stanza} è acceso a {temperatura}°C");
            isOn = true;
        }

        public override void Spegni()
        {
            WriteLine($"Il termostato {nome} nella stanza {stanza} è spento");
            isOn = false;
        }

        public override void MostraInfo()
        {
            WriteLine($"Termostato: {nome}, Stanza: {stanza}, Temperatura: {temperatura}°C, Stato: {(isOn ? "Acceso" : "Spento")}");
        }
    }
}
