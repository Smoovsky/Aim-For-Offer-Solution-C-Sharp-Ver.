namespace Algorithm.Chapter6;

public static partial class Solution
{
    public static string P286LeftRotateWord(
        string source,
        int k)
    {
        if (k == 0)
        {
            return source;
        }

        if (!(k <= source?.Length) || k < 0)
        {
            return null;
        }

        var reversed = source.ToArray();

        ReverseString(reversed.AsSpan()[0..k]);
        ReverseString(reversed.AsSpan()[k..]);
        ReverseString(reversed.AsSpan());

        var result = reversed.Aggregate(
            string.Empty,
            (p, c) => $"{p}{c}");

        Console.WriteLine(result);

        return result;
    }


    // ====================测试代码====================
    public static void P286Test(string testName, string input, int k, string expectedResult)
    {
        if (testName != null)
            Console.Write($"{testName} begins: ");

        string result = P286LeftRotateWord(input, k);

        if ((input == null && expectedResult == null)
            || (input != null && result == expectedResult))
            Console.Write("Passed.\n\n");
        else
            Console.Write("Failed.\n\n");
    }

    // 功能测试
    public static void P286Test1()
    {
        string input = "abcdefg";
        string expected = "cdefgab";

        P286Test("Test1", input, 2, expected);
    }

    // 边界值测试
    public static void P286Test2()
    {
        string input = "abcdefg";
        string expected = "bcdefga";

        P286Test("Test2", input, 1, expected);
    }

    // 边界值测试
    public static void P286Test3()
    {
        string input = "abcdefg";
        string expected = "gabcdef";

        P286Test("Test3", input, 6, expected);
    }

    // 鲁棒性测试
    public static void P286Test4()
    {
        P286Test("Test4", null, 6, null);
    }

    // 鲁棒性测试
    public static void P286Test5()
    {
        string input = "abcdefg";
        string expected = "abcdefg";

        P286Test("Test5", input, 0, expected);
    }

    // 鲁棒性测试
    public static void P286Test6()
    {
        string input = "abcdefg";
        string expected = "abcdefg";

        P286Test("Test6", input, 7, expected);
    }

    public static void P286Test()
    {
        P286Test1();
        P286Test2();
        P286Test3();
        P286Test4();
        P286Test5();
        P286Test6();
    }

}
