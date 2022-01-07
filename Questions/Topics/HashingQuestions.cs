using System;
using System.Collections.Generic;

namespace Questions
{
    public class HashingQuestions
    {
        /*
         * Theory
         * Why hashing? :
         * To improve search speed
         * 
         * Linear: O(n)
         * Binary: O(logn) * requires sorting
         * Hashing: Ideal time is O(1) * takes up more space
         * 
         * Hashing is a relation from keys to hash table, we are using functions for mapping i.e. one-one, & many-one
         * one-one hash function is aka ideal hashing
         * 
         * many to one function results in collisions (two keys at same index)
         * 
         * =*= Loading factor: (denoted by lamda) = keys count / size of hashtable 
         * =*= lambda changes with each hash function, a hashfunction should make sure
         *  to keys are evenly distributed
         * 
         * Methods to resolve collision
         *  Open hashing
         *      Chaining
         *          Here, when collision occurs, multiple keys can be stored by using linked list
         *          linked list can be sorted to optimize further
         *          
         *          * Loading factor can be greater than one
         *          Operations: 
         *              Insertion
         *              Search
         *               When found: t = 1 (hash fn) + lambda/2 (average time in linked list) 
         *               When not found: 1 + lambda
         *              Delete
         *                  
         *                  
         *  Closed hashing
         *      Open addressing
         *      1. Linear probing
         *          
         *          * Loading factor will be smaller than one
         *          =**= Loading factor should be <= 0.5
         *          
         *          In case of collisions, move to next available space by searching linearly
         *          h(x) = (h(x)+f(i)) % 10
         *              where f(i) is 0,1,2,3
         *          
         *          when collision happen, they tend to cluster around some indexes
         *          
         *          Operations
         *              Insert: use hashfunction iteratively till free space is found
         *                  
         *              Search: use hashfunction iteratively till free space is found
         *                      
         *              Delete:
         *                  To delete an element, we will have to consider original hash indexes
         *                  and we cannot simply delete any element
         *                  We will need to take out one element and rehash whole table
         *                  (Rehashing)
         *                  Not recommended, alternatively a flag can be used
         *                  
         *      2. Quadratic probing
         *          Similar to linear probing, here hash function will use mathematical functions
         *          
         *          Primary reason is to avoid clustering
         *          
         *          h(x) = (h(x)+f(i)) % 10
         *              where f(i) is i^2      
         *              
         *      3. Double hashing
         *          We will have two hash functions, one regular and second for when there is a collision
         *          
         *          regular = h1(x) = x%10
         *          collision = h2(x) = R - (x % R) 
         *              where R is a prime number less than size of hash table
         *          * Seconds hash function should not return 0
         *          * Seconds hash function should distribute evenly
         *          
         *          complete function: h(x) = (h1(x) + i*h2(x)) % 10
         *              where i = 0, 1, ..
         *          
         *          
         * Hash function ideas
         *  1. Mod
         *      h(x) = (x%size)+1 
                    if size is prime number it will result in fewer collisions
                    size should be atleast twice as big as number of keys
         *  2. Midsquare
         *      h(x) = square the key and take mid value
         *          key = 11,
         *          11^2 = 121, hash function will output 2, as it is mid
         *          
         *  3. Folding
         *      key = 123347
         *      then 12+33+47 = 9+2 = 11
         *      
         *      string can be converted to ascii and then perform folding
         *      
         *  
         */

        /// <summary>
        /// Implement hashing by using chaining
        /// </summary>
        public static void Chaining()
        {
            var arr = Helper.ReadElementsInOneLine();
            var hashTable = ConvertToHashTableOpenAddressing(arr);
            Helper.WriteLine(arr);

            Helper.WriteLine($"Search {arr[0]}: {hashTable.Search(arr[0])}");
            Helper.WriteLine($"Search {arr[1]}: {hashTable.Search(arr[1])}");
            Helper.WriteLine($"Delete {arr[0]}: {hashTable.Delete(arr[0])}");
            Helper.WriteLine($"Search {arr[0]}: {hashTable.Search(arr[0])}");
        }

        internal static void LinearProbing()
        {
            var arr = Helper.ReadElementsInOneLine();
            var hashTable = ConvertToHashTableClosedAddressing(arr);
            Helper.WriteLine(arr);

            Helper.WriteLine($"Search {arr[0]}: {hashTable.Search(arr[0])}");
            Helper.WriteLine($"Search {arr[1]}: {hashTable.Search(arr[1])}");
            Helper.WriteLine($"Delete {arr[0]}: {hashTable.Delete(arr[0])}");
            Helper.WriteLine($"Search {arr[0]}: {hashTable.Search(arr[0])}");
        }

        internal static void QuadraticProbing()
        {
            var arr = Helper.ReadElementsInOneLine();
            var hashTable = ConvertToHashTableClosedAddressing(arr, true);
            Helper.WriteLine(arr);

            Helper.WriteLine($"Search {arr[0]}: {hashTable.Search(arr[0])}");
            Helper.WriteLine($"Search {arr[1]}: {hashTable.Search(arr[1])}");
            Helper.WriteLine($"Delete {arr[0]}: {hashTable.Delete(arr[0])}");
            Helper.WriteLine($"Search {arr[0]}: {hashTable.Search(arr[0])}"); ;
        }

        /// <summary>
        /// Print vertical order of a Binary tree
        /// </summary>
        /*
         *  I:      1
         *       2     3
         *     4   5 6   7
         *  O: 4 2 1 5 6 3 7   
         */
        public static void VerticalOrderPrint()
        {
            BinaryTreeQuestions.VerticalOrderPrint();
        }

        /// <summary>
        /// Given an array and K, output Top K Most Frequent Elements
        /// </summary>
        public static void TopKMostFrequentElements()
        {
            var arr = Helper.ReadElementsInOneLine();
            var k = Helper.ReadN();

            var hashMap = new Dictionary<int, int>();
            foreach (int a in arr)
            {
                if (!hashMap.ContainsKey(a)) hashMap[a] = 0;
                hashMap[a]++;
            }

            var heap = new Heap_Pair();
            var ans = new List<int>();
            foreach (var mapping in hashMap)
            {
                heap.Insert((mapping.Value, mapping.Key));
            }

            for (int i = 0; i < k; i++)
            {
                ans.Add(heap.Delete().Item2);
            }

            Helper.WriteLine(ans.ToArray());
        }

        /// <summary>
        /// Given an array and number k, find first k distinct elements and their frequency
        /// </summary>
        public static void FirstKDistinctElements()
        {
            var arr = Helper.ReadElementsInOneLine();
            var k = Helper.ReadN();

            var hashMap = new Dictionary<int, int>();
            
            for (int i =0; i<arr.Length; i++)
            {
                var ele = arr[i];
                if (!hashMap.ContainsKey(ele) && hashMap.Count >= k)
                {
                    break;
                }

                if (!hashMap.ContainsKey(ele)) hashMap[ele] = 0;
                hashMap[ele]++;

            }

            foreach(var kv in hashMap)
            {
                Helper.WriteLine($"{kv.Key}: {kv.Value}");
            }


        }

        // todo_question: array prefix sum
        /// <summary>
        /// Given an array, find all possible sub arrays that can have sum as 0
        /// </summary>
        public static void NumberOfSubarraysWithSumZero()
        {
            throw new NotImplementedException();
        }

        // todo_question: This requires backtracking
        /// <summary>
        /// Given a unsolved valid sudoku grid, write code which can solve the sudoku puzzle 
        /// </summary>
        public static void SudokuSolver()
        {
            throw new NotImplementedException();
        }


        #region Helpers
        private static HashTable_OpenAddressing ConvertToHashTableOpenAddressing(int[] arr)
        {
            var hashTable = new HashTable_OpenAddressing(arr.Length);

            foreach (int a in arr)
            {
                hashTable.Insert(a);
            }

            return hashTable;
        }

        private static HashTable_ClosedAddressing ConvertToHashTableClosedAddressing(int[] arr, bool isQuadratic = false)
        {
            var hashTable = new HashTable_ClosedAddressing(arr.Length, isQuadratic ? ProbingType.Quadratic : ProbingType.Linear);

            foreach (int a in arr)
            {
                hashTable.Insert(a);
            }

            return hashTable;
        }
        #endregion
    }
}
