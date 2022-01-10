using System;
using System.Collections.Generic;
using System.Linq;

namespace Questions
{
    public class CharArrayQuestions
    {
        /*
         * syntax: char[] arr = new char[size]
         * In older programming languages, size had to be
         * declared as size+1 to accomodate '\0' i.e. null character or 
         * string termination character
         */

        /// <summary>
        /// Basic operations in char array
        /// </summary>
        public static void Operations()
        {
            char[] arr = Console.ReadLine().ToCharArray();

            // Print length
            Helper.WriteLine(arr.Length);

            // Print whole array
            Console.WriteLine(arr);

            // Print ith char
            Console.WriteLine(arr[0]);
        }

        /// <summary>
        /// Check if a word is palindrome
        /// </summary>
        public static void Palindrome()
        {
            var arr = Console.ReadLine().ToCharArray();
            var ans = Palindrome(arr);
            Helper.WriteLine(ans);
        }

        // ABCCBA
        private static bool Palindrome(char[] arr)
        {
            var n = arr.Length;
            bool isPalindrome = true;
            for (int i=0; i<=n/2 -1; i++)
            {
                if (arr[i] != arr[n - 1 - i])
                    isPalindrome = false;
            }

            return isPalindrome;
        }

        /// <summary>
        /// Largest Word In CharArray
        /// </summary>
        public static void LargestWordInCharArray()
        {
            var arr = Console.ReadLine().ToCharArray();
            var ans = LargestWordInCharArray(arr);
            Console.WriteLine(ans);
        }

        // do or die
        // 012345678
        private static char[] LargestWordInCharArray(char[] arr)
        {
            var n = arr.Length;
            var maxStart = 0;
            var maxEnd = 0;
            var maxLength = 0;

            var currentLength = 0;
            var currentStart = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] != ' ')
                {
                    currentLength++;

                    if (currentLength > maxLength)
                    {
                        maxStart = currentStart;
                        maxLength = currentLength;
                        maxEnd = i;
                    }
                }
                else
                {
                    currentLength = 0;
                    currentStart = i + 1;
                }
            }

            var result = new char[maxEnd - maxStart + 1];
            for (int i = 0, j = maxStart; j <= maxEnd; i++,j++)
            {
                result[i] = arr[j];
            }

            return result;
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

