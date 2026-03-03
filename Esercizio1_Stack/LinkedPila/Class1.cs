namespace LinkedPila
{
    public interface IPila<T>
    {
        bool IsEmpty();
        void Push(T elem);
        T Pop();
        T Peek();
        void Clear();
    }

    internal class Nodo<T>
    {
        public T Value { get; set; }
        public Nodo<T>? Next { get; set; }

        public Nodo(T value)
        {
            Value = value;
            Next = null;
        }
    }

    public class LinkedPila<T> : IPila<T>, IEnumerable<T>
    {
        private Nodo<T>? head;

        public LinkedPila()
        {
            head = null;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public void Push(T elem)
        {
            Nodo<T> nuovoNodo = new Nodo<T>(elem);
            nuovoNodo.Next = head;
            head = nuovoNodo;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("La pila è vuota.");
            }

            T valore = head!.Value;
            head = head.Next;
            return valore;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("La pila è vuota.");
            }

            return head!.Value;
        }

        public void Clear()
        {
            head = null;
        }

        public int Count()
        {
            int count = 0;
            Nodo<T>? current = head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Nodo<T>? current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}