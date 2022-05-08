namespace Algorithm
{
    public static partial class Solution
    {
        public static int RotationArrayMinP84(int[] array)
        {
            var pt1 = 0;
            var pt2 = array.Length - 1;

            var mid = (pt2 - pt1) / 2;

            while (pt1 + 1 < pt2)
            {
                if (array[pt1] < array[pt2])
                {
                    return array[pt1];
                }

                if (array[mid] == array[pt1] && array[pt1] == array[pt2])
                {
                    return FindNextMin(array, pt1, pt2);
                }

                if (array[mid] >= array[pt1] && array[mid] <= array[pt2])
                {
                    throw new ArgumentException("Invalid argument.");
                }

                if (array[mid] >= array[pt1])
                {
                    pt1 = mid;
                }
                else if (array[mid] <= array[pt2])
                {
                    pt2 = mid;
                }
                else
                {
                    throw new ArgumentException("Invalid argument.");
                }

                mid = pt1 + (pt2 - pt1) / 2;
            }

            return array[pt2];
        }

        public static int FindNextMin(int[] array, int p1, int p2)
        {
            for (var i = p1; i <= p2; i++)
            {
                if (i > p1 && array[i] < array[i - 1])
                {
                    return array[i];
                }
            }

            return array[p2];
        }

        public static void TestRotatedArrayMinP84(int[] numbers, int expected)
        {
            int result;

            try
            {
                result = RotationArrayMinP84(numbers);

                for (int i = 0; i < numbers.Length; ++i)
                    Console.WriteLine(numbers[i].ToString());

                if (result == expected)
                    Console.WriteLine("\tpassed\n");
                else
                    Console.WriteLine("\tfailed\n");
            }
            catch
            {
                if (numbers == null)
                    Console.WriteLine("Test passed.\n");
                else
                    Console.WriteLine("Test failed.\n");
            }
        }
    }
}