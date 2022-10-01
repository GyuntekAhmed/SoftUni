using System;

class Summer_Outfit
{
    static void Main()
    {
        int degrees = int.Parse(Console.ReadLine());
        string timeOfDay = Console.ReadLine();
        string outfit = null;
        string shoes = null;
        bool theDay = timeOfDay == "Morning" && timeOfDay == "Afternoon" && timeOfDay == "Evening";
        if (degrees >= 10 && degrees <= 18)
        {
            switch (timeOfDay)
            {
                case "Morning":
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                    break;
                case "Afternoon":
                    outfit = "Shirt";
                    shoes = "Moccasins";
                    break;
                case "Evening":
                    outfit = "Shirt";
                    shoes = "Moccasins";
                    break;
                default:
                    break;
            }

        }
        else if (degrees >= 19 && degrees <= 24)
        {
            switch (timeOfDay)
            {
                case "Morning":
                    outfit = "Shirt";
                    shoes = "Moccasins";
                    break;
                case "Afternoon":
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                    break;
                case "Evening":
                    outfit = "Shirt";
                    shoes = "Moccasins";
                    break;
                default:
                    break;
            }
        }

        else if (degrees >= 25 && degrees <= 42)
        {
            switch (timeOfDay)
            {
                case "Morning":
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                    break;
                case "Afternoon":
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                    break;
                case "Evening":
                    outfit = "Shirt";
                    shoes = "Moccasins";
                    break;
                default:
                    break;
            }

        }

        Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}."); ;
    }
}
