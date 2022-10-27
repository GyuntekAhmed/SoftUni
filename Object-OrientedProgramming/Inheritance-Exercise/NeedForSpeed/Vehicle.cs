
namespace NeedForSpeed
{
    public class Vehicle
    {
		private const double DEFAULT_FUEL_CONSUMTION = 1.25;


        public Vehicle( int horsePower, double fuel )
		{
			HorsePower = horsePower;
			Fuel = fuel;
		}

		public double Fuel { get; set; }

		public int HorsePower { get; set; }

		public virtual double FuelConsumption
			=> DEFAULT_FUEL_CONSUMTION;

		public virtual void Drive(double kilometers)
		{
			if (this.Fuel - (kilometers * this.FuelConsumption) >= 0)
			{
				this.Fuel -= kilometers * this.FuelConsumption;
			}
		}
	}
}
