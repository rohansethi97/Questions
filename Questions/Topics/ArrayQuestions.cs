using System;
using System.Collections.Generic;
using System.Linq;

namespace Questions
{
    public class ArrayQuestions
    {

        /*
         * Theory
         * Array: 1 2 4 1 0 3
         * 
         * Calculating required complexity of a question using constraints
         *     1 sec = ~10^8 operations
         *     if array size < 10^4 it can be done in n^2
         *     1GB size = 10^8 array max
         * 
         * Subarray and subsequence
         *     Subarray
         *         contiguous part of an array with any (>1) number of elements
         *         1 0 3
         *             number of subarrays of an array with n elements = nC2+n
         *      
         *     Subsequence
         *         A subsequence of an array is a subsequence that can be derived by selecting zero or 
         *         more elements without changing order of remaining elements
         *         1 4 3
         *             number of subsequences = 2^n
         *             
         *         Every subsequence is a subarray, but subarray is not a subsequence
         *  
         *  
         */

        /// <summary>
        /// Find max till ith elemetn in array
        /// </summary>
        public static void MaxTillI()
        {
            var arr = Helper.ReadElementsInOneLine();
            var n = arr.Length;

            var ans = MaxTillI(arr);
            Helper.WriteLine(ans);
        }

        private static int[] MaxTillI(int[] arr)
        {
            var iMaxArray = new int[arr.Length];
            var max = arr[0];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max) max = arr[i];
                iMaxArray[i] = max;
            }

            return iMaxArray;
        }

        /// <summary>
        /// Sum Of All Subarrays in a array
        /// </summary>
        /// Arrays: 1 2 2
        /// Subarrays
        ///     1       = 1
        ///     1 2     = 3
        ///     1 2 2   = 5
        ///     2       = 2
        ///     2 2     = 4
        ///     2       = 2
        public static void SumOfAllSubarrays_Nested_Loop()
        {
            var arr = Helper.ReadElementsInOneLine();
            var n = arr.Length;

            SumOfAllSubarrays_Nested_Loop(arr);
        }

        private static void SumOfAllSubarrays_Nested_Loop(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                var sum = 0;
                for (int j = i; j < arr.Length; j++)
                {
                    sum += arr[j];
                    Helper.WriteLine(sum);
                }

            }
        }

        /// <summary>
        /// Longest Arithmetic Subarray
        ///     Given array with N integers, give the length of longest contiguous sub array
        /// 
        /// An arithmetic array is an array that contains at least two integers and the 
        /// differences between consecutive integers are equal for example
        /// 
        /// 9,10 & 3,3,3 & 9,7,5,3 are arithmetic arrays
        /// 
        /// while 1 3 3 7 & 2 1 2 are not arithmetic arrays
        /// </summary>
        public static void LongestArithmeticSubarray()
        {
            var arr = Helper.ReadElementsInOneLine();
            var ans = LongestArithmeticSubarray(arr);
            Helper.WriteLine(ans);
        }

        // [ 9 7 5 3 0]
        // [ 9 7 ]
        private static int LongestArithmeticSubarray(int[] arr)
        {
            if (arr.Length <= 1) return arr.Length;

            var longestLas = 0;
            var currentLas = 0;
            var currentDiff = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                var diff = arr[i] - arr[i - 1];
                if (diff == currentDiff) currentLas++;
                else
                {
                    currentDiff = arr[i] - arr[i - 1];
                    currentLas = 1;
                }

                if (longestLas < currentLas) longestLas = currentLas;
            }

            return longestLas + 1;
        }

        /// <summary>
        /// Record breaker
        /// Given visitors in an array
        /// A record breaking day is
        ///     number of visitors is greater than all previous days or first day
        ///     and
        ///     number of visitor is larger than the following day or last day or 
        /// </summary>
        /// 
        /// I: 1 2 0 7 2 0 2 2
        /// O: 2
        public static void RecordBreaker()
        {
            var arr = Helper.ReadElementsInOneLine();
            var ans = RecordBreaker(arr);
            Helper.WriteLine(ans);
        }

        private static int RecordBreaker(int[] arr)
        {
            int recordBreakingDays = 0;
            var maxTillNow = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (
                    (i == 0 || arr[i] > maxTillNow)
                    && (i == arr.Length - 1 || arr[i] > arr[i + 1])
                    )
                {
                    recordBreakingDays++;
                }
                if (arr[i] > maxTillNow) maxTillNow = arr[i];
            }

            return recordBreakingDays;
        }


        /// <summary>
        /// Given an array of size n, find an element which occurs more than once, if there are
        /// multiple, find the one with smallest initial occurence index
        /// </summary>
        /// I: 0 1 2 3 4 5 6 6 4
        /// O: 4
        public static void FirstRepeatingElement()
        {
            var arr = Helper.ReadElementsInOneLine();
            var ans = FirstRepeatingElement(arr);
            Helper.WriteLine(ans);
        }

        private static int FirstRepeatingElement(int[] arr)
        {
            var hashMap = new Dictionary<int, int>();
            var minIdx = arr.Length + 1;
            for (int i = 0; i < arr.Length; i++)
            {
                var ele = arr[i];
                if (hashMap.ContainsKey(ele) && minIdx > hashMap[ele])
                    minIdx = hashMap[ele];
                else
                    hashMap[ele] = i;
            }

            return minIdx == arr.Length + 1 ? -1 : arr[minIdx];

        }

        /// <summary>
        /// Given an array with n numbers, and a sum s. Find subarray whose sum is equal to s
        /// </summary>
        /// I: 0 3 2 4 5
        /// I: 6
        /// O: true
        public static void SubarrayWithGivenSum()
        {
            var arr = Helper.ReadElementsInOneLine();
            var sum = Helper.ReadN();
            var ans = SubarrayWithGivenSum(arr, sum);
            Helper.WriteLine(ans);
        }


        private static int[] SubarrayWithGivenSum(int[] arr, int sum)
        {
            int start = 0; int end = 0;

            var currSum = arr[0];
            var foundAns = false;
            while (end < arr.Length)
            {
                if (currSum == sum)
                {
                    foundAns = true;
                    break;
                }
                else if (currSum < sum)
                {
                    end++;
                    if (end > arr.Length - 1) break;
                    currSum += arr[end];
                }
                else
                {
                    if (start == end)
                    {
                        currSum -= arr[start];
                        start++;
                        end++;
                        currSum += arr[end];
                    }
                    else
                    {
                        currSum -= arr[start];
                        start++;
                    }
                }
            }
            if (foundAns)
            {
                var result = new int[end - start + 1];
                for (int i = 0, j = start; j <= end; i++, j++)
                {
                    result[i] = arr[j];
                }
                return result;
            }

            return new int[0];
        }

        /// <summary>
        /// given an array of n integers, the task is to find smallest positive number missing from array
        /// </summary>
        /// I: 0 -9 1 3 -4 5
        /// O: 2
        public static void SmallestPositiveMissingNumber()
        {
            var arr = Helper.ReadElementsInOneLine();
            var ans = SmallestPositiveMissingNumber(arr);
            Helper.WriteLine(ans);
        }

        private static int SmallestPositiveMissingNumber(int[] arr)
        {
            var max = arr.Max();
            var hash = new bool[max + 1];

            foreach(int a in arr)
            {
                if (a > 0)
                    hash[a] = true;
            }

            int i = 1;
            while (i < max)
            {
                if (hash[i] == false) 
                    return i;
                i++;
            }

            return -1;
        }

        /// <summary>
        /// Find max sub array sum for any given array
        /// </summary>
        /// I: 1 2 3
        /// O: 
        /// 1
        /// 1 2
        /// 1 2 3
        /// 2
        /// 2 3
        /// 3
        public static void PrintAllSubarrays()
        {
            var arr = Helper.ReadElementsInOneLine();
            PrintAllSubarrays(arr);
        }
        private static void PrintAllSubarrays(int[] arr)
        {
            var n = arr.Length;
            for (int i=0; i<n; i++)
            {
                for (int j=i; j < n; j++)
                {
                    for (int k=i; k<=j; k++)
                    {
                        Console.Write(arr[k] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Find max sub array sum for any given array
        /// </summary>
        /// 4 5 -7
        public static void MaxSubarraySum_Iterative()
        {
            var arr = Helper.ReadElementsInOneLine();
            var ans = MaxSubarraySum_Iterative(arr);
            Helper.WriteLine(ans);
        }
        private static int MaxSubarraySum_Iterative(int[] arr)
        {
            var n = arr.Length;
            var maxSum = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    var sum = 0;
                    for (int k = i; k <= j; k++)
                    {
                        sum += arr[k];
                    }
                    maxSum = Math.Max(sum, maxSum);
                }
            }

            return maxSum;
        }

        /// <summary>
        /// This approach creates a new array called prefix sum array, it stores sum of all preceding elements
        /// </summary>
        /// Array: 4 5 -11 11
        /// PrefSum: 4 9 -2 9 
        public static void MaxSubarraySum_PrefixSum()
        {
            var arr = Helper.ReadElementsInOneLine();
            var ans = MaxSubarraySum_PrefixSum(arr);
            Helper.WriteLine(ans);
        }
        private static int MaxSubarraySum_PrefixSum(int[] arr)
        {
            var prefSum = new int[arr.Length];
            
            // Create prefsum array
            prefSum[0] = arr[0];
            for (int i=1; i <arr.Length; i++)
            {
                prefSum[i] = arr[i] + prefSum[i - 1];
            }

            var maxSum = int.MinValue;

            for (int i=0; i<arr.Length; i++)
            {
                var currSum = prefSum[i];
                maxSum = Math.Max(currSum, maxSum);
                for (int j=0; j <= i; j++)
                {
                    currSum -= arr[j];
                    maxSum = Math.Max(currSum, maxSum);
                }
            }

            return maxSum;
        }


        /// <summary>
        /// Kadane algo works in O(n), but it only works when max sum is > 0 (can be handled by adding a check for all negative numbers)
        /// Approach
        /// 1. Iterate of each element
        /// 2. Maintain sum till now, add current element to sum
        /// 3. if sum turns negative set it to zero
        /// 4. else check if it is larger than maxsum
        /// </summary>
        /// 10 -1 10 -20
        public static void MaxSubarraySum_Kadane()
        {
            var arr = Helper.ReadElementsInOneLine();
            var ans = MaxSubarraySum_Kadane(arr);
            Helper.WriteLine(ans);
        }

        public static int MaxSubarraySum_Kadane(int[] arr)
        {
            var maxSum = int.MinValue;
            var sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];

                if (sum < 0)
                {
                    sum = 0;
                }
                maxSum = Math.Max(sum, maxSum);
            }

            return maxSum;
        }

        /// <summary>
        /// Given an array, find maximum subarray sum when going around an array can be considered
        /// </summary>
        /// Approach:
        ///     Case 1: when wrapping is not required
        ///         Array: -1 99 -1
        ///         Simply applying kadane's algo will work here
        ///     Case 2: When Wrapping is required
        ///         Array: 1 -99 1
        ///         Approach: 
        ///             1. We need to avoid mid element (or all negative elements) and take sum of all other elements
        ///             2. To achieve this, the following formula can be used
        ///                 max sum = total sum - non wrapping elements (i.e. in this case -99)
        ///             3. Apply - to all elements in array
        ///             4. find max using kadane's, (it will result in 99)
        ///                 ans = -97 - (-99)
        ///                 ans = 2
        ///    Find max of both case 1 & 2 and return 
        public static void CircularSubarraySum()
        {
            var arr = Helper.ReadElementsInOneLine();
            var ans = CircularSubarraySum(arr);
            Helper.WriteLine(ans);
        }

        private static int CircularSubarraySum(int[] arr)
        {
            var nonWrappingCaseSum = MaxSubarraySum_Kadane(arr);

            var totalSum = 0;
            foreach (var a in arr) totalSum += a;

            var negativeArr = new int[arr.Length];
            for(int i=0; i<arr.Length; i++)
            {
                negativeArr[i] = -arr[i];
            }
            var negativeSum = MaxSubarraySum_Kadane(negativeArr);

            var wrappignCaseMaxSum = totalSum - (-negativeSum);

            return Math.Max(nonWrappingCaseSum, wrappignCaseMaxSum);
        }

        /// <summary>
        /// Given an array A, and a sum S, find two elements in A whose sum is equal to S
        /// </summary>
        /// Approach 1: 
        ///     sort the array
        ///     use two pointer approach
        ///         place one pointer at start, another at end and calculate sum
        ///         if sum > desiredSum
        ///             move the end pointer back
        ///         else
        ///             move front pointer ahead
        ///         calculate sum again
        ///     Complexity: O(nlogn) - sorting complexity
        /// Approach 2:
        ///     create a hashset for each element
        ///     iterate over each element check if complement of that element exists that can result into sum
        ///     Complexity: O(n)
        public static void PairSum()
        {
            var arr = Helper.ReadElementsInOneLine();
            var sum = Helper.ReadN();
            var ans = PairSum(arr, sum);
            Helper.WriteLine(ans);
        }

        private static bool PairSum(int[] arr, int sum)
        {
            Array.Sort(arr);
            var start = 0;
            var end = arr.Length - 1;

            while (start < end)
            {
                var currSum = arr[start] + arr[end];

                if (sum == currSum) return true;
                else if (sum > currSum) start++;
                else end--;
            }

            return false;
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

