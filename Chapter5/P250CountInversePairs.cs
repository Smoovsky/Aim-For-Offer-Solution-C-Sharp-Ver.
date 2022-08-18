namespace Algorithm.Chapter5;

public static partial class Solution
{
    public static void P250CountInversePairs(
        int[] source,
        ref int reversePairCount,
        int[] copy = null,
        int? start = null,
        int? end = null)
    {
        if (!(source?.Length > 1))
        {
            return;
        }

        start ??= 0;
        end ??= source.Length - 1;
        copy ??= new int[source.Length];

        if (end == start)
        {
            copy[end.Value] = source[end.Value];

            return;
        }

        var mid = (end - start) / 2 + start;

        if (end - start > 1)
        {
            P250CountInversePairs(
                copy,
                ref reversePairCount,
                source,
                start,
                mid);

            P250CountInversePairs(
                copy,
                ref reversePairCount,
                source,
                mid + 1,
                end);
        }

        var p1 = mid.Value;
        var p2 = end.Value;
        var p3 = end.Value;

        while (p1 >= start || p2 > mid)
        {
            if (p1 >= start
                && p2 > mid
                && source[p1] > source[p2])
            {
                reversePairCount += p1 - start.Value + 1;
                copy[p3--] = source[p1--];
            }
            else if (p2 > mid)
            {
                copy[p3--] = source[p2--];
            }
            else if (p1 >= start)
            {
                copy[p3--] = source[p1--];
            }
        }
    }

    // ====================测试代码====================
    public static void P250Test(string testName, int[] data, int expected)
    {
        if (testName != null)
            Console.Write($"{testName} begins: ");

        var result = 0;
        P250CountInversePairs(data, ref result);

        if (result == expected)
            Console.Write("Passed.\n");
        else
            Console.Write("Failed.\n");
    }

    public static void P250Test1()
    {
        int[] data = new[] { 1, 2, 3, 4, 7, 6, 5 };
        int expected = 3;

        P250Test("Test1", data, expected);
    }

    // 递减排序数组
    public static void P250Test2()
    {
        int[] data = new[] { 6, 5, 4, 3, 2, 1 };
        int expected = 15;

        P250Test("Test2", data, expected);
    }

    // 递增排序数组
    public static void P250Test3()
    {
        int[] data = new[] { 1, 2, 3, 4, 5, 6 };
        int expected = 0;

        P250Test("Test3", data, expected);
    }

    // 数组中只有一个数字
    public static void P250Test4()
    {
        int[] data = new[] { 1 };
        int expected = 0;

        P250Test("Test4", data, expected);
    }


    // 数组中只有两个数字，递增排序
    public static void P250Test5()
    {
        int[] data = new[] { 1, 2 };
        int expected = 0;

        P250Test("Test5", data, expected);
    }

    // 数组中只有两个数字，递减排序
    public static void P250Test6()
    {
        int[] data = new[] { 2, 1 };
        int expected = 1;

        P250Test("Test6", data, expected);
    }

    // 数组中有相等的数字
    public static void P250Test7()
    {
        int[] data = new[] { 1, 2, 1, 2, 1 };
        int expected = 3;

        P250Test("Test7", data, expected);
    }

    public static void P250Test8()
    {
        int expected = 0;

        P250Test("Test8", null, expected);
    }

    public static void P250Test()
    {
        P250Test1();
        P250Test2();
        P250Test3();
        P250Test4();
        P250Test5();
        P250Test6();
        P250Test7();
        P250Test8();
    }
}
