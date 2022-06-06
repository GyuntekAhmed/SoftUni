using System;
using System.Linq;

namespace _3._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int[] evenArray = new int[lines];
            int[] oddAray = new int[lines];

            for (int i = 0; i < lines; i++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    evenArray[i] = numbers[0];
                    oddAray[i] = numbers[1];
                }
                else
                {
                    evenArray[i] = numbers[1];
                    oddAray[i] = numbers[0];
                }
            }

            Console.WriteLine(string.Join(" ", evenArray));
            Console.WriteLine(string.Join(" ", oddAray));
        }
    }
}
