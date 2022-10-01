using System;
using System.Linq;

internal class SortEvenNumbers
{
    static void Main()
    {
        //int[] numbers = Console.ReadLine()
        //    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
        //    .Select(n => int.Parse(n))
        //    .Where(x => x % 2 == 0)
        //    .OrderBy(n => n)
        //    .ToArray();

        Func<string, int> ParseStringToInt =
            x => int.Parse(x);
        Func<int, bool> isEven =
            x => x % 2 == 0;
        Func<int, int> identity =
            x => x;
        string input = Console.ReadLine();
        string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
        int[] nums = tokens.Select(ParseStringToInt).ToArray();
        int[] evenNums = nums.Where(isEven).ToArray();
        int[] orderedEvenNums = evenNums.OrderBy(identity).ToArray();

        Console.WriteLine(string.Join(", ", orderedEvenNums));
    }
}
