using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] %2 == 0)
                {
                    int number = numbers[i];
                    queue.Enqueue(number);
                }
            }

            Console.WriteLine(string.Join(", ", queue));
        }
    }
}
