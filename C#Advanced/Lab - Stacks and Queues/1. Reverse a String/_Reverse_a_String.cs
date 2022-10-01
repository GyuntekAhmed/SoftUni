using System;
using System.Collections.Generic;

class _Reverse_a_String
{
    static void Main()
    {
        Stack<char> stack = new Stack<char>();
        string text = Console.ReadLine();

        foreach (char ch in text)
        {
            stack.Push(ch);
        }

        Console.WriteLine(string.Join("", stack));
    }
}
