using System;

namespace Vehicles
{
    public class Car : Vehicles
    {
        public Car(double fuelQuantity, double fuelConsuption)
            : base(fuelQuantity, fuelConsuption)
        {

        }

        public override double FuelConsumption
            => base.FuelConsumption + 0.9;
    }
}
