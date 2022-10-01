using System;
using System.Collections.Generic;
using System.Linq;

internal class ListOfPredicates
{
    static void Main()
    {
        List<Predicate<int>> predicates = new List<Predicate<int>>();

        int endRange = int.Parse(Console.ReadLine());

        int[] dividers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        int[] numbers = Enumerable.Range(1, endRange).ToArray();

        foreach (int divider in dividers)
        {
            predicates.Add(p => p % divider == 0);
        }

        foreach (var number in numbers)
        {
            bool isDivisible = true;

            foreach (var match in predicates)
            {
                if (!match(number))
                {
                    isDivisible = false;
                    break;
                }
            }

            if (isDivisible)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
