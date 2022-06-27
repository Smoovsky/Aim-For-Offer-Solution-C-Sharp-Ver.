namespace Algorithm.Chapter3
{
    public static partial class Solution
    {
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