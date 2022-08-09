namespace Algorithm.Chapter5;

public static partial class Solution
{
    public static int P236MaxUniqueStr(string source)
    {
        var prevIndice = new int[26];

        _ = Enumerable.Range(0, 26).Select(i => prevIndice[i] = -1).ToArray();

        var result = new int[source.Length];
        var max = 0;

        for (int i = 0; i < source.Length; i++)
        {
            var charInt = source[i] - 'a';

            if (i == 0)
            {
                result[i] = 1;
                prevIndice[charInt] = 0;

                continue;
            }

            var prevResult = result[i - 1];

            var prevIndex = prevIndice[charInt];

            if (prevIndex == -1 || i - prevIndex > prevResult)
            {
                result[i] = prevResult + 1;
            }
            else
            {
                result[i] = prevResult;
            }

            if (result[i] > max)
            {
                max = result[i];
            }

            prevIndice[charInt] = i;
        }

        return max;
    }

    // ====================测试代码====================
    public static void P234Test(string input, int expected)
    {
        int output = P236MaxUniqueStr(input);
        if (output == expected)
            Console.WriteLine($"Solution 1 passed, with input: {input}");
        else
            Console.WriteLine($"Solution 1 FAILED, with input: {input}");
    }

    public static void P234Test1()
    {
        string input = "abcacfrar";
        int expected = 4;
        P234Test(input, expected);
    }

    public static void P234Test2()
    {
        string input = "acfrarabc";
        int expected = 4;
        P234Test(input, expected);
    }

    public static void P234Test3()
    {
        string input = "arabcacfr";
        int expected = 4;
        P234Test(input, expected);
    }

    public static void P234Test4()
    {
        string input = "aaaa";
        int expected = 1;
        P234Test(input, expected);
    }

    public static void P234Test5()
    {
        string input = "abcdefg";
        int expected = 7;
        P234Test(input, expected);
    }

    public static void P234Test6()
    {
        string input = "aaabbbccc";
        int expected = 2;
        P234Test(input, expected);
    }

    public static void P234Test7()
    {
        string input = "abcdcba";
        int expected = 4;
        P234Test(input, expected);
    }

    public static void P234Test8()
    {
        string input = "abcdaef";
        int expected = 6;
        P234Test(input, expected);
    }

    public static void P234Test9()
    {
        string input = "a";
        int expected = 1;
        P234Test(input, expected);
    }

    public static void P234Test10()
    {
        string input = "";
        int expected = 0;
        P234Test(input, expected);
    }

    public static void P234Test()
    {
        P234Test1();
        P234Test2();
        P234Test3();
        P234Test4();
        P234Test5();
        P234Test6();
        P234Test7();
        P234Test8();
        P234Test9();
        P234Test10();
    }
}
