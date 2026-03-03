using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDomotico
{
    internal abstract class CItem : ISwitchable
    {
        protected string nome;
        protected string stanza;

        public CItem(string nome, string stanza)
        {
            this.nome = nome;
            this.stanza = stanza;
        }

        public abstract void Accendi();
        public abstract void Spegni();

        public abstract void MostraInfo();
        public abstract bool isOn { get; set; }
    }
}
