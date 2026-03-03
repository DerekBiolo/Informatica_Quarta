using System;

namespace Elenco_Persone_BD
{
    internal class CStudente : CPersona
    {
        private int matricola;
        private string universita;

        public int Matricola
        {
            get => matricola;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("La matricola deve essere un numero positivo.");
                matricola = value;
            }
        }

        public string Universita
        {
            get => universita;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Il nome dell'università non può essere vuoto.");
                universita = value.Trim();
            }
        }

        public CStudente(string codiceFiscale, string nome, string cognome, int matricola, string universita)
            : base(codiceFiscale, nome, cognome)
        {
            Matricola = matricola;
            Universita = universita;
        }

        public override string Print()
        {
            return $"{base.Print()} | Matricola: {Matricola} | Università: {Universita}";
        }
    }
}
