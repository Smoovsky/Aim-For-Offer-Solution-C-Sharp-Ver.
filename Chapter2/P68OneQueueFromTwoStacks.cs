namespace Algorithm.Chapter2
{
    public static partial class Solution
    {
        public class CustomQueue<T>
        {
            private readonly Stack<T> _s1 = new();
            private readonly Stack<T> _s2 = new();

            public void Enqueue(T element) => _s1.Push(element);

            public T Dequeue()
            {
                if (!_s2.Any() && !_s1.Any())
                {
                    throw new InvalidOperationException("Sequence is empty");
                }

                if (_s2.Any())
                {
                    return _s2.Pop();
                }

                while (_s1.Any())
                {
                    _s2.Push(_s1.Pop());
                }

                return _s2.Pop();
            }
        }

        public static void Test(char actual, char expected)
        {
            if (actual == expected)
                Console.Write("Test passed.\n");
            else
                Console.Write("Test failed.\n");
        }
    }
}