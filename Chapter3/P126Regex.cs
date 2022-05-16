namespace Algorithm.Chapter3
{
    public static partial class Solution
    {
        public static bool P126Regex(
            ReadOnlySpan<char> pattern,
            ReadOnlySpan<char> str)
        {
            if (pattern.Length == 0 && str.Length == 0)
            {
                return true;
            }

            if (pattern.Length == 0 && str.Length > 0)
            {
                return false;
            }

            if (pattern.Length > 1 && pattern[1] == '*')
            {
                if (str.Length > 0 && (pattern[0] == str[0] || pattern[0] == '.'))
                {
                    return P126Regex(
                            pattern[2..],
                            str[1..])
                        || P126Regex(
                            pattern[2..],
                            str[0..])
                        || P126Regex(
                            pattern[0..],
                            str[1..]);
                }
                else
                {
                    return P126Regex(
                        pattern[2..],
                        str[0..]);
                }
            }

            if (str.Length == 0)
            {
                return false;
            }

            if (str[0] == pattern[0])
            {
                return P126Regex(
                    pattern[1..],
                    str[1..]);
            }

            return false;
        }
    }
}