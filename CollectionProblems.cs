using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionProblems
{
    internal class CollectionProblems
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4, 5, 6};
            int[] b = { 4, 5, 6, 7, 8, 9, 7, 6, 3, 4, 7, 10};
            //Console.WriteLine("Missing elements of array 'a':");
            //FindMissingElements(a, b).ForEach(x => Console.Write(" " + x));

            Console.WriteLine("Frequency of elements in array 'b'");
            FrequencyOfElements(b);
    }

        //Compares elements between two given arrays 'a' & 'b' and returns an array
        //with elements that exist in 'b' only
        public static List<int>? FindMissingElements(int[] a, int[] b)
        {
            /* 
             * logic:
             * if b has 0 elements, there is nothing to compare with
             * Create HashSet to track values of 'a'
             * Create a List that will hold the missing elements of 'a'
             * add every element of 'a' to HashSet
             * For every element 'N' in 'b' that doesn't exist in 'a' do:
             *    add 'N' to List
             * return List 
             */

            if (b.Length == 0)
            {
                return null;
            }
            HashSet<int> list = new HashSet<int>();
            List<int> result = new List<int>();
            foreach (int i in a)
            {
                list.Add(i);
            }
            int j = 0;
            foreach (int i in b)
            {
                if(!list.Contains(i))
                {
                    result.Add(i);
                }
                j++;
            }
            return result;
        }

        //Takes an array and prints the frequency each element appears.
        public static void FrequencyOfElements(int[] n)
        {
            /* logic:
             * if n is empty, return;
             * create dictionary to keep track of repeating values in n
             * for every value in n do:
             *      if value already exists in dictionary keys, increase its frequency by 1
             *      if value doesn't exist, insert value into dictionary as key and set frequency to 1
             * print all key-value pairs in the dictionary
             */

            if(n.Length == 0)
            {
                return;
            }
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int i in n) 
            {
                if(dict.ContainsKey(i))
                {
                    dict[i]++;
                }
                else
                {
                    dict.Add(i, 1);
                }
            }
            foreach (KeyValuePair<int, int> kv in dict)
            {
                Console.WriteLine($"'{kv.Key}' appears {kv.Value} times.");
            }
        }
    }
}
