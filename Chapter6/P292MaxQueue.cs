using System.Collections.Generic;

namespace Algorithm.Chapter6;

public static partial class Solution
{
    public class P292MaxQueue
    {
        private int CurrentIndex = 0;

        private readonly List<(int Idx, int Data)> Data = new();

        private readonly List<(int Idx, int Data)> Maxus = new();

        public int Max()
        {
            if (Maxus.Count == 0)
            {
                throw new Exception();
            }

            return Maxus.First().Data;
        }

        public void Push(int data)
        {
            var internalData = (CurrentIndex++, data);

            Data.Add(internalData);

            while (Maxus.Count > 0 && Maxus.Last().Data < data)
            {
                Maxus.RemoveAt(Maxus.Count - 1);
            }

            Maxus.Add(internalData);
        }

        public int Pop()
        {
            if (Data.Count == 0)
            {
                throw new Exception();
            }

            var result = Data.First();

            Data.RemoveAt(0);

            if (result.Idx == Maxus.First().Idx)
            {
                Maxus.RemoveAt(0);
            }

            return result.Data;
        }
    }


    // ====================测试代码====================
    public static void P292Test(string testName, P292MaxQueue queue, int expected)
    {
        if (testName != null)
            Console.Write($"{testName} begins: ");

        if (queue.Max() == expected)
            Console.Write("Passed.\n");
        else
            Console.Write("FAILED.\n");
    }

    public static void P292Test()
    {
        P292MaxQueue queue = new();
        // {2}
        queue.Push(2);
        P292Test("Test1", queue, 2);

        // {2, 3}
        queue.Push(3);
        P292Test("Test2", queue, 3);

        // {2, 3, 4}
        queue.Push(4);
        P292Test("Test3", queue, 4);

        // {2, 3, 4, 2}
        queue.Push(2);
        P292Test("Test4", queue, 4);

        // {3, 4, 2}
        queue.Pop();
        P292Test("Test5", queue, 4);

        // {4, 2}
        queue.Pop();
        P292Test("Test6", queue, 4);

        // {2}
        queue.Pop();
        P292Test("Test7", queue, 2);

        // {2, 6}
        queue.Push(6);
        P292Test("Test8", queue, 6);

        // {2, 6, 2}
        queue.Push(2);
        P292Test("Test9", queue, 6);

        // {2, 6, 2, 5}
        queue.Push(5);
        P292Test("Test9", queue, 6);

        // {6, 2, 5}
        queue.Pop();
        P292Test("Test10", queue, 6);

        // {2, 5}
        queue.Pop();
        P292Test("Test11", queue, 5);

        // {5}
        queue.Pop();
        P292Test("Test12", queue, 5);

        // {5, 1}
        queue.Push(1);
        P292Test("Test13", queue, 5);
    }
}
