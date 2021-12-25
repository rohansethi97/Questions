using System;

namespace Questions
{
    public class BinaryTreeQuestions
    {
        /// <summary>
        /// Question: Binary tree preorder traversal
        /// </summary>
        ///         
        public static void Traversal()
        {
            /*
                1
               2  3 
             4 5  6 7

            */
            var node = new TreeNode<int>(1);
            node.Left = new TreeNode<int>(2);
            node.Right = new TreeNode<int>(3);
            node.Left.Left = new TreeNode<int>(4);
            node.Left.Right = new TreeNode<int>(5);
            node.Right.Left = new TreeNode<int>(6);
            node.Right.Right = new TreeNode<int>(7);

            PrintPreorder(node); // 1 2 4 5 3 6 7
            PrintInorder(node); // 4 2 5 1 6 3 7
            PrintPostorder(node); // 4 5 2 6 7 3 1
        }

        /*
        Properties of a binary tree
            
            1
           2 3
         4 5 6 7


        1. Nodes at level k = 2^k
        
            Above tree has 2^k at level 2, i.e. 4 nodes
            * note that levels start from 0            

        2. Nodes at height h = 2^h - 1

            Above tree has height of 2^3, i.e. 7 nodes
            * note that height start from 1

        3. For N nodes, minimum possible height or min levels are
            Log2(n+1)

        4. A binary tree with L leaves has atleast 
            log2(n+1)+1 levels
         */


        /// <summary>
        /// Question: Construct Binary tree from inorder and preorder
        /// </summary>
        /// Approach
        /// 1. traverse preorder array 1 by 1
        /// 2. find that element in inorder array, left of that element would be left sub tree, right of that element would be right sub tree
        /// 3. recursively call the function itself to pass in array and left and right subtrees
        public static void ConstructBinaryTreeFromPreorder()
        {
            var inorder = Helper.ReadElementsInOneLine();
            var preorder = Helper.ReadElementsInOneLine();
            int idx = -1;
            var tree = ConstructBinaryTreeFromPreorder(inorder, preorder, 0, inorder.Length - 1, ref idx);
            PrintInorder(tree);
        }

        /*
               1
              2 3
            4 5 6 7

            InOrder:  4 2 5 1 6 3 7
            Preorder: 1 2 4 5 3 6 7
        */
        private static TreeNode<int> ConstructBinaryTreeFromPreorder(int[] inorder, int[] preorder, int start, int end, ref int idx)
        {
            if (start > end || idx >= preorder.Length)
                return null;

            idx++;
            var node = new TreeNode<int>(preorder[idx]);
            var inorderIdx = GetIndex(inorder, preorder[idx]);

            node.Left = ConstructBinaryTreeFromPreorder(inorder, preorder, start, inorderIdx - 1, ref idx);
            node.Right = ConstructBinaryTreeFromPreorder(inorder, preorder, inorderIdx + 1, end, ref idx);

            return node;
        }

        /// <summary>
        /// Question: Construct Binary tree from inorder and postorder
        /// </summary>
        /// Approach
        /// 1. 
        public static void ConstructBinaryTreeFromPostOrder()
        {
            var inorder = Helper.ReadElementsInOneLine();
            var postorder = Helper.ReadElementsInOneLine();
            int idx = inorder.Length;
            var tree = ConstructBinaryTreeFromPostorder(inorder, postorder, 0, inorder.Length - 1, ref idx);
            PrintInorder(tree);
        }

        /*
               1
              2 3
            4 5 6 7

            Inorder:  4 2 5 1 6 3 7
            Postorder: 4 5 2 6 7 3 1
        */
        private static TreeNode<int> ConstructBinaryTreeFromPostorder(int[] inorder, int[] postorder, int start, int end, ref int idx)
        {
            if (start > end || idx <= 0)
                return null;

            idx--;
            var node = new TreeNode<int>(postorder[idx]);
            var inorderIdx = GetIndex(inorder, postorder[idx]);

            node.Right = ConstructBinaryTreeFromPostorder(inorder, postorder, inorderIdx + 1, end, ref idx);
            node.Left = ConstructBinaryTreeFromPostorder(inorder, postorder, start, inorderIdx - 1, ref idx);

            return node;
        }

        private static int GetIndex(int[] arr, int v)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (v == arr[i])
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Level order travelsal of a binary tree
        /// 
        /// 1. Use a queue 
        /// 2. Insert root node and then insert null
        /// 3. A null would signify end of a level
        /// 4. Then go through queue's top and enqueue its left and right if not null
        /// 
        /// </summary>
        public static void LevelOrderTraversal()
        {
            var inorder = new int[] { 4, 2, 5, 1, 6, 3, 7 };
            var postorder = new int[] { 4, 5, 2, 6, 7, 3, 1 };
            int idx = inorder.Length;
            var tree = ConstructBinaryTreeFromPostorder(inorder, postorder, 0, inorder.Length - 1, ref idx);
            LevelOrderTraversal(tree);

        }

        /*
               1
              2 3
            4 5 6 7
        */
        private static void LevelOrderTraversal(TreeNode<int> node)
        {
            var queue = new Queue<TreeNode<int>>();

            if (node == null)
                return;

            queue.Enqueue(node);
            queue.Enqueue(null);

            while (!queue.IsEmpty())
            {
                var val = queue.Peek();
                queue.Pop();

                if (val != null)
                {
                    Console.Write($"{val.Value} ");
                    if (val.Left != null) queue.Enqueue(val.Left);
                    if (val.Right != null) queue.Enqueue(val.Right);
                }
                else
                {
                    Console.WriteLine();
                    if (!queue.IsEmpty() && queue.Peek() != null)
                    {
                        queue.Enqueue(null);
                    }
                }
            }
        }

        /// <summary>
        /// Sum at kth level of a tree
        /// </summary>
        /// Uses level order traversal
        public static void SumAtKthLevel()
        {
            var inorder = new int[] { 4, 2, 5, 1, 6, 3, 7 };
            var postorder = new int[] { 4, 5, 2, 6, 7, 3, 1 };

            var k = Helper.ReadN();
            int idx = inorder.Length;
            var tree = ConstructBinaryTreeFromPostorder(inorder, postorder, 0, inorder.Length - 1, ref idx);
            var ins = SumAtKthLevel(tree, k);
            Console.WriteLine(ins);
        }

        /*
               1
              2 3
            4 5 6 7
        */
        private static int SumAtKthLevel(TreeNode<int> node, int level)
        {
            var queue = new Queue<TreeNode<int>>();

            if (node == null)
                return -1;

            queue.Enqueue(node);
            queue.Enqueue(null);

            int k = 0;
            var sum = 0;

            while (!queue.IsEmpty())
            {
                var val = queue.Peek();
                queue.Pop();

                if (val != null)
                {
                    if (k == level)
                    {
                        sum += val.Value;
                    }

                    if (val.Left != null) queue.Enqueue(val.Left);
                    if (val.Right != null) queue.Enqueue(val.Right);
                }
                else
                {
                    Console.WriteLine();
                    if (!queue.IsEmpty() && queue.Peek() != null)
                    {
                        queue.Enqueue(null);
                        k++;
                        if (k > level)
                        {
                            return sum;
                        }
                    }
                }
            }

            return sum;
        }

        /// <summary>
        /// count number of nodes
        /// </summary>
        public static void CountNodes()
        {
            var tree = CreateBinaryTree();
            Helper.WriteLine(CountNodes(tree));
        }

        private static int CountNodes(TreeNode<int> root)
        {
            if (root == null) return 0;
            if (root.Left == null && root.Right == null) return 1;

            var leftCount = CountNodes(root.Left);
            var rightCount = CountNodes(root.Right);

            return 1 + leftCount + rightCount;
        }

        /// <summary>
        /// Sum of nodes
        /// </summary>
        public static void SumNodes()
        {
            var tree = CreateBinaryTree();
            Helper.WriteLine(SumNodes(tree));
        }

        private static int SumNodes(TreeNode<int> root)
        {
            if (root == null) return 0;
            if (root.Left == null && root.Right == null) return root.Value;

            var leftCount = SumNodes(root.Left);
            var rightCount = SumNodes(root.Right);

            return root.Value + leftCount + rightCount;
        }

        /// <summary>
        /// Height of tree
        /// </summary>
        public static void HeightOfTree()
        {
            var tree = CreateBinaryTree();
            Helper.WriteLine(HeightOfTree(tree));
        }

        private static int HeightOfTree(TreeNode<int> root)
        {
            if (root == null) return 0;

            var leftHeight = HeightOfTree(root.Left);
            var rightHeight = HeightOfTree(root.Right);

            return 1 + (leftHeight > rightHeight ? leftHeight : rightHeight);
        }

        /// <summary>
        /// Diameter of a tree: longest chain of nodes in a tree
        /// </summary>
        /// 
        /// Examples of trees
        ///     1
        ///    2 3
        ///  4 5 6 7
        /// Diameter would be = from 4 to 1 to 7, i.e. 5 nodes
        /// 
        ///         1
        ///        2
        ///       3 5
        ///      4   6
        ///           7
        ///  Diameter would be = from 4 to 2 to 7, i.e. 6 nodes

        /// Approach:

        /// 1. Traverse all nodes, for each node calculate the following
        ///     1. Height of left and right + 1, this would be the case when current node is included in diameter
        ///     2. Diameter of left sub tree, in case current node is not included in the largest possible diameter
        ///     3. Diameter of right sub tree, in case current node is not included in the largest possible diameter

        /// 2. Take max of above 3 parameters and that would be max diameter at any given node
        public static void Diameter()
        {
            var tree = CreateBinaryTree();
            Helper.WriteLine(Diameter_ON(tree).Item1);
        }

        private static int Diameter_ON2(TreeNode<int> node)
        {
            if (node == null) return 0;

            var lh = HeightOfTree(node.Left);
            var rh = HeightOfTree(node.Right);

            var currNodeDiameter = lh + rh + 1;
            var leftDiameter = Diameter_ON2(node.Left);
            var rightDiameter = Diameter_ON2(node.Right);

            return Math.Max(currNodeDiameter, Math.Max(leftDiameter, rightDiameter));
        }

        private static (int, int) Diameter_ON(TreeNode<int> node)
        {
            if (node == null) return (0, 0);

            var leftVal = Diameter_ON(node.Left);
            var rightVal = Diameter_ON(node.Right);

            var currNodeDiameter = leftVal.Item2 + rightVal.Item2 + 1;
            var leftDiameter = leftVal.Item1;
            var rightDiameter = rightVal.Item1;

            var currHeight = (leftVal.Item2 > rightVal.Item2 ? leftVal.Item2 : rightVal.Item2) + 1;
            var currDiameter = Math.Max(currNodeDiameter, Math.Max(leftDiameter, rightDiameter));
            return (currDiameter, currHeight);
        }

        /// <summary>
        /// Add sum of existing tree values with sum of its children
        /// </summary>
        public static void SumReplacement()
        {
            var tree = CreateBinaryTree();
            PrintPreorder(tree);
            SumReplacement(tree);
            PrintPreorder(tree);
        }

        private static void SumReplacement(TreeNode<int> root)
        {
            if (root == null) return;

            SumReplacement(root.Left);
            SumReplacement(root.Right);
            if (root.Left != null) root.Value += root.Left.Value;
            if (root.Right != null) root.Value += root.Right.Value;
        }

        /// <summary>
        /// Check if binary tree is balanced or not
        ///
        /// Balanced Tree: For each node if this condition is true or not
        ///     
        /// | Height of left child - Height of Right child | <= 1
        ///     
        /// </summary>
        public static void IsBalanced()
        {
            var tree = CreateBinaryTree();
            int ht = 0;
            Helper.WriteLine(IsBalanced_Ref(tree, ref ht));
        }

        private static (bool, int) IsBalanced_tuple(TreeNode<int> root)
        {
            if (root == null) return (true, 0);

            var leftResult = IsBalanced_tuple(root.Left);
            var rightResult = IsBalanced_tuple(root.Right);

            if (leftResult.Item1 == false || rightResult.Item1 == false)
                return (false, 0);

            var leftHeight = leftResult.Item2;
            var rightHeight = rightResult.Item2;

            var isBalanced = Math.Abs(leftHeight - rightHeight) <= 1;
            var currNodeHeight = Math.Max(leftHeight, rightHeight) + 1;

            return (isBalanced, currNodeHeight);
        }

        /// <summary>
        /// Same as above but using Ref / Pointers
        /// </summary>
        private static bool IsBalanced_Ref(TreeNode<int> root, ref int height)
        {
            if (root == null) return true;

            int leftHeight = 0, rightHeight = 0;

            var leftResult = IsBalanced_Ref(root.Left, ref leftHeight);
            var rightResult = IsBalanced_Ref(root.Right, ref rightHeight);

            if (leftResult == false || rightResult == false)
                return false;

            height = Math.Max(leftHeight, rightHeight) + 1;

            var isBalanced = Math.Abs(leftHeight - rightHeight) <= 1;

            return isBalanced;
        }

        /// <summary>
        /// Print Right view of a binary tree
        /// </summary>
        /// 
        /// 1. Do level order traversal using queue, 
        /// 2. Insert all element into queue level wise, 
        /// 3. Then take last element in the right view
        public static void RightView()
        {
            var tree = CreateBinaryTree();
            RightView(tree);
        }

        public static void RightView(TreeNode<int> root)
        {
            if (root == null) return;
            var queue = new Queue<TreeNode<int>>();

            queue.Push(root);

            while (!queue.IsEmpty())
            {
                int n = queue.Size();
                for (int i = 0; i < n; i++)
                {
                    var ele = queue.Peek();
                    queue.Pop();

                    if (ele.Left != null) queue.Push(ele.Left);
                    if (ele.Right != null) queue.Push(ele.Right);
                    if (i == n - 1) Helper.WriteLine(ele.Value);
                }
            }

        }


        /// <summary>
        /// Print Left view of a binary tree
        /// </summary>
        /// 
        /// 1. Do level order traversal using queue, 
        /// 2. Insert all element into queue level wise, 
        /// 3. Then take last element in the right view
        public static void LeftView()
        {
            var tree = CreateBinaryTree();
            LeftView(tree);
        }

        public static void LeftView(TreeNode<int> root)
        {
            if (root == null) return;
            var queue = new Queue<TreeNode<int>>();

            queue.Push(root);

            while (!queue.IsEmpty())
            {
                int n = queue.Size();
                for (int i = 0; i < n; i++)
                {
                    var ele = queue.Peek();
                    queue.Pop();

                    if (ele.Left != null) queue.Push(ele.Left);
                    if (ele.Right != null) queue.Push(ele.Right);
                    if (i == 0) Helper.WriteLine(ele.Value);
                }
            }

        }

        #region Helpers

        private static TreeNode<int> CreateBinaryTree()
        {
            Helper.WriteLine("Choose 1 for auto, 0 for manual");
            var choice = Helper.ReadN();
            int[] inorder = null, postorder = null;

            switch (choice)
            {
                case 1:
                    //    1
                    //  2   3
                    // 4 5 6 7
                    inorder = new int[] { 4, 2, 5, 1, 6, 3, 7 };
                    postorder = new int[] { 4, 5, 2, 6, 7, 3, 1 };
                    break;
                case 2:
                    ///         1
                    ///        2
                    ///       3 5
                    ///      4   6
                    ///           7
                    inorder = new int[] { 4, 3, 2, 5, 6, 7, 1 };
                    postorder = new int[] { 4, 3, 7, 6, 5, 2, 1 };
                    break;
                default:
                    inorder = Helper.ReadElementsInOneLine();
                    postorder = Helper.ReadElementsInOneLine();
                    break;
            }

            int idx = inorder.Length;
            return ConstructBinaryTreeFromPostorder(inorder, postorder, 0, inorder.Length - 1, ref idx);
        }

        private static void PrintPreorder(TreeNode<int> node)
        {
            Console.Write("Preorder: ");
            Preorder(node);
            Console.WriteLine();
        }
        private static void Preorder(TreeNode<int> node)
        {
            if (node == null) return;

            Console.Write(node.Value + " ");
            Preorder(node.Left);
            Preorder(node.Right);
        }

        private static void PrintInorder(TreeNode<int> node)
        {
            Console.Write("Inorder: ");
            Inorder(node);
            Console.WriteLine();
        }
        private static void Inorder(TreeNode<int> node)
        {
            if (node == null) return;

            Inorder(node.Left);
            Console.Write(node.Value + " ");
            Inorder(node.Right);
        }

        private static void PrintPostorder(TreeNode<int> node)
        {
            Console.Write("Postorder: ");
            Postorder(node);
            Console.WriteLine();
        }
        private static void Postorder(TreeNode<int> node)
        {
            if (node == null) return;

            Postorder(node.Left);
            Postorder(node.Right);
            Console.Write(node.Value + " ");
        }

        #endregion

    }
}

/*
 
/// ------------------------------------
        /// <summary>
        /// Question: Binary tree
        /// </summary>
        public static void BinaryTree()
        {
            var arr = Helper.ReadElementsInOneLine();
            BinaryTree(arr);
            PrintNodes(head);
        }

        private static TreeNode<int> BinaryTree(int[] node)
        {

        }
// ------------------------------------


*/