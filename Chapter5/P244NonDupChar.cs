namespace Algorithm.Chapter5;

public static partial class Solution
{
    public static char P244NonDupChar(string source)
    {
        if (!(source?.Length > 0))
        {
            return '\0';
        }

        var occuCounrArr = Enumerable.Range(0, 256).Select(i => 0).ToArray();

        foreach (var c in source)
        {
            occuCounrArr[c - 'A']++;
        }

        foreach (var c in source)
        {
            if (occuCounrArr[c - 'A'] == 1)
            {
                return c;
            }
        }

        return '\0';
    }

    public class P244NonDupCharInStream
    {
        private int _currentIndex = 0;

        private readonly int[] _occuCountArr = Enumerable.Range(0, 256).Select(i => -1).ToArray();

        public void Insert(char c)
        {
            _ = _occuCountArr[c - 'A'] == -1
                ? _occuCountArr[c - 'A'] = _currentIndex
                : _occuCountArr[c - 'A'] = -2;

            _currentIndex++;
        }

        public char FirstAppearingOnce()
        {
            var minCharIndex = -1;
            var minChar = 0;

            for (int i = 0; i < 256; i++)
            {
                var charIndex = _occuCountArr[i];

                if(charIndex >= 0)
                {
                    if (minCharIndex == -1 || charIndex < minCharIndex)
                    {
                        minCharIndex = charIndex;
                        minChar = i;
                    }
                }
            }

            if (minCharIndex >= 0)
            { 
                return (char)(minChar + 'A');
            }

            return '\0';
        }
    }
}
