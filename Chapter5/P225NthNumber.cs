namespace Algorithm.Chapter5;

public static partial class Solution
{
    public static int P225NthNumber(int n, int currentPower = 1)
    {
        if (n < 0)
        {
            return -1;
        }

        while (true)
        {
            // 1 -> 10
            // 2 -> 180
            // 3 -> 2700
            var currentMax = (int)(Math.Pow(10, currentPower) - (currentPower == 1 ? 0 : Math.Pow(10, currentPower - 1))) * currentPower;

            if (n > currentMax)
            {
                return P225NthNumber(n - currentMax, currentPower + 1);
            }
            else
            {
                var numCount = n / currentPower;
                var index = n % currentPower;

                var resultNum = (currentPower == 1 ? 0 : Math.Pow(10, currentPower - 1)) + numCount;

                return int.Parse(resultNum.ToString()[index].ToString());
            }
        }
    }
    public static void P225Test(string testName, int inputIndex, int expectedOutput)
    {
        if (P225NthNumber(inputIndex) == expectedOutput)
            Console.WriteLine($"{testName}: PASSED");
        else
            Console.WriteLine($"{testName}: FAILED");
    }

    public static void P225Test()
    {
        P225Test("Test1", 0, 0);
        P225Test("Test2", 1, 1);
        P225Test("Test3", 9, 9);
        P225Test("Test4", 10, 1);
        P225Test("Test5", 189, 9);  // 数字99的最后一位，9
        P225Test("Test6", 190, 1);  // 数字100的第一位，1
        P225Test("Test7", 1000, 3); // 数字370的第一位，3
        P225Test("Test8", 1001, 7); // 数字370的第二位，7
        P225Test("Test9", 1002, 0); // 数字370的第三位，0
    }
}
