using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> orders = new Dictionary<string, double>();
            Dictionary<string, int> newOrders = new Dictionary<string, int>();

            while (true)
            {
                string comand = Console.ReadLine();
                if (comand == "buy")
                {
                    break;
                }

                string[] tokens = comand.Split();

                string ordersName = tokens[0];
                double price = double.Parse(tokens[1]);
                int quantity = int.Parse(tokens[2]);

                if (!orders.ContainsKey(ordersName))
                {
                    orders.Add(ordersName, price);
                    newOrders.Add(ordersName, quantity);
                }
                else if (orders.ContainsKey(ordersName))
                {
                    orders.Remove(ordersName);
                    orders.Add(ordersName, price);
                    newOrders[ordersName] += quantity;
                }
                
            }

            foreach (var order in orders)
            {
                foreach (var newOrder in newOrders)
                {
                    if (order.Key == newOrder.Key)
                    {
                        Console.WriteLine($"{order.Key} -> {order.Value * newOrder.Value:f2}");
                    }
                }
            }
        }
    }
}
