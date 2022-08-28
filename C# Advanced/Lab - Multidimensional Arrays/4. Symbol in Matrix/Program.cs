using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            char[,] matrix = new char[number, number];

            for (int row = 0; row < number; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool isFind = false;

            for (int row = 0; row < number; row++)
            {
                for (int col = 0; col < number; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isFind = true;
                        break;
                    }
                }
            }

            if (!isFind)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }

        }
    }
}
