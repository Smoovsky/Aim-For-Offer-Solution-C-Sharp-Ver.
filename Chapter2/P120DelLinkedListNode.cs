namespace Algorithm
{
    public static partial class Solution
    {
        public class P120LinkedListNode<T>
        {
            public T Value { get; set; }

            public P120LinkedListNode<T> Next { get; set; }
        }

        public static void P120DelLinkedListNode<T>(
            ref P120LinkedListNode<T> head,
            P120LinkedListNode<T> nodeToDel)
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
                var current = head.Next;

                while (current.Next != null)
                {
                    prev = current;
                    current = current.Next;
                }

                prev.Next = null;
            }
        }
    }
}