using System;

class New_House
{
    static void Main()
    {
        string kindOfFlowers = Console.ReadLine();
        int numberOfFlowers = int.Parse(Console.ReadLine());
        int budget = int.Parse(Console.ReadLine());
        double price = 0;
        double discount = 0;
        double newPrice = 0;
        double leftPrice = 0;
        switch (kindOfFlowers)
        {
            case "Roses":
                price = numberOfFlowers * 5;
                if (numberOfFlowers > 80)
                {
                    discount = price * 0.1;
                }
                newPrice = price - discount;
                break;
            case "Dahlias":
                price = numberOfFlowers * 3.80;
                if (numberOfFlowers > 90)
                {
                    discount = price * 0.15;
                }
                newPrice = price - discount;
                break;
            case "Tulips":
                price = numberOfFlowers * 2.80;
                if (numberOfFlowers > 80)
                {
                    discount = price * 0.15;
                }
                newPrice = price - discount;
                break;
            case "Narcissus":
                price = numberOfFlowers * 3;
                if (numberOfFlowers < 120)
                {
                    discount = price * 0.15;
                }
                newPrice = price + discount;
                break;
            case "Gladiolus":
                price = numberOfFlowers * 2.50;
                if (numberOfFlowers < 80)
                {
                    discount = price * 0.2;
                }
                newPrice = price + discount;
                break;
            default:
                break;
        }
        leftPrice = newPrice - budget;
        if (budget >= newPrice)
        {
            Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {kindOfFlowers} and {Math.Abs(leftPrice):f2} leva left.");
        }
        else
        {
            Console.WriteLine($"Not enough money, you need {leftPrice:f2} leva more.");
        }
    }
}
