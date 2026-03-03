using System;

namespace Sistema_Pagamenti_Digitali
{
    internal class C_CartaCredito : AC_MetodoPagamento, I_Autenticazione
    {
        public string NumeroCarta { get; set; }
        public string DataScadenza { get; set; }
        public string Pin { get; set; }
        private bool autenticato;

        public C_CartaCredito(string numeroCarta, string dataScadenza, string pin, decimal saldoDisponibile)
            : base(saldoDisponibile)
        {
            NumeroCarta = numeroCarta;
            DataScadenza = dataScadenza;
            Pin = pin;
            autenticato = false;
        }

        public bool Autenticazione(string nc, string p)
        {
            if (NumeroCarta == nc && Pin == p)
            {
                autenticato = true;
                Console.WriteLine("Accesso effettuato correttamente.");
                return true;
            }
            else
            {
                Console.WriteLine("Credenziali errate.");
                return false;
            }
        }

        public void Disconnetti()
        {
            if (autenticato)
            {
                autenticato = false;
                Console.WriteLine("Disconnessione effettuata con successo.");
            }
            else
            {
                Console.WriteLine("Nessun account attivo da disconnettere.");
            }
        }

        public override void EseguiPagamento(decimal importo)
        {
            if (!autenticato)
                throw new Exception("Devi prima effettuare l'autenticazione per pagare con carta.");

            Console.WriteLine($"Pagamento tramite carta ({NumeroCarta}) in corso...");
            ScalaImporto(importo);
            StampaScontrino(importo);
        }
    }
}
