using System.Collections.Generic;

namespace Algorithm.Chapter4;

public static partial class Solution
{
    public static int P205NumberOverHalfPartition(int[]? source)
    {
        if (!(source?.Length > 0))
        {
            return -1;
        }

        var mid = source.Length / 2;

        var index = Partition(source);

        while (index != mid)
        {
            if (index < mid)
            {
                index = Partition(source, index + 1, source.Length - 1);
            }
            else
            {
                index = Partition(source, 0, index - 1);
            }
        }

        var result = source[index];
        var count = 0;

        for (int i = 0; i < source.Length; i++)
        {
            if (source[i] == result)
            {
                count++;
            }
        }

        if (count <= source.Length / 2)
        {
            return -1;
        }

        return result;
    }
}
