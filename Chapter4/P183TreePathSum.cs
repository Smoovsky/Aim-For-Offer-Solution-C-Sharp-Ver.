using System.Collections.Generic;

namespace Algorithm.Chapter4;

public static partial class Solution
{
    public static void P183TreePathSum(
        TreeNode<int>? current,
        Stack<int>? path,
        int expected)
    {
        if (current == null)
        {
            return;
        }

        path ??= new();
        path.Push(current.Value);

        if (current.Left == null
            && current.Right == null
            && path.Sum() == expected)
        {
            Console.WriteLine($"Path found: {string.Join(", ", path.Select(i => i.ToString()))}");
        }

        if (current.Left != null)
        {
            P183TreePathSum(current.Left, path, expected);
        }

        if (current.Right != null)
        {
            P183TreePathSum(current.Right, path, expected);
        }

        path.Pop();
    }

    // ====================测试代码====================
    public static void P183Test(string P183TestName, TreeNode<int>? pRoot, int expectedSum)
    {
        if (P183TestName != null)
            Console.Write($"{P183TestName} begins:\n");

        P183TreePathSum(pRoot, null, expectedSum);

        Console.Write("\n");
    }

    //            10
    //         /      \
    //        5        12
    //       /\        
    //      4  7     
    // 有两条路径上的结点和为22
    public static void P183Test1()
    {
        TreeNode<int>? pNode10 = new(10);
        TreeNode<int>? pNode5 = new(5);
        TreeNode<int>? pNode12 = new(12);
        TreeNode<int>? pNode4 = new(4);
        TreeNode<int>? pNode7 = new(7);

        TreeNode<int>.ConnectTreeNodes(pNode10, pNode5, pNode12);
        TreeNode<int>.ConnectTreeNodes(pNode5, pNode4, pNode7);

        Console.Write("Two paths should be found in P183Test1.\n");
        P183Test("P183Test1", pNode10, 22);


    }

    //            10
    //         /      \
    //        5        12
    //       /\        
    //      4  7     
    // 没有路径上的结点和为15
    public static void P183Test2()
    {
        TreeNode<int>? pNode10 = new(10);
        TreeNode<int>? pNode5 = new(5);
        TreeNode<int>? pNode12 = new(12);
        TreeNode<int>? pNode4 = new(4);
        TreeNode<int>? pNode7 = new(7);

        TreeNode<int>.ConnectTreeNodes(pNode10, pNode5, pNode12);
        TreeNode<int>.ConnectTreeNodes(pNode5, pNode4, pNode7);

        Console.Write("No paths should be found in P183Test2.\n");
        P183Test("P183Test2", pNode10, 15);


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
    // 有一条路径上面的结点和为15
    public static void P183Test3()
    {
        TreeNode<int>? pNode5 = new(5);
        TreeNode<int>? pNode4 = new(4);
        TreeNode<int>? pNode3 = new(3);
        TreeNode<int>? pNode2 = new(2);
        TreeNode<int>? pNode1 = new(1);

        TreeNode<int>.ConnectTreeNodes(pNode5, pNode4, null);
        TreeNode<int>.ConnectTreeNodes(pNode4, pNode3, null);
        TreeNode<int>.ConnectTreeNodes(pNode3, pNode2, null);
        TreeNode<int>.ConnectTreeNodes(pNode2, pNode1, null);

        Console.Write("One path should be found in P183Test3.\n");
        P183Test("P183Test3", pNode5, 15);


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
    // 没有路径上面的结点和为16
    public static void P183Test4()
    {
        TreeNode<int>? pNode1 = new(1);
        TreeNode<int>? pNode2 = new(2);
        TreeNode<int>? pNode3 = new(3);
        TreeNode<int>? pNode4 = new(4);
        TreeNode<int>? pNode5 = new(5);

        TreeNode<int>.ConnectTreeNodes(pNode1, null, pNode2);
        TreeNode<int>.ConnectTreeNodes(pNode2, null, pNode3);
        TreeNode<int>.ConnectTreeNodes(pNode3, null, pNode4);
        TreeNode<int>.ConnectTreeNodes(pNode4, null, pNode5);

        Console.Write("No paths should be found in P183Test4.\n");
        P183Test("P183Test4", pNode1, 16);


    }

    // 树中只有1个结点
    public static void P183Test5()
    {
        TreeNode<int>? pNode1 = new(1);

        Console.Write("One path should be found in P183Test5.\n");
        P183Test("P183Test5", pNode1, 1);


    }

    // 树中没有结点
    public static void P183Test6()
    {
        Console.Write("No paths should be found in P183Test6.\n");
        P183Test("P183Test6", null, 0);
    }
}
