﻿using System;
using System.ComponentModel.DataAnnotations;

namespace VehiclesExtension
{
    public abstract class Vehicles
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicles(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public double TankCapacity
        {
            get { return this.tankCapacity; }
            set
            {
                Validator.CheckPositiveNumber(value);
                this.tankCapacity = value;
            }
        }

        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set
            {
                Validator.CheckPositiveNumber(value);
                this.fuelQuantity = value;
            }
        }

        public abstract void Drive(double distance);

        public abstract void Refuel(double liters);

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
