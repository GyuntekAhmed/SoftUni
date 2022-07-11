using System;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                char[] wordArr = input.ToCharArray();
                Array.Reverse(wordArr);
                string reversedString = new string(wordArr);

                Console.WriteLine($"{input} = {reversedString}");
            }

        }
    }
}
