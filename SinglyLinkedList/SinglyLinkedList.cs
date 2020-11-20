using System;
using System.Collections.Generic;
using System.Text;
using static DataStructures.SinglyLinkedList;

namespace DataStructures
{
    public class SinglyLinkedListMethods
    {
        public Node Head;
        public class Node
        {
            public int Data;
            public Node Next;
            public Node(int d)
            {
                Data = d;
            }
        }
        public void Print()
        {
            Node node = Head;
            while (node != null)
            {
                Console.WriteLine(node.Data);
                node = node.Next;
            }
        }

        public void Print(Node node)
        {
            while (node != null)
            {
                Console.WriteLine(node.Data);
                node = node.Next;
            }
        }

        public void AddFirst(int value)
        {
            Node dataToinsert = new Node(value);
            dataToinsert.Next = Head;
            Head = dataToinsert;
        }

        public void AddAfterGivenNode(Node givenNode, int value)
        {
            Node node = Head;
            Node new_node = new Node(value);

            while (node != null)
            {
                if (node.Data == givenNode.Data)
                {
                    new_node.Next = node.Next;
                    node.Next = new_node;
                    break;
                }
                node = node.Next;
            }
        }

        public void AddLast(int value)
        {
            Node new_node = new Node(value);

            if (Head == null)
            {
                Head = new_node;
                return;
            }
            Node node = Head;


            while (node != null)
            {
                if (node.Next == null)
                {
                    node.Next = new_node;
                    break;
                }
                node = node.Next;
            }

        }

        public void DeleteNode(int value)
        {
            Node node = Head;
            Node previousNode = null;

            if (node != null && node.Data == value)
            {
                Head = node.Next;
                return;
            }

            while (node != null)
            {
                if (node.Data == value)
                {
                    previousNode.Next = node.Next;
                    return;
                }
                previousNode = node;
                node = node.Next;
            }
            Console.WriteLine("Sucess");

        }


        // Input: position = 1, Linked List = 8->2->3->1->7
        //Output: Linked List = 8->3->1->7

        //Input: position = 0, Linked List = 8->2->3->1->7
        //Output: Linked List = 2->3->1->7
        public void DeleteAtGivenPosition(int position)
        {
            Node node = Head, previousNode = null;
            if (position == 0)
            {
                Head = node.Next;
                return;
            }

            int count = 0;

            while (node != null)
            {
                if (count == position)
                {
                    previousNode.Next = node.Next;
                }
                previousNode = node;
                node = node.Next;
                count++;
            }
        }

        public int FindLengthOfLinkedList()
        {
            int count = 0;
            Node node = Head;

            while (node != null)
            {
                count++;
                node = node.Next;
            }
            return count;
        }

        public int FindLengthRecurssive(Node head)
        {
            if (head == null)
            {
                return 0;
            }
            else
            {
                return 1 + FindLengthRecurssive(head.Next);
            }
        }

        //Input:  10->15->12->13->20->14,  x = 12, y = 20
        //Output: 10->15->20->13->12->14

        //Input:  10->15->12->13->20->14,  x = 10, y = 20
        //Output: 20->15->12->13->10->14

        //Input:  10->15->12->13->20->14,  x = 12, y = 13
        //Output: 10->15->13->12->20->14

        public void SwapNodes(int a, int b)
        {
            Node node = Head;

            if (a == b) return;


            while (node != null)
            {
                if (node.Data == a)
                {
                    node.Data = b;
                }
                else if (node.Data == b)
                {
                    node.Data = a;
                }

                node = node.Next;
            }

        }

        //Input: Head of following linked list
        //1->2->3->4->NULL
        //Output: Linked list should be changed to,
        //4->3->2->1->NULL

        public Node ReverseLinkedList()
        {
            Node node = Head;
            Node output = null;

            while (node != null)
            {
                Node dataToinsert = new Node(node.Data);
                if (output == null)
                {
                    output = dataToinsert;
                }
                else
                {
                    dataToinsert.Next = output;
                    output = dataToinsert;
                }
                node = node.Next;
            }
            return output;
        }

        public bool SearchElementInLinkedList(int value)
        {
            Node node = Head;

            while (node != null)
            {
                if (node.Data == value)
                {
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        public bool SearchElementInLinkedList(Node Head, int value)
        {
            if (Head == null) return false;
            if (Head.Data == value)
            {
                return true;
            }

            return SearchElementInLinkedList(Head.Next, value);
        }

        public void printNthFromLast(int n)
        {
            int length = 0;
            Node temp = Head;

            while (temp != null)
            {
                length++;
                temp = temp.Next;
            }
            if (length < n)
                return;

            temp = Head; ;

            for (int i = 0; i < length - n + 1; i++)
            {
                temp = temp.Next;
            }
            Console.WriteLine(temp.Data);
        }

        public void CountOfNumber(int number)
        {
            Node temp = Head;
            int count = 0;
            while (temp != null)
            {
                if (temp.Data == number)
                {
                    count++;
                }
                temp = temp.Next;
            }
        }

        public int CountOfNumberRecurssion(int number, Node temp, int count)
        {
            if (temp == null)
            {
                return count;
            }
            if (temp.Data == number)
            {
                return count++;
            }

            return CountOfNumberRecurssion(number, temp.Next, count);
        }

        public bool DetectLoop()
        {
            Node temp = Head;
            HashSet<Node> s = new HashSet<Node>();
            while (temp != null)
            {
                if (s.Contains(temp))
                {
                    return true;
                }

                s.Add(temp);
                temp = temp.Next;
            }

            return false;
        }

        public bool DetectLoopFloydsCycle()
        {
            Node slow_p = Head, fast_p = Head;
            while (slow_p != null && fast_p != null && fast_p.Next != null)
            {
                slow_p = slow_p.Next;
                fast_p = fast_p.Next.Next;
                if (slow_p == fast_p)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
