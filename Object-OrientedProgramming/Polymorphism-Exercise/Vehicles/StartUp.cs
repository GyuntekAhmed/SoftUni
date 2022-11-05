using System;
using System.Collections.Generic;

namespace Vehicles
{
    public class StartUp
    {
        static void Main()
        {
            string[] carInfo = Console.ReadLine().Split();

            Vehicles car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));

            string[] truckInfo = Console.ReadLine().Split();

            Vehicles truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));


            int countOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfCommands; i++)
            {
                string[] commands = Console.ReadLine().Split();

                if (commands[0] == "Drive")
                {
                    try
                    {
                        if (commands[1] == "Car")
                        {
                            car.Drive(double.Parse(commands[2]));
                            Console.WriteLine($"Car travelled {commands[2]} km");
                        }
                        else
                        {
                            truck.Drive(double.Parse(commands[2]));
                            Console.WriteLine($"Truck travelled {commands[2]} km");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    if (commands[1] == "Car")
                    {
                        car.Refuel(double.Parse(commands[2]));
                    }
                    else
                    {
                        truck.Refuel(double.Parse(commands[2]));
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }
    }
}
