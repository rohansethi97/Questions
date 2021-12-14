using System;

namespace Questions
{
    public class LinkedList<T>
    {
        Node<T> list;

        public void AddToHead(T n)
        {
            var node = new Node<T>(n);
            if (list == null)
            {
                list = node;
            }
            else
            {
                node.Next = list;
                list = node;
            }
        }

        public void AddToTail(T n)
        {
            if (list == null)
            {
                this.AddToHead(n);
                return;
            }

            var node = new Node<T>(n);
            var head = list;

            while (head.Next != null)
            {
                head = head.Next;
            }

            head.Next = node;
        }

        public void DeleteFromHead()
        {
            if (list == null)
            {
                return;
            }
            else
            {
                list = list.Next;
            }
        }

        public bool IsEmpty()
        {
            return list == null;
        }

        public void DeleteNth(int index)
        {
            if (list == null)
            {
                Helper.WriteLine("Queue is empty");
                return;
            }
            if (index == 0)
            {
                DeleteFromHead();
                return;
            }
            // 1 2 3 4
            int count = 1;
            Node<T> head = list;
            while (head != null && count < index)
            {
                head = head.Next;
                count++;
            }

            if (head != null && head.Next!=null)
            {
                head.Next = head.Next.Next;
            }
            else
            {
                Helper.WriteLine("Invalid index");
                return;
            }
        }

        /// <summary>
        /// Gets nth index element
        /// </summary>
        /// <param name="index">uses 0 based indexing</param>
        /// <returns></returns>
        public T GetNthValue(int index)
        {
            if (list == null)
            {
                Helper.WriteLine("List is empty");
                return default;
            }

            int count = 0;
            Node<T> head = list;
            while (head != null && count <= index)
            {
                if (count == index)
                {
                    return head.Value;
                }
                else
                {
                    head = head.Next;
                    count++;
                }
            }

            Helper.WriteLine("index out of range");
            return default;
        }

        public int GetLength()
        {
            if (list == null) return 0;
            int count = 0;
            var head = list;

            while (head != null)
            {
                count++;
                head = head.Next;
            }

            return count;
        }
    }
}
