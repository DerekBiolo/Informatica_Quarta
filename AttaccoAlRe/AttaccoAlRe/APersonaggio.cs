using System;
using System.Collections.Generic;
using System.Text;

namespace AttaccoAlRe
{
    public abstract class APersonaggio
    {
        public string Nome;
        public bool catturato;

        public APersonaggio(string nome)
        {
            this.Nome = nome;
            this.catturato = false;
        }
    }
}