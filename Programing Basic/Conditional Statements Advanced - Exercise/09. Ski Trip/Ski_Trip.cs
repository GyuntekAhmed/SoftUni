using System;

class Ski_Trip
{
    static void Main()
    {
        int daysOfStay = int.Parse(Console.ReadLine());
        int nightsOfStay = daysOfStay - 1;
        string typeOfRoom = Console.ReadLine();
        string evalution = Console.ReadLine();

        double roomPrice = 18.00;
        double apartmentPrice = 25.00;
        double presidentApartmentPrice = 35.00;
        double discount = 0;
        double price = 0;

        switch (typeOfRoom)
        {
            case "room for one person":
                price = nightsOfStay * roomPrice;
                if (evalution == "positive")
                {
                    discount = price * 0.25;
                    price += discount;
                }
                else if (evalution == "negative")
                {
                    discount = price * 0.10;
                    price -= discount;
                }
                break;
            case "apartment":
                price = nightsOfStay * apartmentPrice;
                if (daysOfStay < 10)
                {
                    discount = price * 0.30;
                    price -= discount;

                }
                else if (daysOfStay >= 10 && daysOfStay <= 15)
                {
                    discount = price * 0.35;
                    price -= discount;

                }
                else if (daysOfStay > 15)
                {
                    discount = price * 0.50;
                    price -= discount;

                }
                if (evalution == "positive")
                {
                    discount = price * 0.25;
                    price += discount;
                }
                else if (evalution == "negative")
                {
                    discount = price * 0.10;
                    price -= discount;
                }
                break;
            case "president apartment":
                price = nightsOfStay * presidentApartmentPrice;
                if (daysOfStay < 10)
                {
                    discount = price * 0.10;
                    price -= discount;

                }
                else if (daysOfStay >= 10 && daysOfStay <= 15)
                {
                    discount = price * 0.15;
                    price -= discount;

                }
                else if (daysOfStay > 15)
                {
                    discount = price * 0.20;
                    price -= discount;
                }
                if (evalution == "positive")
                {
                    discount = price * 0.25;
                    price += discount;
                }
                else if (evalution == "negative")
                {
                    discount = price * 0.10;
                    price -= discount;
                }
                break;


        }
        Console.WriteLine($"{price:f2}");
    }
}
