using System;
using System.Collections.Generic;
using System.Linq;

class Reverse_Numbers
{
    static void Main()
    {
        Stack<int> numbers = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

        foreach (int number in numbers)
        {
            Console.Write($"{number} ");
        }
    }
}
