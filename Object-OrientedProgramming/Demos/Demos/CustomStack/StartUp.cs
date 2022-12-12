namespace CustomStack
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main()
        {
            StackOfStrings strings = new StackOfStrings();

            Console.WriteLine(strings.IsEmpty());

            strings.AddRange(new List<string>() { "11", "55", "44" });
            Console.WriteLine(strings.IsEmpty());

            Console.WriteLine(strings.Pop());
            Console.WriteLine(strings.Pop());
            Console.WriteLine(strings.Pop());
        }
    }
}
