namespace Questions
{
    public class Stack<T>
    {
        public LinkedList<T> List;

        public Stack()
        {
            List = new LinkedList<T>();
        }

        public void Push(T n)
        {
            List.AddToHead(n);
        }

        public void Pop()
        {
            List.DeleteFromHead();
        }

        public T Top()
        {
            return List.GetNthValue(0);
        }

        public bool IsEmpty()
        {
            return List.IsEmpty();
        }

        public int Size()
        {
            return List.GetLength();
        }
    }
}
