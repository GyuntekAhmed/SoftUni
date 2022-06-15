using System;

namespace _01._Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int isInteger = 0;
            double isDouble = 0;
            string isString = string.Empty;

            PrintResult(type, isInteger, isDouble, isString);

        }

        private static void PrintResult(string type, int isInteger, double isDouble, string isString)
        {
            if (type == "int")
            {
                isInteger = int.Parse(Console.ReadLine());
                int result = isInteger * 2;
                Console.WriteLine(result);
            }
            else if (type == "real")
            {
                isDouble = double.Parse(Console.ReadLine());
                double result = isDouble * 1.5;
                Console.WriteLine($"{result:f2}");
            }
            else
            {
                isString = Console.ReadLine();
                Console.WriteLine($"${isString}$");
            }
        }
    }
}
