using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.MealPlan
{
    internal class Startup
    {
        static void Main()
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split());

            Stack<int> dailyCalories = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList());

        }
    }
}
