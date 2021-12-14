namespace Questions
{
    public class Node<T>
    {
        public Node<T> Next;
        public T Value;

        public Node(T value)
        {
            this.Value = value;
        }
    }
}
