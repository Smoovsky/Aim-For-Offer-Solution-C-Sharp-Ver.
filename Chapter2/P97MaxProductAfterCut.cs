namespace Algorithm.Chapter2
{
    public static partial class Solution
    {
        public static int MaxProductAfterCutP97DynPlan(int length)
        {
            if (length < 2)
            {
                return 0;
            }

            if (length == 2)
            {
                return 1;
            }

            var maxProduct = new List<int>() { 0, 1, 2, 3 }; // why? because for i < 4, cut none is the biggest solution

            for (int i = 4; i <= length; i++)
            {
                maxProduct.Add(i - 1);

                for (int j = 1; j <= i / 2; j++)
                {
                    var product = maxProduct[j] * maxProduct[i - j];

                    if (product > maxProduct[i])
                    {
                        maxProduct[i] = product;
                    }
                }
            }

            return maxProduct[length];
        }

        public static int MaxProductAfterCutP97Greedy(int length)
        {
            if (length < 2)
            {
                return 0;
            }

            if (length == 2)
            {
                return 1;
            }

            var pow3 = length / 3;

            if (length % pow3 == 1)
            {
                pow3 -= 1;
            }

            var pow2 = (length - pow3 * 3) / 2;

            return (int)Math.Pow(3, pow3) * (int)Math.Pow(2, pow2);
        }

        public static void TestMaxProductAfterCutP97DynPlan()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(
                    $"{i}: {MaxProductAfterCutP97DynPlan(i)}");
                Console.WriteLine(
                    $"{i}: {MaxProductAfterCutP97Greedy(i)}");
            }
        }
    }
}