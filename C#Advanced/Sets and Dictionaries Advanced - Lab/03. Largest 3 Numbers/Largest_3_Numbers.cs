using System;
using System.Linq;

class Largest_3_Numbers
{
    static void Main()
    {
        int[] numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        int[] sortedNums = numbers.OrderByDescending(n => n).ToArray();

        int countToPrint = sortedNums.Length;

        if (countToPrint > 3)
        {
            countToPrint = 3;
        }

        for (int i = 0; i < countToPrint; i++)
        {
            Console.Write($"{sortedNums[i]} ");
        }
    }
}
