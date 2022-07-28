namespace Algorithm.Chapter5;

public static partial class Solution
{
    public static int[] P210LeastKNumbers(int[]? source, int k)
    {
        if (k <= 0 || source?.Length < k || source == null)
        {
            return null;
        }

        var result = new int[k];

        var start = 0;
        var end = source.Length - 1;

        var index = Partition(source, start, end);

        while (index != k - 1)
        {
            if (index < k - 1)
            {
                start = index + 1;
                index = Partition(source, start, end);
            }
            else
            {
                end = index - 1;
                index = Partition(source, start, end);
            }
        }

        for (var i = 0; i < k; i++)
        {
            result[i] = source[i];
        }

        return result;
    }

    public static int[] P210LeastKNumbersAlternative(int[]? source, int k)
    {
        if (k <= 0 || source?.Length < k || source == null)
        {
            return null;
        }

        var maxHeap = new MaxHeap<int>();

        for (var i = 0; i < source.Length; i++)
        {
            if (i < k)
            {
                maxHeap.Insert(source[i]);
            }
            else
            {
                var max = maxHeap.Values[0];

                if (max > source[i])
                {
                    maxHeap.ExtractMax();
                    maxHeap.Insert(source[i]);
                }
            }
        }

        return maxHeap.Values.ToArray();
    }

    // ====================测试代码====================
    public static void P210Test(string P210TestName, int[] data, int[]? expectedResult, int k)
    {
        if (P210TestName != null)
            Console.WriteLine($"{P210TestName} begins:");

        var vectorData = data?.ToArray();

        if (expectedResult == null)
            Console.WriteLine("The input is invalid, we don't expect any result.");
        else
        {
            Console.WriteLine($"Expected result:\n{System.Text.Json.JsonSerializer.Serialize(expectedResult)}");
        }

        Console.WriteLine(
            $"Result for solution1:\n{System.Text.Json.JsonSerializer.Serialize(P210LeastKNumbers(vectorData, k))}");

        Console.WriteLine(
            $"Result for solution2:\n{System.Text.Json.JsonSerializer.Serialize(P210LeastKNumbersAlternative(data, k))}\n");
    }

    // k小于数组的长度
    public static void P210Test1()
    {
        int[] data = { 4, 5, 1, 6, 2, 7, 3, 8 };
        int[] expected = { 1, 2, 3, 4 };
        P210Test("P210Test1", data, expected, expected.Length);
    }

    // k等于数组的长度
    public static void P210Test2()
    {
        int[] data = { 4, 5, 1, 6, 2, 7, 3, 8 };
        int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8 };
        P210Test("P210Test2", data, expected, expected.Length);
    }

    // k大于数组的长度
    public static void P210Test3()
    {
        int[] data = { 4, 5, 1, 6, 2, 7, 3, 8 };
        int[] expected = null;
        P210Test("P210Test3", data, expected, 10);
    }

    // k等于1
    public static void P210Test4()
    {
        int[] data = { 4, 5, 1, 6, 2, 7, 3, 8 };
        int[] expected = { 1 };
        P210Test("P210Test4", data, expected, expected.Length);
    }

    // k等于0
    public static void P210Test5()
    {
        int[] data = { 4, 5, 1, 6, 2, 7, 3, 8 };
        int[] expected = null;
        P210Test("P210Test5", data, expected, 0);
    }

    // 数组中有相同的数字
    public static void P210Test6()
    {
        int[] data = { 4, 5, 1, 6, 2, 7, 2, 8 };
        int[] expected = { 1, 2 };
        P210Test("P210Test6", data, expected, expected.Length);
    }

    // 输入空指针
    public static void P210Test7()
    {
        int[] expected = null;
        P210Test("P210Test7", null, expected, 0);
    }

}
