using System;
using System.Collections;
using System.Collections.Generic;

namespace DoubleLinkedList
{
    internal interface ILista<T>
    {
        void Add(T element);
        bool IsEmpty();
        int Size();
        T First();
        T Last();
        T Search(Func<T, bool> predicate);
        void Remove(Func<T, bool> predicate);
        void Update(Func<T, bool> predicate, T newElement);
        void Clear();
    }

    internal class DoubleLinkedList : ILista<Studente>, IEnumerable<Studente>
    {
        private Nodo head;

        public void Add(Studente student)
        {
            Nodo newNode = new Nodo(student);

            if (head == null || string.Compare(student.Codice, head.Data.Codice) < 0)
            {
                newNode.Next = head;
                if (head != null)
                    head.Prev = newNode;
                head = newNode;
                return;
            }

            Nodo current = head;

            while (current.Next != null &&
                   string.Compare(student.Codice, current.Next.Data.Codice) > 0)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            if (current.Next != null)
                current.Next.Prev = newNode;

            current.Next = newNode;
            newNode.Prev = current;
        }

        public bool IsEmpty() => head == null;

        public int Size()
        {
            int n = 0;
            Nodo current = head;
            while (current != null) { n++; current = current.Next; }
            return n;
        }

        public Studente First()
        {
            if (IsEmpty()) throw new InvalidOperationException("Lista vuota.");
            return head.Data;
        }

        public Studente Last()
        {
            if (IsEmpty()) throw new InvalidOperationException("Lista vuota.");
            Nodo current = head;
            while (current.Next != null)
                current = current.Next;
            return current.Data;
        }

        public Studente Search(Func<Studente, bool> predicate)
        {
            Nodo current = head;
            while (current != null)
            {
                if (predicate(current.Data))
                    return current.Data;
                current = current.Next;
            }
            return null;
        }

        public void Remove(Func<Studente, bool> predicate)
        {
            Nodo current = head;
            while (current != null)
            {
                if (predicate(current.Data))
                {
                    if (current.Prev != null)
                        current.Prev.Next = current.Next;
                    else
                        head = current.Next;

                    if (current.Next != null)
                        current.Next.Prev = current.Prev;

                    return;
                }
                current = current.Next;
            }
        }

        public void Update(Func<Studente, bool> predicate, Studente newStudent)
        {
            Remove(predicate);
            Add(newStudent);
        }

        public void Clear() => head = null;

        public IEnumerable<Studente> GetDescending()
        {
            // Raggiungiamo l'ultimo nodo
            Nodo current = head;
            if (current == null) yield break;
            while (current.Next != null)
                current = current.Next;

            // Scorriamo all'indietro usando Prev
            while (current != null)
            {
                yield return current.Data;
                current = current.Prev;
            }
        }

        public IEnumerator<Studente> GetEnumerator()
        {
            Nodo current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public Studente Find(string codice) =>
            Search(s => s.Codice == codice);

        public void Insert(Studente s) => Add(s);

        public void Delete(string codice) =>
            Remove(s => s.Codice == codice);

        public void UpdateByCodice(string codice, Studente nuovo) =>
            Update(s => s.Codice == codice, nuovo);
    }
}
