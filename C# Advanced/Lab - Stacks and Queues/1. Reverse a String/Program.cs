using System;
using System.Collections.Generic;

namespace _1._Reverse_a_String
{
    class Program
    {
        static void Main(string[] args)
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
}
