using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_of_Products
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfNumbers = int.Parse(Console.ReadLine());

            List<string> products = new List<string>();

            for (int i = 0; i < countOfNumbers; i++)
            {
                string product = Console.ReadLine();
                products.Add(product);
            }

            products.Sort();

            int num = 1;

            foreach (var product in products)
            {
                Console.WriteLine($"{num}.{product}");
                num++;
            }
        }
    }
}
