using System;
using System.Collections.Generic;
using System.Text;

namespace CopisteriaAsyncrona
{
    internal class Documento
    {
        public string Nome;
        public int Priorita;
        public int NumeroEntrata;
        public Documento(string n, int p, int ne)
        {
            this.Nome = n;
            this.Priorita = p;
            this.NumeroEntrata = ne;
        }

        public override string ToString()
        {
            return $"Documento: {Nome}, Priorità: {Priorita}, Numero Entrata: {NumeroEntrata}";
        }
    }
}
