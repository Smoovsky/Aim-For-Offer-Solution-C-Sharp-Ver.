namespace Algorithm
{
    public static partial class Solution
    {
        public static void ReplaceSpaceP53(
            List<char> source)
        {
            var len = source.Count;

            var spaceCount = source
                .Where(c => c == ' ')
                .Count();

            var newLen = len + spaceCount * 2;

            source.AddRange(new char[newLen - len]);

            var p1Index = len - 1;
            var p2Index = newLen - 1;

            while (p1Index >= 0 && p1Index < p2Index)
            {
                if (source[p1Index] == ' ')
                {
                    source[p2Index--] = '0';
                    source[p2Index--] = '2';
                    source[p2Index--] = '%';
                }
                else
                {
                    source[p2Index--] = source[p1Index];
                }

                p1Index--;
            }

            Console.WriteLine(string.Join(string.Empty, source));
        }
    }
}