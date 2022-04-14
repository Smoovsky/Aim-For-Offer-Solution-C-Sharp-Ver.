namespace Algorithm
{
    public static partial class Solution
    {
        public static int RotationArrayMinP84(int[] array)
        {
            var pt1 = 0;
            var pt2 = array.Length - 1;

            var mid = (pt2 - pt1) / 2;

            while (pt1 + 1 < pt2)
            {
                if (array[mid] >= array[pt1] && array[mid] <= array[pt2])
                {
                    throw new ArgumentException("Invalid argument.");
                }

                if (array[mid] >= array[pt1])
                {
                    pt1 = mid;
                }
                else if (array[mid] <= array[pt2])
                {
                    pt2 = mid;
                }
                else
                {
                    throw new ArgumentException("Invalid argument.");
                }

                mid = pt1 + (pt2 - pt1) / 2;
            }

            return array[pt2];
        }
    }
}