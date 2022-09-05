using System;
using System.Collections.Generic;
using System.Linq;

class _Simple_Calculator
{
    static void Main()
    {
        Stack<int> stack = new Stack<int>();
        string[] input = Console.ReadLine().Split();

        int sum = int.Parse(input[0]);

        for (int i = 1; i < input.Length; i++)
        {

            if (input[i] == "+")
            {
                int number = int.Parse(input[i + 1]);
                sum += number;
            }
            else if (input[i] == "-")
            {
                int number = int.Parse(input[i + 1]);
                sum -= number;
            }

        }
        stack.Push(sum);

        Console.WriteLine(string.Join("", stack));
    }
}
