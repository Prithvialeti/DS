using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            DoublyLinkedList<int> test = new DoublyLinkedList<int>();

            for (int i = 0; i < 5; i++)
            {
                test.AddTail(i);
            }
        }
    }
}
