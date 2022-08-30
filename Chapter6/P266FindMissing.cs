namespace Algorithm.Chapter6;

public static partial class Solution
{
    public static int P266FindMissing(
        int[]? source,
        int? start = null,
        int? end = null)
    {
        if (!(source?.Length > 0))
        {
            return -1;
        }

        start ??= 0;
        end ??= source.Length - 1;

        if (start == end
            && source[start.Value] == start.Value
            && start == source.Length - 1)
        {
            return source.Length;
        }

        if ((start == end
                && source[start.Value] == start.Value)
            || (start > end))
        {
            return -1;
        }

        var idx = Random.Shared.Next(start.Value, end.Value + 1);

        if (source[idx] == idx)
        {
            return P266FindMissing(source, idx + 1, end);
        }
        else
        {
            if (idx == 0 || source[idx - 1] == idx - 1)
            {
                return idx;
            }

            return P266FindMissing(source, start, idx - 1);
        }
    }
    // ====================测试代码====================
    public static void P266Test(string testName, int[] numbers, int expected)
    {
        if (testName != null)
            Console.Write($"{testName} begins: ");

        int result = P266FindMissing(numbers);
        if (result == expected)
            Console.Write("Passed.\n");
        else
            Console.Write("Failed.\n");
    }

    // 缺失的是第一个数字0
    public static void P266Test1()
    {
        int[] numbers = new[] { 1, 2, 3, 4, 5 };
        int expected = 0;
        P266Test("Test1", numbers, expected);
    }

    // 缺失的是最后一个数字
    public static void P266Test2()
    {
        int[] numbers = new[] { 0, 1, 2, 3, 4 };
        int expected = 5;
        P266Test("Test2", numbers, expected);
    }

    // 缺失的是中间某个数字0
    public static void P266Test3()
    {
        int[] numbers = new[] { 0, 1, 2, 4, 5 };
        int expected = 3;
        P266Test("Test3", numbers, expected);
    }

    // 数组中只有一个数字，缺失的是第一个数字0
    public static void P266Test4()
    {
        int[] numbers = new[] { 1 };
        int expected = 0;
        P266Test("Test4", numbers, expected);
    }

    // 数组中只有一个数字，缺失的是最后一个数字1
    public static void P266Test5()
    {
        int[] numbers = new[] { 0 };
        int expected = 1;
        P266Test("Test5", numbers, expected);
    }

    // 空数组
    public static void P266Test6()
    {
        int expected = -1;
        P266Test("Test6", null, expected);
    }

    public static void P266Test()
    {
        P266Test1();
        P266Test2();
        P266Test3();
        P266Test4();
        P266Test5();
        P266Test6();
    }
}
