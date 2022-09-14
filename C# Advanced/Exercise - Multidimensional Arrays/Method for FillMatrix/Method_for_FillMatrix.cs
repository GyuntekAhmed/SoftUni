using System;
using System.Linq;

internal class Method_for_FillMatrix
{
    static void Main()
    {
        string input = Console.ReadLine();
        int rows = int.Parse(input.Split()[0]);
        int cols = int.Parse(input.Split()[1]);

        int[,] matrix = new int[rows, cols];

        FillMatrix(matrix);

    }

    public static void FillMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int[] rowData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = rowData[col];
            }
        }
    }
}
