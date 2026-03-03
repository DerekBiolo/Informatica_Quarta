using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList
{
    internal class Nodo
    {
        public Studente Data;
        public Nodo Next;
        public Nodo Prev;

        public Nodo(Studente Data)
        {
            this.Data = Data; 
        }
    }
}
