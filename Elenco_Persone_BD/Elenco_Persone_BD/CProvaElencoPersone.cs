namespace Elenco_Persone_BD
{
    using static System.Console;
    using System.Collections.Generic;

    internal class CProvaElencoPersone
    {
        public void Esegui()
        {
            int max;
            do
            {
                Write("Inserisci il numero massimo di persone: ");
            } while (!int.TryParse(ReadLine(), out max) || max <= 0);

            CElencoPersone elencoPersone = new(max);

            for (int i = 0; i < max; i++)
            {
                WriteLine($"\n--- Persona {i + 1} di {max} ---");
                int scelta;

                WriteLine("Scegli il tipo di persona:");
                WriteLine("1) Persona generica");
                WriteLine("2) Docente");
                WriteLine("3) Studente");
                do
                {
                    Write("Scelta: ");
                } while (!int.TryParse(ReadLine(), out scelta) || scelta < 1 || scelta > 3);

                string nome = LeggiCampo("nome");
                string cognome = LeggiCampo("cognome");
                string codiceFiscale = LeggiCampo("codice fiscale", 16);

                switch (scelta)
                {
                    case 1:
                        elencoPersone.AggiungiPersona(new CPersona(codiceFiscale, nome, cognome));
                        break;

                    case 2:
                        string materia = LeggiCampo("materia");
                        double salario = LeggiDouble("salario", 0);
                        elencoPersone.AggiungiPersona(new CDocente(codiceFiscale, nome, cognome, materia, salario));
                        break;

                    case 3:
                        string universita = LeggiCampo("università");
                        int matricola = LeggiInt("numero di matricola", 0);
                        elencoPersone.AggiungiPersona(new CStudente(codiceFiscale, nome, cognome, matricola, universita));
                        break;
                }
            }

            WriteLine("\n--- Elenco completo delle persone ---");
            WriteLine(elencoPersone.Print());

            WriteLine("\n--- Studenti inseriti ---");
            var studenti = elencoPersone.RitornaStudenti();
            if (studenti != null && studenti.Count > 0)
            {
                foreach (var s in studenti)
                    WriteLine($"Nome: {s.Nome} | Cognome: {s.Cognome} | CF: {s.CodiceFiscale} | Matricola: {s.Matricola} | Università: {s.Universita}");
            }
            else
            {
                WriteLine("Nessuno studente presente.");
            }

            WriteLine("\n--- Docenti con salario > 2000 ---");
            var docenti = elencoPersone.RitornaSalarioMaggiore(2000d);
            if (docenti != null && docenti.Count > 0)
            {
                foreach (var d in docenti)
                    WriteLine($"Nome: {d.Nome} | Salario: {d.Salario}");
            }
            else
            {
                WriteLine("Nessun docente con salario superiore a 2000 trovato.");
            }
        }

        private string LeggiCampo(string campo, int lunghezza = -1)
        {
            string valore;
            do
            {
                Write($"Inserisci il {campo}: ");
                valore = ReadLine()?.Trim();
            } while (string.IsNullOrWhiteSpace(valore) || (lunghezza > 0 && valore.Length != lunghezza));
            return valore;
        }

        private double LeggiDouble(string campo, double min)
        {
            double valore;
            do
            {
                Write($"Inserisci il {campo}: ");
            } while (!double.TryParse(ReadLine(), out valore) || valore < min);
            return valore;
        }

        private int LeggiInt(string campo, int min)
        {
            int valore;
            do
            {
                Write($"Inserisci il {campo}: ");
            } while (!int.TryParse(ReadLine(), out valore) || valore < min);
            return valore;
        }
    }
}
