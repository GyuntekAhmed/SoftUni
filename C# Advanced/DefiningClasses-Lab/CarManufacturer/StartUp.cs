using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Engine engine = new Engine(155, 2.2);

            Tire[] tires = new Tire[4]
            {
                new Tire(2022, 5),
                new Tire(2022, 5),
                new Tire(2022, 5),
                new Tire(2022, 5),
            };

            Car car = new Car("Hyundai", "Santa Fe", 2009, 75, 10.5, engine, tires);

            while (true)
            {

                Console.WriteLine("Where to go ?");

                car.Drive(int.Parse(Console.ReadLine()));
                Console.WriteLine($"{car.Tires[0].Pressure}");
                Console.WriteLine($"Left fuel: {car.FuelQuantity}");
                Console.WriteLine($"{car.WhoAmI()}");

            }
        }
    }
}
