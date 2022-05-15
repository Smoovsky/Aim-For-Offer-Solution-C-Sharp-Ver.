namespace Algorithm.Chapter3
{
    public static partial class Solution
    {
        public static decimal P110Power(decimal baseNum, int power)
        {
            if (baseNum == 0 && power < 0)
            {
                throw new ArgumentException("Invalid Input.");
            }

            var result = P110UnsignedExponent(baseNum, (uint)Math.Abs(power));

            if (power < 0)
            {
                result = 1m / result;
            }

            return result;
        }

        public static decimal P110UnsignedExponent(decimal baseNum, uint power)
        {
            if (power == 0)
            {
                return 1;
            }

            if (power == 1)
            {
                return baseNum;
            }

            var result = P110UnsignedExponent(baseNum, power >> 1);

            result *= result;

            if ((power & 1) == 1)
            {
                result *= baseNum;
            }

            return result;
        }

        public static void P110PowerTest(
            string testName,
            decimal baseNum,
            int exponent,
            decimal expectedResult,
            bool expectedFlag)
        {
            bool g_InvalidInput = false;

            decimal result = 0m;

            try
            {
                result = P110Power(baseNum, exponent);
            }
            catch
            {
                g_InvalidInput = true;
            }

            if (result == expectedResult
                && g_InvalidInput == expectedFlag)
            {
                Console.WriteLine(testName + " passed");
            }
            else
            {
                Console.WriteLine(testName + " FAILED");
            }
        }
    }
}