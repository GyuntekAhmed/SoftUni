using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfCarsToPass = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();

            int totalCarsPassed = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "green")
                {
                    for (int i = 0; i < countOfCarsToPass; i++)
                    {
                        if (cars.Count > 0)
                        {
                            string car = cars.Dequeue();

                            Console.WriteLine($"{car} passed!");

                            totalCarsPassed++;
                        }
                    }
                }
                else if (command == "end")
                {
                    Console.WriteLine($"{totalCarsPassed} cars passed the crossroads.");
                    break;
                }
                else
                {
                    cars.Enqueue(command);
                }
            }
        }
    }
}
