using System;

namespace Vehicles
{
    public class Car : Vehicles
    {
        public Car(double fuelQuantity, double fuelConsuption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsuption = fuelConsuption + 0.9;
        }

        public double FuelQuantity { get; set; }

        public double FuelConsuption { get; set; }

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
            FuelQuantity += quantity;
            return FuelQuantity;
        }
    }
}
