namespace Algorithm.Chapter3
{
    public static partial class Solution
    {
        public static LinkedListNode<T> P140MidOfLoopNodes<T>(
            LinkedListNode<T> headNode)
        {
            if (headNode == null)
            {
                return null;
            }

            var p1 = headNode;
            var p2 = headNode;

            while (p1.Next != null
                && p2.Next != null)
            {
                p1 = p1.Next;
                p2 = p2.Next;

                if (p2.Next == p1)
                {
                    return p2.Next;
                }

                if (p2.Next != null)
                {
                    p2 = p2.Next;
                }
            }

            return null;
        }

        public static LinkedListNode<T> P140EntryOfLoopNodes<T>(
            LinkedListNode<T> headNode)
        {
            var midPoint = P140MidOfLoopNodes(headNode);

            if (midPoint == null)
            {
                return null;
            }

            var p1 = midPoint;

            int loopLength = 1;

            while (p1!.Next != midPoint)
            {
                loopLength++;
                p1 = p1.Next;
            }

            if (loopLength == 1)
            {
                return midPoint;
            }

            p1 = headNode;
            var p2 = headNode;

            for (int i = 0; i < loopLength; i++)
            {
                p1 = p1!.Next;
            }

            while (p1 != p2)
            {
                p1 = p1!.Next;
                p2 = p2!.Next;
            }

            return p1;
        }

        // ==================== Test Code ====================
        public static void P140Test(string testName, LinkedListNode<int> pHead, LinkedListNode<int> entryNode)
        {
            if (testName != null)
                Console.Write($"{testName} begins: ");

            if (P140EntryOfLoopNodes<int>(pHead) == entryNode)
                Console.Write("Passed.\n");
            else
                Console.Write("FAILED.\n");
        }

        // A list has a node, without a loop
        public static void P140Test1()
        {
            LinkedListNode<int> pNode1 = LinkedListNode<int>.Create(1);

            P140Test("Test1", pNode1, null);            
        }

        // A list has a node, with a loop
        public static void P140Test2()
        {
            LinkedListNode<int> pNode1 = LinkedListNode<int>.Create(1);
            LinkedListNode<int>.Connect(pNode1, pNode1);

            P140Test("Test2", pNode1, pNode1);
        }

        // A list has multiple nodes, with a loop 
        public static void P140Test3()
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
            LinkedListNode<int>.Connect(pNode5, pNode3);

            P140Test("Test3", pNode1, pNode3);
        }

        // A list has multiple nodes, with a loop 
        public static void P140Test4()
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
            LinkedListNode<int>.Connect(pNode5, pNode1);

            P140Test("Test4", pNode1, pNode1);
        }

        // A list has multiple nodes, with a loop 
        public static void P140Test5()
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
            LinkedListNode<int>.Connect(pNode5, pNode5);

            P140Test("Test5", pNode1, pNode5);
        }

        // A list has multiple nodes, without a loop 
        public static void P140Test6()
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

            P140Test("Test6", pNode1, null);
        }

        // Empty list
        public static void P140Test7()
        {
            P140Test("Test7", null, null);
        }
    }
}