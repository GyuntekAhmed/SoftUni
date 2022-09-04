using System;
using System.Collections.Generic;
using System.Linq;

class _Maximum_and_Minimum_Element
{
    static void Main()
    {
        Stack<int> stack = new Stack<int>();

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            int[] command = Console.ReadLine()
                            .Split(' ')
                            .Select(int.Parse)
                            .ToArray();

            switch (command[0])
            {
                case 1:
                    stack.Push(command[1]);
                    break;
                case 2:
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                        break;
                    }
                    break;
                case 3:
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Max());
                    }
                    break;
                case 4:
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                    break;
            }
        }

        Console.WriteLine(string.Join(", ", stack));
    }
}
