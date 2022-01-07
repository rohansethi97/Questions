namespace Questions
{
    public class SearchingQuestions
    {
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

        internal static void LinearSearch()
        {
            throw new System.NotImplementedException();
        }

        internal static void BinarySearch()
        {
            throw new System.NotImplementedException();
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

