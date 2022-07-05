namespace Algorithm.Chapter4;

public static partial class Solution
{
    public static void P163PrintMatrixSpiral(
        int[][] matrix,
        int columns,
        int rows)
    {
        if (matrix == null
            || columns <= 0
            || rows <= 0)
        {
            return;
        }

        int start = 0;

        while (start * 2 < columns
            && start * 2 < rows)
        {
            P163PrintMatrixSpiralCore(matrix, columns, rows, start);

            start++;
        }

        Console.WriteLine(string.Empty);
    }

    public static void P163PrintMatrixSpiralCore(
        int[][] matrix,
        int columns,
        int rows,
        int start)
    {
        var endX = columns - 1 - start;
        var endY = rows - 1 - start;

        for (int i = start; i <= endX; i++)
        {
            Console.Write($"{matrix[i][start]} ");
        }

        if (endY > start)
        {
            for (int j = start + 1; j <= endY; j++)
            {
                Console.Write($"{matrix[endX][j]} ");
            }
        }

        if (endX > start && endY > start)
        {
            for (int i = endX - 1; i >= start; i--)
            {
                Console.Write($"{matrix[i][endY]} ");
            }
        }

        if (endX > start && endY > start + 1)
        {
            for (int j = endY - 1; j > start; j--)
            {
                Console.Write($"{matrix[start][j]} ");
            }
        }
    }

    public static void P163Test(int columns, int rows)
    {
        Console.WriteLine($"Test Begin: {columns} columns, {rows} rows.");

        if (columns < 1 || rows < 1)
            return;

        var numbers = new int[columns][];

        for (int i = 0; i < columns; ++i)
        {
            numbers[i] = new int[rows];
            for (int j = 0; j < rows; ++j)
            {
                numbers[i][j] = i + j * columns + 1;
            }
        }

        P163PrintMatrixSpiral(numbers, columns, rows);

        Console.WriteLine(string.Empty);
    }
}
