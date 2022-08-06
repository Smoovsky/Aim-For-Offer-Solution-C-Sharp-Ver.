using System.Collections.Generic;

namespace Algorithm.Chapter5;

public static partial class Solution
{
    public class IntComboComparer : IComparer<string>
    {
        public int Compare(string? x, string? y) => string.Compare(x + y, y + x);
    }

    public static string P230MinNumCombo(int[] source) =>
        source != null
        ? string.Join(
            string.Empty,
            QuickSort(
                source.Select(s => s.ToString()),
                new IntComboComparer()))
        : null;

    // ====================测试代码====================
    public static void P230Test(string testName, int[] numbers, string expectedResult)
    {
        if (testName != null)
            Console.Write($"{testName} begins:\n");

        if (expectedResult != null)
            Console.Write($"Expected result is: \t{expectedResult}\n");

        Console.Write($"Actual result is: \t{P230MinNumCombo(numbers)}");

        Console.Write("\n");
    }

    public static void P230Test1()
    {
        int[] numbers = { 3, 5, 1, 4, 2 };
        P230Test("Test1", numbers, "12345");
    }

    public static void P230Test2()
    {
        int[] numbers = { 3, 32, 321 };
        P230Test("Test2", numbers, "321323");
    }

    public static void P230Test3()
    {
        int[] numbers = { 3, 323, 32123 };
        P230Test("Test3", numbers, "321233233");
    }

    public static void P230Test4()
    {
        int[] numbers = { 1, 11, 111 };
        P230Test("Test4", numbers, "111111");
    }

    // 数组中只有一个数字
    public static void P230Test5()
    {
        int[] numbers = { 321 };
        P230Test("Test5", numbers, "321");
    }

    public static void P230Test6()
    {
        P230Test("Test6", null, "Don't print anything.");
    }


    public static void P230Test()
    {
        P230Test1();
        P230Test2();
        P230Test3();
        P230Test4();
        P230Test5();
        P230Test6();
    }
}
