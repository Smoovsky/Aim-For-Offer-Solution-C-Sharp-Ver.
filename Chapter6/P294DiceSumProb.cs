namespace Algorithm.Chapter6;

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

        return probArr!;
    }

    // public static decimal[] P294DiceSumProbLoop(int numOfDice)
    // {
    //     var result = new int[2][];
    //     result[0] = new int[numOfDice * DieFaceCount];
    //     result[1] = new int[numOfDice * DieFaceCount];

    //     var flg = 0;

    //     for (var i = 1; i <= numOfDice; i++)
    //     {
    //         if (i == 1)
    //         {
    //             for (var j = 1; j <= 6; j++)
    //             {
    //                 result[flg][j] = 1;
    //             }
    //         }
    //         else
    //         {
    //             for (var j = 1; j <= i; j++)
    //             {
    //                 result[flg][j] = 0;
    //             }

                
    //         }

    //         flg = 1 - flg;
    //     }
    // }
}
