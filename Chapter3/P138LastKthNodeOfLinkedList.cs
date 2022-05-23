namespace Algorithm.Chapter3
{
    public static partial class Solution
    {
        public static LinkedListNode<T> P138LastKthNodeOfLinkedList<T>(
            LinkedListNode<T> headNode,
            uint k)
        {
            if (k == 0 || headNode == null)
            {
                return null;
            }

            var p1 = headNode;
            var p2 = headNode;

            for (int i = 0; i < k - 1; i++)
            {
                if (p1.Next == null)
                {
                    return null;
                }

                p1 = p1.Next;
            }

            while(p1.Next != null)
            {
                p1 = p1.Next;
                p2 = p2!.Next;
            }

            return p2;
        }
    }
}