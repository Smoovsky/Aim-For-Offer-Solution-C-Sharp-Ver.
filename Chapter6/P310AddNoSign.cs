namespace Algorithm.Chapter6;

public static partial class Solution
{
    public static int P310AddNoSign(
        int left,
        int right)
    {
        int sum = left ^ right, carry = (left & right) << 1;
        left = sum;

        while (carry != 0)
        {
            sum = left ^ carry;
            carry = (left & carry) << 1;
            left = sum;
        }

        return sum;
    }
}
