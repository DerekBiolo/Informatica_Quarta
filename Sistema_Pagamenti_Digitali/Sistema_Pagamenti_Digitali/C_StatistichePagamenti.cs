using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Pagamenti_Digitali
{
    internal class C_StatistichePagamenti
    {
        private decimal totaleIncassato;
        private int totaleTransazioni;
        private Dictionary<string, int> conteggioTransazioni;

        public C_StatistichePagamenti()
        {
            totaleIncassato = 0;
            totaleTransazioni = 0;
            conteggioTransazioni = new();
        }

        public void RegistraPagamento(string metodoPagamento, decimal importoPagamento)
        {
            totaleTransazioni++;
            totaleIncassato += importoPagamento;

            if (conteggioTransazioni.ContainsKey(metodoPagamento))
            {
                conteggioTransazioni[metodoPagamento]++;
            }
            else
            {
                conteggioTransazioni[metodoPagamento] = 1;
            }
        }

        public string MaxMetodo()
        {
            if (conteggioTransazioni.Count == 0)
                return "Nessun pagamento effettuato fino ad ora";

            string metodoMax = "";
            int maxCount = 0;

            foreach (var c in conteggioTransazioni)
            {
                if (c.Value > maxCount)
                {
                    maxCount = c.Value;
                    metodoMax = c.Key;
                }
            }

            return metodoMax;
        }

        public decimal GetTotInc() => totaleIncassato;
        public decimal NumTrans() => totaleTransazioni;



    }
}
