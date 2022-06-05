using System;

namespace _8._Triangle_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number =int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                Console.Write($"{i}");

                for (int j = 1; j < i; j++)
                {
                    Console.Write($" {i}");
                }
                Console.WriteLine("");
            }
        }
    }
}
