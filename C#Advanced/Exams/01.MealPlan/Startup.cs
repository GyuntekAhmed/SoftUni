using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.MealPlan
{
    internal class Startup
    {
        static void Main()
        {
            Dictionary<string, int> mealsAndCalories = new Dictionary<string, int>
            {
                {"salad", 350 },
                {"soup", 490 },
                {"pasta", 680 },
                {"steak", 790 }
            };
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split());

            Stack<int> dailyCalories = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList());
            int numberOfMeals = 0;

            int currentCalories = dailyCalories.Peek();

            while (meals.Count > 0)
            {
                if (dailyCalories.Count == 0)
                {
                    break;
                }
                string currentMeal = meals.Peek();
                currentCalories -= mealsAndCalories[currentMeal];

                if (currentCalories <= 0)
                {
                    dailyCalories.Pop();
                    if (dailyCalories.Count != 0)
                    {
                        currentCalories = dailyCalories.Peek() - Math.Abs(currentCalories);
                    }
                    else
                    {
                        currentCalories = Math.Abs(currentCalories);
                        numberOfMeals--;
                        meals.Dequeue();
                        numberOfMeals++;
                        break;
                    }

                }

                meals.Dequeue();
                dailyCalories.Pop();
                dailyCalories.Push(currentCalories);
                numberOfMeals++;
            }

            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {numberOfMeals} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", dailyCalories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {numberOfMeals} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
    }
}
