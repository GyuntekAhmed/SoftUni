using System;
using System.Linq;

class SumNumbers
{
    static int Parse(string str) => int.Parse(str);
    static void Main()
    {
        string input = Console.ReadLine();

        int[] nums = input.Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(Parse)
            .ToArray();
        Console.WriteLine(nums.Count());
        Console.WriteLine(nums.Sum());
    }
}
