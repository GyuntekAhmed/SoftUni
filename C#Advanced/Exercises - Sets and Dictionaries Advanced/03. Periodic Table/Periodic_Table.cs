using System;
using System.Collections.Generic;

class Periodic_Table
{
    static void Main()
    {
        SortedSet<string> set = new SortedSet<string>();

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < input.Length; j++)
            {
                string currentStr = input[j];

                set.Add(currentStr);
            }
        }

        foreach (string item in set)
        {
            Console.Write($"{item} ");
        }
    }
}
