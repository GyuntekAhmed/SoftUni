using System;

namespace _05._Multiplication_Sign
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int result = num1 * num2 * num3;

            if (result < 0)
            {
                Console.WriteLine("negative");
            }
            else if (result == 0)
            {
                Console.WriteLine("zero");
            }
            else
            {
                Console.WriteLine("positive");
            }

        }
    }
}
