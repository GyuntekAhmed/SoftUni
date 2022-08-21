using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            string expr = Console.ReadLine();

            for (int i = 0; i < expr.Length; i++)
            {
                char c = expr[i];

                if (c == '(')
                {
                    stack.Push(i);
                }
                else if (c == ')')
                {
                    int startIndex = stack.Pop();
                    int endIndex = i;

                    string subExpr = expr.Substring(startIndex, endIndex - startIndex + 1);

                    Console.WriteLine(subExpr);
                }
            }
        }
    }
}
