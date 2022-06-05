using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string typeOfDay = Console.ReadLine();

            double price = 0;

            if (typeOfGroup == "Students")
            {
                if (typeOfDay == "Friday")
                {
                    price = 8.45;
                }
                else if (typeOfDay == "Saturday")
                {
                    price = 9.80;
                }
                else if (typeOfDay == "Sunday")
                {
                    price = 10.46;
                }
            }
            else if (typeOfGroup == "Business")
            {
                if (typeOfDay == "Friday")
                {
                    price = 10.90;
                }
                else if (typeOfDay == "Saturday")
                {
                    price = 15.60;
                }
                else if (typeOfDay == "Sunday")
                {
                    price = 16;
                }
            }
            else if (typeOfGroup == "Regular")
            {
                if (typeOfDay == "Friday")
                {
                    price = 15;
                }
                else if (typeOfDay == "Saturday")
                {
                    price = 20;
                }
                else if (typeOfDay == "Sunday")
                {
                    price = 22.50;
                }
            }

            double totalPrice = countOfPeople * price;

            if (typeOfGroup == "Students")
            {
                if (countOfPeople >= 30)
                {
                    totalPrice *= 0.85;
                }
            }
            if (typeOfGroup == "Business")
            {
                if (countOfPeople >= 100)
                {
                    totalPrice -= totalPrice / countOfPeople * 10;
                }
            }
            if (typeOfGroup == "Regular")
            {
                if (countOfPeople >= 10 && countOfPeople <= 20)
                {
                    totalPrice *= 0.95;
                }
            }
            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
