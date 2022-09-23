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
        cofeeDrinks.Add("Cortado", 0);
        cofeeDrinks.Add("Espresso", 0);
        cofeeDrinks.Add("Capuccino", 0);
        cofeeDrinks.Add("Americano", 0);
        cofeeDrinks.Add("Latte", 0);

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

                switch (sum)
                {
                    case 50:
                        cofeeDrinks["Cortado"]++;
                        coffeeQuantities.Dequeue();
                        milkQuantities.Pop();
                        break;
                    case 75:
                        cofeeDrinks["Espresso"]++;
                        coffeeQuantities.Dequeue();
                        milkQuantities.Pop();
                        break;
                    case 100:
                        cofeeDrinks["Capuccino"]++;
                        coffeeQuantities.Dequeue();
                        milkQuantities.Pop();
                        break;
                    case 150:
                        cofeeDrinks["Americano"]++;
                        coffeeQuantities.Dequeue();
                        milkQuantities.Pop();
                        break;
                    case 200:
                        cofeeDrinks["Latte"]++;
                        coffeeQuantities.Dequeue();
                        milkQuantities.Pop();
                        break;
                    default:
                        coffeeQuantities.Dequeue();
                        currentMilk -= 5;
                        break;
                }
            }
        }
        Console.WriteLine();
    }
}
