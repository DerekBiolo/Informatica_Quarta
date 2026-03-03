using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CodaLinked
{
    internal class LinkedCoda<T> : InterfacciaCoda<T>
    {
        Nodo<T>? head = null;
        Nodo<T>? tail = null;
        int lunghezza = 0;

        public void Enqueue(T value)
        {
            Nodo<T> nodoNuovo = new Nodo<T>(value);

            if (head == null)
            {
                head = nodoNuovo;
                tail = nodoNuovo;
                lunghezza++;
                return;
            } else
            {
                tail!.next = nodoNuovo;
                tail = nodoNuovo;
                lunghezza++;
            }
        }

        public T Dequeue()
        {
            if (head == null)
                throw new Exception("Non puoi fare Dequeue su una lista vuota! Are you crazy? Loco?");

            T valoreRimosso = head.value;
            head = head.next;

            if (head == null)
                tail = null;

            lunghezza--;
            return valoreRimosso;
        }

        public T Peek()
        {
            if (head == null)
                throw new Exception("Non puoi usare Peek su una lista vuota! Sei matto Loco");

            return head.value;
        }

        public bool IsEmpty()
        {
            return head == null && tail == null;
        }

        public int Count() { return lunghezza; }

        public void Clear()
        {
            head = null; tail = null; lunghezza = 0;
        }
    }
}
