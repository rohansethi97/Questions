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
        public static void ConstructBinaryTreeFromPreorder()
        {
            var inorder = Helper.ReadElementsInOneLine();
            var preorder = Helper.ReadElementsInOneLine();
            var tree = ConstructBinaryTreeFromPreorder(inorder, preorder);
            PrintPreorder(tree);
        }

        private static TreeNode<int> ConstructBinaryTreeFromPreorder(int[] inorder, int[] preorder)
        {
            /*
                   1
                  2 3
                4 5 6 7

                InOrder:  4 2 5 1 6 3 7
                Preorder: 1 2 4 5 3 6 7
            */

            return null;
        
        }

        #region Helpers

        private static TreeNode<int> CreateBinaryTree(int n, ref int current)
        {
            if (current > n)
                return null;
            
            var node = new TreeNode<int>(current);
            current++;
            node.Left = CreateBinaryTree(n, ref current);
            current++;
            node.Right = CreateBinaryTree(n, ref current);

            return node;
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