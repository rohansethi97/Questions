using System;
using System.Collections.Generic;
using System.Linq;

namespace Questions
{
    public class StringQuestions
    {
        /*
         * strings are immutable in c#, you need to assign it back to itself to update
         */
        /// <summary>
        /// basic operations on string
        /// </summary>
        public static void Operations()
        {
            Console.WriteLine("Input s1");
            string s1 = Console.ReadLine();
            Console.WriteLine("Input s2");
            var s2 = Helper.ReadString();
            Helper.WriteLine($"string: {s1}");
            Helper.WriteLine($"length: {s1.Length}");

            Console.Write($"string using indexes:");
            for (int i = 0; i <= s1.Length; i++)
                Console.Write(s1[i]);
            Console.WriteLine();

            Console.WriteLine($"string concat using +:{s1 + s2}");
            Console.WriteLine($"string concat using concat fn:{string.Concat(s1, s2)}");
            Console.WriteLine($"string insert fn:{s1.Insert(2, s2)}");
            Console.WriteLine($"string substring fn:{s1.Substring(0, 3)}");
            Console.WriteLine($"string1: {s1}");
            Console.WriteLine($"string2: {s2}");

        }

        /// <summary>
        /// String has some higher or lower chars, convert them to lower and higher strings
        /// </summary>
        public static void ToLowerAndToUpper()
        {
            var str = Console.ReadLine();
            var lower = ToLower(str);
            var upper = ToUpper(str);
            Helper.WriteLine(lower);
            Helper.WriteLine(upper);
        }

        private static string ToLower(string str)
        {
            var newStr = "";
            var diff = 'a' - 'A'; //a=65, A=97
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z') 
                    newStr += (char)(str[i] + diff);
                else 
                    newStr += str[i];
            }

            return newStr;
        }

        private static string ToUpper(string str)
        {
            var newStr = "";
            var diff = 'a' - 'A'; //a=65, A=97
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'a' && str[i] <= 'z')
                    newStr += (char)(str[i] - diff);
                else 
                    newStr += str[i];

            }

            return newStr;
        }

        /// <summary>
        /// FormBiggestNumber in a string
        /// </summary>
        public static void FormBiggestNumber()
        {
            var str = Console.ReadLine();
            var result = FormBiggestNumber(str);
            Helper.WriteLine(result);
        }

        private static string FormBiggestNumber(string str)
        {
            var arr = str.ToCharArray();
            Array.Sort(arr, (char1, char2) => char2.CompareTo(char1));
            return new string(arr);
        }

        /// <summary>
        /// HighestFrequqncyAlphabet in string
        /// </summary>
        public static void HighestFrequencyAlphabet()
        {
            var str = Console.ReadLine();
            var result = HighestFrequencyAlphabet(str);
            Console.WriteLine(result);
        }

        private static char HighestFrequencyAlphabet(string str)
        {
            str = str.ToLower();
            var hash = new int['z' - 'a'+1];
            for (int i=0; i < str.Length; i++)
            {
                hash[str[i] - 'a']++;
            }

            var highest = 0;
            var highestIdx = 0;

            for (int i = 0; i < hash.Length; i++)
            {
                if (highest < hash[i])
                {
                    highest = hash[i];
                    highestIdx = i;
                }
            }

            return (char) (highestIdx + 'a');
        }
    }
}


/*
        /// <summary>
        /// Array
        /// </summary>
        public static void Array()
        {
            var arr = Helper.ReadElementsInOneLine();
            var n = arr.Length;

            var ans = Array(arr);
            Helper.WriteLine(ans);
        }

        private static int Array(int[] arr)
        {
            return 1;
        }
 */

