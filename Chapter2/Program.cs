// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// static int Duplicate(int[] nums, out int res)
// {
//     if (nums == null)
//     { 
//         throw new 
//     }

//     var len = nums.Length;
// }

static int GetDuplicateP41(int[] source)
{
    var countFunc = new Func<int, int, int[], int>((start, end, arr) =>
    {
        var count = 0;

        foreach (var num in arr)
        {
            if (num >= start && num <= end)
            {
                count++;
            }
        }

        return count;
    });

    var len = source.Length; // range: 1 ~ len - 1

    int start = 1;
    int end = len - 1;

    while (end >= start)
    {
        var middle = (end - start) / 2; // auto-floored

        var count = countFunc(start, middle, source);

        if (end == start)
        {
            if (count > 1)
            {
                return end;
            }

            break;
        }

        if (count > (middle - start + 1))
        {
            end = middle;
        }
        else
        {
            start = middle;
        }
    }

    return -1;
}