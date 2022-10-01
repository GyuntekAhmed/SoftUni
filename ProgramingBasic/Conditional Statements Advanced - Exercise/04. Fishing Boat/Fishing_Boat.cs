using System;

class Fishing_Boat
{
    static void Main()
    {
        int budjet = int.Parse(Console.ReadLine());
        string season = Console.ReadLine();
        int numbrerOfFisherman = int.Parse(Console.ReadLine());
        int priceOfShip = 0;
        double discount = 0;
        double totalPrice = 0;
        double leftPrice = 0;
        double moreDiscount = 0;
        switch (season)
        {
            case "Spring":
                priceOfShip = 3000;
                break;
            case "Summer":
                priceOfShip = 4200;
                break;
            case "Autumn":
                priceOfShip = 4200;
                break;
            case "Winter":
                priceOfShip = 2600;
                break;
            default:
                break;
        }
        if (numbrerOfFisherman <= 6)
        {
            discount = priceOfShip * 0.1;
        }
        else if (numbrerOfFisherman >= 7 && numbrerOfFisherman <= 11)
        {
            discount = priceOfShip * 0.15;
        }
        else if (numbrerOfFisherman >= 12)
        {
            discount = priceOfShip * 0.25;
        }
        if (numbrerOfFisherman % 2 == 0)
        {
            if (season != "Autumn")
            {
                moreDiscount = (priceOfShip - discount) * 0.05;
            }
        }
        totalPrice = priceOfShip - discount - moreDiscount;
        leftPrice = totalPrice - budjet;
        if (budjet < totalPrice)
        {
            Console.WriteLine($"Not enough money! You need {Math.Abs(leftPrice):f2} leva.");
        }
        else if (budjet >= totalPrice)
        {
            Console.WriteLine($"Yes! You have {Math.Abs(leftPrice):f2} leva left.");
        }
    }
}
