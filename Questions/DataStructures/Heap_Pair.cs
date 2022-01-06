namespace Questions
{
    // TODO: Implement a generic heap
    public class Heap_Pair
    {
        (int,int)[] arr;
        int lastIndex;
        bool isMaxHeap;

        // TODO: Implement a generic heap
        public Heap_Pair(int size = 500, bool isMaxHeap = true)
        {
            arr = new (int,int)[size];
            lastIndex = -1;
            this.isMaxHeap = isMaxHeap;
        }

        public void Insert((int,int) n)
        {
            lastIndex++;
            
            var currIdx = lastIndex;
            var parentIdx = (lastIndex - 1) / 2;
            while (currIdx > 0)
            {
                if (
                    (isMaxHeap && arr[parentIdx].Item1 < n.Item1) ||
                    (!isMaxHeap && arr[parentIdx].Item1 > n.Item1)
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

        public (int, int) Delete()
        {
            if (lastIndex < 0) return (-1, -1);
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
                        isMaxHeap && arr[nextIdx].Item1 < arr[nextIdx+1].Item1
                        || !isMaxHeap && (arr[nextIdx].Item1 > arr[nextIdx + 1].Item1)
                    )
                )
                {
                    nextIdx = nextIdx + 1;
                }

                if (
                    nextIdx <= lastIndex &&
                    (
                        isMaxHeap && arr[currIdx].Item1 < arr[nextIdx].Item1
                        || !isMaxHeap && arr[currIdx].Item1 > arr[nextIdx].Item1
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

        public (int, int) Peek()
        {
            if (lastIndex < 0) return (-1,-1);
            return arr[0];
        }

        private void Swap((int,int)[] arr, int j, int k)
        {
            var temp = arr[j];
            arr[j] = arr[k];
            arr[k] = temp;
        }
    }
}
