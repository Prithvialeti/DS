using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class Node<T>
    {
        public Node( T value, Node<T> next = null)
        {
            this.Next = next;
            this.Value = value;
        }
        public Node<T> Next;
        public T Value;
    }
}
