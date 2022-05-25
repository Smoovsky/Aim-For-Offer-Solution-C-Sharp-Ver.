namespace Algorithm.Chapter3
{
    public static partial class Solution
    {
        public static LinkedListNode<T> P145ReverseLinkedList<T>(LinkedListNode<T> headNode)
        {
            if (headNode == null)
            {
                return null;
            }

            var node = headNode;
            LinkedListNode<T> prevNode = null;

            while (node != null)
            {
                var nextNode = node.Next;
                if (nextNode == null)
                {
                    headNode = node;
                }

                node.Next = prevNode;
                prevNode = node;
                node = nextNode;
            }

            return headNode;
        }

        public static LinkedListNode<T> P145ReverseLinkedListRecursive<T>(
            LinkedListNode<T> node,
            LinkedListNode<T> prevNode)
        {
            if (node == null)
            {
                return null;
            }

            var nextNode = node.Next;

            node.Next = prevNode;

            if (nextNode == null)
            {
                return node;
            }

            return P145ReverseLinkedListRecursive(nextNode, node);
        }

        public static LinkedListNode<int> P145Test(LinkedListNode<int> pHead)
        {
            Console.Write("The original list is: \n");
            LinkedListNode<int>.Print(pHead);

            LinkedListNode<int> pReversedHead = P145ReverseLinkedList(pHead);

            Console.Write("The reversed list is: \n");
            LinkedListNode<int>.Print(pReversedHead);

            LinkedListNode<int> pReversedRecursiveHead = P145ReverseLinkedListRecursive(
                P145ReverseLinkedList(pReversedHead),
                null);

            Console.Write("The recursively reversed list is: \n");
            LinkedListNode<int>.Print(pReversedRecursiveHead);

            return pReversedHead;
        }

        // 输入的链表有多个结点
        public static void P145Test1()
        {
            LinkedListNode<int> pNode1 = LinkedListNode<int>.Create(1);
            LinkedListNode<int> pNode2 = LinkedListNode<int>.Create(2);
            LinkedListNode<int> pNode3 = LinkedListNode<int>.Create(3);
            LinkedListNode<int> pNode4 = LinkedListNode<int>.Create(4);
            LinkedListNode<int> pNode5 = LinkedListNode<int>.Create(5);

            LinkedListNode<int>.Connect(pNode1, pNode2);
            LinkedListNode<int>.Connect(pNode2, pNode3);
            LinkedListNode<int>.Connect(pNode3, pNode4);
            LinkedListNode<int>.Connect(pNode4, pNode5);

            LinkedListNode<int> pReversedHead = P145Test(pNode1);
        }

        // 输入的链表只有一个结点
        public static void P145Test2()
        {
            LinkedListNode<int> pNode1 = LinkedListNode<int>.Create(1);

            LinkedListNode<int> pReversedHead = P145Test(pNode1);
        }

        // 输入空链表
        public static void P145Test3()
        {
            P145Test(null);
        }
    }
}