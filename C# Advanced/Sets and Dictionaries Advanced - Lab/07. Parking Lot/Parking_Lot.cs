using System;
using System.Collections.Generic;

class Parking_Lot
{
    static void Main()
    {
        HashSet<string> cars = new HashSet<string>();

        while (true)
        {
            string command = Console.ReadLine();

            if (command == "END")
            {
                PrintCars(cars);
                break;
            }

            string[] splited = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string action = splited[0];
            string car = splited[1];

            AddCars(cars, car, action);
        }
    }

    static void AddCars(HashSet<string> cars, string car, string action)
    {
        if (action == "IN")
        {
            cars.Add(car);
        }
        if (action == "OUT")
        {
            cars.Remove(car);
        }

    }

    static void PrintCars(HashSet<string> cars)
    {
        if (cars.Count == 0)
        {
            Console.WriteLine("Parking Lot is Empty");
        }

        foreach (string car in cars)
        {
            Console.WriteLine(car);
        }
    }
}
