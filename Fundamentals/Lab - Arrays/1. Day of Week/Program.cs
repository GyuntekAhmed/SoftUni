using System;

namespace _1._Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            int dayOfWeek = int.Parse(Console.ReadLine());
            string[] weekDays =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday",
            };

            if (dayOfWeek >= 1 && dayOfWeek <= 7)
            {
                dayOfWeek--;

                Console.WriteLine(weekDays[dayOfWeek]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
