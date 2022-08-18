namespace Algorithm.Chapter5;

public static partial class Solution
{
    public static public static void P250CountInversePairs(
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
        end ??= source.Length;
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
                source,
                ref reversePairCount,
                copy,
                start,
                mid);

            P250CountInversePairs(
                source,
                ref reversePairCount,
                copy,
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
    public static void Test(string testName, int[] data, int length, int expected)
    {
        if (testName != nullptr)
            Console.Write($"{testName} begins: ", );

        if (InversePairs(data, length) == expected)
            Console.Write("Passed.\n");
        else
            Console.Write("Failed.\n");
    }

    public static void Test1()
    {
        int[] data = new[] { 1, 2, 3, 4, 7, 6, 5 };
        int expected = 3;

        Test("Test1", data, sizeof(data) / sizeof(int), expected);
    }

    // 递减排序数组
    public static void Test2()
    {
        int[] data = new[] { 6, 5, 4, 3, 2, 1 };
        int expected = 15;

        Test("Test2", data, sizeof(data) / sizeof(int), expected);
    }

    // 递增排序数组
    public static void Test3()
    {
        int[] data = new[] { 1, 2, 3, 4, 5, 6 };
        int expected = 0;

        Test("Test3", data, sizeof(data) / sizeof(int), expected);
    }

    // 数组中只有一个数字
    public static void Test4()
    {
        int[] data = new[] { 1 };
        int expected = 0;

        Test("Test4", data, sizeof(data) / sizeof(int), expected);
    }


    // 数组中只有两个数字，递增排序
    public static void Test5()
    {
        int[] data = new[] { 1, 2 };
        int expected = 0;

        Test("Test5", data, sizeof(data) / sizeof(int), expected);
    }

    // 数组中只有两个数字，递减排序
    public static void Test6()
    {
        int[] data = new[] { 2, 1 };
        int expected = 1;

        Test("Test6", data, sizeof(data) / sizeof(int), expected);
    }

    // 数组中有相等的数字
    public static void Test7()
    {
        int[] data = new[] { 1, 2, 1, 2, 1 };
        int expected = 3;

        Test("Test7", data, sizeof(data) / sizeof(int), expected);
    }

    public static void Test8()
    {
        int expected = 0;

        Test("Test8", nullptr, 0, expected);
    }

    int main(int argc, string argv[])
    {
        Test1();
        Test2();
        Test3();
        Test4();
        Test5();
        Test6();
        Test7();
        Test8();

        return 0;
    }
}
