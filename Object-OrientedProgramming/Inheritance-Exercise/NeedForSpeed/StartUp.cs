using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main()
        {
            Car car = new Car(155, 75);
            car.Drive(50);
            SportCar sportCar = new SportCar(235, 85);
            sportCar.Drive(30);

            Console.WriteLine(car.Fuel);
            Console.WriteLine(sportCar.Fuel);
        }
    }
}
