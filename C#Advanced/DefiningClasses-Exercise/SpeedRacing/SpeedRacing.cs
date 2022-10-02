using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SpeedRacing
{
    public class SpeedRacing
    {
        static void Main()
        {
            List<Car> cars = new List<Car>();

            int countOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfCars; i++)
            {
                string[] carsInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carsInfo[0];
                double fuelAmount = double.Parse(carsInfo[1]);
                double FuelConsumptionPerKilometer = double.Parse(carsInfo[2]);

                Car car = new Car(model, fuelAmount, FuelConsumptionPerKilometer);

                cars.Add(car);
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = tokens[1];
                double amountOfKm = double.Parse(tokens[2]);

                Car carToDrive = cars.First(car => car.Model == carModel);

                carToDrive.Drive(amountOfKm);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
