using System;
using System.Collections.Generic;
using System.Text;

namespace AttaccoAlRe
{
    internal class CGuardia : APersonaggio
    {
        public CGuardia(string nome) : base (nome) { }
        SistemaDifesa difesa = new SistemaDifesa();

        public string Difendi(object sender, EventArgs e)
        {
            if(!catturato)
            {
                return Nome;
            } else
            {
                return string.Empty;
            }
        }
    }
}
