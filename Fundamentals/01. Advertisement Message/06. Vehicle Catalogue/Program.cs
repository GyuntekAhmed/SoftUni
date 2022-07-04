using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "End")
                {
                    break;
                }

                VehicleType vehicleType;
                bool isVehicleTypeSuccesfull = Enum.TryParse(input[0], true, out vehicleType);

                if (isVehicleTypeSuccesfull)
                {
                    string vehicleModel = input[1];
                    string vehicleColor = input[2];
                    int vehicleHorsePower = int.Parse(input[3]);

                    Vehicle currentVehicle = new Vehicle(vehicleType, vehicleModel, vehicleColor, vehicleHorsePower);
                    vehicles.Add(currentVehicle);
                }
            }

            while (true)
            {
                string comands = Console.ReadLine();

                if (comands == "Close the Catalogue")
                {
                    break;
                }

                Vehicle desiredVehicle = vehicles.FirstOrDefault(vehicle => vehicle.Model == comands);

                Console.WriteLine(desiredVehicle);
            }

            List<Vehicle> cars = vehicles.Where(vehicle => vehicle.Type == VehicleType.Car).ToList();
            List<Vehicle> trucks = vehicles.Where(vehicle => vehicle.Type == VehicleType.Truck).ToList();

            double carsAvarageHorsePower = cars.Count > 0 ? cars.Average(car => car.HorsePower) : 0.00;
            double trucksAvarageHorsePower = trucks.Count > 0 ? trucks.Average(truck => truck.HorsePower) : 0.00;

            Console.WriteLine($"Cars have average horsepower of: {carsAvarageHorsePower:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksAvarageHorsePower:f2}.");
        }
    }

    enum VehicleType
    {
        Car,
        Truck
    }
    class Vehicle
    {
        public Vehicle(VehicleType type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;

        }
        public VehicleType Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Type: {Type}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"Color: {Color}");
            sb.AppendLine($"Horsepower: {HorsePower}");

            return sb.ToString().TrimEnd();
        }
    }
}
