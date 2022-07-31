namespace Algorithm.Chapter5;

public static partial class Solution
{
    public static void P220MaxSubArraySum(
        int[] array,
        out int? currentSum,
        out int? maxSum,
        int? currentIndex = null)
    {
        if (!(array?.Length > 0) || currentIndex < 0)
        {
            currentSum = null;
            maxSum = null;

            return;
        }

        currentIndex ??= array.Length - 1;

        if (currentIndex == 0)
        {
            currentSum = array[currentIndex.Value];
            maxSum = currentSum;

            return;
        }

        P220MaxSubArraySum(
            array, 
            out currentSum,
            out maxSum,
            currentIndex - 1);

        if (currentSum <= 0)
        {
            currentSum = array[currentIndex.Value];
        }
        else
        {
            currentSum = currentSum! + array[currentIndex.Value];
        }

        if (currentSum > maxSum)
        {
            maxSum = currentSum;
        }
    }


    // ====================测试代码====================
    public static void P220Test(string testName, int[] pData, int? expected, bool expectedFlag)
    {
        if (testName != null)
            Console.Write($"{testName} begins: \n");

        if (expectedFlag)
        {
            expected = null;
        }

        P220MaxSubArraySum(
            pData,
            out var _,
            out var result);

        if (result == expected)
            Console.Write("Passed.\n");
        else
            Console.Write("Failed.\n");
    }

    // 1, -2, 3, 10, -4, 7, 2, -5
    public static void P220Test1()
    {
        int[] data = { 1, -2, 3, 10, -4, 7, 2, -5 };
        P220Test("Test1", data, 18, false);
    }

    // 所有数字都是负数
    // -2, -8, -1, -5, -9
    public static void P220Test2()
    {
        int[] data = { -2, -8, -1, -5, -9 };
        P220Test("Test2", data, -1, false);
    }

    // 所有数字都是正数
    // 2, 8, 1, 5, 9
    public static void P220Test3()
    {
        int[] data = { 2, 8, 1, 5, 9 };
        P220Test("Test3", data, 25, false);
    }

    // 无效输入
    public static void P220Test4()
    {
        P220Test("Test4", null, 0, true);
    }

}
