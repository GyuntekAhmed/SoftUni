namespace VehiclesExtension
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }

        public double FuelConsumption { get; }

        public double Capacity { get; }

        public bool IsEmpty { get; set; }

        public bool CanRefuel(double quantity);

        public bool CanDrive(double distance);

        public void Drive(double distance);

        public void Refuel(double quantity);
    }
}
