using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    internal class Startup
    {
        static void Main()
        {
            var stack = new Stack<string>();
            while (true)
            {
                var tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "END") break;

                if (tokens[0] == "Push")
                {
                    stack.Push(tokens.Skip(1).Select(e => e.Split(",").First()).ToArray());
                }
                else if (tokens[0] == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);

                    }
                }

            }

            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
