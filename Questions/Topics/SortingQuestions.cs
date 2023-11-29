namespace Questions
{
    class SortingQuestions
    {
        /// <summary>
        /// Bubble sort
        /// Repeatedly swap two adjacent elements if they are in wrong order
        /// Complexity: O(n^2)
        /// </summary>
        /* 
         I1: [ 4 3 2 1 5 ]
         I2: [ 3 2 1 4 5 ]
         I3: [ 2 1 3 4 5 ]
         I4: [ 1 2 3 4 5 ]
         I5: [ 1 2 3 4 5 ]
        */
        public static void BubbleSort()
        {
            var arr = Helper.ReadElementsInOneLine();
            BubbleSort(arr);
        }

        // 5 4 3 2 1
        private static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n-1; i++)
            {
                for (int j = 1; j < n - i; j++)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        Swap(arr, j - 1, j);
                    }
                }
                Helper.WriteLine(arr);
            }
        }

        /// <summary>
        /// Selection sort
        /// Find the minimum element in the array and swap it with element at beginning
        /// </summary>
        /*
         I1: [ 0 5 4 3 2 1 ]
         I2: [ 0 1 5 4 3 2 ]
         I3: [ 0 1 2 5 4 3 ]
         I4: [ 0 1 2 3 5 4 ]
         I5: [ 0 1 2 3 4 5 ]
        */
        public static void SelectionSort()
        {
            var arr = Helper.ReadElementsInOneLine();
            SelectionSort(arr);
        }

        private static void SelectionSort(int[] arr)
        {
            int n = arr.Length; 
            for (int i = 0; i < n-1; i++)
            {
                for (int j = i+1; j < n; j++)
                {
                    if (arr[j] < arr[i])
                    {
                        Swap(arr, i, j);
                    }
                }
                Helper.WriteLine(arr);
            }
        }

        /// <summary>
        /// Insertion sort
        /// Insert an element from unsorted array to its correct position in array
        /// (start from i=i, go till n-1)
        /// Complexity: O(n^2)
        /// </summary>
        /// 3 5 4 1 2
        public static void InsertionSort()
        {
            var arr = Helper.ReadElementsInOneLine();
            InsertionSort(arr);
        }

        private static void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                var temp = arr[i];

                if (temp < arr[i - 1])
                {
                    var j = i;
                    while (j >= 1 && arr[j - 1] > temp)
                    {
                        arr[j] = arr[j-1];
                        j--;
                    }
                    arr[j] = temp;
                }

                Helper.WriteLine(arr);
            }
        }

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
            MergeSort(arr, 0, arr.Length - 1);
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
            int[] a = new int[mid - start + 1];
            int[] b = new int[end - (mid + 1) + 1];

            int j = 0;
            int k = 0;

            for (int i = start; i <= mid; i++)
            {
                a[j] = arr[i];
                j++;
            }

            for (int i = mid + 1; i <= end; i++)
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
            QuickSort(arr, 0, arr.Length - 1);
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


        // 5 4 2 1 3
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