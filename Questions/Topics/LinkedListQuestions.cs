namespace Questions
{
    public class LinkedListQuestions
    {
        /// ------------------------------------
        /// <summary>
        /// Question: Perform basic operations on a linked list
        /// </summary>
        public static void CreateLinkedList()
        {
            var arr = Helper.ReadElementsInOneLine();
            Helper.WriteLine("Converting to linked list");
            var head = ConvertToLinkedList(arr);
            PrintNodes(head);

            Helper.WriteLine("Inserting new element at head");
            head = InsertAtHead(head, 5);
            PrintNodes(head);

            Helper.WriteLine("Inserting new element at tail");
            InsertAtTail(head, 10);
            PrintNodes(head);

            Helper.WriteLine("Deleting from tail");
            head = Delete(head, 10);
            PrintNodes(head);

            Helper.WriteLine("Deleting from head");
            head = Delete(head, 5);
            PrintNodes(head);

        }

        #region linked list helper

        // Helper functions
        private static void InsertAtTail(Node<int> head, int val)
        {
            if (head == null)
            {
                Helper.WriteLine("head pointer is null!");
                return;
            }

            var newNode = new Node<int>(val);
            while (head.Next != null)
            {
                head = head.Next;
            }

            head.Next = newNode;
            return;
        }

        private static Node<int> InsertAtHead(Node<int> head, int val)
        {
            var newNode = new Node<int>(val);
            newNode.Next = head;
            return newNode;
        }

        private static bool Search(Node<int> head, int key)
        {
            while (head != null)
            {
                if (head.Value == key)
                    return true;
            }
            return false;
        }

        private static Node<int> Delete(Node<int> head, int val)
        {
            var temp = head;
            if (head.Value == val)
                return DeleteAtHead(head);

            Node<int> prev = null;
            while (temp != null)
            {
                if (temp.Value == val)
                    break;
                prev = temp;
                temp = temp.Next;
            }

            prev.Next = temp.Next;
            return head;
        }

        private static Node<int> DeleteAtHead(Node<int> head)
        {
            return head.Next;
        }

        private static void PrintNodes(Node<int> s)
        {
            string ans = string.Empty;
            while (s != null)
            {
                ans += $" {s.Value}->";
                s = s.Next;
            }
            ans += "NULL";
            Helper.WriteLine($"[{ans}]");
        }

        private static Node<int> ConvertToLinkedList(int[] arr)
        {
            Node<int> head = null;
            Helper.WriteLine("Converting to linked list");
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == 0)
                {
                    head = InsertAtHead(head, arr[i]);
                }
                else
                {
                    InsertAtTail(head, arr[i]);
                }
            }

            return head;
        }

        private static int GetLengthOfLinkedList(Node<int> head)
        {
            if (head == null) return 0;
            int i = 1;

            while (head.Next != null)
            {
                head = head.Next;
                i++;
            }

            return i;
        }

        private static Node<int> GetNthNode(Node<int> head, int n)
        {
            int i = 1;

            while (head != null)
            {
                if (i == n)
                {
                    return head;
                }
                head = head.Next;

                i++;
            }

            return head;
        }
        #endregion
        // ------------------------------------

        /// ------------------------------------
        /// <summary>
        /// Question: Reverse a linked list
        /// </summary>
        public static void ReverseLinkedList()
        {
            var arr = Helper.ReadElementsInOneLine();
            var head = ConvertToLinkedList(arr);
            PrintNodes(head);
            head = Reverse(head);
            PrintNodes(head);

        }

        private static Node<int> Reverse(Node<int> current)
        {
            Node<int> prev = null, next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;

                current = next;
            }

            return prev;
        }
        // ------------------------------------

        /// ------------------------------------
        /// <summary>
        /// Question: Reverse a linked list
        /// </summary>
        /// I: 1 2 3 4 5 6, 2
        /// O: 2 1 4 3 6 5
        /// 
        public static void ReverseKNodes_Iterative()
        {
            var arr = Helper.ReadElementsInOneLine();
            var k = Helper.ReadN();
            var head = ConvertToLinkedList(arr);
            PrintNodes(head);
            var newHead = ReverseKNodes_Iterative(head, k);
            PrintNodes(newHead);

        }

        private static Node<int> ReverseKNodes_Iterative(Node<int> node, int k)
        {
            Node<int> finalHead = null, currTail = null, prev = null, next = null;
            Node<int> prevTail = null, curr = node;

            int counter = 1;

            while (curr != null)
            {
                if (counter % k == 1) // first
                {
                    currTail = curr;
                }

                if (counter % k == 0) // last
                {
                    if (finalHead == null)
                        finalHead = curr;
                    if (prevTail != null)
                        prevTail.Next = curr;
                    prevTail = currTail;
                }

                next = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = next;

                counter++;
            }
            prevTail.Next = prev;
            currTail.Next = null;

            return finalHead;

        }
        // ------------------------------------


        /// ------------------------------------
        /// <summary>
        /// Question: Reverse a linked list
        /// </summary>
        public static void ReverseKNodes_Recursive()
        {
            var arr = Helper.ReadElementsInOneLine();
            var k = Helper.ReadN();
            var head = ConvertToLinkedList(arr);
            PrintNodes(head);
            var newHead = ReverseKNodes_Recursive(head, k);
            PrintNodes(newHead);

        }

        /// I: 1 2 3 4 5 6, 2
        /// O: 2 1 4 3 6 5
        private static Node<int> ReverseKNodes_Recursive(Node<int> node, int k)
        {
            if (node == null) return null;

            Node<int> prev = null, curr = node, next = null;
            int counter = 1;

            while (curr != null && counter <= k)
            {
                next = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = next;

                counter++;
            }
            node.Next = ReverseKNodes_Recursive(curr, k);

            return prev;

        }
        // ------------------------------------

        /// ------------------------------------
        /// <summary>
        /// Question: Detect and remove a cycle in linked list
        /// Approach:
        /// Common: Detect cycle using fast and slow pointers, if they meet then cycle is present
        /// Approach 1:
        /// Use hashing / sets to store address, then detect last node and point it to null
        /// Approach 2:
        /// Use floyd's algo, (implementation below, see code for details)
        /// </summary>
        public static void DetectAndRemoveCycle()
        {
            var arr = Helper.ReadElementsInOneLine();
            var head = ConvertToLinkedList(arr);
            PrintNodes(head);
            CreateCycle(head, 3);
            DetectAndRemoveCycle(head);
            PrintNodes(head);
        }

        private static void CreateCycle(Node<int> head, int v)
        {
            Node<int> nthNode = null;
            int curr = 1;

            while (head.Next != null)
            {
                if (curr == v)
                {
                    nthNode = head;
                }
                curr++;
                head = head.Next;
            }

            head.Next = nthNode;
        }

        private static void DetectAndRemoveCycle(Node<int> head)
        {
            var isCycleDetected = HasCycle(head);
            if (!isCycleDetected) return;

            // Remove cycle
            Node<int> fast = head, slow = head;
            do
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            } while (fast != slow); // 1. Get to the point where both pointers point to each other

            /*
             Distance travelled by fast would be twice as much as slow
             m - no. of non loop nodes
             n - where fast and slow nodes have met
             l - no. of nodes in loop
             distance by fast = m + n + l*j
             distance by slow = 2 * (m + n + l*i)
             
             m + n = l*(j - 2*i)
             m = l*(j - 2*i) - n
             */


            fast = head; // set fast to head

            while (fast.Next != slow.Next) // when moved 1 by 1, they will meet at the starting node
            {
                fast = fast.Next;
                slow = slow.Next;
            }

            // Set current node to null
            slow.Next = null;
        }

        private static bool HasCycle(Node<int> head)
        {
            Node<int> fast = head, slow = head;

            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
                if (fast == slow)
                    return true;
            }

            return false;
        }
        // ------------------------------------


        /// ------------------------------------
        /// <summary>
        /// Question: AppendLastKNodesToStart
        /// </summary>
        public static void AppendLastKNodesToStart()
        {
            var arr = Helper.ReadElementsInOneLine();
            var n = Helper.ReadN();
            var head = ConvertToLinkedList(arr);
            PrintNodes(head);
            head = AppendLastKNodesToStart(head, n);
            PrintNodes(head);

        }

        // I: 1 2 3 4 5 6
        // I: 3
        // O: 4 5 6 1 2 3

        private static Node<int> AppendLastKNodesToStart(Node<int> head, int k)
        {
            var oldHead = head;
            int len = GetLengthOfLinkedList(head);
            var nodesToTraverse = len - k;
            int count = 1;

            while (count < nodesToTraverse)
            {
                head = head.Next;
                count++;
            }
            var oldTail = head;
            var newHead = head.Next;

            while (head.Next != null)
            {
                head = head.Next;
            }

            oldTail.Next = null;
            head.Next = oldHead;

            return newHead;
        }
        // ------------------------------------

        /// ------------------------------------
        /// <summary>
        /// Question: Merge 2 sorted linked list
        /// </summary>
        public static void MergeTwoSortedLinkedLists()
        {
            var arr1 = Helper.ReadElementsInOneLine();
            var head1 = ConvertToLinkedList(arr1);
            PrintNodes(head1);

            var arr2 = Helper.ReadElementsInOneLine();
            var head2 = ConvertToLinkedList(arr2);
            PrintNodes(head2);

            head1 = MergeTwoSortedLinkedLists(head1, head2);
            PrintNodes(head1);
        }

        private static Node<int> MergeTwoSortedLinkedLists(Node<int> node1, Node<int> node2)
        {
            var head = new Node<int>(0); // insert a fake node
            var headRef = head;
            while (node1 != null || node2 != null)
            {
                if (node2 == null || node1 != null && node1.Value < node2.Value)
                {
                    head.Next = node1;
                    node1 = node1.Next;
                }
                else
                {
                    head.Next = node2;
                    node2 = node2.Next;
                }

                head = head.Next;
            }

            return headRef.Next;
        }
        // ------------------------------------

        /// ------------------------------------
        /// <summary>
        /// Question: Intersection of two linked lists
        /// </summary>
        public static void IntersectionOfTwoLinkedLists()
        {
            var arr1 = Helper.ReadElementsInOneLine();
            var head1 = ConvertToLinkedList(arr1);
            PrintNodes(head1);

            var n = 3;
            var nthNode = GetNthNode(head1, n);

            var arr2 = Helper.ReadElementsInOneLine();
            var head2 = ConvertToLinkedList(arr2);

            var len = GetLengthOfLinkedList(head2);
            var lastNode = GetNthNode(head2, len);
            lastNode.Next = nthNode;
            PrintNodes(head2);

            var nodeVal = IntersectionOfTwoLinkedLists(head1, head2);
            Helper.WriteLine(nodeVal);

        }
        /*
           I:
             1 -> 2 -> 3  
                         -> 4 -> 5 -> null
                      10
           O: 
             4
         */
        private static int IntersectionOfTwoLinkedLists(Node<int> head1, Node<int> head2)
        {
            var len1 = GetLengthOfLinkedList(head1);
            var len2 = GetLengthOfLinkedList(head2);

            if (len1 < len2) // ensure len1 is greater for simplicity
            {
                Node<int> temp = head1;
                head1 = head2;
                head2 = temp;

                var len = len1;
                len1 = len2;
                len2 = len;
            }

            var diff = len1 - len2;
            int count = 1;
            while (count <= diff)
            {
                head1 = head1.Next;
                count++;
            }

            if (head1.Next != null && head2.Next != null && head1.Next == head2.Next)
                return head2.Next.Value;
            else
                return -1;

        }
        // ------------------------------------

        /// ------------------------------------
        /// <summary>
        /// Question: Reverse a linked list
        /// </summary>
        public static void MoveEvenNodesToEnd()
        {
            var arr = Helper.ReadElementsInOneLine();
            var head = ConvertToLinkedList(arr);
            PrintNodes(head);
            head = MoveEvenNodesToEnd(head);
            PrintNodes(head);

        }

        //I: 1 2 3 4 5 6
        //O: 1 3 5 2 4 6 

        private static Node<int> MoveEvenNodesToEnd(Node<int> node)
        {
            Node<int> odd = new Node<int>(-1), even = new Node<int>(-1);//for simplicity
            Node<int> oddHead = odd, evenHead = even;
            int count = 1;

            while (node != null)
            {
                if (count % 2 == 0)
                {
                    even.Next = node;
                    even = even.Next;
                }
                else
                {
                    odd.Next = node;
                    odd = odd.Next;
                }
                node = node.Next;
                count++;
            }
            even.Next = null;
            odd.Next = evenHead.Next; // using evenHead.next - as first node is fake;

            return oddHead.Next; //Head.next - as first node is fake;

        }
        // ------------------------------------


        /// ------------------------------------
        /// <summary>
        /// Question: Doubly linked list
        /// </summary>
        public static void DoublyLinkedListOperations()
        {
            var arr = Helper.ReadElementsInOneLine();
            var head = ConvertToDoublyLinkedList(arr);
            PrintNodes(head);

            head = InsertAtHead(head, 0);
            head = InsertAtHead(head, 0);
            PrintNodes(head);
            
            head = InsertAtTail(head, 0);
            head = InsertAtTail(head, 0);
            PrintNodes(head);

            head = DeleteAtHead(head);
            head = DeleteAtPos(head, 2);
            PrintNodes(head);

            head = DeleteAtHead(head);
            head = DeleteAtPos(head, 2);
            PrintNodes(head);

            head = DeleteAtTail(head);
            head = DeleteAtTail(head);
            PrintNodes(head);

            Helper.WriteLine("Node<int> at pos 2 is: " + GetNthNode(head, 2).Value);
            Helper.WriteLine("Length is: " + GetLengthOfLinkedList(head));
        }

        #region doubly linked list helpers
        private static DoublyLinkedListNode InsertAtPos(DoublyLinkedListNode node, int index, int val)
        {
            var newNode = new DoublyLinkedListNode(val);
            if (index == 1) return InsertAtHead(node, val);

            var head = node;
            int counter = 1;
            while (node != null)
            {
                if (counter == index)
                {
                    var prev = node.Previous;
                    prev.Next = newNode;
                    newNode.Previous = prev;

                    newNode.Next = node;
                    node.Previous = newNode;
                    break;
                }
                else
                {
                    node = node.Next;
                    counter++;
                }
            }

            if (node == null) return InsertAtTail(head, val);

            return head;
        }

        private static DoublyLinkedListNode InsertAtHead(DoublyLinkedListNode node, int val)
        {
            var newNode = new DoublyLinkedListNode(val);
            if (node == null) return newNode;

            newNode.Next = node;
            node.Previous = newNode;
            return newNode;
        }

        private static DoublyLinkedListNode InsertAtTail(DoublyLinkedListNode node, int val)
        {
            var newNode = new DoublyLinkedListNode(val);
            if (node == null) return newNode;
            var head = node;

            while (node.Next != null)
            {
                node = node.Next;
            }

            node.Next = newNode;
            newNode.Previous = node;

            return head;
        }

        private static DoublyLinkedListNode DeleteAtPos(DoublyLinkedListNode node, int index)
        {
            if (index == 1) return DeleteAtHead(node);
            var head = node;
            int count = 1;

            var deleted = false;
            while (node.Next != null)
            {
                if (count == index)
                {
                    node.Previous.Next = node.Next;
                    node.Next.Previous = node.Previous;
                    deleted = true;
                    break;
                }
                else
                {
                    count++;
                    node = node.Next;
                }
            }

            if (!deleted) DeleteAtTail(head);

            return head;
        }

        private static DoublyLinkedListNode DeleteAtHead(DoublyLinkedListNode node)
        {
            var next = node.Next;
            node.Next.Previous = null;
            return next;
        }

        private static DoublyLinkedListNode DeleteAtTail(DoublyLinkedListNode node)
        {
            var head = node;

            while (node != null && node.Next != null)
            {
                node = node.Next;
            }
            if (node != null) node.Previous.Next = null;

            return head;
        }
        private static void PrintNodes(DoublyLinkedListNode s)
        {
            string ans = string.Empty;
            var tail = s;
            while (s != null)
            {
                ans += $" {s.Value}->";
                if (s.Next == null) tail = s;
                s = s.Next;
            }
            ans += "NULL";
            Helper.WriteLine($"Forwards: [{ans}]");

            ans = string.Empty;
            while (tail != null)
            {
                ans += $" {tail.Value}->";
                tail = tail.Previous;
            }
            ans += "NULL";
            Helper.WriteLine($"Forwards: [{ans}]");
        }

        private static DoublyLinkedListNode ConvertToDoublyLinkedList(int[] arr)
        {
            DoublyLinkedListNode head = null;
            Helper.WriteLine("Converting to linked list");
            for (int i = 0; i < arr.Length; i++)
            {
                head = InsertAtPos(head, i+1, arr[i]);
            }

            return head;
        }

        private static int GetLengthOfLinkedList(DoublyLinkedListNode head)
        {
            if (head == null) return 0;
            int i = 1;

            while (head.Next != null)
            {
                head = head.Next;
                i++;
            }

            return i;
        }
        private static DoublyLinkedListNode GetNthNode(DoublyLinkedListNode head, int n)
        {
            int i = 1;

            while (head != null)
            {
                if (i == n)
                {
                    return head;
                }
                head = head.Next;

                i++;
            }

            return head;
        }

        #endregion
        // ------------------------------------


        /// ------------------------------------
        /// <summary>
        /// Question: Circular linked list
        /// </summary>
        public static void CircularLinkedListOperations()
        {
            var arr = Helper.ReadElementsInOneLine();
            var head = ConvertToCircularLinkedList(arr);
            PrintNodes_Circular(head);

            head = InsertAtHead_Circular(head, 1);
            head = InsertAtHead_Circular(head, 2);
            PrintNodes_Circular(head);

            head = InsertAtTail_Circular(head, 3);
            head = InsertAtTail_Circular(head, 4);
            PrintNodes_Circular(head);

            head = DeleteAtPos_Circular(head, 1);
            head = DeleteAtPos_Circular(head, GetLengthOfCircularLinkedList(head)/2);
            head = DeleteAtPos_Circular(head, GetLengthOfCircularLinkedList(head));
            PrintNodes_Circular(head);

            Helper.WriteLine("Length is: " + GetLengthOfCircularLinkedList(head));
        }

        #region Circular linked list helpers
        
        private static Node<int> InsertAtHead_Circular(Node<int> node, int val)
        {
            var newNode = new Node<int>(val);
            if (node == null)
            {
                newNode.Next = newNode;
                return newNode;
            }
            newNode.Next = node;
            
            var head = node;
            while (node.Next != head)
            {
                node = node.Next;
            }
            node.Next = newNode;
            
            return newNode;
        }

        private static Node<int> InsertAtTail_Circular(Node<int> node, int val)
        {
            if (node == null)
            {
                return InsertAtHead_Circular(node, val);
            }
            var newNode = new Node<int>(val);

            var head = node;
            while (node.Next != head)
            {
                node = node.Next;
            }
            node.Next = newNode;
            newNode.Next = head;

            return head;
        }

        private static Node<int> DeleteAtPos_Circular(Node<int> node, int index)
        {
            if (index == 1) return DeleteAtHead_Circular(node);
            var head = node;
            
            int count = 1;
            while (node.Next != head)
            {
                if (count == index-1)
                {
                    node.Next = node.Next.Next;
                    break;
                }
                else
                {
                    count++;
                    node = node.Next;
                }
            }

            return head;
        }

        private static Node<int> DeleteAtHead_Circular(Node<int> node)
        {
            if (node.Next == node) return null;

            var head = node;
            var newHead = node.Next;
            while(node.Next != head)
            {
                node = node.Next;
            }
            node.Next = newHead;
            
            return newHead;
        }

        private static void PrintNodes_Circular(Node<int> s)
        {
            string ans = string.Empty;
            var head = s;

            do
            {
                ans += $" {s.Value}->";
                s = s.Next;
            }
            while (s != head);

            ans += $"{s.Value}";

            Helper.WriteLine($"Forwards: [{ans}]");

        }

        private static Node<int> ConvertToCircularLinkedList(int[] arr)
        {
            Node<int> head = null;
            Helper.WriteLine("Converting to linked list");
            for (int i = 0; i < arr.Length; i++)
            {
                head = InsertAtTail_Circular(head, arr[i]);
            }

            return head;
        }

        private static int GetLengthOfCircularLinkedList(Node<int> node)
        {
            if (node == null) return 0;
            int i = 1;
            var head = node;
            while (node.Next != head)
            {
                node = node.Next;
                i++;
            }

            return i;
        }
        #endregion
        // ------------------------------------
    }
}



// Template 

/*
 
/// ------------------------------------
/// <summary>
/// Question: Reverse a linked list
/// </summary>
public static void ReverseLinkedList()
{
    var arr = Helper.ReadElementsInOneLine();
    var head = ConvertToLinkedList(arr);
    PrintNodes(head);
    head = Reverse(head);
    PrintNodes(head);

}

private static Node<int> Reverse(Node<int> node)
{

}
// ------------------------------------


*/