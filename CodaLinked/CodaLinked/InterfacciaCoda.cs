using System;
using System.Collections.Generic;
using System.Text;

namespace CodaLinked
{
    internal interface InterfacciaCoda<T>
    {
        void Enqueue(T value);
        T Dequeue();

        bool IsEmpty();

        void Clear();
        T Peek();
        int Count();
    }
}
