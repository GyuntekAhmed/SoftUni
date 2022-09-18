using System;
using System.Collections.Generic;
using System.Linq;

class Sets_of_Elements
{
    static void Main()
    {
        HashSet<int> firstSet = new HashSet<int>();
        HashSet<int> secondSet = new HashSet<int>();

        int[] input = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        int n = input[0];
        int m = input[1];

        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());

            firstSet.Add(number);
        }
        for (int i = 0; i < m; i++)
        {
            int number = int.Parse(Console.ReadLine());

            secondSet.Add(number);
        }

        foreach (int firstNumber in firstSet)
        {
            foreach (int secondNumber in secondSet)
            {
                if (secondNumber == firstNumber)
                {
                    Console.Write($"{firstNumber} ");
                }
            }
        }
    }
}
