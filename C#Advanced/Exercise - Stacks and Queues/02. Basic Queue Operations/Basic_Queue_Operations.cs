using System;
using System.Collections.Generic;
using System.Linq;

class Basic_Queue_Operations
{
    static void Main()
    {
        Queue<int> queue = new Queue<int>();

        int[] numbers = Console.ReadLine()
                        .Split(' ')
                        .Select(int.Parse)
                        .ToArray();
        int n = numbers[0];
        int s = numbers[1];
        int x = numbers[2];

        List<int> numberList = Console.ReadLine()
                               .Split(' ')
                               .Select(int.Parse)
                               .ToList();

        for (int i = 0; i < n; i++)
        {
            queue.Enqueue(numberList[i]);
        }

        for (int i = 0; i < s; i++)
        {
            queue.Dequeue();
        }

        if (queue.Count == 0)
        {
            Console.WriteLine(0);
        }
        else if (queue.Contains(x))
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine(queue.Min());
        }
    }
}
