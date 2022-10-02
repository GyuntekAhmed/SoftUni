using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class RawData
    {
        static void Main()
        {
            List<Car> cars = new List<Car>();

            int countOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfCars; i++)
            {
                string[] input = Console.ReadLine().Split(' ', 6);

                var cargo = new Cargo();
                var engine = new Engine();
                var tires = new List<Tire>();

                string model = input[0];
                engine.Speed = int.Parse(input[1]);
                engine.Power = int.Parse(input[2]);
                cargo.Weight = int.Parse(input[3]);
                cargo.Type = input[4];
                var spliter = input[5].Split().ToArray();

                for (int j = 0; j < spliter.Length; j+= 2)
                {
                    var tire = new Tire();
                    tire.Pressure = double.Parse(spliter[j]);
                    tire.Age = int.Parse(spliter[j + 1]);

                    tires.Add(tire);
                }

                var car = new Car(model, engine, cargo, tires.ToArray());

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                DisplayFragile(cars);
            }
            else
            {
                DisplayFlamable(cars);
            }
        }

         static void DisplayFragile(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                string model = string.Empty;

                foreach (Tire tire in car.Tires)
                {
                    if (tire.Pressure < 1 && car.Model != model)
                    {
                        model = car.Model;
                        Console.WriteLine(model);
                    }
                }
            }
        }

        static void DisplayFlamable(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                if (car.Engine.Power > 250)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
