using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
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
}
