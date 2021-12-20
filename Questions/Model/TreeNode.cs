namespace Questions
{
    public class TreeNode<T>
    {
        public TreeNode<T> Left;
        public TreeNode<T> Right;
        public T Value;

        public TreeNode(T val)
        {
            this.Value = val;
        }
    }
}
