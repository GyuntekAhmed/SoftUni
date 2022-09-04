using System;
using System.Collections.Generic;
using System.Linq;

class _Fast_Food
{
    static void Main()
    {
        int quantityOfFood = int.Parse(Console.ReadLine());

        Queue<int> ordersQueue = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));

        Console.WriteLine(ordersQueue.Max());

        int countOfOrders = ordersQueue.Count;

        for (int order = 1; order <= countOfOrders; order++)
        {
            if (quantityOfFood >= ordersQueue.Peek())
            {
                quantityOfFood -= ordersQueue.Peek();
                ordersQueue.Dequeue();
            }
            else
            {
                break;
            }
        }

        if (ordersQueue.Count == 0)
        {
            Console.WriteLine("Orders complete");
        }
        else
        {
            Console.WriteLine($"Orders left: " + string.Join(" ", ordersQueue));
        }
    }
}