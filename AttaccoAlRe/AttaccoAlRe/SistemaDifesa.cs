using System;
using System.Collections.Generic;
using System.Text;

namespace AttaccoAlRe
{
    internal class SistemaDifesa
    {
        private CRe re;
        private List<CGuardia> guardie;
        private List<CPedone> pedoni;
        public event EventHandler<string> MessaggioDifesaGenerale;
        public SistemaDifesa()
        {
            guardie = new List<CGuardia>();
            pedoni = new List<CPedone>();
        }

        public bool CaricaDaFile(string filePercorso)
        {
            try
            {
                string[] r = File.ReadAllLines(filePercorso);

                if (r.Length < 3)
                {
                    Console.WriteLine("File non validsss");
                    return false;
                }

                //prendo il nome de re
                re = new CRe(r[0].Trim());

                //seconda riga le guardie
                if (!string.IsNullOrEmpty(r[1]))
                {
                    string[] nomiGuardie = r[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string nome in nomiGuardie)
                    {
                        CGuardia g = new(nome.Trim());
                        guardie.Add(g);
                        Console.WriteLine($"Guardia aggiunta: {g.Nome}");
                        re.SottoAttacco += g.Difendi;
                    }
                }

                //terza riga pedonis
                if (!string.IsNullOrEmpty(r[2]))
                {
                    string[] nomiPedoni = r[2].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string nome in nomiPedoni)
                    {
                        CPedone p = new(nome.Trim());
                        pedoni.Add(p);
                        Console.WriteLine($"Pedone aggiunto: {p.Nome}");
                        re.SottoAttacco += p.Prepara;
                    }
                }
                bool isFinished = false;
                //righe successive
                for (int i = 3; i < r.Length; i++)
                {
                    if (isFinished)
                        break;


                    string comando = r[i].Trim();
                    if (comando.Equals("End", StringComparison.OrdinalIgnoreCase))
                        break;


                    Console.WriteLine($"\nComando in esecuzione: {comando}");
                    isFinished = EseguiComando(comando, isFinished);
                    Console.WriteLine("_______________________________");
                }

                return isFinished;
            } catch (FileNotFoundException)
            {
                Console.WriteLine("File in input non trovato");
                return false;
            } catch (Exception ex)
            {
                Console.WriteLine("Errore: " + ex);
                return false;
            }
        }

        private bool EseguiComando(string c, bool f)
        {
            bool isFinished = f;
            if (string.IsNullOrWhiteSpace(c))
                return false;

            Console.WriteLine($"\n> {c}");

            if (c.Equals("Attacca Re", StringComparison.OrdinalIgnoreCase))
            {
                re.SubisciAttacco();
                //scateno l'evento di difesa di tutte le guardie e pedoni che lo hanno ancora libero
                foreach (CGuardia g in guardie)
                {
                    if (!g.catturato)
                    {
                        g.Difendi(this, EventArgs.Empty);

                    }
                }
                foreach (CPedone p in pedoni)
                {
                    if (!p.catturato)
                        p.Prepara(this, EventArgs.Empty);
                }
            }

            if (c.StartsWith("Cattura ", StringComparison.OrdinalIgnoreCase))
            {
                string nome = c.Substring(8).Trim();
                Cattura(nome);
            }

            return false;
        }

        private void Cattura(string n)
        {
            CGuardia guardia = guardie.FirstOrDefault(g => g.Nome.Equals(n, StringComparison.OrdinalIgnoreCase) && !g.catturato);
            if (guardia != null)
            {
                guardia.catturato = true;
                re.SottoAttacco -= guardia.Difendi;
                return;
            }

            CPedone pedone = pedoni.FirstOrDefault(p => p.Nome.Equals(n, StringComparison.OrdinalIgnoreCase) && !p.catturato);
            if (pedone != null)
            {
                pedone.catturato = true;
                re.SottoAttacco -= pedone.Prepara;
                return;
            }
        }
    }
}
