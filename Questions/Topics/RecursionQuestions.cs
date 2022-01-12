using System;
using System.Collections.Generic;

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

            return n * NToPowerP(n, p - 1);
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
                return n - 1;

            return Fib(n - 1) + Fib(n - 2);
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

        /// ------------------------------------
        /// <summary>
        /// Question: Is Array sorted?
        /// </summary>
        public static void IsArraySorted()
        {
            var n = Helper.ReadN();
            var arr = Helper.ReadElementsInOneLine();
            var result = IsSorted(arr, 0, n - 1);
            Helper.WriteLine(result);
        }

        private static bool IsSorted(int[] arr, int start, int end)
        {
            if (start == end)
                return true;

            return arr[start] < arr[start + 1] && IsSorted(arr, start + 1, end);
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
            var result = GetFirstOccurrence(arr, 0, n - 1, key);
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
                return first + restOfString;

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
        /// There will be 2^n subsequences for any string of length n
        /// Input: ABC
        /// Output: 
        /// ""
        /// A
        /// B
        /// C
        /// AB
        /// AC
        /// BC
        /// ABC
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
            AllSubsequences(input.Substring(1), output + input[0]);
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
        /// Give all possible n alphabet sentences when n digits are pressed on the phone
        /// t9 keypad
        /// </summary>
        /// Approach
        ///     1. Get input digits in string format and pass to recursive function
        ///     2. That function will use for loop to make a recursive call for each of the letters of that digit
        /*
         * 
         * Input: digits = "23"
         * Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]
         * 
         */

        public static void LetterCombinationsPhone()
        {
            var keyMapping = new Dictionary<char, char[]>()
            {
                {'1', new char[]{ '.' } },
                {'2', new char[]{ 'a', 'b', 'c' } },
                {'3', new char[]{ 'd','e','f' } },
                {'4', new char[]{ 'g', 'h', 'i' } },
                {'5', new char[]{ 'j', 'k', 'l' } },
                {'6', new char[]{ 'm', 'n', 'o' } },
                {'7', new char[]{ 'p', 'q', 'r', 's' } },
                {'8', new char[]{ 't', 'u', 'v' } },
                {'9', new char[]{ 'x', 'y', 'z' } },
            };

            Helper.WriteLine("Input a number upto 4 characters, from 2 to 9");
            var input = Helper.ReadString();

            LetterCombinationsPhone(keyMapping, input, string.Empty);
        }

        private static void LetterCombinationsPhone(Dictionary<char, char[]> mapping, string input, string output)
        {
            if (input.Length == 0)
            {
                Helper.WriteLine(output);
                return;
            }

            var alphabets = mapping[input[0]];

            for (int i = 0; i < alphabets.Length; i++)
            {
                LetterCombinationsPhone(mapping, input.Substring(1), output + alphabets[i]);
            }
        }

        /// <summary>
        /// Print all permutations of a string
        /// </summary>
        /// Input: ABC
        /// Output:
        ///     ABC
        ///     ACB
        ///     BAC
        ///     BCA
        ///     CAB
        ///     CBA
        public static void PermutationsOfAString()
        {
            var input = Helper.ReadString();
            CalculatePermutations(input, string.Empty);
        }

        private static void CalculatePermutations(string input, string output)
        {
            if (input.Length == 0)
            {
                Helper.WriteLine(output);
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                var fixedChar = input[i];
                var restOfString = input.Substring(0, i) + input.Substring(i + 1);

                CalculatePermutations(restOfString, output + fixedChar);
            }
        }

        /// <summary>
        /// Given a row with n columns (array), and a dice which can output 1 to 6, count possible ways to reach destination
        /// </summary>
        /// Approach: 
        ///     1. Keep start and end
        ///     2. Recursively call each possible dice number and increase start to check if it reaches n
        public  static void CountPathsInSingleRow()
        {
            var end = Helper.ReadN();

            var ans = CountPathsInSingleRow(1, end);
            Console.WriteLine(ans);
        }

        // 1 2 3 4 5 6
        private static int CountPathsInSingleRow(int start, int end)
        {
            if (start == end)
            {
                return 1;
            }

            if (start > end) return 0;

            var count = 0;
            for(int i = 1; i<=6; i++)
            {
                count += CountPathsInSingleRow(start + i, end);
            }

            return count;
        }


        /// <summary>
        /// Given NxN maze (more like a grid), find all possible ways to reach from 0,0 to N-1,N-1
        /// we can either move downwards or right
        /// </summary>
        /// Approach
        ///     1. Maintain i,j (coordinates in the maze)
        ///     2. Recursively increment i & j separately
        ///     3. If i == n-1 & j == n-1 then return 1, 
        ///         the recursion tree will be built and take care of how many possible ways there are
        public static void CountPathsInGrid()
        {
            var n = Helper.ReadN();

            var ans = CountPathsInGrid(n, 0, 0);
            Console.WriteLine(ans);
        }

        private static int CountPathsInGrid( int n, int row, int col)
        {
            if (row == n - 1 && col == n - 1) return 1;
            else if (row >= n || col >= n) return 0;

            return CountPathsInGrid(n, row + 1, col) + CountPathsInGrid(n, row, col + 1);
        }


        /// <summary>
        /// Given a surface of 2xN blocks and 2x1 tiles, count number of ways this surface can be tiled
        /// </summary>
        /// Note: we need to count number of ways tiles will be placed not number of tiles
        /// Input: n = 4
        /// Output: 5
        /// Explanation:
        ///     For a 2 x 4 board, there are 3 ways
        ///     All 4 vertical(1 way)
        ///     All 4 horizontal(1 way)
        ///     2 vertical and 2 horizontal(3 ways)
        ///     
        /// Input: n = 3
        /// Output: 3
        /// Explanation:
        /// Place all 3 tiles vertically.
        /// Place 1 tile vertically and remaining 2 tiles horizontally (2 ways)
        /// 
        /// Approach
        ///     1. Notice if we place tile horizontally it will reduce problem size by 2, 
        ///         and vertically will reduce by 1
        ///     2. End condition: If there are no tiles to be placed, return 0
        ///     
        /*
            | | | | |
            | | | | |
            
            | |
            | |
         */
        public static void TilingProblem()
        {
            var n = Helper.ReadN();
            var ans = CalculateTiles(n);
            Helper.WriteLine(ans);
        }

        private static int CalculateTiles(int n)
        {
            if (n == 0 || n == 1 || n==2) return n;

            return CalculateTiles(n - 1) + CalculateTiles(n-2);
        }

        /// <summary>
        /// Given n friends, you can either pair them in groups of 2 or not pair them, count all possible pairings
        /// </summary>
        /// Solution: 
        ///     1. make two recursive calls, one to not pair them
        ///     2. One to pair them
        ///     3. also pairing can happen with n-1 people
        public static void FriendsPairingProblem()
        {
            var n = Helper.ReadN();
            var ans = CalculateFriendsPairing(n);
            Helper.WriteLine(ans);
        }

        private static int CalculateFriendsPairing(int n)
        {
            if (n == 0 || n == 1 || n == 2) return n;

            var notPairing = CalculateTiles(n - 1);
            var pairing = CalculateTiles(n - 2) * (n - 1);
            
            return notPairing + pairing;
        }


        /// <summary>
        /// Given a knapsack of that can hold weight W, and N items with respective weights and values, calculate maximum value that can be taken
        /// </summary>
        /// Input
        /// Value : 50 100 150
        /// Weight: 10 20  30
        /// 
        /// knapsack weight = 50
        /// Approach
        ///     1. For each item we have the following options
        ///         Take an item or not take an item
        ///     2. Recursively make call for each item to take it or not
        ///     3. End condition would be if items are empty or weight is exceeded
        ///     
        public static void ZeroOneKnapsack()
        {
            var values = Helper.ReadElementsInOneLine();
            var weights = Helper.ReadElementsInOneLine();

            Helper.WriteLine("Enter knapsack size");
            var knapsackSize = Helper.ReadN();

            var ans = CalculateKnapsack(values, weights, knapsackSize, 0);
            Helper.WriteLine(ans);
        }

        private static int CalculateKnapsack(int[] values, int[] weights, int knapsackSize, int idx)
        {
            if (knapsackSize == 0 || idx >= values.Length) return 0;
            int whenItemTaken = 0, whenNotTaken = 0;

            if (knapsackSize >= weights[idx])
            {
                whenItemTaken = values[idx] + CalculateKnapsack(values, weights, knapsackSize - weights[idx], idx + 1);
            }
            whenNotTaken = CalculateKnapsack(values, weights, knapsackSize, idx + 1);
            var maxValue = Math.Max(whenItemTaken, whenNotTaken);

            return maxValue;
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