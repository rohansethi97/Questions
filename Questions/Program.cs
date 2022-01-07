namespace Questions
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int count = 1;
        Start:
            Execute();
            Console.WriteLine();
            Console.WriteLine("----------------- Execution ended -------------------");
            Console.WriteLine();
            count++;

            if (count == 10)
                Console.ReadLine();

            goto Start;
        }

        static void Execute()
        {

            // ------------ Hashing --------------
            //HashingQuestions.Chaining();
            //HashingQuestions.LinearProbing();
            //HashingQuestions.QuadraticProbing();
            //HashingQuestions.VerticalOrderPrint();
            //HashingQuestions.TopKMostFrequentElements();
            //HashingQuestions.FirstKDistinctElements();
            //HashingQuestions.NumberOfSubarraysWithSumZero();
            //HashingQuestions.SudokuSolver();

            // ------------ Heaps ----------------
            //HeapsQuestions.InsertIntoHeap();
            //HeapsQuestions.DeleteFromHeap();
            //HeapsQuestions.HeapSort();
            //HeapsQuestions.Heapify();
            //HeapsQuestions.MedianOfRunningStream();
            //HeapsQuestions.MergeKSortedArrays();
            //HeapsQuestions.SmallestSequenceWithSumAtleastK();

            //-------------Binary Search Tree---------
            //BinarySearchTreeQuestions.AllPossibleBSTForN();
            //BinarySearchTreeQuestions.LargestBSTInBT();
            //BinarySearchTreeQuestions.RecoverBST();
            //BinarySearchTreeQuestions.IdenticalBST();
            //BinarySearchTreeQuestions.ZigZagTraversal();
            //BinarySearchTreeQuestions.BalancedBSTFromSortedArray();
            //BinarySearchTreeQuestions.IsBST();
            //BinarySearchTreeQuestions.BSTFromPreOrder();
            //BinarySearchTreeQuestions.DeleteFromBST();
            //BinarySearchTreeQuestions.SearchInBST();
            //BinarySearchTreeQuestions.InsertIntoBST();


            //-------------Binary Tree---------
            //BinaryTreeQuestions.ShortestDistanceBetweenTwoNodes();
            //BinaryTreeQuestions.LowestCommonAncestor();
            //BinaryTreeQuestions.MaxPossibleSum();
            //BinaryTreeQuestions.FindNodesAtKDistance();
            //BinaryTreeQuestions.Flatten();
            //BinaryTreeQuestions.LeftView();
            //BinaryTreeQuestions.RightView();
            //BinaryTreeQuestions.IsBalanced();
            //BinaryTreeQuestions.SumReplacement();
            //BinaryTreeQuestions.Diameter();
            //BinaryTreeQuestions.HeightOfTree();
            //BinaryTreeQuestions.SumNodes();
            //BinaryTreeQuestions.SumAtKthLevel();
            //BinaryTreeQuestions.LevelOrderTraversal();
            //BinaryTreeQuestions.ConstructBinaryTreeFromPostOrder();
            //BinaryTreeQuestions.ConstructBinaryTreeFromPreorder();
            //BinaryTreeQuestions.Traversal();


            //-------------Queue------------
            //QueueQuestions.StackUsingQueue_PushEasy();
            //QueueQuestions.StackUsingQueue_PopEasy();
            //QueueQuestions.QueueUsingStacks();
            //QueueQuestions.QueueOperations();


            //-------------Stack------------
            //StackQuestions.InfixToPrefix();
            //StackQuestions.InfixToPostfix();
            //StackQuestions.InfixToPostfix();
            //StackQuestions.InfixToPrefix();
            //StackQuestions.AreParenthesisBalanced();
            //StackQuestions.PostfixEvaluation();
            //StackQuestions.PrefixEvaluation();
            //StackQuestions.ReverseString();
            //StackQuestions.StackOperations();

            //-------------Linked List------------
            //LinkedListQuestions.CircularLinkedListOperations();
            //LinkedListQuestions.DoublyLinkedListOperations();
            //LinkedListQuestions.MoveEvenNodesToEnd();
            //LinkedListQuestions.IntersectionOfTwoLinkedLists();
            //LinkedListQuestions.MergeTwoSortedLinkedLists();
            //LinkedListQuestions.AppendLastKNodesToStart();
            //LinkedListQuestions.DetectAndRemoveCycle();
            //LinkedListQuestions.ReverseKNodes_Recursive();
            //LinkedListQuestions.ReverseKNodes_Iterative();
            //LinkedListQuestions.ReverseLinkedList();
            //LinkedListQuestions.CreateLinkedList();

            //-------------Sorting------------
            //SortingQuestions.QuickSort();
            //SortingQuestions.MergeSort();

            //--------------Recursion-----------
            //RecursionQuestions.NthCatalanNumber();
            //RecursionQuestions.SumTillN();
            //RecursionQuestions.NToPowerP();
            //RecursionQuestions.FactorialOfN();
            //RecursionQuestions.NthFibonacci();
            //RecursionQuestions.IsArraySorted();
            //RecursionQuestions.PrintInAscendingTillN();
            //RecursionQuestions.PrintInDescendingTillN();
            //RecursionQuestions.FirstOccurrenceInArray();
            //RecursionQuestions.LastOccurrenceInArray();
            //RecursionQuestions.ReverseString();
            //RecursionQuestions.ReplaceSubstring();
            //RecursionQuestions.TowerOfHanoi();
            //RecursionQuestions.RemoveDuplicates();
            //RecursionQuestions.MoveXToEnd();
            //RecursionQuestions.AllSubsequencesOfAString();
            //RecursionQuestions.AllSubsequencesASCIIOfAString();
        }
    }
}
