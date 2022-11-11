namespace Vehicles
{
    using System;
    public class Truck : Vehicles
    {
        public Truck(double fuelQuantity, double fuelConsuption)
            : base(fuelQuantity, fuelConsuption)
        {
        }

        public override double FuelConsumption
            => base.FuelConsumption + 1.6;

        public override void Refuel(double quantity)
        {
            quantity *= 0.95;
            base.Refuel(quantity);
        }
    }
}
