using System;
using System.Collections.Generic;
using System.Linq;

internal class ActionPrint
{
    static void Main()
    {
        List<string> list = Console.ReadLine().Split().ToList();

        Action<string> print = name => Console.WriteLine(name);

        list.ForEach(print);
    }
}
