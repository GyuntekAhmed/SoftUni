using System;

namespace _5._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            PrintTotalPrice(product, quantity);
        }

        static void PrintTotalPrice(string product, int quantity)
        {

            double coffee = 1.50;
            double water = 1.00;
            double coke = 1.40;
            double snacks = 2.00;

            switch (product)
            {
                case "coffee":
                    Console.WriteLine($"{ (coffee * quantity):f2}");
                    break;
                case "water":
                    Console.WriteLine($"{(water*quantity):f2}");
                    break;
                case "coke":
                    Console.WriteLine($"{(coke * quantity):f2}");
                    break;
                case "snacks":
                    Console.WriteLine($"{(snacks * quantity):f2}");
                    break;
            }
        }
    }
}
