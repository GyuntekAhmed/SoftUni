using System;
using System.Collections.Generic;
using System.Linq;

class Even_Times
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Dictionary<int, int> numbers = new Dictionary<int, int>();

        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());

            if (numbers.ContainsKey(number))
            {
                numbers[number]++;
            }
            else
            {
                numbers.Add(number, 1);
            }
        }

        var evenNumber = numbers.First(n => n.Value % 2 == 0).Key;

        Console.WriteLine(evenNumber);
    }
}
