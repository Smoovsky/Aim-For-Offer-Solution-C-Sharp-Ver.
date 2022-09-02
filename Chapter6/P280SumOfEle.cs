namespace Algorithm.Chapter6;

public static partial class Solution
{
    public static bool P280SumOfEle(int[] source, int k, ref int num1, ref int num2)
    {
        if (!(source?.Length > 1))
        {
            return false;
        }

        int p1 = 0, p2 = source.Length - 1;

        while (p1 < p2)
        {
            if (source[p1] + source[p2] == k)
            {
                num1 = source[p1];
                num2 = source[p2];
                Console.WriteLine($"{source[p1]}, {source[p2]}");
                return true;
            }
            else if (source[p1] + source[p2] < k)
            {
                p1++;
            }
            else
            {
                p2--;
            }
        }

        return false;
    }
    // ====================测试代码====================
    public static void P280Test(string testName, int[] data, int sum, bool expectedReturn)
    {
        if (testName != null)
            Console.Write($"{testName} begins: ");

        int num1 = 0, num2 = 0;
        var result = P280SumOfEle(data, sum, ref num1, ref num2);

        if (result == expectedReturn)
        {
            if (result)
            {
                if (num1 + num2 == sum)
                    Console.Write("Passed. \n");
                else
                    Console.Write("FAILED. \n");
            }
            else
                Console.Write("Passed. \n");
        }
        else
            Console.Write("FAILED. \n");
    }

    // 存在和为s的两个数字，这两个数字位于数组的中间
    public static void P280Test1()
    {
        int[] data = new[] { 1, 2, 4, 7, 11, 15 };
        P280Test("Test1", data,  15, true);
    }

    // 存在和为s的两个数字，这两个数字位于数组的两段
    public static void P280Test2()
    {
        int[] data = new[] { 1, 2, 4, 7, 11, 16 };
        P280Test("Test2", data,  17, true);
    }

    // 不存在和为s的两个数字
    public static void P280Test3()
    {
        int[] data = new[] { 1, 2, 4, 7, 11, 16 };
        P280Test("Test3", data,  10, false);
    }

    // 鲁棒性测试
    public static void P280Test4()
    {
        P280Test("Test4", null, 0, false);
    }

    public static void P280Test()
    {
        P280Test1();
        P280Test2();
        P280Test3();
        P280Test4();
    }
}
