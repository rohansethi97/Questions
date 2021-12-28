using System;

namespace Questions
{
    public class BinarySearchTreeQuestions
    {
        /*
         Binary search trees are useful for fast lookup, insertion and deletion
         complexity  of each of these operations O(logn)
         
         Rules of binary search trees
         1. All keys on left should be smaller than the node
         2. All keys on right side should be larger than the node
         3. Above 2 properties shoud apply to all nodes, (there should be no duplicate nodes)

         Example:
                 3
              2     7
            1     5   8
                 4 6

         ** Inorder of BST is always in increasing order
         */

        /// <summary>
        /// Convert an array to BST, this is not balanced bst
        /// </summary>
        public static void InsertIntoBST()
        {
            var arr = Helper.ReadElementsInOneLine();
            TreeNode<int> root = null;
            foreach (int i in arr)
                root = InsertIntoBST(root, i);
            
            PrintInorder(root);
        }

        /// Approach
        /// Notice how root is returned at the end 
        /// It is to ensure that same node which was passed into this method is returned until null is reached
        private static TreeNode<int> InsertIntoBST(TreeNode<int> root, int val)
        {
            if(root is null)
            {
                return new TreeNode<int>(val);
            }

            if (val < root.Value)
            {
                root.Left = InsertIntoBST(root.Left, val);
            }
            else
            {
                root.Right = InsertIntoBST(root.Right, val);
            }

            return root;
        }

        /// <summary>
        /// Search an element in BST
        /// </summary>
        public static void SearchInBST()
        {
            var tree = CreateBST();
            var key = Helper.ReadN();
            var isPresent = SearchInBST(tree, key);

            Helper.WriteLine(isPresent);
        }

        private static bool SearchInBST(TreeNode<int> root, int key)
        {
            if (root == null) return false;
            if (root.Value == key) return true;

            if (root.Value > key)
            {
                return SearchInBST(root.Left, key);
            }
            else
            {
                return SearchInBST(root.Right, key);
            }
        }

        /// <summary>
        /// Search an element in BST
        /// </summary>
        public static void DeleteFromBST()
        {
            var tree = CreateBST();
            PrintInorder(tree);
            var key = Helper.ReadN();
            DeleteFromBST(tree, key);
            PrintInorder(tree);
        }

        /*
                    5
                3      7
              2   4  6   8
         */
        private static bool DeleteFromBST(TreeNode<int> root, int key)
        {
            if (root == null) return false;
            if (root.Value == key) return true;

            if (root.Value > key)
            {
                return DeleteFromBST(root.Left, key);
            }
            else
            {
                return DeleteFromBST(root.Right, key);
            }
        }


        #region Helpers

        private static TreeNode<int> CreateBST()
        {
            var arr = Helper.ReadElementsInOneLine();
            TreeNode<int> root = null;
            foreach (int i in arr)
                root = InsertIntoBST(root, i);
            return root;
        }

        private static void PrintPreorder(TreeNode<int> node)
        {
            BinaryTreeQuestions.PrintPreorder(node);
        }
        private static void PrintInorder(TreeNode<int> node)
        {
            BinaryTreeQuestions.PrintInorder(node);
        }
        private static void PrintPostorder(TreeNode<int> node)
        {
            BinaryTreeQuestions.PrintPostorder(node);
        }

        #endregion

    }
}

/*
 
/// ------------------------------------
        /// <summary>
        /// Question: Binary Search tree
        /// </summary>
        public static void BinarySearchTree()
        {
            var arr = Helper.ReadElementsInOneLine();
            BinaryTree(arr);
            PrintNodes(head);
        }

        private static void BinarySearchTree(TreeNode<int> root)
        {

        }
// ------------------------------------


*/