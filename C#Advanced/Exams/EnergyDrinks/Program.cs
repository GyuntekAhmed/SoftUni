using System;
using System.Collections.Generic;
using System.Linq;

namespace EnergyDrinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> miligrams = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Queue<int> energyDrinks = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int canDrink = 0;
            int stamatCafeine = 300;

            while (miligrams.Count != 0 && energyDrinks.Count != 0)
            {
                int sum = miligrams.Peek() * energyDrinks.Peek();

                if (sum < stamatCafeine)
                {
                    stamatCafeine -= sum;
                    miligrams.Pop();
                    energyDrinks.Dequeue();
                    canDrink += sum;
                }
                else
                {
                    miligrams.Pop();
                    int currentDrink = energyDrinks.Peek();
                    energyDrinks.Dequeue();
                    energyDrinks.Enqueue(currentDrink);
                    canDrink -= 30;
                    stamatCafeine -= Math.Abs(canDrink);
                    stamatCafeine = 300 - Math.Abs(canDrink);
                }
            }

            if (energyDrinks.Count > 0)
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinks)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }
            Console.WriteLine($"Stamat is going to sleep with {canDrink} mg caffeine.");
        }
    }
}
