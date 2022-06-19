namespace Algorithm.Chapter3
{
    public static partial class Solution
    {
        public static LinkedListNode<T> P147MergeSortedLinkedList<T>(
            LinkedListNode<T>? p1HeadNode,
            LinkedListNode<T>? p2HeadNode)
        where T : IComparable
        {
            if (p1HeadNode == null)
            {
                return p2HeadNode;
            }

            if (p2HeadNode == null)
            {
                return p1HeadNode;
            }

            LinkedListNode<T> headNode;

            if ((p1HeadNode.Value?.CompareTo(p2HeadNode.Value) ?? -1) > 0)
            {
                headNode = p2HeadNode;

                headNode.Next = P147MergeSortedLinkedList(
                    p2HeadNode.Next,
                    p1HeadNode);
            }
            else
            {
                headNode = p1HeadNode;

                headNode.Next = P147MergeSortedLinkedList(
                    p1HeadNode.Next,
                    p2HeadNode);
            }

            return headNode;
        }

        public static LinkedListNode<int> P147Test(string testName, LinkedListNode<int> pHead1, LinkedListNode<int> pHead2)
        {
            if (testName != null)
                Console.WriteLine($"{testName} begins:\n");

            Console.WriteLine("The first list is:\n");
            LinkedListNode<int>.Print(pHead1);

            Console.WriteLine("The second list is:\n");
            LinkedListNode<int>.Print(pHead2);

            Console.WriteLine("The merged list is:\n");
            LinkedListNode<int> pMergedHead = P147MergeSortedLinkedList(pHead1, pHead2);
            LinkedListNode<int>.Print(pMergedHead);

            Console.WriteLine("\n\n");

            return pMergedHead;
        }

        // list1: 1->3->5
        // list2: 2->4->6
        public static void P147Test1()
        {
            var pNode1 = LinkedListNode<int>.Create(1);
            var pNode3 = LinkedListNode<int>.Create(3);
            var pNode5 = LinkedListNode<int>.Create(5);

            LinkedListNode<int>.Connect(pNode1, pNode3);
            LinkedListNode<int>.Connect(pNode3, pNode5);

            var pNode2 = LinkedListNode<int>.Create(2);
            var pNode4 = LinkedListNode<int>.Create(4);
            var pNode6 = LinkedListNode<int>.Create(6);

            LinkedListNode<int>.Connect(pNode2, pNode4);
            LinkedListNode<int>.Connect(pNode4, pNode6);

            var pMergedHead = P147Test("P147Test1", pNode1, pNode2);
        }

        // 两个链表中有重复的数字
        // list1: 1->3->5
        // list2: 1->3->5
        public static void P147Test2()
        {
            var pNode1 = LinkedListNode<int>.Create(1);
            var pNode3 = LinkedListNode<int>.Create(3);
            var pNode5 = LinkedListNode<int>.Create(5);

            LinkedListNode<int>.Connect(pNode1, pNode3);
            LinkedListNode<int>.Connect(pNode3, pNode5);

            var pNode2 = LinkedListNode<int>.Create(1);
            var pNode4 = LinkedListNode<int>.Create(3);
            var pNode6 = LinkedListNode<int>.Create(5);

            LinkedListNode<int>.Connect(pNode2, pNode4);
            LinkedListNode<int>.Connect(pNode4, pNode6);

            var pMergedHead = P147Test("P147Test2", pNode1, pNode2);
        }

        // 两个链表都只有一个数字
        // list1: 1
        // list2: 2
        public static void P147Test3()
        {
            var pNode1 = LinkedListNode<int>.Create(1);
            var pNode2 = LinkedListNode<int>.Create(2);

            var pMergedHead = P147Test("P147Test3", pNode1, pNode2);
        }

        // 一个链表为空链表
        // list1: 1->3->5
        // list2: 空链表
        public static void P147Test4()
        {
            var pNode1 = LinkedListNode<int>.Create(1);
            var pNode3 = LinkedListNode<int>.Create(3);
            var pNode5 = LinkedListNode<int>.Create(5);

            LinkedListNode<int>.Connect(pNode1, pNode3);
            LinkedListNode<int>.Connect(pNode3, pNode5);

            var pMergedHead = P147Test("P147Test4", pNode1, null);
        }

        // 两个链表都为空链表
        // list1: 空链表
        // list2: 空链表
        public static void P147Test5()
        {
            var pMergedHead = P147Test("P147Test5", null, null);
        }
    }
}