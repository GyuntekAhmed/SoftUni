using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Reverse_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stack = new Stack<char>();
            string str = Console.ReadLine();

            foreach (char ch in str)
            {
                stack.Push(ch);
            }

            Console.WriteLine(string.Join("", stack));
        }
    }
}
