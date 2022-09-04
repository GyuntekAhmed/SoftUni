using System;
using System.Collections.Generic;
using System.Linq;

class _Basic_Stack_Operations
{
    static void Main(string[] args)
    {
        Stack<int> stack = new Stack<int>();

        int[] numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        int n = numbers[0];
        int s = numbers[1];
        int x = numbers[2];

        List<int> numberList = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();
        for (int i = 0; i < n; i++)
        {
            stack.Push(numberList[i]);
        }

        for (int j = 0; j < s; j++)
        {
            stack.Pop();
        }

        if (stack.Count == 0)
        {
            Console.WriteLine(0);
        }
        else if (stack.Contains(x))
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine(stack.Min());
        }

    }
}
