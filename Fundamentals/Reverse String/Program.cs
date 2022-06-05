using System;

namespace Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string reverseText = "";

            for (int i = text.Length-1; i >= 0; i--)
            {
                reverseText += text[i];
            }
            Console.WriteLine(reverseText);
        } 
    }
}
