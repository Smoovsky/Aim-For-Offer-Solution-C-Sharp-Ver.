namespace Algorithm.Chapter4;

public static partial class Solution
{
    public static bool P160IsTreeSymmetric<T>(TreeNode<T>? root) where T : struct => P160IsTreeSymmetricCore(root, root);

    public static bool P160IsTreeSymmetricCore<T>(
        TreeNode<T>? tree1,
        TreeNode<T>? tree2) where T : struct
    {
        if (tree1 == null && tree2 == null)
        {
            return true;
        }

        if (tree1 == null || tree2 == null)
        {
            return false;
        }

        if (tree1.Value.Equals(tree2.Value) != true)
        {
            return false;
        }

        return P160IsTreeSymmetricCore(tree1.Left, tree2.Right)
            && P160IsTreeSymmetricCore(tree1.Right, tree2.Left);
    }

    // ====================测试代码====================
    public static void P160Test(string P160TestName, TreeNode<int> pRoot, bool expected)
    {
        if (P160TestName != null)
            Console.WriteLine($"{P160TestName} begins: ");

        if (P160IsTreeSymmetric(pRoot) == expected)
            Console.WriteLine("Passed.\n");
        else
            Console.WriteLine("FAILED.\n");
    }

    //            8
    //        6      6
    //       5 7    7 5
    public static void P160Test1()
    {
        TreeNode<int> pNode8 = new(8);
        TreeNode<int> pNode61 = new(6);
        TreeNode<int> pNode62 = new(6);
        TreeNode<int> pNode51 = new(5);
        TreeNode<int> pNode71 = new(7);
        TreeNode<int> pNode72 = new(7);
        TreeNode<int> pNode52 = new(5);

        TreeNode<int>.ConnectTreeNodes(pNode8, pNode61, pNode62);
        TreeNode<int>.ConnectTreeNodes(pNode61, pNode51, pNode71);
        TreeNode<int>.ConnectTreeNodes(pNode62, pNode72, pNode52);

        P160Test("P160Test1", pNode8, true);


    }

    //            8
    //        6      9
    //       5 7    7 5
    public static void P160Test2()
    {
        TreeNode<int> pNode8 = new(8);
        TreeNode<int> pNode61 = new(6);
        TreeNode<int> pNode9 = new(9);
        TreeNode<int> pNode51 = new(5);
        TreeNode<int> pNode71 = new(7);
        TreeNode<int> pNode72 = new(7);
        TreeNode<int> pNode52 = new(5);

        TreeNode<int>.ConnectTreeNodes(pNode8, pNode61, pNode9);
        TreeNode<int>.ConnectTreeNodes(pNode61, pNode51, pNode71);
        TreeNode<int>.ConnectTreeNodes(pNode9, pNode72, pNode52);

        P160Test("P160Test2", pNode8, false);


    }

    //            8
    //        6      6
    //       5 7    7
    public static void P160Test3()
    {
        TreeNode<int> pNode8 = new(8);
        TreeNode<int> pNode61 = new(6);
        TreeNode<int> pNode62 = new(6);
        TreeNode<int> pNode51 = new(5);
        TreeNode<int> pNode71 = new(7);
        TreeNode<int> pNode72 = new(7);

        TreeNode<int>.ConnectTreeNodes(pNode8, pNode61, pNode62);
        TreeNode<int>.ConnectTreeNodes(pNode61, pNode51, pNode71);
        TreeNode<int>.ConnectTreeNodes(pNode62, pNode72, null);

        P160Test("P160Test3", pNode8, false);


    }

    //               5
    //              / \
    //             3   3
    //            /     \
    //           4       4
    //          /         \
    //         2           2
    //        /             \
    //       1               1
    public static void P160Test4()
    {
        TreeNode<int> pNode5 = new(5);
        TreeNode<int> pNode31 = new(3);
        TreeNode<int> pNode32 = new(3);
        TreeNode<int> pNode41 = new(4);
        TreeNode<int> pNode42 = new(4);
        TreeNode<int> pNode21 = new(2);
        TreeNode<int> pNode22 = new(2);
        TreeNode<int> pNode11 = new(1);
        TreeNode<int> pNode12 = new(1);

        TreeNode<int>.ConnectTreeNodes(pNode5, pNode31, pNode32);
        TreeNode<int>.ConnectTreeNodes(pNode31, pNode41, null);
        TreeNode<int>.ConnectTreeNodes(pNode32, null, pNode42);
        TreeNode<int>.ConnectTreeNodes(pNode41, pNode21, null);
        TreeNode<int>.ConnectTreeNodes(pNode42, null, pNode22);
        TreeNode<int>.ConnectTreeNodes(pNode21, pNode11, null);
        TreeNode<int>.ConnectTreeNodes(pNode22, null, pNode12);

        P160Test("P160Test4", pNode5, true);


    }


    //               5
    //              / \
    //             3   3
    //            /     \
    //           4       4
    //          /         \
    //         6           2
    //        /             \
    //       1               1
    public static void P160Test5()
    {
        TreeNode<int> pNode5 = new(5);
        TreeNode<int> pNode31 = new(3);
        TreeNode<int> pNode32 = new(3);
        TreeNode<int> pNode41 = new(4);
        TreeNode<int> pNode42 = new(4);
        TreeNode<int> pNode6 = new(6);
        TreeNode<int> pNode22 = new(2);
        TreeNode<int> pNode11 = new(1);
        TreeNode<int> pNode12 = new(1);

        TreeNode<int>.ConnectTreeNodes(pNode5, pNode31, pNode32);
        TreeNode<int>.ConnectTreeNodes(pNode31, pNode41, null);
        TreeNode<int>.ConnectTreeNodes(pNode32, null, pNode42);
        TreeNode<int>.ConnectTreeNodes(pNode41, pNode6, null);
        TreeNode<int>.ConnectTreeNodes(pNode42, null, pNode22);
        TreeNode<int>.ConnectTreeNodes(pNode6, pNode11, null);
        TreeNode<int>.ConnectTreeNodes(pNode22, null, pNode12);

        P160Test("P160Test5", pNode5, false);


    }

    //               5
    //              / \
    //             3   3
    //            /     \
    //           4       4
    //          /         \
    //         2           2
    //                      \
    //                       1
    public static void P160Test6()
    {
        TreeNode<int> pNode5 = new(5);
        TreeNode<int> pNode31 = new(3);
        TreeNode<int> pNode32 = new(3);
        TreeNode<int> pNode41 = new(4);
        TreeNode<int> pNode42 = new(4);
        TreeNode<int> pNode21 = new(2);
        TreeNode<int> pNode22 = new(2);
        TreeNode<int> pNode12 = new(1);

        TreeNode<int>.ConnectTreeNodes(pNode5, pNode31, pNode32);
        TreeNode<int>.ConnectTreeNodes(pNode31, pNode41, null);
        TreeNode<int>.ConnectTreeNodes(pNode32, null, pNode42);
        TreeNode<int>.ConnectTreeNodes(pNode41, pNode21, null);
        TreeNode<int>.ConnectTreeNodes(pNode42, null, pNode22);
        TreeNode<int>.ConnectTreeNodes(pNode21, null, null);
        TreeNode<int>.ConnectTreeNodes(pNode22, null, pNode12);

        P160Test("P160Test6", pNode5, false);


    }

    // 只有一个结点
    public static void P160Test7()
    {
        TreeNode<int> pNode1 = new(1);
        P160Test("P160Test7", pNode1, true);


    }

    // 没有结点
    public static void P160Test8()
    {
        P160Test("P160Test8", null, true);
    }

    // 所有结点都有相同的值，树对称
    //               5
    //              / \
    //             5   5
    //            /     \
    //           5       5
    //          /         \
    //         5           5
    public static void P160Test9()
    {
        TreeNode<int> pNode1 = new(5);
        TreeNode<int> pNode21 = new(5);
        TreeNode<int> pNode22 = new(5);
        TreeNode<int> pNode31 = new(5);
        TreeNode<int> pNode32 = new(5);
        TreeNode<int> pNode41 = new(5);
        TreeNode<int> pNode42 = new(5);

        TreeNode<int>.ConnectTreeNodes(pNode1, pNode21, pNode22);
        TreeNode<int>.ConnectTreeNodes(pNode21, pNode31, null);
        TreeNode<int>.ConnectTreeNodes(pNode22, null, pNode32);
        TreeNode<int>.ConnectTreeNodes(pNode31, pNode41, null);
        TreeNode<int>.ConnectTreeNodes(pNode32, null, pNode42);
        TreeNode<int>.ConnectTreeNodes(pNode41, null, null);
        TreeNode<int>.ConnectTreeNodes(pNode42, null, null);

        P160Test("P160Test9", pNode1, true);


    }

    // 所有结点都有相同的值，树不对称
    //               5
    //              / \
    //             5   5
    //            /     \
    //           5       5
    //          /       /
    //         5       5
    public static void P160Test10()
    {
        TreeNode<int> pNode1 = new(5);
        TreeNode<int> pNode21 = new(5);
        TreeNode<int> pNode22 = new(5);
        TreeNode<int> pNode31 = new(5);
        TreeNode<int> pNode32 = new(5);
        TreeNode<int> pNode41 = new(5);
        TreeNode<int> pNode42 = new(5);

        TreeNode<int>.ConnectTreeNodes(pNode1, pNode21, pNode22);
        TreeNode<int>.ConnectTreeNodes(pNode21, pNode31, null);
        TreeNode<int>.ConnectTreeNodes(pNode22, null, pNode32);
        TreeNode<int>.ConnectTreeNodes(pNode31, pNode41, null);
        TreeNode<int>.ConnectTreeNodes(pNode32, pNode42, null);
        TreeNode<int>.ConnectTreeNodes(pNode41, null, null);
        TreeNode<int>.ConnectTreeNodes(pNode42, null, null);

        P160Test("P160Test10", pNode1, false);


    }
}
