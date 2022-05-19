namespace Algorithm.Chapter3
{
    public static partial class Solution
    {
        public static void P130MoveArrayOddEvenTwoPointers(int[] src)
        {
            if (src?.Length > 1 != true)
            {
                return;
            }

            var pt2 = src.Length - 1;

            for (var pt1 = 0; pt1 < pt2; pt1++)
            {
                if ((src[pt1] & 0x1) == 0)
                {
                    while ((pt2 > pt1) && ((src[pt2] & 0x1) == 0))
                    {
                        pt2--;
                    }

                    if (pt1 < pt2)
                    {
                        Swap(ref src[pt1], ref src[pt2]);
                    }
                }
            }
        }

        public static void Swap(ref int x, ref int y) => (x, y) = (y, x);
    }
}