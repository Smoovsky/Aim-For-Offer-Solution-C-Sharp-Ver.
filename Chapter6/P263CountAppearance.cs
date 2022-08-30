namespace Algorithm.Chapter6;

public static partial class Solution
{
    public static int P263CountAppearance(
        int[]? source,
        int k)
    {
        if (!(source?.Length > 0))
        {
            return 0;
        }

        var firstK = GetFirstK(source, k);

        if (firstK == -1)
        {
            return 0;
        }

        var lastK = GetLastK(source, k);

        if (lastK == -1)
        {
            return 0;
        }

        return lastK - firstK + 1;
    }

    public static int GetFirstK(
        int[] source,
        int k,
        int? start = null,
        int? end = null)
    {
        start ??= 0;
        end ??= source.Length - 1;

        if ((start == end
                && source[start.Value] != k)
            || start > end)
        {
            return -1;
        }
        // else if (start == end)
        // {
        //     return start.Value;
        // }

        var idx = Random.Shared.Next(start.Value, end.Value + 1);

        if (source[idx] < k)
        {
            return GetFirstK(source, k, idx + 1, end);
        }

        if (source[idx] == k
            && (idx == 0 || source[idx - 1] != k))
        {
            return idx;
        }

        return GetFirstK(source, k, start.Value, idx - 1);
    }

    public static int GetLastK(
        int[] source,
        int k,
        int? start = null,
        int? end = null)
    {
        start ??= 0;
        end ??= source.Length - 1;

        if ((start == end
                && source[start.Value] != k)
            || start > end)
        {
            return -1;
        }
        // else if (start == end)
        // {
        //     return start.Value;
        // }

        var idx = Random.Shared.Next(start.Value, end.Value + 1);

        if (source[idx] < k
            || (source[idx] == k
                && idx < source.Length - 1
                && source[idx + 1] == k))
        {
            return GetLastK(source, k, idx + 1, end.Value);
        }

        if (source[idx] == k
            && (idx == source.Length - 1 || source[idx + 1] != k))
        {
            return idx;
        }

        return GetLastK(source, k, start.Value, idx - 1);
    }

    // ====================测试代码====================
    public static void P263Test(
        string testName,
        int[] data,
        int k,
        int expected)
    {
        if (testName != null)
            Console.Write($"{testName} begins: ");

        int result = P263CountAppearance(data, k);
        if (result == expected)
            Console.Write("Passed.\n");
        else
            Console.Write("Failed.\n");
    }

    // 查找的数字出现在数组的中间
    public static void P263Test1()
    {
        var data = new[] { 1, 2, 3, 3, 3, 3, 4, 5 };
        P263Test("Test1", data, 3, 4);
    }

    // 查找的数组出现在数组的开头
    public static void P263Test2()
    {
        var data = new[] { 3, 3, 3, 3, 4, 5 };
        P263Test("Test2", data, 3, 4);
    }

    // 查找的数组出现在数组的结尾
    public static void P263Test3()
    {
        var data = new[] { 1, 2, 3, 3, 3, 3 };
        P263Test("Test3", data, 3, 4);
    }

    // 查找的数字不存在
    public static void P263Test4()
    {
        var data = new[] { 1, 3, 3, 3, 3, 4, 5 };
        P263Test("Test4", data, 2, 0);
    }

    // 查找的数字比第一个数字还小，不存在
    public static void P263Test5()
    {
        var data = new[] { 1, 3, 3, 3, 3, 4, 5 };
        P263Test("Test5", data, 0, 0);
    }

    // 查找的数字比最后一个数字还大，不存在
    public static void P263Test6()
    {
        var data = new[] { 1, 3, 3, 3, 3, 4, 5 };
        P263Test("Test6", data, 6, 0);
    }

    // 数组中的数字从头到尾都是查找的数字
    public static void P263Test7()
    {
        var data = new[] { 3, 3, 3, 3 };
        P263Test("Test7", data, 3, 4);
    }

    // 数组中的数字从头到尾只有一个重复的数字，不是查找的数字
    public static void P263Test8()
    {
        var data = new[] { 3, 3, 3, 3 };
        P263Test("Test8", data, 4, 0);
    }

    // 数组中只有一个数字，是查找的数字
    public static void P263Test9()
    {
        var data = new[] { 3 };
        P263Test("Test9", data, 3, 1);
    }

    // 数组中只有一个数字，不是查找的数字
    public static void P263Test10()
    {
        var data = new[] { 3 };
        P263Test("Test10", data, 4, 0);
    }

    // 鲁棒性测试，数组空指针
    public static void P263Test11()
    {
        P263Test("Test11", null, 0, 0);
    }

    public static void P263Test()
    {
        P263Test1();
        P263Test2();
        P263Test3();
        P263Test4();
        P263Test5();
        P263Test6();
        P263Test7();
        P263Test8();
        P263Test9();
        P263Test10();
        P263Test11();
    }
}
