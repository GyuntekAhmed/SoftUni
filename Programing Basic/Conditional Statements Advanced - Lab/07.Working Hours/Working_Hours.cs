using System;

class Working_Hours
{
    static void Main()
    {
        int hours = int.Parse(Console.ReadLine());
        string day = Console.ReadLine();

        if (hours >= 10 && hours <= 18)
        {
            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                case "Saturday":
                    Console.WriteLine("open");
                    break;
                default:
                    Console.WriteLine("closed");
                    break;
            }

        }
        else
        {
            Console.WriteLine("closed");
        }
    }
}
