using System.Collections.Generic;

namespace Questions
{
    public class SearchingQuestions
    {
        /// <summary>
        /// Linear Search
        /// Complexity: O(n)
        /// </summary>
        public static void LinearSearch()
        {
            var arr = Helper.ReadElementsInOneLine();
            var ele = Helper.ReadN();

            var ans = LinearSearch(arr, ele);
            Helper.WriteLine(ans);
        }

        private static int LinearSearch(int[] arr, int ele)
        {
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] == ele)
                    return i;

            return -1;
        }

        /// <summary>
        /// Binary Search
        /// Complexity O(Logn)
        /// </summary>
        public static void BinarySearch()
        {
            var arr = Helper.ReadElementsInOneLine();
            var ele = Helper.ReadN();

            var ans = BinarySearch(arr, ele);
            Helper.WriteLine(ans);
        }

        // 0 1 2 3 4 5 6 7
        private static int BinarySearch(int[] arr, int ele)
        {
            var start = 0;
            var end = arr.Length - 1;
            var mid = (start + end) / 2;

            while (start <= end)
            {
                if (arr[mid] == ele) return mid;
                else if (arr[mid] < ele) start = mid + 1;
                else end = mid - 1;

                mid = (start + end) / 2;
            }

            return -1;
        }

    }
}


/*
        /// <summary>
        /// Search
        /// </summary>
        public static void Search()
        {
            var arr = Helper.ReadElementsInOneLine();
            var n = arr.Length;

            var ans = Search(arr);
            Helper.WriteLine(ans);
        }

        private static int Search(int[] arr)
        {
            return 1;
        }
 */

