using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizio1_Stack
{
    internal class Nodo<T>
    {
        public Nodo<T>? next;
        public T value;

        public Nodo(T value)
        {
            this.value = value;
            next = null;
        }
    }

    internal class LinkedStack<T> : InterfacciaStack<T>
    {
        Nodo<T> head = new Nodo<T>(default(T));

        public void Push(T item)
        {
            Nodo<T> newNode = new(item);

            if (head.next == null)
                head.next = newNode;

            Nodo<T> temp = head.next;
            head.next = newNode;
            newNode.next = temp;
        }

        public T Pop()
        {
            if (head.next == null)
                throw new Exception("Stack vuoto");

            Nodo<T> temp = head.next;
            Nodo<T> newTop = temp.next;
            head.next = newTop;
            return temp.value;
        }

        public T Peek()
        {
            if (head.next == null)
                throw new Exception("Stack vuoto");

            return head.next.value;
        }

        public int Count()
        {
            int contatore = 0;
            Nodo<T> nodo = head;
            while (nodo.next != null)
            {
                contatore++;
                nodo = nodo.next;
            }
            return contatore;
        }
    }

    public interface InterfacciaStack<T>
    {

    }
}
