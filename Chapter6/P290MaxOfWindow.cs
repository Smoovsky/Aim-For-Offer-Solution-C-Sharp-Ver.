using System.Collections.Generic;

using Json = System.Text.Json.JsonSerializer;

namespace Algorithm.Chapter6;

public static partial class Solution
{
    public static ICollection<int> P290MaxOfWindow(
        int[] source,
        int windowSize)
    {
        if (!(source?.Length >= windowSize) || windowSize <= 0)
        {
            return Array.Empty<int>();
        }

        var result = new List<int>();

        var asitLst = new List<int>();

        for (var i = 0; i < source.Length; i++)
        {
            if (asitLst.Count > 0)
            {
                var currentMaxIndex = asitLst.First();

                if (i - currentMaxIndex > windowSize - 1)
                {
                    asitLst.RemoveAt(0);
                }

                if (asitLst.Count > 0
                    && source[i] > source[asitLst.First()])
                {
                    asitLst.RemoveAll(_ => true);
                }
                else
                {
                    for (int j = asitLst.Count - 1; j > 0; j--)
                    {
                        if (source[asitLst[j]] < source[i])
                        {
                            asitLst.RemoveAt(j);
                        }
                    }
                }
            }

            asitLst.Add(i);

            if (i >= windowSize - 1)
            {
                result.Add(source[asitLst.First()]);
            }
        }

        return result;
    }


    // ====================测试代码====================
    public static void P290Test(string testName, int[] num, int size, int[] expected)
    {
        if (testName != null)
            Console.Write($"{testName} begins: ");

        var result = P290MaxOfWindow(num, size);

        if (Json.Serialize(result) == Json.Serialize(expected))
            Console.Write("Passed.\n");
        else
            Console.Write("FAILED.\n");
    }

    public static void P290Test1()
    {
        var num = new[] { 2, 3, 4, 2, 6, 2, 5, 1 };


        var expected = new[] { 4, 4, 6, 6, 6, 5 };


        int size = 3;

        P290Test("Test1", num, size, expected);
    }

    public static void P290Test2()
    {
        var num = new[] { 1, 3, -1, -3, 5, 3, 6, 7 };


        var expected = new[] { 3, 3, 5, 5, 6, 7 };


        int size = 3;

        P290Test("Test2", num, size, expected);
    }

    // 输入数组单调递增
    public static void P290Test3()
    {
        var num = new[] { 1, 3, 5, 7, 9, 11, 13, 15 };


        var expected = new[] { 7, 9, 11, 13, 15 };


        int size = 4;

        P290Test("Test3", num, size, expected);
    }

    // 输入数组单调递减
    public static void P290Test4()
    {
        var num = new[] { 16, 14, 12, 10, 8, 6, 4 };


        var expected = new[] { 16, 14, 12 };


        int size = 5;

        P290Test("Test4", num, size, expected);
    }

    // 滑动窗口的大小为1
    public static void P290Test5()
    {
        var num = new[] { 10, 14, 12, 11 };


        var expected = new[] { 10, 14, 12, 11 };


        int size = 1;

        P290Test("Test5", num, size, expected);
    }

    // 滑动窗口的大小等于数组的长度
    public static void P290Test6()
    {
        var num = new[] { 10, 14, 12, 11 };


        var expected = new[] { 14 };


        int size = 4;

        P290Test("Test6", num, size, expected);
    }

    // 滑动窗口的大小为0
    public static void P290Test7()
    {
        var num = new[] { 10, 14, 12, 11 };

        int size = 0;

        P290Test("Test7", num, size, Array.Empty<int>());
    }

    // 滑动窗口的大小大于输入数组的长度
    public static void P290Test8()
    {
        var num = new[] { 10, 14, 12, 11 };

        int size = 5;

        P290Test("Test8", num, size, Array.Empty<int>());
    }

    // 输入数组为空
    public static void P290Test9()
    {
        int size = 5;

        P290Test("Test9", Array.Empty<int>(), size, Array.Empty<int>());
    }

    public static void P290Test()
    {
        P290Test1();
        P290Test2();
        P290Test3();
        P290Test4();
        P290Test5();
        P290Test6();
        P290Test7();
        P290Test8();
        P290Test9();
    }
}
