namespace Algorithm.Chapter2
{
    public static partial class Solution
    {
        public static int P100CountOneShiftOne(int num)
        {
            uint i = 1;

            var result = 0;

            while (i != 0)
            {
                if ((num & i) != 0)
                {
                    result++;
                }

                i <<= 1;
            }

            return result;
        }

        public static int P100CountOneNoShift(int num)
        {
            var result = 0;

            while (num != 0)
            {
                num &= num - 1;
                result++;
            }

            return result;
        }

        public static void TestP100CountOne()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"{i}:{P100CountOneShiftOne(i)}");
                Console.WriteLine($"{i}:{P100CountOneNoShift(i)}");
            }
        }
    }
}