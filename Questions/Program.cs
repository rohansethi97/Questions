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
            //SearchingQuestions.LinearSearch();
            //SearchingQuestions.BinarySearch();


            //-------------Sorting------------
            //SortingQuestions.BubbleSort();
            //SortingQuestions.SelectionSort();
            //SortingQuestions.InsertionSort();
            //SortingQuestions.QuickSort();
            //SortingQuestions.MergeSort();


            //--------------Array----------------
            //ArrayQuestions.MaxTillI();
            //ArrayQuestions.SumOfAllSubarrays_Nested_Loop();
            //ArrayQuestions.LongestArithmeticSubarray();
            //ArrayQuestions.FirstRepeatingElement();
            //ArrayQuestions.SubarrayWithGivenSum();
            //ArrayQuestions.SmallestPositiveMissingNumber();
            //ArrayQuestions.PrintAllSubarrays();
            //ArrayQuestions.MaxSubarraySum_Iterative();
            //ArrayQuestions.MaxSubarraySum_PrefixSum();
            //ArrayQuestions.MaxSubarraySum_Kadane();
            //ArrayQuestions.CircularSubarraySum();
            //ArrayQuestions.PairSum();

            //---------------2D arrays-----------
            //Array2DQuestions.Operations();
            //Array2DQuestions.SpiralOrderTraversal();
            //Array2DQuestions.MatrixTranspose();
            //Array2DQuestions.MatrixMultiplication();
            //Array2DQuestions.MatrixSearch();

            //---------------Characters arrays-----------
            //CharArrayQuestions.Operations();
            //CharArrayQuestions.Palindrome();
            //CharArrayQuestions.LargestWordInCharArray();

            //---------------String questions-------
            //StringQuestions.Operations();
            //StringQuestions.FormBiggestNumber();
            //StringQuestions.HighestFrequencyAlphabet();

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
            //RecursionQuestions.LetterCombinationsPhone();
            //RecursionQuestions.PermutationsOfAString();
            //RecursionQuestions.CountPathsInSingleRow();
            //RecursionQuestions.CountPathsInMaze();
            //RecursionQuestions.TilingProblem();
            //RecursionQuestions.FriendsPairingProblem();


            //---------- Backtracking------------
            //BacktrackingQuestions.RatInAMaze();
            //BacktrackingQuestions.NQueen();


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
