using System;

namespace Restaurant
{
    public class StartUp
    {
        static void Main()
        {
            Cake cake = new Cake("MyCake");

            Console.WriteLine(cake.Name);
            Console.WriteLine(cake.Price);
        }
    }
}
