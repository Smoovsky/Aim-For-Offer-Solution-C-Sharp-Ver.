namespace Algorithm.Chapter5;

public static partial class Solution
{
    public static int P222Count1s(int num)
    {
        return P222Count1s(num.ToString());
    }

    private static int P222Count1s(string num)
    {
        var numParsed = int.Parse(num);

        if (numParsed < 0)
        {
            return -1;
        }

        if (numParsed == 0)
        {
            return 0;
        }

        if (numParsed < 10)
        {
            return 1;
        }

        var firstDigit = int.Parse(num[0].ToString());

        var decimals = num.Length;

        int ltm1s;

        if (firstDigit < 2)
        {
            ltm1s = int.Parse(num[1..]) + 1;
        }
        else
        {
            ltm1s = (int)Math.Pow(10, decimals - 1);
        }

        var combi1s = (decimals - 1) * (int)Math.Pow(10, decimals - 2) * firstDigit;

        return ltm1s + combi1s + P222Count1s(numParsed - firstDigit * (int)Math.Pow(10, decimals - 1));
    }

    public static void P222Test(string testName, int n, int expected)
    {
        if (testName != null)
            Console.Write($"{testName} begins: \n");

        if (P222Count1s(n) == expected)
            Console.Write("Solution1 passed.\n");
        else
            Console.Write("Solution1 failed.\n");

        // if(NumberOf1Between1AndN_Solution2(n) == expected)
        //     Console.Write("Solution2 passed.\n");
        // else
        //     Console.Write("Solution2 failed.\n"); 

        Console.Write("\n");
    }

    public static void P222Test()
    {
        P222Test("Test1", 1, 1);
        P222Test("Test2", 5, 1);
        P222Test("Test3", 10, 2);
        P222Test("Test4", 55, 16);
        P222Test("Test5", 99, 20);
        P222Test("Test6", 10000, 4001);
        P222Test("Test7", 21345, 18821);
        P222Test("Test8", 0, 0);
    }
}
