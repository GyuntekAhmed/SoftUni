﻿using System;

namespace _04._Print_and_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber =int.Parse(Console.ReadLine());
            int finishNumber =int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = startNumber; i <= finishNumber; i++)
            {
                Console.Write($"{i} ");
                sum += i;
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
