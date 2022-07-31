namespace Algorithm.Chapter5;

public static partial class Solution
{
    public class P215MedianOfStream
    {
        private readonly MaxHeap<int> _left = new();

        private readonly MinHeap<int> _right = new();

        private int _count = 0;

        public void Insert(int val)
        {
            _count++;

            if ((_count & 1) == 1)
            {
                _right.Insert(val);

                _left.Insert(_right.ExtractMin());
            }
            else
            {
                _left.Insert(val);

                _right.Insert(_left.ExtractMax());
            }
        }

        public decimal GetMedian()
        {
            if ((_count & 1) == 1)
            {
                return _left.Values[0];
            }

            return (_left.Values[0] + _right.Values[0]) / 2m;
        }
    }

    // ====================测试代码====================
    public static void P215Test(string testName, P215MedianOfStream numbers, decimal expected)
    {
        if (testName != null)
            Console.Write($"{testName} begins: ");

        if (Math.Abs(numbers.GetMedian() - expected) < 0.0000001m)
            Console.Write("Passed.\n");
        else
            Console.Write("FAILED.\n");
    }

    public static void P215Test()
    {
        P215MedianOfStream numbers = new();

        Console.Write("Test1 begins: ");
        try
        {
            numbers.GetMedian();
            Console.Write("FAILED.\n");
        }
        catch
        {
            Console.Write("Passed.\n");
        }

        numbers.Insert(5);
        P215Test("Test2", numbers, 5);

        numbers.Insert(2);
        P215Test("Test3", numbers, 3.5m);

        numbers.Insert(3);
        P215Test("Test4", numbers, 3);

        numbers.Insert(4);
        P215Test("Test6", numbers, 3.5m);

        numbers.Insert(1);
        P215Test("Test5", numbers, 3);

        numbers.Insert(6);
        P215Test("Test7", numbers, 3.5m);

        numbers.Insert(7);
        P215Test("Test8", numbers, 4);

        numbers.Insert(0);
        P215Test("Test9", numbers, 3.5m);

        numbers.Insert(8);
        P215Test("Test10", numbers, 4);
    }
}
