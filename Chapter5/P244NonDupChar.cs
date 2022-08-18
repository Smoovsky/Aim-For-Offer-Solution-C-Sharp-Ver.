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

    public static void P244Test(string pString, char expected)
    {
        if (P244NonDupChar(pString) == expected)
            Console.Write("Test passed.\n");
        else
            Console.Write("Test failed.\n");
    }

    public static void P224Test01()
    {
        // 常规输入测试，存在只出现一次的字符
        P244Test("google", 'l');

        // 常规输入测试，不存在只出现一次的字符
        P244Test("aabccdbd", '\0');

        // 常规输入测试，所有字符都只出现一次
        P244Test("abcdefg", 'a');

        // 鲁棒性测试，输入null
        P244Test(null, '\0');
    }

    // ====================测试代码====================
    public static void P244Test(string testName, P244NonDupCharInStream chars, char expected)
    {
        if (testName != null)
            Console.Write($"{testName} begins: ");

        if (chars.FirstAppearingOnce() == expected)
            Console.Write("Passed.\n");
        else
            Console.Write("FAILED.\n");
    }

    public static void P224Test02()
    {
        P244NonDupCharInStream chars = new();

        P244Test("Test1", chars, '\0');

        chars.Insert('g');
        P244Test("Test2", chars, 'g');

        chars.Insert('o');
        P244Test("Test3", chars, 'g');

        chars.Insert('o');
        P244Test("Test4", chars, 'g');

        chars.Insert('g');
        P244Test("Test5", chars, '\0');

        chars.Insert('l');
        P244Test("Test6", chars, 'l');

        chars.Insert('e');
        P244Test("Test7", chars, 'l');
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

                if (charIndex >= 0)
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
