using System;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int dayMonth = 0;
            int capCount = 0;
            double capP = 0;

            double price = 0;
            double priceNow = 0;
            for (int i = 0; i < n; i++)
            {
                capP = double.Parse(Console.ReadLine());
                dayMonth = int.Parse(Console.ReadLine());
                capCount = int.Parse(Console.ReadLine());

                priceNow = (dayMonth * capCount) * capP;
                Console.WriteLine($"The price for the coffee is: ${priceNow:F2}");
                price += priceNow;
            }
            Console.WriteLine($"Total: ${price:F2}");
        }
    }
