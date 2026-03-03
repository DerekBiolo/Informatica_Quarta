using System;

namespace Sistema_Pagamenti_Digitali
{
    abstract class AC_MetodoPagamento
    {
        protected decimal SaldoDisponibile;

        protected AC_MetodoPagamento(decimal saldo)
        {
            SaldoDisponibile = saldo;
        }

        public abstract void EseguiPagamento(decimal importo);

        protected bool VerificaDisponibilita(decimal importo)
        {
            return SaldoDisponibile >= importo;
        }

        protected void StampaScontrino(decimal importo)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("        SCONTRINO");
            Console.WriteLine("----------------------------");
            Console.WriteLine($" Totale speso:   {importo} €");
            Console.WriteLine($" Saldo residuo:  {SaldoDisponibile} €");
            Console.WriteLine("----------------------------");
        }
        protected void ScalaImporto(decimal importo)
        {
            if (!VerificaDisponibilita(importo))
                throw new Exception("Fondi insufficienti per completare il pagamento.");

            SaldoDisponibile -= importo;
        }
    }
}
