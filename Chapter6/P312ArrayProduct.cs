namespace Algorithm.Chapter6;

public static partial class Solution
{
    public static int[] P312ArrayProduct(int[] arr)
    {
        if (!(arr?.Length > 1))
        {
            return null;
        }

        var arr1 = new int[arr.Length - 1];
        var arr2 = new int[arr.Length - 1];

        for (var i = 0; i < arr.Length - 1; i++)
        {
            if (i == 0)
            {
                arr1[0] = arr[0];
                arr2[^1] = arr[^1];
            }
            else
            {
                arr1[i] = arr[i] * arr1[i - 1];
                arr2[^(1 + i)] = arr[^(1 + i)] * arr2[^i];
            }
        }

        var result = new int[arr.Length];

        for (var i = 0; i < arr.Length; i++)
        {
            var left = i == 0
                ? 1
                : arr1[i - 1];

            var right = i == arr.Length - 1
                ? 1
                : arr2[i];

            result[i] = left * right;
        }

        return result;
    }
}
