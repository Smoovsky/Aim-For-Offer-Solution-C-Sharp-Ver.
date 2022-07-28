namespace Algorithm.Chapter2
{
    public static partial class Solution
    {
        public static TreeNode<T> NextNodeInOrderP64<T>(TreeNode<T> currentNode) where T : struct
        {
            if (currentNode == null)
            {
                return null;
            }

            TreeNode<T> pNext;

            if (currentNode.Right != null)
            {
                pNext = currentNode.Right;

                while (pNext.Left != null)
                {
                    pNext = pNext.Left;
                }

                return pNext;
            }

            pNext = currentNode;

            while (pNext != null && pNext.Parent?.Left != pNext)
            {
                pNext = pNext.Parent;
            }

            return pNext?.Parent;
        }

        public static void Test(string testName, TreeNode<int> pNode, TreeNode<int> expected)
        {
            if (testName != null)
                Console.Write("{0} begins: ", testName);

            TreeNode<int> pNext = NextNodeInOrderP64(pNode);
            if (pNext == expected)
                Console.Write("Passed.\n");
            else
                Console.Write("FAILED.\n");
        }

        //            8
        //        6      10
        //       5 7    9  11
        public static void Test1_7()
        {
            TreeNode<int> pNode8 = new(8);
            TreeNode<int> pNode6 = new(6);
            TreeNode<int> pNode10 = new(10);
            TreeNode<int> pNode5 = new(5);
            TreeNode<int> pNode7 = new(7);
            TreeNode<int> pNode9 = new(9);
            TreeNode<int> pNode11 = new(11);

            TreeNode<int>.ConnectTreeNodes(pNode8, pNode6, pNode10);
            TreeNode<int>.ConnectTreeNodes(pNode6, pNode5, pNode7);
            TreeNode<int>.ConnectTreeNodes(pNode10, pNode9, pNode11);

            Test("Test1", pNode8, pNode9);
            Test("Test2", pNode6, pNode7);
            Test("Test3", pNode10, pNode11);
            Test("Test4", pNode5, pNode6);
            Test("Test5", pNode7, pNode8);
            Test("Test6", pNode9, pNode10);
            Test("Test7", pNode11, null);
        }

        //            5
        //          4
        //        3
        //      2
        public static void Test8_11()
        {
            TreeNode<int> pNode5 = new(5);
            TreeNode<int> pNode4 = new(4);
            TreeNode<int> pNode3 = new(3);
            TreeNode<int> pNode2 = new(2);

            TreeNode<int>.ConnectTreeNodes(pNode5, pNode4, null);
            TreeNode<int>.ConnectTreeNodes(pNode4, pNode3, null);
            TreeNode<int>.ConnectTreeNodes(pNode3, pNode2, null);

            Test("Test8", pNode5, null);
            Test("Test9", pNode4, pNode5);
            Test("Test10", pNode3, pNode4);
            Test("Test11", pNode2, pNode3);
        }

        //        2
        //         3
        //          4
        //           5
        public static void Test12_15()
        {
            TreeNode<int> pNode2 = new(2);
            TreeNode<int> pNode3 = new(3);
            TreeNode<int> pNode4 = new(4);
            TreeNode<int> pNode5 = new(5);

            TreeNode<int>.ConnectTreeNodes(pNode2, null, pNode3);
            TreeNode<int>.ConnectTreeNodes(pNode3, null, pNode4);
            TreeNode<int>.ConnectTreeNodes(pNode4, null, pNode5);

            Test("Test12", pNode5, null);
            Test("Test13", pNode4, pNode5);
            Test("Test14", pNode3, pNode4);
            Test("Test15", pNode2, pNode3);
        }

        public static void Test16()
        {
            TreeNode<int> pNode5 = new(5);

            Test("Test16", pNode5, null);
        }
    }
}