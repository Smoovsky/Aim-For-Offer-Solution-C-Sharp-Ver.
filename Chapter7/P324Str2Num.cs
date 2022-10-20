namespace Algorithm.Chapter7;

public static partial class Solution
{
    public static int? P324Str2Num(string source)
    {
        if (!(source?.Length > 0))
        {
            return null;
        }

        var neg = source[0] == '-';
        var skip = source[0] == '-' || source[0] == '+';

        if (neg && source.Length == 1)
        {
            return null;
        }

        long result = 0;

        foreach (var c in skip ? source[1..] : source)
        {
            var num = c - '0';

            if (num > 9 || num < 0)
            {
                return null;
            }

            result *= 10;
            result += num;

            if ((neg && result > int.MaxValue)
                || (!neg && -result < int.MinValue))
            {
                return null;
            }
        }

        return (int)(neg ? -result : result);
    }

    // ====================测试代码====================
    public static void P324Test(string str)
    {
        int? result = P324Str2Num(str);
        if (result == null)
            Console.Write($"the input {str} is invalid.\n");
        else
            Console.Write($"number for {str} is: {result}.\n");
    }

    public static void P324Test()
    {
        P324Test(null);

        P324Test("");

        P324Test("123");

        P324Test("+123");

        P324Test("-123");

        P324Test("1a33");

        P324Test("+0");

        P324Test("-0");

        //有效的最大正整数, 0x7FFFFFFF
        P324Test("+2147483647");

        P324Test("-2147483647");

        P324Test("+2147483648");

        //有效的最小负整数, 0x80000000
        P324Test("-2147483648");

        P324Test("+2147483649");

        P324Test("-2147483649");

        P324Test("+");

        P324Test("-");
    }
}
