namespace Questions
{
    public class Heap
    {
        int[] arr;
        int lastIndex;
        bool isMaxHeap;

        public Heap(int size = 500, bool isMaxHeap = true)
        {
            arr = new int[size];
            lastIndex = -1;
            this.isMaxHeap = isMaxHeap;
        }

        public void Insert(int n)
        {
            lastIndex++;
            
            var currIdx = lastIndex;
            var parentIdx = (lastIndex - 1) / 2;
            while (currIdx > 0)
            {
                if (
                    (isMaxHeap && arr[parentIdx] < n) ||
                    (!isMaxHeap && arr[parentIdx] > n)
                    )
                {
                    Swap(arr, currIdx, parentIdx);
                    currIdx = parentIdx;
                    parentIdx = (currIdx - 1) / 2;
                }
                else
                {
                    break;
                }
            }

            arr[currIdx] = n;
        }

        public int Delete()
        {
            if (lastIndex < 0) return -1;

            var top = arr[0];
            arr[0] = arr[lastIndex];
            lastIndex--;

            int currIdx = 0;
            int nextIdx = currIdx * 2 + 1;
            while (nextIdx <= lastIndex)
            {
                if (
                    nextIdx+1 <= lastIndex && 
                    (
                        isMaxHeap && arr[nextIdx] < arr[nextIdx+1]
                        || !isMaxHeap && (arr[nextIdx] > arr[nextIdx + 1])
                    )
                )
                {
                    nextIdx = nextIdx + 1;
                }

                if (
                    nextIdx <= lastIndex &&
                    (
                        isMaxHeap && arr[currIdx] < arr[nextIdx]
                        || !isMaxHeap && arr[currIdx] > arr[nextIdx]
                    )
                )
                {
                    Swap(arr, currIdx, nextIdx);
                    currIdx = nextIdx;
                    nextIdx = currIdx * 2 + 1;
                }
                else
                {
                    break;
                }
            }

            return top;
        }

        public int Count()
        {
            return lastIndex + 1;
        }

        public void Print()
        {
            Helper.WriteLine(arr);
        }

        public int Peek()
        {
            if (lastIndex < 0) return -1;
            return arr[0];
        }

        private void Swap(int[] arr, int j, int k)
        {
            int temp = arr[j];
            arr[j] = arr[k];
            arr[k] = temp;
        }
    }
}
