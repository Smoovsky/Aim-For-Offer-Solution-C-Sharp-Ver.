namespace Algorithm.Chapter6;

public static partial class Solution
{
    public static TreeNode<int>? P268KthNodeOfBST(
        TreeNode<int>? root,
        int k,
        ref int current)
    {
        if (root == null)
        {
            return null;
        }

        var l = P268KthNodeOfBST(root.Left, k, ref current);

        if (l != null)
        {
            return l;
        }

        current++;

        if (current == k)
        {
            return root;
        }

        var r = P268KthNodeOfBST(root.Right, k, ref current);

        if (r != null)
        {
            return r;
        }

        return null;
    }

    // ====================测试代码====================
    public static void P268Test(string testName, TreeNode<int> pRoot, int k, bool isNull, int expected)
    {
        if (testName != null)
            Console.Write($"{testName} begins: ");

        var i = 0;

        TreeNode<int> pTarget = P268KthNodeOfBST(pRoot, k, ref i);
        if ((isNull && pTarget == null) || (!isNull && pTarget!.Value == expected))
            Console.Write("Passed.\n");
        else
            Console.Write("FAILED.\n");
    }

    //            8
    //        6      10
    //       5 7    9  11
    public static void P268TestA()
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

        P268Test("TestA0", pNode8, 0, true, -1);
        P268Test("TestA1", pNode8, 1, false, 5);
        P268Test("TestA2", pNode8, 2, false, 6);
        P268Test("TestA3", pNode8, 3, false, 7);
        P268Test("TestA4", pNode8, 4, false, 8);
        P268Test("TestA5", pNode8, 5, false, 9);
        P268Test("TestA6", pNode8, 6, false, 10);
        P268Test("TestA7", pNode8, 7, false, 11);
        P268Test("TestA8", pNode8, 8, true, -1);

        

        Console.Write("\n\n");
    }

    //               5
    //              /
    //             4
    //            /
    //           3
    //          /
    //         2
    //        /
    //       1
    public static void P268TestB()
    {
        TreeNode<int> pNode5 = new(5);
        TreeNode<int> pNode4 = new(4);
        TreeNode<int> pNode3 = new(3);
        TreeNode<int> pNode2 = new(2);
        TreeNode<int> pNode1 = new(1);

        TreeNode<int>.ConnectTreeNodes(pNode5, pNode4, null);
        TreeNode<int>.ConnectTreeNodes(pNode4, pNode3, null);
        TreeNode<int>.ConnectTreeNodes(pNode3, pNode2, null);
        TreeNode<int>.ConnectTreeNodes(pNode2, pNode1, null);

        P268Test("TestB0", pNode5, 0, true, -1);
        P268Test("TestB1", pNode5, 1, false, 1);
        P268Test("TestB2", pNode5, 2, false, 2);
        P268Test("TestB3", pNode5, 3, false, 3);
        P268Test("TestB4", pNode5, 4, false, 4);
        P268Test("TestB5", pNode5, 5, false, 5);
        P268Test("TestB6", pNode5, 6, true, -1);

        

        Console.Write("\n\n");
    }

    // 1
    //  \
    //   2
    //    \
    //     3
    //      \
    //       4
    //        \
    //         5
    public static void P268TestC()
    {
        TreeNode<int> pNode1 = new(1);
        TreeNode<int> pNode2 = new(2);
        TreeNode<int> pNode3 = new(3);
        TreeNode<int> pNode4 = new(4);
        TreeNode<int> pNode5 = new(5);

        TreeNode<int>.ConnectTreeNodes(pNode1, null, pNode2);
        TreeNode<int>.ConnectTreeNodes(pNode2, null, pNode3);
        TreeNode<int>.ConnectTreeNodes(pNode3, null, pNode4);
        TreeNode<int>.ConnectTreeNodes(pNode4, null, pNode5);

        P268Test("TestC0", pNode1, 0, true, -1);
        P268Test("TestC1", pNode1, 1, false, 1);
        P268Test("TestC2", pNode1, 2, false, 2);
        P268Test("TestC3", pNode1, 3, false, 3);
        P268Test("TestC4", pNode1, 4, false, 4);
        P268Test("TestC5", pNode1, 5, false, 5);
        P268Test("TestC6", pNode1, 6, true, -1);

        

        Console.Write("\n\n");
    }

    // There is only one node in a tree
    public static void P268TestD()
    {
        TreeNode<int> pNode1 = new(1);

        P268Test("TestD0", pNode1, 0, true, -1);
        P268Test("TestD1", pNode1, 1, false, 1);
        P268Test("TestD2", pNode1, 2, true, -1);

        

        Console.Write("\n\n");
    }

    // empty tree
    public static void P268TestE()
    {
        P268Test("TestE0", null, 0, true, -1);
        P268Test("TestE1", null, 1, true, -1);

        Console.Write("\n\n");
    }

    public static void P268Test()
    {
        P268TestA();
        P268TestB();
        P268TestC();
        P268TestD();
        P268TestE();
    }
}
