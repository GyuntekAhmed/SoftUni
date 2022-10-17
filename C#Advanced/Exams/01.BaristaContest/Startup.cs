using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BaristaContest
{
    internal class Startup
    {
        static void Main()
        {
            Dictionary<string, int> drinksTable = new Dictionary<string, int>
            {
                {"Cortado", 50 },
                {"Espresso", 75 },
                {"Capuccino", 100 },
                {"Americano", 150 },
                {"Latte", 200 },
            };
            Dictionary<string, int> drinksCount = new Dictionary<string, int>();

            Queue<int> cofeeQuantities = new Queue<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray());
            Stack<int> milkQuantities = new Stack<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray());

            while (cofeeQuantities.Count != 0 || milkQuantities.Count != 0)
            {
                int sumOfDrinks = cofeeQuantities.Peek() + milkQuantities.Peek();

                foreach (var drink in drinksTable)
                {
                    if (sumOfDrinks == drink.Value)
                    {
                        string drinkName = drink.Key;
                        if (!drinksCount.ContainsKey(drinkName))
                        {
                            drinksCount.Add(drinkName, 1);
                            cofeeQuantities.Dequeue();
                            milkQuantities.Pop();
                            break;
                        }
                        else
                        {
                            drinksCount[drinkName]++;
                            cofeeQuantities.Dequeue();
                            milkQuantities.Pop();
                            break;
                        }
                    }
                }
            }
        }
    }
}
