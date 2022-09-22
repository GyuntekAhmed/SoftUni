using System;
using System.Collections.Generic;
using System.Linq;

class Barista_Contest
{
    static void Main()
    {
        //  Coffee drink    Quantities needed

        //   Cortado              50
        //  Espresso              75
        //  Capuccino             100
        //  Americano             150
        //   Latte                200

        SortedDictionary<string, int> cofeeDrinks = new SortedDictionary<string, int>();

        Queue<int> coffeeQuantities = new Queue<int>(Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray());
        Stack<int> milkQuantities = new Stack<int>(Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray());

        for (int coffee = 0; coffee < coffeeQuantities.Count; coffee++)
        {
            for (int milk = milkQuantities.Count - 1; milk >= 0; milk--)
            {
                int currentCoffee = coffeeQuantities.Peek();
                int currentMilk = milkQuantities.Peek();
                int sum = currentCoffee + currentMilk;

                if (sum == 50)
                {

                }
            }
        }
    }
}
