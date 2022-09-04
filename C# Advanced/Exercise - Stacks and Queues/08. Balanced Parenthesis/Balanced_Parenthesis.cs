using System;
using System.Collections.Generic;

class Balanced_Parenthesis
{
    static void Main()
    {
        string input = Console.ReadLine();

        bool isBalanced = false;
        Stack<char> openBracket = new Stack<char>();


        foreach (char bracket in input)
        {
            if (bracket == '(' || bracket == '{' || bracket == '[')
            {
                openBracket.Push(bracket);
            }
            else if (bracket == ')' || bracket == '}' || bracket == ']')
            {
                if (openBracket.Count == 0)
                {
                    isBalanced = false;
                    break;
                }

                char lastOpen = openBracket.Pop();

                if (lastOpen == '(' && bracket == ')')
                {
                    isBalanced = true;
                }
                else if (lastOpen == '{' && bracket == '}')
                {
                    isBalanced = true;
                }
                else if (lastOpen == '[' && bracket == ']')
                {
                    isBalanced = true;
                }
                else
                {
                    isBalanced = false;
                    break;
                }
            }
        }
        if (isBalanced)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }
}
