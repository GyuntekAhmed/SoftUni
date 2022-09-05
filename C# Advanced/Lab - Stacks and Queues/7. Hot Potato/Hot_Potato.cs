using System;
using System.Collections.Generic;

class Hot_Potato
{
    static void Main()
    {
        string[] players = Console.ReadLine()
            .Split();
        int count = int.Parse(Console.ReadLine());

        Queue<string> queue = new Queue<string>(players);

        while (queue.Count > 1)
        {
            for (int i = 1; i < count; i++)
            {
                string player = queue.Dequeue();
                queue.Enqueue(player);
            }

            string lostPlayer = queue.Dequeue();

            Console.WriteLine($"Removed {lostPlayer}");
        }

        string lastPlayer = queue.Dequeue();

        Console.WriteLine($"Last is {lastPlayer}");
    }
}
