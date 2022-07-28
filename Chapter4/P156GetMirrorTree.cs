namespace Algorithm.Chapter4;

public static partial class Solution
{
    public static void P156GetMirrorTree<T>(TreeNode<T>? root) where T : struct
    {
        if (root == null)
        {
            return;
        }

        (root.Left, root.Right) = (root.Right, root.Left);

        P156GetMirrorTree(root.Left);
        P156GetMirrorTree(root.Right);
    }
    // ====================测试代码====================
    // 测试完全二叉树：除了叶子节点，其他节点都有两个子节点
    //            8
    //        6      10
    //       5 7    9  11
    public static void P156Test1()
    {
        Console.WriteLine("=====P156Test1 starts:=====\n");
        var pNode8 = new TreeNode<int>(8);
        var pNode6 = new TreeNode<int>(6);
        var pNode10 = new TreeNode<int>(10);
        var pNode5 = new TreeNode<int>(5);
        var pNode7 = new TreeNode<int>(7);
        var pNode9 = new TreeNode<int>(9);
        var pNode11 = new TreeNode<int>(11);

        TreeNode<int>.ConnectTreeNodes(pNode8, pNode6, pNode10);
        TreeNode<int>.ConnectTreeNodes(pNode6, pNode5, pNode7);
        TreeNode<int>.ConnectTreeNodes(pNode10, pNode9, pNode11);

        TreeNode<int>.Print2D(pNode8);

        Console.WriteLine("=====P156Test1: P156GetMirrorTree=====\n");
        P156GetMirrorTree(pNode8);
        TreeNode<int>.Print2D(pNode8);

        Console.WriteLine("=====P156Test1: P156GetMirrorTree=====\n");
        P156GetMirrorTree(pNode8);
        TreeNode<int>.Print2D(pNode8);

        
    }

    // 测试二叉树：出叶子结点之外，左右的结点都有且只有一个左子结点
    //            8
    //          7   
    //        6 
    //      5
    //    4
    public static void P156Test2()
    {
        Console.WriteLine("=====P156Test2 starts:=====\n");
        var pNode8 = new TreeNode<int>(8);
        var pNode7 = new TreeNode<int>(7);
        var pNode6 = new TreeNode<int>(6);
        var pNode5 = new TreeNode<int>(5);
        var pNode4 = new TreeNode<int>(4);

        TreeNode<int>.ConnectTreeNodes(pNode8, pNode7, null);
        TreeNode<int>.ConnectTreeNodes(pNode7, pNode6, null);
        TreeNode<int>.ConnectTreeNodes(pNode6, pNode5, null);
        TreeNode<int>.ConnectTreeNodes(pNode5, pNode4, null);

        TreeNode<int>.Print2D(pNode8);

        Console.WriteLine("=====P156Test2: P156GetMirrorTree=====\n");
        P156GetMirrorTree(pNode8);
        TreeNode<int>.Print2D(pNode8);

        Console.WriteLine("=====P156Test2: P156GetMirrorTree=====\n");
        P156GetMirrorTree(pNode8);
        TreeNode<int>.Print2D(pNode8);

        
    }

    // 测试二叉树：出叶子结点之外，左右的结点都有且只有一个右子结点
    //            8
    //             7   
    //              6 
    //               5
    //                4
    public static void P156Test3()
    {
        Console.WriteLine("=====P156Test3 starts:=====\n");
        var pNode8 = new TreeNode<int>(8);
        var pNode7 = new TreeNode<int>(7);
        var pNode6 = new TreeNode<int>(6);
        var pNode5 = new TreeNode<int>(5);
        var pNode4 = new TreeNode<int>(4);

        TreeNode<int>.ConnectTreeNodes(pNode8, null, pNode7);
        TreeNode<int>.ConnectTreeNodes(pNode7, null, pNode6);
        TreeNode<int>.ConnectTreeNodes(pNode6, null, pNode5);
        TreeNode<int>.ConnectTreeNodes(pNode5, null, pNode4);

        TreeNode<int>.Print2D(pNode8);

        Console.WriteLine("=====P156Test3: P156GetMirrorTree=====\n");
        P156GetMirrorTree(pNode8);
        TreeNode<int>.Print2D(pNode8);

        Console.WriteLine("=====P156Test3: P156GetMirrorTree=====\n");
        P156GetMirrorTree(pNode8);
        TreeNode<int>.Print2D(pNode8);

        
    }

    // 测试空二叉树：根结点为空指针
    public static void P156Test4()
    {
        Console.WriteLine("=====P156Test4 starts:=====\n");
        TreeNode<int> pNode = null;

        TreeNode<int>.Print2D(pNode);

        Console.WriteLine("=====P156Test4: P156GetMirrorTree=====\n");
        P156GetMirrorTree(pNode);
        TreeNode<int>.Print2D(pNode);

        Console.WriteLine("=====P156Test4: P156GetMirrorTree=====\n");
        P156GetMirrorTree(pNode);
        TreeNode<int>.Print2D(pNode);
    }

    // 测试只有一个结点的二叉树
    public static void P156Test5()
    {
        Console.WriteLine("=====P156Test5 starts:=====\n");
        var pNode8 = new TreeNode<int>(8);

        TreeNode<int>.Print2D(pNode8);

        Console.WriteLine("=====P156Test4: P156GetMirrorTree=====\n");
        P156GetMirrorTree(pNode8);
        TreeNode<int>.Print2D(pNode8);

        Console.WriteLine("=====P156Test4: P156GetMirrorTree=====\n");
        P156GetMirrorTree(pNode8);
        TreeNode<int>.Print2D(pNode8);
    }
}
