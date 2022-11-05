using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public interface Vehicles
    {
		public double FuelQuantity { get; }
		public double FuelConsuption { get; }

		double Drive(double distance);
		double Refuel(double quantity);
	}
}
