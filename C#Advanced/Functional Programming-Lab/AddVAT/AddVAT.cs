using System;
using System.Collections.Generic;
using System.Linq;

class AddVAT
{
    static void Main()
    {
        Func<decimal, decimal> addVat = x => x * 1.20m;

        string input = Console.ReadLine();
        string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
        decimal[] nums = tokens.Select(decimal.Parse).ToArray();
        decimal[] numsWithVat = nums.Select(addVat).ToArray();

        Array.ForEach(numsWithVat, x => Console.WriteLine("{0:f2}",x));
    }
}
