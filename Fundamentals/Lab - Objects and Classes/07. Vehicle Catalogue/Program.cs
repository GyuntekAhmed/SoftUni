using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Catallog catallog = new Catallog();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] tokens = command.Split("/");

                string type = tokens[0];

                if (type == "Truck")
                {
                    Truck truck = new Truck
                    {
                        Brand = tokens[1],
                        Model = tokens[2],
                        Weight = int.Parse(tokens[3])
                    };
                    catallog.Trucks.Add(truck);
                }
                else if (type == "Car")
                {
                    Car car = new Car
                    {
                        Brand = tokens[1],
                        Model = tokens[2],
                        HorsePower = int.Parse(tokens[3])
                    };
                    catallog.Cars.Add(car);
                }
            }

            if (catallog.Cars.Count > 0)
            {
                List<Car> orderedCars = catallog.Cars.OrderBy(c => c.Brand).ToList();
                Console.WriteLine("Cars:");

                foreach (var car in orderedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (catallog.Trucks.Count > 0)
            {
                List<Truck> orderedTrukcs = catallog.Trucks.OrderBy(c => c.Brand).ToList();
                Console.WriteLine("Trucks:");

                foreach (var truck in orderedTrukcs)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }

        }
    }

    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Weight { get; set; }
    }
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }
    class Catallog
    {
        public Catallog()
        {
            this.Cars = new List<Car>();
            this.Trucks = new List<Truck>();
        }
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }
}
