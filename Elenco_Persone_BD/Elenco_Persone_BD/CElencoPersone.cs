using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elenco_Persone_BD
{
    internal class CElencoPersone
    {
        int maxPersone;
        List<CPersona> ElencoPersone;

        public CElencoPersone(int m)
        {
            maxPersone = m;
            ElencoPersone = new List<CPersona>();
        }
        public void AggiungiPersona(CPersona p)
        {
            ElencoPersone.Add(p);
        }

        public string Print()
        {
            string ret = "";
            if (ElencoPersone.Count > 0)
            {
                foreach (var p in ElencoPersone)
                {
                    ret += $"{p.Nome} - {p.Cognome} - {p.CodiceFiscale}\n";
                }
            }
            return ret;
        }


        public List<CStudente> RitornaStudenti()
        {
            List<CStudente> studenti = new List<CStudente>();
            foreach (var p in ElencoPersone)
            {
                if (p is CStudente s)
                {
                    studenti.Add(s);
                }
            }
            if (studenti.Count > 0)
            {
                return studenti;
            }
            else
            {
                return null;
            }
        }

        public List<CDocente> RitornaSalarioMaggiore(double salarioMaggiore)
        {
            List<CDocente> docentiMegaStrapieniDiSchei = new List<CDocente>();

            foreach (var p in ElencoPersone)
            {
                if (p is CDocente d)
                {
                    if(d.Salario >= salarioMaggiore)
                    {
                        docentiMegaStrapieniDiSchei.Add(d);
                    }
                }
            }

            if (docentiMegaStrapieniDiSchei.Count > 0)
            {
                return docentiMegaStrapieniDiSchei;
            } else
            {
                return null;
            }
        }

        public string StampaTipo()
        {
            string dc = "";
            string st = "";
            string pn = "";

            foreach (var p in ElencoPersone)
            {
                if (p is CStudente s)
                {
                    st += $"Studente : {s.Nome} \n";
                }
                else if (p is CDocente d)
                {
                    dc += $"Docente : {d.Nome} \n";
                }
                else
                {
                    pn += $"Persona Generica : {p.Nome} \n";
                }
            }

            string all = $"{dc} \n \n \n  + {st} \n \n \n + {pn}";

            return all;
        }
    }
}
