namespace Algorithm
{
    public static partial class Solution
    {
        public static int QuickSortPartitionP80(int[] array, int start, int end)
        {
            var index = start + new Random().Next(end - start);

            Swap(ref array[index], ref array[end]);

            var smallBoundary = start - 1;

            for (index = start; index < end; index++)
            {
                if (array[index] < array[end])
                {
                    smallBoundary++;

                    if (index != smallBoundary)
                    {
                        Swap(ref array[index], ref array[smallBoundary]);
                    }
                }
            }

            smallBoundary++;

            Swap(ref array[end], ref array[smallBoundary]);

            return smallBoundary;
        }

        public static void QuickSortP80(int[] array) => QuickSortP80(array, 0, array.Length - 1);

        public static void QuickSortP80(int[] array, int start, int end)
        {
            var index = QuickSortPartitionP80(array, start, end);

            if (index > start)
            {
                QuickSortP80(array, start, index - 1);
            }

            if (index < end)
            {
                QuickSortP80(array, index + 1, end);
            }
        }

        public static void Swap(ref int x, ref int y) => (y, x) = (x, y);
    }
}