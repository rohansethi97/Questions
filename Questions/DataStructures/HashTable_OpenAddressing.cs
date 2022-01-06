namespace Questions
{
    public class HashTable_OpenAddressing
    {
        Node<int>[] hashTable;
        int size;

        public HashTable_OpenAddressing(int datasetSize)
        {
            this.size = GetIdealTableSize(datasetSize);
            this.hashTable = new Node<int>[this.size];
        }

        public bool Insert(int n)
        {
            var index = HashFunction(n);
            var newNode = new Node<int>(n);
            var list = hashTable[index];
            
            if (list == null || list.Value > n)
            {
                hashTable[index] = newNode;
                newNode.Next = list;
                return true;
            }

            while (list.Next != null && list.Next.Value <= n)
            {
               if (list.Next.Value == n) return false;

               list = list.Next;
            }

            newNode.Next = list.Next;
            list.Next = newNode;

            return false;
        }

        public bool Search(int n)
        {
            var index = HashFunction(n);
            var list = hashTable[index];

            while (list != null && list.Value <= n)
            {
                if (list.Value == n) return true;
                list = list.Next;
            }

            return false;
        }

        public bool Delete(int n)
        {
            var index = HashFunction(n);
            var list = hashTable[index];

            if (list != null && list.Value == n)
            {
                hashTable[index] = list.Next;
                return true;
            }

            Node<int> prev = null;
            while (list != null && list.Value <= n)
            {
                if (list.Value == n)
                {
                    prev.Next = list.Next;
                    return true;
                }
                
                prev = list;
                list = list.Next;
            }

            return false;
        }

        public int HashFunction(int n)
        {
            return n % size;
        }

        private static int GetIdealTableSize(int datasetSize)
        {
            var minSize = 10;
            var ideal = datasetSize / 10;
            return ideal < minSize ? minSize : ideal;
        }

    }
}
