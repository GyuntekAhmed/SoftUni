using System;
using System.Collections.Generic;
using System.Linq;

class KnightsOfHonor
{
    static void Main()
    {
        List<string> list = Console.ReadLine().Split().ToList();

        Action<string> print = name => Console.WriteLine($"Sir {name}");

        list.ForEach(print);
    }
}
