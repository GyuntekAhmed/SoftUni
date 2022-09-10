using System;

class Cinema_Ticket
{
    static void Main()
    {
        string day = Console.ReadLine();

        switch (day)
        {
            case "Monday":
                Console.WriteLine("12");
                break;
            case "Tuesday":
                Console.WriteLine("12");
                break;
            case "Wednesday":
                Console.WriteLine("14");
                break;
            case "Thursday":
                Console.WriteLine("14");
                break;
            case "Friday":
                Console.WriteLine("12");
                break;
            case "Saturday":
                Console.WriteLine("16");
                break;
            case "Sunday":
                Console.WriteLine("16");
                break;

        }
    }
}
