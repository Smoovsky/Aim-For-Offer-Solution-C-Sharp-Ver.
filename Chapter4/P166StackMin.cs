using System.Collections.Generic;

namespace Algorithm.Chapter4;

public static partial class Solution
{
    public class P166StackMin
    {
        private readonly Stack<int> _content = new();

        private readonly Stack<int> _min = new();

        private int _currentMin = int.MaxValue;

        public void Push(int item)
        {
            if (item < _currentMin)
            {
                _currentMin = item;
                _min.Push(item);
            }
            else
            {
                _min.Push(_currentMin);
            }

            _content.Push(item);
        }

        public int Pop()
        {
            _min.Pop();

            return _content.Pop();
        }

        public int Min() => _min.Peek();
    }

    public static void P166Test(
        string testName,
        P166StackMin stack,
        int expected)
    {
        if (testName != null)
            Console.WriteLine($"{testName}begins: ");

        if (stack.Min() == expected)
            Console.WriteLine("Passed.\n");
        else
            Console.WriteLine("Failed.\n");
    }
}
