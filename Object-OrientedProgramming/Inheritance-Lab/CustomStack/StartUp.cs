using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main()
        {
            StackOfStrings strings = new StackOfStrings();

            Console.WriteLine(strings.isEmpty());

            strings.AddRange(new List<string>() { "11", "55", "44"});
            Console.WriteLine(strings.isEmpty());

            Console.WriteLine(strings.Pop());
            Console.WriteLine(strings.Pop());
            Console.WriteLine(strings.Pop());
        }
    }
}
