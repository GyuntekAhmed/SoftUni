using System;

class Fruit_Shop
{
    static void Main()
    {
        string fruit = Console.ReadLine();
        string dayOfWeek = Console.ReadLine();
        double quantity = double.Parse(Console.ReadLine());

        if (dayOfWeek != "Monday" && dayOfWeek != "Tuesday" && dayOfWeek != "Wednesday" 
            && dayOfWeek != "Thursday" && dayOfWeek != "Friday" &&
            dayOfWeek != "Saturday" && dayOfWeek != "Sunday")
        {
            Console.WriteLine("error");
        }

        else if (fruit == "banana")
        {
            double price = 0;

            if (dayOfWeek == "Saturday" || dayOfWeek == "Sunday")
            {
                price = 2.70;
            }
            else
            {
                price = 2.50;
            }
            double sum = quantity * price;
            Console.WriteLine($"{sum:f2}");
        }
        else if (fruit == "apple")
        {
            double price = 0;
            if (dayOfWeek == "Saturday" || dayOfWeek == "Sunday")
            {
                price = 1.25;
            }
            else
            {
                price = 1.20;
            }
            double sum = quantity * price;

            Console.WriteLine($"{sum:f2}");
        }
        else if (fruit == "orange")
        {
            double price = 0;

            if (dayOfWeek == "Saturday" || dayOfWeek == "Sunday")
            {
                price = 0.90;
            }
            else
            {
                price = 0.85;
            }
            double sum = quantity * price;
            Console.WriteLine($"{sum:f2}");
        }
        else if (fruit == "grapefruit")
        {
            double price = 0;

            if (dayOfWeek == "Saturday" || dayOfWeek == "Sunday")
            {
                price = 1.60;
            }
            else
            {
                price = 1.45;
            }
            double sum = quantity * price;

            Console.WriteLine($"{sum:f2}");
        }
        else if (fruit == "kiwi")
        {
            double price = 0;
            if (dayOfWeek == "Saturday" || dayOfWeek == "Sunday")
            {
                price = 3.00;
            }
            else
            {
                price = 2.70;
            }
            double sum = quantity * price;

            Console.WriteLine($"{sum:f2}");
        }
        else if (fruit == "pineapple")
        {
            double price = 0;
            if (dayOfWeek == "Saturday" || dayOfWeek == "Sunday")
            {
                price = 5.60;
            }
            else
            {
                price = 5.50;
            }
            double sum = quantity * price;
            Console.WriteLine($"{sum:f2}");
        }
        else if (fruit == "grapes")
        {
            double price = 0;

            if (dayOfWeek == "Saturday" || dayOfWeek == "Sunday")
            {
                price = 4.20;
            }
            else
            {
                price = 3.85;
            }
            double sum = quantity * price;

            Console.WriteLine($"{sum:f2}");
        }
        else
        {
            Console.WriteLine("error");
        }
    }
}
