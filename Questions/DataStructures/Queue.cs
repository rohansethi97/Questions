namespace Questions
{
    public class Queue<T>
    {
        public LinkedList<T> Head;

        public Queue()
        {
            Head = new LinkedList<T>();
        }

        public void Enqueue(T val)
        {
            Head.AddToTail(val);
            // Can be implemented in O(1) instead of O(n) by using a tail pointer
        }

        public T Peek()
        {
            return Head.GetNthValue(0);
        }

        public bool IsEmpty()
        {
            return Head.IsEmpty();
        }

        public void Deque()
        {
            if (this.IsEmpty())
            {
                Helper.WriteLine("Queue is empty");
                return;
            }
            Head.DeleteFromHead();
        }

        public int Size()
        {
            // TODO: Implement O(1) instead of O(n)
            return this.Head.GetLength();
        }

        public void Push(T val)
        {
            this.Enqueue(val);
        }

        public void Pop()
        {
            this.Deque();
        }

        public T Top()
        {
            return this.Peek();
        }
    }
}
