using DataStructures.ArraysAndStrings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static DataStructures.SinglyLinkedListMethods;

namespace DataStructures
{

    class BaseClass
    {
        public int i = 10;
        public int j = 20;
        public void Display()
        {
            Console.WriteLine("Base Method");
        }
    }
    class Derived : BaseClass
    {
        public int s = 30;   
    }


    public abstract class A
    {
        public abstract void F1();
        public virtual void F2()
        {
            Console.WriteLine("A F2");
            F1();
        }
    }
    public class B: A
    {
        public override void F1()
        {
            Console.WriteLine("B F1");
        }
    }


    public class TestStatic { 
    
    }

    public class SinglyLinkedList
    {

        static string location;
        static DateTime time;
        static void Main(string[] args)
        {

            Console.WriteLine(location == null ? "location is null" : location);
            Console.WriteLine(time == null ? "time is null" : time.ToString());



            new B().F2();


            Derived d = new Derived();
            Console.WriteLine("{0},{1},{2}", d.i, d.j, d.s);
            d.Display();

            Customer c = new Customer();
            c.id = 10;
            Customer.setReference(c);

            ArraysAndString arraysAndStrings = new ArraysAndString();
            arraysAndStrings.ReverseOfANumber(8, 8, 0);
            arraysAndStrings.MinAbsValueSumOfTwo(new int[] { 1, 4, -3 });
            arraysAndStrings.MinAbsValue(new int[] { 1, 5, 2, -2 });
            arraysAndStrings.DNASequence("", null, null);
            arraysAndStrings.FindLowestMissingNumber(new int[] { 1, 5, 6, 4, 1, 2 });
            arraysAndStrings.FindDifferenceOfParts(new int[] { 3, 1, 2, 4, 3 });
            arraysAndStrings.FindMissingElement(new int[] { 2, 3, 1, 5 });
            arraysAndStrings.FrogJmp(10, 85, 30);
            arraysAndStrings.UnpairedNumber(new int[] { 9, 3, 9, 3, 9, 7, 9 });
            arraysAndStrings.CyclicRotation(new int[] { 3, 8, 9, 7, 6 }, 3);
            arraysAndStrings.BinaryGap(32);
            arraysAndStrings.AlternateCoins();
            arraysAndStrings.ReturnLowestNumber();
            arraysAndStrings.OneAway("pale", "bale");
            arraysAndStrings.isPalindromePermutation("tacti coa");
            string replacedString = arraysAndStrings.ReplaceString("Mr John Smith".ToCharArray(), 13);
            bool isPermutation = arraysAndStrings.CheckPermutationOfStrings("abcd ", "a bcd");
            bool isUnique = arraysAndStrings.IsStringUnique("P    i");



            List<int> MyList = new List<int>();
            MyList.Add(1);
            MyList.Add(2);
            MyList.Add(3);
            MyList.Add(4);
            MyList.Add(5);
            var nr = FilterWithoutYield(MyList);


            string input = "xyz abc mnp \"asdf dfaa asdf\" asd \"fdas asdffgg\"";
            splitTonewLineProgram(input);


            #region LinkedList
            SinglyLinkedListMethods list = new SinglyLinkedListMethods();

            list.Head = new Node(1);
            Node second = new Node(2);
            Node third = new Node(3);

            list.Head.Next = second;

            second.Next = third;

            list.AddLast(4);
            list.AddAfterGivenNode(second, 5);

            Console.WriteLine("All the Data /n");

            list.Print();
            Console.WriteLine("lenght:" + list.FindLengthOfLinkedList());

            Console.WriteLine("Recurrsive approach lenght:" + list.FindLengthRecurssive(list.Head));

            list.SwapNodes(2, 1);
            Console.WriteLine("All the Data after swap");
            list.Print();

            Node reversedList = list.ReverseLinkedList();


            Console.WriteLine("All the Data after reversing");
            list.Print(reversedList);


            // before loop
            bool rest = list.DetectLoopFloydsCycle();
            list.Head.Next.Next.Next.Next.Next = list.Head.Next.Next.Next;

            //After loop
            rest = list.DetectLoopFloydsCycle();
            list.DeleteAtGivenPosition(2);
            Console.WriteLine("All the Data after Deleting /n");
            list.Print();
            list.DeleteNode(3);
            list.Print();

            Console.ReadLine();
            #endregion
        }

        static IEnumerable<int> FilterWithoutYield(List<int> MyList)
        {
            foreach (int i in MyList)
            {
                if (i > 3)
                {
                    yield return i;
                }
            }
        }


        //string input1 = "one \"two two\" three \"four four\" five six";

        private static void splitTonewLineProgram(string input)
        {
            var parts = Regex.Matches(input, @"[\""].+?[\""]|[^ ]+")
                            .Cast<Match>()
                            .Select(m => m.Value)
                            .ToList();
            for (int i = 0; i < parts.Count; i++)
            {
                Console.WriteLine(parts[i]);
            }

            Console.ReadLine();

        }
    }
}
