using System;

namespace _5._Print_Part_of_the_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNum =int.Parse(Console.ReadLine());
            int endNum =int.Parse(Console.ReadLine());

            for (int i = startNum; i <= endNum; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
