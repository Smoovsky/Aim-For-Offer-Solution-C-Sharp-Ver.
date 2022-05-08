namespace Algorithm
{
    public static partial class Solution
    {
        public static string P100AlphaDecimal(int octal)
        {
            octal--;

            int maxPow = -1;

            for (int i = 1; i <= 10; i++)
            {
                if (Math.Pow(26, i) > octal)
                {
                    maxPow = i - 1;
                    break;
                }

                if (Math.Pow(26, i) == octal)
                {
                    maxPow = i;
                    break;
                }
            }

            if (maxPow == -1)
            {
                return string.Empty;
            }

            var result = string.Empty;
            var cursor = 0;

            for (int i = maxPow; i >= 0; i--)
            {
                var baseNum = (int)Math.Pow(26, i);

                for (int j = 0; j < 26; j++)
                {
                    if (baseNum * j + cursor > octal)
                    {
                        cursor += baseNum * --j;
                        result += P100OctalToString(j);

                        break;
                    }

                    if (baseNum * j + cursor == octal
                        || j == 25)
                    {
                        cursor += baseNum * j;
                        result += P100OctalToString(j);

                        break;
                    }
                }
            }

            if (result == "ZA")
            {

            }

            return result;
        }

        public static string P100OctalToString(int octal)
        {
            return ((char)(octal += 65)).ToString();
        }

        public static void P100AlphaDecimalTest()
        {
            for (int i = 1; i <= 1000; i++)
            {
                Console.WriteLine(P100AlphaDecimal(i));
            }
        }
    }
}