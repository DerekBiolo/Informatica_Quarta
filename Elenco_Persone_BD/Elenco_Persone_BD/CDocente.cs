using System;

namespace Elenco_Persone_BD
{
    internal class CDocente : CPersona
    {
        private string materia;
        private double salario;

        public string Materia
        {
            get => materia;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La materia non può essere vuota.");
                materia = value.Trim();
            }
        }

        public double Salario
        {
            get => salario;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Il salario non può essere negativo.");
                salario = value;
            }
        }

        public CDocente(string codiceFiscale, string nome, string cognome, string materia, double salario)
            : base(codiceFiscale, nome, cognome)
        {
            Materia = materia;
            Salario = salario;
        }

        public override string Print()
        {
            return $"{base.Print()} | Materia: {Materia} | Salario: {Salario}";
        }
    }
}
