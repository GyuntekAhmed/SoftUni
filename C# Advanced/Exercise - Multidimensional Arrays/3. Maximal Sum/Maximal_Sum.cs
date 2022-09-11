using System;
using System.Linq;
using System.Text;

class Maximal_Sum
{
    static void Main()
    {
        int[] size = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        int[,] matrix = new int[size[0], size[1]];

        for (int i = 0; i < size[0]; i++)
        {
            int[] colEl = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)  //тук се чупи, затова го добавих
                .Select(int.Parse)
                .ToArray();
            for (int j = 0; j < size[1]; j++)
            {
                matrix[i, j] = colEl[j];
            }
        }
        //int[,] newMatrix = new int[3, 3]; не е нужно
        int startRow = 0;
        int startCol = 0;
        int largest = 0;

        for (int i = 0; i < matrix.GetLength(0) - 2; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 2; j++)
            {
                int sum = 0;

                for (int x = i; x < i + 3; x++)
                {
                    for (int y = j; y < j + 3; y++)
                    {
                        sum += matrix[x, y];
                    }
                }
                if (sum > largest)
                {
                    largest = sum;
                    startRow = i; //начало на квадрата
                    startCol = j; //начало на квадрата
                }
            }
        }

        StringBuilder sb = new StringBuilder(); //за да се намали броя писане в конзолата
        sb.AppendLine($"Sum = {largest}");
        for (int i = startRow; i < startRow + 3; i++)
        {
            for (int y = startCol; y < startCol + 3; y++)
            {
                sb.Append(matrix[i, y] + " ");
            }
            sb.AppendLine();
        }
        Console.WriteLine(sb.ToString().Trim());
    }
}