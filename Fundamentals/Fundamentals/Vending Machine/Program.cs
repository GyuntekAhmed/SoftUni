using System;

namespace Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            double totalMoneyAcumolated = 0;

            while (comand != "Start")
            {
                double inputMoney = double.Parse(comand);
                if (inputMoney == 0.1 || inputMoney == 0.2 || inputMoney == 0.5 || inputMoney == 1 || inputMoney == 2)
                {
                    totalMoneyAcumolated += inputMoney;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {inputMoney}");
                }
                comand = Console.ReadLine();
            }
           
            comand = Console.ReadLine();

            double totalPrice = 0;

            while (comand != "End")
            {
                switch (comand)
                {
                    case "Nuts":
                        totalPrice = 2;
                        break;
                    case "Water":
                        totalPrice = 0.7;
                        break;
                    case "Crisps":
                        totalPrice = 1.5;
                        break;
                    case "Soda":
                        totalPrice = 0.8;
                        break;
                    case "Coke":
                        totalPrice = 1.0;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        comand = Console.ReadLine();
                        continue;
                }
                if (totalMoneyAcumolated >= totalPrice)
                {
                    totalMoneyAcumolated -= totalPrice;
                    Console.WriteLine($"Purchased {comand.ToLower()}");
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }

                comand = Console.ReadLine();

            }

            Console.WriteLine($"Change: {totalMoneyAcumolated:f2}");
        }
    }
}
