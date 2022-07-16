using System;
using System.Text;

namespace _06._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder();
            

            for (int i = 0; i < input.Length - 1; i++)
            {
                char currentChar = input[i];
                char secondChar = input[i + 1];

                if (currentChar != secondChar)
                {
                    sb.Append(currentChar);
                }
            }
            sb.Append(input[input.Length - 1]);
            Console.WriteLine(sb);
        }
    }
}
