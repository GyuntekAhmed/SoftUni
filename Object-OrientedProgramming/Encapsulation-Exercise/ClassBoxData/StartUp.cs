using System;

namespace ClassBoxData
{
    public class StartUp
    {
        static void Main()
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());


            Box box = new Box(length, width, height);
            try
            {
                var surfaceArea = box.SurfaceArea(length, width, height);
                var lateral = box.LateralSurfaceArea(length, width, height);
                 var volume = box.Volume(length, width, height);

                Console.WriteLine($"Surface Area - {surfaceArea:f2}");
                Console.WriteLine($"Lateral Surface Area - {lateral:f2}");
                Console.WriteLine($"Volume - {volume:f2}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
