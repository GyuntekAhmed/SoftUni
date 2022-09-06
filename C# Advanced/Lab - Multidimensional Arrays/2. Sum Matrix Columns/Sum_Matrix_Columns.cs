using System;
using System.Linq;

class Sum_Matrix_Columns
{
    static void Main()
    {
        // Read the matrix dimensions: rows, cols
        int[] dimensions = Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .ToArray();
        (int rowsCount, int colsCount) = (dimensions[0], dimensions[1]);

        // Read the number for the matrix
        int[,] matrix = new int[rowsCount, colsCount];

        for (int row = 0; row < rowsCount; row++)
        {
            int[] line = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            for (int col = 0; col < colsCount; col++)
            {
                matrix[row, col] = line[col];
            }
        }

        long[] colSums = new long[colsCount];

        // Calculate the matrix columns sum
        for (int row = 0; row < rowsCount; row++)
            for (int col = 0; col < colsCount; col++)
                colSums[col] += matrix[row, col];

        // Print the columns sum
        for (int col = 0; col < colsCount; col++)
            Console.WriteLine(colSums[col]);
    }
}
