namespace Algorithm.Chapter6;

public static partial class Solution
{
    public static int P271TreeDepth(
        TreeNode<int>? root)
    {
        if (root == null)
        {
            return 0;
        }

        var l = P271TreeDepth(root.Left);
        var r = P271TreeDepth(root.Right);

        return l > r
            ? ++l
            : ++r;
    }

    // ====================测试代码====================
    public static void P271Test(string testName, TreeNode<int> pRoot, int expected)
    {
        int result = P271TreeDepth(pRoot);
        if (expected == result)
            Console.Write($"{testName} passed.\n");
        else
            Console.Write($"{testName} FAILED.\n");
    }

    //            1
    //         /      \
    //        2        3
    //       /\         \
    //      4  5         6
    //        /
    //       7
    public static void P271Test1()
    {
        TreeNode<int> pNode1 = new(1);
        TreeNode<int> pNode2 = new(2);
        TreeNode<int> pNode3 = new(3);
        TreeNode<int> pNode4 = new(4);
        TreeNode<int> pNode5 = new(5);
        TreeNode<int> pNode6 = new(6);
        TreeNode<int> pNode7 = new(7);

        TreeNode<int>.ConnectTreeNodes(pNode1, pNode2, pNode3);
        TreeNode<int>.ConnectTreeNodes(pNode2, pNode4, pNode5);
        TreeNode<int>.ConnectTreeNodes(pNode3, null, pNode6);
        TreeNode<int>.ConnectTreeNodes(pNode5, pNode7, null);

        P271Test("Test1", pNode1, 4);


    }

    //               1
    //              /
    //             2
    //            /
    //           3
    //          /
    //         4
    //        /
    //       5
    public static void P271Test2()
    {
        TreeNode<int> pNode1 = new(1);
        TreeNode<int> pNode2 = new(2);
        TreeNode<int> pNode3 = new(3);
        TreeNode<int> pNode4 = new(4);
        TreeNode<int> pNode5 = new(5);

        TreeNode<int>.ConnectTreeNodes(pNode1, pNode2, null);
        TreeNode<int>.ConnectTreeNodes(pNode2, pNode3, null);
        TreeNode<int>.ConnectTreeNodes(pNode3, pNode4, null);
        TreeNode<int>.ConnectTreeNodes(pNode4, pNode5, null);

        P271Test("Test2", pNode1, 5);


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
    public static void P271Test3()
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

        P271Test("Test3", pNode1, 5);


    }

    // 树中只有1个结点
    public static void P271Test4()
    {
        TreeNode<int> pNode1 = new(1);
        P271Test("Test4", pNode1, 1);


    }

    // 树中没有结点
    public static void P271Test5()
    {
        P271Test("Test5", null, 0);
    }

    public static void P271Test()
    {
        P271Test1();
        P271Test2();
        P271Test3();
        P271Test4();
        P271Test5();
    }
}
