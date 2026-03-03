using System;
using System.Collections.Generic;
using System.Text;

namespace ListaEsercizi1
{
    internal class Nodo<T>
    {
        public Nodo<T> next;
        public T value;

        public Nodo(T value)
        {
            this.value = value;
            this.next = null;
        }
    }
}
