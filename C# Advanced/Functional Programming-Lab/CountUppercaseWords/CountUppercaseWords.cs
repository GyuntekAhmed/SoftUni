using System;
using System.Linq;

class CountUppercaseWords
{
    static void Main()
    {
        Predicate<string> isUpper =
            (string x) => x.Length > 0 && char.IsUpper(x[0]);
        Console.WriteLine(
            string.Join(
                "\r\n",
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => isUpper(x))
                .ToArray()
                )
            );
    }
}
