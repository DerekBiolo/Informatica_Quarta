using System;
using System.Collections.Generic;
using System.Text;

namespace AttaccoAlRe
{
    internal class CPedone : APersonaggio
    {
        public CPedone(string nome) : base(nome) { }

        public void Prepara(object sender, EventArgs e)
        {
            if (!catturato)
            {
                Console.WriteLine($"Il pedone {Nome} si sta preparando");
            }
        }
    }
}