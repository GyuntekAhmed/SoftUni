using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, int> countsByNumber = new SortedDictionary<double, int>();

            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            foreach (int number in numbers)
            {
                if (!countsByNumber.ContainsKey(number))
                {
                    countsByNumber.Add(number, 0);
                }

                countsByNumber[number]++;
            }

            foreach (var number in countsByNumber)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}
