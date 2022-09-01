namespace Algorithm.Chapter6;

public static partial class Solution
{
    public static bool P272IsTreeBalanced(
        TreeNode<int>? root,
        ref int current)
    {
        if (root == null)
        {
            return true;
        }

        int left = 0, right = 0;

        return P272IsTreeBalanced(root.Left, ref left)
            && P272IsTreeBalanced(root.Right, ref right)
            && Math.Abs(left - right) <= 1
            && ((current = left > right
                ? ++left
                : ++right) > 0);
    }


    // ====================测试代码====================
    public static void P272Test(string testName, TreeNode<int> pRoot, bool expected)
    {
        if (testName != null)
            Console.Write($"{testName} begins:\n");

        // Console.Write("Solution1 begins: ");
        // if(IsBalanced_Solution1(pRoot) == expected)
        //     Console.Write("Passed.\n");
        // else
        //     Console.Write("Failed.\n");

        // Console.Write("Solution2 begins: ");

        var i = 0;
        if (P272IsTreeBalanced(pRoot, ref i) == expected)
            Console.Write("Passed.\n");
        else
            Console.Write("Failed.\n");
    }

    // 完全二叉树
    //             1
    //         /      \
    //        2        3
    //       /\       / \
    //      4  5     6   7
    public static void P272Test1()
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
        TreeNode<int>.ConnectTreeNodes(pNode3, pNode6, pNode7);

        P272Test("Test1", pNode1, true);


    }

    // 不是完全二叉树，但是平衡二叉树
    //             1
    //         /      \
    //        2        3
    //       /\         \
    //      4  5         6
    //        /
    //       7
    public static void P272Test2()
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

        P272Test("Test2", pNode1, true);


    }

    // 不是平衡二叉树
    //             1
    //         /      \
    //        2        3
    //       /\         
    //      4  5        
    //        /
    //       6
    public static void P272Test3()
    {
        TreeNode<int> pNode1 = new(1);
        TreeNode<int> pNode2 = new(2);
        TreeNode<int> pNode3 = new(3);
        TreeNode<int> pNode4 = new(4);
        TreeNode<int> pNode5 = new(5);
        TreeNode<int> pNode6 = new(6);

        TreeNode<int>.ConnectTreeNodes(pNode1, pNode2, pNode3);
        TreeNode<int>.ConnectTreeNodes(pNode2, pNode4, pNode5);
        TreeNode<int>.ConnectTreeNodes(pNode5, pNode6, null);

        P272Test("Test3", pNode1, false);


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
    public static void P272Test4()
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

        P272Test("Test4", pNode1, false);


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
    public static void P272Test5()
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

        P272Test("Test5", pNode1, false);


    }

    // 树中只有1个结点
    public static void P272Test6()
    {
        TreeNode<int> pNode1 = new(1);
        P272Test("Test6", pNode1, true);


    }

    // 树中没有结点
    public static void P272Test7()
    {
        P272Test("Test7", null, true);
    }

    public static void P272Test()
    {
        P272Test1();
        P272Test2();
        P272Test3();
        P272Test4();
        P272Test5();
        P272Test6();
        P272Test7();
    }
}
