using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class LinkedListNode<T>
    {
        public LinkedListNode(T value, LinkedListNode<T> next = null)
        {
            this.Value = value;
            this.Next = next;
        }

        public LinkedListNode<T> Next;
        public T Value;
    }
}
