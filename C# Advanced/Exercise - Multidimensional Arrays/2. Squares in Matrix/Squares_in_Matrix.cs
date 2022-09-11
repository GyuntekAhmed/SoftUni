using System;
using System.Linq;

class Squares_in_Matrix
{
    static void Main()
    {
        int[] sizeOfMatrix = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        int rows = sizeOfMatrix[0];
        int cols = sizeOfMatrix[1];

        string[,] matrix = new string[rows, cols];

        FillMatrix(matrix);

        int count = 0;

        for (int row = 0; row < rows - 1; row++)
        {
            for (int col = 0; col < cols - 1; col++)
            {
                if (matrix[row, col] == matrix[row, col + 1]
                    && matrix[row, col] == matrix[row + 1, col]
                    && matrix[row, col] == matrix[row + 1, col + 1])
                {
                    count++;
                }
            }
        }

        Console.WriteLine(count);
    }
    public static void FillMatrix(string[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string[] rowData = Console.ReadLine().Split();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = rowData[col];
            }
        }
    }
}
