using System;
using System.Linq;

internal class Method_for_FillMatrix
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] array = new int[n, n];

        FillMatrix(array, " ");

    }

    public static void FillMatrix(int[,] array, string spliter = " ")
    {
        for (int row = 0; row < array.GetLength(0); row++)
        {
            int[] rowData = Console.ReadLine()
                .Split(spliter, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            for (int col = 0; col < array.GetLength(1); col++)
            {
                array[row, col] = rowData[col];
            }
        }
    }
}
