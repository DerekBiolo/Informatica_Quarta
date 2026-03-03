using System;
using System.Collections.Generic;
using System.Text;

namespace CopisteriaAsyncrona
{
    internal class Copisteria
    {
        private readonly int _numeroStampanti;
        private readonly object _lock = new();
        private readonly SemaphoreSlim _spazioDisponibile; //stampanti disponibili
        private readonly SemaphoreSlim _documentiDisponibili = new(0); //contatore documenti in coda
        private readonly List<Documento> _coda = new();

        public Copisteria(int numeroStampanti)
        {
            _numeroStampanti = numeroStampanti;
            _spazioDisponibile = new(numeroStampanti, numeroStampanti);
        }

        public async Task InserisciDocumento(Documento doc)
        {
            await _spazioDisponibile.WaitAsync(); //se non ce spazio nella copisteria, aspetta
            lock (_lock) //entra una alla volta
            {
                _coda.Add(doc); //aggiungi documento alla coda
                _coda.Sort((d1, d2) =>
                {
                    int cmp = d2.Priorita.CompareTo(d1.Priorita);
                    return cmp != 0 ? cmp : d1.NumeroEntrata.CompareTo(d2.NumeroEntrata);
                });
            }
            _documentiDisponibili.Release(); //libera spazio per altri documenti (il documento e pronto)
        }


        public async Task<Documento> PrendiDocumento()
        {
            await _documentiDisponibili.WaitAsync(); //aspetta che ci sia un documento disponibile
            Documento doc;
            lock (_lock) //entra una alla volta
            {
                doc = _coda[0]; //prendi il documento con priorità più alta
                _coda.RemoveAt(0); //rimuovi il documento dalla coda
            }
            return doc;
        }

        public void StampaFinita()
        {
            _spazioDisponibile.Release();
        }


    }
}
