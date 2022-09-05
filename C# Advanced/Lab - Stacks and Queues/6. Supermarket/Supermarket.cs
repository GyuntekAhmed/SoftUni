using System;
using System.Collections.Generic;

class Supermarket
{
    static void Main()
    {
        Queue<string> queue = new Queue<string>();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "End")
            {
                Console.WriteLine($"{queue.Count} people remaining.");
                break;
            }
            else if (input == "Paid")
            {
                foreach (string customer in queue)
                {
                    Console.WriteLine(customer);
                }
                queue.Clear();
            }
            else
            {
                string customer = input;
                queue.Enqueue(customer);
            }
        }
    }
}
