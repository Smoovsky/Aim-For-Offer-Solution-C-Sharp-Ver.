namespace Algorithm.Chapter6;

public static partial class Solution
{
    public static int P278NumAppearOnceOthers3(int[] source)
    {
        if (!(source?.Length > 0))
        {
            return 0;
        }

        var dic = new ushort[sizeof(int) * 8];

        foreach (var num in source)
        {
            for (var i = 0; i < dic.Length; i++)
            {
                if (((1 << i) & num) != 0)
                {
                    dic[i]++;
                }
            }
        }

        int result = 0;

        _ = dic.Select((x, i) =>
        {
            if (x % 3u != 0)
            {
                result |= 1 << i;
            }

            return true;
        }).ToList();

        return result;
    }


    // ====================测试代码====================
    public static void P278Test(string testName, int[] numbers, int expected)
    {
        int result = P278NumAppearOnceOthers3(numbers);
        if (result == expected)
            Console.Write($"{testName} passed.\n");
        else
            Console.Write($"{testName} FAILED.\n");
    }

    // 所有数字都是正数，唯一的数字是最小的
    public static void P278Test1()
    {
        int[] numbers = new int[] { 1, 1, 2, 2, 2, 1, 3 };
        int expected = 3;
        P278Test("Test1", numbers, expected);
    }

    // 所有数字都是正数，唯一的数字的大小位于中间
    public static void P278Test2()
    {
        int[] numbers = new int[] { 4, 3, 3, 2, 2, 2, 3 };
        int expected = 4;
        P278Test("Test2", numbers, expected);
    }

    // 所有数字都是正数，唯一的数字是最大的
    public static void P278Test3()
    {
        int[] numbers = new int[] { 4, 4, 1, 1, 1, 7, 4 };
        int expected = 7;
        P278Test("Test3", numbers, expected);
    }

    // 唯一的数字是负数
    public static void P278Test4()
    {
        int[] numbers = new int[] { -10, 214, 214, 214 };
        int expected = -10;
        P278Test("Test4", numbers, expected);
    }

    // 除了唯一的数字，其他数字都是负数
    public static void P278Test5()
    {
        int[] numbers = new int[] { -209, 3467, -209, -209 };
        int expected = 3467;
        P278Test("Test5", numbers, expected);
    }

    // 重复的数字有正数也有负数
    public static void P278Test6()
    {
        int[] numbers = new int[] { 1024, -1025, 1024, -1025, 1024, -1025, 1023 };
        int expected = 1023;
        P278Test("Test6", numbers, expected);
    }

    // 所有数字都是负数
    public static void P278Test7()
    {
        int[] numbers = new int[] { -1024, -1024, -1024, -1023 };
        int expected = -1023;
        P278Test("Test7", numbers, expected);
    }

    // 唯一的数字是0
    public static void P278Test8()
    {
        int[] numbers = new int[] { -23, 0, 214, -23, 214, -23, 214 };
        int expected = 0;
        P278Test("Test8", numbers, expected);
    }

    // 除了唯一的数字，其他数字都是0
    public static void P278Test9()
    {
        int[] numbers = new int[] { 0, 3467, 0, 0, 0, 0, 0, 0 };
        int expected = 3467;
        P278Test("Test9", numbers, expected);
    }

    public static void P278Test()
    {
        P278Test1();
        P278Test2();
        P278Test3();
        P278Test4();
        P278Test5();
        P278Test6();
        P278Test7();
        P278Test8();
        P278Test9();
    }
}
