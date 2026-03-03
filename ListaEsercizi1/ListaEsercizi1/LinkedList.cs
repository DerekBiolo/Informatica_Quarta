using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace ListaEsercizi1
{
    internal class LinkedList<T> : IEnumerable<T>, InterfacciaLista
    {
        Nodo<T> head;



        public IEnumerator<T> GetEnumerator()
        {
            Nodo<T> current = head;
            while (current != null)
            {
                yield return current.value;
                current = current.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int TotaleElementi()
        {
            int totale = 0;
            Nodo<T> nodoAttuale = head;
            while (nodoAttuale != null)
            {
                totale++;
                nodoAttuale = nodoAttuale.next;
            }
            return totale;
        }

        public LinkedList<T> GetLista() => this;

        public void AggiungiElementoFine(T elemento)
        {
            Nodo<T> temp = new Nodo<T>(elemento);
            if (head == null)
            {
                head = temp;
            }
            else
            {
                Nodo<T> current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = temp;
            }
        }

        public void AggiungiElementoInizio(T elemento)
        {
            Nodo<T> temp = head.next;
            Nodo<T> NuovoElemento = new Nodo<T>(elemento);
            head.next = NuovoElemento;
            NuovoElemento.next = temp;
        }

        public void AggiungiElementoAt(T elemento, int indice)
        {
            int contatore = 0;
            Nodo<T> nodoAttuale = head;
            while (contatore < indice)
            {
                if (nodoAttuale.next != null)
                {
                    contatore++;
                    nodoAttuale = nodoAttuale.next;
                }
                else
                {
                    throw new Exception("Index out of range exeption");
                }
            }

            Nodo<T> temp = nodoAttuale.next;
            Nodo<T> NuovoElemento = new Nodo<T>(elemento);
            head.next = NuovoElemento;
            NuovoElemento.next = temp;
        }

        public void RimuoviPrimoElemento()
        {
            if (this.TotaleElementi() > 3)
            {
                Nodo<T> temp = head.next.next;

                Nodo<T> elementoRimosso = head.next;

                head.next = temp;
                elementoRimosso = null;
            }
        }

        public void RimuoviUltimoElemento()
        {
            Nodo<T> daEliminare = head.next.next;
            Nodo<T> ultimoElemento = head.next;
            while( daEliminare != null )
            {
                ultimoElemento = ultimoElemento.next;
                daEliminare = daEliminare.next;
            }

            daEliminare = null;
            ultimoElemento.next = null;
        }

        public void RimuoviElementoAt(int indice)
        {
            int contatore = 0;
            Nodo<T> nodoAttuale = head;
            Nodo<T> temp = null;
            while (contatore < indice)
            {
                if (nodoAttuale.next != null)
                {
                    contatore++;
                    temp = nodoAttuale;
                    nodoAttuale = nodoAttuale.next;
                }
                else
                {
                    throw new Exception("Index out of range exeption");
                }
            }

            Nodo<T> prossimo = nodoAttuale.next;
            temp.next = prossimo;
            nodoAttuale = null;
        }

        public T GetElementoAt(int indice)
        {

        }
    }
}
