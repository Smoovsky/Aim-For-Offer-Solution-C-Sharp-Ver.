namespace Algorithm.Chapter3
{
    public static partial class Solution
    {
        public class LinkedListNode<T>
        {
            public T? Value { get; set; }

            public LinkedListNode<T>? Next { get; set; }

            public static LinkedListNode<TV> Create<TV>(TV val) => new()
            {
                Value = val
            };

            public static void Connect<TV>(LinkedListNode<TV> p,  LinkedListNode<TV> c)
            {
                if (p == null)
                {
                    return;
                }

                p.Next = c;
            }
        }

        public static void P120DelLinkedListNode<T>(
            ref LinkedListNode<T>? head,
            LinkedListNode<T> nodeToDel)
        {
            if (nodeToDel.Next != null)
            {
                nodeToDel.Value = nodeToDel.Next.Value;
                nodeToDel.Next = nodeToDel.Next;
            }
            else if (head == nodeToDel) // del first node
            {
                head = null;
            }
            else // del last node
            {
                var prev = head;
                var current = head!.Next;

                while (current!.Next != null)
                {
                    prev = current;
                    current = current.Next;
                }

                prev!.Next = null;
            }
        }
    }
}