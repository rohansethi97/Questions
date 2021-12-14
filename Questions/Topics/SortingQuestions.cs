namespace Questions
{
    class SortingQuestions
    {
        /// ------------------------------------
        /// <summary>
        /// Question: Merge Sort
        /// A: 
        /// 1. take start, end and mid
        /// 2. make recursive call from start to mid and for mid to end
        /// 3. after calling merge the sorted array
        /// 
        /// </summary>
        public static void MergeSort()
        {
            var arr = Helper.ReadElementsInOneLine();
            MergeSort(arr, 0, arr.Length-1);
            Helper.WriteLine(arr);
        }

        private static void MergeSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                var mid = (start + end) / 2;

                MergeSort(arr, start, mid);
                MergeSort(arr, mid + 1, end);

                Merge(arr, start, mid, end);
            }
        }

        private static void Merge(int[] arr, int start, int mid, int end)
        {
            int[] a = new int[mid - start+1];
            int[] b = new int[end - (mid + 1)+1];

            int j = 0;
            int k = 0;

            for (int i = start; i<=mid; i++)
            {
                a[j] = arr[i];
                j++;
            }

            for (int i = mid+1; i <= end; i++)
            { 
                b[k] = arr[i];
                k++;
            }

            j = 0;
            k = 0;

            for (int i = start; i <= end; i++)
            {
                if (k >= b.Length || j < a.Length && a[j] < b[k])
                {
                    arr[i] = a[j];
                    j++;
                }
                else
                {
                    arr[i] = b[k];
                    k++;
                }
            }

        }
        // ------------------------------------


        /// ------------------------------------
        /// <summary>
        /// Question: Quick sort
        /// 1. Pick one element (any, start, mid, end)
        /// 2. Make one pass through the array to ensure all elements left to it are smaller, and right are bigger
        /// 3. Above step does not need ordering
        /// </summary>
        public static void QuickSort()
        {
            var arr = Helper.ReadElementsInOneLine();
            QuickSort(arr, 0, arr.Length-1);
            Helper.WriteLine(arr);
        }

        private static void QuickSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partition(arr, start, end);

                QuickSort(arr, start, pivot - 1);
                QuickSort(arr, pivot + 1, start);
            }
        }

        private static int Partition(int[] arr, int start, int end)
        {
            int pivot = arr[end];
            int k = start;
            for (int i = start; i < end; i++)
            {
                if (arr[i] < pivot)
                {
                    Swap(arr, k, i);
                    k++;
                }
            }
            Swap(arr, k, end);

            return k;
        }


        // ------------------------------------

        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}

// Template 

/*
 
/// ------------------------------------
/// <summary>
/// Question: 
/// </summary>
public static void Sort()
{
    var n = Helper.ReadN();
    var arr = Helper.ReadElementsInOneLine();
    var result = SumTillN(n);
    Helper.WriteLine(result);
}

private static int Sort(int[] arr, int n)
{

}
// ------------------------------------


*/