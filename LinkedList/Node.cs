using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LinkedList
{
    public class Node<T>
    {
        public T Value { get; set; }

        public Node<T> Next { get; set; }
        public Node(T value, Node<T> next)
        {
            this.Value = value;
            this.Next = next;
        }
    }
}
