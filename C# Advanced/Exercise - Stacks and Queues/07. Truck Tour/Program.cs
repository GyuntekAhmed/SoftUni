using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] amount = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.WriteLine(amount.Min());
        }
    }
}
