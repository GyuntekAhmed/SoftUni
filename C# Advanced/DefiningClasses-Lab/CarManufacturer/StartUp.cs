using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Car car = new Car()
            {
                Make = "Hyundai",
                Model = "Santa Fe",
                Year = 2009,
                FuelConsumption = 10.5,
                FuelQuantity = 75,
            };

            while (true)
            {
                Console.WriteLine("Where to go ?");

                car.Drive(int.Parse(Console.ReadLine()));

                Console.WriteLine($"Left fuel: {car.FuelQuantity}");
                Console.WriteLine($"{car.WhoAmI()}");
            }
        }
    }
}
