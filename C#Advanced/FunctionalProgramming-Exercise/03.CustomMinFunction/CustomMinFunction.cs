using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;

class CustomMinFunction
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();
        Func<List<int>, int> getMinElement = numbers => numbers.Min();

        Console.WriteLine(getMinElement(numbers));
    }
}
