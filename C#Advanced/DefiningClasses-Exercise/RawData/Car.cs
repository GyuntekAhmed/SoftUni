using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RawData
{
    public class Car
    {
        private Tire[] tires;
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public Tire[] Tires
        {
            get => tires;
            set
            {
                if (value.Length == 4)
                {
                    tires = value;
                }
            }
        }

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }
    }
    public class Cargo
    {
        public string Type { get; set; }

        public int Weight { get; set; }
    }
    public class Engine
    {
        public int Speed { get; set; }

        public int Power { get; set; }
    }
    public class Tire
    {
        public double Pressure { get; set; }

        public int Age { get; set; }
    }
}
