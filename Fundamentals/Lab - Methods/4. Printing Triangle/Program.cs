using System;

namespace _4._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int count =int.Parse(Console.ReadLine());

            for (int i = 1; i <= count; i++)
            {
                PrintLine(1, i);
            }

            for (int i = count-1; i >= 1; i--)
            {
                PrintLine(1, i);
            }
        }

        static void PrintLine(int start,int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }
    }
}
