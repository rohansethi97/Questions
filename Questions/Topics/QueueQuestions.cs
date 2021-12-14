using System;

namespace Questions
{
    public static class QueueQuestions
    {
        /// ------------------------------------
        /// <summary>
        /// Question: Queue Operations
        /// </summary>
        public static void QueueOperations()
        {
            var arr = Helper.ReadElementsInOneLine();
            var queue = ConvertToQueue(arr);
            Print(queue);
            queue.Enqueue(0);
            queue.Enqueue(0);
            Print(queue);
            queue.Dequeue();
            Helper.WriteLine($"First element is {queue.Peek()}");
            queue.Dequeue();

            while (!queue.IsEmpty())
            {
                Print(queue);
                queue.Pop();
            }
            Helper.WriteLine($"Is queue empty: {queue.IsEmpty()}");
        }



        #region helpers
        private static Queue<int> ConvertToQueue(int[] arr)
        {
            var queue = new Queue<int>();

            foreach (int i in arr)
                queue.Push(i);

            return queue;
        }

        private static void Print(Queue<int> queue)
        {
            var len = queue.Head.GetLength();
            var str = string.Empty;
            for (int i = 0; i < len; i++)
            {
                str += $"{queue.Head.GetNthValue(i)} -> ";
            }

            Helper.WriteLine($"[{str}null ]");
        }
        #endregion
    }
}

/* 
/// ------------------------------------
/// <summary>
/// Question: Queue
/// </summary>
public static void Queue()
{
    var arr = Helper.ReadElementsInOneLine();
    var queue = ConvertToQueue(arr);
    Print(queue);
    var result = Operation(queue);
    Helper.WriteLine(result);
}

private static string Operation(Queue queue)
{

}
// ------------------------------------

*/