using System;

namespace Sistema_Pagamenti_Digitali
{
    internal class C_Paypal : AC_MetodoPagamento, I_Autenticazione
    {
        public string Email { get; set; }
        public string Password { get; set; }
        private bool autenticato;

        public C_Paypal(string email, decimal saldoDisponibile, string password)
            : base(saldoDisponibile)
        {
            Email = email;
            Password = password;
            autenticato = false;
        }

        public bool Autenticazione(string e, string p)
        {
            if (Email == e && Password == p)
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
                throw new Exception("Devi prima effettuare l'autenticazione per pagare con PayPal.");

            Console.WriteLine($"Pagamento tramite PayPal ({Email}) in corso...");
            ScalaImporto(importo);
            StampaScontrino(importo);
        }
    }
}
