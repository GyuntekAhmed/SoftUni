using System;

namespace Vehicles
{
    public class Truck : Vehicles
    {
        public Truck(double fuelQuantity, double fuelConsuption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsuption = fuelConsuption + 1.6;
        }

        public double FuelQuantity {get;set;}

        public double FuelConsuption {get;set;}

        public double Drive(double distance)
        {
            double result = distance * FuelConsuption;

            if (FuelQuantity < result)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }
           FuelQuantity -= result;
            return FuelQuantity;
        }

        public double Refuel(double quantity)
        {
            quantity *= 0.95;
            FuelQuantity += quantity;

            return FuelQuantity;
        }
    }
}
