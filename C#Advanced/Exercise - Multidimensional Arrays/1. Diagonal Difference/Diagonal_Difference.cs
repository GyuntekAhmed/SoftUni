using System;
using System.Linq;

class Diagonal_Difference
{
    static void Main(string[] args)
    {
        int sizeOfSquare = int.Parse(Console.ReadLine());

        int[][] matrix = new int[sizeOfSquare][];

        long primaryDiagonalSum = 0;
        long secondaryDiagonalSum = 0;

        for (int row = 0; row < sizeOfSquare; row++)
        {
            matrix[row] = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            primaryDiagonalSum += matrix[row][row];
        }

        int n = sizeOfSquare - 1;

        for (int i = 0; i < sizeOfSquare; i++)
        {

            for (int j = 0; j < sizeOfSquare; j++)
            {
                if (j == n)
                {
                    secondaryDiagonalSum += matrix[i][j];
                    n--;
                }
            }
        }

        long totalSum = primaryDiagonalSum - secondaryDiagonalSum;

        Console.WriteLine(Math.Abs(totalSum));
    }
}
