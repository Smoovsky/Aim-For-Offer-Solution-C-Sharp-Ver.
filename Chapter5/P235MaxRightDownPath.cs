namespace Algorithm.Chapter5;

public static partial class Solution
{
    public static int P235MaxRightDownPath(int[][] maze, int rows, int cols)
    {
        if (maze == null || rows <= 0 || cols <= 0)
        {
            return 0;
        }

        var max = new int[cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                var up = 0;
                var left = 0;

                if (i > 0)
                {
                    up = max[j];
                }

                if (j > 0)
                {
                    left = max[j - 1];
                }

                max[j] = maze[i][j] + (up > left ? up : left);
            }
        }

        return max.Max();
    }

    // ====================测试代码====================
    public static void P235Test(string testName, int[][] values, int rows, int cols, int expected)
    {
        if (P235MaxRightDownPath(values, rows, cols) == expected)
            Console.WriteLine($"{testName}: solution1 passed.");
        else
            Console.WriteLine($"{testName}: solution1 FAILED."); ;

        // if(getMaxValue_solution2(values, rows, cols) == expected)
        //     std::cout << testName << ": solution2 passed." << std::endl;
        // else
        //     std::cout << testName << ": solution2 FAILED." << std::endl;
    }

    public static void P235Test1()
    {
        // 三行三列
        int[][] values = new[]
        {
            new []{ 1, 2, 3 },
            new []{ 4, 5, 6 },
            new []{ 7, 8, 9 }
        };
        int expected = 29;
        P235Test("test1", values, 3, 3, expected);
    }

    public static void P235Test2()
    {
        //四行四列
        int[][] values = new[]{
            new [] { 1, 10, 3, 8 },
        new [] { 12, 2, 9, 6 },
        new [] { 5, 7, 4, 11 },
        new [] { 3, 7, 16, 5 }
        };
        int expected = 53;
        P235Test("test2", values, 4, 4, expected);
    }

    public static void P235Test3()
    {
        // 一行四列
        int[][] values = new[]{
            new [] { 1, 10, 3, 8 }
        };
        int expected = 22;
        P235Test("test3", values, 1, 4, expected);
    }

    public static void P235Test4()
    {
        int[][] values = new[]{
            new[] { 1 },
        new[] { 12 },
        new[] { 5 },
        new[] { 3 }
        };
        int expected = 21;
        P235Test("test4", values, 4, 1, expected);
    }

    public static void P235Test5()
    {
        // 一行一列
        int[][] values = new[]{
            new [] { 3 }
        };
        int expected = 3;
        P235Test("test5", values, 1, 1, expected);
    }

    public static void P235Test6()
    {
        // 空指针
        int expected = 0;
        P235Test("test6", null, 0, 0, expected);
    }

    public static void P235Test()
    {
        P235Test1();
        P235Test2();
        P235Test3();
        P235Test4();
        P235Test5();
    }
}
