namespace Algorithm.Chapter6;

public static partial class Solution
{
    public static bool P298IsStraight(int[] numbers)
    {
        if (numbers?.Any() != true)
        {
            return false;
        }

        var sorted = QuickSort(numbers);

        var zeroCount = 0;
        var gapCount = 0;

        for (var i = 0; i < numbers.Length; i++)
        {
            if (sorted[i] == 0)
            {
                zeroCount++;

                continue;
            }

            if (i > 0
                && sorted[i - 1] != 0
                && sorted[i] == sorted[i - 1])
            {
                return false;
            }

            if (i > 0
                && sorted[i - 1] != 0
                && sorted[i] - sorted[i - 1] > 1)
            {
                gapCount += sorted[i] - sorted[i - 1] - 1;
            }
        }

        return zeroCount >= gapCount;
    }
}
