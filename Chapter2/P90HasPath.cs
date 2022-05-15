namespace Algorithm.Chapter2
{
    public static partial class Solution
    {
        public static bool HasPathP90(char[] matrix, int rows, int cols, string str)
        {
            if (rows < 1 || cols < 1 || matrix == null || matrix.Length != rows * cols || string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    if (HasPathP90Core(matrix, i, j, rows, cols, str, 0, new bool[matrix.Length]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool HasPathP90Core(char[] matrix, int row, int col, int rows, int cols, string str, int pathLen, bool[] visited)
        {
            var hasPath = false;

            if (pathLen == str.Length)
            {
                return true;
            }

            if (pathLen < str.Length
                && row < rows
                && col < cols
                && row >= 0
                && col >= 0
                && matrix[row * cols + col] == str[pathLen]
                && !visited[row * cols + col])
            {
                visited[row * cols + col] = true;

                hasPath = HasPathP90Core(matrix, row + 1, col, rows, cols, str, pathLen + 1, visited)
                    || HasPathP90Core(matrix, row - 1, col, rows, cols, str, pathLen + 1, visited)
                    || HasPathP90Core(matrix, row, col + 1, rows, cols, str, pathLen + 1, visited)
                    || HasPathP90Core(matrix, row, col - 1, rows, cols, str, pathLen + 1, visited);

                if (!hasPath)
                {
                    visited[row * cols + col] = false;
                }
            }

            return hasPath;
        }

        public static int TestHasPathP90()
        {
            // ====================测试代码====================
            void Test(string testName, char[] matrix, int rows, int cols, string str, bool expected)
            {
                if (testName != null)
                    Console.WriteLine($"{testName} begins: ");

                if (HasPathP90(matrix, rows, cols, str) == expected)
                    Console.WriteLine("Passed.\n");
                else
                    Console.WriteLine("FAILED.\n");
            }

            //ABTG
            //CFCS
            //JDEH

            //BFCE
            void Test1()
            {
                var matrix = "ABTGCFCSJDEH".ToArray();
                string str = "BFCE";

                Test("Test1", matrix, 3, 4, str, true);
            }

            //ABCE
            //SFCS
            //ADEE

            //SEE
            void Test2()
            {
                var matrix = "ABCESFCSADEE".ToArray();
                string str = "SEE";

                Test("Test2", matrix, 3, 4, str, true);
            }

            //ABTG
            //CFCS
            //JDEH

            //ABFB
            void Test3()
            {
                var matrix = "ABTGCFCSJDEH".ToArray();
                string str = "ABFB";

                Test("Test3", matrix, 3, 4, str, false);
            }

            //ABCEHJIG
            //SFCSLOPQ
            //ADEEMNOE
            //ADIDEJFM
            //VCEIFGGS

            //SLHECCEIDEJFGGFIE
            void Test4()
            {
                var matrix = "ABCEHJIGSFCSLOPQADEEMNOEADIDEJFMVCEIFGGS".ToArray();
                string str = "SLHECCEIDEJFGGFIE";

                Test("Test4", matrix, 5, 8, str, true);
            }

            //ABCEHJIG
            //SFCSLOPQ
            //ADEEMNOE
            //ADIDEJFM
            //VCEIFGGS

            //SGGFIECVAASABCEHJIGQEM
            void Test5()
            {
                var matrix = "ABCEHJIGSFCSLOPQADEEMNOEADIDEJFMVCEIFGGS".ToArray();
                string str = "SGGFIECVAASABCEHJIGQEM";

                Test("Test5", matrix, 5, 8, str, true);
            }

            //ABCEHJIG
            //SFCSLOPQ
            //ADEEMNOE
            //ADIDEJFM
            //VCEIFGGS

            //SGGFIECVAASABCEEJIGOEM
            void Test6()
            {
                var matrix = "ABCEHJIGSFCSLOPQADEEMNOEADIDEJFMVCEIFGGS".ToArray();
                string str = "SGGFIECVAASABCEEJIGOEM";

                Test("Test6", matrix, 5, 8, str, false);
            }

            //ABCEHJIG
            //SFCSLOPQ
            //ADEEMNOE
            //ADIDEJFM
            //VCEIFGGS

            //SGGFIECVAASABCEHJIGQEMS
            void Test7()
            {
                var matrix = "ABCEHJIGSFCSLOPQADEEMNOEADIDEJFMVCEIFGGS".ToArray();
                string str = "SGGFIECVAASABCEHJIGQEMS";

                Test("Test7", matrix, 5, 8, str, false);
            }

            //AAAA
            //AAAA
            //AAAA

            //AAAAAAAAAAAA
            void Test8()
            {
                var matrix = "AAAAAAAAAAAA".ToArray();
                string str = "AAAAAAAAAAAA";

                Test("Test8", matrix, 3, 4, str, true);
            }

            //AAAA
            //AAAA
            //AAAA

            //AAAAAAAAAAAAA
            void Test9()
            {
                var matrix = "AAAAAAAAAAAA".ToArray();
                string str = "AAAAAAAAAAAAA";

                Test("Test9", matrix, 3, 4, str, false);
            }

            //A

            //A
            void Test10()
            {
                var matrix = "A".ToArray();
                string str = "A";

                Test("Test10", matrix, 1, 1, str, true);
            }

            //A

            //B
            void Test11()
            {
                var matrix = "A".ToArray();
                string str = "B";

                Test("Test11", matrix, 1, 1, str, false);
            }

            void Test12()
            {
                Test("Test12", null, 0, 0, null, false);
            }

            Test1();
            Test2();
            Test3();
            Test4();
            Test5();
            Test6();
            Test7();
            Test8();
            Test9();
            Test10();
            Test11();
            Test12();

            return 0;
        }
    }
}