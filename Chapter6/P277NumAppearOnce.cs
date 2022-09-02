namespace Algorithm.Chapter6;

public static partial class Solution
{
    public static void P277NumAppearOnce(
        uint[] source,
        ref uint num1,
        ref uint num2)
    {
        if (!(source?.Length > 0))
        {
            return;
        }

        var xorResult = source
            .Aggregate((p, c) => p ^ c);

        var first1Index = 0;

        while (((1 << first1Index) & xorResult) == 0 && xorResult < sizeof(uint))
        {
            first1Index++;
        }

        var referenceNumber = 1 << first1Index;

        num1 = num2 = 0;

        foreach (var num in source)
        {
            if ((referenceNumber & num) == 0)
            {
                num1 ^= num;
            }
            else
            {
                num2 ^= num;
            }
        }
    }


    // ====================测试代码====================
    public static void P277Test(string testName, uint[] data, int expected1, int expected2)
    {
        if (testName != null)
            Console.Write($"{testName} begins: ");

        uint result1 = 0, result2 = 0;

        P277NumAppearOnce(data, ref result1, ref result2);

        if ((expected1 == result1 && expected2 == result2) ||
            (expected2 == result1 && expected1 == result2))
            Console.Write("Passed.\n\n");
        else
            Console.Write("Failed.\n\n");
    }

    public static void P277Test1()
    {
        uint[] data = new uint[] { 2, 4, 3, 6, 3, 2, 5, 5 };
        P277Test("Test1", data, 4, 6);
    }

    public static void P277Test2()
    {
        uint[] data = new uint[] { 4, 6 };
        P277Test("Test2", data, 4, 6);
    }

    public static void P277Test3()
    {
        uint[] data = new uint[] { 4, 6, 1, 1, 1, 1 };
        P277Test("Test3", data, 4, 6);
    }

    public static void P277Test()
    {
        P277Test1();
        P277Test2();
        P277Test3();
    }
}
