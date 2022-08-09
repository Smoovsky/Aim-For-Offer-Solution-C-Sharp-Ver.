using System.Collections.Generic;

namespace Algorithm.Chapter5;

public static partial class Solution
{
    public static int P236Num2Alpha(int num)
    {
        if (num < 0)
        {
            return 0;
        }

        var result = new List<int>();

        var numStr = num.ToString();

        for (int i = 0; i < numStr.Length; i++)
        {
            if (i == 0)
            {
                result.Add(1);

                continue;
            }
            else
            {
                result.Add(result[i - 1]);
            }

            if (i >= 1)
            {
                var parsed = int.Parse(numStr[i - 1].ToString() + numStr[i].ToString());

                if (parsed >= 10 && parsed <= 25)
                {
                    if (i >= 2)
                    {
                        result[i] += result[i - 2];
                    }
                    else
                    {
                        result[i] += 1;
                    }
                }
            }
        }

        return result.Last();
    }


    // ====================测试代码====================
    public static void P236Test(string testName, int number, int expected)
    {
        if (P236Num2Alpha(number) == expected)
            Console.WriteLine($"{testName}: PASSED");
        else
            Console.WriteLine($"{testName}: FAILED");
    }

    public static void P236Test1()
    {
        int number = 0;
        int expected = 1;
        P236Test("Test1", number, expected);
    }

    public static void P236Test2()
    {
        int number = 10;
        int expected = 2;
        P236Test("Test2", number, expected);
    }

    public static void P236Test3()
    {
        int number = 125;
        int expected = 3;
        P236Test("Test3", number, expected);
    }

    public static void P236Test4()
    {
        int number = 126;
        int expected = 2;
        P236Test("Test4", number, expected);
    }

    public static void P236Test5()
    {
        int number = 426;
        int expected = 1;
        P236Test("Test5", number, expected);
    }

    public static void P236Test6()
    {
        int number = 100;
        int expected = 2;
        P236Test("Test6", number, expected);
    }

    public static void P236Test7()
    {
        int number = 101;
        int expected = 2;
        P236Test("Test7", number, expected);
    }

    public static void P236Test8()
    {
        int number = 12258;
        int expected = 5;
        P236Test("Test8", number, expected);
    }

    public static void P236Test9()
    {
        int number = -100;
        int expected = 0;
        P236Test("Test9", number, expected);
    }

    public static void  P236Test()
    {
        P236Test1();
        P236Test2();
        P236Test3();
        P236Test4();
        P236Test5();
        P236Test6();
        P236Test7();
        P236Test8();
        P236Test9();
    }
}
