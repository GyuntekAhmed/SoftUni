using System;
using System.Linq;

class _Sum_Matrix_Elements
{
    static void Main()
    {
        int[] dimensions = Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .ToArray();
        (int rowsCount, int colsCount) = (dimensions[0], dimensions[1]);

        int[,] matrix = new int[rowsCount, colsCount];

        for (int row = 0; row < rowsCount; row++)
        {
            int[] line = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            for (int col = 0; col < colsCount; col++)
            {
                matrix[row, col] = line[col];
            }
        }

        long sum = 0;

        for (int row = 0; row < rowsCount; row++)
            for (int col = 0; col < colsCount; col++)
                sum += matrix[row, col];
        Console.WriteLine(rowsCount);
        Console.WriteLine(colsCount);
        Console.WriteLine(sum);
    }
}
