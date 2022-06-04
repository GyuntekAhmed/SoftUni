using System;

namespace _8._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int nLines =int.Parse(Console.ReadLine());
            double biggestKegs = double.MinValue;

            string biggestKegName = "";

            for (int i = 0; i < nLines; i++)
            {
                string model = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int hight =int.Parse(Console.ReadLine());

                // π * r^2 * h. 
                double volumeOfCurrentKeg = Math.PI * Math.Pow(radius, 2) * hight;

                if (volumeOfCurrentKeg > biggestKegs)
                {
                    biggestKegs = volumeOfCurrentKeg;
                    biggestKegName = model;
                }
            }

            Console.WriteLine(biggestKegName);
        }
    }
}
