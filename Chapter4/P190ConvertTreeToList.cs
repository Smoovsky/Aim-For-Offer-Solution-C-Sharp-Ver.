namespace Algorithm.Chapter4;

public static partial class Solution
{
    public static TreeNode<int> P190ConvertTreeToList(
        TreeNode<int>? root)
    {
        if (root == null)
        {
            return null;
        }

        TreeNode<int>? result = null;

        P190ConvertTreeToListCore(root, ref result);

        while (result?.Left != null)
        {
            result = result.Left;
        }

        return result;
    }

    public static void P190ConvertTreeToListCore(
        TreeNode<int> current,
        ref TreeNode<int>? lastInList)
    {
        if (current.Left != null)
        {
            P190ConvertTreeToListCore(current.Left, ref lastInList);
        }

        current.Left = lastInList;

        if (lastInList != null)
        {
            lastInList.Right = current;
        }

        lastInList = current;

        if (current.Right != null)
        {
            P190ConvertTreeToListCore(current.Right, ref lastInList);
        }
    }

    public static void PrintDoubleLinkedList(TreeNode<int> pHeadOfList)
    {
        TreeNode<int> pNode = pHeadOfList;

        Console.Write("The nodes from left to right are:\n");

        while (pNode != null)
        {
            Console.Write($"{pNode.Value}\t");

            if (pNode.Right == null)
                break;
            pNode = pNode.Right;
        }

        Console.Write("\nThe nodes from right to left are:\n");
        while (pNode != null)
        {
            Console.Write($"{pNode.Value}\t");

            if (pNode.Left == null)
                break;
            pNode = pNode.Left;
        }

        Console.Write("\n");
    }

    public static void P190Test(string testName, TreeNode<int>? pRootOfTree)
    {
        if (testName != null)
            Console.Write($"{testName} begins:\n");

        TreeNode<int>.Print2D(pRootOfTree);

        var pHeadOfList = P190ConvertTreeToList(pRootOfTree);

        PrintDoubleLinkedList(pHeadOfList);
    }

    //            10
    //         /      \
    //        6        14
    //       /\        /\
    //      4  8     12  16
    public static void P190Test1()
    {
        TreeNode<int> pNode10 = new(10);
        TreeNode<int> pNode6 = new(6);
        TreeNode<int> pNode14 = new(14);
        TreeNode<int> pNode4 = new(4);
        TreeNode<int> pNode8 = new(8);
        TreeNode<int> pNode12 = new(12);
        TreeNode<int> pNode16 = new(16);

        TreeNode<int>.ConnectTreeNodes(pNode10, pNode6, pNode14);
        TreeNode<int>.ConnectTreeNodes(pNode6, pNode4, pNode8);
        TreeNode<int>.ConnectTreeNodes(pNode14, pNode12, pNode16);

        P190Test("P190Test1", pNode10);
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
    public static void P190Test2()
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

        P190Test("P190Test2", pNode5);
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
    public static void P190Test3()
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

        P190Test("P190Test3", pNode1);


    }

    // 树中只有1个结点
    public static void P190Test4()
    {
        TreeNode<int> pNode1 = new(1);
        P190Test("P190Test4", pNode1);
    }

    // 树中没有结点
    public static void P190Test5()
    {
        P190Test("P190Test5", null);
    }
}
