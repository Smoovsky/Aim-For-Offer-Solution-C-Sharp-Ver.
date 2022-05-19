namespace Algorithm.Chapter3
{
    public static partial class Solution
    {
        public static bool P127MatchNumber(ReadOnlySpan<char> str)
        {
            if (str.Length == 0)
            {
                return false;
            }

            var isNum = P127MatchSignedInt(ref str);

            if (str.Length > 0 && str[0] == '.')
            {
                str = str[1..];
                isNum = P127MatchUnsignedInt(ref str) || isNum;
            }

            if (isNum && str.Length > 0 && (str[0] == 'e' || str[0] == 'E'))
            {
                str = str[1..];

                isNum = P127MatchSignedInt(ref str);
            }

            return isNum && str.Length == 0;
        }

        public static bool P127MatchUnsignedInt(ref ReadOnlySpan<char> str)
        {
            int i = 0;

            while (str.Length > 0
                && str[0] >= '0'
                && str[0] <= '9')
            {
                str = str[1..];
                ++i;
            }

            return i > 0;
        }

        public static bool P127MatchSignedInt(ref ReadOnlySpan<char> str)
        {
            if (str.Length > 0 && (str[0] == '+' || str[0] == '-'))
            {
                str = str[1..];
            }

            return P127MatchUnsignedInt(ref str);
        }

        public static void P127Test(string testName, string? str, bool expected)
        {
            if (testName != null)
                Console.WriteLine($"{testName} begins: ");

            if (P127MatchNumber(str) == expected)
                Console.WriteLine("Passed.\n");
            else
                Console.WriteLine("FAILED.\n");
        }
    }
}