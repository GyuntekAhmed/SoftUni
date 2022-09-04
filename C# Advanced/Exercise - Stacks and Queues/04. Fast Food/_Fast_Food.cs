using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
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
}
