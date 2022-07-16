using System;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Console.WriteLine(Multiplier(input[0], input[1]));
        }

        public static int Multiplier(string str1, string str2)
        {
            int sum = 0;
            string longest = string.Empty;
            string shortest = string.Empty;

            if (str1.Length > str2.Length)
            {
                longest = str1;
                shortest = str2;
            }
            else
            {
                longest = str2;
                shortest = str1;
            }

            for (int i = 0; i < shortest.Length; i++)
            {
                sum += str1[i] * str2[i];
            }

            for (int i = shortest.Length; i < longest.Length; i++)
            {
                sum += longest[i];
            }

            return sum;
        }
    }
}
