using System;

namespace Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney =double.Parse(Console.ReadLine());
            int countOfStudents =int.Parse(Console.ReadLine());
            double priceOfLightsaber =double.Parse(Console.ReadLine());
            double priceOfRobe =double.Parse(Console.ReadLine());
            double priceOfBelt =double.Parse(Console.ReadLine());

            double freeBelt = Math.Floor((double)countOfStudents / 6);
            double saberBS = Math.Ceiling(countOfStudents + countOfStudents * 0.1);

            double price = (priceOfLightsaber * saberBS) + (priceOfRobe * countOfStudents) + (priceOfBelt * (countOfStudents - freeBelt));

            if (amountOfMoney >= price)
            {
                Console.WriteLine($"The money is enough - it would cost {price:f2}lv.");
            }
            else
            {
                double moneyNeed = price - amountOfMoney;
                Console.WriteLine($" John will need {moneyNeed:f2}lv more.");
            }

        }
    }
}
