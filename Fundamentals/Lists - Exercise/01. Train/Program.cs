using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int capacity = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] tokens = command.Split();

                if (tokens.Length == 2)
                {
                    int wagon = int.Parse(tokens[1]);
                    wagons.Add(wagon);
                }
                else
                {
                    int passengers = int.Parse(tokens[0]);
                    FindWagons(wagons, capacity, passengers);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", wagons));
        }

        private static void FindWagons(List<int> wagons, int capacity, int passengers)
        {
            for (int i = 0; i < wagons.Count; i++)
            {
                int currWagon = wagons[i];

                if (currWagon + passengers <= capacity)
                {
                    wagons[i] += passengers;

                    break;
                }
            }
        }
    }
}
