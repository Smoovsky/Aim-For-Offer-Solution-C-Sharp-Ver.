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
}
