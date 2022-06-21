using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmExercises
{
    internal class Program
    #nullable enable
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        //Takes a string argument and returns true if it is all uppercase, otherwise returns false
        static bool IsUppercase(string word)
        {
            bool isUppercase = true;
            foreach (char c in word)
            {
                if (char.IsLower(c)) { isUppercase = false; break; }
            }
            return isUppercase;

            //Linq single-line alternative
            //return word.All(char.IsUpper);
        }

        // Takes a string argument and determines if it includes 1x upper 1x lower and 1x numeric value
        static bool IsPasswordComplex(string s)
        {
            return s.Any(char.IsUpper) && s.Any(char.IsLower) &&
                s.Any(char.IsNumber) && s.Any(char.IsSymbol);

        }

        // Takes a string and returns it as lowercase
        static string NormaliseString(string s)
        {
            string normalised = s.ToLower();
            normalised = normalised.Trim();
            normalised = normalised.Replace("!", "");
            for (int i = 0; i < normalised.Length; i++)
            {
                char c = normalised[i];
                if (char.IsWhiteSpace(c) || !char.IsLetter(c))
                {
                    normalised = normalised.Remove(i, 1);
                    i = 0;
                }

            }
            return normalised;

            //single line alternative
            //return s.ToLower().Trim().Replace("/","");
        }

        // Reverses given string
        static string Reverse(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            string newString = "";
            for (int i = s.Length - 1; i > -1; i--)
            {
                newString += s[i];
            }
            return newString;
        }

        // Reverses words in sentence; keeps original word order
        static string ReverseSentence(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return s;

            Char[] sentence = s.ToArray();
            StringBuilder word = new StringBuilder();
            StringBuilder newSentence = new StringBuilder();
            for (int i = 0; i <= s.Length - 1; i++)
            {
                if (char.IsWhiteSpace(sentence[i]))
                {
                    newSentence.Append(Reverse(word.ToString()));
                    newSentence.Append(" ");
                    word.Clear();

                }
                else
                {
                    word.Append(sentence[i]);
                }
                if (i.Equals(s.Count() - 1))
                {
                    newSentence.Append(Reverse(word.ToString()));
                }
            }
            return newSentence.ToString();
        }
        static string ReverseSentence2(string s)
        {
            string[] sentence = s.Split(' ');
            StringBuilder newSentence = new StringBuilder();
            foreach (string word in sentence)
            {
                newSentence.Append(Reverse(word));
                newSentence.Append(' ');
            }
            return newSentence.ToString().Trim();
        }

        // Linear search for string, returns index if found, otherwise returns null
        static int? LinearSearch(string[] list, string s)
        {
            for (int i = 0; i < list.Length; i++) 
            {
                if (list[i] == s) return i;
            }
            return null;
        }
    }
}

