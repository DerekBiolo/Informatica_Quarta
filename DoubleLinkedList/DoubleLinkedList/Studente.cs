using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList
{
    internal class Studente
    {
        public string Nome;
        public string Cognome;
        public string Codice;
        public string Classe;

        public Studente(string nome, string cognome, string codice, string classe)
        {
            Nome = nome;
            Cognome = cognome;
            Codice = codice;
            Classe = classe;
        }

        public override string ToString()
        {
            return $"{Nome} {Cognome} - {Codice} - Classe {Classe}";
        }
    }
}
