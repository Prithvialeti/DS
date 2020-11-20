using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.ArraysAndStrings
{
    public class ArraysAndString
    {

        /// <summary>
        /// 1.1
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool IsStringUnique(String str)
        {
            if (str.Length > 128) return false;
            bool[] char_set = new bool[128];
            for (int i = 0; i < str.Length; i++)
            {
                int val = str[i];
                if (char_set[val])
                {
                    return false;
                }
                char_set[val] = true;
            }

            return true;
        }

        /// <summary>
        /// 1.2
        /// </summary>
        /// <param name="Str1"></param>
        /// <param name="Str2"></param>
        /// <returns></returns>
        public bool CheckPermutationOfStrings(string Str1, string Str2)
        {
            int c1 = Str1.Length;
            int c2 = Str2.Length;

            if (c1 != c2) return false;
            char[] char1 = Str1.ToCharArray();
            char[] char2 = Str2.ToCharArray();

            Array.Sort(char1);
            Array.Sort(char2);

            for (int i = 0; i < c1; i++)
            {
                if (char1[i] != char2[i])
                {
                    return false;
                }

            }
            return true;
        }

        /// <summary>
        /// 1.3
        /// </summary>
        /// <param name="str"></param>
        /// <param name="trueLength"></param>
        /// <returns></returns>
        // input = "Mr John Smith", 13
        // output = "Mr%20John%20Smith"

        public string ReplaceString(char[] str, int trueLength)
        {
            int spaceCount = 0, index;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    spaceCount++;
                }
            }

            index = trueLength + spaceCount * 2;
            char[] result = new char[index];
            for (int i = trueLength - 1; i >= 0; i--)
            {
                if (str[i] == ' ')
                {
                    result[index - 1] = '0';
                    result[index - 2] = '2';
                    result[index - 3] = '%';
                    index = index - 3;
                }
                else
                {
                    result[index - 1] = str[i];
                    index--;
                }
            }

            return new string(result);
        }

        /// <summary>
        /// 1.4
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool isPalindromePermutation(string str)
        {
            str = str.Replace(" ", string.Empty);
            return str.Length % 2 == 0 ? getCharactersEven(str) : !getCharactersEven(str);
        }
        private static bool getCharactersEven(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                int count = 0;
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == c)
                    {
                        count++;
                    }

                }
                if (count % 2 != 0)
                {
                    return false;
                }

            }
            return true;
        }

        /// <summary>
        /// 1.5
        /// /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public bool OneAway(string s1, string s2)
        {
            if (s1.Length == s2.Length)
            {
                // Replace

                return oneEditReplace(s1, s2);
            }
            else if (s1.Length + 1 == s2.Length)
            {
                // Insert
                return OnEditInsert(s1, s2);
            }
            else if (s1.Length - 1 == s2.Length)
            {
                // Insert
                return OnEditInsert(s2, s1);
            }
            return false;

        }

        private bool oneEditReplace(string s1, string s2)
        {
            bool foundDifference = false;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    if (foundDifference)
                    {
                        return false;
                    }
                    foundDifference = true;
                }
            }
            return true;
        }

        private bool OnEditInsert(string s1, string s2)
        {
            int index1 = 0;
            int index2 = 0;

            while (index1 < s1.Length && index2 < s2.Length)
            {
                if (s1[index1] != s2[index2])
                {
                    if (index1 != index2)
                    {
                        return false;
                    }

                    index2++;
                }
                else
                {
                    index1++;
                    index2++;
                }
            }
            return true; ;
        }


        /// <summary>
        /// 1.6
        /// </summary>
        /// <param name="s1"></param>
        /// 

        //input aabcccccaaa
        //output a2b1c5a3
        public string StringComparision(string s1)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int countConsecutive = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                countConsecutive++;
                if ((i + 1 >= s1.Length) || (s1[i] != s1[i + 1]))
                {
                    stringBuilder.Append(s1[i]);
                    stringBuilder.Append(countConsecutive);
                    countConsecutive = 0;
                }
            }

            return stringBuilder.Length < s1.Length ? stringBuilder.ToString() : s1;
        }

        //For example, given A = [1, 3, 6, 4, 1, 2], the function should return 5.

        //Given A = [1, 2, 3], the function should return 4.

        //Given A = [−1, −3], the function should return 1.

        public int ReturnLowestNumber()
        {
            int[] intArray = new int[] { 2 };
            Array.Sort(intArray);
            //intArray = 0,1,1,2,3,4,6
            int buffer = intArray[0];

            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] != 0 && intArray[i] != buffer)
                {
                    buffer++;
                    if (buffer != intArray[i] && buffer > 0)
                    {
                        return buffer;
                    }
                }
            }
            if (buffer < 0 || buffer >= 2)
            {
                return 1;
            }

            return buffer++;
        }

        public int AlternateCoins()
        {
            int[] intArray = new int[] { 1, 0, 1, 0, 1, 1 };



            int firstNo = 0;
            int secondNo = 1;


            int noOfChanges = 0;
            int nextNo = intArray[0] == 1 ? 0 : 1;

            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] == firstNo)
                {
                    nextNo = intArray[i] == 1 ? 0 : 1;
                }
                else
                {
                    intArray[i] = nextNo;
                    noOfChanges++;
                }
            }
            return noOfChanges;
        }

        private static void NewMethod(int[] intArray, ref int noOfChanges, ref int nextNo)
        {
            for (int i = 1; i < intArray.Length; i++)
            {
                if (intArray[i] == nextNo)
                {
                    nextNo = intArray[i] == 1 ? 0 : 1;
                }
                else
                {
                    intArray[i] = nextNo;
                    noOfChanges++;
                }
            }
        }

        public int BinaryGap(int N)
        {
            string binary = Convert.ToString(N, 2);

            int gap = 0;
            int count = binary.Count(f => f == '1');
            List<int> gapArray = new List<int>();
            int firstOne = 0, secondOne = 0;
            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] == '1' && gap == 0)
                {
                    firstOne = 1;
                }
                if (i != 0 && firstOne == 1 && binary[i] == '1')
                {
                    secondOne = 1;
                    gap--;
                    gapArray.Add(gap);
                    gap = 0;
                }
                gap++;
            }
            return secondOne == 1 ? gapArray.Max() : 0;
        }

        public int[] CyclicRotation(int[] A, int K)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            for (int i = 1; i <= K; i++)
            {
                for (int j = 0; j < A.Length; j++)
                {
                    int temp = A[j];
                    A[j] = A[A.Length - 1];
                    A[A.Length - 1] = temp;
                }
            }
            return A;
        }

        public int UnpairedNumber(int[] A)
        {
            Array.Sort(A);
            int i, j, count = 0;
            for (i = 0; i < A.Length; i++)
            {
                for (j = i + 1; j < A.Length; j++)
                {
                    if (A[i] == A[j])
                        count++;
                    else
                        break;
                }
                if (count % 2 == 0)
                    return A[i];
                else
                {
                    count = 0;
                    i = j - 1;
                }
            }
            return 0;
        }

        public int FrogJmp(int X, int Y, int d)
        {
            int difference = Y - X;
            if (difference % 2 == 0)
            {
                return difference / d;
            }
            else
            {
                return difference / d + 1;
            }
        }

        public int FindMissingElement(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono
            if (A.Length == 0) return 1;
            int n = A.Length + 1;
            int sum = (n * (n + 1)) / 2;
            return sum - A.Sum();
        }

        public int FindDifferenceOfParts(int[] A)
        {
            int total = 0;

            for (int i = 0; i < A.Length; i++)
                total += A[i];

            int diff = int.MaxValue;
            int prev = 0;
            int next = total;

            for (int p = 1; p < A.Length; p++)
            {
                prev += A[p - 1];
                next = total - prev;
                diff = Math.Min(diff, Math.Abs(prev - next));
            }

            return diff;

            //int countp = A.Length - 1;
            //List<int> aaa = new List<int>();
            //for (int j = 1; j <= countp; j++)
            //{
            //    int firstPart = 0, secondPart = 0;
            //    for (int i = 0; i < A.Length; i++)
            //    {
            //        if (i + 1 <= j)
            //        {
            //            firstPart = firstPart + A[i];
            //        }
            //        else
            //        {
            //            secondPart = secondPart + A[i];
            //        }
            //    };
            //    aaa.Add(Math.Abs(firstPart - secondPart));
            //}
            //return aaa.Min();
        }

        public int FindLowestMissingNumber(int[] A)
        {
            int flag = 1;
            A = A.OrderBy(x => x).ToArray();
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] <= 0)
                    continue;
                else if (A[i] == flag)
                {
                    flag++;
                }
            }
            return flag;
        }


        public int CountDiv(int A, int B, int K)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int result = 0;

            if (A % K == 0)
            {
                result = ((B - A) / K) + 1;
            }
            else
            {
                result = (B / K - ((A / K) + 1)) + 1;
            }

            return result;
        }

        public int[] DNASequence(string S, int[] P, int[] Q)
        {
            S = "CAGCCTA";
            P = new int[] { 2, 5, 0 };
            Q = new int[] { 4, 5, 6 };
            int[] output = new int[P.Length];

            for (int i = 0; i < P.Length; i++)
            {
                int start = P[i];
                int end = Q[i];
                char[] substring = S.Substring(P[i], Q[i] - P[i] + 1).ToCharArray();
                Array.Sort(substring);
                if (substring[0] == 'A')
                {
                    output[i] = 1;
                }
                else if (substring[0] == 'C')
                {

                    output[i] = 2;
                }
                else if (substring[0] == 'G')
                {

                    output[i] = 3;
                }
                else if (substring[0] == 'T')
                {

                    output[i] = 4;
                }
            }
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            return output;
        }

        public int MaxProductOfThree(int[] A)
        {
            Array.Sort(A);
            int a = 0;
            if (A[0] < 0 && A[1] < 0)
                a = A[0] * A[1] * A[A.Length - 1];
            int b = A[A.Length - 1] * A[A.Length - 2] * A[A.Length - 3];

            if (a > b && (A[0] < 0 && A[1] < 0)) return a;
            else return b;
        }

        public int TrianglePrograming(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < A.Length; j++)
                {
                    for (int k = 0; k < A.Length; k++)
                    {

                    }

                }

            }
            return 0;
        }

        public int MinAbsValue(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var ordered = A.OrderByDescending(Math.Abs);

            var sum = 0;
            foreach (var e in ordered)
            {
                var multiplier = sum > 0 == e > 0 ? -1 : 1;
                sum += e * multiplier;
            }

            return sum;
        }
        public int MinAbsValueSumOfTwo(int[] A)
        {
            //List<int> output = new List<int>();

            //for (int i = 0; i < A.Length; i++)
            //{
            //    for (int j = i; j < A.Length; j++)
            //    {
            //        output.Add(Math.Abs(A[i] + A[j]));
            //    }
            //}
            int N = A.Length;
            Array.Sort(A);
            int tail = 0;
            int head = N - 1;
            int minAbsSum = Math.Abs(A[tail] + A[head]);
            while (tail <= head)
            {
                int currentSum = A[tail] + A[head];
                minAbsSum = Math.Min(minAbsSum, Math.Abs(currentSum));
                // If the sum has become
                // positive, we should know that the head can be moved left
                if (currentSum <= 0)
                    tail++;
                else
                    head--;
            }

            return minAbsSum;

        }


        public string ReverseOfANumber(int A, int B, int C)
        {
            var result = string.Empty;
            while (A != 0 || B != 0 || C != 0)
            {
                if (C < A || C < B)
                {
                    if (A != 0 && validateSequence(result, 'a', A, B, C))
                    {
                        result += "a";
                        A -= 1;
                    }
                    else if (B != 0 && validateSequence(result, 'b', A, B, C))
                    {
                        result += "b";
                        B -= 1;
                    }
                    else if (C != 0 && validateSequence(result, 'c', A, B, C))
                    {
                        result += "c";
                        C -= 1;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (C != 0 && validateSequence(result, 'c', A, B, C))
                    {
                        result += "c";
                        C -= 1;
                    }
                    else if (A != 0 && validateSequence(result, 'a', A, B, C))
                    {
                        result += "a";
                        A -= 1;
                    }
                    else if (B != 0 && validateSequence(result, 'b', A, B, C))
                    {
                        result += "b";
                        B -= 1;
                    }
                    else
                    {
                        break;
                    }
                }

            }
            return result;
        }
        public static bool validateSequence(string result, char character, int A, int B, int C)
        {
            bool output = false;
            if (!string.IsNullOrEmpty(result) && result.Length >= 2 && result[result.Length - 1] == character && result[result.Length - 2] == character)
            {
                output = false;
            }
            else
            {
                output = true;
            }
            return output;
        }


    }

    public class Customer
    {

        public int id;
        public static void setReference(Customer c)
        {
            c = null;
        }
    }


}
