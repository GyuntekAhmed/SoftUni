using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main()
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            List<IBuyer> buyers = new List<IBuyer>();
            List<IBuyer> totalFoods = new List<IBuyer>();

            int totalFood = 0;

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] info = Console.ReadLine().Split();

                if (info.Length == 4)
                {
                    string name = info[0];
                    int age = int.Parse(info[1]);
                    string id = info[2];
                    string birthdate = info[3];

                    IBuyer citizen = new Citizens(name, age, id, birthdate);
                    buyers.Add(citizen);
                }

                if (info.Length == 3)
                {
                    string name = info[0];
                    int age = int.Parse(info[1]);
                    string group = info[2];

                    IBuyer rebel = new Rebel(name, age, group);
                    buyers.Add(rebel);
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string nameOfBoughtFood = command;

                foreach (var item in buyers)
                {
                    string currentName = item.Name;

                    if (nameOfBoughtFood == currentName)
                    {
                        item.BuyFood();
                        totalFoods.Add(item);
                    }
                }
            }
            totalFood += buyers.Select(x => x.Food).Sum();
            
            Console.WriteLine(totalFood);
        }
    }
}
