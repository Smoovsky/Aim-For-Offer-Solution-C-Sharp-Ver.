namespace Algorithm.Chapter6;

using JSON = System.Text.Json.JsonSerializer;

public static partial class Solution
{
    public const int DieFaceCount = 6;

    public static decimal[] P294DiceSumProbRecursive(
        int numOfDice,
        int? currentDiceCount = null,
        int? currentSum = null,
        decimal[] probArr = null)
    {
        currentDiceCount ??= numOfDice;
        currentSum ??= 0;
        probArr ??= new decimal[numOfDice * DieFaceCount - numOfDice + 1];

        if (currentDiceCount == 0)
        {
            probArr[currentSum.Value - numOfDice]++;
        }
        else
        {
            for (int i = 1; i <= DieFaceCount; i++)
            {
                P294DiceSumProbRecursive(
                    numOfDice,
                    currentDiceCount - 1,
                    currentSum + i,
                    probArr);
            }
        }

        if (currentDiceCount == numOfDice)
        {
            Console.WriteLine(JSON.Serialize(probArr));
        }

        return probArr!;
    }

    public static int[] P294DiceSumProbLoop(int numOfDice)
    {
        var result = new int[2][];
        result[0] = new int[numOfDice * DieFaceCount + 1];
        result[1] = new int[numOfDice * DieFaceCount + 1];

        var flg = 0;

        for (var i = 1; i <= numOfDice; i++)
        {
            if (i == 1)
            {
                for (var j = 1; j <= DieFaceCount; j++)
                {
                    result[flg][j] = 1;
                }
            }
            else
            {
                for (var j = 1; j < i ; j++)
                {
                    result[flg][j] = 0;
                }

                for (var j = i; j <= DieFaceCount * i; j++)
                {
                    var currentCount = 0;

                    for (var k = j - 1; k >= j - 6 && k >= 1; k--)
                    {
                        currentCount += result[1 - flg][k];
                    }

                    result[flg][j] = currentCount;
                }
            }

            flg = 1 - flg;
        }

        Console.WriteLine(JSON.Serialize(result[1 - flg][numOfDice..]));

        return result[1 - flg];
    }
}
