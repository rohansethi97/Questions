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

            //-------------Queue------------
            QueueQuestions.QueueOperations();


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
