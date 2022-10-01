using System;

class Journey
{
    static void Main()
    {
        double budget = double.Parse(Console.ReadLine());
        string season = Console.ReadLine();
        string destination = null;
        double price = 0;
        string room = null;
        if (budget <= 100)
        {
            destination = "Bulgaria";
            if (season == "summer")
            {
                price = budget * 0.30;
                room = "Camp";
            }
            else if (season == "winter")
            {
                price = budget * 0.70;
                room = "Hotel";
            }
        }
        else if (budget > 100 && budget <= 1000)
        {
            destination = "Balkans";
            if (season == "summer")
            {
                price = budget * 0.40;
                room = "Camp";
            }
            else if (season == "winter")
            {
                price = budget * 0.80;
                room = "Hotel";

            }
        }
        else if (budget > 1000)
        {
            destination = "Europe";
            price = budget * 0.90;
            room = "Hotel";

        }
        Console.WriteLine($"Somewhere in {destination}");
        Console.WriteLine($"{room} - {price:f2}");
    }
}
