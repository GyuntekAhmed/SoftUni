using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._Speed_Racing
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfCars = int.Parse(Console.ReadLine());
            Car[] cars = new Car[countOfCars];

            for (int i = 0; i < countOfCars; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                double fuelAmount = double.Parse(tokens[1]);
                double consumPerKilom = double.Parse(tokens[2]);

                cars[i] = new Car(model, fuelAmount, consumPerKilom);
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split();

                string model = tokens[1];
                double distance = double.Parse(tokens[2]);

                cars.Where(x => x.Model == model).ToList().ForEach(c => c.Drive(distance));

                command = Console.ReadLine();
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
            }
        }
    }

    public class Car
    {
        public Car(string model, double fuelAmount, double consumPerKilom)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.ConsumPerKilom = consumPerKilom;
            this.TraveledDistance = 0;
        }

        public string Model;
        public double FuelAmount;
        public double ConsumPerKilom;
        public double TraveledDistance;
        public void Drive(double distance)
        {
            if (this.FuelAmount < distance * this.ConsumPerKilom)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                this.FuelAmount -= distance * this.ConsumPerKilom;
                this.TraveledDistance += distance;
            }
        }
    }

}
