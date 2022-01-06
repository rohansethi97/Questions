using System;

namespace Questions
{
    public class HashTable_ClosedAddressing
    {
        int?[] hashTable;
        int size;
        ProbingType probingType;

        public HashTable_ClosedAddressing(int datasetSize, ProbingType type = ProbingType.Linear)
        {
            this.size = GetIdealTableSize(datasetSize);
            this.hashTable = new int?[this.size];
            this.probingType = type;
        }

        public bool Search(int n)
        {
            int i = 0;
            while (i < size)
            {
                var index = HashFunction(n, i++);
                if (hashTable[index] == null) return false;
                if (hashTable[index] == n) return true;
            }

            return false;
        }

        public bool Insert(int n)
        {
            int i = 0;
            while (i < size)
            {
                var index = HashFunction(n, i++);

                if (hashTable[index] == null)
                {
                    hashTable[index] = n;
                    return true;
                };

                if (hashTable[index] == n) return true;
            }

            return false;
        }


        public bool Delete(int n)
        {
            int i = 0;
            while (i < size)
            {
                var index = HashFunction(n, i++);
                if (hashTable[index] == null) return false;
                if (hashTable[index] == n)
                {
                    hashTable[index] = null;
                    break;
                };
            }

            Rehash();
            return true;
        }

        private void Rehash()
        {
            var oldTable = this.hashTable;
            this.hashTable = new int?[this.size];

            foreach (int? i in oldTable)
            {
                if (i != null) Insert((int)i);
            }
        }

        public int HashFunction(int n, int i = 0)
        {
            switch (this.probingType)
            {
                case ProbingType.Linear:
                    return HashFunction_Linear(n, i);
                case ProbingType.Quadratic:
                    return HashFunction_Quadratic(n, i);
                default:
                    return HashFunction_Linear(n, i);
            }

        }

        public int HashFunction_Linear(int n, int i)
        {
            return ((n % size) + i) % size;
        }

        public int HashFunction_Quadratic(int n, int i)
        {
            return ((n % size) + (int)Math.Pow(i, 2)) % size;
        }

        private static int GetIdealTableSize(int datasetSize)
        {
            // ideally load factor should be <= 0.5 for closed addressing
            var minSize = 10;
            // this should be closest(larger) prime number
            var ideal = datasetSize * 2;
            return ideal < minSize ? minSize : ideal;
        }
    }

    public enum ProbingType
    {
        Linear,
        Quadratic
    }
}
