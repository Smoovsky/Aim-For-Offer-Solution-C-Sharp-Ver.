namespace Algorithm
{
    public static partial class Solution
    {
        public static int FibonacciRecursiceP78(int seqNum)
        {
            var seed = new[] { 1, 1 };

            if (seqNum < 1)
            {
                throw new ArgumentException("");
            }

            if (seqNum <= 2)
            {
                return seed[seqNum - 1];
            }

            return FibonacciRecursiceP78(seqNum - 1) + FibonacciRecursiceP78(seqNum - 2);
        }

        public static int FibonacciLoopP78(int seqNum)
        {
            if (seqNum < 1)
            {
                throw new ArgumentException("");
            }

            var febMTwo = 1;

            var febMOne = 1;

            var febCurrnet = febMTwo + febMOne;

            for (int i = 3; i < seqNum; i++)
            {
                if (i >= seqNum)
                {
                    return febCurrnet;
                }

                febMTwo = febMOne;
                febMOne = febCurrnet;

                febCurrnet = febMOne + febMTwo;
            }

            return febCurrnet;
        }
    }
}