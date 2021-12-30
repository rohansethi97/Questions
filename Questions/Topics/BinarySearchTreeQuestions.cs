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
        /// Approach
        /// Inorder of a BST is always in ascending order, we can traverse through the BST using inorder
        /// to catch which elements are swapped
        /// 
        /// There are 2 cases
        /// 
        /// Case 1: BST Inorder -> 1 5 3 4 2 6 7
        ///     Here, 5 & 2 are swapped
        /// Case 2: BST Inorder ->  1 2 4 3 5 6 7
        ///     here 3 & 4 are swapped
        ///     
        /// We can maintain the following 3 pointers, which point to occurence where BST inorder property is violated i.e. prev < curr
        /// 
        /// 1. 1st occurrence 
        ///     i.e. case1: pointer to 5, case 2: pointer to 4
        /// 
        /// 2. Element right after first occurence (to handle case 2.) 
        ///     Case1: pointer to 4, case2: pointer to 3
        ///     
        /// 3. Last occurence (to handle case 1)
        ///     Case1: pointer to 2, Case2: null (since there would only be one violation)
        /// 
        /// For case1: swap 1 & 3, 
        /// for case2: swap 1 & 2
        public static void RecoverBST()
        {
            var arr = Helper.ReadElementsInOneLine();
            var tree = BalancedBSTFromSortedArray(arr, 0, arr.Length - 1);
            PrintInorder(tree);

            var temp = tree.Left.Value;
            tree.Left.Value = tree.Left.Left.Value;
            tree.Left.Left.Value = temp;

            PrintInorder(tree);

            TreeNode<int> first = null;
            TreeNode<int> second = null;
            TreeNode<int> third = null;
            TreeNode<int> prev = null;
            CalculatePointers(tree, ref prev, ref first, ref second, ref third);

            if (third == null) third = second;

            temp = first.Value;
            first.Value = third.Value;
            third.Value = temp;

            PrintInorder(tree);
        }

        private static void CalculatePointers(TreeNode<int> root, ref TreeNode<int> prev, ref TreeNode<int> first, ref TreeNode<int> second, ref TreeNode<int> third)
        {
            if (root == null) return;
            CalculatePointers(root.Left, ref prev, ref first, ref second, ref third);

            if (prev != null)
            {
                if (root.Value < prev.Value)
                {
                    if (first == null)
                    {
                        first = prev;
                        second = root;
                    }
                    else
                    {
                        third = root;
                    }
                }

                prev = root;
            }
            else { prev = root; }

            CalculatePointers(root.Right, ref prev, ref first, ref second, ref third);
        }

        /// <summary>
        /// Find largest size of BST in a BT, 
        /// Note: we will only consider only those BSTs which are from root to leaf nodes, that root node can be at any level of a BT
        /// Example: 
        /// Input:      3
        ///           2    4  
        ///          9 8  6 5   
        /// Output: 1, although 2-3-4 is a BST, but we will only consider BSTs that have leaf nodes at bottom
        /// 
        /// Input:       4
        ///           2    6  
        ///          1 3  7  8     
        /// Output: 3, as 1-2-3 are BST, but right sub tree of 4 is not
        /// </summary>
        /// 
        /// Approach: 
        /// 1. Traverse the nodes from bottom to the top
        /// 2. For each node, calculate the following
        ///    min, max, ans, isBST
        /*
            T1:
                     9
                  4     11
                2  5   8  13
              1 3   6
              
            Inorder: 1 2 3 4 5 6 9 8 11 13
            Preorder: 1 3 2 6 5 4 8 13 11 9
         */    

        public static void LargestBSTInBT()
        {
            var tree = CreateBT();

            (int min , int max, int ans, bool isBST) info = LargestBSTInBT(tree);
            Helper.WriteLine(info.ans);
        }

        private static (int min, int max, int ans, bool isBST) LargestBSTInBT(TreeNode<int> root)
        {
            if (root == null) return (int.MaxValue, int.MinValue, 0, true);
            if (root.Left == null && root.Right == null) return (root.Value, root.Value, 1, true);

            var leftInfo = LargestBSTInBT(root.Left);
            var rightInfo = LargestBSTInBT(root.Right);

            (int min, int max, int ans, bool isBST) currInfo;

            if (
                leftInfo.isBST && 
                rightInfo.isBST && 
                root.Value > leftInfo.max && 
                root.Value < rightInfo.min
                )
            {
                currInfo.min = Math.Min(leftInfo.min, root.Value);
                currInfo.max = Math.Min(rightInfo.max, root.Value);
                currInfo.ans = leftInfo.ans + rightInfo.ans + 1;
                currInfo.isBST = true;
            }
            else
            {
                currInfo = (0, 0, Math.Max(leftInfo.ans, rightInfo.ans), false);
            }

            return currInfo;
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

        private static TreeNode<int> CreateBT()
        {
            return BinaryTreeQuestions.CreateBinaryTree();
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