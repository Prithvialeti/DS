using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class DoubleLinkedListNode<T>
    {
        public DoubleLinkedListNode(T value,  DoubleLinkedListNode<T> prev = null, DoubleLinkedListNode<T> next = null)
        {
            this.Value = value;
            this.Next = next;
            this.Previous = prev; ;
        }

        public DoubleLinkedListNode<T> Previous { get; set; }
        public DoubleLinkedListNode<T> Next { get; set; }
        public T Value { get; set; }
    }

    public class DoublyLinkedList<T> : System.Collections.Generic.ICollection<T>
    {
        public DoubleLinkedListNode<T> Head
        {
            get;
            private set;
        }
        public DoubleLinkedListNode<T> Tail
        {
            get;
            private set;
        }


        public void AddHead(T value)
        {
            DoubleLinkedListNode<T> adding = new DoubleLinkedListNode<T>(value, null, Head);
            if (Head != null)
            {
                Head.Previous = adding;
            }
            Head = adding;
            if (Tail == null)
            {
                Tail = Head;
            }
        }

        public void AddTail (T value)
        {

            if (Tail == null)
            {
                AddHead(value);
            }

            else
            {
                DoubleLinkedListNode<T> adding = new DoubleLinkedListNode<T>(value, Tail);

                Tail.Next = adding;
                Tail = adding;
            }

        }

        public DoubleLinkedListNode<T> Find(T value)
        {
            DoubleLinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return current;
                }
                current = current.Next;
            }

            return null;

        }
        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            DoubleLinkedListNode<T> found = Find(item);
            if(found == null)
            {
                return false;
            }
            DoubleLinkedListNode<T> previous = found.Previous;
            DoubleLinkedListNode<T> next = found.Next;

            if(previous == null)
            {
                Head = next;
                if(Head != null)
                {
                    Head.Previous = null;
                }
            }
            else
            {
                previous.Next = next;
            }

            if(next == null)
            {
                Tail = previous;
                if(Tail != null)
                {
                    Tail.Next = null;
                }

            }
            else
            {
                next.Previous = previous;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
