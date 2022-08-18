namespace Algorithm.Chapter5;

public static partial class Solution
{
    public static void P250CountInversePairs(
        int[] source,
        ref int reversePairCount,
        int[] copy = null,
        int? start = null,
        int? end = null)
    {
        if (!(source?.Length > 1))
        {
            return;
        }

        start ??= 0;
        end ??= source.Length;
        copy ??= new int[source.Length];

        if (end == start)
        {
            copy[end.Value] = source[end.Value];

            return;
        }

        var mid = (end - start) / 2 + start;

        if (end - start > 1)
        {
            P250CountInversePairs(
                source,
                ref reversePairCount,
                copy,
                start,
                mid);

            P250CountInversePairs(
                source,
                ref reversePairCount,
                copy,
                mid + 1,
                end);
        }

        var p1 = mid.Value;
        var p2 = end.Value;
        var p3 = end.Value;

        while (p1 >= start || p2 > mid)
        {
            if (p1 >= start
                && p2 > mid
                && source[p1] > source[p2])
            {
                reversePairCount += p1 - start.Value + 1;
                copy[p3--] = source[p1--];
            }
            else if (p2 > mid)
            {
                copy[p3--] = source[p2--];
            }
            else if (p1 >= start)
            {
                copy[p3--] = source[p1--];
            }
        }
    }
}
