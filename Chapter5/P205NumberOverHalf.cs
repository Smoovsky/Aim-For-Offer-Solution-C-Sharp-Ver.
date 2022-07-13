namespace Algorithm.Chapter5;

public static partial class Solution
{
    public static int P205NumberOverHalfPartition(int[]? source)
    {
        if (!(source?.Length > 0))
        {
            return 0;
        }

        var mid = source.Length / 2;

        var index = Partition(source);

        while (index != mid)
        {
            if (index < mid)
            {
                index = Partition(source, index + 1, source.Length - 1);
            }
            else
            {
                index = Partition(source, 0, index - 1);
            }
        }

        var result = source[index];
        var count = 0;

        for (int i = 0; i < source.Length; i++)
        {
            if (source[i] == result)
            {
                count++;
            }
        }

        if (count <= source.Length / 2)
        {
            return 0;
        }

        return result;
    }

    public static int P205NumberOverHalfAlternative(int[]? source)
    {
        if (!(source?.Length > 0))
        {
            return 0;
        }

        var saved = 0;
        var count = 0;

        for (int i = 0; i < source.Length; i++)
        {
            if (source[i] == saved)
            {
                count++;
            }
            else
            {
                if (count == 0)
                {
                    count = 1;
                    saved = source[i];
                }
                else
                {
                    count--;
                }
            }
        }

        count = 0;

        for (int i = 0; i < source.Length; i++)
        {
            if (source[i] == saved)
            {
                count++;
            }
        }

        if (count <= source.Length / 2)
        {
            return 0;
        }

        return saved;
    }

    // ====================测试代码====================
    public static void P205Test(string testName, int[] numbers, int length, int expectedValue, bool _)
    {
        if (testName != null)
            Console.Write($"{testName} begins: \n");

        int[] copy = new int[length];
        for (int i = 0; i < length; ++i)
            copy[i] = numbers[i];

        Console.Write("P205Test for solution1: ");
        int result = P205NumberOverHalfPartition(numbers);

        if (result == expectedValue)
            Console.Write("Passed.\n");
        else
            Console.Write("Failed.\n");

        Console.Write("P205Test for solution2: ");
        result = P205NumberOverHalfAlternative(copy);
        if(result == expectedValue)
            Console.Write("Passed.\n");
        else
            Console.Write("Failed.\n");


    }

    // 存在出现次数超过数组长度一半的数字
    public static void P205Test1()
    {
        var numbers = new int[] { 1, 2, 3, 2, 2, 2, 5, 4, 2 };
        P205Test("P205Test1", numbers, numbers?.Length ?? 0, 2, false);
    }

    // 不存在出现次数超过数组长度一半的数字
    public static void P205Test2()
    {
        var numbers = new int[] { 1, 2, 3, 2, 4, 2, 5, 2, 3 };
        P205Test("P205Test2", numbers, numbers?.Length ?? 0, 0, true);
    }

    // 出现次数超过数组长度一半的数字都出现在数组的前半部分
    public static void P205Test3()
    {
        var numbers = new int[] { 2, 2, 2, 2, 2, 1, 3, 4, 5 };
        P205Test("P205Test3", numbers, numbers?.Length ?? 0, 2, false);
    }

    // 出现次数超过数组长度一半的数字都出现在数组的后半部分
    public static void P205Test4()
    {
        var numbers = new int[] { 1, 3, 4, 5, 2, 2, 2, 2, 2 };
        P205Test("P205Test4", numbers, numbers?.Length ?? 0, 2, false);
    }

    // 输入空指针
    public static void P205Test5()
    {
        var numbers = new int[] { 1 };
        P205Test("P205Test5", numbers, 1, 1, false);
    }

    // 输入空指针
    public static void P205Test6()
    {
        P205Test("P205Test6", null, 0, 0, true);
    }
}
