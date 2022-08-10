namespace Algorithm.Chapter5;

public static partial class Solution
{
    public static int P243NthUglyNumber(int n)
    {
        if (n <= 0)
        {
            return 0;
        }

        var ulyNums = new int[n];

        ulyNums[0] = 1;

        var max2Idx = 0;
        var max3Idx = 0;
        var max5Idx = 0;

        var crntIdx = 1;

        while (crntIdx < n)
        {
            ulyNums[crntIdx] = new[] { ulyNums[max2Idx] * 2, ulyNums[max3Idx] * 3, ulyNums[max5Idx] * 5 }.Min();

            while (ulyNums[max2Idx] * 2 <= ulyNums[crntIdx])
                max2Idx++;

            while (ulyNums[max3Idx] * 3 <= ulyNums[crntIdx])
                max3Idx++;

            while (ulyNums[max5Idx] * 5 <= ulyNums[crntIdx])
                max5Idx++;

            crntIdx++;
        }

        return ulyNums[n - 1];
    }
    // ====================测试代码====================
    public static void P243Test(int index, int expected)
    {
        if (P243NthUglyNumber(index) == expected)
            Console.Write("solution1 passed\n");
        else
            Console.Write("solution1 failed\n");

        // if(GetUglyNumber_Solution2(index) == expected)
        //     printf("solution2 passed\n");
        // else
        //     printf("solution2 failed\n");
    }

    public static void P243Test()
    {
        P243Test(1, 1);

        P243Test(2, 2);
        P243Test(3, 3);
        P243Test(4, 4);
        P243Test(5, 5);
        P243Test(6, 6);
        P243Test(7, 8);
        P243Test(8, 9);
        P243Test(9, 10);
        P243Test(10, 12);
        P243Test(11, 15);

        P243Test(1500, 859963392);

        P243Test(0, 0);
    }

}
