namespace Algorithm.Chapter6;

public static partial class Solution
{
    public static int P304MaxStockProfit(int[] prices)
    {
        if (!(prices?.Length > 1))
        {
            return -1;
        }

        var minPrice = prices[0];
        var maxProfit = prices[1] - prices[0];

        foreach (var i in prices[1..])
        {
            if ((i - minPrice) > maxProfit)
            {
                maxProfit = i - minPrice;
            }

            if (i < minPrice)
            {
                minPrice = i;
            }
        }

        return maxProfit;
    }
}
