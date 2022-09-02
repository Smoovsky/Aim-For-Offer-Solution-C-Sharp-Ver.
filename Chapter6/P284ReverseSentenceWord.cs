namespace Algorithm.Chapter6;

public static partial class Solution
{
    public static string P284ReverseSentenceWord(string source)
    {
        if (!(source?.Length > 1))
        {
            return source?.ToString();
        }

        var reversed = source.ToArray();
        ReverseString(reversed);

        int begin = 0, end = 0;

        while (begin < source.Length)
        {
            while (end < source.Length)
            {
                if (end == source.Length - 1)
                {
                    ReverseString(reversed.AsSpan()[begin..(end + 1)]);

                    begin = end + 1;

                    break;
                }

                if (reversed[end] == ' ')
                {
                    ReverseString(reversed.AsSpan()[begin..end]);

                    begin = end + 1;

                    end++;

                    break;
                }

                end++;
            }
        }

        var result = reversed.Aggregate(
            string.Empty,
            (p, c) => $"{p}{c}");

        Console.WriteLine(result);

        return result;
    }

    public static void ReverseString(Span<char> source)
    {
        if (!(source.Length > 1))
        {
            return;
        }

        int begin = 0, end = source.Length - 1;

        while (begin < end)
        {
            Swap(ref source[begin++], ref source[end--]);
        }
    }


    // ====================测试代码====================
    public static void P284Test(string testName, string input, string expectedResult)
    {
        if (testName != null)
            Console.Write($"{testName} begins: ");

        var result = P284ReverseSentenceWord(input);

        if ((result == null && expectedResult == null)
            || (input != null && result == expectedResult))
            Console.Write("Passed.\n\n");
        else
            Console.Write("Failed.\n\n");
    }

    // 功能测试，句子中有多个单词
    public static void P284Test1()
    {
        string input = "I am a student.";
        string expected = "student. a am I";

        P284Test("Test1", input, expected);
    }

    // 功能测试，句子中只有一个单词
    public static void P284Test2()
    {
        string input = "Wonderful";
        string expected = "Wonderful";

        P284Test("Test2", input, expected);
    }

    // 鲁棒性测试
    public static void P284Test3()
    {
        P284Test("Test3", null, null);
    }

    // 边界值测试，测试空字符串
    public static void P284Test4()
    {
        P284Test("Test4", "", "");
    }

    // 边界值测试，字符串中只有空格
    public static void P284Test5()
    {
        string input = "   ";
        string expected = "   ";
        P284Test("Test5", input, expected);
    }

    public static void P284Test()
    {
        P284Test1();
        P284Test2();
        P284Test3();
        P284Test4();
        P284Test5();
    }
}
