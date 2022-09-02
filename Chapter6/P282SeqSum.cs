namespace Algorithm.Chapter6;

public static partial class Solution
{
    public static void P282SeqSum(int k)
    {
        var small = 0;
        var large = 1;
        var currentSum = small + large;

        while (small <= k / 2)
        {
            if (currentSum < k)
            {
                currentSum += ++large;
            }
            else if (currentSum == k)
            {
                Console.WriteLine(
                    System.Text.Json.JsonSerializer.Serialize(Enumerable.Range(small, large - small + 1)));

                currentSum -= small++;
            }
            else
            {
                currentSum -= small++;
            }
        }
    }

    // ====================测试代码====================
    public static void P282Test(string testName, int sum)
    {
        if (testName != null)
            Console.Write($"{testName} for {sum} begins: \n");

        P282SeqSum(sum);
    }

    public static void P282Test()
    {
        P282Test("test1", 1);
        P282Test("test2", 3);
        P282Test("test3", 4);
        P282Test("test4", 9);
        P282Test("test5", 15);
        P282Test("test6", 100);
    }
}
