using System;

namespace Questions
{
    public static class RecursionQuestions
    {
        
        /// ------------------------------------
        /// <summary>
        /// Question: Use recursion to get sum till n.
        /// </summary>
        public static void SumTillN()
        {
            var n = Helper.ReadN();
            var sum = SumTillN(n);
            Helper.WriteLine(sum);
        }

        private static int SumTillN(int n)
        {
            if (n == 1)
                return n;

            return n + SumTillN(n - 1);
        }
        // ------------------------------------


        /// ------------------------------------
        /// <summary>
        /// Question: Return N ^ P using recursion
        /// </summary>
        public static void NToPowerP()
        {
            var n = Helper.ReadN();
            var p = Helper.ReadN();
            var result = NToPowerP(n, p);
            Helper.WriteLine(result);
        }

        private static int NToPowerP(int n, int p)
        {
            if (p == 0)
                return 1;

            return n * NToPowerP(n, p-1);
        }
        // ------------------------------------


        /// ------------------------------------
        /// <summary>
        /// Question: Factorial value of n
        /// </summary>
        public static void FactorialOfN()
        {
            var n = Helper.ReadN();
            var result = FactorialOfN(n);
            Helper.WriteLine(result);
        }

        private static int FactorialOfN(int n)
        {
            if (n == 1)
                return n;

            return n * FactorialOfN(n - 1);
        }
        // ------------------------------------

        /// ------------------------------------
        /// <summary>
        /// Question: Nth Fibonacci number
        /// </summary>
        public static void NthFibonacci()
        {
            var n = Helper.ReadN();
            var result = Fib(n);
            Helper.WriteLine(result);
        }

        private static int Fib(int n)
        {
            if (n == 1 || n == 2)
                return n-1;

            return Fib(n-1) + Fib(n-2);
        }
        // ------------------------------------

        /// ------------------------------------
        /// <summary>
        /// Question: Is Array sorted?
        /// </summary>
        public static void IsArraySorted()
        {
            var n = Helper.ReadN();
            var arr = Helper.ReadElementsInOneLine();
            var result = IsSorted(arr, 0, n-1);
            Helper.WriteLine(result);
        }

        private static bool IsSorted(int[] arr, int start, int end)
        {
            if (start == end)
                return true;

            return arr[start] < arr[start+1] && IsSorted(arr, start+1, end);
        }
        // ------------------------------------


        /// ------------------------------------
        /// <summary>
        /// Question: Print in ascending till Nth element
        /// </summary>
        public static void PrintInAscendingTillN()
        {
            var n = Helper.ReadN();
            Asc(1, n);
        }

        private static void Asc(int start, int end)
        {
            if (start > end)
                return;

            Console.WriteLine(start);
            Asc(start + 1, end);
        }
        // ------------------------------------

        /// ------------------------------------
        /// <summary>
        /// Question: Print in descending by using addition, idea is to understand call stack
        /// </summary>
        public static void PrintInDescendingTillN()
        {
            var n = Helper.ReadN();
            Desc(1, n);
        }

        private static void Desc(int counter, int n)
        {
            if (counter > n)
                return;
            
            Desc(counter + 1, n);
            Console.WriteLine(counter);

        }

        // ------------------------------------

        /// ------------------------------------
        /// <summary>
        /// Question: FirstOccurrence of an element in an array
        /// </summary>
        public static void FirstOccurrenceInArray()
        {
            var n = Helper.ReadN();
            var arr = Helper.ReadElementsInOneLine();
            var key = Helper.ReadN();
            var result = GetFirstOccurrence(arr, 0, n-1, key);
            Helper.WriteLine(result);
        }

        private static int GetFirstOccurrence(int[] arr, int start, int end, int key)
        {
            if (start > end) return -1;

            if (arr[start] == key) return start;
            else return GetFirstOccurrence(arr, start + 1, end, key);
        }
        // ------------------------------------

        /// ------------------------------------
        /// <summary>
        /// Question: FirstOccurrence of an element in an array
        /// </summary>
        public static void LastOccurrenceInArray()
        {
            var n = Helper.ReadN();
            var arr = Helper.ReadElementsInOneLine();
            var key = Helper.ReadN();
            var result = GetLastOccurrence(arr, 0, n - 1, key);
            Helper.WriteLine(result);
        }

        private static int GetLastOccurrence(int[] arr, int start, int end, int key)
        {
            if (start > end) return -1;

            var val = GetLastOccurrence(arr, start + 1, end, key);
            if (val == -1 && arr[start] == key) val = start;

            return val;
            
        }
        // ------------------------------------

        /// ------------------------------------
        /// <summary>
        /// Question: Reverse a string using recursion
        /// </summary>
        public static void ReverseString()
        {
            var s = Helper.ReadString();
            ReverseString(s);
        }

        private static void ReverseString(string s)
        {
            if (s == string.Empty)
                return;
            ReverseString(s.Substring(1));
            Console.Write(s[0]);
        }
        // ------------------------------------

        /// ------------------------------------
        /// <summary>
        /// Question: Replace Instances of a substring in string using recursion
        /// </summary>
        public static void ReplaceSubstring()
        {
            var str = Helper.ReadString();
            var old = Helper.ReadString();
            var latest = Helper.ReadString();

            ReplaceSubstring(str, old, latest);
        }

        private static void ReplaceSubstring(string s, string old, string latest)
        {
            if (s.Length < 1)
                return;
            if (s.StartsWith(old))
            {
                Console.Write(latest);
                ReplaceSubstring(s.Substring(old.Length), old, latest);
            }
            else
            {
                Console.Write(s[0]);
                ReplaceSubstring(s.Substring(1), old, latest);
            }
        }
        // ------------------------------------


        /// ------------------------------------
        /// <summary>
        /// Question: Tower of Hanoi
        /// </summary>
        public static void TowerOfHanoi()
        {
            var n = Helper.ReadN();
            TOH(n, "A", "C", "B");
        }

        private static void TOH(int n, string src, string dest, string aux)
        {
            if (n == 0)
                return;

            TOH(n - 1, src, aux, dest);
            Console.WriteLine($"Move {n} from {src} to {dest}");
            TOH(n - 1, aux, dest, src);
        }
        // ------------------------------------


        /// ------------------------------------
        /// <summary>
        /// Question: Remove duplicates in sorted string
        /// </summary>
        public static void RemoveDuplicates()
        {
            var n = Helper.ReadString();
            var result = RemoveDup(n);
            Helper.WriteLine(result);
        }

        private static string RemoveDup(string s)
        {
            if (s.Length == 0)
                return string.Empty;

            var first = s[0];
            var restOfString = RemoveDup(s.Substring(1));

            if (restOfString.Length != 0 && first == restOfString[0])
                return restOfString;
            else 
                return first + restOfString;
            
        }
        // ------------------------------------


        /// ------------------------------------
        /// <summary>
        /// Question: move all x to end of string.
        /// 
        /// Sol: 1. This solution goes to the end of string (n-1)
        /// 2. then from the n-1 it compares it to n-2
        /// 3. if n-2 == x, then it returns n-1 + 'x', thus moving 'x' to the end
        /// 
        /// Remarks: It is neat how, it returns correct string from each function call, but in the call stack starts returning from the very end
        /// </summary>
        public static void MoveXToEnd()
        {
            var n = Helper.ReadString();
            var result = MoveX(n);
            Helper.WriteLine(result);
        }

        private static string MoveX(string s)
        {
            if (s.Length == 0)
                return string.Empty;

            var first = s[0];
            var restOfString = MoveX(s.Substring(1));

            if (restOfString.Length != 0 && first == 'x')
                return restOfString + first;
            else
                return first+restOfString;

        }
        // ------------------------------------

        /// ------------------------------------
        /// <summary>
        /// Question: Print all subsequences of a string
        /// Idea: 
        ///     1. have input as whole string, have output as empty string
        ///     2. take one character from input, make a recursive call to add it, another call to not add it
        ///     3. when input is empty, print whatever output we have
        /// </summary>
        /// REVISIT
        public static void AllSubsequencesOfAString()
        {
            var n = Helper.ReadString();
            AllSubsequences(n, string.Empty);
        }

        private static void AllSubsequences(string input, string output)
        {
            if (input.Length == 0)
            {
                Console.WriteLine($"'{output}'");
                return;
            }

            AllSubsequences(input.Substring(1), output);
            AllSubsequences(input.Substring(1), input[0] + output);
        }
        // ------------------------------------

        /// ------------------------------------
        /// <summary>
        /// Question: Print all subsequences of a string with ascii
        /// Idea: 
        ///     1. have input as whole string, have output as empty string
        ///     2. take one character from input, make a recursive call to add it, another call to not add it
        ///     3. when input is empty, print whatever output we have
        /// </summary>
        /// REVISIT
        public static void AllSubsequencesASCIIOfAString()
        {
            var n = Helper.ReadString();
            AllSubsequencesASCII(n, string.Empty);
        }

        private static void AllSubsequencesASCII(string input, string output)
        {
            if (input.Length == 0)
            {
                Console.WriteLine($"'{output}'");
                return;
            }

            AllSubsequencesASCII(input.Substring(1), output);
            AllSubsequencesASCII(input.Substring(1), output + input[0]);
            AllSubsequencesASCII(input.Substring(1), output + input[0] + ((int)input[0]).ToString());
        }
        // ------------------------------------

        /// <summary>
        /// Get Nth Catalan number using recursion
        /// </summary>
        /// This solution can be further improved by hashing / memoization
        /*
         * Catalan numbers are a sequence of natural numbers that occur in 
         * various counting problems often involving recursively defined objects
         * 
         * Applications:
         *    Possible BSTs
         *    Paranthesis combinations
         *    possible forests
         *    ways of triangulations
         *    possible paths in matrix
         *    divide circle using n chords
         *    dyck words of given lenth
         *    etc
         *  
         * 
         * Catalan number is series defined by the following formula
         * 
         * C0 = 1
         * C1 = 1
         * C2 = C0*C1 + C1*C0 = 2
         * C3 = C0*C2 + C1*C1 + C2*C0 = 5
         */

        public static void NthCatalanNumber()
        {
            var n = Helper.ReadN();
            int result = NthCatalanNumber(n);
            Helper.WriteLine(result);
        }

        private static int NthCatalanNumber(int n)
        {
            if (n == 0 || n == 1) return 1;

            var sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += NthCatalanNumber(i) * NthCatalanNumber(n - 1 - i);
            }

            return sum;
        }
    }
}

// Template 

/*
 
/// ------------------------------------
/// <summary>
/// Question: 
/// </summary>
public static void SumTillN()
{
    var n = Helper.ReadN();
    var result = SumTillN(n);
    Helper.WriteLine(result);
}

private static int SumTillN(int n)
{
    if (n == 1)
        return n;

    return n + SumTillN(n - 1);
}
// ------------------------------------


*/