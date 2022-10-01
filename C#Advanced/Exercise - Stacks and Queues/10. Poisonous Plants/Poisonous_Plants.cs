using System;
using System.Collections.Generic;
using System.Linq;

class Poisonous_Plants
{
    static void Main()
    {
        int numberPlants = int.Parse(Console.ReadLine());

        List<int> plants = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        Stack<int> deadPlantsIndexes = new Stack<int>();

        int dayCounter = 0;

        while (true)
        {
            dayCounter++;

            int lastDeadDay = 0;

            for (int i = 0; i < numberPlants - 1; i++)
            {
                if (plants[i + 1] > plants[i])
                {
                    deadPlantsIndexes.Push(i + 1);

                    lastDeadDay = 1;
                }
            }

            int deadPlantsCount = deadPlantsIndexes.Count;

            for (int i = 0; i < deadPlantsCount; i++)
            {
                plants.RemoveAt(deadPlantsIndexes.Pop());
            }

            numberPlants = plants.Count;

            if (lastDeadDay == 0)
            {
                Console.WriteLine(dayCounter - 1);
                return;
            }
        }

    }
}
