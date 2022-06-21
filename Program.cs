using System;
using System.Collections.Generic;

namespace SearchingAlgorithms
{
    internal class Program
#nullable enable
    {
        static void Main(string[] args)
        {
            int[] i = {0, 1, 2, 3, 4, 11, 12, 13, 14, 15, 110, 120, 130, 140, 150};
            //int[] array = GreaterThan(i, 4);
            //Array.ForEach(array, x => Console.Write(x + " "));
            //Console.WriteLine();
            //Console.WriteLine(RecursiveBinarySearch(i, 150));
            //Console.WriteLine(IterativeBinarySearch(i, 150));
            //Array.ForEach(ReverseArray(i), x => Console.Write(x + " "));
            //Console.WriteLine();

            //Array.ForEach(ReverseInPlace(i), Console.WriteLine);

            //Array.ForEach(ShiftPosition2(i), Console.WriteLine);

            //PrintBinary(18);

            //FindGreater(new int[] {9, 2, 141, 56, 4, 430, 1000, 1050, 15, 6, 1740 });

            string[] s = { "(hello) computer)", "((Origin)()(of)()(Symmetry))",
            "Up() for (a() challenge?)", "((country Road! Take me home!)"};
            foreach (string st in s)
            {
                Console.WriteLine($"{st} has matching parentheses: {HasMatchingParentheses(st)}");
            }


        }

        // returns index if passed int exists in given list, or false if it does not
        public static int? LinearSearch(int[] list, int x)
        {
            for(int i = 0; i < list.Length; i++)
            {
                if (list[i] == x) return i;
            }
            return null;
        }

        //returns the int if it is found in the list, otherwise returns 0
        public static int LinearSearch2(int[] list, int x)
        {
            return Array.Find(list, element => element == x);
        }

        //returns an array of int that meet specified condition
        public static int[] GreaterThan(int[] list, int x)
        {
            return Array.FindAll(list, element => element > x);
        }

        //binary search for given int; returns index if exists
        //Recursive method:
        public static int RecursiveBinarySearch(int[] list, int x)
        {
            if (list.Length == 1 && list[0] == x)
            {
                return 0;
            }
            int midPoint = list.Length / 2;
            Console.WriteLine("midpoint:" + midPoint);
            if(list[midPoint] > x)
            {
                return BinarySearch(list, x, 0, midPoint);
            }
            else
            {
                return BinarySearch(list, x, midPoint, list.Length);
            }

            
            static int BinarySearch(int[] list, int x, int start, int end)
            {
                int midPoint = (start + end) / 2;
                Console.WriteLine("2nd method:" + midPoint);
                if (list[midPoint] == x)
                {
                    return midPoint;
                }
                if (list[midPoint] > x)
                {
                    return BinarySearch(list, x, start, midPoint);
                }
                else if (list[midPoint] < x)
                {
                    return BinarySearch(list, x, midPoint, end);
                }
                return -1;
            }
        }
        //Iterative method
        public static int IterativeBinarySearch(int[] list, int x)
        {
            int min = 0;
            int max = list.Length-1;
            int midPoint = (max + min) / 2;

            //while min != max
            // is [midPoint] == x?
            // yes? return x
            // no?:
            // if x> midpoint, min = midPoint, max = max, midPoint = (mid+max/2)
            // if x< midPoint, min = min, max = midPoint, midPoint = (mid+max/2)
            while(min <= max)
            {
                if(list[midPoint] == x) return midPoint;
                if(list[midPoint] > x)
                {
                    max = --midPoint;
                    midPoint = (max + min) / 2;
                }
                else if(list[midPoint] < x)
                {
                    min = ++midPoint;
                    midPoint= (min + max) / 2;
                }
                Console.WriteLine($"min:{min}, max{max}");

            }
            Console.WriteLine("loop ends");
            return -1;

        }

        //Reverses the elements of given array
        public static int[] ReverseArray(int[] list)
        {
            if (list.Length == 0) return list;
            int[] result = new int[list.Length];
            
           for (int i = list.Length-1; i != 0; i--)
            {
                result[list.Length -i -1] = list[i];
            }
           return result;
        }
        //Reverses elements of given array in place
        public static int[] ReverseInPlace(int[] list)
        {
            int i = 0;
            int j = list.Length - 1;
            while(i != j)
            {   
                int temp = i;
                list[i++] = list[j];
                list[j--] = temp;
            }
            return list;
        }

        //Shifts elements in an array by 1 position to the left
        public static int[] ShiftPosition(int[] list)
        {
            //while i is less than number of elements in the list:
            //i = 0;
            //store i-th element of the array in temp
            //store element from position i+1, to position i
            //store temp element into position i+i
            //increment i by 1
            int i = 0;
            while (i < list.Length)
            {   
                if(i == list.Length-1) return list; //if end of list is reached; return list
                int temp = list[i];
                list[i] = list[i+1];
                list[i+1] = temp;
                ++i;
            }
            return list;
        }
        //More intuitive approach of ShiftPosition algorithm
        public static int[] ShiftPosition2(int[] list)
        {
            var temp = list[0];
            for(int i = 0; i < list.Length-1; ++i)
            {
                list[i] = list[i + 1];
            }
            list[list.Length-1] = temp;
            return list;
        }
        //Prints a series of binary numbers that correspond to numbers up to given int
        public static void PrintBinary(int i)
        {
            //if input is less or equal to 0, the input is invalid
            //Create Queue
            //Enque first number
            //From 0 to given input do:
            //Remove 1st item from Queue
            //Print item
            //Establish patern for binary; n0=1, n1=1*10, n2=(1*10)+1
            //Calculate and enqueue n1 and n2
            if (i <= 0)
            {
                Console.WriteLine("Invalid input.");
            }
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            for (int j = 0; j < i; ++j)
            {
                var current = queue.Dequeue();
                Console.WriteLine(current);
                queue.Enqueue(current * 10);
                queue.Enqueue((current * 10) + 1);
            }
            Console.WriteLine();
        }
        //Finds and prints the next greater element for each element in the given array with Stack implementation
        public static void FindGreater(int[] arr)
        {
            if (arr.Length <= 1)
            {
                return;
            }

            //create stack to store array elements that are already compared with current
            //insert first element of given array arr into stack
            //iterate through array to find next greater element
                //store first value to compare with current as var 'next'
                //if stack has at least 1 element do:
                    //store 1st item from stack as var 'current'
                    //As long as 'current' is less than 'next' do:
                        //Print current < next
                        //if stack is empty? break;
                        //assign new value from the stack as 'current'
                    //if 'next' <= 'current' then insert next into stack
            //Print elements that don't have a greater number

            Stack<int> stack = new Stack<int>();
            stack.Push(arr[0]);

            for (int i = 1; i < arr.Length; ++i)
            {
                var next = arr[i];
                if (stack.Count > 0)
                {
                    var current = stack.Pop();
                    while (current < next)
                    {
                        Console.WriteLine($"{current} ----> {next}");
                        if (stack.Count == 0)
                        {
                            break;
                        }
                        current = stack.Pop();
                    }
                }
                stack.Push(next);
            }
            if (stack.Count > 0)
            {
                Console.WriteLine("Numbers without a greater value:");
            }
            while (stack.Count > 0)
            {
                Console.Write(" " + stack.Pop());
            }
            Console.WriteLine();

        }
        //Returns true or false depending on whether given string has matching parentheses or not
        public static bool HasMatchingParentheses(string s)
        {
            Stack<Char> stack = new Stack<Char>();
            foreach(Char c in s)
            {
                if (c == '(')
                {
                    stack.Push(c);
                }
                if (c == ')' && stack.Count > 0)
                {
                    stack.Pop();
                }
                else if (c == ')' && stack.Count == 0)
                {
                    return false;
                }
            }
            return !(stack.Count > 0);
        }
    }
}
