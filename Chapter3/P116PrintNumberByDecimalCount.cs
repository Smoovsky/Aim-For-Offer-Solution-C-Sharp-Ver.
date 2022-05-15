using System.Linq;

namespace Algorithm.Chapter3
{
    public static partial class Solution
    {
        public static void P116PrintNumberByDecimalCount(int length)
        {
            static void P116PrintNumberByDecimalCountRecursive(
            char[] str,
            int length,
            int index)
            {
                if (index == length)
                {
                    P116PrintNum(str);

                    return;
                }

                for (byte i = 0; i < 10; i++)
                {
                    str[index] = (char)('0' + i);

                    P116PrintNumberByDecimalCountRecursive(str, length, index + 1);
                }
            }

            P116PrintNumberByDecimalCountRecursive(
                new char[length],
                length,
                0);
        }

        public static void P116PrintNumberByDecimalCountNonRecursive(int length)
        {
            var str = Enumerable.Range(0, length).Select(_ => '0').ToArray();

            static bool Incremet(char[] str)
            {
                var overflow = false;

                var carry = 0;
                var sum = 0;

                for (int i = str.Length - 1; i >= 0; i--)
                {
                    sum = str[i] - '0' + carry;

                    if (i == str.Length - 1)
                    {
                        sum++;
                    }

                    if (sum >= 10)
                    {
                        if (i == 0)
                        {
                            overflow = true;
                        }
                        else
                        {
                            sum -= 10;
                            carry = 1;
                            str[i] = (char)('0' + sum);
                        }
                    }
                    else
                    {
                        str[i] = (char)('0' + sum);
                        break;
                    }
                }

                if (overflow)
                {
                    return false;
                }

                return true;
            };

            while (Incremet(str))
            {
                P116PrintNum(str);
            }
        }

        public static void P116PrintNum(char[] str)
        {
            Console.WriteLine(new string(str).TrimStart('0'));
        }

        public static void TestP116PrintNumberByDecimalCount()
        {
            P116PrintNumberByDecimalCount(5);
            P116PrintNumberByDecimalCountNonRecursive(5);
        }
    }
}