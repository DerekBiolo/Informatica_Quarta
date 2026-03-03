using System;
using System.Collections.Generic;
using System.Text;

namespace CodaLinked
{
    internal class Nodo<T>
    {
        public Nodo<T>? next;
        public T value;

        public Nodo(T value)
        {
            next = null;
            this.value = value;
        }
    }
}
