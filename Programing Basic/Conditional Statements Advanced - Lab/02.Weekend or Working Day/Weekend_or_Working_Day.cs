﻿using System;

class Weekend_or_Working_Day
{
    static void Main()
    {
        //   1   Monday
        //   2   Tuesday
        //   3   Wednesday
        //   4   Thursday
        //   5   Friday
        //   6   Saturday
        //   7   Sunday
        //  - 1  Error

        string day = Console.ReadLine();

        switch (day)
        {
            case "Monday":
            case "Tuesday":
            case "Wednesday":
            case "Thursday":
            case "Friday":
                Console.WriteLine("Working day");
                break;
            case "Saturday":
            case "Sunday":
                Console.WriteLine("Weekend");
                break;
            default:
                Console.WriteLine("Error");
                break;
        }
    }
}
