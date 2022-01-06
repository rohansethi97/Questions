using System;

namespace Questions
{
    public class HeapsQuestions
    {
        /*
         * Binary Heaps
         * Conditions: 1. Heap should be complete binary tree
         *  i.e. no missing elements when represented in an array
         *  
         *  Formula for array representation
         *  Node at index = i
         *  
         *  1 Based Indexing
         *      Left child will be at = 2*i
         *      Right child will be at = 2*i + 1
         *      Parent = i/2
         *  0 Based Indexing
         *      Left child = 2*i+1
         *      Right child = 2*i+2
         *      Parent = (i-1)/2
         * 
         * Condition 2: A element should be greater than all its descendants 
         * (for max heap, and vice versa for min heap)
         * 
         * Condition 3: max height should be log2(n)
         * 
         * Implementation: 
         *  Array can be used for implementation, but diagramattically it can be represented by a tree, 
         *  the children and parent nodes can be defined using above given formulas
         *  
         *  It can be done in place, no need to create new arrays
         */


        /// <summary>
        /// Insert elements into heap
        /// </summary>
        /// Approach: 
        /// 1. Maintain a pointer to the last element of the heap, n
        /// 2. Insert new element at n + 1
        ///         or existing array can be converted to heap by moving one by one from 2nd element onwards
        /// 3. Using formulas above, swap n+1 with parent till it is smaller than parent
        public static void InsertIntoHeap()
        {
            var arr = Helper.ReadElementsInOneLine();

            for (int i = 1; i < arr.Length; i++)
            {
                InsertIntoHeap(arr, i);
                Helper.WriteLine(arr);
            }
        }

        // 0  1  2  3  4  5
        // 50 40 30 20 10 60
        private static void InsertIntoHeap(int[] arr, int lastElement)
        {
            int currElement = arr[lastElement];
            int i = lastElement;
            
            while (i > 0 && arr[(i - 1) / 2] < currElement)
            {
                arr[i] = arr[(i - 1) / 2];
                i = (i - 1) / 2;
            }

            arr[i] = currElement;
        }
        
        
        /// <summary>
        /// Delete element from a heap
        /// </summary>
        /// Deletion from a heap can only happen from top or root element
        /// Approach: 
        ///     1. Move last element to root, ignore first element
        ///     2. Compare it with both children
        ///     3. If it is smaller than either, then swap
        ///     4. Repeat till condition is true
        public static void DeleteFromHeap()
        {
            var heap = CreateHeap(5);
            //var heap = new int[] { 60, 30, 40, 20, 10, 15, 5 };
            Helper.WriteLine(heap);
            for (int i = heap.Length-1; i >= 0; i--)
            {
                DeleteFromHeap(heap, i);
                Helper.WriteLine(heap);
            }
        }

        // 0  1  2  3  4  5  6
        // 60 30 40 20 10 15 5
        /*
                60
             30    40
           20 10  15 5
         
         */
        private static void DeleteFromHeap(int[] arr, int n, bool keepLast = false)
        {
            if (n < 0) return;
            var first = arr[0];
            arr[0] = arr[n];
            arr[n] = keepLast ? first : -1;

            int i = 0;
            int next = 2 * i + 1;

            while (next < n)
            {
                if (next+1 < n && arr[next] < arr[next+1])
                {
                    next++;
                }

                if (next < n && arr[i] < arr[next])
                {
                    Swap(arr, i, next);
                    i = next;
                    next = 2 * i + 1;
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Implement Heap sort
        /// </summary>
        /// Can be achieved by simply inserting converting array to heap then removing elements
        /// Complexity: O(nlogn)
        public static void HeapSort()
        {
            var heap = Helper.ReadElementsInOneLine();
            Helper.WriteLine(heap);

            for (int i = 1; i < heap.Length; i++)
            {
                InsertIntoHeap(heap, i);
            }
            Helper.WriteLine(heap);

            for (int i = heap.Length - 1; i >= 0; i--)
            {
                DeleteFromHeap(heap, i, true);
            }

            Helper.WriteLine(heap);
        }

        /// <summary>
        /// Convert an array to heap using heapify
        /// </summary>
        /// Approach
        /// 1. Start from right to left
        /// 2. Ignore all child nodes, go one by one till i == 0
        /// 3. Compare each node with its children nodes
        /// 4. If element is smaller than either of children, then swap till it is at its correct position
        /// 
        /// 
        /// 1 2 3 4 5 6 7 
        /// 
        public static void Heapify()
        {
            var arr = Helper.ReadElementsInOneLine();
            Helper.WriteLine(arr);
            Heapify(arr);
            Helper.WriteLine(arr);

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                DeleteFromHeap(arr, i, true);
            }
            Helper.WriteLine(arr);
        }

        private static void Heapify(int[] arr)
        {
            var n = arr.Length - 1;
            for (int i = n; i >= 0; i--)
            {
                var curr = i;
                var next = curr * 2 + 1;
                if (next > n) continue;

                while (true)
                {
                    if (next+1 <= n && arr[next] < arr[next+1])
                    {
                        next = next + 1;
                    }
                    
                    if (next <= n && arr[curr] < arr[next])
                    {
                        Swap(arr, curr, next);
                        curr = next;
                        next = curr * 2 + 1;
                    }
                    else
                    {
                        break;
                    }

                    Helper.WriteLine(arr);
                }

            }
        }


        /// <summary>
        /// An array of unsorted elements will be provided one by one, give median of as each element is added
        /// </summary>
        /// Approach
        /// General: 
        /// 1. Maintain min heap (aka priority queue) and max heap , difference between them should be <= 1
        /// 2. first set of elements should be in max heap, second set should be in min heap
        /// 
        /// 1. Inserting
        ///     1. if heap is empty or top is greater than current, insert into max
        ///     2. else insert into min
        /// 3. Balance: Check if heaps need rebalancing (#1 above), if yes then rebalance
        /// 4. Calculate median, 
        ///     1. if sizes of both heaps are equal, average of top of both heaps
        ///     2. if size is not equal, then top of larger queue
        public static void MedianOfRunningStream()
        {
            var arr = Helper.ReadElementsInOneLine();
            MedianOfRunningStream(arr);
        }

        // 10 20 30 40 50
        private static void MedianOfRunningStream(int[] arr)
        {
            var minHeap = new Heap(arr.Length, false);
            var maxHeap = new Heap(arr.Length);

            for (int i = 0; i < arr.Length; i++)
            {
                var curr = arr[i];

                // Insert into heap
                if (maxHeap.Count() ==0 || maxHeap.Peek() > curr)
                {
                    maxHeap.Insert(arr[i]);
                }
                else
                {
                    minHeap.Insert(arr[i]);
                }

                // Balance heap
                if (maxHeap.Count() > minHeap.Count() + 1)
                {
                    minHeap.Insert(maxHeap.Delete());
                }
                else if (minHeap.Count() > maxHeap.Count() + 1)
                {
                    maxHeap.Insert(minHeap.Delete());
                }

                // Calculate median
                if (minHeap.Count() == maxHeap.Count())
                {
                    var min = minHeap.Peek();
                    var max = maxHeap.Peek();

                    Console.WriteLine((float)(min + max) / 2.0);
                }
                else
                {
                    Console.WriteLine(minHeap.Count() > maxHeap.Count() ?  minHeap.Peek(): maxHeap.Peek());
                }
            }
        }

        /// <summary>
        /// Given K sorted arrays with varying lengths, merge them into one single array
        /// </summary>
        /// Approach 1: 
        ///     1. Maintain index pointer to each of the array, 
        ///     2. get the smallest element among all arrays
        ///     3. Increase pointer of that specific array
        ///     Complexity: O(KN)
        ///     
        /// Approach 2: Instead of comparing manually, use min heap to get smallest of current set of elements
        ///     Complexity O(NLogK)
        public static void MergeKSortedArrays()
        {
            var arrayCount = Helper.ReadN();
            var arrayList = new int[arrayCount][];
            for (int i = 0; i < arrayCount; i++)
            {
                var arr = Helper.ReadElementsInOneLine();
                arrayList[i] = arr;
            }

            var array = MergeKSortedArrays(arrayList);

            Helper.WriteLine(array);
        }

        private static int[] MergeKSortedArrays(int[][] arrayList)
        {
            var totalSize = 0;
            int k = arrayList.Length;
            for (int i = 0; i < k; i++) totalSize += arrayList[i].Length;

            var combinedArr = new int[totalSize];

            var heap = new Heap_Pair(k, false);

            var indices = new int[k];

            var counter = 0;
            for (int i = 0; i < k; i++)
            {
                if (indices[i] < arrayList[i].Length)
                {
                    var num = arrayList[i][indices[i]];
                    heap.Insert((num, i));
                }
            }

            while (counter < totalSize)
            {
                var minEle = heap.Delete();
                combinedArr[counter] = minEle.Item1;

                var i = minEle.Item2;
                indices[i]++;               

                if (indices[i] < arrayList[i].Length)
                {
                    var num = arrayList[i][indices[i]];
                    heap.Insert((num, i));

                    indices[i]++;
                }

                counter++;

            }


            return combinedArr;
        }

        /// <summary>
        /// Get count of elements in smallest subsequence with sum atleast k
        /// </summary>
        /// 1 2 3 4 5
        public static void SmallestSequenceWithSumAtleastK()
        {
            var arr = Helper.ReadElementsInOneLine();
            var target = Helper.ReadN();

            Heapify(arr);

            var sum = 0;
            int count = 0;

            var i = arr.Length - 1;
            while (sum < target && i >= 0)
            {
                sum += arr[0];
                count++;
                DeleteFromHeap(arr, i, false);
            }

            Helper.WriteLine(count);
            

        }

        #region Helper
        private static int[] CreateHeap(int n = 6)
        {
            var arr = new int[n];
            for(int i = 0; i < n; i++)
            {
                arr[i] = i;
                InsertIntoHeap(arr, i);
            }

            return arr;
        }
        private static void Swap(int[] arr, int j, int k)
        {
            int temp = arr[j];
            arr[j] = arr[k];
            arr[k] = temp;
        }

        



        #endregion
    }
}
