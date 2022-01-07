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
            //-------------Searching-------------
            //SearchingQuestions.LinearSearch(); //todo_question
            //SearchingQuestions.BinarySearch(); //todo_question

            
            //--------------Array----------------
            //ArrayQuestions.


            //-------------Sorting------------
            //SortingQuestions.BubbleSort(); //todo_question
            //SortingQuestions.InsertionSort(); //todo_question
            //SortingQuestions.SelectionSort(); //todo_question
            //SortingQuestions.QuickSort();
            //SortingQuestions.MergeSort();


            //--------------Recursion-----------
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
            //RecursionQuestions.NthCatalanNumber();


            //-------------Linked List------------
            //LinkedListQuestions.CreateLinkedList();
            //LinkedListQuestions.ReverseLinkedList();
            //LinkedListQuestions.ReverseKNodes_Iterative();
            //LinkedListQuestions.ReverseKNodes_Recursive();
            //LinkedListQuestions.AppendLastKNodesToStart();
            //LinkedListQuestions.MergeTwoSortedLinkedLists();
            //LinkedListQuestions.IntersectionOfTwoLinkedLists();
            //LinkedListQuestions.DetectAndRemoveCycle();
            //LinkedListQuestions.MoveEvenNodesToEnd();
            //LinkedListQuestions.DoublyLinkedListOperations();
            //LinkedListQuestions.CircularLinkedListOperations();


            //-------------Stack------------
            //StackQuestions.StackOperations();
            //StackQuestions.ReverseString();
            //StackQuestions.AreParenthesisBalanced();
            //StackQuestions.PostfixEvaluation();
            //StackQuestions.PrefixEvaluation();
            //StackQuestions.InfixToPrefix();
            //StackQuestions.InfixToPostfix();
            //StackQuestions.InfixToPostfix();
            //StackQuestions.InfixToPrefix();


            //-------------Queue------------
            //QueueQuestions.QueueOperations();
            //QueueQuestions.QueueUsingStacks();
            //QueueQuestions.StackUsingQueue_PushEasy();
            //QueueQuestions.StackUsingQueue_PopEasy();


            //-------------Binary Tree---------
            //BinaryTreeQuestions.Traversal();
            //BinaryTreeQuestions.IsBalanced();
            //BinaryTreeQuestions.Diameter();
            //BinaryTreeQuestions.HeightOfTree();
            //BinaryTreeQuestions.SumNodes();
            //BinaryTreeQuestions.SumReplacement();
            //BinaryTreeQuestions.LeftView();
            //BinaryTreeQuestions.RightView();
            //BinaryTreeQuestions.LevelOrderTraversal();
            //BinaryTreeQuestions.SumAtKthLevel();
            //BinaryTreeQuestions.ConstructBinaryTreeFromPostOrder();
            //BinaryTreeQuestions.ConstructBinaryTreeFromPreorder();
            //BinaryTreeQuestions.LowestCommonAncestor();
            //BinaryTreeQuestions.ShortestDistanceBetweenTwoNodes();
            //BinaryTreeQuestions.MaxPossibleSum();
            //BinaryTreeQuestions.FindNodesAtKDistance();
            //BinaryTreeQuestions.Flatten();


            //-------------Binary Search Tree---------
            //BinarySearchTreeQuestions.InsertIntoBST();
            //BinarySearchTreeQuestions.SearchInBST();
            //BinarySearchTreeQuestions.DeleteFromBST();
            //BinarySearchTreeQuestions.BSTFromPreOrder();
            //BinarySearchTreeQuestions.IsBST();
            //BinarySearchTreeQuestions.BalancedBSTFromSortedArray();
            //BinarySearchTreeQuestions.IdenticalBST();
            //BinarySearchTreeQuestions.RecoverBST();
            //BinarySearchTreeQuestions.LargestBSTInBT();
            //BinarySearchTreeQuestions.ZigZagTraversal();
            //BinarySearchTreeQuestions.AllPossibleBSTForN();


            // ------------ Heaps ----------------
            //HeapsQuestions.InsertIntoHeap();
            //HeapsQuestions.DeleteFromHeap();
            //HeapsQuestions.HeapSort();
            //HeapsQuestions.Heapify();
            //HeapsQuestions.MedianOfRunningStream();
            //HeapsQuestions.MergeKSortedArrays();
            //HeapsQuestions.SmallestSequenceWithSumAtleastK();


            // ------------ Hashing --------------
            //HashingQuestions.Chaining();
            //HashingQuestions.LinearProbing();
            //HashingQuestions.QuadraticProbing();
            //HashingQuestions.VerticalOrderPrint();
            //HashingQuestions.TopKMostFrequentElements();
            //HashingQuestions.FirstKDistinctElements();
            //HashingQuestions.NumberOfSubarraysWithSumZero(); //todo_question
            //HashingQuestions.SudokuSolver(); //todo_question


        }
    }
}
