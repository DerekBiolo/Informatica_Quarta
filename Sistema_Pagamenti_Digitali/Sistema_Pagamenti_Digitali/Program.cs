using System;
using System.Collections.Generic;
using static System.Console;

namespace Sistema_Pagamenti_Digitali
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<AC_MetodoPagamento> pagamenti = new();
            C_StatistichePagamenti statistiche = new();
            bool exit = false;

            while (!exit)
            {
                WriteLine("===| MENU PRINCIPALE |===");
                WriteLine("1 =| Aggiungi metodo di pagamento |===");
                WriteLine("2 =| Esegui pagamento |===");
                WriteLine("3 =| Mostra statistiche |===");
                WriteLine("4 =| Esci |===");
                Write("Scegli un'opzione: ");
                string scelta = ReadLine();

                switch (scelta)
                {
                    case "1":
                        AggiungiMetodoPagamento(pagamenti);
                        break;
                    case "2":
                        EseguiPagamento(pagamenti, statistiche);
                        break;
                    case "3":
                        MostraStatistiche(statistiche);
                        break;
                    case "4":
                        exit = true;
                        WriteLine("Uscita in corso...");
                        break;
                    default:
                        WriteLine("Opzione non valida!");
                        break;
                }

                WriteLine();
            }
        }

        static void AggiungiMetodoPagamento(List<AC_MetodoPagamento> pagamenti)
        {
            WriteLine("Scegli il metodo di pagamento da aggiungere:");
            WriteLine("1 = PayPal");
            WriteLine("2 = Carta di credito");
            WriteLine("3 = Criptovaluta");
            string scelta = ReadLine();

            switch (scelta)
            {
                case "1":
                    Write("Email: ");
                    string email = ReadLine();
                    Write("Password: ");
                    string password = ReadLine();
                    Write("Saldo disponibile: ");
                    decimal saldoPaypal = decimal.Parse(ReadLine());
                    pagamenti.Add(new C_Paypal(email, saldoPaypal, password));
                    break;

                case "2":
                    Write("Numero carta: ");
                    string nc = ReadLine();
                    Write("Data scadenza (MM/AA): ");
                    string data = ReadLine();
                    Write("PIN: ");
                    string pin = ReadLine();
                    Write("Saldo disponibile: ");
                    decimal saldoCarta = decimal.Parse(ReadLine());
                    pagamenti.Add(new C_CartaCredito(nc, data, pin, saldoCarta));
                    break;

                case "3":
                    Write("Wallet ID: ");
                    string wallet = ReadLine();
                    Write("Saldo disponibile: ");
                    decimal saldoCrypto = decimal.Parse(ReadLine());
                    pagamenti.Add(new C_Criptovaluta(wallet, saldoCrypto));
                    break;

                default:
                    WriteLine("Metodo non valido!");
                    break;
            }

            WriteLine("Metodo di pagamento aggiunto con successo!");
        }

        static void EseguiPagamento(List<AC_MetodoPagamento> pagamenti, C_StatistichePagamenti statistiche)
        {
            if (pagamenti.Count == 0)
            {
                WriteLine("Non ci sono metodi di pagamento disponibili!");
                return;
            }

            WriteLine("Seleziona il metodo di pagamento:");
            for (int i = 0; i < pagamenti.Count; i++)
                WriteLine($"{i + 1} = {pagamenti[i].GetType().Name}");

            int sceltaIndex = int.Parse(ReadLine()) - 1;
            if (sceltaIndex < 0 || sceltaIndex >= pagamenti.Count)
            {
                WriteLine("Scelta non valida!");
                return;
            }

            AC_MetodoPagamento metodo = pagamenti[sceltaIndex];

            // Se il metodo richiede autenticazione
            if (metodo is I_Autenticazione auth)
            {
                Write("Email/NumeroCarta: ");
                string u = ReadLine();
                Write("Password/PIN: ");
                string p = ReadLine();
                if (!auth.Autenticazione(u, p))
                {
                    WriteLine("Autenticazione fallita!");
                    return;
                }
            }

            Write("Importo pagamento: ");
            decimal importo = decimal.Parse(ReadLine());

            metodo.EseguiPagamento(importo);

            statistiche.RegistraPagamento(metodo.GetType().Name, importo);

            // Disconnessione automatica se autenticato
            if (metodo is I_Autenticazione daDisconnettere)
                daDisconnettere.Disconnetti();
        }

        static void MostraStatistiche(C_StatistichePagamenti statistiche)
        {
            WriteLine($"Totale incassato: {statistiche.GetTotInc()}");
            WriteLine($"Totale transazioni: {statistiche.NumTrans()}");
            WriteLine($"Metodo più usato: {statistiche.MaxMetodo()}");
        }
    }
}
