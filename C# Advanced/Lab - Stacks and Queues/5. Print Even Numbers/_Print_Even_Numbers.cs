using System;
using System.Collections.Generic;
using System.Linq;

class _Print_Even_Numbers
{
    static void Main()
    {
        Queue<int> queue = new Queue<int>();

        int[] numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] % 2 == 0)
            {
                int number = numbers[i];
                queue.Enqueue(number);
            }
        }

        Console.WriteLine(string.Join(", ", queue));
    }
}
