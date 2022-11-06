namespace Vehicles
{
    public abstract class Vehicles
    {
		protected Vehicles(double fuelQuantity, double fuelConsuption)
		{
			FuelQuantity = fuelQuantity;
			FuelConsumption = fuelConsuption;
		}

		public double FuelQuantity { get; set; }

		public virtual double FuelConsumption { get; set; }

		public bool CanDrive(double distance)
			=> FuelQuantity - (distance * FuelConsumption) >= 0;


        public void Drive(double distance)
		{
			if (CanDrive(distance))
			{
				FuelQuantity -= distance * FuelConsumption;
			}
		}
		public virtual void Refuel(double quantity)
		{
			FuelQuantity += quantity;
		}
	}
}
