using System;

namespace Sistema_Pagamenti_Digitali
{
    internal class C_Criptovaluta : AC_MetodoPagamento
    {
        public string WalletID { get; set; }

        public C_Criptovaluta(string walletID, decimal saldo)
            : base(saldo)
        {
            WalletID = walletID;
        }

        public override void EseguiPagamento(decimal importo)
        {
            Console.WriteLine($"Pagamento in criptovaluta dal wallet {WalletID} in corso...");
            ScalaImporto(importo);
            StampaScontrino(importo);
        }
    }
}
