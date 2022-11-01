using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
		private string model;
		private string color;
		private int batery;

		public Tesla(string model, string color, int batery)
		{
			Model = model;
			Color = color;
			Batery = batery;
		}

		public string Model
		{
			get { return model; }
			set { model = value; }
		}

		public string Color
		{
			get { return color; }
			set { color = value; }
		}

		public int Batery
		{
			get { return batery; }
			set { batery = value; }
		}

		public override string ToString()
		{
			return $"{Color} Tesla {Model} with {Batery} Batteries";

        }
	}
}
