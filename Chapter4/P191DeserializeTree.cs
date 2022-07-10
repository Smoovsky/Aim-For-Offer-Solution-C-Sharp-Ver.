using System.Collections.Generic;

namespace Algorithm.Chapter4;

public static partial class Solution
{
    public static TreeNode<int> P191DeserializeTree(
        IEnumerator<string> input)
    {
        if (!input.MoveNext())
        {
            return null;
        }

        if (!int.TryParse(input.Current, out var value))
        {
            return null;
        }

        var root = new TreeNode<int>(value)
        {
            Left = P191DeserializeTree(input),
            Right = P191DeserializeTree(input)
        };

        return root;
    }

    public static string P191SerializeTree(TreeNode<int>? root) =>
        root == null
            ? "$,"
            : ($"{root.Value},"
                + P191SerializeTree(root.Left)
                + P191SerializeTree(root.Right));

    public static void P191Test(string testName, TreeNode<int>? pRoot)
    {
        if (testName != null)
            Console.Write($"{testName} begins: \n");

        TreeNode<int>.Print2D(pRoot);

        var serialized = P191SerializeTree(pRoot).TrimEnd(',');

        Console.WriteLine(serialized);

        var deserialized = P191DeserializeTree(
            (serialized.Split(',') as IEnumerable<string>).GetEnumerator());

        TreeNode<int>.Print2D(deserialized);
    }

    //            8
    //        6      10
    //       5 7    9  11
    public static void P191Test1()
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

        P191Test("P191Test1", pNode8);


    }

    //            5
    //          4
    //        3
    //      2
    public static void P191Test2()
    {
        TreeNode<int> pNode5 = new(5);
        TreeNode<int> pNode4 = new(4);
        TreeNode<int> pNode3 = new(3);
        TreeNode<int> pNode2 = new(2);

        TreeNode<int>.ConnectTreeNodes(pNode5, pNode4, null);
        TreeNode<int>.ConnectTreeNodes(pNode4, pNode3, null);
        TreeNode<int>.ConnectTreeNodes(pNode3, pNode2, null);

        P191Test("P191Test2", pNode5);


    }

    //        5
    //         4
    //          3
    //           2
    public static void P191Test3()
    {
        TreeNode<int> pNode5 = new(5);
        TreeNode<int> pNode4 = new(4);
        TreeNode<int> pNode3 = new(3);
        TreeNode<int> pNode2 = new(2);

        TreeNode<int>.ConnectTreeNodes(pNode5, null, pNode4);
        TreeNode<int>.ConnectTreeNodes(pNode4, null, pNode3);
        TreeNode<int>.ConnectTreeNodes(pNode3, null, pNode2);

        P191Test("P191Test3", pNode5);


    }

    public static void P191Test4()
    {
        TreeNode<int> pNode5 = new(5);

        P191Test("P191Test4", pNode5);


    }

    public static void P191Test5()
    {
        P191Test("P191Test5", null);
    }

    //        5
    //         5
    //          5
    //         5
    //        5
    //       5 5
    //      5   5
    public static void P191Test6()
    {
        TreeNode<int> pNode1 = new(5);
        TreeNode<int> pNode2 = new(5);
        TreeNode<int> pNode3 = new(5);
        TreeNode<int> pNode4 = new(5);
        TreeNode<int> pNode5 = new(5);
        TreeNode<int> pNode61 = new(5);
        TreeNode<int> pNode62 = new(5);
        TreeNode<int> pNode71 = new(5);
        TreeNode<int> pNode72 = new(5);

        TreeNode<int>.ConnectTreeNodes(pNode1, null, pNode2);
        TreeNode<int>.ConnectTreeNodes(pNode2, null, pNode3);
        TreeNode<int>.ConnectTreeNodes(pNode3, pNode4, null);
        TreeNode<int>.ConnectTreeNodes(pNode4, pNode5, null);
        TreeNode<int>.ConnectTreeNodes(pNode5, pNode61, pNode62);
        TreeNode<int>.ConnectTreeNodes(pNode61, pNode71, null);
        TreeNode<int>.ConnectTreeNodes(pNode62, null, pNode72);

        P191Test("P191Test6", pNode1);


    }
}
