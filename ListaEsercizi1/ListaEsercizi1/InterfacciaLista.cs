using System;
using System.Collections.Generic;
using System.Text;

namespace ListaEsercizi1
{
    internal interface InterfacciaLista<T>
    {
        public int TotaleElementi();
        public LinkedList<T> GetLista();

        public void AggiungiElementoFine(T elemento);
        public void AggiungiElementoInizio(T elemento);
        public void AggiungiElementoAt(T elemento, int index);

        public void RimuoviPrimoElemento();
        public void RimuoviUltimoElemento();
        public void RimuoviElementoAt(int index);

        public T GetElementoAt(int indice);
    }
}
