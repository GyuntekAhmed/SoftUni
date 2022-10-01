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

        Dictionary<string, int> cofeeDrinks = new Dictionary<string, int>();
        cofeeDrinks.Add("Cortado", 0);
        cofeeDrinks.Add("Espresso", 0);
        cofeeDrinks.Add("Capuccino", 0);
        cofeeDrinks.Add("Americano", 0);
        cofeeDrinks.Add("Latte", 0);

        List<int> coffeeQuantities = new List<int>(Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList());
        Stack<int> milkQuantities = new Stack<int>(Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray());
        bool defaultSum = false;
        bool isOne = false;
        int sum = 0;

        while (coffeeQuantities.Count > 0)
        {
            if (milkQuantities.Count == 0)
            {
                break;
            }
            if (!defaultSum)
            {
                sum = coffeeQuantities[0] + milkQuantities.Peek();
            }
            else
            {
                coffeeQuantities.Remove(coffeeQuantities[0]);
                sum = milkQuantities.Peek() - 5;
                defaultSum = false;
                if (!isOne)
                {
                    sum += coffeeQuantities[0];
                }
            }


            switch (sum)
            {
                case 50:
                    cofeeDrinks["Cortado"]++;
                    coffeeQuantities.Remove(coffeeQuantities[0]);
                    milkQuantities.Pop();
                    break;
                case 75:
                    cofeeDrinks["Espresso"]++;
                    coffeeQuantities.Remove(coffeeQuantities[0]);
                    milkQuantities.Pop();
                    break;
                case 100:
                    cofeeDrinks["Capuccino"]++;
                    coffeeQuantities.Remove(coffeeQuantities[0]);
                    milkQuantities.Pop();
                    break;
                case 150:
                    cofeeDrinks["Americano"]++;
                    coffeeQuantities.Remove(coffeeQuantities[0]);
                    milkQuantities.Pop();
                    break;
                case 200:
                    cofeeDrinks["Latte"]++;
                    if (!isOne)
                    {
                        coffeeQuantities.Remove(coffeeQuantities[0]);
                    }
                    milkQuantities.Pop();
                    break;
                default:
                    defaultSum = true;
                    if (coffeeQuantities.Count == 1)
                    {
                        sum += coffeeQuantities[0];
                        isOne = true;
                    }
                    break;
            }
        }
        if (milkQuantities.Count == 0 && coffeeQuantities.Count == 0)
        {
            Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            Console.WriteLine("Coffee left: none");
            Console.WriteLine("Milk left: none");
        }
        else
        {
            Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            if (coffeeQuantities.Count == 0)
            {
                Console.WriteLine("Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffeeQuantities)}");
            }
            if (milkQuantities.Count == 0)
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milkQuantities)}");
            }
        }
        var sortedDrinks = cofeeDrinks.OrderBy(x => x.Value).ThenByDescending(x => x.Key);
        foreach (var cofee in sortedDrinks)
        {
            if (cofee.Value > 0)
            {
                Console.WriteLine($"{cofee.Key}: {cofee.Value}");
            }
        }
    }
}
