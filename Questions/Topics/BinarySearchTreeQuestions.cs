using System;

namespace Questions
{
    public class BinarySearchTreeQuestions
    {
        /*
         Binary search trees are useful for fast lookup, insertion and deletion
         complexity  of each of these operations O(logn)
         
         Rules of binary search trees
         1. All keys on left (whole subtree) should be smaller than the node
         2. All keys on right (whole subtree) side should be larger than the node
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
            if (root is null)
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
        /// Delete an element in BST
        /// </summary>
        /// This will have 3 cases
        /// 1. Recursively traverse BST, 
        /// 2. The method signature will return tree node
        /// 3. with each call, we will update the value of left or right node based on value, 
        /// 4. if right or left node is not the node to be deleted, simply return the node
        /// 5. if node.val == key, there would be three cases
        ///     Case 1: When node is leaf node
        ///         return null
        ///     Case 2: When node has only 1 child, 
        ///         return that child
        ///     case 3: When both children are present,
        ///         Find the inorder successor
        ///         put successor's value in place of current node
        ///         recursively call function to delete the inorder successor node
        ///     
        ///        
        public static void DeleteFromBST()
        {
            var tree = CreateBST();
            PrintInorder(tree);
            var key = Helper.ReadN();
            tree = DeleteFromBST(tree, key);
            PrintInorder(tree);
        }

        /*
                    5
                3      7
              2   4  6   8


                    5
                3      8
                     6   10
                        9   11 
         */
        private static TreeNode<int> DeleteFromBST(TreeNode<int> root, int key)
        {
            if (root == null) return null;

            if (root.Value == key)
            {
                // In case of leaf nodes
                if (root.Left == null && root.Right == null) return null;

                // In case of one child
                else if (root.Left == null || root.Right == null)
                {
                    return root.Left != null ? root.Left : root.Right;
                }
                // In case of both children
                else
                {
                    var temp = InorderSuccessor(root.Right);
                    root.Value = temp.Value;
                    root.Right = DeleteFromBST(root.Right, temp.Value);
                }

            }
            else if (root.Value > key)
            {
                root.Left = DeleteFromBST(root.Left, key);
            }
            else
            {
                root.Right = DeleteFromBST(root.Right, key);
            }

            return root;
        }

        private static TreeNode<int> InorderSuccessor(TreeNode<int> root)
        {
            while (root.Left != null)
            {
                root = root.Left;
            }

            return root;
        }

        /// <summary>
        /// Construct a BST from just Preoder
        /// </summary>
        // We can build BST from just the preorder using same technique used 
        // in binary tree in which we constructed BT from preorder and inorder
        // since inorder is always going to be sorted order, 
        // we can build just using preoder
        // Input: 4 2 1 3 6 5 7
        // Output: 
        //         4
        //      2     6
        //   1   3   5  7
        // Approach
        // Maintain following variables
        //     current, min, max
        // if current < min and current > min,
        //     Insert node at current
        // else return
        public static void BSTFromPreOrder()
        {
            var arr = Helper.ReadElementsInOneLine();
            var idx = 0;
            var root = BSTFromPreOrder(arr, ref idx);
            PrintInorder(root);
        }

        private static TreeNode<int> BSTFromPreOrder(int[] arr, ref int idx, int min = int.MinValue, int max = int.MaxValue)
        {
            var len = arr.Length;
            if (idx >= len) return null;
            
            var value = arr[idx];
            if (value < min || value > max) return null;

            idx++;
            var node = new TreeNode<int>(value);

            if (idx < len) node.Left = BSTFromPreOrder(arr, ref idx, min, value);
            if (idx < len) node.Right = BSTFromPreOrder(arr, ref idx, value, max);

            return node;
        }

        /// <summary>
        /// Check if current tree is a BST 
        /// </summary>
        /// Approach
        /// 1. We need to ensure all elements left of the tree (whole left sub tree) are smaller
        /// 2. vice versa for right of tree
        /// 3. We can do this in O(n) if we maintain max and min limit variables
        //         4
        //      2     6
        //   1   3   5  7
        public static void IsBST()
        {
            var arr = Helper.ReadElementsInOneLine();
            int i = 0;
            var tree = BSTFromPreOrder(arr, ref i);
            PrintInorder(tree);

            Helper.WriteLine(IsBST(tree));
        }

        private static bool IsBST(TreeNode<int> root, int min = int.MinValue, int max = int.MaxValue)
        {
            if (root == null) return true;

            var isCurrentValid = root.Value < min && root.Value > max;
            var isLeftSubtreeValid = IsBST(root.Left, min, root.Value);
            var isRightSubtreeValid = IsBST(root.Right, root.Value, max);

            return isCurrentValid && isLeftSubtreeValid && isRightSubtreeValid;
        }

        /// <summary>
        /// Create a balanced BST from Sorted Array
        /// </summary>
        /* Input {1 2 3 4 5 6 7}
         * Output: 
         *              4
         *           2     6
         *         1  3   5  7
         *  
         * Input {1 2 3 4 5 6}
         * Output: 
         *              3
         *           1    5
         *            2  4  6
        */
        public static void BalancedBSTFromSortedArray()
        {
            var arr = Helper.ReadElementsInOneLine();
            var tree = BalancedBSTFromSortedArray(arr, 0, arr.Length-1);
            PrintInorder(tree);
            PrintPreorder(tree);
        }

        private static TreeNode<int> BalancedBSTFromSortedArray(int[] arr, int min, int max)
        {
            if (min > max) return null;

            var mid = (min + max) / 2;
            var node = new TreeNode<int>(arr[mid]);

            node.Left = BalancedBSTFromSortedArray(arr, min, mid - 1);
            node.Right = BalancedBSTFromSortedArray(arr, mid + 1, max);

            return node;
        }


        /// <summary>
        /// Traverse binary tree in zig zag manner and print
        /// </summary>
        /// Input: 
        ///          8
        ///     4         12
        ///  2    6     10    14
        /// 1 3  5 7   9 11  13 15
        ///  
        /// Output: 8 12 4 2 6 10 14 15 13 11 9 7 5 3 1
        ///  
        ///  stackA: 2 6 10 14
        ///  stackB: 15 13 11 9 7 5 3 1 
        public static void ZigZagTraversal()
        {
            var arr = Helper.ReadElementsInOneLine();
            var tree = BalancedBSTFromSortedArray(arr, 0, arr.Length - 1);
            ZigZagTraversal(tree);
        }

        private static void ZigZagTraversal(TreeNode<int> tree)
        {
            if (tree == null) return;
            var stackA = new Stack<TreeNode<int>>();
            var stackB = new Stack<TreeNode<int>>();

            stackA.Push(tree);
            bool isLTR = true;

            while (!stackA.IsEmpty())
            {
                var top = stackA.Top();
                stackA.Pop();
                Console.Write(top.Value + " ");

                if (isLTR)
                {
                    if (top.Left != null) { stackB.Push(top.Left); }
                    if (top.Right != null) { stackB.Push(top.Right); }
                }
                else
                {
                    if (top.Right != null) { stackB.Push(top.Right); }
                    if (top.Left != null) { stackB.Push(top.Left); }
                }
                

                if (stackA.Size() == 0 && !stackB.IsEmpty())
                {
                    isLTR = !isLTR;
                    var temp = stackA;
                    stackA = stackB;
                    stackB = temp;
                }
            }

        }

        /// <summary>
        /// Check if two BSTs are identical
        /// </summary>
        public static void IdenticalBST()
        {
            var arr = Helper.ReadElementsInOneLine();
            var tree1 = BalancedBSTFromSortedArray(arr, 0, arr.Length - 1);
            arr = Helper.ReadElementsInOneLine();
            var tree2 = BalancedBSTFromSortedArray(arr, 0, arr.Length - 1);

            Helper.WriteLine(IsIdentical(tree1, tree2));
        }

        private static bool IsIdentical(TreeNode<int> root1, TreeNode<int> root2)
        {
            if (root1 == null && root2 == null) return true;
            if (root1?.Value != root2?.Value) return false;
            return IsIdentical(root1.Left, root2.Left) && IsIdentical(root1.Right, root2.Right);
        }

        /// <summary>
        /// 2 nodes of a BST are swapped, restore the BST to its full glory
        /// </summary>
        public static void RecoverBST()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void LargestBSTInBT()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void CatalanNumbers()
        {
            throw new NotImplementedException();
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