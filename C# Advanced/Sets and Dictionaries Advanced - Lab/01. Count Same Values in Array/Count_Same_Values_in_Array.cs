using System;
using System.Collections.Generic;
using System.Linq;

class Count_Same_Values_in_Array
{
    static void Main()
    {
        double[] numbers = Console.ReadLine()
            .Split()
            .Select(double.Parse)
            .ToArray();

        Dictionary<double, int> countByNum = new Dictionary<double, int>();

        foreach (double number in numbers)
        {
            if (countByNum.ContainsKey(number))
            {
                countByNum[number]++;
            }
            else
            {
                countByNum[number] = 1;
            }
        }

        foreach (var pair in countByNum)
        {
            Console.WriteLine($"{pair.Key} - {pair.Value} times");
        }
    }
}
