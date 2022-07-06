namespace Algorithm.Chapter4;

public static partial class Solution
{
    public static bool P180IsArrayBST(ReadOnlySpan<int> arry)
    {
        if (arry.Length == 0)
        {
            return false;
        }

        var i = 0;

        var root = arry[^1];

        for (; i < arry.Length - 1; i++)
        {
            if (arry[i] > root)
            {
                break;
            }
        }

        for (var j = i + 1; j < arry.Length - 1; j++)
        {
            if (arry[j] < root)
            {
                return false;
            }
        }

        var left = true;

        if (i > 2)
        {
            left = P180IsArrayBST(arry[..i]);
        }

        if (!left)
        {
            return false;
        }

        var right = true;

        if (arry.Length - i - 1 > 2)
        {
            right = P180IsArrayBST(arry[i..^1]);
        }

        return right;
    }

    // ====================测试代码====================
    public static void P180Test(string P180TestName, int[] sequence, bool expected)
    {
        if (P180TestName != null)
            Console.Write($"{P180TestName} begins: ");

        if (P180IsArrayBST(sequence) == expected)
            Console.Write("passed.\n");
        else
            Console.Write("failed.\n");
    }

    //            10
    //         /      \
    //        6        14
    //       /\        /\
    //      4  8     12  16
    public static void P180Test1()
    {
        int[] data = { 4, 8, 6, 12, 16, 14, 10 };
        P180Test("P180Test1", data, true);
    }

    //           5
    //          / \
    //         4   7
    //            /
    //           6
    public static void P180Test2()
    {
        int[] data = { 4, 6, 7, 5 };
        P180Test("P180Test2", data, true);
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
    public static void P180Test3()
    {
        int[] data = { 1, 2, 3, 4, 5 };
        P180Test("P180Test3", data, true);
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
    public static void P180Test4()
    {
        int[] data = { 5, 4, 3, 2, 1 };
        P180Test("P180Test4", data, true);
    }

    // 树中只有1个结点
    public static void P180Test5()
    {
        int[] data = { 5 };
        P180Test("P180Test5", data, true);
    }

    public static void P180Test6()
    {
        int[] data = { 7, 4, 6, 5 };
        P180Test("P180Test6", data, false);
    }

    public static void P180Test7()
    {
        int[] data = { 4, 6, 12, 8, 16, 14, 10 };
        P180Test("P180Test7", data, false);
    }

    public static void P180Test8()
    {
        P180Test("P180Test8", null, false);
    }

}
