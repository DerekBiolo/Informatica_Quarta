using System;

namespace Elenco_Persone_BD
{
    internal class CPersona
    {
        private string codiceFiscale;
        private string nome;
        private string cognome;

        public string CodiceFiscale
        {
            get => codiceFiscale;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Il codice fiscale non può essere vuoto.");
                if (value.Length != 16)
                    throw new ArgumentException("Il codice fiscale deve avere 16 caratteri.");
                codiceFiscale = value.Trim().ToUpper();
            }
        }

        public string Nome
        {
            get => nome;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Il nome non può essere vuoto.");
                nome = value.Trim();
            }
        }

        public string Cognome
        {
            get => cognome;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Il cognome non può essere vuoto.");
                cognome = value.Trim();
            }
        }

        public CPersona(string codiceFiscale, string nome, string cognome)
        {
            CodiceFiscale = codiceFiscale;
            Nome = nome;
            Cognome = cognome;
        }

        public virtual string Print()
        {
            return $"{Nome} {Cognome} ({CodiceFiscale})";
        }
    }
}
