﻿using System;
using System.Linq;

class Jagged_Array_Manipulator
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());

        int[][] matrix = new int[rows][];

        for (int row = 0; row < rows; row++)
        {
            matrix[row] = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
        }

        for (int row = 0; row < rows - 1; row++)
        {
            if (matrix[row].Length == matrix[row + 1].Length)
            {
                matrix[row] = matrix[row].Select(el => el * 2).ToArray();
                matrix[row + 1] = matrix[row + 1].Select(el => el * 2).ToArray();
            }
            else
            {
                matrix[row] = matrix[row].Select(el => el / 2).ToArray();
                matrix[row + 1] = matrix[row + 1].Select(el => el / 2).ToArray();
            }
        }

        while (true)
        {
            string command = Console.ReadLine();

            if (command == "End")
            {
                break;
            }

            int row = int.Parse(command.Split()[1]);
            int col = int.Parse(command.Split()[2]);
            int value = int.Parse(command.Split()[3]);

            if (command.StartsWith("Add"))
            {
                if (row >= 0 && row < rows && col >= 0 && col < matrix[row].Length)
                {
                    matrix[row][col] += value;
                }
            }
            else if (command.StartsWith("Subtract"))
            {
                if (row >= 0 && row < rows && col >= 0 && col < matrix[row].Length)
                {
                    matrix[row][col] -= value;
                }
            }
        }

        foreach (int[] row in matrix)
        {
            Console.WriteLine(string.Join(' ', row));
        }
    }
}
