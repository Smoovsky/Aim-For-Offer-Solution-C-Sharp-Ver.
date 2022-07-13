using System.Collections.Generic;

namespace Algorithm.Chapter4;

public static partial class Solution
{
    public static void P198Permunation(
        char[]? source,
        int startIndex = 0)
    {
        if (source?.Any() != true)
        {
            return;
        }

        if (startIndex == source.Length - 1)
        {
            Console.WriteLine(string.Join(',', source));

        }
        else
        {
            for (var i = startIndex; i < source.Length; i++)
            {
                Swap(ref source[startIndex], ref source[i]);

                P198Permunation(source, i + 1);

                Swap(ref source[startIndex], ref source[i]);
            }
        }
    }

    public static void P198LengthNCombination(
        char[]? source,
        int n,
        int startIndex = 0,
        Stack<char> path = null)
    {
        if (source?.Any() != true || n <= 0)
        {
            return;
        }

        path ??= new();

        if (path.Count == n)
        {
            Console.WriteLine(string.Join(',', path));
        }
        else
        {
            for (var i = startIndex; i < source.Length; i++)
            {
                path.Push(source[i]);

                P198LengthNCombination(source, n, i + 1, path);

                path.Pop();
            }
        }
    }

    public static void P198Combination(char[]? source)
    {
        if (source?.Any() != true)
        {
            return;
        }

        for (int i = 1; i <= source.Length; i++)
        {
            P198LengthNCombination(source, i);
        }
    }
}
