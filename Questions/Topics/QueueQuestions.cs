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
            queue.Deque();
            Helper.WriteLine($"First element is {queue.Peek()}");
            queue.Deque();

            while (!queue.IsEmpty())
            {
                Print(queue);
                queue.Pop();
            }
            Helper.WriteLine($"Is queue empty: {queue.IsEmpty()}");
        }

        /*
        Implement queue using stack
        Stack:
            Pushing 3 elements into stack -> 1 2 3
            Popping -> 3 2 1
        Queue:
            Enqueue 3 elements -> 1 2 3
            Dequeue -> 1 2 3

        Implement queue using stack
        Approach 1: in this dequeue will be costly as it requires n elements to have 2n pop & 2n push operations
            Enqueue
                Push to stack 1, this will enqueue
                if we have 3 2 1 in stack, simply push X
                X 3 2 1
            Dequeue
                Let's assume current state
                Stack1: 3 2 1
                Expected Output: 3 2
                
                Pop each element from stack 1 and push to stack 2
                Stack2: 1 2 3 

                Now pop the first element and ignore it
                Stack2: 2 3
                
                Now pop remaining element from stack 2 and push to stack 1
                Stack1: 3 2
        Approach 2: This will have easier dequeue but expensive enqueue
            Enqueue
                Existing stack2: 
                Stack2: 1 2 3
                
                Pop all from stack 2 if not empty and push to stack 1:
                Stack1: 3 2 1    

                Push to new element to Stack1 
                Stack1: X 3 2 1

                Pop all from stack 1 and push to stack 2
                Stack2: 1 2 3 X
            Dequeue
                Pop from Stack2

        Approach 3: Expensive dequeue, but fewer operations, this approach holds elements in intermediate state and relies on if conditions
            Enqueue
                Push to stack 1
            Dequeue
                if stack1 and stack2 are empty
                    queue is empty
                if stack2 is empty
                    push all from stack 1 to stack 2;
                pop top most element from stack2
            Peek
                if stack2 is empty
                    push all from stack 1 to stack 2;
                pop top most element from stack2
                push it back again
            Empty
                Stack1 == null && Stack2 == null
        
        Approach 4: Using call stack with 1 normal stack
            Enqueue
                Push to stack 1
            Dequeue
                var temp = stack.pop()
                
                if stack1 is empty
                    return temp;
                
                call method recursively
                
                stack.push(temp)
        */

        public static void QueueUsingStacks()
        {
            var stack1 = new Stack<int>();
            var stack2 = new Stack<int>();

            EnqueueUsingStack(stack1, 1);
            EnqueueUsingStack(stack1, 2);
            EnqueueUsingStack(stack1, 3);
            EnqueueUsingStack(stack1, 4);
            EnqueueUsingStack(stack1, 5);

            Console.WriteLine(DequeUsingStack(stack1, stack2));
            Console.WriteLine(DequeUsingStack(stack1, stack2));
            Console.WriteLine(DequeUsingStack(stack1, stack2));
            EnqueueUsingStack(stack1, 6);
            EnqueueUsingStack(stack1, 7);
            Console.WriteLine(DequeUsingStack(stack1, stack2));
            Console.WriteLine(DequeUsingStack(stack1, stack2));
            Console.WriteLine(DequeUsingStack(stack1, stack2));
            Console.WriteLine(DequeUsingStack(stack1, stack2));
            Console.WriteLine(DequeUsingStack(stack1, stack2));
        }

        private static void EnqueueUsingStack(Stack<int> stack1, int n)
        {
            stack1.Push(n);
        }

        private static int DequeUsingStack(Stack<int> stack1, Stack<int> stack2)
        {
            if (stack1.IsEmpty() && stack2.IsEmpty())
            {
                Helper.WriteLine("Queue is empty");
                return -1;
            }

            if (stack2.IsEmpty())
            {
                while (!stack1.IsEmpty())
                {
                    stack2.Push(stack1.Top());
                    stack1.Pop();
                }
            }

            var x = stack2.Top();
            stack2.Pop();

            return x;
        }

        // Stack using queue
        /* 
         * Adding 1 2 3 4 5 to stack
         * Stack: 5 4 3 2 1
         *  Push: X 5 4 3 2 1
         *  Pop:  5 3 2 1 1
         * 
         * Queue: 1 2 3 4 5
         *  Push: 1 2 3 4 5 X
         *  Pop:  2 3 4 5 X
         * 
         * 
         * Approach to implement stack using queue
         * # Approach 1: Making push easy & pop costly
         *  
         *  Push: push directly to queue 1
         *      q1: 1 2 3 4 5 X
         *  
         *  Pop: 
         *      While q1.size != 1
         *          q2.push(q1.top)
         *          q1.pop()
         *      q1.pop()
         *      swap(q1, q2)
         *      
         *  Top:
         *      While q1.size != 1
         *          q2.push(q1.top)
         *          q1.pop()
         *      var top = q1.top
         *      q1.pop()
         *      q2.push(top)
         *      swap(q1, q2)
         *      
         * # Approach 2: making pop easy & push costly
         * 
         * Pop: pop directly from q1
         *  q1: X 5 4 3 2 1
         *  q1: 5 4 3 2 1
         * 
         * Push: 
         *  Push to q2
         *  while q1 is not empty
         *      push from q1 to q2
         *  
         *  swap(q1, q2)
         *  
         *  q1: 5 4 3 2 1
         *  q2: X
         *  
         *  q1: 
         *  q2: X 5 4 3 2 1
         *  
         *  q1: X 5 4 3 2 1
         *  q2: 
         */

        /// <summary>
        /// Question: Implement stack using queues
        /// </summary>
        public static void StackUsingQueue_PopEasy()
        {
            var queue1 = new Queue<int>();

            queue1 = Push_Approach1(queue1, 1);
            queue1 = Push_Approach1(queue1, 2);
            queue1 = Push_Approach1(queue1, 3);
            queue1 = Push_Approach1(queue1, 4);
            queue1 = Push_Approach1(queue1, 5);

            Helper.WriteLine(Pop_Approach1(queue1));
            Helper.WriteLine(Pop_Approach1(queue1));
            Helper.WriteLine(Pop_Approach1(queue1));
            queue1 = Push_Approach1(queue1, 6);
            queue1 = Push_Approach1(queue1, 7);

            Helper.WriteLine(Pop_Approach1(queue1));
            Helper.WriteLine(Pop_Approach1(queue1));
            Helper.WriteLine(Pop_Approach1(queue1));
            Helper.WriteLine(Pop_Approach1(queue1));
            Helper.WriteLine(Pop_Approach1(queue1));
        }

        private static int Pop_Approach1(Queue<int> q1)
        {
            if (q1.IsEmpty())
            {
                Helper.WriteLine("Queue is empty");
                return -1;
            }
            var top = q1.Peek();
            q1.Deque();

            return top;
        }

        private static Queue<int> Push_Approach1(Queue<int> q1, int val)
        {
            var q2 = new Queue<int>();
            q2.Enqueue(val);

            while(!q1.IsEmpty())
            {
                var n = q1.Peek();
                q1.Deque();
                q2.Enqueue(n);
            }

            return q2;
        }

        /// <summary>
        /// Question: Implement stack using queues
        /// </summary>
        public static void StackUsingQueue_PushEasy()
        {
            var queue1 = new Queue<int>();

            Push_Approach2(queue1, 1);
            Push_Approach2(queue1, 2);
            Push_Approach2(queue1, 3);
            Push_Approach2(queue1, 4);
            Push_Approach2(queue1, 5);

            Helper.WriteLine(Pop_Approach2(queue1));
            Helper.WriteLine(Pop_Approach2(queue1));
            Helper.WriteLine(Pop_Approach2(queue1));
            Push_Approach2(queue1, 6);
            Push_Approach2(queue1, 7);

            Helper.WriteLine(Pop_Approach2(queue1));
            Helper.WriteLine(Pop_Approach2(queue1));
            Helper.WriteLine(Pop_Approach2(queue1));
            Helper.WriteLine(Pop_Approach2(queue1));
            Helper.WriteLine(Pop_Approach2(queue1));
        }

        private static int Pop_Approach2(Queue<int> q1)
        {
            if  (q1.Size() == 0)
            {
                Helper.WriteLine("Queue is empty");
                return -1;
            }

            var q2 = new Queue<int>();
            
            // Copy n-1 elements from q1 to q2
            // TODO: Implement size
            while (q1.Size() != 1)
            {
                q2.Enqueue(q1.Peek());
                q1.Deque();
            }

            // last element left in q1 is the one we need to ignore
            var popped = q1.Peek();
            q1.Deque();
            
            // swapping both queue
            q1.Head = q2.Head;

            return popped;
        }

        private static void Push_Approach2(Queue<int> q1, int val)
        {
            q1.Enqueue(val);
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