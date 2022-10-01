using System;

class Hotel_Room
{
    static void Main()
    {
        string mounth = Console.ReadLine();
        int numbersForNight = int.Parse(Console.ReadLine());
        double studioPrice = 0;
        double apartPrice = 0;
        double discount = 0;
        switch (mounth)
        {
            case "May":
                studioPrice = 50;
                apartPrice = 65;
                if (numbersForNight > 7 && numbersForNight < 14)
                {
                    discount = studioPrice * 0.05;
                }
                else if (numbersForNight >= 14)
                {
                    discount = studioPrice * 0.30;
                }
                break;
            case "October":
                studioPrice = 50;
                apartPrice = 65;
                if (numbersForNight > 7 && numbersForNight < 14)
                {
                    discount = studioPrice * 0.05;
                }
                else if (numbersForNight >= 14)
                {
                    discount = studioPrice * 0.30;
                }
                break;
            case "June":
                studioPrice = 75.20;
                apartPrice = 68.70;
                if (numbersForNight > 14)
                {
                    discount = studioPrice * 0.20;
                }
                break;
            case "September":
                studioPrice = 75.20;
                apartPrice = 68.70;
                if (numbersForNight > 14)
                {
                    discount = studioPrice * 0.20;
                }
                break;
            case "July":
                studioPrice = 76;
                apartPrice = 77;
                break;
            case "August":
                studioPrice = 76;
                apartPrice = 77;
                break;
        }
        double discountForApart = 0;
        if (numbersForNight > 14)
        {
            discountForApart = apartPrice * 0.10;
        }
        studioPrice = studioPrice - discount;
        apartPrice = apartPrice - discountForApart;
        double totalPriceStudio = numbersForNight * studioPrice;
        double totalPriceApart = numbersForNight * apartPrice;

        Console.WriteLine($"Apartment: {totalPriceApart:f2} lv.");
        Console.WriteLine($"Studio: {totalPriceStudio:f2} lv.");
    }
}
