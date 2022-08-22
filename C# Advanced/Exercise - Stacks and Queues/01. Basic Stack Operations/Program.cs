using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int countOfNumbers = numbers[0];

            int[] numbersToChek = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int x = 0;
            int chekPosition = numbers[1];
            int chekNumber = numbers[2];

            for (int i = 0; i < countOfNumbers; i++)
            {
                stack.Push(numbersToChek[i]);

                if (i + 1 == chekPosition)
                {
                    x = numbersToChek[i];
                }
            }

            if (x == chekNumber)
            {
                Console.WriteLine("true");
            }
            else if (x != chekNumber)
            {
                Console.WriteLine(stack.Min());
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
        }
    }
}
