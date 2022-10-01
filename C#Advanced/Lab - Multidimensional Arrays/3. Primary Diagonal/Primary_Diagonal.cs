using System;
using System.Linq;

class Primary_Diagonal
{
    static void Main()
    {
        int sizeOfMatrix = int.Parse(Console.ReadLine());

        long[][] matrix = new long[sizeOfMatrix][];
        long diagonalSum = 0;

        for (int i = 0; i < sizeOfMatrix; i++)
        {
            matrix[i] = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(long.Parse)
                        .ToArray();
            diagonalSum += matrix[i][i];
        }

        Console.WriteLine(diagonalSum);
    }
}
