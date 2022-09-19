using System;

namespace ConsoleApp2
{
    class Program
    {

        static void Main()
        {
            string projection = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int colonies = int.Parse(Console.ReadLine());
            double price = 0;
            switch (projection)
            {
                case "Premiere":
                    price = 12.00;
                    break;
                case "Normal":
                    price = 7.50;
                    break;
                case "Discount":
                    price = 5.00;
                    break;
            }
            double totalPrice = rows * colonies * price;
            Console.WriteLine($"{totalPrice:f2} leva");

        }
    }
}